using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    class Interface : TextBox
    {
        // number of past commands stored
        private const int MAX_LINES = 100;
        // maximun chars in a command
        private const int MAX_LENGTH = 80;
        // history of previous commands
        private char[][] commands;
        // index of displayed command
        private int current;

        // current caret position on the line
        private int pos;
        // furthest right caret position
        private int end;

        public Interface()
        {
            Multiline = true;
            BorderStyle = BorderStyle.None;
            Dock = DockStyle.Fill;
            Margin = new Padding(1, 1, 1, 1);
            BackColor = Color.Black;
            ForeColor = Color.Lime;

            commands = new char[MAX_LINES][];
            for (int k = 0; k < MAX_LINES; k++)
                commands[k] = new char[MAX_LENGTH];
            current = 0;

            pos = 0;
            end = 0;
            //MessageBox.Show("You typed a character.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            end++;
            Insert(e.KeyChar, pos++);
            base.OnKeyPress(e);
        }
        private void Insert(char input, int position)
        {
            if (position < end)
                for (int k = end; k > position; k--)
                    commands[0][k] = commands[0][k - 1];
            commands[0][position] = input;
        }
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            int dist = 0;
            switch (keyData)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    MoveCaret('B');
                    break;
                case Keys.Right:
                    MoveCaret('F');
                    break;

                case Keys.Control | Keys.Left:
                    MoveCaret('L');
                    break;
                case Keys.Control | Keys.Alt | Keys.Left:
                    MoveCaret('S');
                    break;
                case Keys.Control | Keys.Right:
                    MoveCaret('R');
                    break;
                case Keys.Control | Keys.Alt | Keys.Right:
                    MoveCaret('D');
                    break;

                case Keys.Home:
                    MoveCaret('S');
                    break;
                case Keys.End:
                    MoveCaret('D');
                    break;

                case Keys.Shift | Keys.Left:
                    break;
                case Keys.Control | Keys.Shift | Keys.Left:
                    break;
                case Keys.Shift | Keys.Right:
                    break;
                case Keys.Control | Keys.Shift | Keys.Right:
                    break;

                case Keys.Back:
                    DEL(-1);
                    break;
                case Keys.Control | Keys.Back:
                    DEL(dist = NextWordIndex(-1) - pos);
                    break;

                case Keys.Delete:
                    DEL(1);
                    break;
                case Keys.Control | Keys.Delete:
                    DEL(dist = NextWordIndex(1) - pos);
                    break;

                case Keys.Space:
                    if (pos != 0 && end < MAX_LENGTH - 1 && commands[0][pos-1] != ' ')
                        return base.ProcessCmdKey(ref m, keyData);
                    break;
                case Keys.Enter:
                    Debug.WriteLine(
                        "Length: " + end + ", Stored Command: " + new string(commands[0])
                    );
                    DEL(dist = 0 - pos);
                    break;
                default:
                    if (end < MAX_LENGTH - 1)
                        foreach (Keys kd in Stale.ValidKeys)
                            if (keyData == kd || keyData == (kd | Keys.Shift))
                                return base.ProcessCmdKey(ref m, keyData);
                    break;
            }
            return true;
        }
        private void MoveCaret(char step = 'F')
        {
            int dist = 0;
            switch (step)
            {
                case 'S': // move to the start of line
                    pos += (dist = 0 - pos);
                    break;
                case 'D': // move to the end of line
                    pos += (dist = end - pos);
                    break;
                case 'L': // move left one word
                    pos += (dist = NextWordIndex(-1) - pos);
                    break;
                case 'R': // move right one word
                    pos += (dist = NextWordIndex(1) - pos);
                    break;
                case 'B': // move left one letter
                    if (pos > 0)
                        pos += (dist = -1);
                    break;
                default: // move right one letter
                    if (pos < end)
                        pos += (dist = 1);
                    break;
            }
            Select(SelectionStart + dist, 0);
        }
        private void DEL(int dist = 1)
        {
            if (dist == 0) return;
            if (dist > 0)
            {
                if (pos >= end) return;
                if (pos + dist > end)
                    dist = end - pos;
                Select(SelectionStart, dist);
            }
            else
            {
                if (pos <= 0) return;
                if (pos + dist < 0)
                {
                    dist = pos;
                    pos = 0;
                }
                else
                {
                    pos += dist;
                    dist = -dist;
                }
                Select(SelectionStart, -dist);
            }
            SelectedText = "";

            end -= dist;
            for (int k = pos; k < end + dist; k++)
                if (k < end)
                    commands[0][k] = commands[0][k + dist];
                else
                    commands[0][k] = new char();
        }
        private int NextWordIndex(int dir = 1)
        {
            if (dir < 0)
            {
                for (int k = pos - 1; k > 0; k--)
                    if (commands[0][k] == ' ')
                        return k;
                return 0;
            }
            for (int k = pos + 1; k < end; k++)
                if (commands[0][k] == ' ')
                    return k;
            return end;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0201://WM_LBUTTONDOWN
                    return;
                case 0x0202://WM_LBUTTONUP
                    return;
                case 0x0203://WM_LBUTTONDBLCLK
                    return;
                case 0x0204://WM_RBUTTONDOWN
                    return;
                case 0x0205://WM_RBUTTONUP
                    return;
                case 0x0206://WM_RBUTTONDBLCLK
                    return;
                default:
                    base.WndProc(ref m);
                    return;
            }
        }
    }
}

using System;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Terminal
{
    partial class Andesite
    {
        #region Initializers

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.terminal = new Terminal.Interface();
            this.SuspendLayout();
            // 
            // terminal
            // 
            this.terminal.BackColor = System.Drawing.Color.Black;
            this.terminal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminal.ForeColor = System.Drawing.Color.Lime;
            this.terminal.Location = new System.Drawing.Point(0, 0);
            this.terminal.Margin = new System.Windows.Forms.Padding(1);
            this.terminal.Multiline = true;
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(782, 503);
            this.terminal.TabIndex = 0;
            // 
            // Andesite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 503);
            this.Controls.Add(this.terminal);
            this.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Andesite";
            this.RightToLeftLayout = true;
            this.Text = "Obsidian";
            this.Load += new System.EventHandler(this.Andesite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Helper Functions

        private void disp(String msg)
        {
            string output = "";
            foreach (char c in msg)
                if (c == '\n')
                    output += Environment.NewLine;
                else
                    output += c;
            this.terminal.AppendText(output);
        }

        #endregion

        #region Attributes

        private Interface terminal;

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    public partial class Andesite : Form
    {
        public Andesite()
        {
            InitializeComponent();
        }

        private void Andesite_Load(object sender, EventArgs e)
        {
            disp(Stale.Version + "\n");
            disp(Stale.Author + "\n\n");
            disp("login as: ");
        }
    }
}

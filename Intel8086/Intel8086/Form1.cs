using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intel8086
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AX_TextBox_TextChanged(object sender, EventArgs e)
        {
            string AX = AX_TextBox.Text;
            string AH = AX.Substring(0, 4);
            string AL = AX.Substring(4, 4);
        }

        private void AH_TextBox_TextChanged(object sender, EventArgs e)
        {
            AH_TextBox.Text = AH;
        }
    }
}

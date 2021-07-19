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

        

        private void Send_Button_Click(object sender, EventArgs e)
        {
            if (CLI_Textbox.Text.Length == 0)
            {
                MessageBox.Show("Command is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string command = CLI_Textbox.Text;

                string[] commandStringArr = command.Split(' ');

                string commandType = commandStringArr[0].ToLower();

                if (commandType == "zero")
                {
                    ZeroRegisters();
                    CLI_Textbox.Text = "";
                }
            }
        }

        private void ZeroRegisters()
        {
            AX_Textbox.Text = "0000";
            BX_Textbox.Text = "0000";
            CX_Textbox.Text = "0000";
            DX_Textbox.Text = "0000";
        }

        private void CLI_Textbox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

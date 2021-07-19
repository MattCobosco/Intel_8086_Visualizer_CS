using System;
using System.Windows.Forms;

namespace Intel8086
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Send_Button_Click(object sender, EventArgs e) // enter button (previously send) initializes commands
        {
            if (CLI_Textbox.Text.Length == 0) // 
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
                else if (commandType == "random")
                {
                    RandomRegisters();
                }
            }
        }

        private void RandomRegisters()
        {
            // input random 4-digit hex values into X registers;
            Random random = new Random();
            int numAX = random.Next(0, 65535);
            int numBX = random.Next(0, 65535);
            int numCX = random.Next(0, 65535);
            int numDX = random.Next(0, 65535);
            string hexStringAX = numAX.ToString("X");
            string hexStringBX = numBX.ToString("X");
            string hexStringCX = numCX.ToString("X");
            string hexStringDX = numDX.ToString("X");

            AX_Textbox.Text = hexStringAX;
            BX_Textbox.Text = hexStringBX;
            CX_Textbox.Text = hexStringDX;
            DX_Textbox.Text = hexStringCX;

            EqualizeX_HL();
        }

        private void ZeroRegisters() // fill X registers with 4 zeros
        {
            AX_Textbox.Text = "0000";
            BX_Textbox.Text = "0000";
            CX_Textbox.Text = "0000";
            DX_Textbox.Text = "0000";
            EqualizeX_HL();
        }

        private void EqualizeX_HL() // parse all X registers into respective H and L registers to keep them up to date. Used after any/all (cmds: zero, random) X registers are modified
        {
            AH_Textbox.Text = AX_Textbox.Text.Substring(0, 2);
            AL_Textbox.Text = AX_Textbox.Text.Substring(2, 2);
            BH_Textbox.Text = BX_Textbox.Text.Substring(0, 2);
            BL_Textbox.Text = BX_Textbox.Text.Substring(2, 2);
            CH_Textbox.Text = CX_Textbox.Text.Substring(0, 2);
            CL_Textbox.Text = CX_Textbox.Text.Substring(2, 2);
            DH_Textbox.Text = DX_Textbox.Text.Substring(0, 2);
            DL_Textbox.Text = DX_Textbox.Text.Substring(2, 2);
        }

        private void EqualizeHL_X() // join all H and L registers into X registers to keep them up to date. Used  after any H or L register is modified
        {
            throw new NotImplementedException();
        }
    }
}

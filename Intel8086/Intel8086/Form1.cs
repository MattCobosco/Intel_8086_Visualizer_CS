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
            if (CLI_Textbox.Text.Length == 0) // if there's no command, show warning popup
            {
                MessageBox.Show("Command is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string command = CLI_Textbox.Text; // get the command as string

                string[] commandStringArr = command.Split(' '); // split it into string array

                string commandType = commandStringArr[0].ToLower(); // get the first word from the command. It will determine what action needs to be taken

                if (commandType == "zero")
                {
                    if (commandStringArr.Length > 1) // if zero command has too many elements, show warning popup asking to use the correct command
                    {
                        MessageBox.Show("Command has too many elements. Try \"zero\"!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ZeroRegisters();
                        CLI_Textbox.Text = "";
                    }

                }
                else if (commandType == "random")
                {
                    if (commandStringArr.Length > 1) // if random command has too many elements, show warning popup asking to use the correct command
                    {
                        MessageBox.Show("Command has too many elements. Try \"random\"!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        RandomRegisters();
                        CLI_Textbox.Text = "";
                    }
                }
            }
        }

        private void RandomRegisters()
        {
            // input random 4-digit hex values into all X registers;
            Random random = new Random();
            int numAX = random.Next(0, 65536);
            int numBX = random.Next(0, 65536);
            int numCX = random.Next(0, 65536);
            int numDX = random.Next(0, 65536);
            string hexStringAX = numAX.ToString("X4");
            string hexStringBX = numBX.ToString("X4");
            string hexStringCX = numCX.ToString("X4");
            string hexStringDX = numDX.ToString("X4");

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

        private void EqualizeHL_X() // join all H and L registers into X registers to keep them up to date. Used after any H or L register is modified
        {
            AX_Textbox.Text = AH_Textbox.Text + AL_Textbox.Text;
            BX_Textbox.Text = BH_Textbox.Text + BL_Textbox.Text;
            CX_Textbox.Text = CH_Textbox.Text + CL_Textbox.Text;
            DX_Textbox.Text = DH_Textbox.Text + DL_Textbox.Text;
        }
    }
}

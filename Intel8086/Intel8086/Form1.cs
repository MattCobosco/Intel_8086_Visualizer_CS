using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intel8086
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RandomRegisters(); // program starts with random hex values in the register
        }

        private void Send_Button_Click(object sender, EventArgs e) // enter button (previously send) initializes commands
        {
            if (CLI_Textbox.Text.Length == 0) // if there's no command, show warning popup message box
            {
                MessageBox.Show("Command is empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string command = CLI_Textbox.Text; // get the command as string

                CLI_History_ListBox.Items.Add(CLI_Textbox.Text); // command is saved to the history list box

                ReverseListBoxOrder(); // most recent command is always on top

                string[] commandStringArr = command.Split(' '); // split it into string array

                string commandType = commandStringArr[0].ToLower(); // get the first word from the command. It will determine what action needs to be taken

                if (commandType == "zero")
                {
                    if (commandStringArr.Length > 1) // if zero command has too many elements, show warning popup asking to use the correct command
                    {
                        MessageBox.Show("Command has too many elements. \nTry \"zero\".", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else // else zero the registers
                    {
                        ZeroRegisters();
                    }

                }
                else if (commandType == "random")
                {
                    if (commandStringArr.Length > 1) // if random command has too many elements, show warning popup asking to use the correct command
                    {
                        MessageBox.Show("Command has too many elements. \nTry \"random\".", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else // else fill the registers with random 4-digit hex numbers
                    {
                        RandomRegisters();
                    }
                }
                else if (commandType == "mov")
                {
                    string commandAux1 = commandStringArr[1].ToLower(); // get additional info from command
                    string commandAux2 = commandStringArr[2].ToLower();
                    bool commandIsNum = int.TryParse(commandAux2, out int commandAux2Num); // determine whether the user wants to move value from one register to another or whether they want to move number to a register

                    if (commandIsNum) // if the user wants to move a number then use the method MovCommand which accepts a string and an int as parameters
                    {
                        MovCommand(commandAux1, commandAux2Num);
                    }
                    else // if the user wants to move a value from one register to another then use the method MovCommand which accepts two strings as parameters
                    {
                        MovCommand(commandAux1, commandAux2);
                    }

                }
                else if (commandType == "xchg") /* TODO: Exchg command */
                {

                }
                else // any different command returns a popup error message box
                {
                    MessageBox.Show("Command unknown. \nPlease take a look at the command list at the bottom of the main window.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CLI_Textbox.Text = ""; // clears the command line after the command execution

                CLI_Textbox.Focus(); // keeps the focus on the command line instead of focusing on the send button after it's clicked to activate the command
            }


        }

        private void ReverseListBoxOrder() // reverses the order of items in the history to show the most recent command on top
        {
            for (int i = 0; i < CLI_History_ListBox.Items.Count / 2; i++)
            {
                var tmp = CLI_History_ListBox.Items[i];
                CLI_History_ListBox.Items[i] = CLI_History_ListBox.Items[CLI_History_ListBox.Items.Count - i - 1];
                CLI_History_ListBox.Items[CLI_History_ListBox.Items.Count - i - 1] = tmp;
            }
        }

        private void MovCommand(string regOne, string regTwo)
        {
            if (regOne == regTwo) // if user tries to move values between the same index, an error message box appears
            {
                MessageBox.Show("Wrong command. \nCannot move the value between the same registers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<string> XRegList = new List<string>() // lists with X and HL register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

                List<string> HLRegList = new List<string>()
                {
                    "ah", "bh", "ch", "dh", "al", "bl", "cl", "dl"
                };


                if (XRegList.Contains(regOne) && XRegList.Contains(regTwo)) // if both registers given in the mov command belong to the X register (8bit) indes list then it's possible to move the value
                {
                    if (regOne == "ax" && regTwo == "bx") // HACK: Find a less retarded way to move values in registers - perhaps lists with elements displayed in textboxes?
                    {
                        AX_Textbox.Text = BX_Textbox.Text;
                    }
                    else if (regOne == "ax" && regTwo == "cx")
                    {
                        AX_Textbox.Text = CX_Textbox.Text;
                    }
                    else if (regOne == "ax" && regTwo == "dx")
                    {
                        AX_Textbox.Text = DX_Textbox.Text;
                    }
                    else if (regOne == "bx" && regTwo == "ax")
                    {
                        BX_Textbox.Text = AX_Textbox.Text;
                    }
                    else if (regOne == "bx" && regTwo == "cx")
                    {
                        BX_Textbox.Text = CX_Textbox.Text;
                    }
                    else if (regOne == "bx" && regTwo == "dx")
                    {
                        BX_Textbox.Text = DX_Textbox.Text;
                    }
                    else if (regOne == "cx" && regTwo == "ax")
                    {
                        CX_Textbox.Text = AX_Textbox.Text;
                    }
                    else if (regOne == "cx" && regTwo == "bx")
                    {
                        CX_Textbox.Text = BX_Textbox.Text;
                    }
                    else if (regOne == "cx" && regTwo == "dx")
                    {
                        CX_Textbox.Text = DX_Textbox.Text;
                    }
                    else if (regOne == "dx" && regTwo == "ax")
                    {
                        DX_Textbox.Text = AX_Textbox.Text;
                    }
                    else if (regOne == "dx" && regTwo == "bx")
                    {
                        DX_Textbox.Text = BX_Textbox.Text;
                    }
                    else if (regOne == "dx" && regTwo == "dx")
                    {
                        DX_Textbox.Text = DX_Textbox.Text;
                    }

                    EqualizeX_HL();
                }
                else if (HLRegList.Contains(regOne) && HLRegList.Contains(regTwo)) // if both registers belong to H/L register (4bit) list then it's possible to move their value
                {
                    if (regOne == "al" && regTwo == "bl") // HACK: Find a less retarded way to move values in registers - perhaps lists with elements displayed in textboxes?
                    {
                        AL_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "cl")
                    {
                        AL_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "dl")
                    {
                        AL_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "ah")
                    {
                        AL_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "bh")
                    {
                        AL_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "ch")
                    {
                        AL_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "al" && regTwo == "dh")
                    {
                        AL_Textbox.Text = DH_Textbox.Text;
                    }

                    else if (regOne == "bl" && regTwo == "al")
                    {
                        BL_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "cl")
                    {
                        BL_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "dl")
                    {
                        BL_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "ah")
                    {
                        BL_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "bh")
                    {
                        BL_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "ch")
                    {
                        BL_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "bl" && regTwo == "dh")
                    {
                        BL_Textbox.Text = DH_Textbox.Text;
                    }


                    else if (regOne == "cl" && regTwo == "al")
                    {
                        CL_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "bl")
                    {
                        CL_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "dl")
                    {
                        CL_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "ah")
                    {
                        CL_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "bh")
                    {
                        CL_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "ch")
                    {
                        CL_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "cl" && regTwo == "dh")
                    {
                        CL_Textbox.Text = DH_Textbox.Text;
                    }

                    else if (regOne == "dl" && regTwo == "al")
                    {
                        DL_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "bl")
                    {
                        DL_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "cl")
                    {
                        DL_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "ah")
                    {
                        DL_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "bh")
                    {
                        DL_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "ch")
                    {
                        DL_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "dl" && regTwo == "dh")
                    {
                        DL_Textbox.Text = DH_Textbox.Text;
                    }


                    else if (regOne == "ah" && regTwo == "al")
                    {
                        AH_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "bl")
                    {
                        AH_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "cl")
                    {
                        AH_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "dl")
                    {
                        AH_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "bh")
                    {
                        AH_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "ch")
                    {
                        AH_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "ah" && regTwo == "dh")
                    {
                        AH_Textbox.Text = DH_Textbox.Text;
                    }

                    else if (regOne == "bh" && regTwo == "al")
                    {
                        BH_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "bl")
                    {
                        BH_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "cl")
                    {
                        BH_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "dl")
                    {
                        BH_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "ah")
                    {
                        BH_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "ch")
                    {
                        BH_Textbox.Text = CH_Textbox.Text;
                    }
                    else if (regOne == "bh" && regTwo == "dh")
                    {
                        BH_Textbox.Text = DH_Textbox.Text;
                    }

                    else if (regOne == "ch" && regTwo == "al")
                    {
                        CH_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "bl")
                    {
                        CH_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "cl")
                    {
                        CH_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "dl")
                    {
                        CH_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "ah")
                    {
                        CH_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "bh")
                    {
                        CH_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "ch" && regTwo == "dh")
                    {
                        CH_Textbox.Text = DH_Textbox.Text;
                    }

                    else if (regOne == "dh" && regTwo == "al")
                    {
                        DH_Textbox.Text = AL_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "bl")
                    {
                        DH_Textbox.Text = BL_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "cl")
                    {
                        DH_Textbox.Text = CL_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "dl")
                    {
                        DH_Textbox.Text = DL_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "ah")
                    {
                        DH_Textbox.Text = AH_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "bh")
                    {
                        DH_Textbox.Text = BH_Textbox.Text;
                    }
                    else if (regOne == "dh" && regTwo == "ch")
                    {
                        DH_Textbox.Text = CH_Textbox.Text;
                    }

                    EqualizeHL_X();
                }
                else // it's impossible to move values in all other instances where the user provides two register indexes => the error popup message box will be displayed to the user
                {
                    MessageBox.Show("Wrong command. \nCannot move the value between registers of a different size.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MovCommand(string regOne, int regTwo) /* TODO: create option to add values to the register with mov */
        {
            throw new NotImplementedException();
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

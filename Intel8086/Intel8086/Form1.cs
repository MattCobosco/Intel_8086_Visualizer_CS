using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intel8086
{
    public partial class Form1 : Form
    {
        Stack<string> intelStack = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
            ZeroRegisters(); // program starts with zeros in the registers
        }

        public void Send_Button_Click(object sender, EventArgs e) // enter button (previously send) initializes commands
        {
            try
            {
                if (CLI_Textbox.Text.Length == 0) // if there's no command, show warning popup message box
                {
                    EmptyCommand();
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
                        if (commandStringArr.Length > 1) // if zero command has too many arguments, show warning popup asking to use the correct command
                        {
                            CommandTooManyArguments();
                        }
                        else // else set the registers to zero
                        {
                            ZeroRegisters();
                            ClearConsole();
                        }
                    }
                    else if (commandType == "random")
                    {
                        if (commandStringArr.Length > 1) // if random command has too many arguments, show warning popup asking to use the correct command
                        {
                            CommandTooManyArguments();
                        }
                        else // else fill the registers with random 4-digit hex numbers
                        {
                            RandomRegisters();
                            ClearConsole();
                        }
                    }
                    else if (commandType == "mov")
                    {
                        if (commandStringArr.Length > 3)
                        {
                            CommandTooManyArguments();
                        }
                        else
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
                    }
                    else if (commandType == "xchg")
                    {
                        if (commandStringArr.Length > 3)
                        {
                            CommandTooManyArguments();
                        }
                        else
                        {
                            string commandAux1 = commandStringArr[1].ToLower(); // get additional info from command
                            string commandAux2 = commandStringArr[2].ToLower();
                            XchgCommand(commandAux1, commandAux2);
                        }
                    }
                    else if (commandType == "push")
                    {
                        if (commandStringArr.Length > 2)
                        {
                            CommandTooManyArguments();
                        }
                        else
                        {
                            string commandAux = commandStringArr[1].ToLower();
                            PushUpdateStackPointer();
                            PushCommandStack(commandAux);
                        }
                    }
                    else if (commandType == "pop")
                    {
                        if (commandStringArr.Length > 2)
                        {
                            CommandTooManyArguments();
                            ClearConsole();
                        }
                        else
                        {
                            string commandAux = commandStringArr[1].ToLower();
                            PopUpdateStackPointer();
                            PopCommandStack(commandAux);
                            ClearConsole();
                        }
                    }
                    else // any different command returns a popup error message box
                    {
                        WrongCommand();
                    }

                    CLI_Textbox.Focus(); // keeps the focus on the command line instead of focusing on the send button after it's clicked to activate the command
                }
            }
            catch (IndexOutOfRangeException)
            {
                WrongCommand();
            }
        }

        private void PopCommandStack(string commandAux) // TODO: figure out how to make the stack work
        {
            try
            {

                List<string> XRegList = new List<string>() // lists with X register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

                if (XRegList.Contains(commandAux))
                {
                    if (commandAux == "ax")
                    {
                        AX_Textbox.Text = intelStack.Peek();
                    }
                    else if (commandAux == "bx")
                    {
                        BX_Textbox.Text = intelStack.Peek();
                    }
                    else if (commandAux == "cx")
                    {
                        CX_Textbox.Text = intelStack.Peek();
                    }
                    else
                    {
                        DX_Textbox.Text = intelStack.Peek();
                    }
                }
                else
                {
                    WrongCommand();
                }

                intelStack.Pop();
                EqualizeX_HL();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Stack is empty, cannot POP.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PushCommandStack(string commandAux)
        {
            try
            {
                List<string> XRegList = new List<string>() // lists with X register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

                if (XRegList.Contains(commandAux))
                {
                    if (commandAux == "ax")
                    {
                        intelStack.Push(AX_Textbox.Text);
                    }
                    else if (commandAux == "bx")
                    {
                        intelStack.Push(BX_Textbox.Text);
                    }
                    else if (commandAux == "cx")
                    {
                        intelStack.Push(CX_Textbox.Text);
                    }
                    else
                    {
                        intelStack.Push(DX_Textbox.Text);
                    }
                }
                else
                {
                    WrongCommand();
                }
            }
            catch (System.InvalidOperationException)
            {

            }
        }

        private void PopUpdateStackPointer()
        {
            int intValue = Convert.ToInt32(SP_Textbox.Text, 16);

            if (intValue < 65534) //checks if theres anything on the stack before trying to pop
            {
                intValue += 2;
                string hexValue = intValue.ToString("X4");
                SP_Textbox.Text = hexValue;
            }
        }

        private void PushUpdateStackPointer()
        {
            int intValue = Convert.ToInt32(SP_Textbox.Text, 16);

            if (intValue > 1) // checks if the stack is full before trying to push another value
            {
                intValue -= 2;
                string hexValue = intValue.ToString("X4");
                SP_Textbox.Text = hexValue;
            }
            else
            {
                MessageBox.Show("Stack is full, cannot PUSH.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XchgCommand(string commandAux1, string commandAux2)
        {

            List<string> XRegList = new List<string>() // lists with X and HL register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

            List<string> HLRegList = new List<string>()
                {
                    "ah", "bh", "ch", "dh", "al", "bl", "cl", "dl"
                };


            if (XRegList.Contains(commandAux1) && XRegList.Contains(commandAux2)) // if both registers given in the xchg command belong to the X register (16bit) index list then it's possible to exchange their values
            {
                string temp;
                if (commandAux1 == "ax" && commandAux2 == "bx")
                {
                    temp = AX_Textbox.Text;
                    AX_Textbox.Text = BX_Textbox.Text;
                    BX_Textbox.Text = temp;
                }
                else if (commandAux1 == "ax" && commandAux2 == "cx")
                {
                    temp = AX_Textbox.Text;
                    AX_Textbox.Text = CX_Textbox.Text;
                    CX_Textbox.Text = temp;
                }
                else if (commandAux1 == "ax" && commandAux2 == "dx")
                {
                    temp = AX_Textbox.Text;
                    AX_Textbox.Text = DX_Textbox.Text;
                    DX_Textbox.Text = temp;
                }
                else if (commandAux1 == "bx" && commandAux2 == "ax")
                {
                    temp = BX_Textbox.Text;
                    BX_Textbox.Text = AX_Textbox.Text;
                    AX_Textbox.Text = temp;
                }
                else if (commandAux1 == "bx" && commandAux2 == "cx")
                {
                    temp = BX_Textbox.Text;
                    BX_Textbox.Text = CX_Textbox.Text;
                    CX_Textbox.Text = temp;
                }
                else if (commandAux1 == "bx" && commandAux2 == "dx")
                {
                    temp = BX_Textbox.Text;
                    BX_Textbox.Text = DX_Textbox.Text;
                    DX_Textbox.Text = temp;
                }
                else if (commandAux1 == "cx" && commandAux2 == "ax")
                {
                    temp = CX_Textbox.Text;
                    CX_Textbox.Text = AX_Textbox.Text;
                    AX_Textbox.Text = temp;
                }
                else if (commandAux1 == "cx" && commandAux2 == "bx")
                {
                    temp = CX_Textbox.Text;
                    CX_Textbox.Text = BX_Textbox.Text;
                    BX_Textbox.Text = temp;
                }
                else if (commandAux1 == "cx" && commandAux2 == "dx")
                {
                    temp = CX_Textbox.Text;
                    CX_Textbox.Text = DX_Textbox.Text;
                    DX_Textbox.Text = temp;
                }
                else if (commandAux1 == "dx" && commandAux2 == "ax")
                {
                    temp = DX_Textbox.Text;
                    DX_Textbox.Text = AX_Textbox.Text;
                    AX_Textbox.Text = temp;
                }
                else if (commandAux1 == "dx" && commandAux2 == "bx")
                {
                    temp = DX_Textbox.Text;
                    DX_Textbox.Text = BX_Textbox.Text;
                    BX_Textbox.Text = temp;
                }
                else if (commandAux1 == "dx" && commandAux2 == "cx")
                {
                    temp = DX_Textbox.Text;
                    DX_Textbox.Text = CX_Textbox.Text;
                    CX_Textbox.Text = temp;
                }

                ClearConsole(); // clears the command line after the command is entered
                EqualizeX_HL(); // update the H and L registers with the corresponding values X register
            }
            else if (HLRegList.Contains(commandAux1) && HLRegList.Contains(commandAux2)) // if both registers belong to H/L register (8bit) list then it's possible to move their value
            {
                string temp;

                if ((commandAux1 == "al" && commandAux2 == "bl") || (commandAux1 == "bl" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = BL_Textbox.Text;
                    BL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "cl") || (commandAux1 == "cl" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = CL_Textbox.Text;
                    CL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "dl") || (commandAux1 == "dl" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = DL_Textbox.Text;
                    DL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "ah") || (commandAux1 == "ah" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = AH_Textbox.Text;
                    AH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "bh") || (commandAux1 == "bh" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = BH_Textbox.Text;
                    BH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "al" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "al"))
                {
                    temp = AL_Textbox.Text;
                    AL_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "cl") || (commandAux1 == "cl" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = CL_Textbox.Text;
                    CL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "dl") || (commandAux1 == "dl" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = DL_Textbox.Text;
                    DL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "ah") || (commandAux1 == "ah" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = AH_Textbox.Text;
                    AH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "bh") || (commandAux1 == "bh" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = BH_Textbox.Text;
                    BH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bl" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "bl"))
                {
                    temp = BL_Textbox.Text;
                    BL_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "cl" && commandAux2 == "dl") || (commandAux1 == "dl" && commandAux2 == "cl"))
                {
                    temp = CL_Textbox.Text;
                    CL_Textbox.Text = DL_Textbox.Text;
                    DL_Textbox.Text = temp;
                }
                else if ((commandAux1 == "cl" && commandAux2 == "ah") || (commandAux1 == "ah" && commandAux2 == "cl"))
                {
                    temp = CL_Textbox.Text;
                    CL_Textbox.Text = AH_Textbox.Text;
                    AH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "cl" && commandAux2 == "bh") || (commandAux1 == "bh" && commandAux2 == "cl"))
                {
                    temp = CL_Textbox.Text;
                    CL_Textbox.Text = BH_Textbox.Text;
                    BH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "cl" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "cl"))
                {
                    temp = CL_Textbox.Text;
                    CL_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "cl" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "cl"))
                {
                    temp = CL_Textbox.Text;
                    CL_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "dl" && commandAux2 == "ah") || (commandAux1 == "ah" && commandAux2 == "dl"))
                {
                    temp = DL_Textbox.Text;
                    DL_Textbox.Text = AH_Textbox.Text;
                    AH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "dl" && commandAux2 == "bh") || (commandAux1 == "bh" && commandAux2 == "dl"))
                {
                    temp = DL_Textbox.Text;
                    DL_Textbox.Text = BH_Textbox.Text;
                    BH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "dl" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "dl"))
                {
                    temp = DL_Textbox.Text;
                    DL_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "dl" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "dl"))
                {
                    temp = DL_Textbox.Text;
                    DL_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "ah" && commandAux2 == "bh") || (commandAux1 == "bh" && commandAux2 == "ah"))
                {
                    temp = AH_Textbox.Text;
                    AH_Textbox.Text = BH_Textbox.Text;
                    BH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "ah" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "ah"))
                {
                    temp = AH_Textbox.Text;
                    AH_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "ah" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "ah"))
                {
                    temp = AH_Textbox.Text;
                    AH_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bh" && commandAux2 == "ch") || (commandAux1 == "ch" && commandAux2 == "bh"))
                {
                    temp = BH_Textbox.Text;
                    BH_Textbox.Text = CH_Textbox.Text;
                    CH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "bh" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "bh"))
                {
                    temp = BH_Textbox.Text;
                    BH_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }
                else if ((commandAux1 == "ch" && commandAux2 == "dh") || (commandAux1 == "dh" && commandAux2 == "ch"))
                {
                    temp = CH_Textbox.Text;
                    CH_Textbox.Text = DH_Textbox.Text;
                    DH_Textbox.Text = temp;
                }

                ClearConsole(); // clears the command line after the command is entered
                EqualizeHL_X(); // update the H and L registers with corresponding values from the X register
            }
            else if ((!XRegList.Contains(commandAux1) && !HLRegList.Contains(commandAux1)) || (!XRegList.Contains(commandAux2) && !HLRegList.Contains(commandAux2))) // warns of using an unexisting register index
            {
                MessageBox.Show("Wrong command. \nWrong register index.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // it's impossible to move values in all other instances where the user provides two register indexes => the error popup message box will be displayed to the user
            {
                MessageBox.Show("Wrong command. \nCannot exchange the value between registers of a different size.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MovCommand(string commandAux1, string commandAux2) // method for moving value of one index to another index // HACK: Find a less retarded way to move values in registers - perhaps lists / dictionaries with elements displayed in textboxes ?
        {

            List<string> XRegList = new List<string>() // lists with X and HL register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

            List<string> HLRegList = new List<string>()
                {
                    "ah", "bh", "ch", "dh", "al", "bl", "cl", "dl"
                };


            if (XRegList.Contains(commandAux1) && XRegList.Contains(commandAux2)) // if both registers given in the mov command belong to the X register (16bit) index list then it's possible to move the value
            {
                if (commandAux1 == "ax" && commandAux2 == "bx")
                {
                    AX_Textbox.Text = BX_Textbox.Text;
                }
                else if (commandAux1 == "ax" && commandAux2 == "cx")
                {
                    AX_Textbox.Text = CX_Textbox.Text;
                }
                else if (commandAux1 == "ax" && commandAux2 == "dx")
                {
                    AX_Textbox.Text = DX_Textbox.Text;
                }
                else if (commandAux1 == "bx" && commandAux2 == "ax")
                {
                    BX_Textbox.Text = AX_Textbox.Text;
                }
                else if (commandAux1 == "bx" && commandAux2 == "cx")
                {
                    BX_Textbox.Text = CX_Textbox.Text;
                }
                else if (commandAux1 == "bx" && commandAux2 == "dx")
                {
                    BX_Textbox.Text = DX_Textbox.Text;
                }
                else if (commandAux1 == "cx" && commandAux2 == "ax")
                {
                    CX_Textbox.Text = AX_Textbox.Text;
                }
                else if (commandAux1 == "cx" && commandAux2 == "bx")
                {
                    CX_Textbox.Text = BX_Textbox.Text;
                }
                else if (commandAux1 == "cx" && commandAux2 == "dx")
                {
                    CX_Textbox.Text = DX_Textbox.Text;
                }
                else if (commandAux1 == "dx" && commandAux2 == "ax")
                {
                    DX_Textbox.Text = AX_Textbox.Text;
                }
                else if (commandAux1 == "dx" && commandAux2 == "bx")
                {
                    DX_Textbox.Text = BX_Textbox.Text;
                }
                else if (commandAux1 == "dx" && commandAux2 == "cx")
                {
                    DX_Textbox.Text = CX_Textbox.Text;
                }

                ClearConsole(); // clears the command line after the command is entered
                EqualizeX_HL(); // update the H and L registers with the corresponding values X register
            }
            else if (HLRegList.Contains(commandAux1) && HLRegList.Contains(commandAux2)) // if both registers belong to H/L register (8bit) list then it's possible to move their value
            {
                if (commandAux1 == "al" && commandAux2 == "bl")
                {
                    AL_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "cl")
                {
                    AL_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "dl")
                {
                    AL_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "ah")
                {
                    AL_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "bh")
                {
                    AL_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "ch")
                {
                    AL_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "al" && commandAux2 == "dh")
                {
                    AL_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "al")
                {
                    BL_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "cl")
                {
                    BL_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "dl")
                {
                    BL_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "ah")
                {
                    BL_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "bh")
                {
                    BL_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "ch")
                {
                    BL_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "bl" && commandAux2 == "dh")
                {
                    BL_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "al")
                {
                    CL_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "bl")
                {
                    CL_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "dl")
                {
                    CL_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "ah")
                {
                    CL_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "bh")
                {
                    CL_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "ch")
                {
                    CL_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "cl" && commandAux2 == "dh")
                {
                    CL_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "al")
                {
                    DL_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "bl")
                {
                    DL_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "cl")
                {
                    DL_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "ah")
                {
                    DL_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "bh")
                {
                    DL_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "ch")
                {
                    DL_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "dl" && commandAux2 == "dh")
                {
                    DL_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "al")
                {
                    AH_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "bl")
                {
                    AH_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "cl")
                {
                    AH_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "dl")
                {
                    AH_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "bh")
                {
                    AH_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "ch")
                {
                    AH_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "ah" && commandAux2 == "dh")
                {
                    AH_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "al")
                {
                    BH_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "bl")
                {
                    BH_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "cl")
                {
                    BH_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "dl")
                {
                    BH_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "ah")
                {
                    BH_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "ch")
                {
                    BH_Textbox.Text = CH_Textbox.Text;
                }
                else if (commandAux1 == "bh" && commandAux2 == "dh")
                {
                    BH_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "al")
                {
                    CH_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "bl")
                {
                    CH_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "cl")
                {
                    CH_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "dl")
                {
                    CH_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "ah")
                {
                    CH_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "bh")
                {
                    CH_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "ch" && commandAux2 == "dh")
                {
                    CH_Textbox.Text = DH_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "al")
                {
                    DH_Textbox.Text = AL_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "bl")
                {
                    DH_Textbox.Text = BL_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "cl")
                {
                    DH_Textbox.Text = CL_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "dl")
                {
                    DH_Textbox.Text = DL_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "ah")
                {
                    DH_Textbox.Text = AH_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "bh")
                {
                    DH_Textbox.Text = BH_Textbox.Text;
                }
                else if (commandAux1 == "dh" && commandAux2 == "ch")
                {
                    DH_Textbox.Text = CH_Textbox.Text;
                }

                ClearConsole(); // clears the command line after the command is entered
                EqualizeHL_X(); // update the H and L registers with corresponding values from the X register
            }
            else if ((!XRegList.Contains(commandAux1) && !HLRegList.Contains(commandAux1)) || (!XRegList.Contains(commandAux2) && !HLRegList.Contains(commandAux2))) // warns of using an unexisting register index
            {
                MessageBox.Show("Wrong command. \nWrong register index.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // warns of trying to move value between the registers of a different size (H/L -> X and vice versa)
            {
                MessageBox.Show("Wrong command. \nCannot exchange the value between registers of a different size.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MovCommand(string commandAux1, int commandAux2) /* method to add values to the register with mov */ //HACK: Find a better way to do this
        {
            List<string> XRegList = new List<string>() // lists with X and HL register indexes to check command validity
                {
                    "ax", "bx", "cx", "dx"
                };

            List<string> HLRegList = new List<string>()
                {
                    "ah", "bh", "ch", "dh", "al", "bl", "cl", "dl"
                };

            if (XRegList.Contains(commandAux1) || HLRegList.Contains(commandAux1)) // check if the register index provided in the command exists
            {
                if (XRegList.Contains(commandAux1)) // check if it's for the X register
                {
                    if (commandAux2 > 65535) // if the int is too big, warn the user
                    {
                        MessageBox.Show("Wrong command. \nIndex overflow. \nTry int smaller or equal to 65,535.");
                    }
                    else
                    {
                        string Hex4 = commandAux2.ToString("X4"); // convert the into into a 4-digit hex

                        if (commandAux1 == "ax") // change the requested register
                        {
                            AX_Textbox.Text = Hex4;
                        }
                        else if (commandAux1 == "bx")
                        {
                            BX_Textbox.Text = Hex4;
                        }
                        else if (commandAux1 == "cx")
                        {
                            BX_Textbox.Text = Hex4;
                        }
                        else if (commandAux1 == "dx")
                        {
                            BX_Textbox.Text = Hex4;
                        }

                        EqualizeX_HL();
                    }
                }
                else // if it's not the X register then it must be the H/L register
                {
                    if (commandAux2 > 255) // if the int is too big, warn the user
                    {
                        MessageBox.Show("Wrong command. \nIndex overflow. \nTry int smaller or equal to 255.");
                    }
                    else
                    {
                        string Hex2 = commandAux2.ToString("X2"); // generate a 2-digit hex 

                        if (commandAux1 == "al") // and put it in the requested register
                        {
                            AL_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "bl")
                        {
                            BL_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "cl")
                        {
                            CL_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "dl")
                        {
                            DL_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "ah")
                        {
                            AH_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "bh")
                        {
                            BH_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "ch")
                        {
                            CH_Textbox.Text = Hex2;
                        }
                        else if (commandAux1 == "dh")
                        {
                            DH_Textbox.Text = Hex2;
                        }
                    }

                    EqualizeHL_X();
                }
            }
            else
            {
                MessageBox.Show("Wrong command. \nWrong register index.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Zero / Random
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

        private void ZeroRegisters() // fill X registers and Stack Pointer with zeros
        {
            AX_Textbox.Text = "0000";
            BX_Textbox.Text = "0000";
            CX_Textbox.Text = "0000";
            DX_Textbox.Text = "0000";
            SP_Textbox.Text = 65534.ToString("X4");
            EqualizeX_HL();
        }

        // Updating X and H/L registers after modifications
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

        // GUI Maintenance
        private void ClearConsole()
        {
            CLI_Textbox.Text = "";
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

        // Errors
        private void EmptyCommand()
        {
            MessageBox.Show("Command is empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void WrongCommand()
        {
            MessageBox.Show("Wrong command. \nPlease check the command before trying again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CommandTooManyArguments()
        {
            MessageBox.Show("Command has too many arguments. \nCheck available commands and try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

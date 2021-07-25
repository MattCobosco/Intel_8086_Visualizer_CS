
namespace Intel8086
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AX_Textbox = new System.Windows.Forms.TextBox();
            this.BX_Textbox = new System.Windows.Forms.TextBox();
            this.CX_Textbox = new System.Windows.Forms.TextBox();
            this.DX_Textbox = new System.Windows.Forms.TextBox();
            this.AX_Lbl = new System.Windows.Forms.Label();
            this.BX_Lbl = new System.Windows.Forms.Label();
            this.CX_Lbl = new System.Windows.Forms.Label();
            this.DX_Lbl = new System.Windows.Forms.Label();
            this.AH_Lbl = new System.Windows.Forms.Label();
            this.BH_Lbl = new System.Windows.Forms.Label();
            this.CH_Lbl = new System.Windows.Forms.Label();
            this.DH_Lbl = new System.Windows.Forms.Label();
            this.AL_Lbl = new System.Windows.Forms.Label();
            this.BL_Lbl = new System.Windows.Forms.Label();
            this.CL_Lbl = new System.Windows.Forms.Label();
            this.DL_Lbl = new System.Windows.Forms.Label();
            this.CLI_Textbox = new System.Windows.Forms.TextBox();
            this.Enter_Button = new System.Windows.Forms.Button();
            this.BH_Textbox = new System.Windows.Forms.TextBox();
            this.AH_Textbox = new System.Windows.Forms.TextBox();
            this.DH_Textbox = new System.Windows.Forms.TextBox();
            this.CH_Textbox = new System.Windows.Forms.TextBox();
            this.DL_Textbox = new System.Windows.Forms.TextBox();
            this.CL_Textbox = new System.Windows.Forms.TextBox();
            this.BL_Textbox = new System.Windows.Forms.TextBox();
            this.AL_Textbox = new System.Windows.Forms.TextBox();
            this.CLI_History_ListBox = new System.Windows.Forms.ListBox();
            this.Command_Desc_Lbl = new System.Windows.Forms.Label();
            this.SI_Textbox = new System.Windows.Forms.TextBox();
            this.DI_Textbox = new System.Windows.Forms.TextBox();
            this.BP_Textbox = new System.Windows.Forms.TextBox();
            this.SP_Textbox = new System.Windows.Forms.TextBox();
            this.DISP_Textbox = new System.Windows.Forms.TextBox();
            this.SI_Lbl = new System.Windows.Forms.Label();
            this.DI_Lbl = new System.Windows.Forms.Label();
            this.BP_Lbl = new System.Windows.Forms.Label();
            this.SP_Lbl = new System.Windows.Forms.Label();
            this.DISP_Lbl = new System.Windows.Forms.Label();
            this.Command_History_Lbl = new System.Windows.Forms.Label();
            this.Indexed_Rbtn = new System.Windows.Forms.RadioButton();
            this.Based_Rbtn = new System.Windows.Forms.RadioButton();
            this.Based_Indexed_Rbtn = new System.Windows.Forms.RadioButton();
            this.None_Rbtn = new System.Windows.Forms.RadioButton();
            this.MemtoReg_Rbtn = new System.Windows.Forms.RadioButton();
            this.RegToMem_Rbtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AX_Textbox
            // 
            this.AX_Textbox.Enabled = false;
            this.AX_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AX_Textbox.Location = new System.Drawing.Point(83, 27);
            this.AX_Textbox.MaxLength = 4;
            this.AX_Textbox.Name = "AX_Textbox";
            this.AX_Textbox.ReadOnly = true;
            this.AX_Textbox.Size = new System.Drawing.Size(100, 29);
            this.AX_Textbox.TabIndex = 0;
            this.AX_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BX_Textbox
            // 
            this.BX_Textbox.Enabled = false;
            this.BX_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BX_Textbox.Location = new System.Drawing.Point(83, 76);
            this.BX_Textbox.MaxLength = 4;
            this.BX_Textbox.Name = "BX_Textbox";
            this.BX_Textbox.ReadOnly = true;
            this.BX_Textbox.Size = new System.Drawing.Size(100, 29);
            this.BX_Textbox.TabIndex = 3;
            this.BX_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CX_Textbox
            // 
            this.CX_Textbox.Enabled = false;
            this.CX_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CX_Textbox.Location = new System.Drawing.Point(83, 126);
            this.CX_Textbox.MaxLength = 4;
            this.CX_Textbox.Name = "CX_Textbox";
            this.CX_Textbox.ReadOnly = true;
            this.CX_Textbox.Size = new System.Drawing.Size(100, 29);
            this.CX_Textbox.TabIndex = 5;
            this.CX_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DX_Textbox
            // 
            this.DX_Textbox.Enabled = false;
            this.DX_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DX_Textbox.Location = new System.Drawing.Point(83, 175);
            this.DX_Textbox.MaxLength = 4;
            this.DX_Textbox.Name = "DX_Textbox";
            this.DX_Textbox.ReadOnly = true;
            this.DX_Textbox.Size = new System.Drawing.Size(100, 29);
            this.DX_Textbox.TabIndex = 6;
            this.DX_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AX_Lbl
            // 
            this.AX_Lbl.AutoSize = true;
            this.AX_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AX_Lbl.Location = new System.Drawing.Point(47, 30);
            this.AX_Lbl.Name = "AX_Lbl";
            this.AX_Lbl.Size = new System.Drawing.Size(29, 21);
            this.AX_Lbl.TabIndex = 12;
            this.AX_Lbl.Text = "AX";
            // 
            // BX_Lbl
            // 
            this.BX_Lbl.AutoSize = true;
            this.BX_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BX_Lbl.Location = new System.Drawing.Point(47, 76);
            this.BX_Lbl.Name = "BX_Lbl";
            this.BX_Lbl.Size = new System.Drawing.Size(28, 21);
            this.BX_Lbl.TabIndex = 13;
            this.BX_Lbl.Text = "BX";
            // 
            // CX_Lbl
            // 
            this.CX_Lbl.AutoSize = true;
            this.CX_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CX_Lbl.Location = new System.Drawing.Point(47, 129);
            this.CX_Lbl.Name = "CX_Lbl";
            this.CX_Lbl.Size = new System.Drawing.Size(29, 21);
            this.CX_Lbl.TabIndex = 14;
            this.CX_Lbl.Text = "CX";
            // 
            // DX_Lbl
            // 
            this.DX_Lbl.AutoSize = true;
            this.DX_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DX_Lbl.Location = new System.Drawing.Point(47, 178);
            this.DX_Lbl.Name = "DX_Lbl";
            this.DX_Lbl.Size = new System.Drawing.Size(30, 21);
            this.DX_Lbl.TabIndex = 15;
            this.DX_Lbl.Text = "DX";
            // 
            // AH_Lbl
            // 
            this.AH_Lbl.AutoSize = true;
            this.AH_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AH_Lbl.Location = new System.Drawing.Point(219, 30);
            this.AH_Lbl.Name = "AH_Lbl";
            this.AH_Lbl.Size = new System.Drawing.Size(31, 21);
            this.AH_Lbl.TabIndex = 16;
            this.AH_Lbl.Text = "AH";
            // 
            // BH_Lbl
            // 
            this.BH_Lbl.AutoSize = true;
            this.BH_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BH_Lbl.Location = new System.Drawing.Point(218, 79);
            this.BH_Lbl.Name = "BH_Lbl";
            this.BH_Lbl.Size = new System.Drawing.Size(30, 21);
            this.BH_Lbl.TabIndex = 17;
            this.BH_Lbl.Text = "BH";
            // 
            // CH_Lbl
            // 
            this.CH_Lbl.AutoSize = true;
            this.CH_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CH_Lbl.Location = new System.Drawing.Point(218, 129);
            this.CH_Lbl.Name = "CH_Lbl";
            this.CH_Lbl.Size = new System.Drawing.Size(31, 21);
            this.CH_Lbl.TabIndex = 18;
            this.CH_Lbl.Text = "CH";
            // 
            // DH_Lbl
            // 
            this.DH_Lbl.AutoSize = true;
            this.DH_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DH_Lbl.Location = new System.Drawing.Point(219, 178);
            this.DH_Lbl.Name = "DH_Lbl";
            this.DH_Lbl.Size = new System.Drawing.Size(32, 21);
            this.DH_Lbl.TabIndex = 19;
            this.DH_Lbl.Text = "DH";
            // 
            // AL_Lbl
            // 
            this.AL_Lbl.AutoSize = true;
            this.AL_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AL_Lbl.Location = new System.Drawing.Point(356, 30);
            this.AL_Lbl.Name = "AL_Lbl";
            this.AL_Lbl.Size = new System.Drawing.Size(28, 21);
            this.AL_Lbl.TabIndex = 20;
            this.AL_Lbl.Text = "AL";
            // 
            // BL_Lbl
            // 
            this.BL_Lbl.AutoSize = true;
            this.BL_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BL_Lbl.Location = new System.Drawing.Point(356, 76);
            this.BL_Lbl.Name = "BL_Lbl";
            this.BL_Lbl.Size = new System.Drawing.Size(27, 21);
            this.BL_Lbl.TabIndex = 21;
            this.BL_Lbl.Text = "BL";
            // 
            // CL_Lbl
            // 
            this.CL_Lbl.AutoSize = true;
            this.CL_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CL_Lbl.Location = new System.Drawing.Point(356, 126);
            this.CL_Lbl.Name = "CL_Lbl";
            this.CL_Lbl.Size = new System.Drawing.Size(28, 21);
            this.CL_Lbl.TabIndex = 22;
            this.CL_Lbl.Text = "CL";
            // 
            // DL_Lbl
            // 
            this.DL_Lbl.AutoSize = true;
            this.DL_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DL_Lbl.Location = new System.Drawing.Point(356, 178);
            this.DL_Lbl.Name = "DL_Lbl";
            this.DL_Lbl.Size = new System.Drawing.Size(29, 21);
            this.DL_Lbl.TabIndex = 23;
            this.DL_Lbl.Text = "DL";
            // 
            // CLI_Textbox
            // 
            this.CLI_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CLI_Textbox.Location = new System.Drawing.Point(44, 242);
            this.CLI_Textbox.Name = "CLI_Textbox";
            this.CLI_Textbox.Size = new System.Drawing.Size(276, 29);
            this.CLI_Textbox.TabIndex = 24;
            // 
            // Enter_Button
            // 
            this.Enter_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Enter_Button.Location = new System.Drawing.Point(356, 231);
            this.Enter_Button.Name = "Enter_Button";
            this.Enter_Button.Size = new System.Drawing.Size(98, 49);
            this.Enter_Button.TabIndex = 25;
            this.Enter_Button.Text = "Enter";
            this.Enter_Button.UseVisualStyleBackColor = true;
            this.Enter_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // BH_Textbox
            // 
            this.BH_Textbox.Enabled = false;
            this.BH_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BH_Textbox.Location = new System.Drawing.Point(257, 76);
            this.BH_Textbox.MaxLength = 4;
            this.BH_Textbox.Name = "BH_Textbox";
            this.BH_Textbox.ReadOnly = true;
            this.BH_Textbox.Size = new System.Drawing.Size(63, 29);
            this.BH_Textbox.TabIndex = 27;
            this.BH_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AH_Textbox
            // 
            this.AH_Textbox.Enabled = false;
            this.AH_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AH_Textbox.Location = new System.Drawing.Point(257, 27);
            this.AH_Textbox.MaxLength = 4;
            this.AH_Textbox.Name = "AH_Textbox";
            this.AH_Textbox.ReadOnly = true;
            this.AH_Textbox.Size = new System.Drawing.Size(63, 29);
            this.AH_Textbox.TabIndex = 26;
            this.AH_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DH_Textbox
            // 
            this.DH_Textbox.Enabled = false;
            this.DH_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DH_Textbox.Location = new System.Drawing.Point(257, 175);
            this.DH_Textbox.MaxLength = 4;
            this.DH_Textbox.Name = "DH_Textbox";
            this.DH_Textbox.ReadOnly = true;
            this.DH_Textbox.Size = new System.Drawing.Size(63, 29);
            this.DH_Textbox.TabIndex = 29;
            this.DH_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CH_Textbox
            // 
            this.CH_Textbox.Enabled = false;
            this.CH_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CH_Textbox.Location = new System.Drawing.Point(257, 126);
            this.CH_Textbox.MaxLength = 4;
            this.CH_Textbox.Name = "CH_Textbox";
            this.CH_Textbox.ReadOnly = true;
            this.CH_Textbox.Size = new System.Drawing.Size(63, 29);
            this.CH_Textbox.TabIndex = 28;
            this.CH_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DL_Textbox
            // 
            this.DL_Textbox.Enabled = false;
            this.DL_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DL_Textbox.Location = new System.Drawing.Point(391, 172);
            this.DL_Textbox.MaxLength = 4;
            this.DL_Textbox.Name = "DL_Textbox";
            this.DL_Textbox.ReadOnly = true;
            this.DL_Textbox.Size = new System.Drawing.Size(63, 29);
            this.DL_Textbox.TabIndex = 33;
            this.DL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CL_Textbox
            // 
            this.CL_Textbox.Enabled = false;
            this.CL_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CL_Textbox.Location = new System.Drawing.Point(391, 123);
            this.CL_Textbox.MaxLength = 4;
            this.CL_Textbox.Name = "CL_Textbox";
            this.CL_Textbox.ReadOnly = true;
            this.CL_Textbox.Size = new System.Drawing.Size(63, 29);
            this.CL_Textbox.TabIndex = 32;
            this.CL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BL_Textbox
            // 
            this.BL_Textbox.Enabled = false;
            this.BL_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BL_Textbox.Location = new System.Drawing.Point(391, 76);
            this.BL_Textbox.MaxLength = 4;
            this.BL_Textbox.Name = "BL_Textbox";
            this.BL_Textbox.ReadOnly = true;
            this.BL_Textbox.Size = new System.Drawing.Size(63, 29);
            this.BL_Textbox.TabIndex = 31;
            this.BL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AL_Textbox
            // 
            this.AL_Textbox.Enabled = false;
            this.AL_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AL_Textbox.Location = new System.Drawing.Point(391, 27);
            this.AL_Textbox.MaxLength = 4;
            this.AL_Textbox.Name = "AL_Textbox";
            this.AL_Textbox.ReadOnly = true;
            this.AL_Textbox.Size = new System.Drawing.Size(63, 29);
            this.AL_Textbox.TabIndex = 30;
            this.AL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CLI_History_ListBox
            // 
            this.CLI_History_ListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CLI_History_ListBox.FormattingEnabled = true;
            this.CLI_History_ListBox.ItemHeight = 21;
            this.CLI_History_ListBox.Location = new System.Drawing.Point(44, 351);
            this.CLI_History_ListBox.Name = "CLI_History_ListBox";
            this.CLI_History_ListBox.Size = new System.Drawing.Size(203, 214);
            this.CLI_History_ListBox.TabIndex = 34;
            // 
            // Command_Desc_Lbl
            // 
            this.Command_Desc_Lbl.AutoSize = true;
            this.Command_Desc_Lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Command_Desc_Lbl.Location = new System.Drawing.Point(288, 312);
            this.Command_Desc_Lbl.Name = "Command_Desc_Lbl";
            this.Command_Desc_Lbl.Size = new System.Drawing.Size(502, 228);
            this.Command_Desc_Lbl.TabIndex = 35;
            this.Command_Desc_Lbl.Text = resources.GetString("Command_Desc_Lbl.Text");
            // 
            // SI_Textbox
            // 
            this.SI_Textbox.Enabled = false;
            this.SI_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SI_Textbox.Location = new System.Drawing.Point(690, 27);
            this.SI_Textbox.MaxLength = 4;
            this.SI_Textbox.Name = "SI_Textbox";
            this.SI_Textbox.ReadOnly = true;
            this.SI_Textbox.Size = new System.Drawing.Size(100, 29);
            this.SI_Textbox.TabIndex = 39;
            this.SI_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DI_Textbox
            // 
            this.DI_Textbox.Enabled = false;
            this.DI_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DI_Textbox.Location = new System.Drawing.Point(690, 76);
            this.DI_Textbox.MaxLength = 4;
            this.DI_Textbox.Name = "DI_Textbox";
            this.DI_Textbox.ReadOnly = true;
            this.DI_Textbox.Size = new System.Drawing.Size(100, 29);
            this.DI_Textbox.TabIndex = 40;
            this.DI_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BP_Textbox
            // 
            this.BP_Textbox.Enabled = false;
            this.BP_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BP_Textbox.Location = new System.Drawing.Point(690, 123);
            this.BP_Textbox.MaxLength = 4;
            this.BP_Textbox.Name = "BP_Textbox";
            this.BP_Textbox.ReadOnly = true;
            this.BP_Textbox.Size = new System.Drawing.Size(100, 29);
            this.BP_Textbox.TabIndex = 41;
            this.BP_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SP_Textbox
            // 
            this.SP_Textbox.Enabled = false;
            this.SP_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SP_Textbox.Location = new System.Drawing.Point(690, 172);
            this.SP_Textbox.MaxLength = 4;
            this.SP_Textbox.Name = "SP_Textbox";
            this.SP_Textbox.ReadOnly = true;
            this.SP_Textbox.Size = new System.Drawing.Size(100, 29);
            this.SP_Textbox.TabIndex = 42;
            this.SP_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DISP_Textbox
            // 
            this.DISP_Textbox.Enabled = false;
            this.DISP_Textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DISP_Textbox.Location = new System.Drawing.Point(690, 242);
            this.DISP_Textbox.MaxLength = 4;
            this.DISP_Textbox.Name = "DISP_Textbox";
            this.DISP_Textbox.ReadOnly = true;
            this.DISP_Textbox.Size = new System.Drawing.Size(100, 29);
            this.DISP_Textbox.TabIndex = 43;
            this.DISP_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SI_Lbl
            // 
            this.SI_Lbl.AutoSize = true;
            this.SI_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SI_Lbl.Location = new System.Drawing.Point(656, 30);
            this.SI_Lbl.Name = "SI_Lbl";
            this.SI_Lbl.Size = new System.Drawing.Size(23, 21);
            this.SI_Lbl.TabIndex = 44;
            this.SI_Lbl.Text = "SI";
            // 
            // DI_Lbl
            // 
            this.DI_Lbl.AutoSize = true;
            this.DI_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DI_Lbl.Location = new System.Drawing.Point(656, 79);
            this.DI_Lbl.Name = "DI_Lbl";
            this.DI_Lbl.Size = new System.Drawing.Size(25, 21);
            this.DI_Lbl.TabIndex = 45;
            this.DI_Lbl.Text = "DI";
            // 
            // BP_Lbl
            // 
            this.BP_Lbl.AutoSize = true;
            this.BP_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BP_Lbl.Location = new System.Drawing.Point(656, 129);
            this.BP_Lbl.Name = "BP_Lbl";
            this.BP_Lbl.Size = new System.Drawing.Size(28, 21);
            this.BP_Lbl.TabIndex = 46;
            this.BP_Lbl.Text = "BP";
            // 
            // SP_Lbl
            // 
            this.SP_Lbl.AutoSize = true;
            this.SP_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SP_Lbl.Location = new System.Drawing.Point(656, 178);
            this.SP_Lbl.Name = "SP_Lbl";
            this.SP_Lbl.Size = new System.Drawing.Size(28, 21);
            this.SP_Lbl.TabIndex = 47;
            this.SP_Lbl.Text = "SP";
            // 
            // DISP_Lbl
            // 
            this.DISP_Lbl.AutoSize = true;
            this.DISP_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DISP_Lbl.Location = new System.Drawing.Point(641, 245);
            this.DISP_Lbl.Name = "DISP_Lbl";
            this.DISP_Lbl.Size = new System.Drawing.Size(43, 21);
            this.DISP_Lbl.TabIndex = 48;
            this.DISP_Lbl.Text = "DISP";
            // 
            // Command_History_Lbl
            // 
            this.Command_History_Lbl.AutoSize = true;
            this.Command_History_Lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Command_History_Lbl.Location = new System.Drawing.Point(76, 309);
            this.Command_History_Lbl.Name = "Command_History_Lbl";
            this.Command_History_Lbl.Size = new System.Drawing.Size(135, 21);
            this.Command_History_Lbl.TabIndex = 52;
            this.Command_History_Lbl.Text = "Command history";
            // 
            // Indexed_Rbtn
            // 
            this.Indexed_Rbtn.AutoSize = true;
            this.Indexed_Rbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Indexed_Rbtn.Location = new System.Drawing.Point(488, 79);
            this.Indexed_Rbtn.Name = "Indexed_Rbtn";
            this.Indexed_Rbtn.Size = new System.Drawing.Size(114, 23);
            this.Indexed_Rbtn.TabIndex = 49;
            this.Indexed_Rbtn.Text = "Indexed mode";
            this.Indexed_Rbtn.UseVisualStyleBackColor = true;
            // 
            // Based_Rbtn
            // 
            this.Based_Rbtn.AutoSize = true;
            this.Based_Rbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Based_Rbtn.Location = new System.Drawing.Point(488, 125);
            this.Based_Rbtn.Name = "Based_Rbtn";
            this.Based_Rbtn.Size = new System.Drawing.Size(102, 23);
            this.Based_Rbtn.TabIndex = 50;
            this.Based_Rbtn.Text = "Based mode";
            this.Based_Rbtn.UseVisualStyleBackColor = true;
            // 
            // Based_Indexed_Rbtn
            // 
            this.Based_Indexed_Rbtn.AutoSize = true;
            this.Based_Indexed_Rbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Based_Indexed_Rbtn.Location = new System.Drawing.Point(488, 175);
            this.Based_Indexed_Rbtn.Name = "Based_Indexed_Rbtn";
            this.Based_Indexed_Rbtn.Size = new System.Drawing.Size(153, 23);
            this.Based_Indexed_Rbtn.TabIndex = 51;
            this.Based_Indexed_Rbtn.Text = "Based indexed mode";
            this.Based_Indexed_Rbtn.UseVisualStyleBackColor = true;
            // 
            // None_Rbtn
            // 
            this.None_Rbtn.AutoSize = true;
            this.None_Rbtn.Checked = true;
            this.None_Rbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.None_Rbtn.Location = new System.Drawing.Point(488, 30);
            this.None_Rbtn.Name = "None_Rbtn";
            this.None_Rbtn.Size = new System.Drawing.Size(60, 23);
            this.None_Rbtn.TabIndex = 53;
            this.None_Rbtn.TabStop = true;
            this.None_Rbtn.Text = "None";
            this.None_Rbtn.UseVisualStyleBackColor = true;
            // 
            // MemtoReg_Rbtn
            // 
            this.MemtoReg_Rbtn.AutoSize = true;
            this.MemtoReg_Rbtn.Location = new System.Drawing.Point(0, 30);
            this.MemtoReg_Rbtn.Name = "MemtoReg_Rbtn";
            this.MemtoReg_Rbtn.Size = new System.Drawing.Size(126, 19);
            this.MemtoReg_Rbtn.TabIndex = 55;
            this.MemtoReg_Rbtn.Text = "Memory to register";
            this.MemtoReg_Rbtn.UseVisualStyleBackColor = true;
            // 
            // RegToMem_Rbtn
            // 
            this.RegToMem_Rbtn.AutoSize = true;
            this.RegToMem_Rbtn.Checked = true;
            this.RegToMem_Rbtn.Location = new System.Drawing.Point(0, 0);
            this.RegToMem_Rbtn.Name = "RegToMem_Rbtn";
            this.RegToMem_Rbtn.Size = new System.Drawing.Size(129, 19);
            this.RegToMem_Rbtn.TabIndex = 56;
            this.RegToMem_Rbtn.TabStop = true;
            this.RegToMem_Rbtn.Text = "Register to memory";
            this.RegToMem_Rbtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RegToMem_Rbtn);
            this.panel1.Controls.Add(this.MemtoReg_Rbtn);
            this.panel1.Location = new System.Drawing.Point(488, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 49);
            this.panel1.TabIndex = 57;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 603);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.None_Rbtn);
            this.Controls.Add(this.Command_History_Lbl);
            this.Controls.Add(this.Based_Indexed_Rbtn);
            this.Controls.Add(this.Based_Rbtn);
            this.Controls.Add(this.Indexed_Rbtn);
            this.Controls.Add(this.DISP_Lbl);
            this.Controls.Add(this.SP_Lbl);
            this.Controls.Add(this.BP_Lbl);
            this.Controls.Add(this.DI_Lbl);
            this.Controls.Add(this.SI_Lbl);
            this.Controls.Add(this.DISP_Textbox);
            this.Controls.Add(this.SP_Textbox);
            this.Controls.Add(this.BP_Textbox);
            this.Controls.Add(this.DI_Textbox);
            this.Controls.Add(this.SI_Textbox);
            this.Controls.Add(this.Command_Desc_Lbl);
            this.Controls.Add(this.CLI_History_ListBox);
            this.Controls.Add(this.DL_Textbox);
            this.Controls.Add(this.CL_Textbox);
            this.Controls.Add(this.BL_Textbox);
            this.Controls.Add(this.AL_Textbox);
            this.Controls.Add(this.DH_Textbox);
            this.Controls.Add(this.CH_Textbox);
            this.Controls.Add(this.BH_Textbox);
            this.Controls.Add(this.AH_Textbox);
            this.Controls.Add(this.Enter_Button);
            this.Controls.Add(this.CLI_Textbox);
            this.Controls.Add(this.DL_Lbl);
            this.Controls.Add(this.CL_Lbl);
            this.Controls.Add(this.BL_Lbl);
            this.Controls.Add(this.AL_Lbl);
            this.Controls.Add(this.DH_Lbl);
            this.Controls.Add(this.CH_Lbl);
            this.Controls.Add(this.BH_Lbl);
            this.Controls.Add(this.AH_Lbl);
            this.Controls.Add(this.DX_Lbl);
            this.Controls.Add(this.CX_Lbl);
            this.Controls.Add(this.BX_Lbl);
            this.Controls.Add(this.AX_Lbl);
            this.Controls.Add(this.DX_Textbox);
            this.Controls.Add(this.CX_Textbox);
            this.Controls.Add(this.BX_Textbox);
            this.Controls.Add(this.AX_Textbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AX_Textbox;
        private System.Windows.Forms.TextBox BX_Textbox;
        private System.Windows.Forms.TextBox CX_Textbox;
        private System.Windows.Forms.TextBox DX_Textbox;
        private System.Windows.Forms.Label AX_Lbl;
        private System.Windows.Forms.Label BX_Lbl;
        private System.Windows.Forms.Label CX_Lbl;
        private System.Windows.Forms.Label DX_Lbl;
        private System.Windows.Forms.Label AH_Lbl;
        private System.Windows.Forms.Label BH_Lbl;
        private System.Windows.Forms.Label CH_Lbl;
        private System.Windows.Forms.Label DH_Lbl;
        private System.Windows.Forms.Label AL_Lbl;
        private System.Windows.Forms.Label BL_Lbl;
        private System.Windows.Forms.Label CL_Lbl;
        private System.Windows.Forms.Label DL_Lbl;
        private System.Windows.Forms.TextBox CLI_Textbox;
        private System.Windows.Forms.Button Enter_Button;
        private System.Windows.Forms.TextBox BH_Textbox;
        private System.Windows.Forms.TextBox AH_Textbox;
        private System.Windows.Forms.TextBox DH_Textbox;
        private System.Windows.Forms.TextBox CH_Textbox;
        private System.Windows.Forms.TextBox DL_Textbox;
        private System.Windows.Forms.TextBox CL_Textbox;
        private System.Windows.Forms.TextBox BL_Textbox;
        private System.Windows.Forms.TextBox AL_Textbox;
        private System.Windows.Forms.ListBox CLI_History_ListBox;
        private System.Windows.Forms.Label Command_Desc_Lbl;
        private System.Windows.Forms.TextBox SI_Textbox;
        private System.Windows.Forms.TextBox DI_Textbox;
        private System.Windows.Forms.TextBox BP_Textbox;
        private System.Windows.Forms.TextBox SP_Textbox;
        private System.Windows.Forms.TextBox DISP_Textbox;
        private System.Windows.Forms.Label SI_Lbl;
        private System.Windows.Forms.Label DI_Lbl;
        private System.Windows.Forms.Label BP_Lbl;
        private System.Windows.Forms.Label SP_Lbl;
        private System.Windows.Forms.Label DISP_Lbl;
        private System.Windows.Forms.Label Command_History_Lbl;
        private System.Windows.Forms.RadioButton Indexed_Rbtn;
        private System.Windows.Forms.RadioButton Based_Rbtn;
        private System.Windows.Forms.RadioButton Based_Indexed_Rbtn;
        private System.Windows.Forms.RadioButton None_Rbtn;
        private System.Windows.Forms.RadioButton MemtoReg_Rbtn;
        private System.Windows.Forms.RadioButton RegToMem_Rbtn;
        private System.Windows.Forms.Panel panel1;
    }
}


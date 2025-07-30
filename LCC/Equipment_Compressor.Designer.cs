namespace LCC
{
    partial class Equipment_Compressor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_Compressor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEquipName = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCompressor = new System.Windows.Forms.TabPage();
            this.lblNote = new System.Windows.Forms.Label();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.txtPurchase = new System.Windows.Forms.TextBox();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.gbCompressorType = new System.Windows.Forms.GroupBox();
            this.rdbRecip_Stream = new System.Windows.Forms.RadioButton();
            this.rdbRecip_Motor = new System.Windows.Forms.RadioButton();
            this.rdbRecip_GasTurbine = new System.Windows.Forms.RadioButton();
            this.rdbCent_Rotary = new System.Windows.Forms.RadioButton();
            this.rdbCent_Turbine = new System.Windows.Forms.RadioButton();
            this.rdbCent_Motor = new System.Windows.Forms.RadioButton();
            this.lblUnit2Comp = new System.Windows.Forms.Label();
            this.lblPowerComp = new System.Windows.Forms.Label();
            this.cbbPowerCompUnit = new System.Windows.Forms.ComboBox();
            this.txtPowerComp = new System.Windows.Forms.TextBox();
            this.gbMaterialComp = new System.Windows.Forms.GroupBox();
            this.rdbNickel_Comp = new System.Windows.Forms.RadioButton();
            this.rdbStainless_Comp = new System.Windows.Forms.RadioButton();
            this.rdbCarbon_Comp = new System.Windows.Forms.RadioButton();
            this.lblUnitComp = new System.Windows.Forms.Label();
            this.lblPressureComp = new System.Windows.Forms.Label();
            this.cbbUnitPresssureComp = new System.Windows.Forms.ComboBox();
            this.txtPressureComp = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCompressor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.gbCompressorType.SuspendLayout();
            this.gbMaterialComp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1127, 28);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblEquipName
            // 
            this.lblEquipName.AutoSize = true;
            this.lblEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipName.Location = new System.Drawing.Point(35, 49);
            this.lblEquipName.Name = "lblEquipName";
            this.lblEquipName.Size = new System.Drawing.Size(168, 25);
            this.lblEquipName.TabIndex = 112;
            this.lblEquipName.Text = "Equipment Name:";
            // 
            // txtEquipName
            // 
            this.txtEquipName.BackColor = System.Drawing.Color.LightGreen;
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(218, 48);
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.ReadOnly = true;
            this.txtEquipName.Size = new System.Drawing.Size(326, 28);
            this.txtEquipName.TabIndex = 111;
            this.txtEquipName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCompressor);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(20, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1088, 434);
            this.tabControl1.TabIndex = 113;
            // 
            // tabCompressor
            // 
            this.tabCompressor.Controls.Add(this.lblUnit2Comp);
            this.tabCompressor.Controls.Add(this.lblPowerComp);
            this.tabCompressor.Controls.Add(this.cbbPowerCompUnit);
            this.tabCompressor.Controls.Add(this.txtPowerComp);
            this.tabCompressor.Controls.Add(this.gbMaterialComp);
            this.tabCompressor.Controls.Add(this.lblUnitComp);
            this.tabCompressor.Controls.Add(this.lblPressureComp);
            this.tabCompressor.Controls.Add(this.cbbUnitPresssureComp);
            this.tabCompressor.Controls.Add(this.txtPressureComp);
            this.tabCompressor.Controls.Add(this.gbCompressorType);
            this.tabCompressor.Controls.Add(this.lblNote);
            this.tabCompressor.Controls.Add(this.pbInfo);
            this.tabCompressor.Controls.Add(this.btnDone);
            this.tabCompressor.Controls.Add(this.btnCal);
            this.tabCompressor.Controls.Add(this.txtPurchase);
            this.tabCompressor.Controls.Add(this.lblPurchase);
            this.tabCompressor.Location = new System.Drawing.Point(4, 31);
            this.tabCompressor.Name = "tabCompressor";
            this.tabCompressor.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompressor.Size = new System.Drawing.Size(1080, 399);
            this.tabCompressor.TabIndex = 0;
            this.tabCompressor.Text = "Compressor";
            this.tabCompressor.UseVisualStyleBackColor = true;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Blue;
            this.lblNote.Location = new System.Drawing.Point(680, 248);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(246, 54);
            this.lblNote.TabIndex = 108;
            this.lblNote.Text = "The power range for this calculation \r\n\r\nis 75 kW to 6000 kW.";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbInfo
            // 
            this.pbInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbInfo.Image")));
            this.pbInfo.Location = new System.Drawing.Point(559, 243);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(89, 71);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo.TabIndex = 110;
            this.pbInfo.TabStop = false;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(912, 345);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(146, 39);
            this.btnDone.TabIndex = 106;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCal
            // 
            this.btnCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCal.Location = new System.Drawing.Point(749, 345);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(146, 39);
            this.btnCal.TabIndex = 107;
            this.btnCal.Text = "Calculate";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtPurchase
            // 
            this.txtPurchase.BackColor = System.Drawing.Color.LightBlue;
            this.txtPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchase.Location = new System.Drawing.Point(502, 351);
            this.txtPurchase.Name = "txtPurchase";
            this.txtPurchase.ReadOnly = true;
            this.txtPurchase.Size = new System.Drawing.Size(219, 28);
            this.txtPurchase.TabIndex = 102;
            this.txtPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPurchase
            // 
            this.lblPurchase.AutoSize = true;
            this.lblPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchase.Location = new System.Drawing.Point(320, 352);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(147, 25);
            this.lblPurchase.TabIndex = 103;
            this.lblPurchase.Text = "Purchase Cost:";
            // 
            // gbCompressorType
            // 
            this.gbCompressorType.Controls.Add(this.rdbRecip_Stream);
            this.gbCompressorType.Controls.Add(this.rdbRecip_Motor);
            this.gbCompressorType.Controls.Add(this.rdbRecip_GasTurbine);
            this.gbCompressorType.Controls.Add(this.rdbCent_Rotary);
            this.gbCompressorType.Controls.Add(this.rdbCent_Turbine);
            this.gbCompressorType.Controls.Add(this.rdbCent_Motor);
            this.gbCompressorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCompressorType.Location = new System.Drawing.Point(38, 27);
            this.gbCompressorType.Name = "gbCompressorType";
            this.gbCompressorType.Size = new System.Drawing.Size(330, 308);
            this.gbCompressorType.TabIndex = 111;
            this.gbCompressorType.TabStop = false;
            this.gbCompressorType.Text = "Compressor Type";
            // 
            // rdbRecip_Stream
            // 
            this.rdbRecip_Stream.AutoSize = true;
            this.rdbRecip_Stream.Location = new System.Drawing.Point(25, 261);
            this.rdbRecip_Stream.Name = "rdbRecip_Stream";
            this.rdbRecip_Stream.Size = new System.Drawing.Size(204, 26);
            this.rdbRecip_Stream.TabIndex = 6;
            this.rdbRecip_Stream.TabStop = true;
            this.rdbRecip_Stream.Text = "Reciprocating-Stream";
            this.rdbRecip_Stream.UseVisualStyleBackColor = true;
            this.rdbRecip_Stream.CheckedChanged += new System.EventHandler(this.rdbRecip_Stream_CheckedChanged);
            // 
            // rdbRecip_Motor
            // 
            this.rdbRecip_Motor.AutoSize = true;
            this.rdbRecip_Motor.Location = new System.Drawing.Point(25, 217);
            this.rdbRecip_Motor.Name = "rdbRecip_Motor";
            this.rdbRecip_Motor.Size = new System.Drawing.Size(192, 26);
            this.rdbRecip_Motor.TabIndex = 5;
            this.rdbRecip_Motor.TabStop = true;
            this.rdbRecip_Motor.Text = "Reciprocating-Motor";
            this.rdbRecip_Motor.UseVisualStyleBackColor = true;
            this.rdbRecip_Motor.CheckedChanged += new System.EventHandler(this.rdbRecip_Motor_CheckedChanged);
            // 
            // rdbRecip_GasTurbine
            // 
            this.rdbRecip_GasTurbine.AutoSize = true;
            this.rdbRecip_GasTurbine.Location = new System.Drawing.Point(25, 176);
            this.rdbRecip_GasTurbine.Name = "rdbRecip_GasTurbine";
            this.rdbRecip_GasTurbine.Size = new System.Drawing.Size(247, 26);
            this.rdbRecip_GasTurbine.TabIndex = 4;
            this.rdbRecip_GasTurbine.TabStop = true;
            this.rdbRecip_GasTurbine.Text = "Reciprocating-Gas Turbine";
            this.rdbRecip_GasTurbine.UseVisualStyleBackColor = true;
            this.rdbRecip_GasTurbine.CheckedChanged += new System.EventHandler(this.rdbRecip_GasTurbine_CheckedChanged);
            // 
            // rdbCent_Rotary
            // 
            this.rdbCent_Rotary.AutoSize = true;
            this.rdbCent_Rotary.Location = new System.Drawing.Point(25, 134);
            this.rdbCent_Rotary.Name = "rdbCent_Rotary";
            this.rdbCent_Rotary.Size = new System.Drawing.Size(177, 26);
            this.rdbCent_Rotary.TabIndex = 3;
            this.rdbCent_Rotary.TabStop = true;
            this.rdbCent_Rotary.Text = "Centrifugal-Rotary";
            this.rdbCent_Rotary.UseVisualStyleBackColor = true;
            this.rdbCent_Rotary.CheckedChanged += new System.EventHandler(this.rdbCent_Rotary_CheckedChanged);
            // 
            // rdbCent_Turbine
            // 
            this.rdbCent_Turbine.AutoSize = true;
            this.rdbCent_Turbine.Location = new System.Drawing.Point(25, 91);
            this.rdbCent_Turbine.Name = "rdbCent_Turbine";
            this.rdbCent_Turbine.Size = new System.Drawing.Size(186, 26);
            this.rdbCent_Turbine.TabIndex = 2;
            this.rdbCent_Turbine.TabStop = true;
            this.rdbCent_Turbine.Text = "Centrifugal-Turbine";
            this.rdbCent_Turbine.UseVisualStyleBackColor = true;
            this.rdbCent_Turbine.CheckedChanged += new System.EventHandler(this.rdbCent_Turbine_CheckedChanged);
            // 
            // rdbCent_Motor
            // 
            this.rdbCent_Motor.AutoSize = true;
            this.rdbCent_Motor.Location = new System.Drawing.Point(25, 45);
            this.rdbCent_Motor.Name = "rdbCent_Motor";
            this.rdbCent_Motor.Size = new System.Drawing.Size(169, 26);
            this.rdbCent_Motor.TabIndex = 1;
            this.rdbCent_Motor.TabStop = true;
            this.rdbCent_Motor.Text = "Centrifugal-Motor";
            this.rdbCent_Motor.UseVisualStyleBackColor = true;
            this.rdbCent_Motor.CheckedChanged += new System.EventHandler(this.rdbCent_Motor_CheckedChanged);
            // 
            // lblUnit2Comp
            // 
            this.lblUnit2Comp.AutoSize = true;
            this.lblUnit2Comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit2Comp.Location = new System.Drawing.Point(820, 132);
            this.lblUnit2Comp.Name = "lblUnit2Comp";
            this.lblUnit2Comp.Size = new System.Drawing.Size(52, 25);
            this.lblUnit2Comp.TabIndex = 120;
            this.lblUnit2Comp.Text = "Unit:";
            // 
            // lblPowerComp
            // 
            this.lblPowerComp.AutoSize = true;
            this.lblPowerComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerComp.Location = new System.Drawing.Point(636, 132);
            this.lblPowerComp.Name = "lblPowerComp";
            this.lblPowerComp.Size = new System.Drawing.Size(73, 25);
            this.lblPowerComp.TabIndex = 119;
            this.lblPowerComp.Text = "Power:";
            // 
            // cbbPowerCompUnit
            // 
            this.cbbPowerCompUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPowerCompUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPowerCompUnit.FormattingEnabled = true;
            this.cbbPowerCompUnit.Items.AddRange(new object[] {
            "kW",
            "HP"});
            this.cbbPowerCompUnit.Location = new System.Drawing.Point(825, 178);
            this.cbbPowerCompUnit.Name = "cbbPowerCompUnit";
            this.cbbPowerCompUnit.Size = new System.Drawing.Size(193, 30);
            this.cbbPowerCompUnit.TabIndex = 118;
            this.cbbPowerCompUnit.SelectedIndexChanged += new System.EventHandler(this.cbbPowerCompUnit_SelectedIndexChanged);
            // 
            // txtPowerComp
            // 
            this.txtPowerComp.BackColor = System.Drawing.Color.LightBlue;
            this.txtPowerComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPowerComp.Location = new System.Drawing.Point(644, 180);
            this.txtPowerComp.Name = "txtPowerComp";
            this.txtPowerComp.Size = new System.Drawing.Size(152, 28);
            this.txtPowerComp.TabIndex = 117;
            this.txtPowerComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPowerComp.TextChanged += new System.EventHandler(this.txtPowerComp_TextChanged);
            // 
            // gbMaterialComp
            // 
            this.gbMaterialComp.Controls.Add(this.rdbNickel_Comp);
            this.gbMaterialComp.Controls.Add(this.rdbStainless_Comp);
            this.gbMaterialComp.Controls.Add(this.rdbCarbon_Comp);
            this.gbMaterialComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialComp.Location = new System.Drawing.Point(407, 29);
            this.gbMaterialComp.Name = "gbMaterialComp";
            this.gbMaterialComp.Size = new System.Drawing.Size(188, 179);
            this.gbMaterialComp.TabIndex = 116;
            this.gbMaterialComp.TabStop = false;
            this.gbMaterialComp.Text = "Material";
            // 
            // rdbNickel_Comp
            // 
            this.rdbNickel_Comp.AutoSize = true;
            this.rdbNickel_Comp.Location = new System.Drawing.Point(22, 131);
            this.rdbNickel_Comp.Name = "rdbNickel_Comp";
            this.rdbNickel_Comp.Size = new System.Drawing.Size(124, 26);
            this.rdbNickel_Comp.TabIndex = 4;
            this.rdbNickel_Comp.TabStop = true;
            this.rdbNickel_Comp.Text = "Nickel Alloy";
            this.rdbNickel_Comp.UseVisualStyleBackColor = true;
            this.rdbNickel_Comp.CheckedChanged += new System.EventHandler(this.rdbNickel_Comp_CheckedChanged);
            // 
            // rdbStainless_Comp
            // 
            this.rdbStainless_Comp.AutoSize = true;
            this.rdbStainless_Comp.Location = new System.Drawing.Point(22, 88);
            this.rdbStainless_Comp.Name = "rdbStainless_Comp";
            this.rdbStainless_Comp.Size = new System.Drawing.Size(150, 26);
            this.rdbStainless_Comp.TabIndex = 3;
            this.rdbStainless_Comp.TabStop = true;
            this.rdbStainless_Comp.Text = "Stainless Steel";
            this.rdbStainless_Comp.UseVisualStyleBackColor = true;
            this.rdbStainless_Comp.CheckedChanged += new System.EventHandler(this.rdbStainless_Comp_CheckedChanged);
            // 
            // rdbCarbon_Comp
            // 
            this.rdbCarbon_Comp.AutoSize = true;
            this.rdbCarbon_Comp.Location = new System.Drawing.Point(22, 45);
            this.rdbCarbon_Comp.Name = "rdbCarbon_Comp";
            this.rdbCarbon_Comp.Size = new System.Drawing.Size(136, 26);
            this.rdbCarbon_Comp.TabIndex = 2;
            this.rdbCarbon_Comp.TabStop = true;
            this.rdbCarbon_Comp.Text = "Carbon Steel";
            this.rdbCarbon_Comp.UseVisualStyleBackColor = true;
            this.rdbCarbon_Comp.CheckedChanged += new System.EventHandler(this.rdbCarbon_Comp_CheckedChanged);
            // 
            // lblUnitComp
            // 
            this.lblUnitComp.AutoSize = true;
            this.lblUnitComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitComp.Location = new System.Drawing.Point(820, 36);
            this.lblUnitComp.Name = "lblUnitComp";
            this.lblUnitComp.Size = new System.Drawing.Size(52, 25);
            this.lblUnitComp.TabIndex = 115;
            this.lblUnitComp.Text = "Unit:";
            // 
            // lblPressureComp
            // 
            this.lblPressureComp.AutoSize = true;
            this.lblPressureComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressureComp.Location = new System.Drawing.Point(636, 36);
            this.lblPressureComp.Name = "lblPressureComp";
            this.lblPressureComp.Size = new System.Drawing.Size(96, 25);
            this.lblPressureComp.TabIndex = 114;
            this.lblPressureComp.Text = "Pressure:";
            // 
            // cbbUnitPresssureComp
            // 
            this.cbbUnitPresssureComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnitPresssureComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnitPresssureComp.FormattingEnabled = true;
            this.cbbUnitPresssureComp.Items.AddRange(new object[] {
            "kPa",
            "psi",
            "bar"});
            this.cbbUnitPresssureComp.Location = new System.Drawing.Point(825, 82);
            this.cbbUnitPresssureComp.Name = "cbbUnitPresssureComp";
            this.cbbUnitPresssureComp.Size = new System.Drawing.Size(193, 30);
            this.cbbUnitPresssureComp.TabIndex = 113;
            this.cbbUnitPresssureComp.SelectedIndexChanged += new System.EventHandler(this.cbbUnitPresssureComp_SelectedIndexChanged);
            // 
            // txtPressureComp
            // 
            this.txtPressureComp.BackColor = System.Drawing.Color.LightBlue;
            this.txtPressureComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressureComp.Location = new System.Drawing.Point(644, 84);
            this.txtPressureComp.Name = "txtPressureComp";
            this.txtPressureComp.Size = new System.Drawing.Size(152, 28);
            this.txtPressureComp.TabIndex = 112;
            this.txtPressureComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPressureComp.TextChanged += new System.EventHandler(this.txtPressureComp_TextChanged);
            // 
            // Equipment_Compressor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 543);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblEquipName);
            this.Controls.Add(this.txtEquipName);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Equipment_Compressor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compressor Page";
            this.Load += new System.EventHandler(this.Equipment_Compressor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabCompressor.ResumeLayout(false);
            this.tabCompressor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.gbCompressorType.ResumeLayout(false);
            this.gbCompressorType.PerformLayout();
            this.gbMaterialComp.ResumeLayout(false);
            this.gbMaterialComp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblEquipName;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCompressor;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.TextBox txtPurchase;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.GroupBox gbCompressorType;
        private System.Windows.Forms.RadioButton rdbRecip_Stream;
        private System.Windows.Forms.RadioButton rdbRecip_Motor;
        private System.Windows.Forms.RadioButton rdbRecip_GasTurbine;
        private System.Windows.Forms.RadioButton rdbCent_Rotary;
        private System.Windows.Forms.RadioButton rdbCent_Turbine;
        private System.Windows.Forms.RadioButton rdbCent_Motor;
        private System.Windows.Forms.Label lblUnit2Comp;
        private System.Windows.Forms.Label lblPowerComp;
        private System.Windows.Forms.ComboBox cbbPowerCompUnit;
        private System.Windows.Forms.TextBox txtPowerComp;
        private System.Windows.Forms.GroupBox gbMaterialComp;
        private System.Windows.Forms.RadioButton rdbNickel_Comp;
        private System.Windows.Forms.RadioButton rdbStainless_Comp;
        private System.Windows.Forms.RadioButton rdbCarbon_Comp;
        private System.Windows.Forms.Label lblUnitComp;
        private System.Windows.Forms.Label lblPressureComp;
        private System.Windows.Forms.ComboBox cbbUnitPresssureComp;
        private System.Windows.Forms.TextBox txtPressureComp;
    }
}
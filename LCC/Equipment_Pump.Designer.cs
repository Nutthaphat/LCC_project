namespace LCC
{
    partial class Equipment_Pump
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_Pump));
            this.lblNotePump = new System.Windows.Forms.Label();
            this.btnCalPump = new System.Windows.Forms.Button();
            this.btnDonePump = new System.Windows.Forms.Button();
            this.lblEquipNamePump = new System.Windows.Forms.Label();
            this.txtEquipNamePump = new System.Windows.Forms.TextBox();
            this.lblPurchasePump = new System.Windows.Forms.Label();
            this.txtPurchasePump = new System.Windows.Forms.TextBox();
            this.lblUnitPump = new System.Windows.Forms.Label();
            this.lblPumpCap = new System.Windows.Forms.Label();
            this.cbbUnitPump = new System.Windows.Forms.ComboBox();
            this.txtPumpCap = new System.Windows.Forms.TextBox();
            this.gbPressureP = new System.Windows.Forms.GroupBox();
            this.rdb30000 = new System.Windows.Forms.RadioButton();
            this.rdb20000 = new System.Windows.Forms.RadioButton();
            this.rdb10000 = new System.Windows.Forms.RadioButton();
            this.rdb5000 = new System.Windows.Forms.RadioButton();
            this.rdb1035 = new System.Windows.Forms.RadioButton();
            this.gbMaterialP = new System.Windows.Forms.GroupBox();
            this.rdbNickelAlloyPump = new System.Windows.Forms.RadioButton();
            this.rdbStainlessSteelPump = new System.Windows.Forms.RadioButton();
            this.rdbCastSteelPump = new System.Windows.Forms.RadioButton();
            this.rdbCastIronPump = new System.Windows.Forms.RadioButton();
            this.gbTypePump = new System.Windows.Forms.GroupBox();
            this.rdbDiaphragmP = new System.Windows.Forms.RadioButton();
            this.rdbGearP = new System.Windows.Forms.RadioButton();
            this.rdbRotaryP = new System.Windows.Forms.RadioButton();
            this.rdbReciprocatingP = new System.Windows.Forms.RadioButton();
            this.rdbCentifugalP = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPump = new System.Windows.Forms.TabPage();
            this.pbInfoP = new System.Windows.Forms.PictureBox();
            this.tabPumpDrive = new System.Windows.Forms.TabPage();
            this.pbInfoPD = new System.Windows.Forms.PictureBox();
            this.btnCalPD = new System.Windows.Forms.Button();
            this.btnDonePD = new System.Windows.Forms.Button();
            this.lblPurchasePumpDrive = new System.Windows.Forms.Label();
            this.txtPurchasePumpDrive = new System.Windows.Forms.TextBox();
            this.lblNotePD = new System.Windows.Forms.Label();
            this.lblUnit2PumpDrive = new System.Windows.Forms.Label();
            this.lblUtilityPumpDrive = new System.Windows.Forms.Label();
            this.cbbUnit2PumpDrive = new System.Windows.Forms.ComboBox();
            this.txtUtilityPumpDrive = new System.Windows.Forms.TextBox();
            this.lblUnitPumpDrive = new System.Windows.Forms.Label();
            this.lblsizePumpDrive = new System.Windows.Forms.Label();
            this.cbbUnitPumpDrive = new System.Windows.Forms.ComboBox();
            this.txtsizePumpDrive = new System.Windows.Forms.TextBox();
            this.lblNote2 = new System.Windows.Forms.Label();
            this.gbPressureP.SuspendLayout();
            this.gbMaterialP.SuspendLayout();
            this.gbTypePump.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPump.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoP)).BeginInit();
            this.tabPumpDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoPD)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotePump
            // 
            this.lblNotePump.AutoSize = true;
            this.lblNotePump.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNotePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotePump.ForeColor = System.Drawing.Color.Blue;
            this.lblNotePump.Location = new System.Drawing.Point(768, 188);
            this.lblNotePump.Name = "lblNotePump";
            this.lblNotePump.Size = new System.Drawing.Size(265, 54);
            this.lblNotePump.TabIndex = 108;
            this.lblNotePump.Text = "*The capacity range for this calculation \r\n\r\nis  0.00015 m3/s to 1 m3/s.";
            this.lblNotePump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCalPump
            // 
            this.btnCalPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalPump.Location = new System.Drawing.Point(749, 314);
            this.btnCalPump.Name = "btnCalPump";
            this.btnCalPump.Size = new System.Drawing.Size(146, 39);
            this.btnCalPump.TabIndex = 107;
            this.btnCalPump.Text = "Calculate";
            this.btnCalPump.UseVisualStyleBackColor = true;
            this.btnCalPump.Click += new System.EventHandler(this.btnCalPump_Click);
            // 
            // btnDonePump
            // 
            this.btnDonePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonePump.Location = new System.Drawing.Point(912, 314);
            this.btnDonePump.Name = "btnDonePump";
            this.btnDonePump.Size = new System.Drawing.Size(146, 39);
            this.btnDonePump.TabIndex = 106;
            this.btnDonePump.Text = "Done";
            this.btnDonePump.UseVisualStyleBackColor = true;
            this.btnDonePump.Click += new System.EventHandler(this.btnDonePump_Click);
            // 
            // lblEquipNamePump
            // 
            this.lblEquipNamePump.AutoSize = true;
            this.lblEquipNamePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipNamePump.Location = new System.Drawing.Point(35, 49);
            this.lblEquipNamePump.Name = "lblEquipNamePump";
            this.lblEquipNamePump.Size = new System.Drawing.Size(168, 25);
            this.lblEquipNamePump.TabIndex = 105;
            this.lblEquipNamePump.Text = "Equipment Name:";
            // 
            // txtEquipNamePump
            // 
            this.txtEquipNamePump.BackColor = System.Drawing.Color.LightGreen;
            this.txtEquipNamePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipNamePump.Location = new System.Drawing.Point(218, 48);
            this.txtEquipNamePump.Name = "txtEquipNamePump";
            this.txtEquipNamePump.ReadOnly = true;
            this.txtEquipNamePump.Size = new System.Drawing.Size(326, 28);
            this.txtEquipNamePump.TabIndex = 104;
            this.txtEquipNamePump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPurchasePump
            // 
            this.lblPurchasePump.AutoSize = true;
            this.lblPurchasePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchasePump.Location = new System.Drawing.Point(320, 321);
            this.lblPurchasePump.Name = "lblPurchasePump";
            this.lblPurchasePump.Size = new System.Drawing.Size(147, 25);
            this.lblPurchasePump.TabIndex = 103;
            this.lblPurchasePump.Text = "Purchase Cost:";
            // 
            // txtPurchasePump
            // 
            this.txtPurchasePump.BackColor = System.Drawing.Color.LightBlue;
            this.txtPurchasePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePump.Location = new System.Drawing.Point(502, 320);
            this.txtPurchasePump.Name = "txtPurchasePump";
            this.txtPurchasePump.ReadOnly = true;
            this.txtPurchasePump.Size = new System.Drawing.Size(219, 28);
            this.txtPurchasePump.TabIndex = 102;
            this.txtPurchasePump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUnitPump
            // 
            this.lblUnitPump.AutoSize = true;
            this.lblUnitPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPump.Location = new System.Drawing.Point(846, 72);
            this.lblUnitPump.Name = "lblUnitPump";
            this.lblUnitPump.Size = new System.Drawing.Size(52, 25);
            this.lblUnitPump.TabIndex = 101;
            this.lblUnitPump.Text = "Unit:";
            // 
            // lblPumpCap
            // 
            this.lblPumpCap.AutoSize = true;
            this.lblPumpCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPumpCap.Location = new System.Drawing.Point(651, 72);
            this.lblPumpCap.Name = "lblPumpCap";
            this.lblPumpCap.Size = new System.Drawing.Size(151, 25);
            this.lblPumpCap.TabIndex = 100;
            this.lblPumpCap.Text = "Pump Capacity:";
            // 
            // cbbUnitPump
            // 
            this.cbbUnitPump.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnitPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnitPump.FormattingEnabled = true;
            this.cbbUnitPump.Items.AddRange(new object[] {
            "cubic meter (m3)/s",
            "cubic meter (m3)/hr",
            "gallon/s",
            "cubic feet (feet3)/s"});
            this.cbbUnitPump.Location = new System.Drawing.Point(840, 118);
            this.cbbUnitPump.Name = "cbbUnitPump";
            this.cbbUnitPump.Size = new System.Drawing.Size(200, 30);
            this.cbbUnitPump.TabIndex = 99;
            this.cbbUnitPump.SelectedIndexChanged += new System.EventHandler(this.cbbUnitPump_SelectedIndexChanged);
            // 
            // txtPumpCap
            // 
            this.txtPumpCap.BackColor = System.Drawing.Color.LightBlue;
            this.txtPumpCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPumpCap.Location = new System.Drawing.Point(656, 120);
            this.txtPumpCap.Name = "txtPumpCap";
            this.txtPumpCap.Size = new System.Drawing.Size(152, 28);
            this.txtPumpCap.TabIndex = 98;
            this.txtPumpCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPumpCap.TextChanged += new System.EventHandler(this.txtPumpCap_TextChanged);
            // 
            // gbPressureP
            // 
            this.gbPressureP.Controls.Add(this.rdb30000);
            this.gbPressureP.Controls.Add(this.rdb20000);
            this.gbPressureP.Controls.Add(this.rdb10000);
            this.gbPressureP.Controls.Add(this.rdb5000);
            this.gbPressureP.Controls.Add(this.rdb1035);
            this.gbPressureP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPressureP.Location = new System.Drawing.Point(435, 29);
            this.gbPressureP.Name = "gbPressureP";
            this.gbPressureP.Size = new System.Drawing.Size(188, 264);
            this.gbPressureP.TabIndex = 97;
            this.gbPressureP.TabStop = false;
            this.gbPressureP.Text = "Pressure";
            // 
            // rdb30000
            // 
            this.rdb30000.AutoSize = true;
            this.rdb30000.Location = new System.Drawing.Point(25, 217);
            this.rdb30000.Name = "rdb30000";
            this.rdb30000.Size = new System.Drawing.Size(117, 26);
            this.rdb30000.TabIndex = 5;
            this.rdb30000.TabStop = true;
            this.rdb30000.Text = "30000 kPa";
            this.rdb30000.UseVisualStyleBackColor = true;
            this.rdb30000.CheckedChanged += new System.EventHandler(this.rdb30000_CheckedChanged);
            // 
            // rdb20000
            // 
            this.rdb20000.AutoSize = true;
            this.rdb20000.Location = new System.Drawing.Point(25, 177);
            this.rdb20000.Name = "rdb20000";
            this.rdb20000.Size = new System.Drawing.Size(117, 26);
            this.rdb20000.TabIndex = 4;
            this.rdb20000.TabStop = true;
            this.rdb20000.Text = "20000 kPa";
            this.rdb20000.UseVisualStyleBackColor = true;
            this.rdb20000.CheckedChanged += new System.EventHandler(this.rdb20000_CheckedChanged);
            // 
            // rdb10000
            // 
            this.rdb10000.AutoSize = true;
            this.rdb10000.Location = new System.Drawing.Point(25, 134);
            this.rdb10000.Name = "rdb10000";
            this.rdb10000.Size = new System.Drawing.Size(117, 26);
            this.rdb10000.TabIndex = 3;
            this.rdb10000.TabStop = true;
            this.rdb10000.Text = "10000 kPa";
            this.rdb10000.UseVisualStyleBackColor = true;
            this.rdb10000.CheckedChanged += new System.EventHandler(this.rdb10000_CheckedChanged);
            // 
            // rdb5000
            // 
            this.rdb5000.AutoSize = true;
            this.rdb5000.Location = new System.Drawing.Point(25, 91);
            this.rdb5000.Name = "rdb5000";
            this.rdb5000.Size = new System.Drawing.Size(107, 26);
            this.rdb5000.TabIndex = 2;
            this.rdb5000.TabStop = true;
            this.rdb5000.Text = "5000 kPa";
            this.rdb5000.UseVisualStyleBackColor = true;
            this.rdb5000.CheckedChanged += new System.EventHandler(this.rdb5000_CheckedChanged);
            // 
            // rdb1035
            // 
            this.rdb1035.AutoSize = true;
            this.rdb1035.Location = new System.Drawing.Point(25, 45);
            this.rdb1035.Name = "rdb1035";
            this.rdb1035.Size = new System.Drawing.Size(107, 26);
            this.rdb1035.TabIndex = 1;
            this.rdb1035.TabStop = true;
            this.rdb1035.Text = "1035 kPa";
            this.rdb1035.UseVisualStyleBackColor = true;
            this.rdb1035.CheckedChanged += new System.EventHandler(this.rdb1035_CheckedChanged);
            // 
            // gbMaterialP
            // 
            this.gbMaterialP.Controls.Add(this.rdbNickelAlloyPump);
            this.gbMaterialP.Controls.Add(this.rdbStainlessSteelPump);
            this.gbMaterialP.Controls.Add(this.rdbCastSteelPump);
            this.gbMaterialP.Controls.Add(this.rdbCastIronPump);
            this.gbMaterialP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialP.Location = new System.Drawing.Point(222, 29);
            this.gbMaterialP.Name = "gbMaterialP";
            this.gbMaterialP.Size = new System.Drawing.Size(188, 264);
            this.gbMaterialP.TabIndex = 96;
            this.gbMaterialP.TabStop = false;
            this.gbMaterialP.Text = "Material";
            // 
            // rdbNickelAlloyPump
            // 
            this.rdbNickelAlloyPump.AutoSize = true;
            this.rdbNickelAlloyPump.Location = new System.Drawing.Point(25, 177);
            this.rdbNickelAlloyPump.Name = "rdbNickelAlloyPump";
            this.rdbNickelAlloyPump.Size = new System.Drawing.Size(124, 26);
            this.rdbNickelAlloyPump.TabIndex = 4;
            this.rdbNickelAlloyPump.TabStop = true;
            this.rdbNickelAlloyPump.Text = "Nickel Alloy";
            this.rdbNickelAlloyPump.UseVisualStyleBackColor = true;
            this.rdbNickelAlloyPump.CheckedChanged += new System.EventHandler(this.rdbNickelAlloyPump_CheckedChanged);
            // 
            // rdbStainlessSteelPump
            // 
            this.rdbStainlessSteelPump.AutoSize = true;
            this.rdbStainlessSteelPump.Location = new System.Drawing.Point(25, 134);
            this.rdbStainlessSteelPump.Name = "rdbStainlessSteelPump";
            this.rdbStainlessSteelPump.Size = new System.Drawing.Size(150, 26);
            this.rdbStainlessSteelPump.TabIndex = 3;
            this.rdbStainlessSteelPump.TabStop = true;
            this.rdbStainlessSteelPump.Text = "Stainless Steel";
            this.rdbStainlessSteelPump.UseVisualStyleBackColor = true;
            this.rdbStainlessSteelPump.CheckedChanged += new System.EventHandler(this.rdbStainlessSteelPump_CheckedChanged);
            // 
            // rdbCastSteelPump
            // 
            this.rdbCastSteelPump.AutoSize = true;
            this.rdbCastSteelPump.Location = new System.Drawing.Point(25, 91);
            this.rdbCastSteelPump.Name = "rdbCastSteelPump";
            this.rdbCastSteelPump.Size = new System.Drawing.Size(114, 26);
            this.rdbCastSteelPump.TabIndex = 2;
            this.rdbCastSteelPump.TabStop = true;
            this.rdbCastSteelPump.Text = "Cast Steel";
            this.rdbCastSteelPump.UseVisualStyleBackColor = true;
            this.rdbCastSteelPump.CheckedChanged += new System.EventHandler(this.rdbCastSteelPump_CheckedChanged);
            // 
            // rdbCastIronPump
            // 
            this.rdbCastIronPump.AutoSize = true;
            this.rdbCastIronPump.Location = new System.Drawing.Point(25, 45);
            this.rdbCastIronPump.Name = "rdbCastIronPump";
            this.rdbCastIronPump.Size = new System.Drawing.Size(103, 26);
            this.rdbCastIronPump.TabIndex = 1;
            this.rdbCastIronPump.TabStop = true;
            this.rdbCastIronPump.Text = "Cast Iron";
            this.rdbCastIronPump.UseVisualStyleBackColor = true;
            this.rdbCastIronPump.CheckedChanged += new System.EventHandler(this.rdbCastIronPump_CheckedChanged);
            // 
            // gbTypePump
            // 
            this.gbTypePump.Controls.Add(this.rdbDiaphragmP);
            this.gbTypePump.Controls.Add(this.rdbGearP);
            this.gbTypePump.Controls.Add(this.rdbRotaryP);
            this.gbTypePump.Controls.Add(this.rdbReciprocatingP);
            this.gbTypePump.Controls.Add(this.rdbCentifugalP);
            this.gbTypePump.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTypePump.Location = new System.Drawing.Point(17, 29);
            this.gbTypePump.Name = "gbTypePump";
            this.gbTypePump.Size = new System.Drawing.Size(188, 264);
            this.gbTypePump.TabIndex = 95;
            this.gbTypePump.TabStop = false;
            this.gbTypePump.Text = "Pump Type";
            this.gbTypePump.Enter += new System.EventHandler(this.gbTypePump_Enter);
            // 
            // rdbDiaphragmP
            // 
            this.rdbDiaphragmP.AutoSize = true;
            this.rdbDiaphragmP.Enabled = false;
            this.rdbDiaphragmP.Location = new System.Drawing.Point(25, 217);
            this.rdbDiaphragmP.Name = "rdbDiaphragmP";
            this.rdbDiaphragmP.Size = new System.Drawing.Size(118, 26);
            this.rdbDiaphragmP.TabIndex = 5;
            this.rdbDiaphragmP.TabStop = true;
            this.rdbDiaphragmP.Text = "Diaphragm";
            this.rdbDiaphragmP.UseVisualStyleBackColor = true;
            this.rdbDiaphragmP.CheckedChanged += new System.EventHandler(this.rdbDiaphragmP_CheckedChanged);
            // 
            // rdbGearP
            // 
            this.rdbGearP.AutoSize = true;
            this.rdbGearP.Enabled = false;
            this.rdbGearP.Location = new System.Drawing.Point(25, 177);
            this.rdbGearP.Name = "rdbGearP";
            this.rdbGearP.Size = new System.Drawing.Size(71, 26);
            this.rdbGearP.TabIndex = 4;
            this.rdbGearP.TabStop = true;
            this.rdbGearP.Text = "Gear";
            this.rdbGearP.UseVisualStyleBackColor = true;
            this.rdbGearP.CheckedChanged += new System.EventHandler(this.rdbGearP_CheckedChanged);
            // 
            // rdbRotaryP
            // 
            this.rdbRotaryP.AutoSize = true;
            this.rdbRotaryP.Enabled = false;
            this.rdbRotaryP.Location = new System.Drawing.Point(25, 134);
            this.rdbRotaryP.Name = "rdbRotaryP";
            this.rdbRotaryP.Size = new System.Drawing.Size(84, 26);
            this.rdbRotaryP.TabIndex = 3;
            this.rdbRotaryP.TabStop = true;
            this.rdbRotaryP.Text = "Rotary";
            this.rdbRotaryP.UseVisualStyleBackColor = true;
            this.rdbRotaryP.CheckedChanged += new System.EventHandler(this.rdbRotaryP_CheckedChanged);
            // 
            // rdbReciprocatingP
            // 
            this.rdbReciprocatingP.AutoSize = true;
            this.rdbReciprocatingP.Enabled = false;
            this.rdbReciprocatingP.Location = new System.Drawing.Point(25, 91);
            this.rdbReciprocatingP.Name = "rdbReciprocatingP";
            this.rdbReciprocatingP.Size = new System.Drawing.Size(141, 26);
            this.rdbReciprocatingP.TabIndex = 2;
            this.rdbReciprocatingP.TabStop = true;
            this.rdbReciprocatingP.Text = "Reciprocating";
            this.rdbReciprocatingP.UseVisualStyleBackColor = true;
            this.rdbReciprocatingP.CheckedChanged += new System.EventHandler(this.rdbReciprocatingP_CheckedChanged);
            // 
            // rdbCentifugalP
            // 
            this.rdbCentifugalP.AutoSize = true;
            this.rdbCentifugalP.Location = new System.Drawing.Point(25, 45);
            this.rdbCentifugalP.Name = "rdbCentifugalP";
            this.rdbCentifugalP.Size = new System.Drawing.Size(118, 26);
            this.rdbCentifugalP.TabIndex = 1;
            this.rdbCentifugalP.TabStop = true;
            this.rdbCentifugalP.Text = "Centrifugal";
            this.rdbCentifugalP.UseVisualStyleBackColor = true;
            this.rdbCentifugalP.CheckedChanged += new System.EventHandler(this.rdbCentifugalP_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1127, 28);
            this.menuStrip1.TabIndex = 109;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPump);
            this.tabControl1.Controls.Add(this.tabPumpDrive);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(20, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1088, 407);
            this.tabControl1.TabIndex = 110;
            // 
            // tabPump
            // 
            this.tabPump.Controls.Add(this.lblNotePump);
            this.tabPump.Controls.Add(this.pbInfoP);
            this.tabPump.Controls.Add(this.txtPumpCap);
            this.tabPump.Controls.Add(this.cbbUnitPump);
            this.tabPump.Controls.Add(this.btnDonePump);
            this.tabPump.Controls.Add(this.btnCalPump);
            this.tabPump.Controls.Add(this.lblPumpCap);
            this.tabPump.Controls.Add(this.gbPressureP);
            this.tabPump.Controls.Add(this.lblUnitPump);
            this.tabPump.Controls.Add(this.txtPurchasePump);
            this.tabPump.Controls.Add(this.lblPurchasePump);
            this.tabPump.Controls.Add(this.gbTypePump);
            this.tabPump.Controls.Add(this.gbMaterialP);
            this.tabPump.Location = new System.Drawing.Point(4, 31);
            this.tabPump.Name = "tabPump";
            this.tabPump.Padding = new System.Windows.Forms.Padding(3);
            this.tabPump.Size = new System.Drawing.Size(1080, 372);
            this.tabPump.TabIndex = 0;
            this.tabPump.Text = "Pump";
            this.tabPump.UseVisualStyleBackColor = true;
            // 
            // pbInfoP
            // 
            this.pbInfoP.Image = ((System.Drawing.Image)(resources.GetObject("pbInfoP.Image")));
            this.pbInfoP.Location = new System.Drawing.Point(656, 178);
            this.pbInfoP.Name = "pbInfoP";
            this.pbInfoP.Size = new System.Drawing.Size(89, 71);
            this.pbInfoP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfoP.TabIndex = 110;
            this.pbInfoP.TabStop = false;
            // 
            // tabPumpDrive
            // 
            this.tabPumpDrive.Controls.Add(this.pbInfoPD);
            this.tabPumpDrive.Controls.Add(this.btnCalPD);
            this.tabPumpDrive.Controls.Add(this.btnDonePD);
            this.tabPumpDrive.Controls.Add(this.lblPurchasePumpDrive);
            this.tabPumpDrive.Controls.Add(this.txtPurchasePumpDrive);
            this.tabPumpDrive.Controls.Add(this.lblNotePD);
            this.tabPumpDrive.Controls.Add(this.lblUnit2PumpDrive);
            this.tabPumpDrive.Controls.Add(this.lblUtilityPumpDrive);
            this.tabPumpDrive.Controls.Add(this.cbbUnit2PumpDrive);
            this.tabPumpDrive.Controls.Add(this.txtUtilityPumpDrive);
            this.tabPumpDrive.Controls.Add(this.lblUnitPumpDrive);
            this.tabPumpDrive.Controls.Add(this.lblsizePumpDrive);
            this.tabPumpDrive.Controls.Add(this.cbbUnitPumpDrive);
            this.tabPumpDrive.Controls.Add(this.txtsizePumpDrive);
            this.tabPumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPumpDrive.Location = new System.Drawing.Point(4, 31);
            this.tabPumpDrive.Name = "tabPumpDrive";
            this.tabPumpDrive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPumpDrive.Size = new System.Drawing.Size(1080, 372);
            this.tabPumpDrive.TabIndex = 1;
            this.tabPumpDrive.Text = "Pump include drive";
            this.tabPumpDrive.UseVisualStyleBackColor = true;
            // 
            // pbInfoPD
            // 
            this.pbInfoPD.Image = ((System.Drawing.Image)(resources.GetObject("pbInfoPD.Image")));
            this.pbInfoPD.Location = new System.Drawing.Point(591, 131);
            this.pbInfoPD.Name = "pbInfoPD";
            this.pbInfoPD.Size = new System.Drawing.Size(89, 71);
            this.pbInfoPD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfoPD.TabIndex = 109;
            this.pbInfoPD.TabStop = false;
            // 
            // btnCalPD
            // 
            this.btnCalPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalPD.Location = new System.Drawing.Point(749, 314);
            this.btnCalPD.Name = "btnCalPD";
            this.btnCalPD.Size = new System.Drawing.Size(146, 39);
            this.btnCalPD.TabIndex = 108;
            this.btnCalPD.Text = "Calculate";
            this.btnCalPD.UseVisualStyleBackColor = true;
            this.btnCalPD.Click += new System.EventHandler(this.btnCalPD_Click);
            // 
            // btnDonePD
            // 
            this.btnDonePD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonePD.Location = new System.Drawing.Point(912, 314);
            this.btnDonePD.Name = "btnDonePD";
            this.btnDonePD.Size = new System.Drawing.Size(146, 39);
            this.btnDonePD.TabIndex = 107;
            this.btnDonePD.Text = "Done";
            this.btnDonePD.UseVisualStyleBackColor = true;
            this.btnDonePD.Click += new System.EventHandler(this.btnDonePD_Click);
            // 
            // lblPurchasePumpDrive
            // 
            this.lblPurchasePumpDrive.AutoSize = true;
            this.lblPurchasePumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchasePumpDrive.Location = new System.Drawing.Point(320, 321);
            this.lblPurchasePumpDrive.Name = "lblPurchasePumpDrive";
            this.lblPurchasePumpDrive.Size = new System.Drawing.Size(147, 25);
            this.lblPurchasePumpDrive.TabIndex = 106;
            this.lblPurchasePumpDrive.Text = "Purchase Cost:";
            // 
            // txtPurchasePumpDrive
            // 
            this.txtPurchasePumpDrive.BackColor = System.Drawing.Color.LightBlue;
            this.txtPurchasePumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePumpDrive.Location = new System.Drawing.Point(502, 320);
            this.txtPurchasePumpDrive.Name = "txtPurchasePumpDrive";
            this.txtPurchasePumpDrive.ReadOnly = true;
            this.txtPurchasePumpDrive.Size = new System.Drawing.Size(219, 28);
            this.txtPurchasePumpDrive.TabIndex = 105;
            this.txtPurchasePumpDrive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNotePD
            // 
            this.lblNotePD.AutoSize = true;
            this.lblNotePD.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNotePD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotePD.ForeColor = System.Drawing.Color.Blue;
            this.lblNotePD.Location = new System.Drawing.Point(700, 139);
            this.lblNotePD.Name = "lblNotePD";
            this.lblNotePD.Size = new System.Drawing.Size(296, 54);
            this.lblNotePD.TabIndex = 104;
            this.lblNotePD.Text = "*The size of pump range for this calculation \r\n\r\nis  6 m3/s*kPa to 70 m3/s*kPa.";
            this.lblNotePD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnit2PumpDrive
            // 
            this.lblUnit2PumpDrive.AutoSize = true;
            this.lblUnit2PumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit2PumpDrive.Location = new System.Drawing.Point(299, 177);
            this.lblUnit2PumpDrive.Name = "lblUnit2PumpDrive";
            this.lblUnit2PumpDrive.Size = new System.Drawing.Size(52, 25);
            this.lblUnit2PumpDrive.TabIndex = 103;
            this.lblUnit2PumpDrive.Text = "Unit:";
            // 
            // lblUtilityPumpDrive
            // 
            this.lblUtilityPumpDrive.AutoSize = true;
            this.lblUtilityPumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilityPumpDrive.Location = new System.Drawing.Point(75, 177);
            this.lblUtilityPumpDrive.Name = "lblUtilityPumpDrive";
            this.lblUtilityPumpDrive.Size = new System.Drawing.Size(204, 25);
            this.lblUtilityPumpDrive.TabIndex = 102;
            this.lblUtilityPumpDrive.Text = "Utility (power of drive):";
            // 
            // cbbUnit2PumpDrive
            // 
            this.cbbUnit2PumpDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnit2PumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnit2PumpDrive.FormattingEnabled = true;
            this.cbbUnit2PumpDrive.Items.AddRange(new object[] {
            "kW",
            "HP"});
            this.cbbUnit2PumpDrive.Location = new System.Drawing.Point(293, 223);
            this.cbbUnit2PumpDrive.Name = "cbbUnit2PumpDrive";
            this.cbbUnit2PumpDrive.Size = new System.Drawing.Size(200, 30);
            this.cbbUnit2PumpDrive.TabIndex = 101;
            this.cbbUnit2PumpDrive.SelectedIndexChanged += new System.EventHandler(this.cbbUnit2PumpDrive_SelectedIndexChanged);
            // 
            // txtUtilityPumpDrive
            // 
            this.txtUtilityPumpDrive.BackColor = System.Drawing.Color.LightBlue;
            this.txtUtilityPumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilityPumpDrive.Location = new System.Drawing.Point(74, 225);
            this.txtUtilityPumpDrive.Name = "txtUtilityPumpDrive";
            this.txtUtilityPumpDrive.Size = new System.Drawing.Size(152, 28);
            this.txtUtilityPumpDrive.TabIndex = 100;
            this.txtUtilityPumpDrive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUtilityPumpDrive.TextChanged += new System.EventHandler(this.txtUtilityPumpDrive_TextChanged);
            // 
            // lblUnitPumpDrive
            // 
            this.lblUnitPumpDrive.AutoSize = true;
            this.lblUnitPumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPumpDrive.Location = new System.Drawing.Point(299, 51);
            this.lblUnitPumpDrive.Name = "lblUnitPumpDrive";
            this.lblUnitPumpDrive.Size = new System.Drawing.Size(52, 25);
            this.lblUnitPumpDrive.TabIndex = 99;
            this.lblUnitPumpDrive.Text = "Unit:";
            // 
            // lblsizePumpDrive
            // 
            this.lblsizePumpDrive.AutoSize = true;
            this.lblsizePumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsizePumpDrive.Location = new System.Drawing.Point(75, 49);
            this.lblsizePumpDrive.Name = "lblsizePumpDrive";
            this.lblsizePumpDrive.Size = new System.Drawing.Size(134, 25);
            this.lblsizePumpDrive.TabIndex = 98;
            this.lblsizePumpDrive.Text = "Size of Pump:";
            // 
            // cbbUnitPumpDrive
            // 
            this.cbbUnitPumpDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnitPumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnitPumpDrive.FormattingEnabled = true;
            this.cbbUnitPumpDrive.Items.AddRange(new object[] {
            "cubic meter (m3)/s * kPa",
            "gpm * psi"});
            this.cbbUnitPumpDrive.Location = new System.Drawing.Point(293, 97);
            this.cbbUnitPumpDrive.Name = "cbbUnitPumpDrive";
            this.cbbUnitPumpDrive.Size = new System.Drawing.Size(200, 30);
            this.cbbUnitPumpDrive.TabIndex = 97;
            this.cbbUnitPumpDrive.SelectedIndexChanged += new System.EventHandler(this.cbbUnitPumpDrive_SelectedIndexChanged);
            // 
            // txtsizePumpDrive
            // 
            this.txtsizePumpDrive.BackColor = System.Drawing.Color.LightBlue;
            this.txtsizePumpDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsizePumpDrive.Location = new System.Drawing.Point(74, 97);
            this.txtsizePumpDrive.Name = "txtsizePumpDrive";
            this.txtsizePumpDrive.Size = new System.Drawing.Size(152, 28);
            this.txtsizePumpDrive.TabIndex = 96;
            this.txtsizePumpDrive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsizePumpDrive.TextChanged += new System.EventHandler(this.txtsizePumpDrive_TextChanged);
            // 
            // lblNote2
            // 
            this.lblNote2.AutoSize = true;
            this.lblNote2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote2.ForeColor = System.Drawing.Color.Blue;
            this.lblNote2.Location = new System.Drawing.Point(571, 54);
            this.lblNote2.Name = "lblNote2";
            this.lblNote2.Size = new System.Drawing.Size(488, 54);
            this.lblNote2.TabIndex = 109;
            this.lblNote2.Text = "**There are 2 types of pumps: a standard pump and a pump include drive.\r\n\r\nUser c" +
    "an select the desired type by clicking the tab menu below.";
            // 
            // Equipment_Pump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 516);
            this.Controls.Add(this.lblNote2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblEquipNamePump);
            this.Controls.Add(this.txtEquipNamePump);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Equipment_Pump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pump Page";
            this.Load += new System.EventHandler(this.Equipment_Pump_Load);
            this.gbPressureP.ResumeLayout(false);
            this.gbPressureP.PerformLayout();
            this.gbMaterialP.ResumeLayout(false);
            this.gbMaterialP.PerformLayout();
            this.gbTypePump.ResumeLayout(false);
            this.gbTypePump.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPump.ResumeLayout(false);
            this.tabPump.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoP)).EndInit();
            this.tabPumpDrive.ResumeLayout(false);
            this.tabPumpDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoPD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotePump;
        private System.Windows.Forms.Button btnCalPump;
        private System.Windows.Forms.Button btnDonePump;
        private System.Windows.Forms.Label lblEquipNamePump;
        private System.Windows.Forms.TextBox txtEquipNamePump;
        private System.Windows.Forms.Label lblPurchasePump;
        private System.Windows.Forms.TextBox txtPurchasePump;
        private System.Windows.Forms.Label lblUnitPump;
        private System.Windows.Forms.Label lblPumpCap;
        private System.Windows.Forms.ComboBox cbbUnitPump;
        private System.Windows.Forms.TextBox txtPumpCap;
        private System.Windows.Forms.GroupBox gbPressureP;
        private System.Windows.Forms.RadioButton rdb30000;
        private System.Windows.Forms.RadioButton rdb20000;
        private System.Windows.Forms.RadioButton rdb10000;
        private System.Windows.Forms.RadioButton rdb5000;
        private System.Windows.Forms.RadioButton rdb1035;
        private System.Windows.Forms.GroupBox gbMaterialP;
        private System.Windows.Forms.RadioButton rdbNickelAlloyPump;
        private System.Windows.Forms.RadioButton rdbStainlessSteelPump;
        private System.Windows.Forms.RadioButton rdbCastSteelPump;
        private System.Windows.Forms.RadioButton rdbCastIronPump;
        private System.Windows.Forms.GroupBox gbTypePump;
        private System.Windows.Forms.RadioButton rdbDiaphragmP;
        private System.Windows.Forms.RadioButton rdbGearP;
        private System.Windows.Forms.RadioButton rdbRotaryP;
        private System.Windows.Forms.RadioButton rdbReciprocatingP;
        private System.Windows.Forms.RadioButton rdbCentifugalP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPump;
        private System.Windows.Forms.TabPage tabPumpDrive;
        private System.Windows.Forms.Label lblNotePD;
        private System.Windows.Forms.Label lblUnit2PumpDrive;
        private System.Windows.Forms.Label lblUtilityPumpDrive;
        private System.Windows.Forms.ComboBox cbbUnit2PumpDrive;
        private System.Windows.Forms.TextBox txtUtilityPumpDrive;
        private System.Windows.Forms.Label lblUnitPumpDrive;
        private System.Windows.Forms.Label lblsizePumpDrive;
        private System.Windows.Forms.ComboBox cbbUnitPumpDrive;
        private System.Windows.Forms.TextBox txtsizePumpDrive;
        private System.Windows.Forms.Button btnCalPD;
        private System.Windows.Forms.Button btnDonePD;
        private System.Windows.Forms.Label lblPurchasePumpDrive;
        private System.Windows.Forms.TextBox txtPurchasePumpDrive;
        private System.Windows.Forms.Label lblNote2;
        private System.Windows.Forms.PictureBox pbInfoP;
        private System.Windows.Forms.PictureBox pbInfoPD;
    }
}
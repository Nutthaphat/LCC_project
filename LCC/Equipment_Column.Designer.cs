namespace LCC
{
    partial class Equipment_Column
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_Column));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEquipName = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.gbTrayTU = new System.Windows.Forms.GroupBox();
            this.nudNumTray = new System.Windows.Forms.NumericUpDown();
            this.lblNumTTU = new System.Windows.Forms.Label();
            this.cbbUnitTTU = new System.Windows.Forms.ComboBox();
            this.lblUnitTTU = new System.Windows.Forms.Label();
            this.lblDiameterTTU = new System.Windows.Forms.Label();
            this.txtDiameterTTU = new System.Windows.Forms.TextBox();
            this.gbTrayType = new System.Windows.Forms.GroupBox();
            this.lblBCTCS = new System.Windows.Forms.Label();
            this.rdbBCTSS = new System.Windows.Forms.RadioButton();
            this.rdbVTSS = new System.Windows.Forms.RadioButton();
            this.rdbSTBGTSS = new System.Windows.Forms.RadioButton();
            this.rdbSSST = new System.Windows.Forms.RadioButton();
            this.rdbCSVT = new System.Windows.Forms.RadioButton();
            this.rdbCSST = new System.Windows.Forms.RadioButton();
            this.gbTU = new System.Windows.Forms.GroupBox();
            this.gbPressureTU = new System.Windows.Forms.GroupBox();
            this.rdb40000TU = new System.Windows.Forms.RadioButton();
            this.rdb30000TU = new System.Windows.Forms.RadioButton();
            this.rdb20000TU = new System.Windows.Forms.RadioButton();
            this.rdb10000TU = new System.Windows.Forms.RadioButton();
            this.rdb5000TU = new System.Windows.Forms.RadioButton();
            this.rdb1035TU = new System.Windows.Forms.RadioButton();
            this.rdb101TU = new System.Windows.Forms.RadioButton();
            this.cbbUnitTU = new System.Windows.Forms.ComboBox();
            this.lblUnitTU = new System.Windows.Forms.Label();
            this.gbMatTU = new System.Windows.Forms.GroupBox();
            this.rdbNATU = new System.Windows.Forms.RadioButton();
            this.rdbSSTU = new System.Windows.Forms.RadioButton();
            this.rdbCSTU = new System.Windows.Forms.RadioButton();
            this.lblHeightTU = new System.Windows.Forms.Label();
            this.txtHeightTU = new System.Windows.Forms.TextBox();
            this.gbDiameterTU = new System.Windows.Forms.GroupBox();
            this.rdb4TU = new System.Windows.Forms.RadioButton();
            this.rdb3TU = new System.Windows.Forms.RadioButton();
            this.rdb2TU = new System.Windows.Forms.RadioButton();
            this.rdb1TU = new System.Windows.Forms.RadioButton();
            this.rdb05TU = new System.Windows.Forms.RadioButton();
            this.lblNoteTU = new System.Windows.Forms.Label();
            this.lblNoteTTU = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.txtPurchase = new System.Windows.Forms.TextBox();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.cbTrayCheck = new System.Windows.Forms.CheckBox();
            this.lblTray = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbTrayTU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTray)).BeginInit();
            this.gbTrayType.SuspendLayout();
            this.gbTU.SuspendLayout();
            this.gbPressureTU.SuspendLayout();
            this.gbMatTU.SuspendLayout();
            this.gbDiameterTU.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1277, 28);
            this.menuStrip1.TabIndex = 112;
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
            this.lblEquipName.Location = new System.Drawing.Point(36, 51);
            this.lblEquipName.Name = "lblEquipName";
            this.lblEquipName.Size = new System.Drawing.Size(168, 25);
            this.lblEquipName.TabIndex = 118;
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
            this.txtEquipName.TabIndex = 117;
            this.txtEquipName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbTrayTU
            // 
            this.gbTrayTU.BackColor = System.Drawing.Color.Transparent;
            this.gbTrayTU.Controls.Add(this.lblNoteTTU);
            this.gbTrayTU.Controls.Add(this.nudNumTray);
            this.gbTrayTU.Controls.Add(this.lblNumTTU);
            this.gbTrayTU.Controls.Add(this.cbbUnitTTU);
            this.gbTrayTU.Controls.Add(this.lblUnitTTU);
            this.gbTrayTU.Controls.Add(this.lblDiameterTTU);
            this.gbTrayTU.Controls.Add(this.txtDiameterTTU);
            this.gbTrayTU.Controls.Add(this.gbTrayType);
            this.gbTrayTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTrayTU.Location = new System.Drawing.Point(727, 109);
            this.gbTrayTU.Name = "gbTrayTU";
            this.gbTrayTU.Size = new System.Drawing.Size(508, 421);
            this.gbTrayTU.TabIndex = 120;
            this.gbTrayTU.TabStop = false;
            this.gbTrayTU.Text = "Tray Information";
            // 
            // nudNumTray
            // 
            this.nudNumTray.Location = new System.Drawing.Point(313, 254);
            this.nudNumTray.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumTray.Name = "nudNumTray";
            this.nudNumTray.Size = new System.Drawing.Size(181, 28);
            this.nudNumTray.TabIndex = 112;
            this.nudNumTray.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNumTray.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumTray.ValueChanged += new System.EventHandler(this.nudNumTray_ValueChanged);
            // 
            // lblNumTTU
            // 
            this.lblNumTTU.AutoSize = true;
            this.lblNumTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTTU.Location = new System.Drawing.Point(313, 216);
            this.lblNumTTU.Name = "lblNumTTU";
            this.lblNumTTU.Size = new System.Drawing.Size(153, 25);
            this.lblNumTTU.TabIndex = 111;
            this.lblNumTTU.Text = "Number of Tray:";
            // 
            // cbbUnitTTU
            // 
            this.cbbUnitTTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnitTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnitTTU.FormattingEnabled = true;
            this.cbbUnitTTU.Items.AddRange(new object[] {
            "meters",
            "feet",
            "inches"});
            this.cbbUnitTTU.Location = new System.Drawing.Point(318, 170);
            this.cbbUnitTTU.Name = "cbbUnitTTU";
            this.cbbUnitTTU.Size = new System.Drawing.Size(178, 30);
            this.cbbUnitTTU.TabIndex = 107;
            this.cbbUnitTTU.SelectedIndexChanged += new System.EventHandler(this.cbbUnitTTU_SelectedIndexChanged);
            // 
            // lblUnitTTU
            // 
            this.lblUnitTTU.AutoSize = true;
            this.lblUnitTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitTTU.Location = new System.Drawing.Point(313, 137);
            this.lblUnitTTU.Name = "lblUnitTTU";
            this.lblUnitTTU.Size = new System.Drawing.Size(52, 25);
            this.lblUnitTTU.TabIndex = 109;
            this.lblUnitTTU.Text = "Unit:";
            // 
            // lblDiameterTTU
            // 
            this.lblDiameterTTU.AutoSize = true;
            this.lblDiameterTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiameterTTU.Location = new System.Drawing.Point(313, 47);
            this.lblDiameterTTU.Name = "lblDiameterTTU";
            this.lblDiameterTTU.Size = new System.Drawing.Size(162, 25);
            this.lblDiameterTTU.TabIndex = 108;
            this.lblDiameterTTU.Text = "Diameter of Tray:";
            // 
            // txtDiameterTTU
            // 
            this.txtDiameterTTU.BackColor = System.Drawing.Color.LightBlue;
            this.txtDiameterTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiameterTTU.Location = new System.Drawing.Point(318, 85);
            this.txtDiameterTTU.Name = "txtDiameterTTU";
            this.txtDiameterTTU.Size = new System.Drawing.Size(178, 28);
            this.txtDiameterTTU.TabIndex = 106;
            this.txtDiameterTTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiameterTTU.TextChanged += new System.EventHandler(this.txtDiameterTTU_TextChanged);
            // 
            // gbTrayType
            // 
            this.gbTrayType.BackColor = System.Drawing.Color.PapayaWhip;
            this.gbTrayType.Controls.Add(this.lblBCTCS);
            this.gbTrayType.Controls.Add(this.rdbBCTSS);
            this.gbTrayType.Controls.Add(this.rdbVTSS);
            this.gbTrayType.Controls.Add(this.rdbSTBGTSS);
            this.gbTrayType.Controls.Add(this.rdbSSST);
            this.gbTrayType.Controls.Add(this.rdbCSVT);
            this.gbTrayType.Controls.Add(this.rdbCSST);
            this.gbTrayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTrayType.Location = new System.Drawing.Point(6, 30);
            this.gbTrayType.Name = "gbTrayType";
            this.gbTrayType.Size = new System.Drawing.Size(301, 304);
            this.gbTrayType.TabIndex = 103;
            this.gbTrayType.TabStop = false;
            this.gbTrayType.Text = "Tray Type";
            // 
            // lblBCTCS
            // 
            this.lblBCTCS.AutoSize = true;
            this.lblBCTCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCTCS.Location = new System.Drawing.Point(31, 149);
            this.lblBCTCS.Name = "lblBCTCS";
            this.lblBCTCS.Size = new System.Drawing.Size(177, 22);
            this.lblBCTCS.TabIndex = 112;
            this.lblBCTCS.Text = "Bubble cap tray (CS)";
            // 
            // rdbBCTSS
            // 
            this.rdbBCTSS.AutoSize = true;
            this.rdbBCTSS.Location = new System.Drawing.Point(12, 261);
            this.rdbBCTSS.Name = "rdbBCTSS";
            this.rdbBCTSS.Size = new System.Drawing.Size(197, 26);
            this.rdbBCTSS.TabIndex = 6;
            this.rdbBCTSS.TabStop = true;
            this.rdbBCTSS.Text = "Bubble cap tray (SS)";
            this.rdbBCTSS.UseVisualStyleBackColor = true;
            this.rdbBCTSS.CheckedChanged += new System.EventHandler(this.rdbBCTSS_CheckedChanged);
            // 
            // rdbVTSS
            // 
            this.rdbVTSS.AutoSize = true;
            this.rdbVTSS.Location = new System.Drawing.Point(12, 223);
            this.rdbVTSS.Name = "rdbVTSS";
            this.rdbVTSS.Size = new System.Drawing.Size(152, 26);
            this.rdbVTSS.TabIndex = 5;
            this.rdbVTSS.TabStop = true;
            this.rdbVTSS.Text = "Valve tray (SS)";
            this.rdbVTSS.UseVisualStyleBackColor = true;
            this.rdbVTSS.CheckedChanged += new System.EventHandler(this.rdbVTSS_CheckedChanged);
            // 
            // rdbSTBGTSS
            // 
            this.rdbSTBGTSS.AutoSize = true;
            this.rdbSTBGTSS.Location = new System.Drawing.Point(12, 183);
            this.rdbSTBGTSS.Name = "rdbSTBGTSS";
            this.rdbSTBGTSS.Size = new System.Drawing.Size(254, 26);
            this.rdbSTBGTSS.TabIndex = 4;
            this.rdbSTBGTSS.TabStop = true;
            this.rdbSTBGTSS.Text = "Stamped turbogrid tray (SS)";
            this.rdbSTBGTSS.UseVisualStyleBackColor = true;
            this.rdbSTBGTSS.CheckedChanged += new System.EventHandler(this.rdbSTBGTSS_CheckedChanged);
            // 
            // rdbSSST
            // 
            this.rdbSSST.AutoSize = true;
            this.rdbSSST.Location = new System.Drawing.Point(12, 116);
            this.rdbSSST.Name = "rdbSSST";
            this.rdbSSST.Size = new System.Drawing.Size(178, 26);
            this.rdbSSST.TabIndex = 3;
            this.rdbSSST.TabStop = true;
            this.rdbSSST.Text = "Sieve tray (SS) or ";
            this.rdbSSST.UseVisualStyleBackColor = true;
            this.rdbSSST.CheckedChanged += new System.EventHandler(this.rdbSSST_CheckedChanged);
            // 
            // rdbCSVT
            // 
            this.rdbCSVT.AutoSize = true;
            this.rdbCSVT.Location = new System.Drawing.Point(12, 76);
            this.rdbCSVT.Name = "rdbCSVT";
            this.rdbCSVT.Size = new System.Drawing.Size(153, 26);
            this.rdbCSVT.TabIndex = 2;
            this.rdbCSVT.TabStop = true;
            this.rdbCSVT.Text = "Valve tray (CS)";
            this.rdbCSVT.UseVisualStyleBackColor = true;
            this.rdbCSVT.CheckedChanged += new System.EventHandler(this.rdbCSVT_CheckedChanged);
            // 
            // rdbCSST
            // 
            this.rdbCSST.AutoSize = true;
            this.rdbCSST.Location = new System.Drawing.Point(12, 39);
            this.rdbCSST.Name = "rdbCSST";
            this.rdbCSST.Size = new System.Drawing.Size(153, 26);
            this.rdbCSST.TabIndex = 1;
            this.rdbCSST.TabStop = true;
            this.rdbCSST.Text = "Sieve tray (CS)";
            this.rdbCSST.UseVisualStyleBackColor = true;
            this.rdbCSST.CheckedChanged += new System.EventHandler(this.rdbCSST_CheckedChanged);
            // 
            // gbTU
            // 
            this.gbTU.BackColor = System.Drawing.Color.Transparent;
            this.gbTU.Controls.Add(this.lblNoteTU);
            this.gbTU.Controls.Add(this.gbPressureTU);
            this.gbTU.Controls.Add(this.cbbUnitTU);
            this.gbTU.Controls.Add(this.lblUnitTU);
            this.gbTU.Controls.Add(this.gbMatTU);
            this.gbTU.Controls.Add(this.lblHeightTU);
            this.gbTU.Controls.Add(this.txtHeightTU);
            this.gbTU.Controls.Add(this.gbDiameterTU);
            this.gbTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTU.Location = new System.Drawing.Point(41, 109);
            this.gbTU.Name = "gbTU";
            this.gbTU.Size = new System.Drawing.Size(664, 421);
            this.gbTU.TabIndex = 119;
            this.gbTU.TabStop = false;
            this.gbTU.Text = "Column Information";
            // 
            // gbPressureTU
            // 
            this.gbPressureTU.BackColor = System.Drawing.Color.PeachPuff;
            this.gbPressureTU.Controls.Add(this.rdb40000TU);
            this.gbPressureTU.Controls.Add(this.rdb30000TU);
            this.gbPressureTU.Controls.Add(this.rdb20000TU);
            this.gbPressureTU.Controls.Add(this.rdb10000TU);
            this.gbPressureTU.Controls.Add(this.rdb5000TU);
            this.gbPressureTU.Controls.Add(this.rdb1035TU);
            this.gbPressureTU.Controls.Add(this.rdb101TU);
            this.gbPressureTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPressureTU.Location = new System.Drawing.Point(483, 34);
            this.gbPressureTU.Name = "gbPressureTU";
            this.gbPressureTU.Size = new System.Drawing.Size(167, 300);
            this.gbPressureTU.TabIndex = 104;
            this.gbPressureTU.TabStop = false;
            this.gbPressureTU.Text = "Pressure";
            // 
            // rdb40000TU
            // 
            this.rdb40000TU.AutoSize = true;
            this.rdb40000TU.Location = new System.Drawing.Point(27, 257);
            this.rdb40000TU.Name = "rdb40000TU";
            this.rdb40000TU.Size = new System.Drawing.Size(122, 26);
            this.rdb40000TU.TabIndex = 7;
            this.rdb40000TU.TabStop = true;
            this.rdb40000TU.Text = "40,000 kPa";
            this.rdb40000TU.UseVisualStyleBackColor = true;
            this.rdb40000TU.CheckedChanged += new System.EventHandler(this.rdb40000TU_CheckedChanged);
            // 
            // rdb30000TU
            // 
            this.rdb30000TU.AutoSize = true;
            this.rdb30000TU.Location = new System.Drawing.Point(27, 219);
            this.rdb30000TU.Name = "rdb30000TU";
            this.rdb30000TU.Size = new System.Drawing.Size(122, 26);
            this.rdb30000TU.TabIndex = 6;
            this.rdb30000TU.TabStop = true;
            this.rdb30000TU.Text = "30,000 kPa";
            this.rdb30000TU.UseVisualStyleBackColor = true;
            this.rdb30000TU.CheckedChanged += new System.EventHandler(this.rdb30000TU_CheckedChanged);
            // 
            // rdb20000TU
            // 
            this.rdb20000TU.AutoSize = true;
            this.rdb20000TU.Location = new System.Drawing.Point(27, 181);
            this.rdb20000TU.Name = "rdb20000TU";
            this.rdb20000TU.Size = new System.Drawing.Size(122, 26);
            this.rdb20000TU.TabIndex = 5;
            this.rdb20000TU.TabStop = true;
            this.rdb20000TU.Text = "20,000 kPa";
            this.rdb20000TU.UseVisualStyleBackColor = true;
            this.rdb20000TU.CheckedChanged += new System.EventHandler(this.rdb20000TU_CheckedChanged);
            // 
            // rdb10000TU
            // 
            this.rdb10000TU.AutoSize = true;
            this.rdb10000TU.Location = new System.Drawing.Point(27, 143);
            this.rdb10000TU.Name = "rdb10000TU";
            this.rdb10000TU.Size = new System.Drawing.Size(122, 26);
            this.rdb10000TU.TabIndex = 4;
            this.rdb10000TU.TabStop = true;
            this.rdb10000TU.Text = "10,000 kPa";
            this.rdb10000TU.UseVisualStyleBackColor = true;
            this.rdb10000TU.CheckedChanged += new System.EventHandler(this.rdb10000TU_CheckedChanged);
            // 
            // rdb5000TU
            // 
            this.rdb5000TU.AutoSize = true;
            this.rdb5000TU.Location = new System.Drawing.Point(27, 108);
            this.rdb5000TU.Name = "rdb5000TU";
            this.rdb5000TU.Size = new System.Drawing.Size(107, 26);
            this.rdb5000TU.TabIndex = 3;
            this.rdb5000TU.TabStop = true;
            this.rdb5000TU.Text = "5000 kPa";
            this.rdb5000TU.UseVisualStyleBackColor = true;
            this.rdb5000TU.CheckedChanged += new System.EventHandler(this.rdb5000TU_CheckedChanged);
            // 
            // rdb1035TU
            // 
            this.rdb1035TU.AutoSize = true;
            this.rdb1035TU.Location = new System.Drawing.Point(27, 69);
            this.rdb1035TU.Name = "rdb1035TU";
            this.rdb1035TU.Size = new System.Drawing.Size(107, 26);
            this.rdb1035TU.TabIndex = 2;
            this.rdb1035TU.TabStop = true;
            this.rdb1035TU.Text = "1035 kPa";
            this.rdb1035TU.UseVisualStyleBackColor = true;
            this.rdb1035TU.CheckedChanged += new System.EventHandler(this.rdb1035TU_CheckedChanged);
            // 
            // rdb101TU
            // 
            this.rdb101TU.AutoSize = true;
            this.rdb101TU.Location = new System.Drawing.Point(27, 36);
            this.rdb101TU.Name = "rdb101TU";
            this.rdb101TU.Size = new System.Drawing.Size(97, 26);
            this.rdb101TU.TabIndex = 1;
            this.rdb101TU.TabStop = true;
            this.rdb101TU.Text = "101 kPa";
            this.rdb101TU.UseVisualStyleBackColor = true;
            this.rdb101TU.CheckedChanged += new System.EventHandler(this.rdb101TU_CheckedChanged);
            // 
            // cbbUnitTU
            // 
            this.cbbUnitTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnitTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnitTU.FormattingEnabled = true;
            this.cbbUnitTU.Items.AddRange(new object[] {
            "meters",
            "feet",
            "inches"});
            this.cbbUnitTU.Location = new System.Drawing.Point(26, 302);
            this.cbbUnitTU.Name = "cbbUnitTU";
            this.cbbUnitTU.Size = new System.Drawing.Size(200, 30);
            this.cbbUnitTU.TabIndex = 107;
            this.cbbUnitTU.SelectedIndexChanged += new System.EventHandler(this.cbbUnitTU_SelectedIndexChanged);
            // 
            // lblUnitTU
            // 
            this.lblUnitTU.AutoSize = true;
            this.lblUnitTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitTU.Location = new System.Drawing.Point(21, 274);
            this.lblUnitTU.Name = "lblUnitTU";
            this.lblUnitTU.Size = new System.Drawing.Size(52, 25);
            this.lblUnitTU.TabIndex = 109;
            this.lblUnitTU.Text = "Unit:";
            // 
            // gbMatTU
            // 
            this.gbMatTU.BackColor = System.Drawing.Color.PeachPuff;
            this.gbMatTU.Controls.Add(this.rdbNATU);
            this.gbMatTU.Controls.Add(this.rdbSSTU);
            this.gbMatTU.Controls.Add(this.rdbCSTU);
            this.gbMatTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMatTU.Location = new System.Drawing.Point(26, 34);
            this.gbMatTU.Name = "gbMatTU";
            this.gbMatTU.Size = new System.Drawing.Size(227, 156);
            this.gbMatTU.TabIndex = 110;
            this.gbMatTU.TabStop = false;
            this.gbMatTU.Text = "Material";
            // 
            // rdbNATU
            // 
            this.rdbNATU.AutoSize = true;
            this.rdbNATU.Location = new System.Drawing.Point(22, 112);
            this.rdbNATU.Name = "rdbNATU";
            this.rdbNATU.Size = new System.Drawing.Size(124, 26);
            this.rdbNATU.TabIndex = 4;
            this.rdbNATU.TabStop = true;
            this.rdbNATU.Text = "Nickel Alloy";
            this.rdbNATU.UseVisualStyleBackColor = true;
            this.rdbNATU.CheckedChanged += new System.EventHandler(this.rdbNATU_CheckedChanged);
            // 
            // rdbSSTU
            // 
            this.rdbSSTU.AutoSize = true;
            this.rdbSSTU.Location = new System.Drawing.Point(22, 74);
            this.rdbSSTU.Name = "rdbSSTU";
            this.rdbSSTU.Size = new System.Drawing.Size(185, 26);
            this.rdbSSTU.TabIndex = 3;
            this.rdbSSTU.TabStop = true;
            this.rdbSSTU.Text = "316 Stainless Steel";
            this.rdbSSTU.UseVisualStyleBackColor = true;
            this.rdbSSTU.CheckedChanged += new System.EventHandler(this.rdbSSTU_CheckedChanged);
            // 
            // rdbCSTU
            // 
            this.rdbCSTU.AutoSize = true;
            this.rdbCSTU.Location = new System.Drawing.Point(22, 35);
            this.rdbCSTU.Name = "rdbCSTU";
            this.rdbCSTU.Size = new System.Drawing.Size(136, 26);
            this.rdbCSTU.TabIndex = 2;
            this.rdbCSTU.TabStop = true;
            this.rdbCSTU.Text = "Carbon Steel";
            this.rdbCSTU.UseVisualStyleBackColor = true;
            this.rdbCSTU.CheckedChanged += new System.EventHandler(this.rdbCSTU_CheckedChanged);
            // 
            // lblHeightTU
            // 
            this.lblHeightTU.AutoSize = true;
            this.lblHeightTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeightTU.Location = new System.Drawing.Point(21, 206);
            this.lblHeightTU.Name = "lblHeightTU";
            this.lblHeightTU.Size = new System.Drawing.Size(147, 25);
            this.lblHeightTU.TabIndex = 108;
            this.lblHeightTU.Text = "Column Height:";
            // 
            // txtHeightTU
            // 
            this.txtHeightTU.BackColor = System.Drawing.Color.LightBlue;
            this.txtHeightTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeightTU.Location = new System.Drawing.Point(26, 234);
            this.txtHeightTU.Name = "txtHeightTU";
            this.txtHeightTU.Size = new System.Drawing.Size(200, 28);
            this.txtHeightTU.TabIndex = 106;
            this.txtHeightTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeightTU.TextChanged += new System.EventHandler(this.txtHeightTU_TextChanged);
            // 
            // gbDiameterTU
            // 
            this.gbDiameterTU.BackColor = System.Drawing.Color.PeachPuff;
            this.gbDiameterTU.Controls.Add(this.rdb4TU);
            this.gbDiameterTU.Controls.Add(this.rdb3TU);
            this.gbDiameterTU.Controls.Add(this.rdb2TU);
            this.gbDiameterTU.Controls.Add(this.rdb1TU);
            this.gbDiameterTU.Controls.Add(this.rdb05TU);
            this.gbDiameterTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDiameterTU.Location = new System.Drawing.Point(259, 34);
            this.gbDiameterTU.Name = "gbDiameterTU";
            this.gbDiameterTU.Size = new System.Drawing.Size(218, 300);
            this.gbDiameterTU.TabIndex = 103;
            this.gbDiameterTU.TabStop = false;
            this.gbDiameterTU.Text = "Diameter of column";
            // 
            // rdb4TU
            // 
            this.rdb4TU.AutoSize = true;
            this.rdb4TU.Location = new System.Drawing.Point(27, 206);
            this.rdb4TU.Name = "rdb4TU";
            this.rdb4TU.Size = new System.Drawing.Size(127, 26);
            this.rdb4TU.TabIndex = 5;
            this.rdb4TU.TabStop = true;
            this.rdb4TU.Text = "4 meter (m.)";
            this.rdb4TU.UseVisualStyleBackColor = true;
            this.rdb4TU.CheckedChanged += new System.EventHandler(this.rdb4TU_CheckedChanged);
            // 
            // rdb3TU
            // 
            this.rdb3TU.AutoSize = true;
            this.rdb3TU.Location = new System.Drawing.Point(27, 166);
            this.rdb3TU.Name = "rdb3TU";
            this.rdb3TU.Size = new System.Drawing.Size(127, 26);
            this.rdb3TU.TabIndex = 4;
            this.rdb3TU.TabStop = true;
            this.rdb3TU.Text = "3 meter (m.)";
            this.rdb3TU.UseVisualStyleBackColor = true;
            this.rdb3TU.CheckedChanged += new System.EventHandler(this.rdb3TU_CheckedChanged);
            // 
            // rdb2TU
            // 
            this.rdb2TU.AutoSize = true;
            this.rdb2TU.Location = new System.Drawing.Point(27, 127);
            this.rdb2TU.Name = "rdb2TU";
            this.rdb2TU.Size = new System.Drawing.Size(127, 26);
            this.rdb2TU.TabIndex = 3;
            this.rdb2TU.TabStop = true;
            this.rdb2TU.Text = "2 meter (m.)";
            this.rdb2TU.UseVisualStyleBackColor = true;
            this.rdb2TU.CheckedChanged += new System.EventHandler(this.rdb2TU_CheckedChanged);
            // 
            // rdb1TU
            // 
            this.rdb1TU.AutoSize = true;
            this.rdb1TU.Location = new System.Drawing.Point(27, 88);
            this.rdb1TU.Name = "rdb1TU";
            this.rdb1TU.Size = new System.Drawing.Size(127, 26);
            this.rdb1TU.TabIndex = 2;
            this.rdb1TU.TabStop = true;
            this.rdb1TU.Text = "1 meter (m.)";
            this.rdb1TU.UseVisualStyleBackColor = true;
            this.rdb1TU.CheckedChanged += new System.EventHandler(this.rdb1TU_CheckedChanged);
            // 
            // rdb05TU
            // 
            this.rdb05TU.AutoSize = true;
            this.rdb05TU.Location = new System.Drawing.Point(27, 51);
            this.rdb05TU.Name = "rdb05TU";
            this.rdb05TU.Size = new System.Drawing.Size(142, 26);
            this.rdb05TU.TabIndex = 1;
            this.rdb05TU.TabStop = true;
            this.rdb05TU.Text = "0.5 meter (m.)";
            this.rdb05TU.UseVisualStyleBackColor = true;
            this.rdb05TU.CheckedChanged += new System.EventHandler(this.rdb05TU_CheckedChanged);
            // 
            // lblNoteTU
            // 
            this.lblNoteTU.AutoSize = true;
            this.lblNoteTU.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNoteTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteTU.ForeColor = System.Drawing.Color.Blue;
            this.lblNoteTU.Location = new System.Drawing.Point(174, 351);
            this.lblNoteTU.Name = "lblNoteTU";
            this.lblNoteTU.Size = new System.Drawing.Size(250, 54);
            this.lblNoteTU.TabIndex = 125;
            this.lblNoteTU.Text = "*The height range for this calculation \r\n\r\nis 1.5 m to 20 m.";
            this.lblNoteTU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoteTTU
            // 
            this.lblNoteTTU.AutoSize = true;
            this.lblNoteTTU.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNoteTTU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteTTU.ForeColor = System.Drawing.Color.Blue;
            this.lblNoteTTU.Location = new System.Drawing.Point(154, 351);
            this.lblNoteTTU.Name = "lblNoteTTU";
            this.lblNoteTTU.Size = new System.Drawing.Size(250, 54);
            this.lblNoteTTU.TabIndex = 126;
            this.lblNoteTTU.Text = "*The length range for this calculation \r\n\r\nis 0.5 m to 3.81 m.";
            this.lblNoteTTU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(1089, 552);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(146, 39);
            this.btnDone.TabIndex = 126;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCal
            // 
            this.btnCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCal.Location = new System.Drawing.Point(926, 552);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(146, 39);
            this.btnCal.TabIndex = 127;
            this.btnCal.Text = "Calculate";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtPurchase
            // 
            this.txtPurchase.BackColor = System.Drawing.Color.LightBlue;
            this.txtPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchase.Location = new System.Drawing.Point(679, 558);
            this.txtPurchase.Name = "txtPurchase";
            this.txtPurchase.ReadOnly = true;
            this.txtPurchase.Size = new System.Drawing.Size(219, 28);
            this.txtPurchase.TabIndex = 124;
            this.txtPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPurchase
            // 
            this.lblPurchase.AutoSize = true;
            this.lblPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchase.Location = new System.Drawing.Point(497, 559);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(147, 25);
            this.lblPurchase.TabIndex = 125;
            this.lblPurchase.Text = "Purchase Cost:";
            // 
            // cbTrayCheck
            // 
            this.cbTrayCheck.AutoSize = true;
            this.cbTrayCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrayCheck.Location = new System.Drawing.Point(729, 61);
            this.cbTrayCheck.Name = "cbTrayCheck";
            this.cbTrayCheck.Size = new System.Drawing.Size(147, 29);
            this.cbTrayCheck.TabIndex = 128;
            this.cbTrayCheck.Text = "Include Tray ";
            this.cbTrayCheck.UseVisualStyleBackColor = true;
            this.cbTrayCheck.CheckedChanged += new System.EventHandler(this.cbTrayCheck_CheckedChanged);
            // 
            // lblTray
            // 
            this.lblTray.AutoSize = true;
            this.lblTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTray.ForeColor = System.Drawing.Color.Blue;
            this.lblTray.Location = new System.Drawing.Point(895, 62);
            this.lblTray.Name = "lblTray";
            this.lblTray.Size = new System.Drawing.Size(283, 25);
            this.lblTray.TabIndex = 129;
            this.lblTray.Text = "***Tick the box to include a tray";
            // 
            // Equipment_Column
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 605);
            this.Controls.Add(this.lblTray);
            this.Controls.Add(this.cbTrayCheck);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.txtPurchase);
            this.Controls.Add(this.lblPurchase);
            this.Controls.Add(this.gbTrayTU);
            this.Controls.Add(this.gbTU);
            this.Controls.Add(this.lblEquipName);
            this.Controls.Add(this.txtEquipName);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Equipment_Column";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Column Page";
            this.Load += new System.EventHandler(this.Equipment_Column_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbTrayTU.ResumeLayout(false);
            this.gbTrayTU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTray)).EndInit();
            this.gbTrayType.ResumeLayout(false);
            this.gbTrayType.PerformLayout();
            this.gbTU.ResumeLayout(false);
            this.gbTU.PerformLayout();
            this.gbPressureTU.ResumeLayout(false);
            this.gbPressureTU.PerformLayout();
            this.gbMatTU.ResumeLayout(false);
            this.gbMatTU.PerformLayout();
            this.gbDiameterTU.ResumeLayout(false);
            this.gbDiameterTU.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblEquipName;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.GroupBox gbTrayTU;
        private System.Windows.Forms.NumericUpDown nudNumTray;
        private System.Windows.Forms.Label lblNumTTU;
        private System.Windows.Forms.ComboBox cbbUnitTTU;
        private System.Windows.Forms.Label lblUnitTTU;
        private System.Windows.Forms.Label lblDiameterTTU;
        private System.Windows.Forms.TextBox txtDiameterTTU;
        private System.Windows.Forms.GroupBox gbTrayType;
        private System.Windows.Forms.Label lblBCTCS;
        private System.Windows.Forms.RadioButton rdbBCTSS;
        private System.Windows.Forms.RadioButton rdbVTSS;
        private System.Windows.Forms.RadioButton rdbSTBGTSS;
        private System.Windows.Forms.RadioButton rdbSSST;
        private System.Windows.Forms.RadioButton rdbCSVT;
        private System.Windows.Forms.RadioButton rdbCSST;
        private System.Windows.Forms.GroupBox gbTU;
        private System.Windows.Forms.GroupBox gbPressureTU;
        private System.Windows.Forms.RadioButton rdb40000TU;
        private System.Windows.Forms.RadioButton rdb30000TU;
        private System.Windows.Forms.RadioButton rdb20000TU;
        private System.Windows.Forms.RadioButton rdb10000TU;
        private System.Windows.Forms.RadioButton rdb5000TU;
        private System.Windows.Forms.RadioButton rdb1035TU;
        private System.Windows.Forms.RadioButton rdb101TU;
        private System.Windows.Forms.ComboBox cbbUnitTU;
        private System.Windows.Forms.Label lblUnitTU;
        private System.Windows.Forms.GroupBox gbMatTU;
        private System.Windows.Forms.RadioButton rdbNATU;
        private System.Windows.Forms.RadioButton rdbSSTU;
        private System.Windows.Forms.RadioButton rdbCSTU;
        private System.Windows.Forms.Label lblHeightTU;
        private System.Windows.Forms.TextBox txtHeightTU;
        private System.Windows.Forms.GroupBox gbDiameterTU;
        private System.Windows.Forms.RadioButton rdb4TU;
        private System.Windows.Forms.RadioButton rdb3TU;
        private System.Windows.Forms.RadioButton rdb2TU;
        private System.Windows.Forms.RadioButton rdb1TU;
        private System.Windows.Forms.RadioButton rdb05TU;
        private System.Windows.Forms.Label lblNoteTU;
        private System.Windows.Forms.Label lblNoteTTU;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.TextBox txtPurchase;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.CheckBox cbTrayCheck;
        private System.Windows.Forms.Label lblTray;
    }
}
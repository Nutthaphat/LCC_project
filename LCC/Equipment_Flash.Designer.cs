namespace LCC
{
    partial class Equipment_Flash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_Flash));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMaterial = new System.Windows.Forms.GroupBox();
            this.rdbNickelAlloy = new System.Windows.Forms.RadioButton();
            this.rdbStainlessSteel = new System.Windows.Forms.RadioButton();
            this.rdbCastSteel = new System.Windows.Forms.RadioButton();
            this.rdbCastIron = new System.Windows.Forms.RadioButton();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblHeatDuty = new System.Windows.Forms.Label();
            this.cbbUnit = new System.Windows.Forms.ComboBox();
            this.txtHeatDuty = new System.Windows.Forms.TextBox();
            this.btnDoneVR = new System.Windows.Forms.Button();
            this.txtPurchaseVR = new System.Windows.Forms.TextBox();
            this.lblPurchaseVR = new System.Windows.Forms.Label();
            this.lblEquipName = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.gbMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 28);
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
            // gbMaterial
            // 
            this.gbMaterial.Controls.Add(this.rdbNickelAlloy);
            this.gbMaterial.Controls.Add(this.rdbStainlessSteel);
            this.gbMaterial.Controls.Add(this.rdbCastSteel);
            this.gbMaterial.Controls.Add(this.rdbCastIron);
            this.gbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterial.Location = new System.Drawing.Point(40, 116);
            this.gbMaterial.Name = "gbMaterial";
            this.gbMaterial.Size = new System.Drawing.Size(204, 264);
            this.gbMaterial.TabIndex = 111;
            this.gbMaterial.TabStop = false;
            this.gbMaterial.Text = "Material";
            // 
            // rdbNickelAlloy
            // 
            this.rdbNickelAlloy.AutoSize = true;
            this.rdbNickelAlloy.Location = new System.Drawing.Point(25, 177);
            this.rdbNickelAlloy.Name = "rdbNickelAlloy";
            this.rdbNickelAlloy.Size = new System.Drawing.Size(124, 26);
            this.rdbNickelAlloy.TabIndex = 4;
            this.rdbNickelAlloy.TabStop = true;
            this.rdbNickelAlloy.Text = "Nickel Alloy";
            this.rdbNickelAlloy.UseVisualStyleBackColor = true;
            // 
            // rdbStainlessSteel
            // 
            this.rdbStainlessSteel.AutoSize = true;
            this.rdbStainlessSteel.Location = new System.Drawing.Point(25, 134);
            this.rdbStainlessSteel.Name = "rdbStainlessSteel";
            this.rdbStainlessSteel.Size = new System.Drawing.Size(150, 26);
            this.rdbStainlessSteel.TabIndex = 3;
            this.rdbStainlessSteel.TabStop = true;
            this.rdbStainlessSteel.Text = "Stainless Steel";
            this.rdbStainlessSteel.UseVisualStyleBackColor = true;
            // 
            // rdbCastSteel
            // 
            this.rdbCastSteel.AutoSize = true;
            this.rdbCastSteel.Location = new System.Drawing.Point(25, 91);
            this.rdbCastSteel.Name = "rdbCastSteel";
            this.rdbCastSteel.Size = new System.Drawing.Size(114, 26);
            this.rdbCastSteel.TabIndex = 2;
            this.rdbCastSteel.TabStop = true;
            this.rdbCastSteel.Text = "Cast Steel";
            this.rdbCastSteel.UseVisualStyleBackColor = true;
            // 
            // rdbCastIron
            // 
            this.rdbCastIron.AutoSize = true;
            this.rdbCastIron.Location = new System.Drawing.Point(25, 45);
            this.rdbCastIron.Name = "rdbCastIron";
            this.rdbCastIron.Size = new System.Drawing.Size(103, 26);
            this.rdbCastIron.TabIndex = 1;
            this.rdbCastIron.TabStop = true;
            this.rdbCastIron.Text = "Cast Iron";
            this.rdbCastIron.UseVisualStyleBackColor = true;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(471, 146);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(52, 25);
            this.lblUnit.TabIndex = 115;
            this.lblUnit.Text = "Unit:";
            // 
            // lblHeatDuty
            // 
            this.lblHeatDuty.AutoSize = true;
            this.lblHeatDuty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatDuty.Location = new System.Drawing.Point(287, 146);
            this.lblHeatDuty.Name = "lblHeatDuty";
            this.lblHeatDuty.Size = new System.Drawing.Size(104, 25);
            this.lblHeatDuty.TabIndex = 114;
            this.lblHeatDuty.Text = "Heat Duty:";
            // 
            // cbbUnit
            // 
            this.cbbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnit.FormattingEnabled = true;
            this.cbbUnit.Items.AddRange(new object[] {
            "kW",
            "MJ/hr",
            "BTU/s"});
            this.cbbUnit.Location = new System.Drawing.Point(476, 192);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Size = new System.Drawing.Size(193, 30);
            this.cbbUnit.TabIndex = 113;
            // 
            // txtHeatDuty
            // 
            this.txtHeatDuty.BackColor = System.Drawing.Color.LightBlue;
            this.txtHeatDuty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeatDuty.Location = new System.Drawing.Point(292, 192);
            this.txtHeatDuty.Name = "txtHeatDuty";
            this.txtHeatDuty.Size = new System.Drawing.Size(152, 28);
            this.txtHeatDuty.TabIndex = 112;
            this.txtHeatDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeatDuty.TextChanged += new System.EventHandler(this.txtHeatDuty_TextChanged);
            // 
            // btnDoneVR
            // 
            this.btnDoneVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoneVR.Location = new System.Drawing.Point(509, 310);
            this.btnDoneVR.Name = "btnDoneVR";
            this.btnDoneVR.Size = new System.Drawing.Size(146, 39);
            this.btnDoneVR.TabIndex = 118;
            this.btnDoneVR.Text = "Done";
            this.btnDoneVR.UseVisualStyleBackColor = true;
            this.btnDoneVR.Click += new System.EventHandler(this.btnDoneVR_Click);
            // 
            // txtPurchaseVR
            // 
            this.txtPurchaseVR.BackColor = System.Drawing.Color.LightBlue;
            this.txtPurchaseVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseVR.Location = new System.Drawing.Point(292, 316);
            this.txtPurchaseVR.Name = "txtPurchaseVR";
            this.txtPurchaseVR.Size = new System.Drawing.Size(152, 28);
            this.txtPurchaseVR.TabIndex = 116;
            this.txtPurchaseVR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseVR.TextChanged += new System.EventHandler(this.txtPurchaseVR_TextChanged);
            // 
            // lblPurchaseVR
            // 
            this.lblPurchaseVR.AutoSize = true;
            this.lblPurchaseVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseVR.Location = new System.Drawing.Point(287, 267);
            this.lblPurchaseVR.Name = "lblPurchaseVR";
            this.lblPurchaseVR.Size = new System.Drawing.Size(208, 25);
            this.lblPurchaseVR.TabIndex = 117;
            this.lblPurchaseVR.Text = "Define Purchase Cost:";
            // 
            // lblEquipName
            // 
            this.lblEquipName.AutoSize = true;
            this.lblEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipName.Location = new System.Drawing.Point(39, 57);
            this.lblEquipName.Name = "lblEquipName";
            this.lblEquipName.Size = new System.Drawing.Size(168, 25);
            this.lblEquipName.TabIndex = 120;
            this.lblEquipName.Text = "Equipment Name:";
            // 
            // txtEquipName
            // 
            this.txtEquipName.BackColor = System.Drawing.Color.LightGreen;
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(222, 56);
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.ReadOnly = true;
            this.txtEquipName.Size = new System.Drawing.Size(326, 28);
            this.txtEquipName.TabIndex = 119;
            this.txtEquipName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Equipment_Flash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 392);
            this.Controls.Add(this.lblEquipName);
            this.Controls.Add(this.txtEquipName);
            this.Controls.Add(this.btnDoneVR);
            this.Controls.Add(this.txtPurchaseVR);
            this.Controls.Add(this.lblPurchaseVR);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblHeatDuty);
            this.Controls.Add(this.cbbUnit);
            this.Controls.Add(this.txtHeatDuty);
            this.Controls.Add(this.gbMaterial);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Equipment_Flash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flash Page";
            this.Load += new System.EventHandler(this.Equipment_Flash_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMaterial.ResumeLayout(false);
            this.gbMaterial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMaterial;
        private System.Windows.Forms.RadioButton rdbNickelAlloy;
        private System.Windows.Forms.RadioButton rdbStainlessSteel;
        private System.Windows.Forms.RadioButton rdbCastSteel;
        private System.Windows.Forms.RadioButton rdbCastIron;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblHeatDuty;
        private System.Windows.Forms.ComboBox cbbUnit;
        private System.Windows.Forms.TextBox txtHeatDuty;
        private System.Windows.Forms.Button btnDoneVR;
        private System.Windows.Forms.TextBox txtPurchaseVR;
        private System.Windows.Forms.Label lblPurchaseVR;
        private System.Windows.Forms.Label lblEquipName;
        private System.Windows.Forms.TextBox txtEquipName;
    }
}
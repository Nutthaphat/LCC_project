namespace LCC
{
    partial class Utility_Chemical_Price
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utility_Chemical_Price));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEquipName = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.lbdutyType = new System.Windows.Forms.ListBox();
            this.gbDutyType = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.gbPrice = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPrice = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.gbDutyType.SuspendLayout();
            this.gbPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 28);
            this.menuStrip1.TabIndex = 2;
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
            this.lblEquipName.Location = new System.Drawing.Point(36, 59);
            this.lblEquipName.Name = "lblEquipName";
            this.lblEquipName.Size = new System.Drawing.Size(168, 25);
            this.lblEquipName.TabIndex = 120;
            this.lblEquipName.Text = "Equipment Name:";
            // 
            // txtEquipName
            // 
            this.txtEquipName.BackColor = System.Drawing.Color.LightGreen;
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(218, 56);
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.ReadOnly = true;
            this.txtEquipName.Size = new System.Drawing.Size(321, 28);
            this.txtEquipName.TabIndex = 119;
            this.txtEquipName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(497, 543);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(146, 39);
            this.btnUpdate.TabIndex = 127;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(35, 40);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(309, 30);
            this.cbbCategory.TabIndex = 128;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // lbdutyType
            // 
            this.lbdutyType.FormattingEnabled = true;
            this.lbdutyType.ItemHeight = 22;
            this.lbdutyType.Location = new System.Drawing.Point(35, 92);
            this.lbdutyType.Name = "lbdutyType";
            this.lbdutyType.Size = new System.Drawing.Size(309, 378);
            this.lbdutyType.TabIndex = 129;
            this.lbdutyType.SelectedIndexChanged += new System.EventHandler(this.lbdutyType_SelectedIndexChanged);
            // 
            // gbDutyType
            // 
            this.gbDutyType.Controls.Add(this.cbbCategory);
            this.gbDutyType.Controls.Add(this.lbdutyType);
            this.gbDutyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDutyType.Location = new System.Drawing.Point(25, 112);
            this.gbDutyType.Name = "gbDutyType";
            this.gbDutyType.Size = new System.Drawing.Size(377, 478);
            this.gbDutyType.TabIndex = 130;
            this.gbDutyType.TabStop = false;
            this.gbDutyType.Text = "Select Duty Type:";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightBlue;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(10, 32);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(202, 34);
            this.txtPrice.TabIndex = 131;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // gbPrice
            // 
            this.gbPrice.Controls.Add(this.txtPrice);
            this.gbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPrice.Location = new System.Drawing.Point(422, 382);
            this.gbPrice.Name = "gbPrice";
            this.gbPrice.Size = new System.Drawing.Size(219, 88);
            this.gbPrice.TabIndex = 132;
            this.gbPrice.TabStop = false;
            this.gbPrice.Text = "Price ($)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(421, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 66);
            this.label1.TabIndex = 133;
            this.label1.Text = "***Users can select \r\n\'Other\' as the duty type \r\nto define a custom price.";
            // 
            // pbPrice
            // 
            this.pbPrice.Image = ((System.Drawing.Image)(resources.GetObject("pbPrice.Image")));
            this.pbPrice.Location = new System.Drawing.Point(486, 271);
            this.pbPrice.Name = "pbPrice";
            this.pbPrice.Size = new System.Drawing.Size(87, 80);
            this.pbPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrice.TabIndex = 134;
            this.pbPrice.TabStop = false;
            // 
            // Utility_Chemical_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 607);
            this.Controls.Add(this.pbPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbPrice);
            this.Controls.Add(this.gbDutyType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblEquipName);
            this.Controls.Add(this.txtEquipName);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Utility_Chemical_Price";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duty Type Selection";
            this.Load += new System.EventHandler(this.Utility_Chemical_Price_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDutyType.ResumeLayout(false);
            this.gbPrice.ResumeLayout(false);
            this.gbPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblEquipName;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.ListBox lbdutyType;
        private System.Windows.Forms.GroupBox gbDutyType;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.GroupBox gbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbPrice;
    }
}
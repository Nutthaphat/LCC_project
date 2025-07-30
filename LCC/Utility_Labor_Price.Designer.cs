namespace LCC
{
    partial class Utility_Labor_Price
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utility_Labor_Price));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPrice = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.gbDutyType = new System.Windows.Forms.GroupBox();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbnumLabor = new System.Windows.Forms.GroupBox();
            this.txtnumLabor = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbPrice.SuspendLayout();
            this.gbDutyType.SuspendLayout();
            this.gbnumLabor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 28);
            this.menuStrip1.TabIndex = 3;
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
            // gbPrice
            // 
            this.gbPrice.Controls.Add(this.txtPrice);
            this.gbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPrice.Location = new System.Drawing.Point(31, 553);
            this.gbPrice.Name = "gbPrice";
            this.gbPrice.Size = new System.Drawing.Size(247, 88);
            this.gbPrice.TabIndex = 134;
            this.gbPrice.TabStop = false;
            this.gbPrice.Text = "Salary ($)";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightBlue;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(13, 32);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(217, 34);
            this.txtPrice.TabIndex = 131;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // gbDutyType
            // 
            this.gbDutyType.Controls.Add(this.cbbCategory);
            this.gbDutyType.Controls.Add(this.lbType);
            this.gbDutyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDutyType.Location = new System.Drawing.Point(31, 53);
            this.gbDutyType.Name = "gbDutyType";
            this.gbDutyType.Size = new System.Drawing.Size(508, 478);
            this.gbDutyType.TabIndex = 133;
            this.gbDutyType.TabStop = false;
            this.gbDutyType.Text = "Select Labor Cost:";
            this.gbDutyType.Enter += new System.EventHandler(this.gbDutyType_Enter);
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(35, 40);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(435, 30);
            this.cbbCategory.TabIndex = 128;
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.ItemHeight = 22;
            this.lbType.Location = new System.Drawing.Point(35, 92);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(435, 378);
            this.lbType.TabIndex = 129;
            this.lbType.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(376, 672);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(146, 39);
            this.btnUpdate.TabIndex = 135;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gbnumLabor
            // 
            this.gbnumLabor.Controls.Add(this.txtnumLabor);
            this.gbnumLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbnumLabor.Location = new System.Drawing.Point(292, 553);
            this.gbnumLabor.Name = "gbnumLabor";
            this.gbnumLabor.Size = new System.Drawing.Size(247, 88);
            this.gbnumLabor.TabIndex = 135;
            this.gbnumLabor.TabStop = false;
            this.gbnumLabor.Text = "Number of Labors";
            // 
            // txtnumLabor
            // 
            this.txtnumLabor.BackColor = System.Drawing.Color.LightBlue;
            this.txtnumLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumLabor.Location = new System.Drawing.Point(13, 32);
            this.txtnumLabor.Name = "txtnumLabor";
            this.txtnumLabor.Size = new System.Drawing.Size(217, 34);
            this.txtnumLabor.TabIndex = 131;
            this.txtnumLabor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtnumLabor.TextChanged += new System.EventHandler(this.txtnumLabor_TextChanged);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Blue;
            this.lblNote.Location = new System.Drawing.Point(40, 667);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(288, 44);
            this.lblNote.TabIndex = 136;
            this.lblNote.Text = "***User can modify both the salary \r\nand the number of laborers.";
            // 
            // Utility_Labor_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 735);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.gbnumLabor);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbPrice);
            this.Controls.Add(this.gbDutyType);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Utility_Labor_Price";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labor Cost Selection";
            this.Load += new System.EventHandler(this.Utility_Labor_Price_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbPrice.ResumeLayout(false);
            this.gbPrice.PerformLayout();
            this.gbDutyType.ResumeLayout(false);
            this.gbnumLabor.ResumeLayout(false);
            this.gbnumLabor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.GroupBox gbDutyType;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.ListBox lbType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gbnumLabor;
        private System.Windows.Forms.TextBox txtnumLabor;
        private System.Windows.Forms.Label lblNote;
    }
}
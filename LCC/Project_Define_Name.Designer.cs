
namespace LCC
{
    partial class Project_Define_Name
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project_Define_Name));
            this.gbDefine_Project = new System.Windows.Forms.GroupBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectNameTopic = new System.Windows.Forms.Label();
            this.btnEditPJName = new System.Windows.Forms.Button();
            this.btnDefinePJName = new System.Windows.Forms.Button();
            this.pbProject = new System.Windows.Forms.PictureBox();
            this.gbDefine_Project.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProject)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDefine_Project
            // 
            this.gbDefine_Project.BackColor = System.Drawing.Color.Transparent;
            this.gbDefine_Project.Controls.Add(this.txtProjectName);
            this.gbDefine_Project.Controls.Add(this.lblProjectNameTopic);
            this.gbDefine_Project.Controls.Add(this.btnEditPJName);
            this.gbDefine_Project.Controls.Add(this.btnDefinePJName);
            this.gbDefine_Project.Controls.Add(this.pbProject);
            this.gbDefine_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefine_Project.Location = new System.Drawing.Point(53, 26);
            this.gbDefine_Project.Name = "gbDefine_Project";
            this.gbDefine_Project.Size = new System.Drawing.Size(634, 176);
            this.gbDefine_Project.TabIndex = 44;
            this.gbDefine_Project.TabStop = false;
            this.gbDefine_Project.Text = "Please Define Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.Location = new System.Drawing.Point(235, 50);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(384, 28);
            this.txtProjectName.TabIndex = 35;
            // 
            // lblProjectNameTopic
            // 
            this.lblProjectNameTopic.AutoSize = true;
            this.lblProjectNameTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectNameTopic.Location = new System.Drawing.Point(72, 53);
            this.lblProjectNameTopic.Name = "lblProjectNameTopic";
            this.lblProjectNameTopic.Size = new System.Drawing.Size(142, 22);
            this.lblProjectNameTopic.TabIndex = 34;
            this.lblProjectNameTopic.Text = "Project Name: ";
            this.lblProjectNameTopic.Click += new System.EventHandler(this.lblProjectNameTopic_Click);
            // 
            // btnEditPJName
            // 
            this.btnEditPJName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPJName.Location = new System.Drawing.Point(318, 106);
            this.btnEditPJName.Name = "btnEditPJName";
            this.btnEditPJName.Size = new System.Drawing.Size(301, 51);
            this.btnEditPJName.TabIndex = 33;
            this.btnEditPJName.Text = "Edit Project Name";
            this.btnEditPJName.UseVisualStyleBackColor = true;
            this.btnEditPJName.Click += new System.EventHandler(this.btnEditPJName_Click);
            // 
            // btnDefinePJName
            // 
            this.btnDefinePJName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinePJName.Location = new System.Drawing.Point(6, 106);
            this.btnDefinePJName.Name = "btnDefinePJName";
            this.btnDefinePJName.Size = new System.Drawing.Size(301, 51);
            this.btnDefinePJName.TabIndex = 32;
            this.btnDefinePJName.Text = "Save Project Name";
            this.btnDefinePJName.UseVisualStyleBackColor = true;
            this.btnDefinePJName.Click += new System.EventHandler(this.btnDefinePJName_Click);
            // 
            // pbProject
            // 
            this.pbProject.Image = ((System.Drawing.Image)(resources.GetObject("pbProject.Image")));
            this.pbProject.Location = new System.Drawing.Point(16, 45);
            this.pbProject.Name = "pbProject";
            this.pbProject.Size = new System.Drawing.Size(50, 41);
            this.pbProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProject.TabIndex = 25;
            this.pbProject.TabStop = false;
            // 
            // Project_Define_Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(741, 235);
            this.Controls.Add(this.gbDefine_Project);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Project_Define_Name";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Project Name";
            this.Load += new System.EventHandler(this.Project_Define_Name_Load);
            this.gbDefine_Project.ResumeLayout(false);
            this.gbDefine_Project.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDefine_Project;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectNameTopic;
        private System.Windows.Forms.Button btnEditPJName;
        private System.Windows.Forms.Button btnDefinePJName;
        private System.Windows.Forms.PictureBox pbProject;
    }
}
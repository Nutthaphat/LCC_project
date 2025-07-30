
namespace LCC
{
    partial class ChartMonth
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartMonth));
            this.MonthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MonthChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MonthChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MonthChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MonthChart.Legends.Add(legend1);
            this.MonthChart.Location = new System.Drawing.Point(14, 12);
            this.MonthChart.Name = "MonthChart";
            this.MonthChart.Size = new System.Drawing.Size(833, 592);
            this.MonthChart.TabIndex = 77;
            this.MonthChart.Text = "chart1";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Location = new System.Drawing.Point(680, 552);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(146, 39);
            this.btnSaveImage.TabIndex = 78;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // ChartMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 616);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.MonthChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartMonth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1st year chart (month)";
            this.Load += new System.EventHandler(this.ChartMonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonthChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MonthChart;
        private System.Windows.Forms.Button btnSaveImage;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace LCC
{
    public partial class ChartMonth : Form
    {
        public List<double> xPointmain = new List<double>();
        public List<double> yPointmain = new List<double>();
        
        double minY = 0;
        double maxY = 0;
        public ChartMonth(double MinMonth, double MaxMonth, List<double> xPoint, List<double> yPoint)
        {
            InitializeComponent();
            xPointmain.Clear();
            yPointmain.Clear();           
            minY = MinMonth;
            maxY = MaxMonth;
            xPointmain.AddRange(xPoint);
            yPointmain.AddRange(yPoint);           
        }

        private void ChartMonth_Load(object sender, EventArgs e)
        {
            MonthChart.ChartAreas["ChartArea1"].AxisY.Title = "Cumulative Cash Flow ($)";
            MonthChart.ChartAreas["ChartArea1"].AxisX.Title = "Project Life Time in the 1st year (month)";
            MonthChart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            MonthChart.ChartAreas["ChartArea1"].AxisX.Maximum = 12;

            double YearColumn, CumCashFlow;
            double minY_Axis, maxY_Axis;           
            minY_Axis = minY;
            maxY_Axis = maxY;
            int minYstr = Math.Abs(Math.Round(minY_Axis, 0)).ToString().Length - 1;
            int maxYstr = Math.Abs(Math.Round(maxY_Axis, 0)).ToString().Length - 1;
            string rangeMinY = "1";
            for (int i = 0; i < minYstr; i++)
            {
                rangeMinY += "0";
            }
            string rangeMaxY = "1";
            for (int i = 0; i < maxYstr; i++)
            {
                rangeMaxY += "0";
            }
            double conMin = Convert.ToDouble(rangeMinY);
            double conMax = Convert.ToDouble(rangeMaxY);
            double Acc_min, Acc_max;
            Acc_min = Math.Ceiling(minY_Axis / conMin) * conMin;
            Acc_max = Math.Ceiling(maxY_Axis / conMax) * conMax;
            //Clear Series in Chart
            MonthChart.Series.Clear();
            Series newSeries = MonthChart.Series.Add("Zero baseline");
            newSeries.ChartType = SeriesChartType.Line;
            Series newSeries2 = MonthChart.Series.Add("CumCashFlow");
            newSeries2.ChartType = SeriesChartType.Line;
            MonthChart.ChartAreas["ChartArea1"].AxisY.Minimum = Acc_min - conMin;
            MonthChart.ChartAreas["ChartArea1"].AxisY.Maximum = Acc_max;
            MonthChart.ChartAreas["ChartArea1"].AxisY.Interval = conMax;
            for (int i = 0; i < 13; i++)
            {
                YearColumn = xPointmain[i];
                CumCashFlow = yPointmain[i];
                MonthChart.Series[0].Points.AddXY(i, 0);
                MonthChart.Series[1].Points.AddXY(YearColumn, CumCashFlow);
            }

            MonthChart.Series[0].BorderWidth = 2;
            MonthChart.Series[1].BorderWidth = 2;
            MonthChart.Series[1].ToolTip = "#VALX,#VALY";
            MonthChart.Series[1].IsValueShownAsLabel = true;
            MonthChart.Series[1].MarkerStyle = MarkerStyle.Circle;

            Axis yAxis = MonthChart.ChartAreas[0].AxisY;
            yAxis.LabelStyle.Format = "#,0";           
            Legend legend = MonthChart.Legends[0]; // Assuming one legend
            legend.Docking = Docking.Bottom; // Adjust docking as needed (Top, Right, Left)
            
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.png)|*.png";
            saveFileDialog.FileName = "Cumulative Cash Flow Plot of the first year";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MonthChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
            }
            MessageBox.Show("The Cumulative Cash Flow of the first year has been successfully exported to a PNG image.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

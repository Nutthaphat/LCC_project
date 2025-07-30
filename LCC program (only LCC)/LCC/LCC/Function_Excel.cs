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
    class Function_Excel
    {
        public static void PageSetUp(Excel._Worksheet worksheet, string worksheetName)
        {
            worksheet.Name = worksheetName;
            worksheet.PageSetup.RightHeader = "&\"Calibri\"&11&K000000PSE for SPEED Company Limited Email: service@pseforspeed.com";
            worksheet.PageSetup.LeftHeader = "&\"Calibri\"&11&K000000Report XX-2024";
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
        }
        public static void ColumnWidth(Excel._Worksheet worksheet, int Num)
        {
            for (int i = 1; i <= Num; i++)
            {
                worksheet.Columns[i].ColumnWidth = 33;
            }
        }
        public static void BoldAlignRow(Excel._Worksheet worksheet)
        {
            worksheet.Cells[1, 1].Font.Bold = true; //Bold Header 
            worksheet.Rows[1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            worksheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        }
        public static void AddDataToExcel(Excel._Worksheet worksheet, DataGridView dgv, int countRow, int RowExcel, string Topic)
        {
            worksheet.Cells[RowExcel, 1] = Topic;
            worksheet.Cells[RowExcel, 1].Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F8CBAD"); //Add Cell Color Topic 
            worksheet.Cells[RowExcel, 1].Font.Bold = true; //Bold words
            //Header Table
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                worksheet.Cells[RowExcel + 1, i] = dgv.Columns[i - 1].HeaderText;               
                worksheet.Cells[RowExcel + 1, i].Font.Bold = true; //Bold Header                  
                worksheet.Cells[RowExcel + 1, i].Interior.Color = System.Drawing.ColorTranslator.FromHtml("#87CB3D"); //Add Cell Color header
            }
            //Data in Table
            for (int i = 0; i < dgv.Rows.Count - countRow; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + RowExcel + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + RowExcel + 2, j + 1] = "";
                    }                   
                }
            }
            //Adjust Cell Alignment and Add boarder
            for (int i = 0; i < dgv.Rows.Count + 1 - countRow; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    worksheet.Cells[i + RowExcel + 1, j + 1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[i + RowExcel + 1, j + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[i + RowExcel + 1, j + 1].Borders.Color = System.Drawing.Color.Black.ToArgb();
                }
            }          
        }
        public void CreateExcel(string PJName, DataGridView MainPC, DataGridView SidePC, DataGridView SalvageValue, DataGridView Maintenance, string str1, DataGridView Feedstock, DataGridView OPC1, DataGridView OPC2, DataGridView OPC3, DataGridView OPC4, DataGridView CapCost, DataGridView CapCost_FCI, DataGridView CapCost_WCI, DataGridView SummaryLCC)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (.xlsx)|  *.xlsx";
            sfd.FileName = "LCC report.xlsx";
            bool fileError = false;
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Excel.Application xcelApp = new Excel.Application();
                            Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                            Excel._Worksheet worksheet1 = null;
                            Excel._Worksheet worksheet2 = null;
                            Excel._Worksheet worksheet3 = null;
                            Excel._Worksheet worksheet4 = null;
                            Excel._Worksheet worksheet5 = null;
                            Excel._Worksheet worksheet6 = null;
                            Excel._Worksheet worksheet7 = null;

                            //Worksheet 1
                            worksheet1 = workbook.Sheets["Sheet1"];
                            worksheet1 = workbook.ActiveSheet;
                            PageSetUp(worksheet1, "Product Credit");
                            worksheet1.Cells[1, 1] = "Product Credit";
                            AddDataToExcel(worksheet1, MainPC, 1, 3, "Main product credit");
                            AddDataToExcel(worksheet1, SidePC, 1, 3 + 2 + MainPC.RowCount, "Side product credit");
                            ColumnWidth(worksheet1, MainPC.ColumnCount);
                            BoldAlignRow(worksheet1);
                            //---------------------------------------------------
                            //Worksheet 2
                            worksheet2 = workbook.Sheets.Add();
                            worksheet2 = workbook.Sheets["Sheet2"];
                            worksheet2 = workbook.ActiveSheet;
                            PageSetUp(worksheet2, "Salvage Value");
                            worksheet2.Cells[1, 1] = "Salvage Value";
                            AddDataToExcel(worksheet2, SalvageValue, 1, 3, "Salvage value for equipment");
                            ColumnWidth(worksheet2, SalvageValue.ColumnCount);
                            BoldAlignRow(worksheet2);
                            //---------------------------------------------------                           
                            //Worksheet 3
                            worksheet3 = workbook.Sheets.Add();
                            worksheet3 = workbook.Sheets["Sheet3"];
                            worksheet3 = workbook.ActiveSheet;
                            PageSetUp(worksheet3, "Maintenance Cost");
                            worksheet3.Cells[1, 1] = "Maintenance Cost";
                            if (Maintenance.RowCount == 1)
                            {
                                AddDataToExcel(worksheet3, Maintenance, 0, 3, "Percentage of initial capital cost");
                                worksheet3.Cells[5, 1] = "1";
                                worksheet3.Cells[5, 2] = "Cost from % of initial capital cost";
                                worksheet3.Cells[5, 3] = str1;
                            }
                            else
                            {
                                AddDataToExcel(worksheet3, Maintenance, 1, 3, "Specific maintenance cost");
                            }                          
                            ColumnWidth(worksheet3, Maintenance.ColumnCount);
                            BoldAlignRow(worksheet3);
                            //---------------------------------------------------
                            //Worksheet 4
                            worksheet4 = workbook.Sheets.Add();
                            worksheet4 = workbook.Sheets["Sheet4"];
                            worksheet4 = workbook.ActiveSheet;
                            PageSetUp(worksheet4, "Feedstock Cost");
                            worksheet4.Cells[1, 1] = "Feedstock Cost";
                            AddDataToExcel(worksheet4, Feedstock, 1, 3, "Raw material stage");
                            ColumnWidth(worksheet4, Feedstock.ColumnCount);
                            BoldAlignRow(worksheet4);
                            //---------------------------------------------------
                            //Worksheet 5
                            worksheet5 = workbook.Sheets.Add();
                            worksheet5 = workbook.Sheets["Sheet5"];
                            worksheet5 = workbook.ActiveSheet;
                            PageSetUp(worksheet5, "Operating Cost");
                            worksheet5.Cells[1, 1] = "Operating Cost";
                            AddDataToExcel(worksheet5, OPC1, 1, 3, "Operating cost for stream");
                            AddDataToExcel(worksheet5, OPC2, 1, 3 + 2 + OPC1.RowCount, "Operating cost for utility");
                            AddDataToExcel(worksheet5, OPC3, 1, 3 + 4 + OPC1.RowCount + OPC2.RowCount, "Operating cost for labor (per hour)");
                            AddDataToExcel(worksheet5, OPC4, 1, 3 + 6 + OPC1.RowCount + OPC2.RowCount + OPC3.RowCount, "Operating cost for labor (per month)");
                            ColumnWidth(worksheet5, OPC2.ColumnCount);
                            BoldAlignRow(worksheet5);
                            //---------------------------------------------------
                            //Worksheet 6
                            worksheet6 = workbook.Sheets.Add();
                            worksheet6 = workbook.Sheets["Sheet6"];
                            worksheet6 = workbook.ActiveSheet;
                            PageSetUp(worksheet6, "Capital Cost");
                            worksheet6.Cells[1, 1] = "Capital Cost";                           
                            AddDataToExcel(worksheet6, CapCost, 1, 3, "Purchase equipment cost");
                            AddDataToExcel(worksheet6, CapCost_FCI, 1, 3 + 2 + CapCost.RowCount, "Fixed capital investment");
                            AddDataToExcel(worksheet6, CapCost_WCI, 1, 3 + 4 + CapCost.RowCount + CapCost_FCI.RowCount, "Working capital investment");
                            ColumnWidth(worksheet6, CapCost.ColumnCount);
                            BoldAlignRow(worksheet6);
                            //---------------------------------------------------
                            //Worksheet 7
                            worksheet7 = workbook.Sheets.Add();
                            worksheet7 = workbook.Sheets["Sheet7"];
                            worksheet7 = workbook.ActiveSheet;
                            PageSetUp(worksheet7, "LCC Summary");
                            worksheet7.Cells[1, 1] = "Project Name:";
                            worksheet7.Cells[1, 2] = PJName;                                                   
                            AddDataToExcel(worksheet7, SummaryLCC, 0, 3, "Summary of life cycle cost (LCC)");
                            ColumnWidth(worksheet7, SummaryLCC.ColumnCount);
                            BoldAlignRow(worksheet7);
                            //---------------------------------------------------                          
                            workbook.SaveAs(sfd.FileName);
                            workbook.Close(true);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                            xcelApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet1);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet2);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet3);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet4);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet5);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet6);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet7);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xcelApp);
                            MessageBox.Show("You have successfully exported your data to an excel file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateEconExcel(DataGridView EconEval)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (.xlsx)|  *.xlsx";
            sfd.FileName = "Economic evaluation report.xlsx";
            bool fileError = false;
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Excel.Application xcelApp = new Excel.Application();
                            Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                            Excel._Worksheet worksheet1 = null;                          

                            //Worksheet 1
                            worksheet1 = workbook.Sheets["Sheet1"];
                            worksheet1 = workbook.ActiveSheet;
                            PageSetUp(worksheet1, "Economic Evaluation");
                            worksheet1.Cells[1, 1] = "Economic Evaluation";
                            AddDataToExcel(worksheet1, EconEval, 0, 3, "Economic Summary");                            
                            ColumnWidth(worksheet1, EconEval.ColumnCount);
                            BoldAlignRow(worksheet1);
                                                       
                            //---------------------------------------------------                          
                            workbook.SaveAs(sfd.FileName);
                            workbook.Close(true);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                            xcelApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet1);                           
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xcelApp);
                            MessageBox.Show("You have successfully exported your data to an excel file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace LCC
{
    class Function
    {
        public string SearchExcelfile()
        {
            //Open Selected Excel
            OpenFileDialog Openfile = new OpenFileDialog();
            Openfile.RestoreDirectory = true;
            Openfile.Filter = "Excel Files (*.xlsx*)|*.xlsx|Excel Files (*.xls*)|*.xls|Excel Files (*.xlsm*)|*.xlsm";
            Openfile.FilterIndex = 1;
            Openfile.RestoreDirectory = true;
            string strfilename = "";
            if (Openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strfilename = Openfile.FileName;

            }
            return strfilename;
        }
        
        public void GetCellData(List<string> dataList, string filePath, string sheetName, string range)
        {

            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];

                // Get the range of cells
                Range xlRange = xlWorksheet.Range[range];

                // Loop through each cell in the range
                foreach (Range cell in xlRange.Cells)            
                {
                    // Add cell value to the list (check for null values)
                    if (cell.Value != null)
                    {
                        dataList.Add(cell.Value.ToString());
                        //cellList.Add(cell.ToString());
                    }                  

                }

                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }           
        }
        public void ReadCellData(List<string> dataList, List<string> dataList_Val, List<string> outputList, string filePath, string sheetName)
        {           
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                outputList.Add(xlWorksheet.Cells[3, 12].Value.ToString());
                outputList.Add(xlWorksheet.Cells[6, 12].Value.ToString());
                string line = "";
                int range = 50;
                //Read and collect the specific cell
                for (int i = 7; i <= range; i++)
                {
                    if (xlWorksheet.Cells[i, 4].Value.ToString() != null)
                    {
                        //Check the word "Transport" or "Dummy"
                        line = xlWorksheet.Cells[i, 6].Value.ToString();
                        Match m = Regex.Match(line, "Transport");
                        if (m.Success)
                        {
                            continue;
                        }
                        else
                        {
                            dataList.Add(xlWorksheet.Cells[i, 6].Value.ToString());
                            dataList_Val.Add(xlWorksheet.Cells[i, 12].Value.ToString());
                            /*Match k = Regex.Match(line, "Dummy");
                            if (k.Success)
                            {
                                continue;
                            }
                            else
                            {
                                dataList.Add(xlWorksheet.Cells[i, 6].Value.ToString());
                                dataList_Val.Add(xlWorksheet.Cells[i, 12].Value.ToString());
                            }   */
                        }                        
                    }
                    else
                    {
                        continue;
                    }
                }               

                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }
        public void ReadCellData_withTransport(List<string> dataList, List<string> dataList_Val, List<string> outputList, string filePath, string sheetName)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                outputList.Add(xlWorksheet.Cells[3, 12].Value.ToString());
                outputList.Add(xlWorksheet.Cells[6, 12].Value.ToString());
                string line = "";
                int range = 50;
                //Read and collect the specific cell
                for (int i = 7; i <= range; i++)
                {
                    if (xlWorksheet.Cells[i, 4].Value.ToString() != null)
                    {
                        //Check the word "Transport" or "Dummy"
                        line = xlWorksheet.Cells[i, 6].Value.ToString();
                        dataList.Add(xlWorksheet.Cells[i, 6].Value.ToString());
                        dataList_Val.Add(xlWorksheet.Cells[i, 12].Value.ToString());
                    }
                    else
                    {
                        continue;
                    }
                }

                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }
        public void ReadExcelStreamData(DataGridView NewTable, string filePath, string sheetName)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                Excel.Range usedRange = xlWorksheet.UsedRange;

                // Clear existing DataGridView data (if any)
                NewTable.Rows.Clear();
                NewTable.Columns.Clear();
                // Define number of Row and Column
                NewTable.ColumnCount = usedRange.Columns.Count - 2;
                NewTable.RowCount = usedRange.Rows.Count - 7;
                // Add columns based on the first row of data (modify as needed)
                for (int col = 1; col < usedRange.Columns.Count - 1; col++)
                {
                   
                    NewTable.Columns[col - 1].HeaderText = xlWorksheet.Cells[1, col].Value.ToString();
                                   
                }
                NewTable.Rows[0].Cells[0].Value = "Total Weight Comp. Rates";
                NewTable.Rows[0].Cells[1].Value = "kg/hr";
                // Loop through used range and populate DataGridView
                for (int row = 8; row < usedRange.Rows.Count; row++)
                {                  
                    
                    for (int col = 1; col < usedRange.Columns.Count - 1; col++)
                    {
                        NewTable.Rows[row - 7].Cells[col - 1].Value = xlWorksheet.Cells[row, col].Value.ToString();                     
                    }
                    
                }

                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }
        public void SelectFromEqipmentTable (DataGridView OriginalTable, string CheckWord, int num, List<string> colName, List<string> colVal, List<string> colUnit)
        {
            colName.Clear();
            colVal.Clear();
            colUnit.Clear();
            for (int i = 0; i < OriginalTable.Rows.Count; i++)
            {
                if (OriginalTable.Rows[i].Cells[0].Value != null && OriginalTable.Rows[i].Cells[0].Value.ToString() == CheckWord)
                {
                   for (int j = 0; j < OriginalTable.Columns.Count; j++)
                   {
                        if (OriginalTable.Rows[i].Cells[j].Value != null && OriginalTable.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            colName.Add(OriginalTable.Rows[i].Cells[j].Value.ToString());
                            colVal.Add(OriginalTable.Rows[i + num].Cells[j].Value.ToString());
                        }
                   }
                    colUnit.Add(OriginalTable.Rows[i + num].Cells[1].Value.ToString());
                }
                else
                {
                    continue;
                }
            }
        }
        public void CollectEquipDetail (DataGridView dgv, string CheckWord, List<string> colName, List<string> colVal, List<string> colUnit, List<string> DutyCat)
        {            
            colName.Clear();
            colVal.Clear();
            colUnit.Clear();

            colName.Add("");
            colVal.Add("");
            colUnit.Add("");
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[0].Value.ToString().Trim() == CheckWord)
                {
                    //Collect ColNam and ColUnit
                    colName.Add(dgv.Rows[i].Cells[1].Value.ToString().Trim());
                    colUnit.Add(dgv.Rows[i].Cells[3].Value.ToString().Trim());
                    if (dgv.Rows[i].Cells[5].Value.ToString() != "")
                    {
                        colVal.Add(dgv.Rows[i].Cells[5].Value.ToString().Trim());
                        DutyCat.Add("Heating Duty");
                    }
                    else
                    {
                        if (dgv.Rows[i].Cells[6].Value.ToString() != "")
                        {
                            colVal.Add("-" + dgv.Rows[i].Cells[6].Value.ToString().Trim());
                            DutyCat.Add("Cooling Duty");
                        }
                        else
                        {
                            colVal.Add(dgv.Rows[i].Cells[7].Value.ToString().Trim());
                            DutyCat.Add("Electricity Duty");
                        }
                    }
                }
            }
        }
        
        public void AddDataToTable(DataGridView DataTable, string FixedWord, List<string> ListName, List<string> ListVal, List<string> ListUnit)
        {
            if (ListName.Count != 0)
            {
                for (int i = 1; i < ListName.Count; i++)
                {
                    DataTable.Rows.Add(ListName[i].ToString(), FixedWord, ListVal[i].ToString(), ListUnit[0].ToString(), "");
                }
            }           
        }
        public void AddDataToTable2(DataGridView DataTable, string FixedWord, List<string> ListName, List<string> ListVal, List<string> ListUnit)
        {
            if (ListName.Count != 0)
            {
                for (int i = 1; i < ListName.Count; i++)
                {
                    DataTable.Rows.Add(ListName[i].ToString(), FixedWord, ListVal[i].ToString(), ListUnit[i].ToString(), "");
                }
            }
        }
        public void AddColumnFixed2Word (DataGridView DataTable, string FixedWord, string FixedWord2, List<string> ListName, List<string> ListVal, List<string> ListUnit)
        {
            if (ListName.Count != 0)
            {
                for (int i = 1; i < ListName.Count; i++)
                {
                    if (ListVal[i].Contains("-"))
                    {
                        DataTable.Rows.Add(ListName[i].ToString(), FixedWord2, ListVal[i].ToString(), ListUnit[i].ToString(), "");
                    }
                    else
                    {
                        DataTable.Rows.Add(ListName[i].ToString(), FixedWord, ListVal[i].ToString(), ListUnit[i].ToString(), "");
                    }
                    
                }
            }
        }
        
        public void AddColumnToTable(DataGridView DataTable, string FixedWord, string FixedWord2, List<string> ListName, List<string> ListVal, List<string> ListUnit, List<string> List2Name, List<string> List2Val, List<string> List2Unit)
        {
            if (ListName.Count != 0)
            {
                for (int i = 1; i < ListName.Count; i++)
                {
                    DataTable.Rows.Add(ListName[i].ToString(), FixedWord, ListVal[i].ToString(), ListUnit[0].ToString(), "");
                    DataTable.Rows.Add(List2Name[i].ToString(), FixedWord2, List2Val[i].ToString(), List2Unit[0].ToString(), "");
                }
            }
        }
        public void ReadExcelEqipmentData(DataGridView NewTable, string filePath, string sheetName)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                Excel.Range usedRange = xlWorksheet.UsedRange;

                // Clear existing DataGridView data (if any)
                NewTable.Rows.Clear();
                NewTable.Columns.Clear();
                // Define number of Row and Column                
                NewTable.ColumnCount = usedRange.Columns.Count - 2;
                NewTable.RowCount = usedRange.Rows.Count - 2;
                // Add columns based on the first row of data (modify as needed)
                for (int col = 1; col < usedRange.Columns.Count - 1; col++)
                {
                    if (xlWorksheet.Cells[1, col].Value == null)
                    {
                        NewTable.Columns[col - 1].HeaderText = "";
                    }
                    else
                    {
                        NewTable.Columns[col - 1].HeaderText = xlWorksheet.Cells[1, col].Value.ToString();
                    }                                     
                }
                
                // Loop through used range and populate DataGridView
                for (int row = 3; row < usedRange.Rows.Count; row++)
                {

                    for (int col = 1; col < usedRange.Columns.Count - 1; col++)
                    {
                        if (xlWorksheet.Cells[row, col].Value == null)
                        {
                            continue;
                        }
                        else
                        {
                            NewTable.Rows[row - 3].Cells[col - 1].Value = xlWorksheet.Cells[row, col].Value.ToString();
                        }                       
                    }
                }

                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }
        public bool CheckAmount (string Amount_text)
        {
            try
            {
                double result = Convert.ToDouble(Amount_text);
                return true;
            }
            catch
            {
                return false;
            }                   
        }
        public bool CheckExcel_ImportFile (string filePath, string sheetName, string checkword)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();
            // Open workbook
            Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);
            try
            {
                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];

                if (xlWorksheet.Cells[1, 1].Value.ToString() == checkword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
            
        }
        public void ReadStreamTable(List<string> StreamNameList, string filePath, string sheetName, int range)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];                                              
                if (xlWorksheet.Cells[1, 1].Value.ToString() == "Stream Name")
                {                                
                    //Collect Stream name to be header of datagridview
                    StreamNameList.Add(xlWorksheet.Cells[1, 1].Value.ToString());
                    StreamNameList.Add("");
                    for (int i = 3; i <= range; i++)
                    {
                        if (xlWorksheet.Cells[1, i].Value.ToString() != "")
                        {
                            StreamNameList.Add(xlWorksheet.Cells[1, i].Value.ToString());
                        }
                        else
                        {
                            break;
                        }
                    }                  
                }              
                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }
        public void CollectDataToList (List<string> dataList, List<string> dataList2,  DataGridView dataTable)
        {           
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataList.Add(dataTable.Columns[i].HeaderText); 
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataList2.Add(dataTable.Rows[i].Cells[0].Value.ToString());              
            }
        }       
        public void ReadStreamComponent(List<string> ComponentList, string filePath, string sheetName, int range)
        {
            // Start Excel application
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Open workbook
                Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, Type.Missing, true);

                // Get worksheet
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                //Collect component name
                ComponentList.Add("List of component (kg)");
                for (int i = 0; i < range; i++)
                {
                    if (xlWorksheet.Cells[i + 8, 1].Value.ToString() != "")
                    {
                        ComponentList.Add(xlWorksheet.Cells[i + 8, 1].Value.ToString());
                    }
                    else
                    {
                        break;
                    }
                }
                // Close and release Excel objects
                xlWorkbook.Close(true);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure proper release of COM objects
                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
        }       
        public void HeaderTable(DataGridView dgvSelect, string[] ListName)
        {
            //Add Column Name
            dgvSelect.ColumnCount = ListName.Length;
            for (int i = 0; i < ListName.Length; i++)
            {
                dgvSelect.Columns[i].HeaderText = ListName[i];              
            }           
            dgvSelect.AutoResizeColumns();
            dgvSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSelect.ColumnHeadersDefaultCellStyle = style;
        }        
        public void HeaderTable2(DataGridView dgvSelect, string[] ListName)
        {
            //Add Column Name
            dgvSelect.ColumnCount = ListName.Length;
            for (int i = 0; i < ListName.Length; i++)
            {
                dgvSelect.Columns[i].HeaderText = ListName[i];
            }            
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSelect.ColumnHeadersDefaultCellStyle = style;
        }
        public void HeaderTableFromList(DataGridView dgvSelect, List<string> ListName)
        {
            //Add Column Name
            dgvSelect.ColumnCount = ListName.Count;
            for (int i = 0; i < ListName.Count; i++)
            {
                dgvSelect.Columns[i].HeaderText = ListName[i];
            }
            dgvSelect.AutoResizeColumns();
            dgvSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSelect.ColumnHeadersDefaultCellStyle = style;
        }
        public double Cal_InterestRate(string interestRate, string period)
        {
            double CalResult, Rate, Numyear;
            if (interestRate != "")
            {
                Rate = Convert.ToDouble(interestRate) / 100;
            }
            else
            {
                Rate = 0;
            }
            if (period != "")
            {
                Numyear = Convert.ToDouble(period);
            }
            else
            {
                Numyear = 0;
            }          
            CalResult = Math.Pow((1 + Rate), Numyear);
            return CalResult;
        }
        public double Cal_AnnualToPresent(string interestRate, string period)
        {
            double CalResult, Rate, Numyear;
            if (interestRate != "")
            {
                Rate = Convert.ToDouble(interestRate) / 100;
            }
            else
            {
                Rate = 0;
            }
            if (period != "")
            {
                Numyear = Convert.ToDouble(period);
            }
            else
            {
                Numyear = 0;
            }
            CalResult = (Math.Pow((1 + Rate), Numyear) * Rate) / ((Math.Pow((1 + Rate), Numyear) - 1));
            return CalResult;
        }
        public void checkNumberTB (System.Windows.Forms.TextBox tb,string message, string titleMessage)
        {
            tb.BackColor = Color.LightBlue;
            try
            {
                if (tb.Text != "")
                {
                    double num = Convert.ToDouble(tb.Text);
                    tb.BackColor = Color.LightGreen;
                }
            }
            catch
            {
                tb.BackColor = Color.Red;
                MessageBox.Show(message, titleMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void tbNullVal (System.Windows.Forms.TextBox tb)
        {
            tb.Text = "";
            tb.BackColor = Color.LightBlue;
        }
        public string Select4Material(string[] Material, RadioButton rb1, RadioButton rb2, RadioButton rb3, RadioButton rb4)
        {           
            string materialName = "";
            if (rb1.Checked == true)
            {
                materialName = Material[0];
            }
            else if (rb2.Checked == true)
            {
                materialName = Material[1];
            }
            else if (rb3.Checked == true)
            {
                materialName = Material[2];
            }
            else if (rb4.Checked == true)
            {
                materialName = Material[3];
            }

            return materialName;
        }
        public string Select2Material(string[] Material, RadioButton rb1, RadioButton rb2)
        {
            string materialName = "";
            if (rb1.Checked == true)
            {
                materialName = Material[0];
            }
            else if (rb2.Checked == true)
            {
                materialName = Material[1];
            }            

            return materialName;
        }
        public string Select3Material(string[] Material, RadioButton rb1, RadioButton rb2, RadioButton rb3)
        {            
            string materialName = "";
            if (rb1.Checked == true)
            {
                materialName = Material[0];
            }
            else if (rb2.Checked == true)
            {
                materialName = Material[1];
            }
            else if (rb3.Checked == true)
            {
                materialName = Material[2];
            }

            return materialName;
        }
        public string Select5Material(string[] Material, RadioButton rb1, RadioButton rb2, RadioButton rb3, RadioButton rb4, RadioButton rb5)
        {
            string materialName = "";
            if (rb1.Checked == true)
            {
                materialName = Material[0];
            }
            else if (rb2.Checked == true)
            {
                materialName = Material[1];
            }
            else if (rb3.Checked == true)
            {
                materialName = Material[2];
            }
            else if (rb4.Checked == true)
            {
                materialName = Material[3];
            }
            else if (rb5.Checked == true)
            {
                materialName = Material[4];
            }           

            return materialName;
        }
        public string Select6Material(string[] Material, RadioButton rb1, RadioButton rb2, RadioButton rb3, RadioButton rb4, RadioButton rb5, RadioButton rb6)
        {            
            string materialName = "";
            if (rb1.Checked == true)
            {
                materialName = Material[0];
            }
            else if (rb2.Checked == true)
            {
                materialName = Material[1];
            }
            else if (rb3.Checked == true)
            {
                materialName = Material[2];
            }
            else if (rb4.Checked == true)
            {
                materialName = Material[3];
            }
            else if (rb5.Checked == true)
            {
                materialName = Material[4];
            }
            else if (rb6.Checked == true)
            {
                materialName = Material[5];
            }

            return materialName;
        }
        public void ColorTBValue (System.Windows.Forms.TextBox tb)
        {
            if (tb.Text != "")
            {
                tb.BackColor = Color.LightGreen;
            }
            else
            {
                tb.BackColor = Color.LightBlue;
            }
        }
        public void ColorTBValue_expense(System.Windows.Forms.TextBox tb)
        {
            if (tb.Text != "")
            {
                tb.BackColor = Color.LightYellow;
            }
            else
            {
                tb.BackColor = Color.LightBlue;
            }
        }
        public void AutosizeDGV (DataGridView dgvSelect)
        {
            dgvSelect.AutoResizeColumns();
            dgvSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void AutosizeDGV_AllCells(DataGridView dgvSelect)
        {
            dgvSelect.AutoResizeColumns();
            dgvSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void ClearDGVList(DataGridView[] dgv)
        {
            for (int i = 0; i < dgv.Length; i++)
            {
                dgv[i].Rows.Clear();
                dgv[i].Columns.Clear();
            }
        }
        public bool StausTotalCost (System.Windows.Forms.TextBox tb)
        {
            bool status = false;
            if (tb.BackColor == Color.LightGreen)
            {
                status = true;
            }           
            return status;
        }
        public bool StatusTB (System.Windows.Forms.TextBox[] tb, string[] comment)
        {
            bool status = true;
            for (int i = 0; i < tb.Length; i++)
            {
                if (tb[i].BackColor != Color.LightGreen)
                {
                    MessageBox.Show("Missing " + comment[i] + " value.\n\nPlease ensure to fill the value before processing next step.", "Warning missing value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    status = false;
                    break;
                }                
            }
            return status;
        }
        public void StatusTBValue (System.Windows.Forms.TextBox tb, string comment)
        {
            tb.BackColor = Color.LightBlue;
            double TestNum;
            try
            {
                if (tb.Text != "")
                {
                    TestNum = Convert.ToInt32(tb.Text);
                    tb.BackColor = Color.LightGreen;
                }
            }
            catch
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("The value of " + comment + " must be integer.", "Warning missing value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void StatusTBValue_Double(System.Windows.Forms.TextBox tb, string comment)
        {
            tb.BackColor = Color.LightBlue;
            double TestNum;
            try
            {
                if (tb.Text != "")
                {
                    TestNum = Convert.ToDouble(tb.Text);
                    tb.BackColor = Color.LightGreen;
                }
            }
            catch
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("The value of " + comment + " must be number.", "Warning missing value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool statusDGV (DataGridView dgv, TabControl tc, string comment)
        {
            bool status = false;
            if (dgv.RowCount != 0)
            {
                status = true;
            }
            else
            {
                MessageBox.Show("Please click " + comment + " button at the main page before proceeding this step.", "Warning missing step information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tc.SelectedIndex = 0;
            }
            return status;
        }
        public void tbNullValue (System.Windows.Forms.TextBox tb)
        {
            tb.Text = "";
            tb.BackColor = Color.LightBlue;
        }       
        public void checkAndaddDataToText (string word, System.Windows.Forms.TextBox tb)
        {
            if (word != "" && word != "No")
            {
                tb.Text = word;
                tb.BackColor = Color.LightGreen;
            }
            else
            {
                tb.Text = word;
                tb.BackColor = Color.LightBlue;
            }
        }
        public void DataToCenterStyle (DataGridView dgv)
        {
            if (dgv.ColumnCount > 1)
            {
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }           
        }
        public void CellColorWithCond (DataGridView dgv, int ColIndex, string word)
        {
            if (dgv.ColumnCount != 0)
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    string wordCond = dgv.Rows[i].Cells[ColIndex].Value.ToString();
                    if (wordCond != word)
                    {
                        dgv.Rows[i].Cells[ColIndex].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dgv.Rows[i].Cells[ColIndex].Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }
    }
}


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
using System.Xml.Linq;
using System.Collections;
using static System.Windows.Forms.LinkLabel;

namespace LCC
{
    class Function_SaveOpen
    {
        string strDirectory = System.Windows.Forms.Application.StartupPath + "\\";
        public string GetLocationSaveFile (string title)
        {
            string filePath = "";
            // Create an instance of SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set properties for the dialog
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Filter for file types
            saveFileDialog.Title = title; // Title of the dialog box
            saveFileDialog.FileName = title + ".txt"; // Default filename
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // Initial directory
            // Show the dialog and check if the user clicked OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }                
            return filePath;
        }
        public void SaveData2Tables_ArrayVal(DataGridView dgv1, DataGridView dgv2, string filePath, string filePath2, string[] ArrayVal)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write Array value parameter
                    for (int i = 0; i < ArrayVal.Length; i++)
                    {
                        string data = ArrayVal[i];
                        if (data == "")
                        {
                            data = "No";
                        }
                        writer.WriteLine(data);
                    }

                    // Write header row for Datagridview 1
                    if (dgv1.Columns.Count > 0)
                    {
                        for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv1.Columns[col].HeaderText + "|");
                        }
                        writer.WriteLine(dgv1.Columns[dgv1.Columns.Count - 1].HeaderText);

                        // Write data rows for Datagridview 1
                        for (int row = 0; row < dgv1.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                            {
                                writer.Write(dgv1.Rows[row].Cells[col].Value + "|");
                            }
                            writer.WriteLine(dgv1.Rows[row].Cells[dgv1.Columns.Count - 1].Value);
                        }
                    }                   
                }
                using (StreamWriter writer = new StreamWriter(filePath2))
                {
                    // Write header row for Datagridview 2                    
                    if (dgv2.Columns.Count > 0)
                    {
                        for (int col = 0; col < dgv2.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv2.Columns[col].HeaderText + "|");
                        }
                        writer.WriteLine(dgv2.Columns[dgv2.Columns.Count - 1].HeaderText);

                        // Write data rows for Datagridview 2
                        for (int row = 0; row < dgv2.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgv2.Columns.Count - 1; col++)
                            {
                                writer.Write(dgv2.Rows[row].Cells[col].Value + "|");
                            }
                            writer.WriteLine(dgv2.Rows[row].Cells[dgv2.Columns.Count - 1].Value);
                        }
                    }                    
                }

                //MessageBox.Show("Data saved successfully to " + LocationPath, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning saving data: " + ex.Message, "Warning Save Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SaveDataTable(DataGridView dgv1, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {                                        
                    if (dgv1.Columns.Count > 0)
                    {
                        //Write column to text file
                        for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv1.Columns[col].HeaderText + "|");
                        }
                        writer.WriteLine(dgv1.Columns[dgv1.Columns.Count - 1].HeaderText);

                        // Write data rows to text file
                        for (int row = 0; row < dgv1.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                            {
                                writer.Write(dgv1.Rows[row].Cells[col].Value + "|");
                            }
                            writer.WriteLine(dgv1.Rows[row].Cells[dgv1.Columns.Count - 1].Value);
                        }
                    }                   
                }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning saving data: " + ex.Message + "\n" + "\n" + filePath, "Save file warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SaveListTotxt (List<string> list1, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write data to text file
                    for (int i = 0; i < list1.Count; i++)
                    {
                        writer.WriteLine(list1[i]);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message + "\n" + "\n" + filePath, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void SaveDataTable_ArrayVal(DataGridView dgv1, string filePath, string[] ArrayVal)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write Array Value paramenter
                    string joinWord = string.Join("#", ArrayVal);
                    writer.WriteLine(joinWord);
                    //Write column to text file
                    if (dgv1.Columns.Count > 0)
                    {
                        for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv1.Columns[col].HeaderText + "|");
                        }
                        writer.WriteLine(dgv1.Columns[dgv1.Columns.Count - 1].HeaderText);
                    }

                    // Write data rows to text file
                    for (int row = 0; row < dgv1.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv1.Rows[row].Cells[col].Value + "|");
                        }
                        writer.WriteLine(dgv1.Rows[row].Cells[dgv1.Columns.Count - 1].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message + "\n" + "\n" + filePath, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SplitWordToList (List<string> list1, string joinWord)
        {
            list1.Clear();
            string[] split = joinWord.Split('#');
            for (int i = 0; i < split.Length; i++)
            {
                list1.Add(split[i]);
            }
        }
        public void ImportData(DataGridView dgv1, List<string> ValueParameter, int NumVal, int NumHeader, int NumStartTable, string filePath)
        {
            ValueParameter.Clear();                       
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] headerText;
                string[] data;

                for (int i = 0; i < NumVal; i++)
                {
                    ValueParameter.Add(lines[i]);
                }              
                if (lines.Length != NumVal)
                {
                    //Create header for Table
                    headerText = lines[NumHeader].ToString().Split('|');
                    dgv1.ColumnCount = headerText.Length;
                    dgv1.RowCount = lines.Length - NumVal - 1;
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        if (headerText[i] == null)
                        {
                            dgv1.Columns[i].HeaderText = "";
                        }
                        else
                        {
                            dgv1.Columns[i].HeaderText = headerText[i];
                        }
                    }

                    string[][] CollectData = new string[dgv1.RowCount][];
                    for (int i = 0; i < dgv1.RowCount; i++)
                    {
                        CollectData[i] = new string[headerText.Length];
                    }

                    //Add data to table
                    for (int i = NumStartTable; i < lines.Length; i++)
                    {
                        data = lines[i].ToString().Split('|');
                        for (int j = 0; j < headerText.Length; j++)
                        {
                            CollectData[i - NumStartTable][j] = data[j];
                        }
                    }

                    for (int i = 0; i < dgv1.RowCount; i++)
                    {
                        for (int j = 0; j < dgv1.ColumnCount; j++)
                        {
                            dgv1.Rows[i].Cells[j].Value = CollectData[i][j];
                        }
                    }

                    dgv1.AutoResizeColumns();
                    dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ImporttxtToDGV (string filePath, DataGridView dgv)
        {
            try
            {
                //Clear Datagridview
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                //Insert data to datagridview
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);                   

                    if (lines.Length != 0)
                    {
                        //Create header
                        string[] headers = lines[0].Split('|');
                        foreach (string header in headers)
                        {
                            // Create a new DataGridViewTextBoxColumn for each header
                            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                            column.HeaderText = header.Trim(); // Set the header text
                            column.Name = header.Trim().Replace(" ", ""); // Optional: Set a name for programmatic access
                            dgv.Columns.Add(column);
                        }
                        dgv.AutoResizeColumns();
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgv.ColumnHeadersDefaultCellStyle = style;

                        if (lines.Length >= 2)
                        {
                            //Add data in rows
                            for (int i = 1; i < lines.Length; i++)
                            {
                                string[] rowData = lines[i].Split('|');

                                // Ensure the number of data items matches the number of columns
                                if (rowData.Length == dgv.Columns.Count)
                                {
                                    dgv.Rows.Add(rowData); // Add the row to the DataGridView
                                }
                            }
                        }                       
                    }                   
                }
                else
                {
                    MessageBox.Show("Not found: " + filePath, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string ImporttxtToDGV_cond(string filePath, DataGridView dgv)
        {            
            try
            {
                string result = "";
                //Clear Datagridview
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                //Insert data to datagridview
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length != 0)
                    {
                        //First Line
                        result = lines[0];

                        if (lines.Length >= 2)
                        {
                            //Create header
                            string[] headers = lines[1].Split('|');
                            foreach (string header in headers)
                            {
                                // Create a new DataGridViewTextBoxColumn for each header
                                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                                column.HeaderText = header.Trim(); // Set the header text
                                column.Name = header.Trim().Replace(" ", ""); // Optional: Set a name for programmatic access
                                dgv.Columns.Add(column);
                            }
                            //dgv.AutoResizeColumns();
                            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.ColumnHeadersDefaultCellStyle = style;
                        }
                        
                        if (lines.Length >= 3)
                        {
                            //Add data in rows
                            for (int i = 2; i < lines.Length; i++)
                            {
                                string[] rowData = lines[i].Split('|');

                                // Ensure the number of data items matches the number of columns
                                if (rowData.Length == dgv.Columns.Count)
                                {
                                    dgv.Rows.Add(rowData); // Add the row to the DataGridView
                                }
                            }
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("Not found: " + filePath, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        public void ReadtxtToList (string filePath, List<string> DataList)
        {
            try
            {
                string[] allLinesArray = File.ReadAllLines(filePath);
                for (int i = 0; i < allLinesArray.Length; i++)
                {
                    DataList.Add(allLinesArray[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Reading Text file Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SavetxtFromList(string filePath, List<string> DataList)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write text file
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        writer.WriteLine(DataList[i]);
                    }                   
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveProjectName_LCPlus(string TextName, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write Project Name
                    writer.WriteLine(TextName);
                }                

                //MessageBox.Show("Data saved successfully to " + LocationPath, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string ReadFirstLine(string fileName)
        {
            string firstLine = File.ReadLines(fileName).First();
            return firstLine;
        } 
        public void ConvertStreamToPreview (string filePath, string resultPath)
        {
            List<string> data = new List<string>();
            data.Clear();
            string[] lines = File.ReadAllLines(filePath);
            string searchword = "Total Weight Comp.";
            int index = Array.FindIndex(lines, s => s.Contains(searchword));

            data.Add(lines[0].Replace("Stream Name| ", "Stream  (Summary)|UOM").Trim());

            for (int i = index; i < lines.Length; i++)
            {
                data.Add(lines[i].Trim());
            }

            //Create txt file
            try
            {
                using (StreamWriter writer = new StreamWriter(resultPath))
                {
                    for (int j = 0; j < data.Count; j++)
                    {
                        //Write Project Name
                        writer.WriteLine(data[j]);
                    }                   
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        public void ReadTextfile(string filePath, List<string> list1, List<string> list2, List<string> list3, List<string> list4, DataGridView dgv1)
        {           
            try
            {
                list1.Clear();
                list2.Clear();
                list3.Clear();
                list4.Clear();
                dgv1.Rows.Clear();
                string[] lines = File.ReadAllLines(filePath);               
                //Collect data after spliting into the list
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] splitWords = lines[i].Split('$');
                    list1.Add(splitWords[0]);
                    list2.Add(splitWords[1]);
                    list3.Add(splitWords[2]);
                    list4.Add(splitWords[3]);                                     
                } 
                //Add new row in datagridview
                for (int i = 0; i < list1.Count; i++)
                {
                    dgv1.Rows.Add(list1[i], list2[i], list3[i]);
                }                
            }
            catch (Exception ex)
            {               
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void copyfile (string copyfile, string existfile)
        {
            if (File.Exists(existfile))
            {
                //Delete the file
                File.Delete(existfile);
                // Copy the file
                File.Copy(copyfile, existfile);
            }
        }
        public void SaveArrayTotxt(string[] array, string LocationPath, string startWord, string endWord)
        {
            string filePath = LocationPath + "\\" + startWord.Replace("-----------", "") + ".txt";
            try
            {
                int startLine = Array.IndexOf(array, startWord);
                int endLine = Array.IndexOf(array, endWord);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write data to text file
                    for (int i = startLine + 1; i < endLine; i++)
                    {
                        writer.WriteLine(array[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message + "\n" + "\n" + filePath, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool OpenAllSavefiles ()
        {
            bool status = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a saved file";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Filter for file types

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath).Replace(".txt", "");

                //Read all lines
                string[] lines = File.ReadAllLines(filePath);

                if (lines[0].Trim() == "Copyright (C) PSE for SPEED Co., Ltd.")
                {
                    status = true;

                    //Save Project name following the name of opened file                
                    string filePathLCC = strDirectory + "SaveFiles";
                    string filePathImpact = strDirectory + "Impact Calculation\\SaveFile";
                    SaveProjectName_LCPlus(fileName, filePathLCC + "\\Project_Name.txt");
                    SaveProjectName_LCPlus(fileName, filePathImpact + "\\Project_Name.txt");

                    //Create separated text file to LCC save file folder
                    string startWord, endWord;                                      
                    //StreamTablePreview
                    startWord = "-----------StreamTablePreview-----------";
                    endWord = "-----------EquipmentTablePreview-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //EquipmentTablePreview
                    startWord = "-----------EquipmentTablePreview-----------";
                    endWord = "-----------DefineMainProduct-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //DefineMainProduct
                    startWord = "-----------DefineMainProduct-----------";
                    endWord = "-----------DefineSideProduct-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //DefineSideProduct
                    startWord = "-----------DefineSideProduct-----------";
                    endWord = "-----------DefineInputStream-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //DefineInputStream
                    startWord = "-----------DefineInputStream-----------";
                    endWord = "-----------DefineOutputStream-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //DefineOutputStream
                    startWord = "-----------DefineOutputStream-----------";
                    endWord = "-----------DefineEquipment-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //DefineEquipment
                    startWord = "-----------DefineEquipment-----------";
                    endWord = "-----------PurchaseEquipment-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //PurchaseEquipment
                    startWord = "-----------PurchaseEquipment-----------";
                    endWord = "-----------FCI-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //FCI
                    startWord = "-----------FCI-----------";
                    endWord = "-----------WCI-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //WCI
                    startWord = "-----------WCI-----------";
                    endWord = "-----------OPCStream-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //OPCStream
                    startWord = "-----------OPCStream-----------";
                    endWord = "-----------OPCUtility-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //OPCUtility
                    startWord = "-----------OPCUtility-----------";
                    endWord = "-----------OPCLabor_perHour-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //OPCLabor_perHour
                    startWord = "-----------OPCLabor_perHour-----------";
                    endWord = "-----------OPCLabor_perMonth-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //OPCLabor_perMonth
                    startWord = "-----------OPCLabor_perMonth-----------";
                    endWord = "-----------FeedStockCost-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //FeedStockCost
                    startWord = "-----------FeedStockCost-----------";
                    endWord = "-----------MaintenanceCost-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //MaintenanceCost
                    startWord = "-----------MaintenanceCost-----------";
                    endWord = "-----------SalvageValue-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //SalvageValue
                    startWord = "-----------SalvageValue-----------";
                    endWord = "-----------MainProductCredit-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //MainProductCredit
                    startWord = "-----------MainProductCredit-----------";
                    endWord = "-----------SideProductCredit-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                    //SideProductCredit
                    startWord = "-----------SideProductCredit-----------";
                    endWord = "-----------EconomicValueAndProductCapacity-----------";
                    SaveArrayTotxt(lines, filePathLCC, startWord, endWord);
                }
                else
                {
                    MessageBox.Show("The selected file is in an incorrect formal.\n\nPlease ensure you choose the correct file and try again", "Warning incorrect format file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                       
            }

            return status;
        }
    }
}

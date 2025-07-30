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
    class Function_SaveOpen
    {        
        public void SaveData2Tables_ArrayVal(DataGridView dgv1, DataGridView dgv2, string filePath, string filePath2, string LocationPath, string[] ArrayVal)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write Array value parameter
                    for (int i = 0; i < ArrayVal.Length; i++)
                    {
                        writer.WriteLine(ArrayVal[i]);
                    }

                    // Write header row for Datagridview 1
                    if (dgv1.Columns.Count > 0)
                    {
                        for (int col = 0; col < dgv1.Columns.Count - 1; col++)
                        {
                            writer.Write(dgv1.Columns[col].HeaderText + "|");
                        }
                        writer.WriteLine(dgv1.Columns[dgv1.Columns.Count - 1].HeaderText);
                    }

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
                    }

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

                MessageBox.Show("Data saved successfully to " + LocationPath, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveDataTable(DataGridView dgv1, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {                    
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
        public void SaveDataTable_ArrayVal(DataGridView dgv1, string filePath, string[] ArrayVal)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write Array Value paramenter
                    for (int i = 0; i < ArrayVal.Length; i++)
                    {
                        writer.WriteLine(ArrayVal[i]);
                    }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace LCC
{
    class Function_CollectData
    {
        public static DataTable GetDataSQL(string DBPath, string query)
        {
            string connectionString = $"Data Source=" + DBPath + ";Version=3;";
            DataTable dataTable = new DataTable();
            try
            {
                // Open SQLite connection
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Load data into DataTable
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public void GetDataToCbb (string DBPath, ComboBox cbb, string query)
        {
            //Clear items in combobox
            cbb.Items.Clear();

            //Get data from database
            DataTable dataTable = GetDataSQL(DBPath, query);

            //Add data to combobox
            if (dataTable.Rows.Count != 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string data = dataTable.Rows[i][0].ToString();
                    cbb.Items.Add(data);
                }
            }
        }
        public void GetDataToListBox(string DBPath, ListBox lb, string query)
        {
            //Clear items in listbox
            lb.Items.Clear();

            //Get data from database
            DataTable dataTable = GetDataSQL(DBPath, query);

            //Add data to listbox
            if (dataTable.Rows.Count != 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string data = dataTable.Rows[i][0].ToString().Trim();
                    if (data != "" || !string.IsNullOrEmpty(data))
                    {
                        lb.Items.Add(data);
                    }                    
                }
            }
        }
        public void GetDataToTextBox(string DBPath, TextBox tb, string query)
        {           
            //Get data from database
            DataTable dataTable = GetDataSQL(DBPath, query);

            //Add data to textbox
            if (dataTable.Rows.Count != 0)
            {
                string data = dataTable.Rows[0][0].ToString().Trim();
                if (data != "" || !string.IsNullOrEmpty(data))
                {
                    tb.Text = data;
                    tb.BackColor = Color.LightGreen;
                }
            }
        }
        public void GetDataToDGV(string DBPath, DataGridView dgv, int startRow, int endRow, int ReadIndex, int FillIndex, string cmd)
        {
            for (int i = startRow; i < endRow; i++)
            {
                string comp = dgv.Rows[i].Cells[ReadIndex].Value.ToString();
                if (comp != "" || !string.IsNullOrEmpty(comp))
                {
                    string actualComp = comp.ToLower().Trim();                    
                    string query = cmd + " = '" + actualComp + "';";
                    DataTable dataTable = GetDataSQL(DBPath, query);
                    string price;
                    if (dataTable.Rows.Count != 0)
                    {
                        price = dataTable.Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        price = "";
                    }
                    dgv.Rows[i].Cells[FillIndex].Value = price;
                }

            }                                                     
        }
        public void ReadtxtToList (string filePath, List<string> list1)
        {
            try
            {
                list1.Clear();
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    list1.Add(lines[i]);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

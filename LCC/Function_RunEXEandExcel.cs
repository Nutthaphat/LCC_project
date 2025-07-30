using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LCC
{
    class Function_RunEXEandExcel
    {
        public void OpenExcel(string dir,string filename)
        {
            // Create COM objects
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;

            try
            {
                //Set the current directory            
                Directory.SetCurrentDirectory(dir);
                // Open the Excel file
                xlWorkbook = xlApp.Workbooks.Open(filename);           

                // Close the workbook (and optionally quit Excel)
                xlWorkbook.Close(true); // Save changes if any
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                // Handle potential errors (e.g., file not found, Excel not installed)
                MessageBox.Show("Error opening Excel: " + ex.Message, "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool checkWordtxt(string filePath, string checkWord)
        {
            bool status = false;
            string FirstLine;
            string[] Split_Word;
            try
            {
                FirstLine = File.ReadLines(filePath).FirstOrDefault();
                Split_Word = FirstLine.ToString().Split('|');
                if (Split_Word[0] == checkWord)
                {
                    status = true;
                    //MessageBox.Show("The data was successfully imported into the LCC and impact calculation software.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please ensure you seleted the file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Excel: " + ex.Message, "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public void RunExE(string dir, string filePath)
        {      
            try
            {
                //Set the current directory            
                Directory.SetCurrentDirectory(dir);
                Process prs = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.UseShellExecute = true;
                startInfo.CreateNoWindow = true;
                startInfo.FileName = filePath;
                prs.StartInfo = startInfo;
                prs.Start();
                prs.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle potential errors (e.g., file not found)
                MessageBox.Show("Error launching executable: " + ex.Message, "Software Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

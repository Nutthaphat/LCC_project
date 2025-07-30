using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace LCC
{
    public partial class Utility_Labor_Price: Form
    {
        string DBPathMain;
        int ID_DBMain;
        Form1 _word;

        Function con;
        Function_CollectData conCD;
        public Utility_Labor_Price(string DBPath, int ID_DB, Form1 word)
        {
            InitializeComponent();
            DBPathMain = DBPath;
            ID_DBMain = ID_DB;
            _word = word;

            con = new Function();
            conCD = new Function_CollectData();
        }

        private void Utility_Labor_Price_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //Add items to combobox about labor catergory
            string query = "SELECT Labor_Type FROM LABOR_TYPE WHERE ID = " + ID_DBMain.ToString() + ";";
            conCD.GetDataToCbb(DBPathMain, cbbCategory, query);
            cbbCategory.Text = cbbCategory.Items[0].ToString();

            //Add items to Listbox about labor type
            string querylb = "SELECT p.Job_Name " +
                "FROM LABOR_PRICE p " +
                "WHERE TypeID = " + ID_DBMain.ToString() + " " +
                "ORDER BY p.Job_Name;"; 
            conCD.GetDataToListBox(DBPathMain, lbType, querylb);

            //Change wording for groupbox salary
            if (ID_DBMain == 1)
            {
                gbPrice.Text = "Salary per hour ($)";
            }
            else
            {
                gbPrice.Text = "Salary per month ($)";
            }           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Labor Cost Selection page, a feature within the Life Cycle Cost (LCC) section of the software, " +
                "allows users to select labor cost from database.\n\nThese adjustments are applied to the table upon clicking the Update button.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gbDutyType_Enter(object sender, EventArgs e)
        {

        }

        private void lbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbType.Items.Count != 0)
            {               
                string laborType = lbType.SelectedItem.ToString();
                string querytb = "SELECT p.Price " +
                    "FROM LABOR_PRICE p " +
                    "WHERE p.TypeID = " + ID_DBMain.ToString() + " AND p.Job_Name = '" + laborType + "';";
                conCD.GetDataToTextBox(DBPathMain, txtPrice, querytb);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            string message = "The value entered for the salary must be a number.";
            string titleMessage = "Warning Invalid Salary";
            con.checkNumberTB(txtPrice, message, titleMessage);
        }

        private void txtnumLabor_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue(txtnumLabor, "number of labors");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.StausTotalCost(txtPrice))
            {
                if (con.StausTotalCost(txtnumLabor))
                {
                    string JobName = lbType.SelectedItem.ToString();
                    string numberLabor = txtnumLabor.Text;
                    string salary = txtPrice.Text;
                    _word.UpdateLaborCost(JobName, numberLabor, salary, ID_DBMain);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please ensure to fill number of labors before proceeding this step.", "Warning missing number of labors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please ensure to fill salary value before proceeding this step.", "Warning missing salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }               
        }
    }
}

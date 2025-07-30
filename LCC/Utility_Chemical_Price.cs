using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace LCC
{
    public partial class Utility_Chemical_Price: Form
    {
        string DBPathMain;
        string equipNameMain;

        Function con;
        Function_CollectData conCD;
        Form1 _word;
        public Utility_Chemical_Price(string DBPath, string equipName, Form1 word)
        {
            InitializeComponent();
            equipNameMain = equipName;
            DBPathMain = DBPath;
            _word = word;

            con = new Function();
            conCD = new Function_CollectData();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Duty Type Selection page, a feature within the Life Cycle Cost (LCC) section of the software, " +
                "allows users to modify duty prices.\n\nThese adjustments are applied to the table upon clicking the Update button.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Utility_Chemical_Price_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //Show equipment Name
            txtEquipName.Text = equipNameMain;

            //Add items to combobox about utility catergory
            string query = "SELECT Unit_Name FROM UTILITY_CATEGORY;";
            conCD.GetDataToCbb(DBPathMain, cbbCategory, query);

            //Change text box to readonly mode
            txtPrice.ReadOnly = true;
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cbbCategory.Text != "" && cbbCategory.Text != "Other")
            {
                string dutyCategory = cbbCategory.Text;
                //Add items to Listbox about utility type
                string querylb = "SELECT p.Source_Name " +
                    "FROM UTILITY_PRICE p " +
                    "JOIN UTILITY_CATEGORY c ON p.TypeID = c.ID " +
                    "WHERE c.Unit_Name = '" + dutyCategory + "' " +
                    "ORDER BY p.Source_Name;";
                conCD.GetDataToListBox(DBPathMain, lbdutyType, querylb);
                txtPrice.ReadOnly = true;
            }
            else if (cbbCategory.Text == "Other")
            {                                
                lbdutyType.Items.Clear();
                txtPrice.ReadOnly = false;
            }
            con.tbNullValue(txtPrice);
        }

        private void lbdutyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbdutyType.Items.Count != 0)
            {
                string dutyCategory = cbbCategory.Text;
                string dutyType = lbdutyType.SelectedItem.ToString();
                string querytb = "SELECT p.Price " +
                    "FROM UTILITY_PRICE p " +
                    "JOIN UTILITY_CATEGORY c ON p.TypeID = c.ID " +
                    "WHERE c.Unit_Name = '" + dutyCategory + "' AND p.Source_Name = '" + dutyType + "';";
                conCD.GetDataToTextBox(DBPathMain, txtPrice, querytb);
            }            
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {            
            string message = "The value entered for the price must be a number.";
            string titleMessage = "Warning Invalid Price Value";
            con.checkNumberTB(txtPrice, message, titleMessage);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string dutyType, price;
            if (txtPrice.BackColor == Color.LightGreen)
            {
                if (cbbCategory.Text == "Other")
                {
                    dutyType = "Other";
                }
                else
                {
                    dutyType = lbdutyType.SelectedItem.ToString();
                }                   
                price = txtPrice.Text;
                _word.UpdateUtilityPrice(dutyType, price);
                this.Close();
            }
            else
            {
                MessageBox.Show("Missing price value.\n\nPlease ensure you add the price value correctly, and then try again.", "Warning incorrect price value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
        }
    }
}

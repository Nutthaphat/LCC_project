using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCC
{
    public partial class Equipment_Flash: Form
    {
        string equipNameMain;
        Define_Product_LCPlus _word;

        Function con;
        public Equipment_Flash(string equipName, Define_Product_LCPlus word)
        {
            InitializeComponent();
            equipNameMain = equipName;
            _word = word;

            con = new Function();
        }

        private void Equipment_Flash_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipName.Text = equipNameMain;

            rdbCastIron.Checked = true;
            cbbUnit.Text = "kW";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A \"Flash Page\" in this software, designed for users to define the price of " +
                "a flash based on flash data input.", "Flash Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtHeatDuty_TextChanged(object sender, EventArgs e)
        {
            string message = "The value entered for the heat duty must be a number.";
            string titleMessage = "Warning Invalid Heat Duty Value";
            con.checkNumberTB(txtHeatDuty, message, titleMessage);
        }

        private void txtPurchaseVR_TextChanged(object sender, EventArgs e)
        {
            string message = "The value entered for the Purchase Cost must be a number.";
            string titleMessage = "Warning Invalid Purchase Cost Value";
            con.checkNumberTB(txtPurchaseVR, message, titleMessage);
        }       

        private void btnDoneVR_Click(object sender, EventArgs e)
        {
            if (txtHeatDuty.BackColor == Color.LightGreen)
            {
                if (txtPurchaseVR.BackColor == Color.LightGreen)
                {
                    string sizing = txtHeatDuty.Text;
                    string sizing_unit = cbbUnit.Text;
                    string[] Material = { "Cast iron", "Cast steel", "Stainless steel", "Nickel alloy" };
                    string material = con.Select4Material(Material, rdbCastIron, rdbCastSteel, rdbStainlessSteel, rdbNickelAlloy);
                    string PurchaseCost = txtPurchaseVR.Text;

                    //Return value to datagridview in Define_Product_LCPlus page
                    _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Purchase cost fill data is missing.\n\nPlease ensure purchase cost value is entered.", "Warning missing purchase cost value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Heat duty fill data is missing.\n\nPlease ensure heat duty value is entered.", "Warning missing heat duty value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace LCC
{
    public partial class Equipment_Compressor: Form
    {
        string equipNameMain;
        double CPI_IndexMain;
        Function con;
        Function_Calculation conCal;
        Define_Product_LCPlus _word;

        public Equipment_Compressor(string equipName, double CPI_Index, Define_Product_LCPlus word)
        {
            InitializeComponent();
            equipNameMain = equipName;
            CPI_IndexMain = CPI_Index;
            _word = word;

            con = new Function();
            conCal = new Function_Calculation();           
        }
        double alpha = 0;
        double beta = 0;
        double af = 1;

        private void Equipment_Compressor_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipName.Text = equipNameMain;

            //Compressor
            rdbCent_Motor.Checked = true;
            rdbCarbon_Comp.Checked = true;
            cbbPowerCompUnit.Text = "kW";
            cbbUnitPresssureComp.Text = "kPa";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A \"Compressor Page\" in this software, designed for users to calculate the " +
                "price of a compressor based on compressor data input of compressor type, material, pressure and power, " +
                "would be a highly practical and user-friendly feature, especially for businesses in manufacturing, engineering, " +
                "or sales of industrial equipment.", "Compressor Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPressureComp_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);

            string message = "The value entered for the pressure must be a number.";
            string titleMessage = "Warning Invalid Pressure Value";
            con.checkNumberTB(txtPressureComp, message, titleMessage);
        }

        private void txtPowerComp_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);

            string message = "The value entered for the power must be a number.";
            string titleMessage = "Warning Invalid Power Value";
            con.checkNumberTB(txtPowerComp, message, titleMessage);
        }

        private void cbbUnitPresssureComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void cbbPowerCompUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbCent_Motor_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbCent_Turbine_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbCent_Rotary_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbRecip_GasTurbine_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbRecip_Motor_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbRecip_Stream_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbCarbon_Comp_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbStainless_Comp_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbNickel_Comp_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPressureComp.BackColor == Color.LightGreen)
                {
                    if (txtPowerComp.BackColor == Color.LightGreen)
                    {
                        //Compressor type value
                        if (rdbCent_Motor.Checked == true)
                        {
                            alpha = 877.3;
                            beta = 0.9435;
                        }
                        else if (rdbCent_Turbine.Checked == true)
                        {
                            alpha = 1217.9;
                            beta = 0.9195;
                        }
                        else if (rdbCent_Rotary.Checked == true)
                        {
                            alpha = 3159.3;
                            beta = 0.6738;
                        }
                        else if (rdbRecip_GasTurbine.Checked == true)
                        {
                            alpha = 1564.5;
                            beta = 0.9467;
                        }
                        else if (rdbRecip_Motor.Checked == true)
                        {
                            alpha = 1435.4;
                            beta = 0.9138;
                        }
                        else if (rdbRecip_Stream.Checked == true)
                        {
                            alpha = 892.22;
                            beta = 0.9567;
                        }

                        //Compressor material value
                        if (rdbCarbon_Comp.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdbStainless_Comp.Checked == true)
                        {
                            af = 2.5;
                        }
                        else if (rdbNickel_Comp.Checked == true)
                        {
                            af = 5.1;
                        }
                        double sizing_Comp;
                        sizing_Comp = conCal.ConvertPower_Unit(cbbPowerCompUnit.Text, txtPowerComp.Text, 75, 6000);
                        txtPurchase.Text = conCal.PurchaseCost(alpha, beta, sizing_Comp, af, CPI_IndexMain);
                        txtPurchase.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        MessageBox.Show("Power fill data is missing.\n\nPlease ensure power value is entered before processing to the calculation step.", "Warning missing power value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Pressure fill data is missing.\n\nPlease ensure pressure value is entered before processing to the calculation step.", "Warning missing pressure value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }       

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtPurchase.BackColor == Color.LightGreen)
            {
                string sizing = txtPowerComp.Text;
                string sizing_unit = cbbPowerCompUnit.Text;
                string[] Material = { "Carbon steel", "Stainless steel", "Nickel alloy" };
                string material = con.Select3Material(Material, rdbCarbon_Comp, rdbStainless_Comp, rdbNickel_Comp);
                string PurchaseCost = txtPurchase.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

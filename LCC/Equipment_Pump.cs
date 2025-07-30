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
    public partial class Equipment_Pump: Form
    {
        string equipNameMain;
        double CPI_IndexMain;
        Function con;
        Function_Calculation conCal;
        Define_Product_LCPlus _word;
        public Equipment_Pump(string equipName, double CPI_Index, Define_Product_LCPlus word)
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
        double a1 = 0;
        double b1 = 0;
        double c1 = 0;
        double d1 = 0;
        double e1 = 0;
        double f1 = 0;
        double CapitalC = 0;
        private void Equipment_Pump_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipNamePump.Text = equipNameMain;

            //Pump
            rdbCentifugalP.Checked = true;
            rdbCastIronPump.Checked = true;
            rdb1035.Checked = true;
            cbbUnitPump.Text = "cubic meter (m3)/s";

            //Pump include drive
            cbbUnitPumpDrive.Text = "cubic meter (m3)/s * kPa";
            cbbUnit2PumpDrive.Text = "kW";
        }

        private void gbTypePump_Enter(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A \"Pump Page\" in this software, designed for users to calculate the price of " +
                "a pump based on pump data input of pump type, material, and pressure, would be a highly practical " +
                "and user-friendly feature, especially for businesses in manufacturing, engineering, or sales of industrial " +
                "equipment.", "Pump Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPumpCap_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);

            string message = "The value entered for the pump capacity must be a number.";
            string titleMessage = "Warning Invalid Pump Capacity Value";
            con.checkNumberTB(txtPumpCap, message, titleMessage);           
        }

        private void txtsizePumpDrive_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePumpDrive);

            string message = "The value entered for the size of pump must be a number.";
            string titleMessage = "Warning Invalid size of pump Value";
            con.checkNumberTB(txtsizePumpDrive, message, titleMessage);
        }

        private void txtUtilityPumpDrive_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePumpDrive);

            string message = "The value entered for the utility must be a number.";
            string titleMessage = "Warning Invalid utility Value";
            con.checkNumberTB(txtUtilityPumpDrive, message, titleMessage);
        }

        private void rdbCentifugalP_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbReciprocatingP_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbRotaryP_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbGearP_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbDiaphragmP_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbCastIronPump_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbCastSteelPump_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbStainlessSteelPump_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdbNickelAlloyPump_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void btnCalPump_Click(object sender, EventArgs e)
        {
            double sizing_Pump, pressureFactor, CalPumpCost;
            try
            {
                if (txtPumpCap.BackColor == Color.LightGreen)
                {
                    pressureFactor = 1;
                    if (Convert.ToDouble(txtPumpCap.Text) >= 0.009 && Convert.ToDouble(txtPumpCap.Text) <= 1)
                    {
                        //Pump Type
                        if (rdbCentifugalP.Checked == true)
                        {
                            alpha = 18441;
                            beta = 0.3849;
                        }
                        //Material factor
                        if (rdbCastIronPump.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdbCastSteelPump.Checked == true)
                        {
                            af = 1.8;
                        }
                        else if (rdbStainlessSteelPump.Checked == true)
                        {
                            af = 2.4;
                        }
                        else if (rdbNickelAlloyPump.Checked == true)
                        {
                            af = 5;
                        }
                        //Pressure factor
                        if (rdb1035.Checked == true)
                        {
                            pressureFactor = 1;
                        }
                        else if (rdb5000.Checked == true)
                        {
                            pressureFactor = 2.1;
                        }
                        else if (rdb10000.Checked == true)
                        {
                            pressureFactor = 2.8;
                        }
                        else if (rdb20000.Checked == true)
                        {
                            pressureFactor = 3.5;
                        }
                        else if (rdb30000.Checked == true)
                        {
                            pressureFactor = 4;
                        }
                        sizing_Pump = conCal.ConvertCapacityFlow_Unit(cbbUnitPump.Text, txtPumpCap.Text, 0.009, 1);
                        CalPumpCost = Convert.ToDouble(conCal.PurchaseCost(alpha, beta, sizing_Pump, af, CPI_IndexMain));
                        txtPurchasePump.Text = (CalPumpCost * pressureFactor).ToString("#,##0.##");
                        txtPurchasePump.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToDouble(txtPumpCap.Text) > 1)
                    {
                        //Pump Type
                        if (rdbCentifugalP.Checked == true)
                        {
                            alpha = 18441;
                            beta = 0.3849;
                        }
                        //Material factor
                        if (rdbCastIronPump.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdbCastSteelPump.Checked == true)
                        {
                            af = 1.8;
                        }
                        else if (rdbStainlessSteelPump.Checked == true)
                        {
                            af = 2.4;
                        }
                        else if (rdbNickelAlloyPump.Checked == true)
                        {
                            af = 5;
                        }
                        //Pressure factor
                        if (rdb1035.Checked == true)
                        {
                            pressureFactor = 1;
                        }
                        else if (rdb5000.Checked == true)
                        {
                            pressureFactor = 2.1;
                        }
                        else if (rdb10000.Checked == true)
                        {
                            pressureFactor = 2.8;
                        }
                        else if (rdb20000.Checked == true)
                        {
                            pressureFactor = 3.5;
                        }
                        else if (rdb30000.Checked == true)
                        {
                            pressureFactor = 4;
                        }
                        sizing_Pump = conCal.ConvertCapacityFlow_Unit(cbbUnitPump.Text, txtPumpCap.Text, 0.009, 1);
                        CalPumpCost = Convert.ToDouble(conCal.PurchaseCost(alpha, beta, sizing_Pump, af, CPI_IndexMain));
                        txtPurchasePump.Text = (CalPumpCost * pressureFactor).ToString("#,##0.##");
                        txtPurchasePump.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        e1 = -1E+7;
                        f1 = 318781;
                        CapitalC = 1017.3;
                        sizing_Pump = conCal.ConvertCapacityFlow_Unit(cbbUnitPump.Text, txtPumpCap.Text, 0.00015, 0.009);
                        txtPurchasePump.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Pump, 1, CPI_IndexMain);
                        txtPurchasePump.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    MessageBox.Show("Pump capacity fill data is missing.\n\nPlease ensure pump capacity value is entered before processing to the calculation step.", "Warning missing pump capacity value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdb1035_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdb5000_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdb10000_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdb20000_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void rdb30000_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }

        private void cbbUnitPump_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePump);
        }        

        private void btnDonePump_Click(object sender, EventArgs e)
        {
            if (txtPurchasePump.BackColor == Color.LightGreen)
            {
                string sizing = txtPumpCap.Text;
                string sizing_unit = cbbUnitPump.Text;
                string[] PumpMaterial = { "Cast iron", "Cast steel", "Stainless steel", "Nickel alloy" };
                string material = con.Select4Material(PumpMaterial, rdbCastIronPump, rdbCastSteelPump, rdbStainlessSteelPump, rdbNickelAlloyPump);
                string PurchaseCost = txtPurchasePump.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbUnitPumpDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePumpDrive);
        }

        private void cbbUnit2PumpDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePumpDrive);
        }

        private void btnCalPD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsizePumpDrive.BackColor == Color.LightGreen)
                {
                    if (txtUtilityPumpDrive.BackColor == Color.LightGreen)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        e1 = -0.7712;
                        f1 = 795.92;
                        CapitalC = 8081.1;
                        double sizing_PumpDrive;
                        sizing_PumpDrive = conCal.ConvertvolumePressure_Unit(cbbUnitPumpDrive.Text, txtsizePumpDrive.Text, 6, 70);
                        txtPurchasePumpDrive.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PumpDrive, 1, CPI_IndexMain);
                        txtPurchasePumpDrive.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        MessageBox.Show("Size of pump fill data is missing.\n\nPlease ensure size of pump value is entered.", "Warning missing size of pump value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Utility fill data is missing.\n\nPlease ensure utility value is entered.", "Warning missing utility value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDonePD_Click(object sender, EventArgs e)
        {
            if (txtPurchasePumpDrive.BackColor == Color.LightGreen)
            {
                string sizing = txtsizePumpDrive.Text;
                string sizing_unit = cbbUnitPumpDrive.Text;
                string material = "-";
                string PurchaseCost = txtPurchasePumpDrive.Text;

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

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
    public partial class Equipment_Column: Form
    {
        string equipNameMain;
        double CPI_IndexMain;
        Function con;
        Function_Calculation conCal;
        Define_Product_LCPlus _word;
        public Equipment_Column(string equipName, double CPI_Index, Define_Product_LCPlus word)
        {
            InitializeComponent();
            equipNameMain = equipName;
            CPI_IndexMain = CPI_Index;
            _word = word;

            con = new Function();
            conCal = new Function_Calculation();
        }
        
        double af = 1;
        double a1 = 0;
        double b1 = 0;
        double c1 = 0;
        double d1 = 0;
        double e1 = 0;
        double f1 = 0;
        double CapitalC = 0;

        double PurchaseCost_Col = 0;
        double PurchaseCost_Tray = 0;

        double min = 0;
        double max = 0;

        private void Equipment_Column_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipName.Text = equipNameMain;

            //Tower Unit
            rdbCSTU.Checked = true;
            rdb05TU.Checked = true;
            rdb101TU.Checked = true;
            rdbCSST.Checked = true;
            cbbUnitTU.Text = "meters";
            cbbUnitTTU.Text = "meters";
            gbTrayTU.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A \"Column Page\" in this software, designed for users to calculate the price of " +
               "a column based on column data input.", "Column Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbTrayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrayCheck.Checked == true)
            {
                gbTrayTU.Enabled = true;
            }
            else
            {
                gbTrayTU.Enabled = false;
            }
            con.tbNullVal(txtPurchase);
        }

        private void txtHeightTU_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);

            string message = "The value entered for the column height must be a number.";
            string titleMessage = "Warning Invalid Column Height Value";
            con.checkNumberTB(txtHeightTU, message, titleMessage);
        }

        private void txtDiameterTTU_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);

            string message = "The value entered for the diameter of tray must be a number.";
            string titleMessage = "Warning Invalid Diameter of Tray Value";
            con.checkNumberTB(txtDiameterTTU, message, titleMessage);
        }

        private void rdbCSTU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbSSTU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbNATU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void cbbUnitTU_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb05TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation\n\nis 1.5 m to 20 m.";
            con.tbNullVal(txtPurchase);            
        }

        private void rdb1TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation\n\nis 2.5 m to 30 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdb2TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation\n\nis 4 m to 45 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdb3TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation\n\nis 6 m to 50 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdb4TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation\n\nis 7 m to 50 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdb101TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb1035TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb5000TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb10000TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb20000TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb30000TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdb40000TU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void rdbCSST_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.5 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdbCSVT_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.61 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdbSSST_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.61 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdbSTBGTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.61 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdbVTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.61 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void rdbBCTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation\n\nis 0.61 m to 3.81 m.";
            con.tbNullVal(txtPurchase);
        }

        private void cbbUnitTTU_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void nudNumTray_ValueChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchase);
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHeightTU.BackColor == Color.LightGreen)
                {
                    double sizing_Col, sizing_Tray;
                    //double PurchaseCost_Tray = 0;
                    string CalCost;
                    //Pressure factor
                    double pf = 0;
                    if (rdb101TU.Checked == true)
                    {
                        pf = 1;
                    }
                    else if (rdb1035TU.Checked == true)
                    {
                        pf = 1.6;
                    }
                    else if (rdb5000TU.Checked == true)
                    {
                        pf = 3.2;
                    }
                    else if (rdb10000TU.Checked == true)
                    {
                        pf = 4.6;
                    }
                    else if (rdb20000TU.Checked == true)
                    {
                        pf = 8.7;
                    }
                    else if (rdb30000TU.Checked == true)
                    {
                        pf = 12.2;
                    }
                    else if (rdb40000TU.Checked == true)
                    {
                        pf = 15.8;
                    }
                    //Material factor
                    if (rdbCSTU.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdbSSTU.Checked == true)
                    {
                        af = 3;
                    }
                    else if (rdbNATU.Checked == true)
                    {
                        af = 7.4;
                    }
                    //Column Calculation
                    a1 = 0;
                    b1 = 0;
                    c1 = 0;
                    d1 = 0;
                    if (rdb05TU.Checked == true)
                    {
                        e1 = 15.401;
                        f1 = 1588.5;
                        CapitalC = 1495.5;
                        min = 1.5;
                        max = 20;
                    }
                    else if (rdb1TU.Checked == true)
                    {
                        e1 = 13.929;
                        f1 = 2028.4;
                        CapitalC = 1850.6;
                        min = 2.5;
                        max = 30;
                    }
                    else if (rdb2TU.Checked == true)
                    {
                        e1 = 3.011;
                        f1 = 3139.4;
                        CapitalC = 7166.9;
                        min = 4;
                        max = 45;
                    }
                    else if (rdb3TU.Checked == true)
                    {
                        e1 = -23.555;
                        f1 = 5119.4;
                        CapitalC = 10945;
                        min = 6;
                        max = 50;
                    }
                    else if (rdb4TU.Checked == true)
                    {
                        e1 = -49.723;
                        f1 = 5021.1;
                        CapitalC = 24285;
                        min = 7;
                        max = 50;
                    }
                    sizing_Col = conCal.ConvertHeight_Unit(cbbUnitTU.Text, txtHeightTU.Text, min, max);
                    CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Col, af, CPI_IndexMain);
                    PurchaseCost_Col = Convert.ToDouble(CalCost) * pf;
                    //txtPurchaseTU.Text = (Convert.ToDouble(CalCost) * pf).ToString("#,##0.##");
                    //---------------------------------------
                    //Tray 
                    double afTray = 0;
                    double[] numTray = { 3, 2.8, 2.65, 2.5, 2.3, 2.15, 2, 1.8, 1.65, 1.5, 1.45, 1.4, 1.35, 1.30, 1.25, 1.2, 1.15, 1.1, 1.05 };
                    int NumTrayAdd;
                    NumTrayAdd = Convert.ToInt32(nudNumTray.Text);
                    if (cbTrayCheck.Checked == true)
                    {
                        if (txtDiameterTTU.BackColor == Color.LightGreen)
                        {
                            //Number of Tray
                            if (NumTrayAdd < 20)
                            {
                                afTray = numTray[NumTrayAdd - 1];
                            }
                            else if (NumTrayAdd >= 20 && NumTrayAdd < 30)
                            {
                                afTray = 1;
                            }
                            else if (NumTrayAdd >= 30 && NumTrayAdd < 40)
                            {
                                afTray = 0.98;
                            }
                            else if (NumTrayAdd >= 40)
                            {
                                afTray = 0.97;
                            }
                            else
                            {
                                afTray = 0;
                            }
                            //Tray Type
                            a1 = 0;
                            b1 = 0;
                            c1 = 0;
                            min = 0.61;
                            max = 3.81;
                            if (rdbCSST.Checked == true)
                            {
                                d1 = -32.7;
                                e1 = 234.91;
                                f1 = -66.321;
                                CapitalC = 293.53;
                                min = 0.5;
                            }
                            else if (rdbCSVT.Checked == true)
                            {
                                d1 = 38.289;
                                e1 = -26.568;
                                f1 = 332.26;
                                CapitalC = 152.51;
                            }
                            else if (rdbSSST.Checked == true)
                            {
                                d1 = -84.874;
                                e1 = 638.2;
                                f1 = -454.1;
                                CapitalC = 774.21;
                            }
                            else if (rdbSTBGTSS.Checked == true)
                            {
                                d1 = 9.5515;
                                e1 = 85.623;
                                f1 = 290.8;
                                CapitalC = 262.45;
                            }
                            else if (rdbVTSS.Checked == true)
                            {
                                d1 = 87.816;
                                e1 = -44.382;
                                f1 = 631.32;
                                CapitalC = 362.42;
                            }
                            else if (rdbBCTSS.Checked == true)
                            {
                                d1 = 77.593;
                                e1 = 270.1;
                                f1 = 264.98;
                                CapitalC = 542.95;
                            }
                            sizing_Tray = conCal.ConvertHeight_Unit(cbbUnitTTU.Text, txtDiameterTTU.Text, min, max);
                            CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Tray, afTray, CPI_IndexMain);
                            PurchaseCost_Tray = Convert.ToDouble(CalCost) * NumTrayAdd;
                        }
                        else
                        {
                            MessageBox.Show("Diameter of tray fill data is missing.\n\nPlease ensure diameter of tray value is entered.", "Warning missing diameter of tray value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                       
                    }
                    else
                    {
                        PurchaseCost_Tray = 0;
                    }

                    if (cbTrayCheck.Checked == false && txtHeightTU.BackColor == Color.LightGreen)
                    {
                        txtPurchase.Text = (PurchaseCost_Col + PurchaseCost_Tray).ToString("#,##0.##");
                        txtPurchase.BackColor = Color.LightGreen;
                    }
                    else if (cbTrayCheck.Checked == true && txtHeightTU.BackColor == Color.LightGreen && txtDiameterTTU.BackColor == Color.LightGreen)
                    {
                        txtPurchase.Text = (PurchaseCost_Col + PurchaseCost_Tray).ToString("#,##0.##");
                        txtPurchase.BackColor = Color.LightGreen;
                    }                   
                }
                else
                {
                    MessageBox.Show("Column height fill data is missing.\n\nPlease ensure column height value is entered.", "Warning missing column height value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string sizing = txtHeightTU.Text;
                string sizing_unit = cbbUnitTU.Text;
                string[] Material = { "Carbon Steel", "316 Stainless Steel", "Nickel Alloy" };
                string material = con.Select3Material(Material, rdbCSTU, rdbSSTU, rdbNATU);
                string PurchaseCost = txtPurchase.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateColumnCost(equipNameMain, sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

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
    public partial class Equipment_Reactor: Form
    {
        string equipNameMain;
        double CPI_IndexMain;
        Function con;
        Function_Calculation conCal;
        Define_Product_LCPlus _word;

        public Equipment_Reactor(string equipName, double CPI_Index, Define_Product_LCPlus word)
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

        double min = 0;
        double max = 0;
        private void Equipment_Reactor_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipName.Text = equipNameMain;

            //Reactor
            ////Vessel Reactor
            rdbVertical.Checked = true;
            rdbCSVR.Checked = true;
            rdb05VR.Checked = true;
            rdb101VR.Checked = true;
            cbbUnitVR.Text = "meters";
            ////Plug Flow Reactor
            rbdCSCSR.Checked = true;
            rdb690R.Checked = true;            
            cbbUnitPFR.Text = "sq.meter";
        }

        private void btnCalPFR_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaPFR.BackColor == Color.LightGreen)
                {
                    //HX floating head type value
                    //Pressure value
                    if (rdb690R.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 4E-5;
                        e1 = -0.0759;
                        f1 = 99.873;
                        CapitalC = 3070.4;
                    }
                    else if (rdb1035R.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 3E-5;
                        e1 = -0.051;
                        f1 = 104.15;
                        CapitalC = 4208.3;
                    }
                    else if (rdb2070R.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 5E-5;
                        e1 = -0.0758;
                        f1 = 125.31;
                        CapitalC = 4608.7;
                    }
                    else if (rdb3105R.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 6E-5;
                        e1 = -0.0867;
                        f1 = 141.35;
                        CapitalC = 4803.5;
                    }
                    else if (rdb6895R.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 7E-5;
                        e1 = -0.102;
                        f1 = 178.16;
                        CapitalC = 5786.4;
                    }
                    //Material factor
                    if (rbdCSCSR.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdbCSCUR.Checked == true)
                    {
                        af = 1.25;
                    }
                    else if (rdbCSSSR.Checked == true)
                    {
                        af = 1.7;
                    }
                    else if (rdbCSNiR.Checked == true)
                    {
                        af = 2.8;
                    }
                    else if (rdbSSSSR.Checked == true)
                    {
                        af = 3;
                    }
                    else if (rdbCSTiR.Checked == true)
                    {
                        af = 7.2;
                    }
                    double sizing_PFR;
                    sizing_PFR = conCal.ConvertArea_Unit(cbbUnitPFR.Text, txtAreaPFR.Text, 9.3, 1000);
                    txtPurchasePFR.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PFR, af, CPI_IndexMain);
                    txtPurchasePFR.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Reactor area fill data is missing.\n\nPlease ensure reactor area value is entered.", "Warning missing reactor area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblHeightVR_Click(object sender, EventArgs e)
        {

        }

        private void btnHelpPFR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Material abbreviation:" + "\n" + "\n" + "CS-Carbon Steel" + "\n" + "CU-Copper" + "\n" 
                + "SS-Stainless Steel" + "\n" + "Ni Alloy-Nickel Alloy" + "\n" + 
                "Ti-Titanium", "Abbreviation Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtAreaVR_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            string message = "The value entered for the reactor height must be a number.";
            string titleMessage = "Warning Invalid Reactor Height Value";
            con.checkNumberTB(txtAreaVR, message, titleMessage);
        }

        private void txtAreaPFR_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);

            string message = "The value entered for the reactor area must be a number.";
            string titleMessage = "Warning Invalid Reactor Area Value";
            con.checkNumberTB(txtAreaPFR, message, titleMessage);
        }

        private void rdbVertical_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdb05VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 1.5 m to 20 m.";
            }
            else if (rdb1VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 2.5 m to 30 m.";
            }
            else if (rdb2VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 4 m to 45 m.";
            }
            else if (rdb3VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 6 m to 50 m.";
            }
            else if (rdb4VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 7 m to 50 m.";
            }
        }

        private void rdbHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdb05VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 1.5 m to 25.4 m.";
            }
            else if (rdb1VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 2.3 m to 30.4 m.";
            }
            else if (rdb2VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 4.3 m to 41.1 m.";
            }
            else if (rdb3VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 6.5 m to 48.7 m.";
            }
            else if (rdb4VR.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 7.9 m to 53.7 m.";
            }
        }

        private void rdbCSVR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdbSSVR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdbNAVR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb05VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdbVertical.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 1.5 m to 20 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 1.5 m to 25.4 m.";
            }
        }

        private void rdb1VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdbVertical.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 2.5 m to 30 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 2.3 m to 30.4 m.";
            }
        }

        private void rdb2VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdbVertical.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 4 m to 45 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 4.3 m to 41.1 m.";
            }
        }

        private void rdb3VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdbVertical.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 6 m to 50 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 6.5 m to 48.7 m.";
            }
        }

        private void rdb4VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);

            if (rdbVertical.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 7 m to 50 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNote.Text = "*The height range for this calculation\n\nis 7.9 m to 53.7 m.";
            }
        }

        private void rdb101VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb1035VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb5000VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb10000VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb20000VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb30000VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rdb40000VR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void cbbUnitVR_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseVR);
        }

        private void rbdCSCSR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdbCSCUR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdbCSSSR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdbCSNiR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdbSSSSR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdbCSTiR_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdb690R_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdb1035R_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdb2070R_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdb3105R_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void rdb6895R_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }

        private void cbbUnitPFR_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchasePFR);
        }    

        private void btnCalVR_Click(object sender, EventArgs e)
        {
            double sizing_PFR, sizing_vessel;
            string CalCost;
            try
            {
                if (txtAreaVR.BackColor == Color.LightGreen)
                {
                    //Pressure factor
                    double pf = 0;
                    if (rdb101VR.Checked == true)
                    {
                        pf = 1;
                    }
                    else if (rdb1035VR.Checked == true)
                    {
                        pf = 1.6;
                    }
                    else if (rdb5000VR.Checked == true)
                    {
                        pf = 3.2;
                    }
                    else if (rdb10000VR.Checked == true)
                    {
                        pf = 4.6;
                    }
                    else if (rdb20000VR.Checked == true)
                    {
                        pf = 8.7;
                    }
                    else if (rdb30000VR.Checked == true)
                    {
                        pf = 12.2;
                    }
                    else if (rdb40000VR.Checked == true)
                    {
                        pf = 15.8;
                    }
                    //Material factor
                    if (rdbCSVR.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdbSSVR.Checked == true)
                    {
                        af = 3;
                    }
                    else if (rdbNAVR.Checked == true)
                    {
                        af = 7.4;
                    }
                    //Reactor Type
                    if (rdbVertical.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        if (rdb05VR.Checked == true)
                        {
                            e1 = 15.401;
                            f1 = 1588.5;
                            CapitalC = 1495.5;
                            min = 1.5;
                            max = 20;
                        }
                        else if (rdb1VR.Checked == true)
                        {
                            e1 = 13.929;
                            f1 = 2028.4;
                            CapitalC = 1850.6;
                            min = 2.5;
                            max = 30;
                        }
                        else if (rdb2VR.Checked == true)
                        {
                            e1 = 3.011;
                            f1 = 3139.4;
                            CapitalC = 7166.9;
                            min = 4;
                            max = 45;
                        }
                        else if (rdb3VR.Checked == true)
                        {
                            e1 = -23.555;
                            f1 = 5119.4;
                            CapitalC = 10945;
                            min = 6;
                            max = 50;
                        }
                        else if (rdb4VR.Checked == true)
                        {
                            e1 = -49.723;
                            f1 = 5021.1;
                            CapitalC = 24285;
                            min = 7;
                            max = 50;
                        }
                        sizing_PFR = conCal.ConvertHeight_Unit(cbbUnitVR.Text, txtAreaVR.Text, min, max);
                        CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PFR, af, CPI_IndexMain);
                        txtPurchaseVR.Text = (Convert.ToDouble(CalCost) * pf).ToString("#,##0.##");
                        txtPurchaseVR.BackColor = Color.LightGreen;
                    }
                    else if (rdbHorizontal.Checked == true)
                    {
                        if (rdb05VR.Checked == true)
                        {
                            alpha = 931.22;
                            beta = 0.6861;
                            min = 1.5;
                            max = 25.4;
                        }
                        else if (rdb1VR.Checked == true)
                        {
                            alpha = 1461;
                            beta = 0.8025;
                            min = 2.3;
                            max = 30.4;
                        }
                        else if (rdb2VR.Checked == true)
                        {
                            alpha = 2743;
                            beta = 0.5107;
                            min = 4.3;
                            max = 41.1;
                        }
                        else if (rdb3VR.Checked == true)
                        {
                            alpha = 4100;
                            beta = 0.8297;
                            min = 6.5;
                            max = 48.7;
                        }
                        else if (rdb4VR.Checked == true)
                        {
                            alpha = 5191;
                            beta = 0.8268;
                            min = 7.9;
                            max = 53.7;
                        }
                        sizing_vessel = conCal.ConvertHeight_Unit(cbbUnitVR.Text, txtAreaVR.Text, min, max);
                        CalCost = conCal.PurchaseCost(alpha, beta, sizing_vessel, af, CPI_IndexMain);
                        txtPurchaseVR.Text = (Convert.ToDouble(CalCost) * pf).ToString("#,##0.##");
                        txtPurchaseVR.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    MessageBox.Show("Reactor height fill data is missing.\n\nPlease ensure reactor height value is entered.", "Warning missing reactor height value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }               

        private void btnDoneVR_Click(object sender, EventArgs e)
        {
            if (txtPurchaseVR.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaVR.Text;
                string sizing_unit = cbbUnitVR.Text;
                string[] Material = { "Carbon steel", "316 Stainless steel", "Nickel alloy" };
                string material = con.Select3Material(Material, rdbCSVR, rdbSSVR, rdbNAVR);
                string PurchaseCost = txtPurchaseVR.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDonePFR_Click(object sender, EventArgs e)
        {
            if (txtPurchasePFR.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaPFR.Text;
                string sizing_unit = cbbUnitPFR.Text;
                string[] Material = { "CS shell and CS tube", "CS shell and CU tube", "CS shell and SS tube", "CS shell and Ni alloy tube", "SS shell and SS tube", "CS shell and Ti tube" };
                string material = con.Select6Material(Material, rbdCSCSR, rdbCSCUR, rdbCSSSR, rdbCSNiR, rdbSSSSR, rdbCSTiR);
                string PurchaseCost = txtPurchasePFR.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A \"Reactor Page\" in this software, designed for users to calculate the price of " +
                "a reactor based on reactor data input of reactor type, material, pressure, height and area.", "Reactor Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

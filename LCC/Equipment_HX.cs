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
    public partial class Equipment_HX: Form
    {
        string equipNameMain;
        double CPI_IndexMain;
        Function con;
        Function_Calculation conCal;
        Define_Product_LCPlus _word;
        public Equipment_HX(string equipName, double CPI_Index, Define_Product_LCPlus word)
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

        private void Equipment_HX_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtEquipName.Text = equipNameMain;

            //Heat Exchanger
            
            ////Air Cooled
            rdbCSAirCooled.Checked = true;
            cbbUnitAirCooled.Text = "sq.meter";
            ////Double pipe
            rdbCSTS.Checked = true;
            rdb4135Double.Checked = true;
            cbbDoubleUnit.Text = "sq.meter";
            ////Multi pipe
            rdbCSMulti.Checked = true;
            rdb4135Multi.Checked = true;
            cbbUnitMulti.Text = "sq.meter";
            ////Shell and Tube, Fixed Tube
            rdbCS_FT.Checked = true;
            rdb1035FT.Checked = true;
            cbbType_FT.Text = "Tube";
            cbbUnitFT.Text = "sq.meter";
            ////Shell and Tube, U Tube
            rdbCSU.Checked = true;
            rdb1035U.Checked = true;
            cbbTypeU.Text = "Tube";
            cbbUnitU.Text = "sq.meter";
            ////Shell and Tube, Floating Head
            rdbCSCS.Checked = true;
            rdb690FH.Checked = true;
            cbbUnitFH.Text = "sq.meter";
        }

        private void txtAreaAirCooled_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtAreaAirCooled, message, titleMessage);
        }

        private void txtDoubleArea_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtDoubleArea, message, titleMessage);
        }

        private void txtAreaMulti_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtAreaMulti, message, titleMessage);
        }

        private void txtAreaFT_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtAreaFT, message, titleMessage);
        }

        private void txtAreaU_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtAreaU, message, titleMessage);
        }

        private void txtAreaFH_TextChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);

            string message = "The value entered for the area must be a number.";
            string titleMessage = "Warning Invalid Area Value";
            con.checkNumberTB(txtAreaFH, message, titleMessage);
        }

        private void btnHelpFH_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Material abbreviation:" + "\n" + "\n" + "CS-Carbon Steel" + "\n" + "CU-Copper" + "\n"
                + "SS-Stainless Steel" + "\n" + "Ni Alloy-Nickel Alloy" + "\n" +
                "Ti-Titanium", "Abbreviation Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rdbCSAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void rdbSSAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void rdbTiAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void rdbCAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void rdbNAAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void cbbUnitAirCooled_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseAC);
        }

        private void rdbCSTS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);

            lblNoteDP.Text = "*The area range for this calculation\n\nis 0.232 m2 to 29.3 m2.";
        }

        private void rdbATCSS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);

            lblNoteDP.Text = "*The area range for this calculation\n\nis 0.232 m2 to 19.3 m2.";
        }

        private void rdbSSTCSS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);

            lblNoteDP.Text = "*The area range for this calculation\n\nis 0.232 m2 to 14.3 m2.";
        }

        private void rdb4135Double_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void rdb6205Double_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void rdb10340Double_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void rdb20680Double_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void rdb30000Double_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void cbbDoubleUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseDP);
        }

        private void rdbCSMulti_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdbATMulti_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdbSSMulti_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdb4135Multi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdb6205Multi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdb10340Multi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdb20680Multi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdb30000Multi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void cbbUnitMulti_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseMP);
        }

        private void rdbCS_FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb304SS_FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb316SS_FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void cbbType_FT_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb1035FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb5000FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb10000FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdb15000FT_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void cbbUnitFT_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseFT);
        }

        private void rdbCSU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);

            lblNoteSTU.Text = "*The area range for this calculation\n\nis 2.79 m2 to 440 m2.";
        }

        private void rdbSSU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);

            lblNoteSTU.Text = "*The area range for this calculation\n\nis 2.79 m2 to 352 m2.";
        }

        private void cbbTypeU_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void rdb1035U_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void rdb5000U_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void rdb10000U_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void rdb15000U_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void cbbUnitU_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseU);
        }

        private void rdbCSCS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdbCSCU_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdbCSSS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdbCSNi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdbSSSS_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdbCSTi_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdb690FH_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdb1035FH_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdb2070FH_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdb3105FH_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void rdb6895FH_CheckedChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void cbbUnitFH_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.tbNullVal(txtPurchaseSTF);
        }

        private void btnCalAC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaAirCooled.BackColor == Color.LightGreen)
                {
                    alpha = 3788;
                    beta = 0.4216;
                    if (rdbCSAirCooled.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdbCAirCooled.Checked == true)
                    {
                        af = 1.2;
                    }
                    else if (rdbSSAirCooled.Checked == true)
                    {
                        af = 2.3;
                    }
                    else if (rdbNAAirCooled.Checked == true)
                    {
                        af = 2.8;
                    }
                    else if (rdbTiAirCooled.Checked == true)
                    {
                        af = 7.2;
                    }
                    double sizing_AirCooled;
                    sizing_AirCooled = conCal.ConvertArea_Unit(cbbUnitAirCooled.Text, txtAreaAirCooled.Text, 3.3, 11000);
                    txtPurchaseAC.Text = conCal.PurchaseCost(alpha, beta, sizing_AirCooled, af, CPI_IndexMain);
                    txtPurchaseAC.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalDP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDoubleArea.BackColor == Color.LightGreen)
                {
                    //HX Double pipe type value
                    if (rdbCSTS.Checked == true)
                    {
                        alpha = 1039.3;
                        beta = 0.0635;
                    }
                    else if (rdbATCSS.Checked == true)
                    {
                        alpha = 1300.2;
                        beta = 0.0746;
                    }
                    else if (rdbSSTCSS.Checked == true)
                    {
                        alpha = 1959.9;
                        beta = 0.0699;
                    }

                    //Pressure value
                    if (rdb4135Double.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdb6205Double.Checked == true)
                    {
                        af = 1.1;
                    }
                    else if (rdb10340Double.Checked == true)
                    {
                        af = 1.3;
                    }
                    else if (rdb20680Double.Checked == true)
                    {
                        af = 2;
                    }
                    else if (rdb30000Double.Checked == true)
                    {
                        af = 3;
                    }
                    double sizing_DoublePipe;
                    sizing_DoublePipe = conCal.ConvertArea_Unit(cbbDoubleUnit.Text, txtDoubleArea.Text, 0.232, 29.3);
                    if (rdbATCSS.Checked == true)
                    {
                        sizing_DoublePipe = conCal.ConvertArea_Unit(cbbDoubleUnit.Text, txtDoubleArea.Text, 0.232, 19.3);
                    }
                    else if (rdbSSTCSS.Checked == true)
                    {
                        sizing_DoublePipe = conCal.ConvertArea_Unit(cbbDoubleUnit.Text, txtDoubleArea.Text, 0.232, 14.3);
                    }
                    txtPurchaseDP.Text = conCal.PurchaseCost(alpha, beta, sizing_DoublePipe, af, CPI_IndexMain);
                    txtPurchaseDP.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalMP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaMulti.BackColor == Color.LightGreen)
                {
                    //HX Multi pipe type value
                    if (rdbCSMulti.Checked == true)
                    {
                        alpha = 129.79;
                        beta = 0.9711;
                    }
                    else if (rdbATMulti.Checked == true)
                    {
                        alpha = 154.47;
                        beta = 0.9759;
                    }
                    else if (rdbSSMulti.Checked == true)
                    {
                        alpha = 230.05;
                        beta = 0.9666;
                    }

                    //Pressure value
                    if (rdb4135Multi.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdb6205Multi.Checked == true)
                    {
                        af = 1.1;
                    }
                    else if (rdb10340Multi.Checked == true)
                    {
                        af = 1.3;
                    }
                    else if (rdb20680Multi.Checked == true)
                    {
                        af = 2;
                    }
                    else if (rdb30000Multi.Checked == true)
                    {
                        af = 3;
                    }
                    double sizing_MultiPipe;
                    sizing_MultiPipe = conCal.ConvertArea_Unit(cbbUnitMulti.Text, txtAreaMulti.Text, 10, 200);
                    txtPurchaseMP.Text = conCal.PurchaseCost(alpha, beta, sizing_MultiPipe, af, CPI_IndexMain);
                    txtPurchaseMP.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalFT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaFT.BackColor == Color.LightGreen)
                {
                    //HX Fixed Tube pipe type value
                    if (rdbCS_FT.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        e1 = 0;
                        f1 = 59.628;
                        CapitalC = 4071.2;
                    }
                    else if (rdb304SS_FT.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        e1 = 0;
                        f1 = 123.52;
                        CapitalC = 3380.2;
                    }
                    else if (rdb316SS_FT.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 0;
                        e1 = 0;
                        f1 = 165.06;
                        CapitalC = 3154;
                    }
                    //Pressure value
                    if (cbbType_FT.Text == "Tube")
                    {
                        if (rdb1035FT.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdb5000FT.Checked == true)
                        {
                            af = 1.07;
                        }
                        else if (rdb10000FT.Checked == true)
                        {
                            af = 1.10;
                        }
                        else if (rdb15000FT.Checked == true)
                        {
                            af = 1.12;
                        }
                    }
                    else
                    {
                        if (rdb1035FT.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdb5000FT.Checked == true)
                        {
                            af = 1.16;
                        }
                        else if (rdb10000FT.Checked == true)
                        {
                            af = 1.24;
                        }
                        else if (rdb15000FT.Checked == true)
                        {
                            af = 1.31;
                        }
                    }
                    double sizing_FixedTube;
                    sizing_FixedTube = conCal.ConvertArea_Unit(cbbUnitFT.Text, txtAreaFT.Text, 3.52, 635);
                    txtPurchaseFT.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_FixedTube, af, CPI_IndexMain);
                    txtPurchaseFT.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalU_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaU.BackColor == Color.LightGreen)
                {
                    //HX U Tube pipe type value
                    if (rdbCSU.Checked == true)
                    {
                        a1 = -2E-11;
                        b1 = 3E-8;
                        c1 = -2E-5;
                        d1 = 0.0052;
                        e1 = -0.7456;
                        f1 = 139.58;
                        CapitalC = 1975;
                    }
                    else if (rdbSSU.Checked == true)
                    {
                        a1 = -2E-10;
                        b1 = 2E-7;
                        c1 = -9E-5;
                        d1 = 0.0192;
                        e1 = -2.0939;
                        f1 = 302.37;
                        CapitalC = 2420.1;
                    }
                    //Pressure value
                    if (cbbTypeU.Text == "Tube")
                    {
                        if (rdb1035U.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdb5000U.Checked == true)
                        {
                            af = 1.07;
                        }
                        else if (rdb10000U.Checked == true)
                        {
                            af = 1.10;
                        }
                        else if (rdb15000U.Checked == true)
                        {
                            af = 1.12;
                        }
                    }
                    else
                    {
                        if (rdb1035U.Checked == true)
                        {
                            af = 1;
                        }
                        else if (rdb5000U.Checked == true)
                        {
                            af = 1.16;
                        }
                        else if (rdb10000U.Checked == true)
                        {
                            af = 1.24;
                        }
                        else if (rdb15000U.Checked == true)
                        {
                            af = 1.31;
                        }
                    }
                    double sizing_UTube;
                    sizing_UTube = conCal.ConvertArea_Unit(cbbUnitU.Text, txtAreaU.Text, 2.79, 440);
                    if (rdbSSU.Checked == true)
                    {
                        sizing_UTube = conCal.ConvertArea_Unit(cbbUnitU.Text, txtAreaU.Text, 2.79, 352);
                    }
                    txtPurchaseU.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_UTube, af, CPI_IndexMain);
                    txtPurchaseU.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalSTF_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAreaFH.BackColor == Color.LightGreen)
                {
                    //HX floating head type value
                    //Pressure value
                    if (rdb690FH.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 4E-5;
                        e1 = -0.0759;
                        f1 = 99.873;
                        CapitalC = 3070.4;
                    }
                    else if (rdb1035FH.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 3E-5;
                        e1 = -0.051;
                        f1 = 104.15;
                        CapitalC = 4208.3;
                    }
                    else if (rdb2070FH.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 5E-5;
                        e1 = -0.0758;
                        f1 = 125.31;
                        CapitalC = 4608.7;
                    }
                    else if (rdb3105FH.Checked == true)
                    {
                        a1 = 0;
                        b1 = 0;
                        c1 = 0;
                        d1 = 6E-5;
                        e1 = -0.0867;
                        f1 = 141.35;
                        CapitalC = 4803.5;
                    }
                    else if (rdb6895FH.Checked == true)
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
                    if (rdbCSCS.Checked == true)
                    {
                        af = 1;
                    }
                    else if (rdbCSCU.Checked == true)
                    {
                        af = 1.25;
                    }
                    else if (rdbCSSS.Checked == true)
                    {
                        af = 1.7;
                    }
                    else if (rdbCSNi.Checked == true)
                    {
                        af = 2.8;
                    }
                    else if (rdbSSSS.Checked == true)
                    {
                        af = 3;
                    }
                    else if (rdbCSTi.Checked == true)
                    {
                        af = 7.2;
                    }
                    double sizing_FH;
                    sizing_FH = conCal.ConvertArea_Unit(cbbUnitFH.Text, txtAreaFH.Text, 9.3, 1000);
                    txtPurchaseSTF.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_FH, af, CPI_IndexMain);
                    txtPurchaseSTF.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Area fill data is missing.\n\nPlease ensure area value is entered.", "Warning missing area value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Warning Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneSTF_Click(object sender, EventArgs e)
        {
            if (txtPurchaseSTF.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaFH.Text;
                string sizing_unit = cbbUnitFH.Text;
                string[] Material = { "CS shell and CS tube", "CS shell and CU tube", "CS shell and SS tube", "CS shell and Ni alloy tube", "SS shell and SS tube", "CS shell and Ti tube" };
                string material = con.Select6Material(Material, rdbCSCS, rdbCSCU, rdbCSSS, rdbCSNi, rdbSSSS, rdbCSTi);
                string PurchaseCost = txtPurchaseSTF.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneAC_Click(object sender, EventArgs e)
        {
            if (txtPurchaseAC.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaAirCooled.Text;
                string sizing_unit = cbbUnitAirCooled.Text;
                string[] Material = { "Carbon Steel", "Stainless Steel", "Titanium", "Copper", "Nickel Alloy" };
                string material = con.Select5Material(Material, rdbCSAirCooled, rdbSSAirCooled, rdbTiAirCooled, rdbCAirCooled, rdbNAAirCooled);
                string PurchaseCost = txtPurchaseAC.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneDP_Click(object sender, EventArgs e)
        {
            if (txtPurchaseDP.BackColor == Color.LightGreen)
            {
                string sizing = txtDoubleArea.Text;
                string sizing_unit = cbbDoubleUnit.Text;
                string[] Material = { "Carbon Steel tube and shell", "Admiralty tube and Carbon Steel shell", "Stainless Steel tube and Carbon Steel shell" };
                string material = con.Select3Material(Material, rdbCSTS, rdbATCSS, rdbSSTCSS);
                string PurchaseCost = txtPurchaseDP.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneMP_Click(object sender, EventArgs e)
        {
            if (txtPurchaseMP.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaMulti.Text;
                string sizing_unit = cbbUnitMulti.Text;
                string[] Material = { "Carbon Steel tube and shell", "Admiralty tube and Carbon Steel shell", "Stainless Steel tube and Carbon Steel shell" };
                string material = con.Select3Material(Material, rdbCSMulti, rdbATMulti, rdbSSMulti);
                string PurchaseCost = txtPurchaseMP.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneFT_Click(object sender, EventArgs e)
        {
            if (txtPurchaseFT.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaFT.Text;
                string sizing_unit = cbbUnitFT.Text;
                string[] Material = { "Carbon Steel", "304 Stainless Steel", "316 Stainless Steel" };
                string material = con.Select3Material(Material, rdbCS_FT, rdb304SS_FT, rdb316SS_FT);
                string PurchaseCost = txtPurchaseFT.Text;

                //Return value to datagridview in Define_Product_LCPlus page
                _word.UpdateCost(sizing, sizing_unit, material, PurchaseCost);
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no value for the purchase cost.\n\nPlease click the  \"Calculate\" button first to obtain the result.", "Warning no purchase cost result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoneU_Click(object sender, EventArgs e)
        {
            if (txtPurchaseU.BackColor == Color.LightGreen)
            {
                string sizing = txtAreaU.Text;
                string sizing_unit = cbbUnitU.Text;
                string[] Material = { "Carbon Steel", "Stainless Steel"};
                string material = con.Select2Material(Material, rdbCSU, rdbSSU);
                string PurchaseCost = txtPurchaseU.Text;

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
            MessageBox.Show("A \"Heat Exchanger Page\" in this software, designed for users to calculate the price of " +
               "a heat exchanger based on heat exchanger data input.", "Heat Exchanger Page Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

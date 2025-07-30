using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace LCC
{
    public partial class Form1 : Form
    {
        Function con;
        Function_Calculation conCal;
        Function_SaveOpen conSP;
        Function_Excel conEx;
        string strDirectory = Application.StartupPath + "\\";
        public Form1()
        {
            InitializeComponent();
            con = new Function();
            conCal = new Function_Calculation();
            conSP = new Function_SaveOpen();
            conEx = new Function_Excel();
        }
        //List for Stream Table import
        List<string> StreamName = new List<string>();
        List<string> ComponentName = new List<string>();

        //List for Equipment Table import
        List<string> EquipmentName = new List<string>();
        List<string> EquipmentDuty = new List<string>();
        List<string> EquipmentUnit = new List<string>();
        List<string> ColumnName = new List<string>();
        List<string> ColumnDuty = new List<string>();
        List<string> ColumnUnit = new List<string>();

        //List for Feedstock Cost
        List<string> input_FS = new List<string>();
        List<string> inputValue_FS = new List<string>();
        List<string> output_FS = new List<string>();

        //List for Operating Cost
        List<string> stream_OPC = new List<string>();
        List<int> Findstream_OPC = new List<int>();

        //List for By Product credit 
        List<int> FindOutputStream = new List<int>();
        List<int> FindRowStream = new List<int>();
        List<string> MainProductCredit = new List<string>();
        List<string> SideProductCredit = new List<string>();
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string Journal_Name = "Engineering";
            string Publication_Year = " (2023)";
            string Volume = " 68,";
            string page = " e17469,";
            string DOI = " DOI: 10.1002/aic.17469.";
            DialogResult dialogresult = MessageBox.Show("Copyright (C) PSE for SPEED Co., Ltd." +
                "\n" + "\n" + "COSMO-SAC software incorporates the following three functionalities:" +
                "\n" + "\n" + "1. Vapor-liquid equilibrium (VLE) calculation: COSMO-SAC software possesses the capability to predict VLE by employing compound sigma profiles. This allows for accurate estimation of the distribution of components between vapor and liquid phases." +
                "\n" + "\n" + "2. Vapor pressure prediction: COSMO-SAC can calculate the vapor pressure of a chosen compound with high accuracy. This feature is valuable for understanding its volatility and potential for evaporation." +
                "\n" + "\n" + "3. Activity coefficient calculation: COSMO-SAC enables the determination of the activity coefficient (gamma) of a selected compound, both at single-point conditions and across various concentration levels (multiple points). This provides insights into the non-ideal behavior of the compound within a mixture." +
                "\n" + "\n" + "Reference:" + "\n" + "Alshehri, A.S.; Tula, A.K.; You, F.; Gani, R. Next generation pure component property estimation models: With and without machine learning techniques. " + Journal_Name + Publication_Year + Volume + page + DOI +
                "\n" + "\n" + "Would you like to open the paper?", "About COSMO-SAC Software", MessageBoxButtons.YesNo, MessageBoxIcon.Information); 
            if (dialogresult == DialogResult.Yes)
            {
                string Manuscriptpdf = strDirectory + "Reference\\Manuscript.pdf";
                Process.Start(Manuscriptpdf);
            }*/
            MessageBox.Show("Copyright (C) PSE for SPEED Co., Ltd." +
                "\n" + "\n" + "PSE for SPEED company's Life Cycle Cost (LCC) software, version 1.0, is a computer program designed to assist users in evaluating the total cost of ownership for a plant over its operational lifespan. " +
                "\n" + "\n" + "By analyzing these costs, the software can help users make informed decisions regarding plant design, equipment selection, and maintenance strategies.", "About LCC Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Manuscriptpdf = strDirectory + "Reference\\User_manual.pdf";
            Process.Start(Manuscriptpdf);
        }
        
        private void btnBrowse_FS_Click(object sender, EventArgs e)
        {            
            try
            {
                txtSearch_rawData.Text = con.SearchExcelfile();
            }
            catch
            {
                MessageBox.Show("Program cannot find. Please ensure you seleted the excel file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
        private void btnAdd_FS_Click(object sender, EventArgs e)
        {
            if (txtSearch_rawData.Text != "")
            {
                if (txtAmount_FS.Text != "")
                {
                    if (con.CheckAmount(txtAmount_FS.Text))
                    {
                        input_FS.Clear();
                        inputValue_FS.Clear();
                        output_FS.Clear();
                        string filePath = txtSearch_rawData.Text;
                        string sheetName = "X-Exchange";
                        int count_row = dgvRawMat_FS.Rows.Count;
                        int newRow = count_row - 1;
                        //Read Excel file and Extract data
                        if (CheckTransport == "yes")
                        {
                            con.ReadCellData_withTransport(input_FS, inputValue_FS, output_FS, filePath, sheetName);
                        }
                        else if (CheckTransport == "no")
                        {
                            con.ReadCellData(input_FS, inputValue_FS, output_FS, filePath, sheetName);
                        }                           
                        //Show data in datagridview
                        if (count_row <= 1)
                        {                         
                            for (int i = 0; i < input_FS.Count; i++)
                            {
                                dgvRawMat_FS.Rows.Add();
                            }
                            for (int i = 0; i < input_FS.Count; i++)
                            {
                                dgvRawMat_FS.Rows[i].Cells[3].Value = input_FS[i];
                                dgvRawMat_FS.Rows[i].Cells[4].Value = Convert.ToDouble(inputValue_FS[i]) * Convert.ToDouble(txtAmount_FS.Text);
                            }
                            dgvRawMat_FS.Rows[0].Cells[1].Value = txtAmount_FS.Text;
                            dgvRawMat_FS.Rows[0].Cells[0].Value = output_FS[0];
                            dgvRawMat_FS.Rows[0].Cells[2].Value = output_FS[1];
                        }
                        else
                        {                     
                            for (int i = 0; i < input_FS.Count; i++)
                            {
                                dgvRawMat_FS.Rows.Add();
                            }
                            for (int i = 0; i < input_FS.Count; i++)
                            {
                                dgvRawMat_FS.Rows[i + newRow].Cells[3].Value = input_FS[i];
                                dgvRawMat_FS.Rows[i + newRow].Cells[4].Value = Convert.ToDouble(inputValue_FS[i]) * Convert.ToDouble(txtAmount_FS.Text);
                            }
                            dgvRawMat_FS.Rows[0 + newRow].Cells[1].Value = txtAmount_FS.Text;
                            dgvRawMat_FS.Rows[0 + newRow].Cells[0].Value = output_FS[0];
                            dgvRawMat_FS.Rows[0 + newRow].Cells[2].Value = output_FS[1];
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please ensure that the amount of material is correct, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    //set column Alignment
                    string[] columnName = { "Column2", "Column4", "Column5", "Column6", "Column7" };
                    for (int i = 0; i < columnName.Length; i++)
                    {
                        dgvRawMat_FS.Columns[columnName[i]].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    //dgvRawMat_FS.AutoResizeColumns();
                    //dgvRawMat_FS.Columns["Column2"].Width = 100;
                    //dgvRawMat_FS.Columns["Column7"].Width = 90;
                    
                    /*try
                    {

                    }
                    catch
                    {
                        MessageBox.Show("Program cannot find. Please ensure you seleted the excel file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
                else
                {
                    MessageBox.Show("Please add the amount of material, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Program cannot find. Please ensure you seleted the excel file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_FS_Click(object sender, EventArgs e)
        {
            input_FS.Clear();
            inputValue_FS.Clear();
            output_FS.Clear();
            dgvRawMat_FS.Rows.Clear();
            //dgvRawMat_FS.Columns.Clear();
            //MessageBox.Show(dgvRawMat_FS.Rows.Count.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtAmount_FS.Text = "1";
            txtNumHour_OpC.Text = "2088";
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRawMat_FS.ColumnHeadersDefaultCellStyle = style;
            //Capital Cost
            cbbProcessCap.Text = "Fluid processing";
            //Salvage Cost
            rdbCustomSV.Checked = true;
            //Operating Cost
            rdbMixtureFeed.Checked = true;
            txtOverallFeed.Text = "Product1";
            txtOverallFeed.Enabled = false;
            //Maintenanace Cost
            gbSpecific_MC.Enabled = false;
            gbPercent_MC.Enabled = false;
            txtInterestRate.Text = "5";
            txtPeriod.Text = "10";            
            //Feedstock Cost
            rdbWithTransport.Checked = true;         
            //Define Equipment
            txtCPI_Index.Text = "521";
            //Compressor
            rdbCent_Motor.Checked = true;
            rdbCarbon_Comp.Checked = true;
            cbbPowerCompUnit.Text = "kW";
            cbbUnitPresssureComp.Text = "kPa";
            //Cooling Tower
            rdb33AppCooling.Checked = true;
            rdb55TempRCooling.Checked = true;
            cbbUnitCooling.Text = "cubic meter (m3)/s";
            //Direct-fired Heater
            rdbCS690.Checked = true;
            cbbUnitDireactHeater.Text = "kW";
            //Drive
            rdbExplosion.Checked = true;
            cbbUnitDrive.Text = "kW";
            //Furnance
            rdb3450Furnance.Checked = true;
            cbbUnitFurnance.Text = "kW";
            //Mixer
            rdbCSMixer.Checked = true;
            cbbUnitMixer.Text = "cubic meter (m3)";
            cbbUnit2Mixer.Text = "kW";
            //Pump
            rdbCentifugalP.Checked = true;
            rdbCastIronPump.Checked = true;
            rdb1035.Checked = true;
            cbbUnitPump.Text = "cubic meter (m3)/s";           
            //Pump include drive
            cbbUnitPumpDrive.Text = "cubic meter (m3)/s * kPa";
            cbbUnit2PumpDrive.Text = "kW";
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
            tabReactor.Enabled = false;
            cbbUnitPFR.Text = "sq.meter";
            //Storage
            rdbSpherical.Checked = true;
            rdbCSStorage.Checked = true;
            cbbUnitStorage.Text = "cubic meter (m3)";
            //Turbine
            rdbCSTurbine.Checked = true;
            cbbUnitTurbine.Text = "kW";
            //Heat Exchanger
            tabHeatExType.Enabled = false;
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
            //Tower Unit
            rdbCSTU.Checked = true;
            rdb05TU.Checked = true;
            rdb101TU.Checked = true;
            rdbCSST.Checked = true;
            cbbUnitTU.Text = "meters";
            cbbUnitTTU.Text = "meters";
            gbTrayTU.Enabled = false;
            //Add Other
            cbbUtilityOther.Text = "Electricity";
            cbbUnitOther.Text = "kW";
            //Select Type
            cbbTypeOfEquip.Text = "Select type of equipment";
            //ECON evaluate
            txtCIR.Text = "7";
            txtPPIR.Text = "7";
            txtTIR.Text = "7";
            txtMar.Text = "15";
            txtRma.Text = "0.1397764";
            txtTax.Text = "35";
            cbbDepreciationType.Text = "Straight Line";
            nudYearDepreciation.Text = "10";
            nudProjectLifeTime.Text = "10";
            double LandInvest = 20000000;
            txtLandCostInvestment.Text = LandInvest.ToString("#,##0.##");
        }

        private void btnCal_FS_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvRawMat_FS.Rows.Count - 1; i++)
            {
                if (dgvRawMat_FS.Rows[i].Cells[5].Value == null || dgvRawMat_FS.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dgvRawMat_FS.Rows[i].Cells[5].Value = "-";
                    dgvRawMat_FS.Rows[i].Cells[6].Value = "-";
                }
                else if (dgvRawMat_FS.Rows[i].Cells[5].Value.ToString() == "-")
                {                  
                    dgvRawMat_FS.Rows[i].Cells[6].Value = "-";
                }
                else
                {                    
                    try
                    {
                       
                        dgvRawMat_FS.Rows[i].Cells[6].Value = (Convert.ToDouble(dgvRawMat_FS.Rows[i].Cells[4].Value.ToString()) * Convert.ToDouble(dgvRawMat_FS.Rows[i].Cells[5].Value.ToString())).ToString("#,##0.##");
                        
                    }
                    catch
                    {
                        MessageBox.Show("Please kindly ensure the material costs are correctly reflected in row " + (i + 1).ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                }
            }
            double sum = 0;
            double InterestRateCal;
            InterestRateCal = con.Cal_InterestRate(txtInterestRate.Text, txtPeriod.Text);           
            for (int i = 0; i < dgvRawMat_FS.Rows.Count - 1; i++)
            {
                try
                {
                    sum += Convert.ToDouble(dgvRawMat_FS.Rows[i].Cells[6].Value);
                    txtTotal_FS.Text = (sum / InterestRateCal).ToString("#,##0.##");
                }
                catch
                {
                    txtTotal_FS.Text = (sum / InterestRateCal).ToString("#,##0.##");
                    continue;
                }
            }                
        }     
               
        private void btnDone_FS_Click(object sender, EventArgs e)
        {
            if (txtTotal_FS.Text == "")
            {
                txtTotal_FS.Text = "0";
            }
            btnFeedstockCost.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }

        private void btnDone_CC_Click(object sender, EventArgs e)
        {
            if (txtTotal_CC.Text == "")
            {
                txtTotal_CC.Text = "0";
            }
            btnCapitalCost.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }
        
        private void btnImport_Stream_Click(object sender, EventArgs e)
        {
            dgvStreamTablePreview.Columns.Clear();
            dgvStreamTablePreview.Rows.Clear();
            string filePath = con.SearchExcelfile();
            
            string sheetName = "Mass Balance";
            try
            {
                if (con.CheckExcel_ImportFile(filePath, sheetName, "Stream Name"))
                {
                    //Show file name in Textbox
                    txtStreamtable_OpC.Text = filePath;
                    txtStreamtable_OpC.ReadOnly = true;
                    txtProductFile.Text = filePath;
                    txtProductFile.ReadOnly = true;
                    //Collect stream name and component name into the list
                    StreamName.Clear();
                    ComponentName.Clear();                                     
                    //Collect Raw data of Stream Table
                    con.ReadExcelStreamData(dgvStreamTablePreview, filePath, sheetName);
                    con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
                    btnImport_Stream.BackColor = Color.LightGreen;

                }
                else
                {
                    MessageBox.Show("Please ensure you seleted the Stream Table file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you seleted the Stream Table file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDone_MC_Click(object sender, EventArgs e)
        {
            if (txtTotalMaintenance.Text == "")
            {
                txtTotalMaintenance.Text = "0";
            }
            btnMaintenanceCost.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }

        private void btnDone_SV_Click(object sender, EventArgs e)
        {
            if (txtTotal_SV.Text == "")
            {
                txtTotal_SV.Text = "0";
            }
            btnSalvageValue.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }

        private void btnDone_BPC_Click(object sender, EventArgs e)
        {
            if (txtTotal_PC.Text == "")
            {
                txtTotal_PC.Text = "0";
            }
            btnProductCredit.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }
        string ProjectName = "";
        private void btnDefinePJName_Click(object sender, EventArgs e)
        {           
            string[] symbol = { @"\<", @"\>", @"\?", @"\[", @"\]", @"\:", @"\|", @"\*", @"\\", @"\/" };
            if (txtProjectName.Text != "")
            {              
                for (int i = 0; i < symbol.Length; i++)
                {
                    Match m = Regex.Match(@txtProjectName.Text, symbol[i]);
                    if (m.Success)
                    {
                        btnDefinePJName.BackColor = Color.Transparent;
                        btnEditPJName.BackColor = Color.Transparent;
                        txtProjectName.ReadOnly = false;
                        MessageBox.Show(@"The project name cannot allow to use any of the following character: <, >, ?, [, ], :, /, \ and *", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        break;                       
                    }
                    else
                    {
                        ProjectName = @txtProjectName.Text;
                        btnDefinePJName.BackColor = Color.LightGreen;
                        btnEditPJName.BackColor = Color.LightBlue;
                        txtProjectName.ReadOnly = true;
                    }
                }              
            }
            else
            {
                MessageBox.Show("Please type the Project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEditPJName_Click(object sender, EventArgs e)
        {
            ProjectName = "";
            txtProjectName.Text = "";
            btnDefinePJName.BackColor = Color.Transparent;
            btnEditPJName.BackColor = Color.Transparent;
            txtProjectName.ReadOnly = false;
        }

        private void btnImport_Equipment_Click(object sender, EventArgs e)
        {
            dgvEquipmentPreview.Columns.Clear();
            dgvEquipmentPreview.Rows.Clear();
            
            string filePath = con.SearchExcelfile();
            string sheetName = "Unit Operation Property";

            //Add column Name
            string[] EquipmentHeader = { "Equipment Name", "Type of Equipment", "Duty/Work", "Unit",  "Energy source", "Sizing", "Sizing Unit", "Material", "Purchase Cost ($)" };
            con.HeaderTable(dgvEquipmentSummary, EquipmentHeader);
            
            try
            {
                if (con.CheckExcel_ImportFile(filePath, sheetName, "Unit Operation Summary"))
                {
                    //Show file name in Textbox
                    txtEquipmentFile.Text = filePath;
                    txtEquipmentFile.ReadOnly = true;

                    //Show original equipment table
                    con.ReadExcelEqipmentData(dgvEquipmentPreview, filePath, sheetName);
                    dgvEquipmentPreview.AutoResizeColumns();
                    dgvEquipmentPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    //Add Pump to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Pump Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
                    con.AddDataToTable(dgvEquipmentSummary, "Pump", EquipmentName, EquipmentDuty, EquipmentUnit);
                    //Add Conpressor to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Compressor Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
                    con.AddDataToTable(dgvEquipmentSummary, "Compressor", EquipmentName, EquipmentDuty, EquipmentUnit);
                    //Add Reactor to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "ConReactor Name", 3, EquipmentName, EquipmentDuty, EquipmentUnit);
                    con.AddDataToTable(dgvEquipmentSummary, "Reactor", EquipmentName, EquipmentDuty, EquipmentUnit);
                    //Add Flash to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Flash Name", 4, EquipmentName, EquipmentDuty, EquipmentUnit);
                    con.AddDataToTable(dgvEquipmentSummary, "Flash", EquipmentName, EquipmentDuty, EquipmentUnit);
                    //Add Heat Exchanger to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Hx Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
                    con.AddDataToTable(dgvEquipmentSummary, "Heat Exchanger", EquipmentName, EquipmentDuty, EquipmentUnit);
                    //Add Column-Condenser and Column-Reboiler to Table
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);                                      
                    con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 2, ColumnName, ColumnDuty, ColumnUnit);
                    con.AddColumnToTable(dgvEquipmentSummary, "Column-Condenser", "Column-Reboiler", EquipmentName, EquipmentDuty, EquipmentUnit, ColumnName, ColumnDuty, ColumnUnit);

                    btnImport_Equipment.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Please ensure you seleted the Eqipment Table file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you seleted the Eqipment Table file correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btnDefineProduct_Click(object sender, EventArgs e)
        {
            cbbMainProduct.Items.Clear();
            cbbSideProduct.Items.Clear();
            if (ComponentName.Count != 0)
            {
                for (int i = 1; i < ComponentName.Count; i++)
                {
                    cbbMainProduct.Items.Add(ComponentName[i]);
                    cbbSideProduct.Items.Add(ComponentName[i]);
                }
                cbbMainProduct.Text = ComponentName[1];
                cbbSideProduct.Text = ComponentName[2];
                tabpage.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please import Stream Table before proceeding to define Product process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Product_Credit_Click(object sender, EventArgs e)
        {

        }

        private void btnDefineStream_Click(object sender, EventArgs e)
        {
            cbbStreamInput.Items.Clear();
            cbbStreamOutput.Items.Clear();            
            if (StreamName.Count != 0)
            {
                for (int i = 2; i < StreamName.Count; i++)
                {
                    cbbStreamInput.Items.Add(StreamName[i]);
                    cbbStreamOutput.Items.Add(StreamName[i]);
                }
                cbbStreamInput.Text = StreamName[2];
                cbbStreamOutput.Text = StreamName[StreamName.Count - 1];
                tabpage.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Please import Stream Table before proceeding to define Stream process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnAddMainProduct_Click(object sender, EventArgs e)
        {
            if (cbbMainProduct.Text != "")
            {
                dgvMainProduct.Rows.Add(cbbMainProduct.Text);
            }
            else
            {
                MessageBox.Show("Please ensure that you have already imported the Stream Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage.SelectedIndex = 0;
            }
        }

        private void btnSideProduct_Click(object sender, EventArgs e)
        {
            if (cbbSideProduct.Text != "")
            {
                dgvSideProduct.Rows.Add(cbbSideProduct.Text);
            }
            else
            {
                MessageBox.Show("Please ensure that you have already imported the Stream Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage.SelectedIndex = 0;
            }
        }

        private void btnDone_Product_Click(object sender, EventArgs e)
        {
            if (dgvMainProduct.Rows.Count == 0)
            {
                MessageBox.Show("The product must be added before proceeding to the next step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnDefineProduct.BackColor = Color.LightGreen;
                tabpage.SelectedIndex = 0;
            }
            pbOne.Visible = false;
        }

        private void btnDone_StreamTable_Click_1(object sender, EventArgs e)
        {
            if (dgvStream_OpC.Rows.Count == 0)
            {
                MessageBox.Show("The stream input must be added before proceeding to the next step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvStreamOutput_OpC.Rows.Count == 0)
                {
                    MessageBox.Show("The stream output must be added before proceeding to the next step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnDefineStream.BackColor = Color.LightGreen;
                    tabpage.SelectedIndex = 0;
                }
            }
            pbTwo.Visible = false;
        }

        private void btnAddStreamInput_Click_1(object sender, EventArgs e)
        {
            if (cbbStreamInput.Text != "")
            {
                dgvStream_OpC.Rows.Add(cbbStreamInput.Text);
            }
            else
            {
                MessageBox.Show("Please ensure that you have already imported the Stream Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage.SelectedIndex = 0;
            }
        }

        private void btnAddStreamOutput_Click_1(object sender, EventArgs e)
        {
            if (cbbStreamOutput.Text != "")
            {
                dgvStreamOutput_OpC.Rows.Add(cbbStreamOutput.Text);
            }
            else
            {
                MessageBox.Show("Please ensure that you have already imported the Stream Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage.SelectedIndex = 0;
            }
        }

        private void btnDefineEqipment_Click(object sender, EventArgs e)
        {
            cbbEnergySource.Items.Clear();
            string[] EnergySource = {"Electricity", "Natural gas", "Cooling energy", "Coal", "Wind", "Solar energy", "Fuel", "Kerosine", "Other", "-"};
            //Coal, wind, solar energy, fuel, kerosine
            if (dgvEquipmentPreview.Columns.Count != 0)
            {
                for (int i = 0; i < EnergySource.Length; i++)
                {
                    cbbEnergySource.Items.Add(EnergySource[i]);
                }
                cbbEnergySource.Text = EnergySource[0];
                tabpage.SelectedIndex = 3;
            } 
            else
            {
                MessageBox.Show("Please ensure that you have already imported the Equipment Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbEnergySource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbEnergySource.Text == "Other")
            {
                txtOtherSource.ReadOnly = false;
            }
            else
            {
                txtOtherSource.ReadOnly = true;
            }
        }

        private void btnAddDefineEquip_Click(object sender, EventArgs e)
        {
            if (cbbEnergySource.Text != "Other")
            {
                dgvEquipmentSummary.SelectedRows[0].Cells[4].Value = cbbEnergySource.Text;
            }
            else
            {
                if (txtOtherSource.Text != "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[4].Value = txtOtherSource.Text;
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[4].Value = "-";
                }
            }                       
        }

        private void btnDone_DefineEquip_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentSummary.Rows.Count == 0)
            {
                MessageBox.Show("The Equipment Table must be imported before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < dgvEquipmentSummary.Rows.Count; i++)
                {
                    if (dgvEquipmentSummary.Rows[i].Cells[4].Value != null && dgvEquipmentSummary.Rows[i].Cells[4].Value.ToString() != "")
                    {
                        btnDefineEqipment.BackColor = Color.LightGreen;
                        tabpage.SelectedIndex = 0;
                    }
                    else
                    {
                        dgvEquipmentSummary.Rows[i].Cells[4].Value = "-";
                        btnDefineEqipment.BackColor = Color.LightGreen;
                        tabpage.SelectedIndex = 0;
                    }
                }                
            }
            pbThree.Visible = false;
        }
        int count = 0;
        private void btnCapitalCost_Click(object sender, EventArgs e)
        {            
            if (dgvEquipmentSummary.Rows.Count == 0)
            {
                MessageBox.Show("The Equipment Table must be imported before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (count == 0)
                {
                    dgvOnetime_CC.Columns.Clear();
                    dgvOnetime_CC.Rows.Clear();
                    dgvWorkingCapital.Columns.Clear();
                    dgvWorkingCapital.Rows.Clear();
                    //Datagridview for One-time expense
                    string[] OneTimeExpense = { "No.", "Name List of One-time expenses", "Cost ($)" };
                    //Add Column name
                    con.HeaderTable(dgvOnetime_CC, OneTimeExpense);
                    con.HeaderTable(dgvWorkingCapital, OneTimeExpense);
                    //Add Row data
                    string[] List_CC = { "Land acquisition cost", "Building construction cost", "Engineering and design cost", "Permits and licenses cost", "Construction labor cost", "Pre-production testing cost" };
                    for (int i = 0; i < List_CC.Length; i++)
                    {
                        dgvOnetime_CC.Rows.Add("", List_CC[i], "");
                    }
                    //Working Capital Investment
                    dgvWorkingCapital.Rows.Add("1", "Working Capital Investmenst (WC)", "");

                    //Datagridview for equipment
                    dgvEquipment_CC.Rows.Clear();
                    dgvEquipment_CC.Columns.Clear();
                    string[] Equipmet_CC = { "No.", "Name List of Equipment expenses", "Type of Equipment","Cost ($)" };
                    //Add Column name
                    con.HeaderTable2(dgvEquipment_CC, Equipmet_CC);
                    //Add Row data
                    string PurchaseCost_EachEquipment;
                    for (int i = 0; i < dgvEquipmentSummary.Rows.Count; i++)
                    {
                        if (dgvEquipmentSummary.Rows[i].Cells[1].Value.ToString() == "Column-Reboiler")
                        {
                            continue;
                        }
                        else
                        {
                            if (dgvEquipmentSummary.Rows[i].Cells[8].Value == null || dgvEquipmentSummary.Rows[i].Cells[8].Value.ToString() == "-" || dgvEquipmentSummary.Rows[i].Cells[8].Value.ToString() == "")
                            {
                                PurchaseCost_EachEquipment = "0";
                            }
                            else
                            {
                                PurchaseCost_EachEquipment = dgvEquipmentSummary.Rows[i].Cells[8].Value.ToString();
                            }
                            //Add data to datagridview
                            if (dgvEquipmentSummary.Rows[i].Cells[1].Value.ToString() == "Column-Condenser")
                            {
                                dgvEquipment_CC.Rows.Add("", dgvEquipmentSummary.Rows[i].Cells[0].Value.ToString(), "Column", PurchaseCost_EachEquipment);
                            }
                            else
                            {
                                dgvEquipment_CC.Rows.Add("", dgvEquipmentSummary.Rows[i].Cells[0].Value.ToString(), dgvEquipmentSummary.Rows[i].Cells[1].Value.ToString(), PurchaseCost_EachEquipment);
                            }                           
                        }                       
                    }
                    dgvEquipment_CC.Columns[0].Width = 45;
                }

                if (dgvOnetime_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                if (dgvEquipment_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                    {
                        dgvEquipment_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }               
                tabpage.SelectedIndex = 4;
                count = 0;
                //Custom by user
                rdbCustomCapCost.Checked = true;
            }
            
        }

        private void btnAdd_CC_Click(object sender, EventArgs e)
        {
            if (txtOther_CC.Text == "")
            {
                MessageBox.Show("Please type the Other Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Fixed Capital Investment 
                dgvOnetime_CC.Rows.Add("", txtOther_CC.Text, "");
                if (dgvOnetime_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Working Capital Investment 
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                    {
                        dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Equipment Cost
                if (dgvEquipment_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                    {
                        dgvEquipment_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
            
        }
        double Total_CapitalCost = 0;
        private void btnCalculate_CC_Click(object sender, EventArgs e)
        {           
            if (dgvOnetime_CC.Rows.Count == 0 || dgvEquipment_CC.Rows.Count == 0 || dgvWorkingCapital.Rows.Count == 0)
            {
                MessageBox.Show("The Equipment Table must be imported before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdbCustomCapCost.Checked == true)
                {
                    try
                    {
                        //Fixed Capital Investment
                        for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                        {                           
                            if (dgvOnetime_CC.Rows[i].Cells[2].Value == null || dgvOnetime_CC.Rows[i].Cells[2].Value.ToString() == "")
                            {
                                Total_CapitalCost += 0;
                                dgvOnetime_CC.Rows[i].Cells[2].Value = "-";
                            }
                            else if (dgvOnetime_CC.Rows[i].Cells[2].Value.ToString() == "-")
                            {
                                Total_CapitalCost += 0;
                            }
                            else
                            {
                                Total_CapitalCost += Convert.ToDouble(dgvOnetime_CC.Rows[i].Cells[2].Value.ToString());                        
                            }                            
                        }
                        //Working Capital Investment
                        for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                        {
                            if (dgvWorkingCapital.Rows[i].Cells[2].Value == null || dgvWorkingCapital.Rows[i].Cells[2].Value.ToString() == "")
                            {
                                Total_CapitalCost += 0;
                                dgvWorkingCapital.Rows[i].Cells[2].Value = "-";
                            }
                            else if (dgvWorkingCapital.Rows[i].Cells[2].Value.ToString() == "-")
                            {
                                Total_CapitalCost += 0;
                            }
                            else
                            {
                                Total_CapitalCost += Convert.ToDouble(dgvWorkingCapital.Rows[i].Cells[2].Value.ToString());
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please kindly ensure the capital costs for One-time expenses are correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                        {
                            if (dgvEquipment_CC.Rows[i].Cells[3].Value == null || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "")
                            {
                                Total_CapitalCost += 0;
                                dgvEquipment_CC.Rows[i].Cells[3].Value = "-";
                            }
                            else if (dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "-")
                            {
                                Total_CapitalCost += 0;
                            }
                            else
                            {
                                Total_CapitalCost += Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please kindly ensure the capital costs for Equipment expenses are correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtTotal_CC.Text = Total_CapitalCost.ToString("#,##0.##");
                }
                else if (rdbECONCapCost.Checked == true)
                {                   
                    double purchaseCostdeli = Convert.ToDouble(dgvOnetime_CC.Rows[0].Cells[3].Value.ToString());
                    double TotalCostECON = purchaseCostdeli;
                    //Fixed Capital Investment
                    for (int i = 1; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        if (dgvOnetime_CC.Rows[i].Cells[2].Value == null || dgvOnetime_CC.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            dgvOnetime_CC.Rows[i].Cells[2].Value = "-";
                            dgvOnetime_CC.Rows[i].Cells[3].Value = "0";
                        }
                        else if (dgvOnetime_CC.Rows[i].Cells[2].Value.ToString() == "-")
                        {
                            dgvOnetime_CC.Rows[i].Cells[3].Value = "0";
                        }
                        else
                        {
                            dgvOnetime_CC.Rows[i].Cells[3].Value = (Convert.ToDouble(dgvOnetime_CC.Rows[i].Cells[2].Value.ToString()) * purchaseCostdeli).ToString("#,##0.##");
                        }                        
                        TotalCostECON += Convert.ToDouble(dgvOnetime_CC.Rows[i].Cells[3].Value.ToString());                       
                    }
                    //Working Capital Investment
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                    {
                        if (dgvWorkingCapital.Rows[i].Cells[2].Value == null || dgvWorkingCapital.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            dgvWorkingCapital.Rows[i].Cells[2].Value = "-";
                            dgvWorkingCapital.Rows[i].Cells[3].Value = "0";
                        }
                        else if (dgvWorkingCapital.Rows[i].Cells[2].Value.ToString() == "-")
                        {
                            dgvWorkingCapital.Rows[i].Cells[3].Value = "0";
                        }
                        else
                        {
                            dgvWorkingCapital.Rows[i].Cells[3].Value = (Convert.ToDouble(dgvWorkingCapital.Rows[i].Cells[2].Value.ToString()) * purchaseCostdeli).ToString("#,##0.##");
                        }                       
                        TotalCostECON += Convert.ToDouble(dgvWorkingCapital.Rows[i].Cells[3].Value.ToString());
                    }                   
                    txtTotal_CC.Text = TotalCostECON.ToString("#,##0.##");
                }
                //Arrange no.
                if (dgvOnetime_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                    {
                        dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                    }
                }

            }           
            
            Total_CapitalCost = 0;
        }

        private void btnFeedstockCost_Click(object sender, EventArgs e)
        {
            tabpage.SelectedIndex = 6;
        }

        private void txtOther_CC_TextChanged(object sender, EventArgs e)
        {

        }

        private void Maintenance_Cost_Click(object sender, EventArgs e)
        {

        }
        string MaintenanceType = "";
        private void rdbPercent_MC_CheckedChanged(object sender, EventArgs e)
        {
            MaintenanceType = "percent";
            dgvSpecific_MC.Rows.Clear();
            txtAddSpecific_MC.Text = "";
            gbSpecific_MC.Enabled = false;
            gbPercent_MC.Enabled = true;
            txtTotalMaintenance.Text = "";
        }

        private void rdbSpecific_MC_CheckedChanged(object sender, EventArgs e)
        {
            MaintenanceType = "specific";
            txtPercent_MC.Text = "";
            gbSpecific_MC.Enabled = true;
            gbPercent_MC.Enabled = false;
            txtTotalMaintenance.Text = "";
        }

        private void txtTotal_CC_TextChanged(object sender, EventArgs e)
        {
            txtPreviewCC_MC.Text = txtTotal_CC.Text;
        }

        private void btnAddSpecific_MC_Click(object sender, EventArgs e)
        {
            if (txtAddSpecific_MC.Text == "")
            {
                MessageBox.Show("Please type the specific maintenance cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvSpecific_MC.Rows.Add("", txtAddSpecific_MC.Text, "");
                for (int i = 0; i < dgvSpecific_MC.Rows.Count - 1; i++)
                {
                    dgvSpecific_MC.Rows[i].Cells[0].Value = i + 1;
                }
            }
        }

        private void txtPercent_MC_TextChanged(object sender, EventArgs e)
        {
            if (txtPercent_MC.Text != "")
            {
                try
                {
                    double percentMC;
                    percentMC = Convert.ToDouble(txtPercent_MC.Text);
                }
                catch
                {
                    MessageBox.Show("Please type only the number for the percentage of maintenance cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnCalculation_MC_Click(object sender, EventArgs e)
        {
            double InitialCC, Percent_MC;
            double SpecificCost = 0;
            double InterestRateCal;
            InterestRateCal = con.Cal_InterestRate(txtInterestRate.Text, txtPeriod.Text);
            try
            {
                if (MaintenanceType == "percent")
                {
                    if (txtPreviewCC_MC.Text == "")
                    {
                        MessageBox.Show("Please ensure you have filled up the information in the capital cost page, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabpage.SelectedIndex = 0;
                    }
                    else
                    {
                        InitialCC = Convert.ToDouble(txtPreviewCC_MC.Text);
                        Percent_MC = Convert.ToDouble(txtPercent_MC.Text);
                        txtTotalMaintenance.Text = (((InitialCC * Percent_MC) / 100) / InterestRateCal).ToString("#,##0.##");
                    }
                    
                }
                else if (MaintenanceType == "")
                {
                    MessageBox.Show("Please select the type of maintenance cost, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MaintenanceType == "specific")
                {
                    
                    for (int i = 0; i < dgvSpecific_MC.Rows.Count - 1; i++)
                    {
                        if (dgvSpecific_MC.Rows[i].Cells[2].Value == null || dgvSpecific_MC.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            dgvSpecific_MC.Rows[i].Cells[2].Value = "-";
                        }
                        if (dgvSpecific_MC.Rows[i].Cells[2].Value.ToString() == "-")
                        {
                            SpecificCost += 0;
                        }
                        else
                        {
                            SpecificCost += Convert.ToDouble(dgvSpecific_MC.Rows[i].Cells[2].Value);
                        }
                    }                                     
                    txtTotalMaintenance.Text = (SpecificCost / InterestRateCal).ToString("#,##0.##");
                    SpecificCost = 0;
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you add the required maintenance cost information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnMaintenanceCost_Click(object sender, EventArgs e)
        {                     
            tabpage.SelectedIndex = 7;
        }

        int salvage_count = 0;
        private void btnSalvageValue_Click(object sender, EventArgs e)
        {
            if (dgvEquipment_CC.Rows.Count == 0 || btnCapitalCost.BackColor == Color.Transparent)
            {
                MessageBox.Show("Please fill up the capital cost information before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage.SelectedIndex = 0;
            }           
            else
            {               
                if (salvage_count == 0)
                {
                    dgvSalvageValue.Rows.Clear();
                    dgvSalvageValue.Columns.Clear();
                    //Datagridview for equipment
                    string[] Equipmet_CC = { "No.", "Name List of Equipment expenses", "Type of Equipment", "Cost ($)" };
                    //Add Column name
                    con.HeaderTable2(dgvSalvageValue, Equipmet_CC);
                    //Add Row data
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                    {
                        dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "");
                    }                   
                    dgvSalvageValue.AutoResizeColumns();
                    dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvSalvageValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
                if (dgvSalvageValue.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvSalvageValue.Rows.Count - 1; i++)
                    {
                        dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                tabpage.SelectedIndex = 8;
                salvage_count = 0;
            }
        }
      
        double TotalSalvage = 0;
        private void btnCalculation_SV_Click(object sender, EventArgs e)
        {
            double InterestRateCal;
            InterestRateCal = con.Cal_InterestRate(txtInterestRate.Text, txtPeriod.Text);
            try
            {              
                if (rdbCustomSV.Checked == true)
                {
                    for (int i = 0; i < dgvSalvageValue.Rows.Count - 1; i++)
                    {
                        if (dgvSalvageValue.Rows[i].Cells[3].Value == null || dgvSalvageValue.Rows[i].Cells[3].Value.ToString() == "")
                        {
                            dgvSalvageValue.Rows[i].Cells[3].Value = "-";
                        }
                        if (dgvSalvageValue.Rows[i].Cells[3].Value.ToString() == "-")
                        {
                            TotalSalvage += 0;
                        }
                        else
                        {
                            TotalSalvage += Convert.ToDouble(dgvSalvageValue.Rows[i].Cells[3].Value);
                        }
                    }
                    txtTotal_SV.Text = (TotalSalvage / InterestRateCal).ToString("#,##0.##");
                    TotalSalvage = 0;
                }
                else if (rdbPercentFirstCost.Checked == true)
                {
                    for (int i = 0; i < dgvSalvageValue.Rows.Count - 1; i++)
                    {
                        if (dgvSalvageValue.Rows[i].Cells[4].Value == null || dgvSalvageValue.Rows[i].Cells[4].Value.ToString() == "")
                        {
                            dgvSalvageValue.Rows[i].Cells[4].Value = "-";
                        }
                        if (dgvSalvageValue.Rows[i].Cells[4].Value.ToString() == "-")
                        {
                            TotalSalvage += 0;
                        }
                        else
                        {                            
                            double InitialEquipCost;
                            InitialEquipCost = Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                            TotalSalvage += ((Convert.ToDouble(dgvSalvageValue.Rows[i].Cells[3].Value) / 100) * InitialEquipCost);
                            dgvSalvageValue.Rows[i].Cells[4].Value = ((Convert.ToDouble(dgvSalvageValue.Rows[i].Cells[3].Value) / 100) * InitialEquipCost).ToString("#,##0.##");
                        }
                    }
                    txtTotal_SV.Text = (TotalSalvage / InterestRateCal).ToString("#,##0.##");
                    TotalSalvage = 0;
                }              
            }
            catch
            {
                MessageBox.Show("Please ensure you add the required salvage value information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        private void btnOperatingCost_Click(object sender, EventArgs e)
        {            
            //Operating Cost for Equipment Table
            string[] OPC_EquipmentHeader = { "Equipment Name", "Duty/Work", "Unit", "Working hour (hr.)", "Cost per unit ($)", "Total Cost ($)" };
            if (dgvEquipmentSummary.Rows.Count != 0)
            {
                //Add column Name              
                con.HeaderTable(dgvEquipmentOPC, OPC_EquipmentHeader);

                for (int i = 0; i < dgvEquipmentSummary.Rows.Count; i++)
                {
                    dgvEquipmentOPC.Rows.Add(dgvEquipmentSummary.Rows[i].Cells[0].Value.ToString(), dgvEquipmentSummary.Rows[i].Cells[2].Value.ToString(), dgvEquipmentSummary.Rows[i].Cells[3].Value.ToString(), txtNumHour_OpC.Text, "", "");
                }
            }

            //Operating Cost for Labor Table
            string[] OPC_LaborHeader = { " Operating Cost Name", "Number of Labor", "Working hour (hr.)", "Cost of salary per hour ($)", "Total Cost ($)" };
            //Add column Name              
            con.HeaderTable(dgvLaborOPC, OPC_LaborHeader);
            dgvLaborOPC.Rows.Add("Labor Cost", "", txtNumHour_OpC.Text, "", "");
            //Operating Cost for Labor per month Table
            string[] OPC_EmployeeHeader = { " Operating Cost Name", "Number of Labor", "Working month", "Cost of salary per month ($)", "Total Cost ($)" };
            //Add column Name              
            con.HeaderTable(dgvLaborMonth, OPC_EmployeeHeader);
            dgvLaborMonth.Rows.Add("Employee Cost", "", "12", "", "");

            //Operating Cost for stream Table
            dgvStreamOPC.Rows.Clear();
            dgvStreamOPC.Columns.Clear();
            stream_OPC.Clear();
            Findstream_OPC.Clear();
            stream_OPC.Add("Stream Name");                      
            stream_OPC.Add("");
            stream_OPC.Add("");
            for (int i = 0; i < dgvStream_OpC.Rows.Count; i++)
            {
                stream_OPC.Add(dgvStream_OpC.Rows[i].Cells[0].Value.ToString());
            }
            stream_OPC.Add("");
            con.HeaderTableFromList(dgvStreamOPC, stream_OPC);  
            
            for (int i = 0; i < ComponentName.Count; i++)
            {
                dgvStreamOPC.Rows.Add(ComponentName[i]);               
            }
            
            //Find Column in original stream
            if (stream_OPC.Count > 2)
            {
                for (int j = 2; j < stream_OPC.Count; j++)
                {
                    for (int k = 0; k < StreamName.Count; k++)
                    {
                        if (stream_OPC[j] == StreamName[k])
                        {
                            Findstream_OPC.Add(k);
                        }
                    }
                }
            }
            //Add Data of each stream to operating cost Table
            for (int i = 1; i < dgvStreamTablePreview.Rows.Count; i++)
            {
                for (int j = 0; j < Findstream_OPC.Count; j++)
                {
                    dgvStreamOPC.Rows[i].Cells[j + 3].Value = Convert.ToDouble(dgvStreamTablePreview.Rows[i].Cells[Findstream_OPC[j]].Value.ToString()).ToString("#,##0.##");
                }
            }
         
            dgvStreamOPC.Rows[0].Cells[0].Value = "List of Component";
            dgvStreamOPC.Rows[0].Cells[1].Value = "Unit Price ($)";
            dgvStreamOPC.Rows[0].Cells[2].Value = "Working hour (hr.)";
            for (int j = 0; j < Findstream_OPC.Count; j++)
            {
                dgvStreamOPC.Rows[0].Cells[j + 3].Value = "Mass flow rate (kg/hr)";
            }
            dgvStreamOPC.Rows[0].Cells[dgvStreamOPC.Columns.Count - 1].Value = "Total Cost ($)";

            for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
            {
                dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
            }

            //Align to center
            dgvEquipmentOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaborOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaborMonth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStreamOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabpage.SelectedIndex = 5;
        }

        private void btnDone_OPC_Click(object sender, EventArgs e)
        {
            if (txtTotal_OPC.Text == "")
            {
                txtTotal_OPC.Text = "0";
            }
            btnOperatingCost.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;
        }

        private void btnProductCredit_Click(object sender, EventArgs e)
        {
            //By Product credit
            dgvMainP.Rows.Clear();
            dgvMainP.Columns.Clear();
            dgvSideP.Rows.Clear();
            dgvSideP.Columns.Clear();
            stream_OPC.Clear();
            FindOutputStream.Clear();
            FindRowStream.Clear();
            MainProductCredit.Clear();
            SideProductCredit.Clear();
            txtTotal_PC.Text = "";
            stream_OPC.Add("Stream Name");
            stream_OPC.Add("");
            stream_OPC.Add("");
            for (int i = 0; i < dgvStreamOutput_OpC.Rows.Count; i++)
            {
                stream_OPC.Add(dgvStreamOutput_OpC.Rows[i].Cells[0].Value.ToString());
            }
            stream_OPC.Add("");
            con.HeaderTableFromList(dgvMainP, stream_OPC);
            con.HeaderTableFromList(dgvSideP, stream_OPC);
            dgvMainP.Rows.Add();
            dgvSideP.Rows.Add();           
            //Main Product Component
            for (int i = 0; i < dgvMainProduct.Rows.Count; i++)
            {
                MainProductCredit.Add(dgvMainProduct.Rows[i].Cells[0].Value.ToString());              
            }
            //Side Product Component
            for (int i = 0; i < dgvSideProduct.Rows.Count; i++)
            {
                SideProductCredit.Add(dgvSideProduct.Rows[i].Cells[0].Value.ToString());              
            }

            //Add Main Product to datagridview
            for (int i = 0; i < MainProductCredit.Count; i++)
            {
                dgvMainP.Rows.Add(MainProductCredit[i]);
            }
            //Add Side Product to datagridview
            for (int i = 0; i < SideProductCredit.Count; i++)
            {
                dgvSideP.Rows.Add(SideProductCredit[i]);
            }

            //Find Column in original stream
            if (stream_OPC.Count > 2)
            {
                for (int j = 2; j < stream_OPC.Count; j++)
                {
                    for (int k = 0; k < StreamName.Count; k++)
                    {
                        if (stream_OPC[j] == StreamName[k])
                        {
                            FindOutputStream.Add(k);
                        }
                    }
                }
            }           

            //Main Product Credit 
            dgvMainP.Rows[0].Cells[0].Value = "List of Component";
            dgvMainP.Rows[0].Cells[1].Value = "Unit Price ($)";
            dgvMainP.Rows[0].Cells[2].Value = "Working hour (hr.)";
            for (int j = 0; j < FindOutputStream.Count; j++)
            {
                dgvMainP.Rows[0].Cells[j + 3].Value = "Mass flow rate (kg/hr)";
            }
            dgvMainP.Rows[0].Cells[dgvMainP.Columns.Count - 1].Value = "Total Cost ($)";

            for (int i = 1; i < dgvMainP.Rows.Count; i++)
            {
                dgvMainP.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
            }
            //Side Product Credit 
            dgvSideP.Rows[0].Cells[0].Value = "List of Component";
            dgvSideP.Rows[0].Cells[1].Value = "Unit Price ($)";
            dgvSideP.Rows[0].Cells[2].Value = "Working hour (hr.)";
            for (int j = 0; j < FindOutputStream.Count; j++)
            {
                dgvSideP.Rows[0].Cells[j + 3].Value = "Mass flow rate (kg/hr)";
            }
            dgvSideP.Rows[0].Cells[dgvSideP.Columns.Count - 1].Value = "Total Cost ($)";

            for (int i = 1; i < dgvSideP.Rows.Count; i++)
            {
                dgvSideP.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
            }
          
            dgvMainP.Rows.Add();
            dgvSideP.Rows.Add();

            //Find and Collect Row of interest stream (main product)
            for (int i = 0; i < MainProductCredit.Count; i++)
            {                
                for (int j = 1; j < dgvStreamTablePreview.Rows.Count; j++)
                {
                    if (dgvStreamTablePreview.Rows[j].Cells[0].Value.ToString() == MainProductCredit[i])
                    {                        
                        FindRowStream.Add(j);
                    }                    
                }
            }
            //Add data for main product
            for (int i = 0; i < MainProductCredit.Count; i++)
            {
                for (int j = 0; j < FindOutputStream.Count; j++)
                {                   
                    dgvMainP.Rows[i + 1].Cells[j + 3].Value = Convert.ToDouble(dgvStreamTablePreview.Rows[FindRowStream[i]].Cells[FindOutputStream[j]].Value.ToString()).ToString("#,##0.##"); 
                }
            }

            FindRowStream.Clear();
            //Find and Collect Row of interest stream (side product)
            for (int i = 0; i < SideProductCredit.Count; i++)
            {
                for (int j = 1; j < dgvStreamTablePreview.Rows.Count; j++)
                {
                    if (dgvStreamTablePreview.Rows[j].Cells[0].Value.ToString() == SideProductCredit[i])
                    {
                        FindRowStream.Add(j);
                    }
                }
            }
            //Add data for side product
            for (int i = 0; i < SideProductCredit.Count; i++)
            {
                for (int j = 0; j < FindOutputStream.Count; j++)
                {
                    dgvSideP.Rows[i + 1].Cells[j + 3].Value = Convert.ToDouble(dgvStreamTablePreview.Rows[FindRowStream[i]].Cells[FindOutputStream[j]].Value.ToString()).ToString("#,##0.##");
                }
            }

            //Align to center
            dgvMainP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSideP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabpage.SelectedIndex = 9;
        }

        private void btnCalculateMainPage_Click(object sender, EventArgs e)
        {
            dgvSummaryCost.Rows.Clear();
            dgvSummaryCost.Columns.Clear();
            //Operating Cost for Labor Table
            string[] SummaryHeader = {"List of Life Cycle Cost", "Cost ($)" };
            //Add column Name              
            con.HeaderTable(dgvSummaryCost, SummaryHeader);

            //Add Rows
            string[] SummaryList = {"Capital Cost", "Operating Cost", "Feedstock Cost", "Maintenance Cost", "Salvage Value", "Product Credit"};
            string[] SummaryData = { txtTotal_CC.Text, txtTotal_OPC.Text, txtTotal_FS.Text, txtTotalMaintenance.Text, txtTotal_SV.Text, txtTotal_PC.Text };
            for (int i = 0; i < SummaryList.Length; i++)
            {
                dgvSummaryCost.Rows.Add(SummaryList[i], SummaryData[i]);
            }
            dgvSummaryCost.AutoResizeColumns();
            dgvSummaryCost.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSummaryCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Calculate LCC
            double Capital, Operating, Feedstock, Maintenance, Salvage, ProductCredit, LCC_Expense, LCC_Revenue;
            try
            {
                //Show summary in Table 
                Capital = Convert.ToDouble(txtTotal_CC.Text);
                Operating = Convert.ToDouble(txtTotal_OPC.Text);
                Feedstock = Convert.ToDouble(txtTotal_FS.Text);
                Maintenance = Convert.ToDouble(txtTotalMaintenance.Text);
                Salvage = Convert.ToDouble(txtTotal_SV.Text);
                ProductCredit = Convert.ToDouble(txtTotal_PC.Text);
                LCC_Expense = Capital + Operating + Feedstock + Maintenance;
                LCC_Revenue = Salvage + ProductCredit;
                txtTotalSummary.Text = LCC_Expense.ToString("#,##0.####");
                txtLCCRevenue.Text = LCC_Revenue.ToString("#,##0.####");
                txtTotalLCC.Text = (LCC_Revenue - LCC_Expense).ToString("#,##0.####");
                //Create Equiment Cost chart
                //Find Total Cost of Equipment
                double Total_EquipCost = 0;
                if (dgvEquipment_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                    {
                        if (dgvEquipment_CC.Rows[i].Cells[3].Value == null || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "")
                        {
                            Total_EquipCost += 0;
                        }
                        else if (dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "-")
                        {
                            Total_EquipCost += 0;
                        }
                        else
                        {
                            Total_EquipCost += Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                        }
                    }

                    // Define data series                   
                    string EquipName_Chart;
                    double PercentEquip_Chart;
                    EquipCostChart.Series[0].Points.Clear();
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                    {
                        if (dgvEquipment_CC.Rows[i].Cells[3].Value == null || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "" || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "-")
                        {
                            continue;
                        }
                        else
                        {
                            EquipName_Chart = dgvEquipment_CC.Rows[i].Cells[1].Value.ToString();
                            PercentEquip_Chart = Math.Round((Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString()) / Total_EquipCost) * 100, 2);
                            EquipCostChart.Series[0].Points.AddXY(EquipName_Chart, PercentEquip_Chart);                           
                        }                       
                    }

                    // Set chart title (optional)
                    EquipCostChart.Titles.Clear();
                    EquipCostChart.Titles.Add("Percentage of Equipment Cost");
                    EquipCostChart.Series[0].IsValueShownAsLabel = true;
                    EquipCostChart.Series[0].IsVisibleInLegend = true;
                }

                //Create Utility Cost chart
                //Find Total Cost of Equipment
                double Total_UtilityCost = 0;
                if (dgvEquipmentOPC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvEquipmentOPC.Rows.Count - 1; i++)
                    {
                        if (dgvEquipmentOPC.Rows[i].Cells[5].Value == null || dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString() == "")
                        {
                            Total_UtilityCost += 0;
                        }
                        else if (dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString() == "-")
                        {
                            Total_UtilityCost += 0;
                        }
                        else
                        {
                            Total_UtilityCost += Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString());
                        }
                    }

                    // Define data series                   
                    string UtilityName_Chart;
                    double PercentUtility_Chart;
                    UtilityCostChart.Series[0].Points.Clear();
                    for (int i = 0; i < dgvEquipmentOPC.Rows.Count - 1; i++)
                    {
                        if (dgvEquipmentOPC.Rows[i].Cells[5].Value == null || dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString() == "" || dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString() == "-")
                        {
                            continue;
                        }
                        else
                        {
                            UtilityName_Chart = dgvEquipmentOPC.Rows[i].Cells[0].Value.ToString();
                            PercentUtility_Chart = Math.Round((Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString()) / Total_UtilityCost) * 100, 2);
                            UtilityCostChart.Series[0].Points.AddXY(UtilityName_Chart, PercentUtility_Chart);
                        }
                    }

                    // Set chart title (optional)
                    UtilityCostChart.Titles.Clear();
                    UtilityCostChart.Titles.Add("Percentage of Utility Cost");
                    UtilityCostChart.Series[0].IsValueShownAsLabel = true;
                    UtilityCostChart.Series[0].IsVisibleInLegend = true;
                }

                //Go to LCC page
                tabpage.SelectedIndex = 10;
            }
            catch
            {
                MessageBox.Show("Please verify that all required cost fields have been completed on each page, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            

        }

        private void Summary_Click(object sender, EventArgs e)
        {

        }

        private void btnGotoMain_Click(object sender, EventArgs e)
        {
            tabpage.SelectedIndex = 0;
        }

        private void btnSaveMainPage_Click(object sender, EventArgs e)
        {
            
        }

        private void btnChange_OPC_Click(object sender, EventArgs e)
        {
            if (txtNumHour_OpC.Text != "")
            {
                //Equipment Table
                for (int i = 0; i < dgvEquipmentOPC.Rows.Count - 1; i++)
                {
                    dgvEquipmentOPC.Rows[i].Cells[3].Value = txtNumHour_OpC.Text;
                }

                //Labor Table
                dgvLaborOPC.Rows[0].Cells[2].Value = txtNumHour_OpC.Text;

                //Stream Table
                for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
                {
                    dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
                }
            }

            for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
            {
                dgvStreamOPC.Rows[i].Cells[dgvStreamOPC.Columns.Count - 1].Value = "";
            }
            dgvEquipmentOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaborOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
      
        string CheckTransport = "";
        private void rdbWithTransport_CheckedChanged(object sender, EventArgs e)
        {
            CheckTransport = "yes";
        }

        private void rdbNotTransport_CheckedChanged(object sender, EventArgs e)
        {
            CheckTransport = "no";
        }

        private void txtInterestRate_TextChanged(object sender, EventArgs e)
        {
            double TestNum;
            try
            {   if (txtInterestRate.Text != "")
                {
                    TestNum = Convert.ToDouble(txtInterestRate.Text);
                }          
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the interest rate correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            double TestNum;
            try
            {
                if (txtPeriod.Text != "")
                {
                    TestNum = Convert.ToDouble(txtPeriod.Text);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the period correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEquipDefineType_Click(object sender, EventArgs e)
        {
            if (cbbTypeOfEquip.Text == "Select type of equipment")
            {
                MessageBox.Show("Please select type of equipment.", "Informaion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbbTypeOfEquip.Text == "Compressor")
            {
                txtEquipNameComp.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtPressureComp.Text = "";
                txtPowerComp.Text = "";
                txtPurchaseComp.Text = "";
                Eqip_Control.SelectedIndex = 2;
            }
            else if (cbbTypeOfEquip.Text == "Cooling Tower")
            {
                txtEquipNameCooling.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtCapCooling.Text = "";
                txtPurchaseCooling.Text = "";
                Eqip_Control.SelectedIndex = 3;
            }
            else if (cbbTypeOfEquip.Text == "Direct-fired Heater")
            {
                txtEquipNameDirectHeater.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtHeaterDuty.Text = "";
                txtPurchaseDirectHeater.Text = "";
                Eqip_Control.SelectedIndex = 4;
            }
            else if (cbbTypeOfEquip.Text == "Drive")
            {
                txtEquipName.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtPowerDrive.Text = "";
                txtPurchaseDrive.Text = "";
                Eqip_Control.SelectedIndex = 5;
            }
            else if (cbbTypeOfEquip.Text == "Furnance")
            {
                txtEquipNameFurnance.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtHeatDutyFurnance.Text = "";
                txtPurchaseFurnance.Text = "";
                Eqip_Control.SelectedIndex = 6;
            }
            else if (cbbTypeOfEquip.Text == "Heat Exchanger")
            {
                txtEquipNameHx.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtAreaAirCooled.Text = "";
                txtDoubleArea.Text = "";
                txtAreaMulti.Text = "";
                txtAreaFT.Text = "";
                txtAreaU.Text = "";
                txtAreaFH.Text = "";
                txtPurchaseCostHx.Text = "";
                Eqip_Control.SelectedIndex = 7;
            }
            else if (cbbTypeOfEquip.Text == "Mixer")
            {
                txtEquipNameMixer.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtCapMixer.Text = "";
                txtPowerCalMixer.Text = "";
                txtPurchaseMixer.Text = "";
                Eqip_Control.SelectedIndex = 8;
            }
            else if (cbbTypeOfEquip.Text == "Pump")
            {
                txtEquipNamePump.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtPumpCap.Text = "";
                txtPurchasePump.Text = "";
                Eqip_Control.SelectedIndex = 9;
            }
            else if (cbbTypeOfEquip.Text == "Pump include drive")
            {
                txtEquipPumpDrive.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtsizePumpDrive.Text = "";
                txtUtilityPumpDrive.Text = "";
                txtPurchasePumpDrive.Text = "";
                Eqip_Control.SelectedIndex = 10;
            }
            else if (cbbTypeOfEquip.Text == "Reactor")
            {
                txtEquipReactor.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtAreaVR.Text = "";
                txtAreaPFR.Text = "";
                txtPurchaseR.Text = "";
                Eqip_Control.SelectedIndex = 11;
            }
            else if (cbbTypeOfEquip.Text == "Storage")
            {
                txtEquipStorage.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtVolumnStorage.Text = "";
                txtPurchaseSr.Text = "";
                Eqip_Control.SelectedIndex = 12;
            }
            else if (cbbTypeOfEquip.Text == "Turbine")
            {
                txtEquipTB.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtPowerTurbine.Text = "";
                txtPurchaseTB.Text = "";
                Eqip_Control.SelectedIndex = 13;
            }
            else if (cbbTypeOfEquip.Text == "Tower Unit")
            {
                txtEquipNameTU.Text = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtTrayName.Text = "Tray-" + dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString();
                txtHeightTU.Text = "";
                txtDiameterTTU.Text = "";
                nudNumTray.Text = "1";
                txtPurchaseTU.Text = "";
                Eqip_Control.SelectedIndex = 14;
            }
            else if (cbbTypeOfEquip.Text == "Add Other Equipment")
            {
                txtOtherEquipName.Text = "";
                txtOtherPurchaseCost.Text = "";
                txtUtilityQuantity.Text = "";
                Eqip_Control.SelectedIndex = 15;
            }
        }
                   
        private void rdbCent_Motor_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbCent_Turbine_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbCent_Rotary_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }
        double alpha = 0;
        double beta = 0;
        double af = 1;
        private void btnCalComp_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseComp.Text = conCal.PurchaseCost(alpha, beta, sizing_Comp, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                    
        }
        double CPI_Index = 0;      
        private void txtCPI_Index_TextChanged(object sender, EventArgs e)
        {           
            try
            {
                if (txtCPI_Index.Text != "")
                {
                    CPI_Index = Convert.ToDouble(txtCPI_Index.Text);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the CPI correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbCS690_CheckedChanged(object sender, EventArgs e)
        {
            lblRangeDireactHeater.Text = "*The heat duty range for this calculation is 200 kW to 10,000 kW.";
            txtPurchaseDirectHeater.Text = "";
        }

        private void btnCalDirectHeater_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbCS690.Checked == true)
                {
                    alpha = 176.04;
                    beta = 0.7628;
                }
                else if (rdbCS1035.Checked == true)
                {
                    alpha = 913.92;
                    beta = 0.6784;
                }
                else if (rdbCS6890.Checked == true)
                {
                    alpha = 1398.2;
                    beta = 0.671;
                }
                else if (rdbCS10340.Checked == true)
                {
                    alpha = 1433.8;
                    beta = 0.6836;
                }
                double sizing_DirectHeater;
                if (rdbCS690.Checked == true)
                {
                    sizing_DirectHeater = conCal.ConvertDuty_Unit(cbbUnitDireactHeater.Text, txtHeaterDuty.Text, 200, 10000);
                }
                else
                {
                    sizing_DirectHeater = conCal.ConvertDuty_Unit(cbbUnitDireactHeater.Text, txtHeaterDuty.Text, 100, 8790);
                }
                txtPurchaseDirectHeater.Text = conCal.PurchaseCost(alpha, beta, sizing_DirectHeater, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void btnCalFurnance_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb3450Furnance.Checked == true)
                {
                    alpha = 199.85;
                    beta = 0.8659;
                }
                else if (rdb6895Furnance.Checked == true)
                {
                    alpha = 288.61;
                    beta = 0.8578;
                }
                else if (rdb13790Furnance.Checked == true)
                {
                    alpha = 515.4;
                    beta = 0.8251;
                }
                double sizing_Furnance;
                sizing_Furnance = conCal.ConvertDuty_Unit(cbbUnitFurnance.Text, txtHeatDutyFurnance.Text, 2000, 100000);
                txtPurchaseFurnance.Text = conCal.PurchaseCost(alpha, beta, sizing_Furnance, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void btnCalMixer_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbCSMixer.Checked == true)
                {
                    alpha = 6583.3;
                    beta = 0.5253;
                }
                else if (rdbStainlessMixer.Checked == true)
                {
                    alpha = 9457.3;
                    beta = 0.5482;
                }
                double sizing_Mixer;
                sizing_Mixer = conCal.ConvertCapacity_Unit(cbbUnitMixer.Text, txtCapMixer.Text, 0.378, 26.5);
                txtPurchaseMixer.Text = conCal.PurchaseCost(alpha, beta, sizing_Mixer, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnCalPump_Click(object sender, EventArgs e)
        {
            double sizing_Pump, pressureFactor, CalPumpCost;
            try
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
                    CalPumpCost = Convert.ToDouble(conCal.PurchaseCost(alpha, beta, sizing_Pump, af, CPI_Index));
                    txtPurchasePump.Text = (CalPumpCost * pressureFactor).ToString("#,##0.##");
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
                    CalPumpCost = Convert.ToDouble(conCal.PurchaseCost(alpha, beta, sizing_Pump, af, CPI_Index));
                    txtPurchasePump.Text = (CalPumpCost * pressureFactor).ToString("#,##0.##");
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
                    txtPurchasePump.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Pump, 1, CPI_Index);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void rdbCS1035_CheckedChanged(object sender, EventArgs e)
        {
            lblRangeDireactHeater.Text = "*The heat duty range for this calculation is 100 kW to 8790 kW.";
            txtPurchaseDirectHeater.Text = "";
        }

        private void rdbCS6890_CheckedChanged(object sender, EventArgs e)
        {
            lblRangeDireactHeater.Text = "*The heat duty range for this calculation is 100 kW to 8790 kW.";
            txtPurchaseDirectHeater.Text = "";
        }

        private void rdbCS10340_CheckedChanged(object sender, EventArgs e)
        {
            lblRangeDireactHeater.Text = "*The heat duty range for this calculation is 100 kW to 8790 kW.";
            txtPurchaseDirectHeater.Text = "";
        }

        private void rdbAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 0;
            txtPurchaseCostHx.Text = "";
        }

        private void rdbDoublePipe_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 1;
            txtPurchaseCostHx.Text = "";
        }

        private void rdbMultiplePipe_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 2;
            txtPurchaseCostHx.Text = "";
        }

        private void rdbFixedTube_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 3;
            txtPurchaseCostHx.Text = "";
        }

        private void rdbUTube_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 4;
            txtPurchaseCostHx.Text = "";
        }

        private void rdbFloatingHead_CheckedChanged(object sender, EventArgs e)
        {
            tabHeatExType.Enabled = true;
            tabHeatExType.SelectedIndex = 5;
            txtPurchaseCostHx.Text = "";
        }

        private void btnCalAirCooled_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost(alpha, beta, sizing_AirCooled, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void btnCalDouble_Click(object sender, EventArgs e)
        {           
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost(alpha, beta, sizing_DoublePipe, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void rdbCSTS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDouble.Text = "*The area range for this calculation is 0.232 m2 to 29.3 m2.";
            txtPurchaseCostHx.Text = "";
        }

        private void rdbATCSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDouble.Text = "*The area range for this calculation is 0.232 m2 to 19.3 m2.";
            txtPurchaseCostHx.Text = "";
        }

        private void rdbSSTCSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDouble.Text = "*The area range for this calculation is 0.232 m2 to 14.3 m2.";
            txtPurchaseCostHx.Text = "";
        }

        private void btnCalMulti_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost(alpha, beta, sizing_MultiPipe, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        double a1 = 0;
        double b1 = 0;
        double c1 = 0;
        double d1 = 0;
        double e1 = 0;
        double f1 = 0;
        double CapitalC = 0;
        
        private void btnCalFT_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_FixedTube, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void rdbCSU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteU.Text = "*The area range for this calculation is 2.79 m2 to 440 m2.";
            txtPurchaseCostHx.Text = "";
        }

        private void rdbSSU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteU.Text = "*The area range for this calculation is 2.79 m2 to 352 m2.";
            txtPurchaseCostHx.Text = "";
        }

        private void btnCalU_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_UTube, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnCalFH_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseCostHx.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_FH, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnHelpFH_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Material abbreviation:" + "\n" + "\n" + "CS-Carbon Steel" + "\n" + "CU-Copper" + "\n" + "SS-Stainless Steel" + "\n" + "Ni Alloy-Nickel Alloy" + "\n" + "Ti-Titanium", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCalDrive_Click(object sender, EventArgs e)
        {
            try
            {
                //Drive type value           
                if (rdbExplosion.Checked == true)
                {
                    a1 = -3E-16;
                    b1 = 5E-12;
                    c1 = -3E-8;
                    d1 = 9E-5;
                    e1 = -0.1566;
                    f1 = 163.04;
                    CapitalC = 324.57;
                }
                else if (rdbEncoled.Checked == true)
                {
                    a1 = -1E-16;
                    b1 = 2E-12;
                    c1 = -2E-8;
                    d1 = 5E-5;
                    e1 = -0.0961;
                    f1 = 113.86;
                    CapitalC = 0;
                }
                else if (rdbDrip.Checked == true)
                {
                    a1 = -9E-17;
                    b1 = 1E-12;
                    c1 = -9E-9;
                    d1 = 3E-5;
                    e1 = -0.0535;
                    f1 = 73.041;
                    CapitalC = 239.95;
                }
                else if (rdbSquirrel.Checked == true)
                {
                    a1 = 0;
                    b1 = 0;
                    c1 = 0;
                    d1 = 0;
                    e1 = 0.1286;
                    f1 = 43.371;
                    CapitalC = 252.17;
                }
                double sizing_FH;
                sizing_FH = conCal.ConvertPower_Unit(cbbUnitDrive.Text, txtPowerDrive.Text, 4, 4480);
                if (rdbEncoled.Checked == true || rdbDrip.Checked == true)
                {
                    sizing_FH = conCal.ConvertPower_Unit(cbbUnitDrive.Text, txtPowerDrive.Text, 1, 4480);
                }
                else if (rdbSquirrel.Checked == true)
                {
                    sizing_FH = conCal.ConvertPower_Unit(cbbUnitDrive.Text, txtPowerDrive.Text, 4.48, 97);
                }
                txtPurchaseDrive.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_FH, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void rdbExplosion_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDrive.Text = "*The power range for this calculation is 4 kW to 4480 kW.";
            txtPurchaseDrive.Text = "";
        }

        private void rdbEncoled_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDrive.Text = "*The power range for this calculation is 1 kW to 4480 kW.";
            txtPurchaseDrive.Text = "";
        }

        private void rdbDrip_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDrive.Text = "*The power range for this calculation is 1 kW to 4480 kW.";
            txtPurchaseDrive.Text = "";
        }

        private void rdbSquirrel_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteDrive.Text = "*The power range for this calculation is 4.48 kW to 97 kW.";
            txtPurchaseDrive.Text = "";
        }

        private void btnCalPD_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchasePumpDrive.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PumpDrive, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnCalCooling_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb33AppCooling.Checked == true && rdb55TempRCooling.Checked == true)
                {
                    alpha = 273999;
                    beta = 68757;
                }
                else if (rdb33AppCooling.Checked == true && rdb83TempRCooling.Checked == true)
                {
                    alpha = 338657;
                    beta = 77757;
                }
                else if (rdb33AppCooling.Checked == true && rdb139TempRCooling.Checked == true)
                {
                    alpha = 481528;
                    beta = 52506;
                }
                else if (rdb55AppCooling.Checked == true && rdb55TempRCooling.Checked == true)
                {
                    alpha = 150032;
                    beta = 51080;
                }
                else if (rdb55AppCooling.Checked == true && rdb83TempRCooling.Checked == true)
                {
                    alpha = 181160;
                    beta = 56088;
                }
                else if (rdb55AppCooling.Checked == true && rdb139TempRCooling.Checked == true)
                {
                    alpha = 213978;
                    beta = 63555;
                }
                double sizing_CoolingTower;
                sizing_CoolingTower = conCal.ConvertCapacityFlow_Unit(cbbUnitCooling.Text, txtCapCooling.Text, 0.2, 2.5);
                txtPurchaseCooling.Text = conCal.PurchaseCost_CoolingTower(alpha, beta, sizing_CoolingTower, 1, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }
        double min = 0;
        double max = 0;
        private void btnCalSr_Click(object sender, EventArgs e)
        {
            try
            {
                double volumnSR = Convert.ToDouble(txtVolumnStorage.Text);
                if (rdbSpherical.Checked == true)
                {
                    if (volumnSR < 1000)
                    {
                        alpha = 8641.9;
                        beta = 0.5464;
                        min = 100;
                        max = 1000;
                    }
                    else
                    {
                        alpha = 4799.1;
                        beta = 0.6315;
                        min = 1000;
                        max = 5000;
                    }
                }
                else if (rdbBullet.Checked == true)
                {
                    alpha = 8334.4;
                    beta = 0.4989;
                    min = 100;
                    max = 1000;
                }
                else if (rdbGasHolder.Checked == true)
                {
                    if (volumnSR < 1000)
                    {
                        alpha = 7020.2;
                        beta = 0.4978;
                        min = 100;
                        max = 1000;
                    }
                    else
                    {
                        alpha = 1926.5;
                        beta = 0.6945;
                        min = 1000;
                        max = 20000;
                    }
                }
                else if (rdblFloatingRoof.Checked == true)
                {
                    if (volumnSR < 2650)
                    {
                        alpha = 5289.2;
                        beta = 0.5018;
                        min = 750;
                        max = 2650;
                    }
                    else
                    {
                        alpha = 1415.6;
                        beta = 0.669;
                        min = 2650;
                        max = 60000;
                    }
                }
                else if (rdbConeRoof.Checked == true)
                {
                    if (volumnSR < 5680)
                    {
                        alpha = 980.35;
                        beta = 0.6522;
                        min = 100;
                        max = 5680;
                    }
                    else
                    {
                        alpha = 151.57;
                        beta = 0.8685;
                        min = 5680;
                        max = 60000;
                    }
                }
                //Material factor
                if (rdbCSStorage.Checked == true)
                {
                    af = 1;
                }
                else if (rdbRubberStorage.Checked == true)
                {
                    af = 1.25;
                }
                else if (rdbSSStorage.Checked == true)
                {
                    af = 1.5;
                }
                else if (rdbGlassStorage.Checked == true)
                {
                    af = 2.85;
                }
                double sizing_Storage;
                sizing_Storage = conCal.ConvertCapacity_Unit(cbbUnitStorage.Text, txtVolumnStorage.Text, min, max);
                txtPurchaseSr.Text = conCal.PurchaseCost(alpha, beta, sizing_Storage, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void rdbSpherical_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteStorage.Text = "*The volume range for this calculation is 100 m3 to 5000 m3.";
            txtPurchaseSr.Text = "";
        }

        private void rdbBullet_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteStorage.Text = "*The volume range for this calculation is 100 m3 to 1000 m3.";
            txtPurchaseSr.Text = "";
        }

        private void rdbGasHolder_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteStorage.Text = "*The volume range for this calculation is 100 m3 to 20,000 m3.";
            txtPurchaseSr.Text = "";
        }

        private void rdblFloatingRoof_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteStorage.Text = "*The volume range for this calculation is 750 m3 to 60,000 m3.";
            txtPurchaseSr.Text = "";
        }

        private void rdbConeRoof_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteStorage.Text = "*The volume range for this calculation is 100 m3 to 60,000 m3.";
            txtPurchaseSr.Text = "";
        }

        private void btnCalTb_Click(object sender, EventArgs e)
        {
            try
            {
                alpha = 3316.1;
                beta = 0.5889;
                //Material factor
                if (rdbCSTurbine.Checked == true)
                {
                    af = 1;
                }
                else if (rdbSSTurbine.Checked == true)
                {
                    af = 2;
                }
                else if (rdbNATurbine.Checked == true)
                {
                    af = 3;
                }
                double sizing_Turbine;
                sizing_Turbine = conCal.ConvertPower_Unit(cbbUnitTurbine.Text, txtPowerTurbine.Text, 100, 4000);
                txtPurchaseTB.Text = conCal.PurchaseCost(alpha, beta, sizing_Turbine, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void rdbVR_CheckedChanged(object sender, EventArgs e)
        {
            tabReactor.Enabled = true;
            tabReactor.SelectedIndex = 0;
            txtPurchaseR.Text = "";
        }

        private void rdbPFR_CheckedChanged(object sender, EventArgs e)
        {
            tabReactor.Enabled = true;
            tabReactor.SelectedIndex = 1;
            txtPurchaseR.Text = "";
        }

        private void btnHelpPFR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Material abbreviation:" + "\n" + "\n" + "CS-Carbon Steel" + "\n" + "CU-Copper" + "\n" + "SS-Stainless Steel" + "\n" + "Ni Alloy-Nickel Alloy" + "\n" + "Ti-Titanium", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCalPFR_Click(object sender, EventArgs e)
        {
            try
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
                txtPurchaseR.Text = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PFR, af, CPI_Index);
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnCalVR_Click(object sender, EventArgs e)
        {
            double sizing_PFR, sizing_vessel;
            string CalCost;
            try
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
                    CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_PFR, af, CPI_Index);
                    txtPurchaseR.Text = (Convert.ToDouble(CalCost) * pf).ToString("#,##0.##");
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
                    CalCost = conCal.PurchaseCost(alpha, beta, sizing_vessel, af, CPI_Index);
                    txtPurchaseR.Text = (Convert.ToDouble(CalCost) * pf).ToString("#,##0.##");
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }              
        }

        private void rdb05VR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVertical.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 1.5 m to 20 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 1.5 m to 25.4 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdb1VR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVertical.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 2.5 m to 30 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 2.3 m to 30.4 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdb2VR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVertical.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 4 m to 45 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 4.3 m to 41.1 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdb3VR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVertical.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 6 m to 50 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 6.5 m to 48.7 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdb4VR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVertical.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 7 m to 50 m.";
            }
            else if (rdbHorizontal.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 7.9 m to 53.7 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdbVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb05VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 1.5 m to 20 m.";
            }
            else if (rdb1VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 2.5 m to 30 m.";
            }
            else if (rdb2VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 4 m to 45 m.";
            }
            else if (rdb3VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 6 m to 50 m.";
            }
            else if (rdb4VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 7 m to 50 m.";
            }
            txtPurchaseR.Text = "";
        }

        private void rdbHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb05VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 1.5 m to 25.4 m.";
            }
            else if (rdb1VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 2.3 m to 30.4 m.";
            }
            else if (rdb2VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 4.3 m to 41.1 m.";
            }
            else if (rdb3VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 6.5 m to 48.7 m.";
            }
            else if (rdb4VR.Checked == true)
            {
                lblNoteVR.Text = "*The height range for this calculation is 7.9 m to 53.7 m.";
            }
            txtPurchaseR.Text = "";
        }
        double PurchaseCost_Col = 0;
        double PurchaseCost_Tray = 0;
        private void btnCalTU_Click(object sender, EventArgs e)
        {           
            try
            {
                double sizing_Col, sizing_Tray;
                //double PurchaseCost_Tray = 0;
                string CalCost;
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
                //Column Calculation
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
                sizing_Col = conCal.ConvertHeight_Unit(cbbUnitTU.Text, txtHeightTU.Text, min, max);
                CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Col, af, CPI_Index);
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
                    CalCost = conCal.PurchaseCost_SecondMethod(a1, b1, c1, d1, e1, f1, CapitalC, sizing_Tray, afTray, CPI_Index);
                    PurchaseCost_Tray = Convert.ToDouble(CalCost) * NumTrayAdd;
                }
                else
                {
                    PurchaseCost_Tray = 0;
                }
                txtPurchaseTU.Text = (PurchaseCost_Col + PurchaseCost_Tray).ToString("#,##0.##");
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the information correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
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
                txtDiameterTTU.Text = "";
            }
        }

        private void rdb05TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation is 1.5 m to 20 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdb1TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation is 2.5 m to 30 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdb2TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation is 4 m to 45 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdb3TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation is 6 m to 50 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdb4TU_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTU.Text = "*The height range for this calculation is 7 m to 50 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbCSST_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.5 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbCSVT_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.61 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbSSST_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.61 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbSTBGTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.61 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbVTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.61 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void rdbBCTSS_CheckedChanged(object sender, EventArgs e)
        {
            lblNoteTTU.Text = "*The length range for this calculation is 0.61 m to 3.81 m.";
            txtPurchaseTU.Text = "";
        }

        private void cbbUtilityOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbUtilityOther.Text == "Other")
            {
                txtOtherUtilityName.ReadOnly = false;
            }
            else
            {
                txtOtherUtilityName.ReadOnly = true;
            }
        }

        private void btnDoneComp_Click(object sender, EventArgs e)
        {
            string[] MatComp = {"Carbon steel", "Stainless steel", "Nickel alloy"};                      
            //Purchase Cost has no value
            if (txtPurchaseComp.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameComp.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtPowerComp.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtPowerComp.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbPowerCompUnit.Text;
                //Material
                if (rdbCarbon_Comp.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatComp[0];
                }
                else if (rdbStainless_Comp.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatComp[1];
                }
                else if (rdbNickel_Comp.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatComp[2];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseComp.Text;
                Eqip_Control.SelectedIndex = 0;
            }          
        }

        private void btnDoneCooling_Click(object sender, EventArgs e)
        {
            //Purchase Cost has no value
            if (txtPurchaseCooling.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameCooling.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtCapCooling.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtCapCooling.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitCooling.Text;
                //Material
                dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "-";
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseCooling.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneDirectHeater_Click(object sender, EventArgs e)
        {
            string[] MatDirect = { "Carbon steel", "Chrome/Moly", "Stainless steel" };

            //Purchase Cost has no value
            if (txtPurchaseDirectHeater.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameDirectHeater.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtHeaterDuty.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtHeaterDuty.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitDireactHeater.Text;
                //Material
                if (rdbCS690.Checked == true || rdbCS1035.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatDirect[0];
                }
                else if (rdbCS6890.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatDirect[1];
                }
                else if (rdbCS10340.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatDirect[2];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseDirectHeater.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneDrive_Click(object sender, EventArgs e)
        {
            //Purchase Cost has no value
            if (txtPurchaseDrive.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipName.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtPowerDrive.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtPowerDrive.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitDrive.Text;
                //Material
                dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "-";
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseDrive.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneFurnance_Click(object sender, EventArgs e)
        {
            string[] MatFurnance = { "Carbon steel", "Chrome/Moly", "Stainless steel" };

            //Purchase Cost has no value
            if (txtPurchaseFurnance.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameFurnance.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtHeatDutyFurnance.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtHeatDutyFurnance.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitFurnance.Text;
                //Material
                if (rdb3450Furnance.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatFurnance[0];
                }
                else if (rdb6895Furnance.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatFurnance[1];
                }
                else if (rdb13790Furnance.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatFurnance[2];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseFurnance.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneMixer_Click(object sender, EventArgs e)
        {
            string[] MatMixer = { "Carbon steel", "Stainless steel" };

            //Purchase Cost has no value
            if (txtPurchaseMixer.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameMixer.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtCapMixer.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtCapMixer.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitMixer.Text;
                //Material
                if (rdbCSMixer.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[0];
                }
                else if (rdbStainlessMixer.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[1];
                }               
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseMixer.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDonePump_Click(object sender, EventArgs e)
        {
            string[] MatMixer = { "Cast iron", "Cast steel", "Stainless steel", "Nickel alloy"};

            //Purchase Cost has no value
            if (txtPurchasePump.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNamePump.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtPumpCap.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtPumpCap.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitPump.Text;
                //Material
                if (rdbCastIronPump.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[0];
                }
                else if (rdbCastSteelPump.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[1];
                }
                else if (rdbStainlessSteelPump.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[2];
                }
                else if (rdbNickelAlloyPump.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatMixer[3];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchasePump.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDonePD_Click(object sender, EventArgs e)
        {
            //Purchase Cost has no value
            if (txtPurchasePumpDrive.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipPumpDrive.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtsizePumpDrive.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtsizePumpDrive.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitPumpDrive.Text;
                //Material
                dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "-";
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchasePumpDrive.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneSr_Click(object sender, EventArgs e)
        {
            string[] MatSr = { "Carbon steel", "Rubber-lined", "Stainless steel", "Glass-lined" };

            //Purchase Cost has no value
            if (txtPurchaseSr.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipStorage.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtVolumnStorage.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtVolumnStorage.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitStorage.Text;
                //Material
                if (rdbCSStorage.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatSr[0];
                }
                else if (rdbRubberStorage.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatSr[1];
                }
                else if (rdbSSStorage.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatSr[2];
                }
                else if (rdbGlassStorage.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatSr[3];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseSr.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneTB_Click(object sender, EventArgs e)
        {
            string[] MatTurbine = { "Carbon steel", "Stainless steel", "Nickel alloy" };
            //Purchase Cost has no value
            if (txtPurchaseTB.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipTB.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtPowerTurbine.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtPowerTurbine.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitTurbine.Text;
                //Material
                if (rdbCSTurbine.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTurbine[0];
                }
                else if (rdbSSTurbine.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTurbine[1];
                }
                else if (rdbNATurbine.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTurbine[2];
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseTB.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneHx_Click(object sender, EventArgs e)
        {
            string[] MatAirCooled = { "Carbon steel", "Stainless steel", "Titanium", "Copper", "Nickel alloy" };
            //Purchase Cost has no value
            if (txtPurchaseCostHx.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameHx.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;                
                ////Air Cooled
                if (rdbAirCooled.Checked == true)
                {
                    //Sizing
                    if (txtAreaAirCooled.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaAirCooled.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitAirCooled.Text;
                    //Material
                    if (rdbCSAirCooled.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[0];
                    }
                    else if (rdbSSAirCooled.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[1];
                    }
                    else if (rdbTiAirCooled.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[2];
                    }
                    else if (rdbCAirCooled.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[3];
                    }
                    else if (rdbNAAirCooled.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[4];
                    }
                }
                else if (rdbDoublePipe.Checked == true)
                {
                    //Sizing
                    if (txtDoubleArea.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtDoubleArea.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbDoubleUnit.Text;
                    //Material
                    if (rdbCSTS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Carbon steel tube and shell";
                    }
                    else if (rdbATCSS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Admiralty tube and carbon steel shell";
                    }
                    else if (rdbSSTCSS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Stainless Steel tube and Carbon Steel shell";
                    }                   
                }
                else if (rdbMultiplePipe.Checked == true)
                {
                    //Sizing
                    if (txtAreaMulti.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaMulti.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitMulti.Text;
                    //Material
                    if (rdbCSMulti.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Carbon steel tube and shell";
                    }
                    else if (rdbATMulti.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Admiralty tube and carbon steel shell";
                    }
                    else if (rdbSSMulti.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "Stainless Steel tube and Carbon Steel shell";
                    }
                }
                else if (rdbFixedTube.Checked == true)
                {
                    //Sizing
                    if (txtAreaFT.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaFT.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitFT.Text;
                    //Material
                    if (rdbCS_FT.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[0];
                    }
                    else if (rdb304SS_FT.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[1];
                    }
                    else if (rdb316SS_FT.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[1];
                    }
                }
                else if (rdbUTube.Checked == true)
                {
                    //Sizing
                    if (txtAreaU.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaU.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitU.Text;
                    //Material
                    if (rdbCSU.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[0];
                    }
                    else if (rdbSSU.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatAirCooled[1];
                    }                   
                }
                else if (rdbFloatingHead.Checked == true)
                {
                    //Sizing
                    if (txtAreaFH.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaFH.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitFH.Text;
                    //Material
                    if (rdbCSCS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and CS tube";
                    }
                    else if (rdbCSCU.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and CU tube";
                    }
                    else if (rdbCSSS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and SS tube";
                    }
                    else if (rdbCSNi.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and Ni alloy tube";
                    }
                    else if (rdbSSSS.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "SS shell and SS tube";
                    }
                    else if (rdbCSTi.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and Ti tube";
                    }
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseCostHx.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneR_Click(object sender, EventArgs e)
        {
            string[] MatReactor = { "Carbon steel", "Stainless steel", "Nickel alloy" };
            //Purchase Cost has no value
            if (txtPurchaseR.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation., and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipReactor.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                ////Air Cooled
                if (rdbVR.Checked == true)
                {
                    //Sizing
                    if (txtAreaVR.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaVR.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitVR.Text;
                    //Material
                    if (rdbCSVR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatReactor[0];
                    }
                    else if (rdbSSVR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatReactor[1];
                    }
                    else if (rdbNAVR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatReactor[2];
                    }
                }
                else if (rdbPFR.Checked == true)
                {
                    //Sizing
                    if (txtAreaPFR.Text == "")
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                    }
                    else
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtAreaPFR.Text;
                    }
                    //Unit Sizing
                    dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitPFR.Text;
                    //Material
                    if (rbdCSCSR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and CS tube";
                    }
                    else if (rdbCSCUR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and CU tube";
                    }
                    else if (rdbCSSSR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and SS tube";
                    }
                    else if (rdbCSNiR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and Ni alloy tube";
                    }
                    else if (rdbSSSSR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "SS shell and SS tube";
                    }
                    else if (rdbCSTiR.Checked == true)
                    {
                        dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = "CS shell and Ti tube";
                    }
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = txtPurchaseR.Text;
                Eqip_Control.SelectedIndex = 0;
            }
        }

        private void btnDoneTU_Click(object sender, EventArgs e)
        {
            string[] MatTowerUnit = { "Carbon steel", "Stainless steel", "Nickel alloy" };
            string[] TypeTray = { "Sieve tray", "Valve tray", "Sieve or bubble cap tray", "Bubble cap tray",  "Stamped turbogrid tray" };
            string TrayMaterial = "";
            string TrayType = "";
            //Purchase Cost has no value
            if (txtPurchaseTU.Text == "")
            {
                MessageBox.Show("Please ensure the completion of all required fields for this calculation, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Name of Equipment 
                dgvEquipmentSummary.SelectedRows[0].Cells[0].Value = txtEquipNameTU.Text;
                //Type of equipment
                dgvEquipmentSummary.SelectedRows[0].Cells[1].Value = cbbTypeOfEquip.Text;
                //Sizing
                if (txtHeightTU.Text == "")
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = "-";
                }
                else
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = txtHeightTU.Text;
                }
                //Unit Sizing
                dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = cbbUnitTU.Text;
                //Material
                if (rdbCSTU.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTowerUnit[0];
                    
                }
                else if (rdbSSTU.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTowerUnit[1];
                    TrayMaterial = MatTowerUnit[1];
                }
                else if (rdbNATU.Checked == true)
                {
                    dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = MatTowerUnit[2];
                    TrayMaterial = MatTowerUnit[2];
                }
                //Tray check
                if (cbTrayCheck.Checked == true)
                {
                    if (rdbCSST.Checked == true)
                    {
                        TrayType = TypeTray[0];
                        TrayMaterial = MatTowerUnit[0];
                    }
                    else if (rdbCSVT.Checked == true)
                    {
                        TrayType = TypeTray[1];
                        TrayMaterial = MatTowerUnit[0];
                    }
                    else if (rdbSSST.Checked == true)
                    {
                        TrayType = TypeTray[2];
                        TrayMaterial = MatTowerUnit[1];
                    }
                    else if (rdbSTBGTSS.Checked == true)
                    {
                        TrayType = TypeTray[4];
                        TrayMaterial = MatTowerUnit[1];
                    }
                    else if (rdbVTSS.Checked == true)
                    {
                        TrayType = TypeTray[1];
                        TrayMaterial = MatTowerUnit[1];
                    }
                    else if (rdbBCTSS.Checked == true)
                    {
                        TrayType = TypeTray[4];
                        TrayMaterial = MatTowerUnit[1];
                    }
                    dgvEquipmentSummary.Rows.Add(txtTrayName.Text, TrayType, "-", "-", "-", nudNumTray.Text, "trays", TrayMaterial, PurchaseCost_Tray.ToString());                   
                }
                //Purchase cost has value
                dgvEquipmentSummary.SelectedRows[0].Cells[8].Value = PurchaseCost_Col.ToString();
                Eqip_Control.SelectedIndex = 0;                
            }
        }

        private void btnDoneOther_Click(object sender, EventArgs e)
        {
            double OtherPurchaseCost;
            string OTherType;
            if (cbbUtilityOther.Text == "Other")
            {
                OTherType = txtOtherUtilityName.Text;
            }
            else
            {
                OTherType = cbbUtilityOther.Text;
            }          
            try
            {
                OtherPurchaseCost = Convert.ToDouble(txtOtherPurchaseCost.Text);
                dgvEquipmentSummary.Rows.Add(txtOtherEquipName.Text, "Other", txtUtilityQuantity.Text, cbbUnitOther.Text, OTherType, "-", "-", "-", OtherPurchaseCost);
                Eqip_Control.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Please ensure you type the purchase cost correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void rdbCustomCapCost_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvEquipmentSummary.Rows.Count == 0)
            {
                MessageBox.Show("The Equipment Table must be imported before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvOnetime_CC.Columns.Clear();
                dgvOnetime_CC.Rows.Clear();
                dgvWorkingCapital.Columns.Clear();
                dgvWorkingCapital.Rows.Clear();
                //gbCapitalCost.Text = "Capital Cost for One-time expenses";
                //Datagridview for One-time expense
                string[] OneTimeExpense = { "No.", "Name List of One-time expenses", "Cost ($)" };
                //Add Column name
                con.HeaderTable(dgvOnetime_CC, OneTimeExpense);
                con.HeaderTable(dgvWorkingCapital, OneTimeExpense);
                //Add Row data Fixed Capital Investment
                string[] List_CC = { "Land acquisition cost", "Building construction cost", "Engineering and design cost", "Permits and licenses cost", "Construction labor cost", "Pre-production testing cost" };
                for (int i = 0; i < List_CC.Length; i++)
                {
                    dgvOnetime_CC.Rows.Add("", List_CC[i], "");
                }

                if (dgvOnetime_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Add Row data Working Capital Investment
                dgvWorkingCapital.Rows.Add("1", "Working Capital Investmenst (WC)", "");
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                    {
                        dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                txtTotal_CC.Text = "";
                Total_CapitalCost = 0;
            }
        }
        
        private void rdbECONCapCost_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvEquipmentSummary.Rows.Count == 0)
            {
                MessageBox.Show("The Equipment Table must be imported before proceeding to the this step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {              
                dgvOnetime_CC.Rows.Clear();
                dgvOnetime_CC.Columns.Clear();
                dgvWorkingCapital.Columns.Clear();
                dgvWorkingCapital.Rows.Clear();               
                double TotalEquipCost = 0;
                for  (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                {
                    if (dgvEquipment_CC.Rows[i].Cells[3].Value == null || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        TotalEquipCost += 0;
                        dgvEquipment_CC.Rows[i].Cells[3].Value = "-";
                    }
                    else if (dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "-")
                    {
                        TotalEquipCost += 0;
                    }
                    else
                    {
                        TotalEquipCost += Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                    }
                }
                //Datagridview from ECON software logic
                string[] ECONExpense = { "No", "Name List of ECON expenses", "Percentage", "Cost ($)" };
                //Add Column name
                con.HeaderTable(dgvOnetime_CC, ECONExpense);
                con.HeaderTable(dgvWorkingCapital, ECONExpense);
                double Impact_Process = 1.1;
                double Process_Factor = 0.89; 
                if (cbbProcessCap.Text == "Fluid processing")
                {
                    Process_Factor = 0.89;
                }
                else if (cbbProcessCap.Text == "Solid-fluid processing")
                {
                    Process_Factor = 0.75;
                }
                else if (cbbProcessCap.Text == "Solid processing")
                {
                    Process_Factor = 0.7;
                }
                double Purchase_EquipDeli = TotalEquipCost * Impact_Process;
                double TotalCapCost = Purchase_EquipDeli;
                dgvOnetime_CC.Rows.Add("", "Purchased Equipment Delivered", Impact_Process, Purchase_EquipDeli.ToString("#,##0.##"));
                string[] List_ECON = { "Purchased Equipment Installation", "Instrumentation and Controls (installed)", "Piping (Installed)", "Electrical Systems (Installed)",
                "Buildings (Including Services)", "Yard Improvement", "Service Facilities (Installed)", "Engineering and Supervision", "Construction Expenses", "Legal Expenses", "Contractor's Fees", "Contingency"};
                double[] Percent_ECON = { 0.47, 0.36, 0.68, 0.11, 0.18, 0.1, 0.7, 0.33, 0.41, 0.04, 0.22, 0.44};
                for (int i = 0; i < List_ECON.Length; i++)
                {
                    dgvOnetime_CC.Rows.Add("", List_ECON[i], Percent_ECON[i].ToString(), (Purchase_EquipDeli * Percent_ECON[i]).ToString("#,##0.##"));
                    TotalCapCost += (Purchase_EquipDeli * Percent_ECON[i]);
                }

                //Working Capital Investmenst (WC) Cost
                dgvWorkingCapital.Rows.Add("1", "Working Capital Investmenst (WC)", Process_Factor.ToString(), (Purchase_EquipDeli * Process_Factor).ToString("#,##0.##"));
                TotalCapCost += (Purchase_EquipDeli * Process_Factor);

                if (dgvOnetime_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                    {
                        dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                txtTotal_CC.Text = TotalCapCost.ToString("#,##0.##");
            }           
        }

        private void btnClearCap_Click(object sender, EventArgs e)
        {
            btnCapitalCost.BackColor = Color.Transparent;
            btnMaintenanceCost.BackColor = Color.Transparent;
            btnSalvageValue.BackColor = Color.Transparent;
            count = 0;
            Total_CapitalCost = 0;           
            salvage_count = 0;
            TotalSalvage = 0;
            tabpage.SelectedIndex = 0;
        }

        private void rdbOverallFeed_CheckedChanged(object sender, EventArgs e)
        {          
            txtOverallFeed.Enabled = true;
            List<double> TotalStreamFeed = new List<double>();
            TotalStreamFeed.Clear();
            //Add Data of each stream to operating cost Table
            double TotalFeed;
            if (dgvStreamOPC.Rows.Count != 0)
            {
                for (int j = 0; j < dgvStreamOPC.Columns.Count - 4; j++)
                {
                    TotalFeed = 0;
                    for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
                    {
                        TotalFeed += Convert.ToDouble(dgvStreamOPC.Rows[i].Cells[j + 3].Value.ToString());
                    }
                    TotalStreamFeed.Add(TotalFeed);
                }
                //Operating Cost for stream Table
                dgvStreamOPC.Rows.Clear();
                dgvStreamOPC.Columns.Clear();
                stream_OPC.Clear();
                //Findstream_OPC.Clear();
                stream_OPC.Add("Stream Name");
                stream_OPC.Add("");
                stream_OPC.Add("");
                for (int i = 0; i < dgvStream_OpC.Rows.Count; i++)
                {
                    stream_OPC.Add(dgvStream_OpC.Rows[i].Cells[0].Value.ToString());
                }
                stream_OPC.Add("");
                con.HeaderTableFromList(dgvStreamOPC, stream_OPC);
                dgvStreamOPC.Rows.Add("", "", "", "", "", "");
                dgvStreamOPC.Rows.Add("Test");
                //Add Data of each stream to operating cost Table
                for (int j = 0; j < dgvStreamOPC.Columns.Count - 4; j++)
                {                  
                    dgvStreamOPC.Rows[1].Cells[j + 3].Value = TotalStreamFeed[j].ToString("#,##0.##");
                    dgvStreamOPC.Rows[0].Cells[j + 3].Value = "Mass flow rate (kg/hr)";                    
                }
                dgvStreamOPC.Rows[0].Cells[0].Value = "List of Component";
                dgvStreamOPC.Rows[0].Cells[1].Value = "Unit Price ($)";
                dgvStreamOPC.Rows[0].Cells[2].Value = "Working hour (hr.)";               
                dgvStreamOPC.Rows[0].Cells[dgvStreamOPC.Columns.Count - 1].Value = "Total Cost ($)";
                dgvStreamOPC.Rows[1].Cells[0].Value = txtOverallFeed.Text;
                dgvStreamOPC.Rows[1].Cells[1].Value = "";
                dgvStreamOPC.Rows[1].Cells[2].Value = txtNumHour_OpC.Text;
                dgvStreamOPC.Rows[1].Cells[dgvStreamOPC.Columns.Count - 1].Value = "";
            }
        }

        private void rdbMixtureFeed_CheckedChanged(object sender, EventArgs e)
        {
            txtOverallFeed.Enabled = false;
            if (dgvStreamOPC.Rows.Count != 0)
            {
                //Operating Cost for stream Table
                dgvStreamOPC.Rows.Clear();
                dgvStreamOPC.Columns.Clear();
                stream_OPC.Clear();
                Findstream_OPC.Clear();
                stream_OPC.Add("Stream Name");
                stream_OPC.Add("");
                stream_OPC.Add("");
                for (int i = 0; i < dgvStream_OpC.Rows.Count; i++)
                {
                    stream_OPC.Add(dgvStream_OpC.Rows[i].Cells[0].Value.ToString());
                }
                stream_OPC.Add("");
                con.HeaderTableFromList(dgvStreamOPC, stream_OPC);

                for (int i = 0; i < ComponentName.Count; i++)
                {
                    dgvStreamOPC.Rows.Add(ComponentName[i]);
                }

                //Find Column in original stream
                if (stream_OPC.Count > 2)
                {
                    for (int j = 2; j < stream_OPC.Count; j++)
                    {
                        for (int k = 0; k < StreamName.Count; k++)
                        {
                            if (stream_OPC[j] == StreamName[k])
                            {
                                Findstream_OPC.Add(k);
                            }
                        }
                    }
                }
                //Add Data of each stream to operating cost Table
                for (int i = 1; i < dgvStreamTablePreview.Rows.Count; i++)
                {
                    for (int j = 0; j < Findstream_OPC.Count; j++)
                    {
                        dgvStreamOPC.Rows[i].Cells[j + 3].Value = Convert.ToDouble(dgvStreamTablePreview.Rows[i].Cells[Findstream_OPC[j]].Value.ToString()).ToString("#,##0.##");
                    }
                }

                dgvStreamOPC.Rows[0].Cells[0].Value = "List of Component";
                dgvStreamOPC.Rows[0].Cells[1].Value = "Unit Price ($)";
                dgvStreamOPC.Rows[0].Cells[2].Value = "Working hour (hr.)";
                for (int j = 0; j < Findstream_OPC.Count; j++)
                {
                    dgvStreamOPC.Rows[0].Cells[j + 3].Value = "Mass flow rate (kg/hr)";
                }
                dgvStreamOPC.Rows[0].Cells[dgvStreamOPC.Columns.Count - 1].Value = "Total Cost ($)";

                for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
                {
                    dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
                }
            }
        }
        double TotalOPforEconEval = 0;
        private void btnCalOPC_Click(object sender, EventArgs e)
        {
            //Operating for Cost stream
            double InterestRateCal;
            InterestRateCal = con.Cal_AnnualToPresent(txtInterestRate.Text, txtPeriod.Text);
            double Total_EachRowStream, CostComponent;
            int RowCount = dgvStreamOPC.Rows.Count - 1;           
            for (int i = 1; i < RowCount; i++)
            {
                Total_EachRowStream = 0;
                for (int j = 0; j < Findstream_OPC.Count; j++)
                {
                    Total_EachRowStream += Convert.ToDouble(dgvStreamOPC.Rows[i].Cells[j + 3].Value.ToString());                   
                }               
                if (dgvStreamOPC.Rows[i].Cells[1].Value == null || dgvStreamOPC.Rows[i].Cells[1].Value.ToString() == "")
                {
                    dgvStreamOPC.Rows[i].Cells[1].Value = "-";
                    CostComponent = 0;
                }
                else if (dgvStreamOPC.Rows[i].Cells[1].Value.ToString() == "-")
                {
                    CostComponent = 0;
                }
                else
                {
                    CostComponent = Convert.ToDouble(dgvStreamOPC.Rows[i].Cells[1].Value.ToString());
                }
                dgvStreamOPC.Rows[i].Cells[dgvStreamOPC.Columns.Count - 1].Value = (CostComponent * (Total_EachRowStream * Convert.ToDouble(dgvStreamOPC.Rows[1].Cells[2].Value.ToString()))).ToString("#,##0.##");
            }

            //Operating Cost for Utility
            double DutyEquip, WorkingEquip, CostEquip;
            for (int i = 0; i < dgvEquipmentOPC.Rows.Count - 1; i++)
            {
                DutyEquip = Math.Abs(Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[1].Value.ToString()));
                WorkingEquip = Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[3].Value.ToString());
                if (dgvEquipmentOPC.Rows[i].Cells[4].Value == null || dgvEquipmentOPC.Rows[i].Cells[4].Value.ToString() == "")
                {
                    CostEquip = 0;
                    dgvEquipmentOPC.Rows[i].Cells[4].Value = "-";
                }
                else if (dgvEquipmentOPC.Rows[i].Cells[4].Value.ToString() == "-")
                {
                    CostEquip = 0;
                }
                else
                {
                    CostEquip = Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[4].Value.ToString());
                }
                //Show Total Cost
                dgvEquipmentOPC.Rows[i].Cells[5].Value = (DutyEquip * WorkingEquip * CostEquip).ToString("#,##0.##");
            }

            //Operating for Labor
            double NumLabor, Working_time, CostSalary, TotalLaborCost;
            //Labor Cost (per hour)
            for (int i = 0; i < dgvLaborOPC.Rows.Count - 1; i++)
            {
                try
                {
                    //Number of labor
                    if (dgvLaborOPC.Rows[i].Cells[1].Value == null || dgvLaborOPC.Rows[i].Cells[1].Value.ToString() == "")
                    {
                        NumLabor = 0;
                        dgvLaborOPC.Rows[i].Cells[1].Value = "-";
                    }
                    else if (dgvLaborOPC.Rows[i].Cells[1].Value.ToString() == "-")
                    {
                        NumLabor = 0;
                    }
                    else
                    {
                        NumLabor = Convert.ToDouble(dgvLaborOPC.Rows[i].Cells[1].Value.ToString());
                    }

                    //Working hour
                    if (dgvLaborOPC.Rows[i].Cells[2].Value == null || dgvLaborOPC.Rows[i].Cells[2].Value.ToString() == "")
                    {
                        Working_time = 0;
                        dgvLaborOPC.Rows[i].Cells[2].Value = "-";
                    }
                    else if (dgvLaborOPC.Rows[i].Cells[2].Value.ToString() == "-")
                    {
                        Working_time = 0;
                    }
                    else
                    {
                        Working_time = Convert.ToDouble(dgvLaborOPC.Rows[i].Cells[2].Value.ToString());
                    }

                    //Salary                   
                    if (dgvLaborOPC.Rows[i].Cells[3].Value == null || dgvLaborOPC.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        CostSalary = 0;
                        dgvLaborOPC.Rows[i].Cells[3].Value = "-";
                    }
                    else if (dgvLaborOPC.Rows[i].Cells[3].Value.ToString() == "-")
                    {
                        CostSalary = 0;
                    }
                    else
                    {
                        CostSalary = Convert.ToDouble(dgvLaborOPC.Rows[i].Cells[3].Value.ToString());
                    }                   
                    TotalLaborCost = NumLabor * Working_time * CostSalary;
                    dgvLaborOPC.Rows[i].Cells[4].Value = TotalLaborCost.ToString("#,##0.##");
                }
                catch
                {
                    MessageBox.Show("Please ensure you add the information in Labor Cost (per hour) table correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            //Labor Cost (per month)
            for (int i = 0; i < dgvLaborMonth.Rows.Count - 1; i++)
            {
                try
                {
                    //Number of labor
                    if (dgvLaborMonth.Rows[i].Cells[1].Value == null || dgvLaborMonth.Rows[i].Cells[1].Value.ToString() == "")
                    {
                        NumLabor = 0;
                        dgvLaborMonth.Rows[i].Cells[1].Value = "-";
                    }
                    else if (dgvLaborMonth.Rows[i].Cells[1].Value.ToString() == "-")
                    {
                        NumLabor = 0;
                    }
                    else
                    {
                        NumLabor = Convert.ToDouble(dgvLaborMonth.Rows[i].Cells[1].Value.ToString());
                    }

                    //Working hour
                    if (dgvLaborMonth.Rows[i].Cells[2].Value == null || dgvLaborMonth.Rows[i].Cells[2].Value.ToString() == "")
                    {
                        Working_time = 0;
                        dgvLaborMonth.Rows[i].Cells[2].Value = "-";
                    }
                    else if (dgvLaborMonth.Rows[i].Cells[2].Value.ToString() == "-")
                    {
                        Working_time = 0;
                    }
                    else
                    {
                        Working_time = Convert.ToDouble(dgvLaborMonth.Rows[i].Cells[2].Value.ToString());
                    }

                    //Salary                   
                    if (dgvLaborMonth.Rows[i].Cells[3].Value == null || dgvLaborMonth.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        CostSalary = 0;
                        dgvLaborMonth.Rows[i].Cells[3].Value = "-";
                    }
                    else if (dgvLaborMonth.Rows[i].Cells[3].Value.ToString() == "-")
                    {
                        CostSalary = 0;
                    }
                    else
                    {
                        CostSalary = Convert.ToDouble(dgvLaborMonth.Rows[i].Cells[3].Value.ToString());
                    }
                    TotalLaborCost = NumLabor * Working_time * CostSalary;
                    dgvLaborMonth.Rows[i].Cells[4].Value = TotalLaborCost.ToString("#,##0.##");
                }
                catch
                {
                    MessageBox.Show("Please ensure you add the information in Labor Cost (per month) table correctly, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Calculation for Total Cost of Operating Cost
            double TotalOperatingCost;
            TotalOperatingCost = 0;
            for (int i = 1; i < dgvStreamOPC.Rows.Count - 1; i++)
            {
                TotalOperatingCost += Convert.ToDouble(dgvStreamOPC.Rows[i].Cells[dgvStreamOPC.Columns.Count - 1].Value.ToString());
            }
            for (int i = 0; i < dgvEquipmentOPC.Rows.Count - 1; i++)
            {
                TotalOperatingCost += Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[dgvEquipmentOPC.Columns.Count - 1].Value.ToString());
            }
            for (int i = 0; i < dgvLaborOPC.Rows.Count - 1; i++)
            {
                TotalOperatingCost += Convert.ToDouble(dgvLaborOPC.Rows[i].Cells[dgvLaborOPC.Columns.Count - 1].Value.ToString());
            }
            for (int i = 0; i < dgvLaborMonth.Rows.Count - 1; i++)
            {
                TotalOperatingCost += Convert.ToDouble(dgvLaborMonth.Rows[i].Cells[dgvLaborMonth.Columns.Count - 1].Value.ToString());
            }

            txtTotal_OPC.Text = (TotalOperatingCost / InterestRateCal).ToString("#,##0.##");

            //For Total Product Cost Calculation in Economic evaluation
            TotalOPforEconEval = 0;
            TotalOPforEconEval = TotalOperatingCost;           
        }

        private void rdbRecip_GasTurbine_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbRecip_Motor_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbRecip_Stream_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbCarbon_Comp_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbStainless_Comp_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdbNickel_Comp_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseComp.Text = "";
        }

        private void rdb33AppCooling_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCooling.Text = "";
        }

        private void rdb55AppCooling_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCooling.Text = "";
        }

        private void rdb55TempRCooling_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCooling.Text = "";
        }

        private void rdb83TempRCooling_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCooling.Text = "";
        }

        private void rdb139TempRCooling_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCooling.Text = "";
        }

        private void rdb3450Furnance_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseFurnance.Text = "";
        }

        private void rdb6895Furnance_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseFurnance.Text = "";
        }

        private void rdb13790Furnance_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseFurnance.Text = "";
        }

        private void rdbCSAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbSSAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbTiAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbNAAirCooled_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb4135Double_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb6205Double_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb10340Double_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb20680Double_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb30000Double_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSMulti_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbATMulti_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbSSMulti_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb4135Multi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb6205Multi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb10340Multi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb20680Multi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb30000Multi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCS_FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb304SS_FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb316SS_FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb1035FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb5000FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb10000FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb15000FT_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb1035U_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb5000U_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb10000U_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb15000U_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSCS_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSCU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSSS_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSNi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbSSSS_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSTi_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb690FH_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb1035FH_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb2070FH_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb3105FH_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdb6895FH_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseCostHx.Text = "";
        }

        private void rdbCSMixer_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseMixer.Text = "";
        }

        private void rdbStainlessMixer_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseMixer.Text = "";
        }

        private void rdbCentifugalP_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdbCastIronPump_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdbCastSteelPump_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdbStainlessSteelPump_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdbNickelAlloyPump_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdb1035_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdb5000_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdb10000_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdb20000_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdb30000_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePump.Text = "";
        }

        private void rdbCSStorage_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseSr.Text = "";
        }

        private void rdbRubberStorage_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseSr.Text = "";
        }

        private void rdbSSStorage_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseSr.Text = "";
        }

        private void rdbGlassStorage_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseSr.Text = "";
        }

        private void rdbCSTurbine_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTB.Text = "";
        }

        private void rdbSSTurbine_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTB.Text = "";
        }

        private void rdbNATurbine_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTB.Text = "";
        }

        private void rdbCSVR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbSSVR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbNAVR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb101VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb1035VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb5000VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb10000VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb20000VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb30000VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb40000VR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rbdCSCSR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbCSCUR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbCSSSR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbCSNiR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbSSSSR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbCSTiR_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb690R_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb1035R_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb2070R_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb3105R_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdb6895R_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseR.Text = "";
        }

        private void rdbCSTU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdbSSTU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdbNATU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb101TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb1035TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb5000TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb10000TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb20000TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb30000TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdb40000TU_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchaseTU.Text = "";
        }

        private void rdbCustomSV_CheckedChanged(object sender, EventArgs e)
        {
            txtTotal_SV.Text = "";
            if (salvage_count == 0)
            {
                dgvSalvageValue.Rows.Clear();
                dgvSalvageValue.Columns.Clear();
                //Datagridview for equipment
                string[] Equipmet_CC = { "No.", "Name List of Equipment expenses", "Type of Equipment", "Cost ($)" };
                //Add Column name
                con.HeaderTable2(dgvSalvageValue, Equipmet_CC);
                //Add Row data
                for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                {
                    dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "");
                }
                dgvSalvageValue.AutoResizeColumns();
                dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            if (dgvSalvageValue.Rows.Count != 0)
            {
                for (int i = 0; i < dgvSalvageValue.Rows.Count - 1; i++)
                {
                    dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                }
            }
            salvage_count = 0;           
        }

        private void rdbPercentFirstCost_CheckedChanged(object sender, EventArgs e)
        {
            if (salvage_count == 0)
            {
                dgvSalvageValue.Rows.Clear();
                dgvSalvageValue.Columns.Clear();
                //Datagridview for equipment
                string[] Equipmet_CC = { "No.", "Name List of Equipment expenses", "Type of Equipment", "Percentage of Initial Equipment Cost (%)", "Cost ($)" };
                //Add Column name
                con.HeaderTable2(dgvSalvageValue, Equipmet_CC);
                //Add Row data
                double InitialEquipCost;
                for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
                {
                    InitialEquipCost = Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                    dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "10", (0.1 * InitialEquipCost).ToString("#,##0.##"));
                }
                dgvSalvageValue.AutoResizeColumns();
                dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            if (dgvSalvageValue.Rows.Count != 0)
            {
                for (int i = 0; i < dgvSalvageValue.Rows.Count - 1; i++)
                {
                    dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                }
            }
            salvage_count = 0;
        }

        private void dgvSalvageValue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalculation_BPC_Click(object sender, EventArgs e)
        {
            txtTotal_PC.Text = "";
            //Cost for Main Product Credit
            double InterestRateCal;
            InterestRateCal = con.Cal_AnnualToPresent(txtInterestRate.Text, txtPeriod.Text);
            double Total_EachRowStream, CostComponent;
            int RowCount;
            //For Main Product
            RowCount = dgvMainP.Rows.Count - 1;
            for (int i = 1; i < RowCount; i++)
            {
                Total_EachRowStream = 0;
                for (int j = 0; j < FindOutputStream.Count; j++)
                {
                    Total_EachRowStream += Convert.ToDouble(dgvMainP.Rows[i].Cells[j + 3].Value.ToString());
                }
                if (dgvMainP.Rows[i].Cells[1].Value == null || dgvMainP.Rows[i].Cells[1].Value.ToString() == "")
                {
                    dgvMainP.Rows[i].Cells[1].Value = "-";
                    CostComponent = 0;
                }
                else if (dgvMainP.Rows[i].Cells[1].Value.ToString() == "-")
                {
                    CostComponent = 0;
                }
                else
                {
                    CostComponent = Convert.ToDouble(dgvMainP.Rows[i].Cells[1].Value.ToString());
                }
                dgvMainP.Rows[i].Cells[dgvMainP.Columns.Count - 1].Value = (CostComponent * (Total_EachRowStream * Convert.ToDouble(dgvMainP.Rows[1].Cells[2].Value.ToString()))).ToString("#,##0.##");              
            }

            //For Side Product
            RowCount = dgvSideP.Rows.Count - 1;
            for (int i = 1; i < RowCount; i++)
            {
                Total_EachRowStream = 0;
                for (int j = 0; j < FindOutputStream.Count; j++)
                {
                    Total_EachRowStream += Convert.ToDouble(dgvSideP.Rows[i].Cells[j + 3].Value.ToString());
                }
                if (dgvSideP.Rows[i].Cells[1].Value == null || dgvSideP.Rows[i].Cells[1].Value.ToString() == "")
                {
                    dgvSideP.Rows[i].Cells[1].Value = "-";
                    CostComponent = 0;
                }
                else if (dgvSideP.Rows[i].Cells[1].Value.ToString() == "-")
                {
                    CostComponent = 0;
                }
                else
                {
                    CostComponent = Convert.ToDouble(dgvSideP.Rows[i].Cells[1].Value.ToString());
                }
                dgvSideP.Rows[i].Cells[dgvSideP.Columns.Count - 1].Value = (CostComponent * (Total_EachRowStream * Convert.ToDouble(dgvSideP.Rows[1].Cells[2].Value.ToString()))).ToString("#,##0.##");
            }
            //Calculation for Total Cost of By Product Credit
            double TotalBPCCost;
            TotalBPCCost = 0;
            for (int i = 1; i < dgvMainP.Rows.Count - 1; i++)
            {
                TotalBPCCost += Convert.ToDouble(dgvMainP.Rows[i].Cells[dgvMainP.Columns.Count - 1].Value.ToString());
            }
            for (int i = 1; i < dgvSideP.Rows.Count - 1; i++)
            {
                TotalBPCCost += Convert.ToDouble(dgvSideP.Rows[i].Cells[dgvSideP.Columns.Count - 1].Value.ToString());
            }

            txtTotal_PC.Text = (TotalBPCCost / InterestRateCal).ToString("#,##0.##");
        }

        private void txtOverallFeed_TextChanged(object sender, EventArgs e)
        {
            if (dgvStreamOPC.Rows.Count != 0)
            {
                dgvStreamOPC.Rows[1].Cells[0].Value = txtOverallFeed.Text;
            }            
        }        

        private void btnResetEconVal_Click(object sender, EventArgs e)
        {
            txtCIR.Text = "7";
            txtPPIR.Text = "7";
            txtTIR.Text = "7";
            txtMar.Text = "15";
            txtRma.Text = "0.1397764";
            txtTax.Text = "35";
            cbbDepreciationType.Text = "Straight Line";
            nudYearDepreciation.Text = "10";
            nudProjectLifeTime.Text = "10";
            double LandInvest = 20000000;
            txtLandCostInvestment.Text = LandInvest.ToString("#,##0.##");
        }

        private void btnNextToProCap_Click(object sender, EventArgs e)
        {          
            dgvProductCap.Rows.Clear();
            dgvProductCap.Columns.Clear();
            double YearDepreciation = Convert.ToDouble(nudYearDepreciation.Text);
            double ProjectLifeTime = Convert.ToDouble(nudProjectLifeTime.Text);
            if (YearDepreciation > ProjectLifeTime)
            {
                nudYearDepreciation.Text = nudProjectLifeTime.Text;
            }
            string[] YearHeader = { "Year Name", "Product Capacity (%)" };
            con.HeaderTable(dgvProductCap, YearHeader);

            int NumberOfYear = Convert.ToInt32(nudProjectLifeTime.Text);
            string YearName;
            for (int i = 0; i < NumberOfYear; i++)
            {
                YearName = "Year " + (i + 1).ToString();
                dgvProductCap.Rows.Add(YearName, "100");
            }
            dgvProductCap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Go to Product capacity page
            tabEconEval.SelectedIndex = 1;
        }

        private void btnResetProductCap_Click(object sender, EventArgs e)
        {
            if (dgvProductCap.Rows.Count != 0)
            {
                for (int i = 0; i < dgvProductCap.Rows.Count - 1; i++)
                {
                    dgvProductCap.Rows[i].Cells[1].Value = 100;
                }
            }
            else
            {
                MessageBox.Show("Please ensure to correct all required information in Economic Value, and then click Next button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<string> EconSummary_Header = new List<string>();
        private void btnEconSummary_Click(object sender, EventArgs e)
        {
            btnCCFMonth.Visible = false;
            dgvEconSummary.Rows.Clear();
            dgvEconSummary.Columns.Clear();
            //Add number of year to list
            EconSummary_Header.Clear();
            EconSummary_Header.Add("Year");
            EconSummary_Header.Add("-2");
            EconSummary_Header.Add("-1");
            int NumYear = Convert.ToInt32(nudProjectLifeTime.Text);
            for (int i = 0; i <= NumYear; i++)
            {
                EconSummary_Header.Add(i.ToString());
            }
            EconSummary_Header.Add("Total");
            //Add Header Name
            con.HeaderTableFromList(dgvEconSummary, EconSummary_Header);

            //Add Row in Table
            string[] RowName = { "Production Capacity", "All Money", "Land", "Fixed Capital Investment", "Working Capital Investment", "Total Capital Investment", "Start-up Expense",
            "Annual Sales", "Total Product Cost", "Depreciation Factor", "Depreciation", "Gross Profit", "Net Profit", "Total Annual Cash Flow", "Cumulative Cash Flow", "",
            "Annual End of Year Cash Flows and Discounting", "NPV", "Present Worth Factor", "Present Worth", "DCFR", "Present Worth Factor", "Present Worth", "",
            "Continuous Cash Flows and Discounting", "NPV", "Present Worth Factor", "Present Worth", "DCFR", "Present Worth Factor", "Present Worth", "", "Rate of Investment (ROI)", "Pay Back period (PBP)", "Pay Back period (PBP) (Year and Month)", "Net Return"};
            for (int i = 0; i < RowName.Length; i++)
            {
                dgvEconSummary.Rows.Add(RowName[i]);
            }
            //Product capacity row            
            for (int i = 0; i < dgvProductCap.Rows.Count - 1; i++)
            {
                dgvEconSummary.Rows[0].Cells[i + 4].Value = dgvProductCap.Rows[i].Cells[1].Value.ToString() + "%";               
            }
            //Land
            dgvEconSummary.Rows[2].Cells[1].Value = (Convert.ToDouble(txtLandCostInvestment.Text) * - 1).ToString("#,##0.##");
            //Fixed Capital Investment Calculation
            double CalFixCap = 0;
            if (rdbCustomCapCost.Checked == true)
            {
                for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                {
                    CalFixCap += Convert.ToDouble(dgvOnetime_CC.Rows[i].Cells[2].Value.ToString());
                }
            }
            else if (rdbECONCapCost.Checked == true)
            {
                for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                {
                    CalFixCap += Convert.ToDouble(dgvOnetime_CC.Rows[i].Cells[3].Value.ToString());
                }
            }
            dgvEconSummary.Rows[3].Cells[1].Value = (CalFixCap * 0.35 * Math.Pow((1 + (Convert.ToDouble(txtCIR.Text) / 100)), 0) * -1).ToString("#,##0.##");
            dgvEconSummary.Rows[3].Cells[2].Value = (CalFixCap * 0.5 * Math.Pow((1 + (Convert.ToDouble(txtCIR.Text) / 100)), 1) * -1).ToString("#,##0.##");
            dgvEconSummary.Rows[3].Cells[3].Value = (CalFixCap * 0.15 * Math.Pow((1 + (Convert.ToDouble(txtCIR.Text) / 100)), 2) * -1).ToString("#,##0.##");
            //Working Capital Investment
            double Sum_FCI = 0;
            for (int i = 1; i <= 3; i++)
            {
                Sum_FCI += Convert.ToDouble(dgvEconSummary.Rows[3].Cells[i].Value.ToString());
            }
            if (rdbCustomCapCost.Checked == true)
            {
                dgvEconSummary.Rows[4].Cells[3].Value = ((Convert.ToDouble(dgvWorkingCapital.Rows[0].Cells[2].Value.ToString()) * Sum_FCI) / CalFixCap).ToString("#,##0.##");
            }
            else if (rdbECONCapCost.Checked == true)
            {
                dgvEconSummary.Rows[4].Cells[3].Value = ((Convert.ToDouble(dgvWorkingCapital.Rows[0].Cells[3].Value.ToString()) * Sum_FCI) / CalFixCap).ToString("#,##0.##");
            }
            //Total Capital Investment Calculation
            double SumTCI = 0;
            for (int col = 0; col < 3; col++)
            {
                SumTCI = 0;
                for (int row = 0; row < 3; row++)
                {
                    if (dgvEconSummary.Rows[row + 2].Cells[col + 1].Value == null || dgvEconSummary.Rows[row + 2].Cells[col + 1].Value.ToString() == "")
                    {
                        SumTCI += 0;
                    }
                    else
                    {                       
                        SumTCI += Convert.ToDouble(dgvEconSummary.Rows[row + 2].Cells[col + 1].Value.ToString());
                    }
                    dgvEconSummary.Rows[5].Cells[col + 1].Value = SumTCI.ToString("#,##0.##");
                }
            }
            //Start-up Expense Calculation
            double SumStartup = 0;
            for (int i = 0; i < 3; i++)
            {
                SumStartup += Convert.ToDouble(dgvEconSummary.Rows[3].Cells[i + 1].Value);
                dgvEconSummary.Rows[6].Cells[4].Value = (SumStartup * 0.1).ToString("#,##0.##");
            }
            //Parameter for Annual Sales Calculation
            double ProductTotalCost = Convert.ToDouble(txtTotal_PC.Text);
            double PRIR = Convert.ToDouble(txtPPIR.Text) / 100;
            double ProductCapPercent;
            //Parameter for Total Product Cost Calculation
            double TotalVariableCost = TotalOPforEconEval;                     
            double TotalOP = Convert.ToDouble(txtTotal_OPC.Text);
            double TPCIR = Convert.ToDouble(txtTIR.Text) / 100;
            //Parameter for Depreciation Factor
            double Year_Depreciation = Convert.ToDouble(nudYearDepreciation.Text);
            double DepreciationFactor = Math.Round((100 / Year_Depreciation), 2);
            //Add data to Table
            for (int i = 0; i < NumYear; i++)
            {
                ProductCapPercent = Convert.ToDouble(dgvEconSummary.Rows[0].Cells[i + 4].Value.ToString().TrimEnd('%')) / 100;
                //Annual Sales Calculation
                dgvEconSummary.Rows[7].Cells[i + 4].Value = (ProductTotalCost * ProductCapPercent * Math.Pow((1 + PRIR), (i + 4 - 3 + 2))).ToString("#,##0.##");              
                //Total Product Cost Calculation             
                dgvEconSummary.Rows[8].Cells[i + 4].Value = ((TotalVariableCost * (1 - ProductCapPercent)) - (TotalOP * Math.Pow((1 + TPCIR), (i + 4 - 3 + 2)))).ToString("#,##0.##");
                //Depreciation Factor
                dgvEconSummary.Rows[9].Cells[i + 4].Value = DepreciationFactor.ToString("#,##0.##") + "%";
                //Depreciation 
                dgvEconSummary.Rows[10].Cells[i + 4].Value = ((SumStartup * DepreciationFactor) / 100).ToString("#,##0.##");
            }                     
            double Annual_Sale, StartUpSale, TPC_Cost, Depreciation, GrossProfit;
            StartUpSale = Convert.ToDouble(dgvEconSummary.Rows[6].Cells[4].Value.ToString());
            for (int i = 0; i < NumYear; i++)
            {
                Annual_Sale = Convert.ToDouble(dgvEconSummary.Rows[7].Cells[i + 4].Value.ToString());
                TPC_Cost = Convert.ToDouble(dgvEconSummary.Rows[8].Cells[i + 4].Value.ToString());
                Depreciation = Convert.ToDouble(dgvEconSummary.Rows[10].Cells[i + 4].Value.ToString());
                //Gross Profit
                GrossProfit = Annual_Sale + TPC_Cost + StartUpSale + Depreciation;
                dgvEconSummary.Rows[11].Cells[i + 4].Value = GrossProfit.ToString("#,##0.##");
                //Net Profit
                if (GrossProfit <= 0)
                {
                    dgvEconSummary.Rows[12].Cells[i + 4].Value = "0";
                }
                else
                {
                    dgvEconSummary.Rows[12].Cells[i + 4].Value = (GrossProfit * (1 - (Convert.ToDouble(txtTax.Text) / 100))).ToString("#,##0.##");
                }
                //Total Annual Cash Flow
                dgvEconSummary.Rows[13].Cells[i + 4].Value = dgvEconSummary.Rows[12].Cells[i + 4].Value;
            }
            //Total Annual Cash Flow (Cont.)
            for (int col = 0; col < 3; col++)
            {
                dgvEconSummary.Rows[13].Cells[col + 1].Value = dgvEconSummary.Rows[5].Cells[col + 1].Value;
            }
            
            double SumCashFlow = 0;
            double M_ar = Convert.ToDouble(txtMar.Text) / 100;
            double PWF, TACF;                
            for (int i = 0; i < NumYear + 3; i++)
            {
                //Cumulative Cash Flow
                SumCashFlow += Convert.ToDouble(dgvEconSummary.Rows[13].Cells[i + 1].Value.ToString());
                dgvEconSummary.Rows[14].Cells[i + 1].Value = SumCashFlow.ToString("#,##0.##");
                //Annual End of Year Cash Flows and Discounting
                //Present Worth Factor 
                PWF = Math.Pow((1 + M_ar), (-i + 1 + 3));
                dgvEconSummary.Rows[18].Cells[i + 1].Value = PWF.ToString("#,##0.##");
                //Present Worth
                TACF = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[i + 1].Value.ToString());
                dgvEconSummary.Rows[19].Cells[i + 1].Value = (PWF * TACF).ToString("#,##0.##");
                               
            }
                    
            double DCFR = M_ar;
            double count = 0;
            double SumDCFW_PW = 0;
            while (count < 500)
            {
                for (int i = 0; i < NumYear + 3; i++)
                {
                    //DCFR
                    dgvEconSummary.Rows[20].Cells[1].Value = DCFR.ToString("#,##0.##");
                    //Present Worth Factor 
                    PWF = Math.Pow((1 + DCFR), (-1 * (i + 1 - 3)));
                    dgvEconSummary.Rows[21].Cells[i + 1].Value = PWF.ToString("#,##0.##");
                    //Present Worth
                    TACF = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[i + 1].Value.ToString());
                    dgvEconSummary.Rows[22].Cells[i + 1].Value = (PWF * TACF).ToString("#,##0.##");
                    SumDCFW_PW += Convert.ToDouble(dgvEconSummary.Rows[22].Cells[i + 1].Value);
                }
                if (SumDCFW_PW > 0)
                {
                    DCFR += 0.001;                  
                }
                else if (SumDCFW_PW < 0)
                {
                    break;
                }
                count += 1; 
            }

            //Continuous Cash Flows and Discounting 
            double rma = Convert.ToDouble(txtRma.Text);
            for (int i = 0; i < NumYear + 3; i++)
            {
                //Present Worth Factor
                PWF = ((Math.Exp(rma) - 1) / rma) * Math.Exp(-1 * (i - 3) * rma);
                dgvEconSummary.Rows[26].Cells[i + 1].Value = PWF.ToString("#,##0.##");
                //Present Worth
                TACF = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[i + 1].Value.ToString());
                dgvEconSummary.Rows[27].Cells[i + 1].Value = (PWF * TACF).ToString("#,##0.##");
            }
            count = 0;
            DCFR = rma;
            SumDCFW_PW = 0;
            
            while (count < 500)
            {
                for (int i = 0; i < NumYear + 3; i++)
                {
                    //DCFR
                    dgvEconSummary.Rows[28].Cells[1].Value = DCFR.ToString("#,##0.##");
                    //Present Worth Factor 
                    PWF = ((Math.Pow(2.71828183, DCFR) - 1) / DCFR) * (Math.Pow(2.71828183, (-1 * (i - 3) * DCFR)));
                    dgvEconSummary.Rows[29].Cells[i + 1].Value = PWF.ToString("#,##0.##");
                    //Present Worth
                    TACF = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[i + 1].Value.ToString());
                    dgvEconSummary.Rows[30].Cells[i + 1].Value = (PWF * TACF).ToString("#,##0.##");
                    SumDCFW_PW += Convert.ToDouble(dgvEconSummary.Rows[30].Cells[i + 1].Value);
                }
                if (SumDCFW_PW > 0)
                {
                    DCFR += 0.001;
                }
                else if (SumDCFW_PW < 0)
                {
                    break;
                }
                count += 1;
            }

            //Add Total summation of each row
            double SumTotal;
            double Col_Val;
            //Sumamtion of total for row of Fixed Capital Investment, Working Capital Investment, Total Capital Investment, Start-up Expense, Annual Sales, Total Product Cost
            for (int row = 0; row < 7; row++)
            {
                SumTotal = 0;
                for (int col = 0; col < NumYear + 3; col++)
                {
                    if (dgvEconSummary.Rows[row + 2].Cells[col + 1].Value == null || dgvEconSummary.Rows[row + 2].Cells[col + 1].Value.ToString() == "")
                    {
                        Col_Val = 0;
                    }
                    else
                    {
                        Col_Val = Convert.ToDouble(dgvEconSummary.Rows[row + 2].Cells[col + 1].Value.ToString());
                    }                   
                    SumTotal += Col_Val;
                }
                dgvEconSummary.Rows[row + 2].Cells[dgvEconSummary.Columns.Count - 1].Value = SumTotal.ToString("#,##0.##");
            }
            //Sumamtion of total for row of Depreciation, Gross Profit, Net Profit, Total Annual Cash Flow
            for (int row = 0; row < 4; row++)
            {
                SumTotal = 0;
                for (int col = 0; col < NumYear + 3; col++)
                {
                    if (dgvEconSummary.Rows[row + 10].Cells[col + 1].Value == null || dgvEconSummary.Rows[row + 10].Cells[col + 1].Value.ToString() == "")
                    {
                        Col_Val = 0;
                    }
                    else
                    {
                        Col_Val = Convert.ToDouble(dgvEconSummary.Rows[row + 10].Cells[col + 1].Value.ToString());
                    }
                    SumTotal += Col_Val;
                }
                dgvEconSummary.Rows[row + 10].Cells[dgvEconSummary.Columns.Count - 1].Value = SumTotal.ToString("#,##0.##");
            }

            //Sumamtion of total for row of Present Worth(NPV), Present Worth(DCFR)
            int[] SelectRow_PW = {19, 22, 27, 30};            
            for (int row = 0; row < SelectRow_PW.Length; row++)
            {
                SumTotal = 0;
                for (int col = 0; col < NumYear + 3; col++)
                {
                    if (dgvEconSummary.Rows[SelectRow_PW[row]].Cells[col + 1].Value == null || dgvEconSummary.Rows[SelectRow_PW[row]].Cells[col + 1].Value.ToString() == "")
                    {
                        Col_Val = 0;
                    }
                    else
                    {
                        Col_Val = Convert.ToDouble(dgvEconSummary.Rows[SelectRow_PW[row]].Cells[col + 1].Value.ToString());
                    }
                    SumTotal += Col_Val;
                }
                dgvEconSummary.Rows[SelectRow_PW[row]].Cells[dgvEconSummary.Columns.Count - 1].Value = SumTotal.ToString("#,##0.##");
            }

            //Rate of Return
            double SumNetProfit, SumOfTCI;                    
            SumNetProfit = Convert.ToDouble(dgvEconSummary.Rows[12].Cells[dgvEconSummary.Columns.Count - 1].Value.ToString());
            SumOfTCI = Convert.ToDouble(dgvEconSummary.Rows[5].Cells[dgvEconSummary.Columns.Count - 1].Value.ToString());
            dgvEconSummary.Rows[32].Cells[1].Value = ((SumNetProfit/(SumOfTCI * -1)/ NumYear) * 100).ToString("#,##0.##") + "%";
            //Pay Back Period
            int lastyear_negativeVal = 0;          
            //Check year that is over break even point
            for (int i = 0; i < NumYear + 3; i++)
            {
                double checkEachYear = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[i + 1].Value.ToString());
                if (checkEachYear < 0)
                {
                    lastyear_negativeVal = i - 2;
                }                         
            } 
            double CumSelectVal, SegmentMonth, Segment100, CalMonth, Cal100, Valpositive;
            CumSelectVal = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[lastyear_negativeVal + 3].Value.ToString()) * -1;
            Valpositive = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[lastyear_negativeVal + 4].Value.ToString());
            SegmentMonth = Valpositive / 12;
            Segment100 = Valpositive / 100;
            CalMonth = CumSelectVal / SegmentMonth;
            Cal100 = Math.Round((CumSelectVal / Segment100 / 100), 2);

            dgvEconSummary.Rows[33].Cells[1].Value = (Convert.ToDouble(lastyear_negativeVal.ToString()) + Cal100).ToString("#,##0.##");
            string YearWord; 
            if (lastyear_negativeVal < Convert.ToInt32(nudProjectLifeTime.Text))
            {
                if (lastyear_negativeVal <= 1)
                {
                    YearWord = " year and ";
                }
                else
                {
                    YearWord = " years and ";
                }
                string MonthWord;
                if (Math.Ceiling(CalMonth) <= 1)
                {
                    MonthWord = " month";
                }
                else
                {
                    MonthWord = " months";
                }
                dgvEconSummary.Rows[34].Cells[1].Value = lastyear_negativeVal.ToString() + YearWord + Math.Ceiling(CalMonth).ToString() + MonthWord;
                //Check return in the first year
                if (lastyear_negativeVal == 0 & CalMonth > 0)
                {
                    btnCCFMonth.Visible = true;
                }
            }
            else
            {
                dgvEconSummary.Rows[34].Cells[1].Value = "> " + lastyear_negativeVal.ToString();
                dgvEconSummary.Rows[33].Cells[1].Value = "> " + lastyear_negativeVal.ToString(); 
            }
            
            
            //Net Return
            double MAR_NR = Convert.ToDouble(txtMar.Text) / 100;
            dgvEconSummary.Rows[35].Cells[1].Value = ((SumNetProfit / NumYear) - (MAR_NR * SumOfTCI)).ToString("#,##0.##");

            dgvEconSummary.AutoResizeColumns();
            dgvEconSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEconSummary.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Create Cummulative Cash flow Chart
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisY.Title = "Cumulative Cash Flow ($)";
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisX.Title = "Project Life Time (year)";
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisX.Minimum = -2;
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisX.Maximum = NumYear;
            double YearColumn, CumCashFlow;
            double minY_Axis, maxY_Axis;           
            minY_Axis = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[1].Value.ToString());
            maxY_Axis = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[dgvEconSummary.ColumnCount - 2].Value.ToString());           
            int minYstr = Math.Abs(Math.Round(minY_Axis, 0)).ToString().Length - 1;
            int maxYstr = Math.Abs(Math.Round(maxY_Axis, 0)).ToString().Length - 1;
            string rangeMinY = "1";
            for (int i = 0; i < minYstr; i++)
            {
                rangeMinY += "0";
            }
            string rangeMaxY = "1";
            for (int i = 0; i < maxYstr; i++)
            {
                rangeMaxY += "0";
            }            
            double conMin = Convert.ToDouble(rangeMinY);
            double conMax = Convert.ToDouble(rangeMaxY);         
            double Acc_min, Acc_max;
            Acc_min = Math.Ceiling(minY_Axis / conMin) * conMin;
            Acc_max = Math.Ceiling(maxY_Axis / conMax) * conMax;            
            //Clear Series in Chart
            Cum_CashFlowChart.Series.Clear();
            Series newSeries = Cum_CashFlowChart.Series.Add("Zero baseline");
            newSeries.ChartType = SeriesChartType.Line;
            Series newSeries2 = Cum_CashFlowChart.Series.Add("CumCashFlow");
            newSeries2.ChartType = SeriesChartType.Line;
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisY.Minimum = Acc_min - conMin;
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisY.Maximum = Acc_max;
            Cum_CashFlowChart.ChartAreas["ChartArea1"].AxisY.Interval = conMax;
            for (int i = 0; i < NumYear + 3; i++)
            {
                YearColumn = Convert.ToDouble(dgvEconSummary.Columns[i + 1].HeaderText);
                CumCashFlow = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[i + 1].Value.ToString());               
                Cum_CashFlowChart.Series[0].Points.AddXY(YearColumn, 0);
                Cum_CashFlowChart.Series[1].Points.AddXY(YearColumn, CumCashFlow);              
            }
            
            Cum_CashFlowChart.Series[0].BorderWidth = 2;
            Cum_CashFlowChart.Series[1].BorderWidth = 2;
            Cum_CashFlowChart.Series[1].ToolTip = "#VALX,#VALY";
            Cum_CashFlowChart.Series[1].IsValueShownAsLabel = true;
            Cum_CashFlowChart.Series[1].MarkerStyle = MarkerStyle.Circle;
            
            Axis yAxis = Cum_CashFlowChart.ChartAreas[0].AxisY;
            yAxis.LabelStyle.Format = "#,0";
            //yAxis.Interval = 10000;
            Legend legend = Cum_CashFlowChart.Legends[0]; // Assuming one legend
            legend.Docking = Docking.Bottom; // Adjust docking as needed (Top, Right, Left)


            //Go to Economic Summary page
            tabEconEval.SelectedIndex = 2;
          
        }

        private void txtRma_TextChanged(object sender, EventArgs e)
        {

        }

        private void economicEvaluationFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = strDirectory + "SaveFiles"; 
            string CIR, PPIR, TIR, Mar, Rma, Tax, DepType, YearDep, PLT, LandCost;
            CIR = txtCIR.Text;
            PPIR = txtPPIR.Text;
            TIR = txtTIR.Text;
            Mar = txtMar.Text;
            Rma = txtRma.Text;
            Tax = txtTax.Text;
            DepType = cbbDepreciationType.Text;
            YearDep = nudYearDepreciation.Text;
            PLT = nudProjectLifeTime.Text;           
            LandCost = txtLandCostInvestment.Text;
            string[] EconVal = { CIR, PPIR, TIR, Mar, Rma, Tax, DepType, YearDep, PLT, LandCost };           
            if (dgvProductCap.Rows.Count == 0 || dgvEconSummary.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to save.", "Empty Economic Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {              
                conSP.SaveData2Tables_ArrayVal(dgvProductCap, dgvEconSummary, filePath + "\\EconomicValueAndProductCapacity.txt", filePath + "\\EconomicSummary.txt", filePath, EconVal);
            }
        }
        List<string> ValueParameter = new List<string>();       
        private void lCCFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = strDirectory + "SaveFiles";
            //Stram Table Preview
            conSP.SaveDataTable(dgvStreamTablePreview, filePath + "\\StreamTablePreview.txt");
            //-------------------------------------
            //Eqipment Table Preview
            conSP.SaveDataTable(dgvEquipmentPreview, filePath + "\\EquipmentTablePreview.txt");
            //-------------------------------------
            //Define product
            //Main Product
            conSP.SaveDataTable(dgvMainProduct, filePath + "\\DefineMainProduct.txt");
            //Side Product
            conSP.SaveDataTable(dgvSideProduct, filePath + "\\DefineSideProduct.txt");
            //-------------------------------------
            //Define Stream
            //Input Stream
            conSP.SaveDataTable(dgvStream_OpC, filePath + "\\DefineInputSteam.txt");
            //Output Stream
            conSP.SaveDataTable(dgvStreamOutput_OpC, filePath + "\\DefineOutputSteam.txt");
            //-------------------------------------
            //Define Equipment
            conSP.SaveDataTable(dgvEquipmentSummary, filePath + "\\DefineEquipment.txt");
            //-------------------------------------
            //Capital Cost
            string CCTypeCal = "";
            if (rdbCustomCapCost.Checked == true)
            {
                CCTypeCal = "User_defined";
            }
            else if (rdbECONCapCost.Checked == true)
            {
                CCTypeCal = "LCC_default";
            }
            string TCC = "0";
            if (txtTotal_CC.Text == "")
            {
                TCC = "0";
            }
            else
            {
                TCC = txtTotal_CC.Text;
            }
            string[] CapitalArray = { CCTypeCal, cbbProcessCap.Text, TCC};
            conSP.SaveDataTable_ArrayVal(dgvEquipment_CC, filePath + "\\PurchaseEquipment.txt", CapitalArray);
            conSP.SaveDataTable(dgvOnetime_CC, filePath + "\\FCI.txt");
            conSP.SaveDataTable(dgvWorkingCapital, filePath + "\\WCI.txt");
            //-------------------------------------
            //Operating Cost
            string OPCTypeCal = "";
            if (rdbMixtureFeed.Checked == true)
            {
                OPCTypeCal = "Mixture_Feed";
            }
            else if (rdbOverallFeed.Checked == true)
            {
                OPCTypeCal = "Overall_Feed";
            }
            string TCC_OPC = "0";
            if (txtTotal_OPC.Text == "")
            {
                TCC_OPC = "0";
            }
            else
            {
                TCC_OPC = txtTotal_OPC.Text;
            }
            string[] OperatingArray = { txtInterestRate.Text, txtPeriod.Text, txtNumHour_OpC.Text, OPCTypeCal, txtOverallFeed.Text, TCC_OPC};
            conSP.SaveDataTable_ArrayVal(dgvStreamOPC, filePath + "\\OPCStream.txt", OperatingArray);
            conSP.SaveDataTable(dgvEquipmentOPC, filePath + "\\OPCUtility.txt");
            conSP.SaveDataTable(dgvLaborOPC, filePath + "\\OPCLabor_perHour.txt");
            conSP.SaveDataTable(dgvLaborMonth, filePath + "\\OPCLabor_perMonth.txt");
            //-------------------------------------
            //Feedstock Cost
            string TCC_FS = "0";
            if (txtTotal_FS.Text == "")
            {
                TCC_FS = "0";
            }
            else
            {
                TCC_FS = txtTotal_FS.Text;
            }
            string[] FeedStockArray = { TCC_FS };
            conSP.SaveDataTable_ArrayVal(dgvRawMat_FS, filePath + "\\FeedStockCost.txt", FeedStockArray);
            //-------------------------------------
            //Maintenance Cost
            string MCTypeCal = "";
            if (rdbPercent_MC.Checked == true)
            {
                MCTypeCal = "Percentage";
            }
            else if (rdbSpecific_MC.Checked == true)
            {
                MCTypeCal = "Specific";
            }
            string TCC_MC = "0";
            if (txtTotalMaintenance.Text == "")
            {
                TCC_MC = "0";
            }
            else
            {
                TCC_MC = txtTotalMaintenance.Text;
            }
            string[] MaintenanceArray = { txtPreviewCC_MC.Text, txtPercent_MC.Text, MCTypeCal, TCC_MC};
            conSP.SaveDataTable_ArrayVal(dgvSpecific_MC, filePath + "\\MaintenanceCost.txt", MaintenanceArray);
            //-------------------------------------
            //Salvage Values
            string SVTypeCal = "";
            if (rdbCustomSV.Checked == true)
            {
                SVTypeCal = "User_defined";
            }
            else if (rdbPercentFirstCost.Checked == true)
            {
                SVTypeCal = "Percentage";
            }
            string TCC_SV = "0";
            if (txtTotal_SV.Text == "")
            {
                TCC_SV = "0";
            }
            else
            {
                TCC_SV = txtTotal_SV.Text;
            }
            string[] SalvageArray = { SVTypeCal, TCC_SV };
            conSP.SaveDataTable_ArrayVal(dgvSalvageValue, filePath + "\\SalvageValue.txt", SalvageArray);
            //-------------------------------------
            //Product Credit
            string TCC_PC = "0";
            if (txtTotal_PC.Text == "")
            {
                TCC_PC = "0";
            }
            else
            {
                TCC_PC = txtTotal_PC.Text;
            }
            string[] PCArray = { TCC_PC };
            conSP.SaveDataTable_ArrayVal(dgvMainP, filePath + "\\MainProductCredit.txt", PCArray);
            conSP.SaveDataTable(dgvSideP, filePath + "\\SideProductCredit.txt");
            //-------------------------------------
            //LCC
            //-------------------------------------
            MessageBox.Show("Data saved successfully to " + filePath, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       

        private void lCCFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = strDirectory + "SaveFiles";
            //Import Steam Table
            conSP.ImportData(dgvStreamTablePreview, ValueParameter, 0, 0, 1, filePath + "\\StreamTablePreview.txt");
            StreamName.Clear();
            ComponentName.Clear();
            con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
            //Show file name in Textbox
            txtStreamtable_OpC.Text = filePath + "\\StreamTablePreview.txt";
            txtStreamtable_OpC.ReadOnly = true;
            txtProductFile.Text = filePath + "\\StreamTablePreview.txt";
            txtProductFile.ReadOnly = true;
            //-------------------------------------
            //Import Equiment Table
            conSP.ImportData(dgvEquipmentPreview, ValueParameter, 0, 0, 1, filePath + "\\EquipmentTablePreview.txt");
            //Show file name in Textbox
            txtEquipmentFile.Text = filePath + "\\EquipmentTablePreview.txt";
            txtEquipmentFile.ReadOnly = true;
            //Add column Name
            string[] EquipmentHeader = { "Equipment Name", "Type of Equipment", "Duty/Work", "Unit", "Energy source", "Sizing", "Sizing Unit", "Material", "Purchase Cost ($)" };
            con.HeaderTable(dgvEquipmentSummary, EquipmentHeader);
            //Add Pump to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Pump Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);           
            //Add Conpressor to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Compressor Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);          
            //Add Reactor to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "ConReactor Name", 3, EquipmentName, EquipmentDuty, EquipmentUnit);           
            //Add Flash to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Flash Name", 4, EquipmentName, EquipmentDuty, EquipmentUnit);           
            //Add Heat Exchanger to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Hx Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);           
            //Add Column-Condenser and Column-Reboiler to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 2, ColumnName, ColumnDuty, ColumnUnit);          
            //-------------------------------------
            //Define product 
            //Main Product
            conSP.ImportData(dgvMainProduct, ValueParameter, 0, 0, 1, filePath + "\\DefineMainProduct.txt");
            //Side Product
            conSP.ImportData(dgvSideProduct, ValueParameter, 0, 0, 1, filePath + "\\DefineSideProduct.txt");
            cbbMainProduct.Items.Clear();
            cbbSideProduct.Items.Clear();
            if (ComponentName.Count != 0)
            {
                for (int i = 1; i < ComponentName.Count; i++)
                {
                    cbbMainProduct.Items.Add(ComponentName[i]);
                    cbbSideProduct.Items.Add(ComponentName[i]);
                }
                cbbMainProduct.Text = ComponentName[1];
                cbbSideProduct.Text = ComponentName[2];               
            }           
            //-------------------------------------
            //Define Stream
            //Input Stream
            conSP.ImportData(dgvStream_OpC, ValueParameter, 0, 0, 1, filePath + "\\DefineInputSteam.txt");
            //Output Stream
            conSP.ImportData(dgvStreamOutput_OpC, ValueParameter, 0, 0, 1, filePath + "\\DefineOutputSteam.txt");
            cbbStreamInput.Items.Clear();
            cbbStreamOutput.Items.Clear();
            if (StreamName.Count != 0)
            {
                for (int i = 2; i < StreamName.Count; i++)
                {
                    cbbStreamInput.Items.Add(StreamName[i]);
                    cbbStreamOutput.Items.Add(StreamName[i]);
                }
                cbbStreamInput.Text = StreamName[2];
                cbbStreamOutput.Text = StreamName[StreamName.Count - 1];               
            }
            //-------------------------------------
            //Define Equipment
            conSP.ImportData(dgvEquipmentSummary, ValueParameter, 0, 0, 1, filePath + "\\DefineEquipment.txt");
            cbbEnergySource.Items.Clear();
            string[] EnergySource = { "Electricity", "Natural gas", "Cooling energy", "Coal", "Wind", "Solar energy", "Fuel", "Kerosine", "Other", "-" };
            //Coal, wind, solar energy, fuel, kerosine
            if (dgvEquipmentPreview.Columns.Count != 0)
            {
                for (int i = 0; i < EnergySource.Length; i++)
                {
                    cbbEnergySource.Items.Add(EnergySource[i]);
                }
                cbbEnergySource.Text = EnergySource[0];               
            }
            //-------------------------------------
            //Capital Cost
            conSP.ImportData(dgvEquipment_CC, ValueParameter, 3, 3, 4, filePath + "\\PurchaseEquipment.txt");
            if (ValueParameter[0] == "User_defined")
            {
                rdbCustomCapCost.Checked = true;
            }
            else if (ValueParameter[0] == "LCC_default")
            {
                rdbECONCapCost.Checked = true;
            }
            cbbProcessCap.Text = ValueParameter[1];
            txtTotal_CC.Text = ValueParameter[2];
            conSP.ImportData(dgvOnetime_CC, ValueParameter, 0, 0, 1, filePath + "\\FCI.txt");
            conSP.ImportData(dgvWorkingCapital, ValueParameter, 0, 0, 1, filePath + "\\WCI.txt");
            //-------------------------------------
            //Operating Cost
            //Align to center
            conSP.ImportData(dgvStreamOPC, ValueParameter, 6, 6, 7, filePath + "\\OPCStream.txt");
            txtInterestRate.Text = ValueParameter[0];
            txtPeriod.Text = ValueParameter[1];
            txtNumHour_OpC.Text = ValueParameter[2];
            if(ValueParameter[3] == "Mixture_Feed")
            {
                rdbMixtureFeed.Checked = true;
            }
            else if (ValueParameter[3] == "Overall_Feed")
            {
                rdbOverallFeed.Checked = true;
            }
            txtOverallFeed.Text = ValueParameter[4];
            txtTotal_OPC.Text = ValueParameter[5];
            conSP.ImportData(dgvStreamOPC, ValueParameter, 6, 6, 7, filePath + "\\OPCStream.txt");
            conSP.ImportData(dgvEquipmentOPC, ValueParameter, 0, 0, 1, filePath + "\\OPCUtility.txt");          
            conSP.ImportData(dgvLaborOPC, ValueParameter, 0, 0, 1, filePath + "\\OPCLabor_perHour.txt");
            conSP.ImportData(dgvLaborMonth, ValueParameter, 0, 0, 1, filePath + "\\OPCLabor_perMonth.txt");          
            dgvEquipmentOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaborOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaborMonth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStreamOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //-------------------------------------
            //Feedstock Cost
            conSP.ImportData(dgvRawMat_FS, ValueParameter, 1, 1, 2, filePath + "\\FeedStockCost.txt");
            txtTotal_FS.Text = ValueParameter[0];
            //-------------------------------------
            //Maintenance Cost
            conSP.ImportData(dgvSpecific_MC, ValueParameter, 4, 4, 5, filePath + "\\MaintenanceCost.txt");
            txtPreviewCC_MC.Text = ValueParameter[0];
            txtPercent_MC.Text = ValueParameter[1];
            if (ValueParameter[2] == "Percentage")
            {
                rdbPercent_MC.Checked = true;
            }
            else if (ValueParameter[2] == "Specific")
            {
                rdbSpecific_MC.Checked = true;
            }
            txtTotalMaintenance.Text = ValueParameter[3];
            //-------------------------------------
            //Salvage Values
            conSP.ImportData(dgvSalvageValue, ValueParameter, 2, 2, 3, filePath + "\\SalvageValue.txt");
            if (ValueParameter[0] == "User_defined")
            {
                rdbCustomSV.Checked = true;
            }
            else if (ValueParameter[0] == "Percentage")
            {
                rdbPercentFirstCost.Checked = true;
            }
            txtTotal_SV.Text = ValueParameter[1];
            conSP.ImportData(dgvSalvageValue, ValueParameter, 2, 2, 3, filePath + "\\SalvageValue.txt");
            //-------------------------------------
            //Product Credit

            //Align to center
            conSP.ImportData(dgvMainP, ValueParameter, 1, 1, 2, filePath + "\\MainProductCredit.txt");
            txtTotal_PC.Text = ValueParameter[0];
            conSP.ImportData(dgvSideP, ValueParameter, 0, 0, 1, filePath + "\\SideProductCredit.txt");
            dgvMainP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSideP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //-------------------------------------
            //LCC
            //-------------------------------------
            //Change button color
            btnImport_Stream.BackColor = Color.LightGreen;
            btnImport_Equipment.BackColor = Color.LightGreen;
            btnDefineProduct.BackColor = Color.LightGreen;
            btnDefineStream.BackColor = Color.LightGreen;
            btnDefineEqipment.BackColor = Color.LightGreen;
            btnCapitalCost.BackColor = Color.LightGreen;
            btnOperatingCost.BackColor = Color.LightGreen;
            btnFeedstockCost.BackColor = Color.LightGreen;
            btnMaintenanceCost.BackColor = Color.LightGreen;
            btnSalvageValue.BackColor = Color.LightGreen;
            btnProductCredit.BackColor = Color.LightGreen;
            //-------------------------------------
            //Not show picture
            pbOne.Visible = false;
            pbTwo.Visible = false;
            pbThree.Visible = false;
            //Go to Main Page
            tabpage.SelectedIndex = 0;
        }

        private void cbbProcessCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvWorkingCapital.Columns.Clear();
            dgvWorkingCapital.Rows.Clear();           
            double TotalEquipCost = 0;
            for (int i = 0; i < dgvEquipment_CC.Rows.Count - 1; i++)
            {
                if (dgvEquipment_CC.Rows[i].Cells[3].Value == null || dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "")
                {
                    TotalEquipCost += 0;
                    dgvEquipment_CC.Rows[i].Cells[3].Value = "-";
                }
                else if (dgvEquipment_CC.Rows[i].Cells[3].Value.ToString() == "-")
                {
                    TotalEquipCost += 0;
                }
                else
                {
                    TotalEquipCost += Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                }
            }
            //Datagridview from ECON software logic
            string[] ECONExpense = { "No", "Name List of ECON expenses", "Percentage", "Cost ($)" };
            //Add Column name            
            con.HeaderTable(dgvWorkingCapital, ECONExpense);
            double Impact_Process = 1.1;
            double Process_Factor = 0.89;
            if (cbbProcessCap.Text == "Fluid processing")
            {
                Process_Factor = 0.89;
            }
            else if (cbbProcessCap.Text == "Solid-fluid processing")
            {
                Process_Factor = 0.75;
            }
            else if (cbbProcessCap.Text == "Solid processing")
            {
                Process_Factor = 0.7;
            }
            double Purchase_EquipDeli = TotalEquipCost * Impact_Process;
            double TotalCapCost = Purchase_EquipDeli;           
            string[] List_ECON = { "Purchased Equipment Installation", "Instrumentation and Controls (installed)", "Piping (Installed)", "Electrical Systems (Installed)",
                "Buildings (Including Services)", "Yard Improvement", "Service Facilities (Installed)", "Engineering and Supervision", "Construction Expenses", "Legal Expenses", "Contractor's Fees", "Contingency"};
            double[] Percent_ECON = { 0.47, 0.36, 0.68, 0.11, 0.18, 0.1, 0.7, 0.33, 0.41, 0.04, 0.22, 0.44 };
            for (int i = 0; i < List_ECON.Length; i++)
            {               
                TotalCapCost += (Purchase_EquipDeli * Percent_ECON[i]);
            }

            //Working Capital Investmenst (WC) Cost
            dgvWorkingCapital.Rows.Add("1", "Working Capital Investmenst (WC)", Process_Factor.ToString(), (Purchase_EquipDeli * Process_Factor).ToString("#,##0.##"));
            TotalCapCost += (Purchase_EquipDeli * Process_Factor);

            if (dgvOnetime_CC.Rows.Count != 0)
            {
                for (int i = 0; i < dgvOnetime_CC.Rows.Count - 1; i++)
                {
                    dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                }
            }
            if (dgvWorkingCapital.Rows.Count != 0)
            {
                for (int i = 0; i < dgvWorkingCapital.Rows.Count - 1; i++)
                {
                    dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                }
            }
            txtTotal_CC.Text = TotalCapCost.ToString("#,##0.##");
        }

        private void economicEvaluationFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = strDirectory + "SaveFiles";
            conSP.ImportData(dgvProductCap, ValueParameter, 10, 10, 11, filePath + "\\EconomicValueAndProductCapacity.txt");
            txtCIR.Text = ValueParameter[0];
            txtPPIR.Text = ValueParameter[1];
            txtTIR.Text = ValueParameter[2];
            txtMar.Text = ValueParameter[3];
            txtRma.Text = ValueParameter[4];
            txtTax.Text = ValueParameter[5];
            cbbDepreciationType.Text = ValueParameter[6];
            nudYearDepreciation.Text = ValueParameter[7];
            nudProjectLifeTime.Text = ValueParameter[8];
            txtLandCostInvestment.Text = ValueParameter[9];
            conSP.ImportData(dgvEconSummary, ValueParameter, 0, 0, 1, filePath + "\\EconomicSummary.txt");
            dgvEconSummary.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEconSummary.ColumnHeadersDefaultCellStyle = style;
            //Go to Econ Evaluate
            tabpage.SelectedIndex = 11;
            tabEconEval.SelectedIndex = 2;
        }

        private void btnExcelLCC_Click(object sender, EventArgs e)
        {
            string PJName = txtProjectName.Text;
            string str1 = txtTotalMaintenance.Text;           
            conEx.CreateExcel(PJName, dgvMainP, dgvSideP, dgvSalvageValue, dgvSpecific_MC, str1, dgvRawMat_FS, dgvStreamOPC, dgvEquipmentOPC, dgvLaborOPC, dgvLaborMonth, dgvEquipment_CC, dgvOnetime_CC, dgvWorkingCapital, dgvSummaryCost);
        }

        private void importTablesAndDefineValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = strDirectory + "SaveFiles";
            //Import Steam Table
            conSP.ImportData(dgvStreamTablePreview, ValueParameter, 0, 0, 1, filePath + "\\StreamTablePreview.txt");
            StreamName.Clear();
            ComponentName.Clear();
            con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
            //Show file name in Textbox
            txtStreamtable_OpC.Text = filePath + "\\StreamTablePreview.txt";
            txtStreamtable_OpC.ReadOnly = true;
            txtProductFile.Text = filePath + "\\StreamTablePreview.txt";
            txtProductFile.ReadOnly = true;
            //-------------------------------------
            //Import Equiment Table
            conSP.ImportData(dgvEquipmentPreview, ValueParameter, 0, 0, 1, filePath + "\\EquipmentTablePreview.txt");
            //Show file name in Textbox
            txtEquipmentFile.Text = filePath + "\\EquipmentTablePreview.txt";
            txtEquipmentFile.ReadOnly = true;
            //Add column Name
            string[] EquipmentHeader = { "Equipment Name", "Type of Equipment", "Duty/Work", "Unit", "Energy source", "Sizing", "Sizing Unit", "Material", "Purchase Cost ($)" };
            con.HeaderTable(dgvEquipmentSummary, EquipmentHeader);           
            //Add Pump to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Pump Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.AddDataToTable(dgvEquipmentSummary, "Pump", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Conpressor to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Compressor Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.AddDataToTable(dgvEquipmentSummary, "Compressor", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Reactor to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "ConReactor Name", 3, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.AddDataToTable(dgvEquipmentSummary, "Reactor", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Flash to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Flash Name", 4, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.AddDataToTable(dgvEquipmentSummary, "Flash", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Heat Exchanger to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Hx Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.AddDataToTable(dgvEquipmentSummary, "Heat Exchanger", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Column-Condenser and Column-Reboiler to Table
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 1, EquipmentName, EquipmentDuty, EquipmentUnit);
            con.SelectFromEqipmentTable(dgvEquipmentPreview, "Column Name", 2, ColumnName, ColumnDuty, ColumnUnit);
            con.AddColumnToTable(dgvEquipmentSummary, "Column-Condenser", "Column-Reboiler", EquipmentName, EquipmentDuty, EquipmentUnit, ColumnName, ColumnDuty, ColumnUnit);
            //-------------------------------------
            //-------------------------------------
            //Define product 
            //Main Product
            conSP.ImportData(dgvMainProduct, ValueParameter, 0, 0, 1, filePath + "\\DefineMainProduct.txt");
            //Side Product
            conSP.ImportData(dgvSideProduct, ValueParameter, 0, 0, 1, filePath + "\\DefineSideProduct.txt");
            cbbMainProduct.Items.Clear();
            cbbSideProduct.Items.Clear();
            if (ComponentName.Count != 0)
            {
                for (int i = 1; i < ComponentName.Count; i++)
                {
                    cbbMainProduct.Items.Add(ComponentName[i]);
                    cbbSideProduct.Items.Add(ComponentName[i]);
                }
                cbbMainProduct.Text = ComponentName[1];
                cbbSideProduct.Text = ComponentName[2];
            }
            //-------------------------------------
            //Define Stream
            //Input Stream
            conSP.ImportData(dgvStream_OpC, ValueParameter, 0, 0, 1, filePath + "\\DefineInputSteam.txt");
            //Output Stream
            conSP.ImportData(dgvStreamOutput_OpC, ValueParameter, 0, 0, 1, filePath + "\\DefineOutputSteam.txt");
            cbbStreamInput.Items.Clear();
            cbbStreamOutput.Items.Clear();
            if (StreamName.Count != 0)
            {
                for (int i = 2; i < StreamName.Count; i++)
                {
                    cbbStreamInput.Items.Add(StreamName[i]);
                    cbbStreamOutput.Items.Add(StreamName[i]);
                }
                cbbStreamInput.Text = StreamName[2];
                cbbStreamOutput.Text = StreamName[StreamName.Count - 1];
            }
            //-------------------------------------
            //Define Equipment
            conSP.ImportData(dgvEquipmentSummary, ValueParameter, 0, 0, 1, filePath + "\\DefineEquipment.txt");
            cbbEnergySource.Items.Clear();
            string[] EnergySource = { "Electricity", "Natural gas", "Cooling energy", "Coal", "Wind", "Solar energy", "Fuel", "Kerosine", "Other", "-" };
            //Coal, wind, solar energy, fuel, kerosine
            if (dgvEquipmentPreview.Columns.Count != 0)
            {
                for (int i = 0; i < EnergySource.Length; i++)
                {
                    cbbEnergySource.Items.Add(EnergySource[i]);
                }
                cbbEnergySource.Text = EnergySource[0];
            }
            btnImport_Stream.BackColor = Color.LightGreen;
            btnImport_Equipment.BackColor = Color.LightGreen;
            btnDefineProduct.BackColor = Color.LightGreen;
            btnDefineStream.BackColor = Color.LightGreen;
            btnDefineEqipment.BackColor = Color.LightGreen;
            pbOne.Visible = false;
            pbTwo.Visible = false;
            pbThree.Visible = false;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.png)|*.png";
            saveFileDialog.FileName = "Cumulative Cash Flow Plot";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cum_CashFlowChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
            }
            MessageBox.Show("The Cumulative Cash Flow has been successfully exported to a PNG image.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCCFMonth_Click(object sender, EventArgs e)
        {
            List<double> xPoint = new List<double>();
            List<double> yPoint = new List<double>();
            xPoint.Clear();
            yPoint.Clear();
            for (int i = 0; i < 13; i++)
            {
                xPoint.Add(i);
            }
            double MinMonth = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[3].Value.ToString());
            double MaxMonth = Convert.ToDouble(dgvEconSummary.Rows[14].Cells[4].Value.ToString());
            double FirstYearCost = Convert.ToDouble(dgvEconSummary.Rows[13].Cells[4].Value.ToString());
            double segmentMonth = FirstYearCost / 12;
            double yValue = MinMonth;
            yPoint.Add(MinMonth);
            for (int i = 0; i < 11; i++)
            {
                yValue += segmentMonth;
                yPoint.Add(yValue);
            }
            yPoint.Add(MaxMonth);
            ChartMonth FirstYearPlot = new ChartMonth(MinMonth, MaxMonth, xPoint, yPoint);
            FirstYearPlot.Show();
        }

        private void btnEconExport_Click(object sender, EventArgs e)
        {
            if (dgvEconSummary.RowCount == 0)
            {
                MessageBox.Show("There is no data to save.", "Empty Economic Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conEx.CreateEconExcel(dgvEconSummary);
            }            
        }

        private void dgvProductCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

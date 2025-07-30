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
using Microsoft.Office.Interop.Excel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Collections;

namespace LCC
{
    public partial class Form1 : Form
    {
        Function con;        
        Function_SaveOpen conSP;
        Function_Excel conEx;
        Function_CollectData conCD;
        string strDirectory = System.Windows.Forms.Application.StartupPath + "\\";
        string DBPath = System.Windows.Forms.Application.StartupPath + "\\Database\\LCC_Price\\LCC_Database.db";
        //Directory of save files
        string filePathSave = System.Windows.Forms.Application.StartupPath + "\\SaveFiles";
        public Form1()
        {
            InitializeComponent();
            con = new Function();
            conCD = new Function_CollectData();
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
        List<string> DutyCatergory = new List<string>();

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

        List<string> ValueParameter = new List<string>();
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {           
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
            this.MaximizeBox = false;

            
            string projectNamePath = filePathSave + "\\Project_Name.txt";
            string streamTablePath = filePathSave + "\\StreamTablePreview.txt";
            //Capital Cost
            string PurchaseEquip = filePathSave + "\\PurchaseEquipment.txt";
            string FCI = filePathSave + "\\FCI.txt";
            string WCI = filePathSave + "\\WCI.txt";

            //Operating Cost
            string OPCStream = filePathSave + "\\OPCStream.txt";
            string OPCUtility = filePathSave + "\\OPCUtility.txt";
            string OPCLaborHour = filePathSave + "\\OPCLabor_perHour.txt";
            string OPCLaborMonth = filePathSave + "\\OPCLabor_perMonth.txt";
            //string DutyCategory = filePathSave + "\\DefineDutyCategory.txt";

            //FeedStock Cost
            string FeedStock = filePathSave + "\\FeedStockCost.txt";

            //Maintenance Cost
            string Maintenance = filePathSave + "\\MaintenanceCost.txt";

            //Salvage Cost
            string Salvage = filePathSave + "\\SalvageValue.txt";

            //Product Credits
            string MainProductCredit = filePathSave + "\\MainProductCredit.txt";
            string SideProductCredit = filePathSave + "\\SideProductCredit.txt";

            //Economic Evaluation
            string EconValue = filePathSave + "\\EconomicValueAndProductCapacity.txt";
            string EconSummary = filePathSave + "\\EconomicSummary.txt";
            //-------------------------------------
            //Import Project Name
            if (File.Exists(projectNamePath))
            {
                txtProjectName.Text = conSP.ReadFirstLine(projectNamePath);
                txtProjectName.ReadOnly = true;
                btnDefinePJName.BackColor = Color.LightGreen;
                btnEditPJName.BackColor = Color.LightBlue;
            }
            //-------------------------------------
            //Import Stream Table
            if (File.Exists(streamTablePath))
            {
                conSP.ImportData(dgvStreamTablePreview, ValueParameter, 0, 0, 1, streamTablePath);
                StreamName.Clear();
                ComponentName.Clear();
                con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
                //Show file name in Textbox
                txtStreamtable_OpC.Text = streamTablePath;
                txtStreamtable_OpC.ReadOnly = true;
                txtProductFile.Text = streamTablePath;
                txtProductFile.ReadOnly = true;
            }            
            //-------------------------------------
            //Import Equiment Table
            conSP.ImportData(dgvEquipmentPreview, ValueParameter, 0, 0, 1, filePathSave + "\\EquipmentTablePreview.txt");
            //Show file name in Textbox
            txtEquipmentFile.Text = filePathSave + "\\EquipmentTablePreview.txt";
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
            conSP.ImportData(dgvMainProduct, ValueParameter, 0, 0, 1, filePathSave + "\\DefineMainProduct.txt");
            //Side Product
            conSP.ImportData(dgvSideProduct, ValueParameter, 0, 0, 1, filePathSave + "\\DefineSideProduct.txt");
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
            conSP.ImportData(dgvStream_OpC, ValueParameter, 0, 0, 1, filePathSave + "\\DefineInputStream.txt");
            //Output Stream
            conSP.ImportData(dgvStreamOutput_OpC, ValueParameter, 0, 0, 1, filePathSave + "\\DefineOutputStream.txt");
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
            conSP.ImportData(dgvEquipmentSummary, ValueParameter, 0, 0, 1, filePathSave + "\\DefineEquipment.txt");
            
            btnImport_Stream.BackColor = Color.LightGreen;
            btnImport_Equipment.BackColor = Color.LightGreen;
            btnDefineProduct.BackColor = Color.LightGreen;
            btnDefineStream.BackColor = Color.LightGreen;
            btnDefineEqipment.BackColor = Color.LightGreen;
            pbOne.Visible = false;
            pbTwo.Visible = false;
            pbThree.Visible = false;
            //---------------------------------------
            string firstLine;

            //Capital Cost          
            firstLine = conSP.ImporttxtToDGV_cond(PurchaseEquip, dgvEquipment_CC);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 4)
            {
                if (ValueParameter[0] == "LCC_default")
                {
                    rdbECONCapCost.Checked = true;
                    cbbProcessCap.Enabled = true;
                }
                else if (ValueParameter[0] == "User_defined")
                {
                    rdbCustomCapCost.Checked = true;
                    cbbProcessCap.Enabled = false;
                }
                cbbProcessCap.Text = ValueParameter[1];                
                con.checkAndaddDataToText(ValueParameter[2], txtTotal_CC);
                con.checkAndaddDataToText(ValueParameter[3], txtCPI_Index);                
            }
            conSP.ImporttxtToDGV(FCI, dgvOnetime_CC);
            conSP.ImporttxtToDGV(WCI, dgvWorkingCapital);
            if (dgvEquipment_CC.ColumnCount != 0 && dgvOnetime_CC.ColumnCount != 0 && dgvWorkingCapital.ColumnCount != 0)
            {
                btnCapitalCost.BackColor = Color.LightGreen;
            }
            else
            {
                btnCapitalCost.BackColor = Color.Transparent;
            }

            //---------------------------------------
            //Operating Cost
            firstLine = conSP.ImporttxtToDGV_cond(OPCStream, dgvStreamOPC);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 6)
            {
                con.checkAndaddDataToText(ValueParameter[0], txtInterestRate);
                con.checkAndaddDataToText(ValueParameter[1], txtPeriod);
                con.checkAndaddDataToText(ValueParameter[2], txtNumHour_OpC);
                if (ValueParameter[3] == "Mixture_Feed")
                {
                    rdbMixtureFeed.Checked = true;
                }
                else
                {
                    rdbOverallFeed.Checked = true;
                }
                con.checkAndaddDataToText(ValueParameter[4], txtOverallFeed);
                con.checkAndaddDataToText(ValueParameter[5], txtTotal_OPC);
            }
            conSP.ImporttxtToDGV(OPCUtility, dgvEquipmentOPC);
            conSP.ImporttxtToDGV(OPCLaborHour, dgvLaborOPC);
            conSP.ImporttxtToDGV(OPCLaborMonth, dgvLaborMonth);

            con.DataToCenterStyle(dgvStreamOPC);            
            con.DataToCenterStyle(dgvEquipmentOPC);
            con.CellColorWithCond(dgvEquipmentOPC, 3, "Double click to select type");
            con.CellColorWithCond(dgvEquipmentOPC, 6, "");
            con.CellColorWithCond(dgvEquipmentOPC, 6, "-");
            con.DataToCenterStyle(dgvLaborOPC);
            con.CellColorWithCond(dgvLaborOPC, 0, "Double click to select type ");
            con.CellColorWithCond(dgvLaborOPC, 1, "");
            con.CellColorWithCond(dgvLaborOPC, 1, "-");
            con.CellColorWithCond(dgvLaborOPC, 3, "");
            con.CellColorWithCond(dgvLaborOPC, 3, "-");
            con.DataToCenterStyle(dgvLaborMonth);
            con.CellColorWithCond(dgvLaborMonth, 0, "Double click to select type ");
            con.CellColorWithCond(dgvLaborMonth, 1, "");
            con.CellColorWithCond(dgvLaborMonth, 1, "-");
            con.CellColorWithCond(dgvLaborMonth, 3, "");
            con.CellColorWithCond(dgvLaborMonth, 3, "-");

            if (dgvStreamOPC.ColumnCount != 0 && dgvEquipmentOPC.ColumnCount != 0 && dgvLaborOPC.ColumnCount != 0 && dgvLaborMonth.ColumnCount != 0)
            {
                btnOperatingCost.BackColor = Color.LightGreen;
            }
            else
            {
                btnOperatingCost.BackColor = Color.Transparent;
            }
            btnDone_OPC.Text = "Next";
            //---------------------------------------
            //FeedStock Cost
            firstLine = conSP.ImporttxtToDGV_cond(FeedStock, dgvRawMat_FS);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 1)
            {                
                con.checkAndaddDataToText(ValueParameter[0], txtTotal_FS);
            }
            if (dgvRawMat_FS.ColumnCount != 0)
            {
                btnFeedstockCost.BackColor = Color.LightGreen;
            }
            else
            {
                btnFeedstockCost.BackColor = Color.Transparent;
            }
            //Maybe need to revise in the future update
            txtAmount_FS.Text = "1";
            rdbWithTransport.Checked = true;
            //---------------------------------------
            //Maintenance Cost
            firstLine = conSP.ImporttxtToDGV_cond(Maintenance, dgvSpecific_MC);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 4)
            {
                con.checkAndaddDataToText(ValueParameter[0], txtPreviewCC_MC);
                con.checkAndaddDataToText(ValueParameter[1], txtPercent_MC);
                if (ValueParameter[2] == "Percentage") 
                {
                    rdbPercent_MC.Checked = true;
                    gbPercent_MC.Enabled = true;
                    gbSpecific_MC.Enabled = false;
                }
                else
                {
                    rdbSpecific_MC.Checked = true;
                    gbSpecific_MC.Enabled = true;
                    gbPercent_MC.Enabled = false;
                }
                con.checkAndaddDataToText(ValueParameter[3], txtTotalMaintenance);
            }
            if (txtTotalMaintenance.BackColor == Color.LightGreen)
            {
                btnMaintenanceCost.BackColor = Color.LightGreen;
            }
            //---------------------------------------
            //Salvage Cost
            firstLine = conSP.ImporttxtToDGV_cond(Salvage, dgvSalvageValue);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 2)
            {
                if (ValueParameter[0] == "Percentage")
                {
                    rdbPercentFirstCost.Checked = true;
                }
                else
                {
                    rdbCustomSV.Checked = true;
                }
                con.checkAndaddDataToText(ValueParameter[1], txtTotal_SV);
            }
            
            if (dgvSalvageValue.ColumnCount > 1)
            {
                dgvSalvageValue.AutoResizeColumns();
                dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvSalvageValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (txtTotal_SV.BackColor == Color.LightGreen)
            {
                btnSalvageValue.BackColor = Color.LightGreen;
            }

            //---------------------------------------
            //Product credit
            ////Main product Credit
            firstLine = conSP.ImporttxtToDGV_cond(MainProductCredit, dgvMainP);
            conSP.SplitWordToList(ValueParameter, firstLine);
            if (ValueParameter.Count == 1)
            {
                con.checkAndaddDataToText(ValueParameter[0], txtTotal_PC);
            }

            ////Side product Credit
            conSP.ImporttxtToDGV(SideProductCredit, dgvSideP);

            con.DataToCenterStyle(dgvMainP);
            con.DataToCenterStyle(dgvSideP);

            if (txtTotal_PC.BackColor == Color.LightGreen)
            {
                btnProductCredit.BackColor = Color.LightGreen;
            }
            //---------------------------------------        


            //txtNumHour_OpC.Text = "2088";
            //DataGridViewCellStyle style = new DataGridViewCellStyle();
            //style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvRawMat_FS.ColumnHeadersDefaultCellStyle = style;
            //Capital Cost            
            //cbbProcessCap.Text = "Fluid processing";
            //Salvage Cost
            //rdbCustomSV.Checked = true;
            //Operating Cost
            //rdbMixtureFeed.Checked = true;
            //txtOverallFeed.Text = "Product1";
            //txtOverallFeed.Enabled = false;
            //btnOPCBack.Visible = false;

            //Maintenanace Cost


            //txtInterestRate.Text = "5";
            //txtPeriod.Text = "10";            
            //Feedstock Cost

            //Define CPI
            //txtCPI_Index.Text = "521";
                        
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
            txtTotal_FS.BackColor = Color.LightGreen;
            btnFeedstockCost.BackColor = Color.LightGreen;
            tabpage.SelectedIndex = 0;

            //-----------------------------------------
            //SaveFile
            //FeedStock Cost
            string FeedStock = filePathSave + "\\FeedStockCost.txt";
            //Feedstock Cost  
            string[] FeedStockArray = { txtTotal_FS.Text };
            conSP.SaveDataTable_ArrayVal(dgvRawMat_FS, FeedStock, FeedStockArray);
        }

        private void btnDone_CC_Click(object sender, EventArgs e)
        {
            if (con.StausTotalCost(txtTotal_CC))
            {
                btnCapitalCost.BackColor = Color.LightGreen;
                tabpage.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please click the calculate button before proceeding this step.", "Warning total cost calculation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //-----------------------------------------
            //SaveFile
            //Capital Cost
            string PurchaseEquip = filePathSave + "\\PurchaseEquipment.txt";
            string FCI = filePathSave + "\\FCI.txt";
            string WCI = filePathSave + "\\WCI.txt";
            //Capital Cost
            string CCTypeCal = "No";
            if (rdbCustomCapCost.Checked == true)
            {
                CCTypeCal = "User_defined";
            }
            else if (rdbECONCapCost.Checked == true)
            {
                CCTypeCal = "LCC_default";
            }

            string[] CapitalArray = { CCTypeCal, cbbProcessCap.Text, txtTotal_CC.Text, txtCPI_Index.Text };
            conSP.SaveDataTable_ArrayVal(dgvEquipment_CC, PurchaseEquip, CapitalArray);
            conSP.SaveDataTable(dgvOnetime_CC, FCI);
            conSP.SaveDataTable(dgvWorkingCapital, WCI);
        }

        private void btnImport_Stream_Click(object sender, EventArgs e)
        {
            /*dgvStreamTablePreview.Columns.Clear();
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
            }*/
            
        }

        private void btnDone_MC_Click(object sender, EventArgs e)
        {          
            if (con.StausTotalCost(txtTotalMaintenance))
            {
                btnMaintenanceCost.BackColor = Color.LightGreen;
                tabpage.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please click the calculate button before proceeding this step.", "Warning total cost calculation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //-----------------------------------------
            //SaveFile
            //Maintenance Cost
            string Maintenance = filePathSave + "\\MaintenanceCost.txt";
            //Maintenance Cost
            string MCTypeCal = "No";
            if (rdbPercent_MC.Checked == true)
            {
                MCTypeCal = "Percentage";
            }
            else if (rdbSpecific_MC.Checked == true)
            {
                MCTypeCal = "Specific";
            }

            string[] MaintenanceArray = { txtPreviewCC_MC.Text, txtPercent_MC.Text, MCTypeCal, txtTotalMaintenance.Text };
            conSP.SaveDataTable_ArrayVal(dgvSpecific_MC, Maintenance, MaintenanceArray);
        }

        private void btnDone_SV_Click(object sender, EventArgs e)
        {           
            if (con.StausTotalCost(txtTotal_SV))
            {
                btnSalvageValue.BackColor = Color.LightGreen;
                tabpage.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please click the calculate button before proceeding this step.", "Warning total cost calculation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //-----------------------------------------
            //SaveFile
            //Salvage Cost
            string Salvage = filePathSave + "\\SalvageValue.txt";
            //Salvage Values
            string SVTypeCal = "No";
            if (rdbCustomSV.Checked == true)
            {
                SVTypeCal = "User_defined";
            }
            else if (rdbPercentFirstCost.Checked == true)
            {
                SVTypeCal = "Percentage";
            }
            string[] SalvageArray = { SVTypeCal, txtTotal_SV.Text };
            conSP.SaveDataTable_ArrayVal(dgvSalvageValue, Salvage, SalvageArray);
        }

        private void btnDone_BPC_Click(object sender, EventArgs e)
        {            
            if (con.StausTotalCost(txtTotal_PC))
            {
                btnProductCredit.BackColor = Color.LightGreen;
                tabpage.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please click the calculate button before proceeding this step.", "Warning total cost calculation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //-----------------------------------------
            //SaveFile
            //Product Credits
            string MainProductCredit = filePathSave + "\\MainProductCredit.txt";
            string SideProductCredit = filePathSave + "\\SideProductCredit.txt";
            //Product Credit
            string[] PCArray = { txtTotal_PC.Text };
            conSP.SaveDataTable_ArrayVal(dgvMainP, MainProductCredit, PCArray);
            conSP.SaveDataTable(dgvSideP, SideProductCredit);
        }
        string ProjectName = "";
        private void btnDefinePJName_Click(object sender, EventArgs e)
        {
            bool CheckWord = true;
            string[] symbol = { @"\<", @"\>", @"\?", @"\[", @"\]", @"\:", @"\|", @"\*", @"\\", @"\/", " " };
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
                        MessageBox.Show(@"The project name cannot allow to use any of the following character: <, >, ?, [, ], :, /, \ , * and white space", "Warning Project Name Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CheckWord = false;
                        break;                       
                    }
                    else
                    {
                        CheckWord = true;
                        ProjectName = @txtProjectName.Text;
                        btnDefinePJName.BackColor = Color.LightGreen;
                        btnEditPJName.BackColor = Color.LightBlue;
                        txtProjectName.ReadOnly = true;
                    }
                    if (CheckWord)
                    {
                        string filePathLCC = strDirectory + "SaveFiles";
                        string filePathImpact = strDirectory + "Impact Calculation\\SaveFile";
                        conSP.SaveProjectName_LCPlus(txtProjectName.Text, filePathLCC + "\\Project_Name.txt");
                        conSP.SaveProjectName_LCPlus(txtProjectName.Text, filePathImpact + "\\Project_Name.txt");                       
                    }
                }              
            }
            else
            {
                MessageBox.Show("The project name field cannot be blank.", "Warning Project Name Blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            /*dgvEquipmentPreview.Columns.Clear();
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
            }*/   
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

            //-----------------------------------------
            //SaveFile
            string MainProduct = filePathSave + "\\DefineMainProduct.txt";
            string SideProduct = filePathSave + "\\DefineSideProduct.txt";
            //Define product
            //Main Product
            conSP.SaveDataTable(dgvMainProduct, MainProduct);
            //Side Product
            conSP.SaveDataTable(dgvSideProduct, SideProduct);
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

            //-----------------------------------------
            //SaveFile
            string StreamPreview = filePathSave + "\\StreamTablePreview.txt";
            string InputStream = filePathSave + "\\DefineInputStream.txt";
            string OutputStream = filePathSave + "\\DefineOutputStream.txt";
            //Stream Table Preview
            conSP.SaveDataTable(dgvStreamTablePreview, StreamPreview);
            //Define Stream
            //Input Stream
            conSP.SaveDataTable(dgvStream_OpC, InputStream);
            //Output Stream
            conSP.SaveDataTable(dgvStreamOutput_OpC, OutputStream);
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
            if (btnDefineEqipment.BackColor == Color.LightGreen)
            {
                tabpage.SelectedIndex = 3;
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

            //-----------------------------------------
            //SaveFile
            string EquipPreview = filePathSave + "\\EquipmentTablePreview.txt";
            string InputEquip = filePathSave + "\\DefineEquipment.txt";
            //Eqipment Table Preview
            conSP.SaveDataTable(dgvEquipmentPreview, EquipPreview);
            //Define Equipment
            conSP.SaveDataTable(dgvEquipmentSummary, InputEquip);
        }
        int count = 0;
        private void btnCapitalCost_Click(object sender, EventArgs e)
        {
            //Disable combobox
            cbbProcessCap.Enabled = false;

            //Textbox and button enable
            txtOther_CC.Text = "";
            txtOther_CC.BackColor = Color.LightBlue;
            txtOther_CC.Enabled = true;
            btnAdd_CC.Enabled = true;

            if (btnCapitalCost.BackColor != Color.LightGreen)
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
                        string[] Equipmet_CC = { "No.", "Name", "Type", "Cost ($)" };
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
                                if (dgvEquipmentSummary.Rows[i].Cells[7].Value == null || dgvEquipmentSummary.Rows[i].Cells[7].Value.ToString() == "-" || dgvEquipmentSummary.Rows[i].Cells[7].Value.ToString() == "")
                                {
                                    PurchaseCost_EachEquipment = "0";
                                }
                                else
                                {
                                    PurchaseCost_EachEquipment = dgvEquipmentSummary.Rows[i].Cells[7].Value.ToString();
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
                        for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                        {
                            dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    if (dgvEquipment_CC.Rows.Count != 0)
                    {
                        for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
                        {
                            dgvEquipment_CC.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    tabpage.SelectedIndex = 4;
                    count = 0;
                    //Custom by user
                    rdbCustomCapCost.Checked = true;
                }
                txtTotal_CC.Text = "";
                con.tbNullValue(txtTotal_CC);
            }
            else
            {
                tabpage.SelectedIndex = 4;
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
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Working Capital Investment 
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
                    {
                        dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Equipment Cost
                if (dgvEquipment_CC.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
                    {
                        dgvEquipment_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
            
        }
        double Total_CapitalCost = 0;
        private void btnCalculate_CC_Click(object sender, EventArgs e)
        {
            if (con.statusDGV(dgvEquipment_CC, tabpage, "Capital Cost"))
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
                            for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
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
                            for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
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
                            for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
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
                        for (int i = 1; i < dgvOnetime_CC.Rows.Count; i++)
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
                        for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
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
                        for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                        {
                            dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    if (dgvWorkingCapital.Rows.Count != 0)
                    {
                        for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
                        {
                            dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                        }
                    }

                }
                txtTotal_CC.BackColor = Color.LightGreen;

                Total_CapitalCost = 0;
            }            
        }

        private void btnFeedstockCost_Click(object sender, EventArgs e)
        {
            if (btnFeedstockCost.BackColor != Color.LightGreen)
            {
                con.tbNullValue(txtTotal_FS);
            }
            tabpage.SelectedIndex = 6;
        }

        private void txtOther_CC_TextChanged(object sender, EventArgs e)
        {
            if (txtOther_CC.Text != "")
            {
                txtOther_CC.BackColor = Color.LightGreen;
            }
            else
            {
                txtOther_CC.BackColor = Color.LightBlue;
            }
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
            con.tbNullValue(txtTotalMaintenance);           
        }

        private void rdbSpecific_MC_CheckedChanged(object sender, EventArgs e)
        {
            MaintenanceType = "specific";
            txtPercent_MC.Text = "";
            gbSpecific_MC.Enabled = true;
            gbPercent_MC.Enabled = false;
            txtTotalMaintenance.Text = "";

            dgvSpecific_MC.Rows.Clear();
            dgvSpecific_MC.Columns.Clear();

            //header for maintanance cost
            string[] MCHeader = { "No.", "List of Maintenance Cost", "Cost ($)" };
            //Add Column name
            con.HeaderTable(dgvSpecific_MC, MCHeader);
        }

        private void txtTotal_CC_TextChanged(object sender, EventArgs e)
        {
            txtPreviewCC_MC.Text = txtTotal_CC.Text;
            
            con.ColorTBValue(txtTotal_CC);
        }

        private void btnAddSpecific_MC_Click(object sender, EventArgs e)
        {
            if (txtAddSpecific_MC.Text == "")
            {
                MessageBox.Show("Please type the specific maintenance cost.", "Warning missing specific maintenance cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvSpecific_MC.Rows.Add("", txtAddSpecific_MC.Text, "");
                for (int i = 0; i < dgvSpecific_MC.Rows.Count; i++)
                {
                    dgvSpecific_MC.Rows[i].Cells[0].Value = i + 1;
                }
            }
            con.tbNullValue(txtAddSpecific_MC);
            con.tbNullValue(txtTotalMaintenance);
        }

        private void txtPercent_MC_TextChanged(object sender, EventArgs e)
        {           
            con.StatusTBValue_Double(txtPercent_MC, "percentage of maintenance cost");
            con.tbNullValue(txtTotalMaintenance);
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
                        MessageBox.Show("Please ensure you have filled up the information in the capital cost page, and then try again.", "Warning missing capital cost value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabpage.SelectedIndex = 0;
                    }
                    else
                    {
                        InitialCC = Convert.ToDouble(txtPreviewCC_MC.Text);
                        Percent_MC = Convert.ToDouble(txtPercent_MC.Text);
                        //txtTotalMaintenance.Text = (((InitialCC * Percent_MC) / 100) / InterestRateCal).ToString("#,##0.##");

                        txtTotalMaintenance.Text = ((InitialCC * Percent_MC) / 100).ToString("#,##0.##");
                    }                    
                }
                else if (MaintenanceType == "")
                {
                    MessageBox.Show("Please select the type of maintenance cost, and then try again.", "Warning maintenance cost type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MaintenanceType == "specific")
                {                    
                    for (int i = 0; i < dgvSpecific_MC.Rows.Count; i++)
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
                MessageBox.Show("Please ensure you add the required maintenance cost information correctly, and then try again.", "Warning missing maintenace cost value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnMaintenanceCost_Click(object sender, EventArgs e)
        {
            if (btnMaintenanceCost.BackColor != Color.LightGreen)
            {
                con.tbNullValue(txtPercent_MC);
                con.tbNullValue(txtTotalMaintenance);
            }
            if (txtTotal_CC.BackColor == Color.LightGreen)
            {
                txtPreviewCC_MC.Text = txtTotal_CC.Text;
                txtPreviewCC_MC.BackColor = Color.LightGreen;
            }
            else
            {
                txtPreviewCC_MC.Text = "0";
                txtPreviewCC_MC.BackColor = Color.LightGreen;
            }

                tabpage.SelectedIndex = 7;
        }

        int salvage_count = 0;
        private void btnSalvageValue_Click(object sender, EventArgs e)
        {
            if (dgvEquipment_CC.Rows.Count == 0 || btnCapitalCost.BackColor == Color.Transparent)
            {
                MessageBox.Show("Please fill up the capital cost information before proceeding to the this step.", "Warning missing capital cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabpage.SelectedIndex = 0;
            }           
            else
            {
                if (btnSalvageValue.BackColor != Color.LightGreen)
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
                        for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
                        {
                            dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "");
                        }
                        dgvSalvageValue.AutoResizeColumns();
                        dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dgvSalvageValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dgvSalvageValue.Rows.Count != 0)
                    {
                        for (int i = 0; i < dgvSalvageValue.Rows.Count; i++)
                        {
                            dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    con.tbNullValue(txtTotal_SV);                    
                }
                
                rdbCustomSV.Checked = true;
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
                    for (int i = 0; i < dgvSalvageValue.Rows.Count; i++)
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
                    for (int i = 0; i < dgvSalvageValue.Rows.Count; i++)
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
                MessageBox.Show("Please ensure you add the required salvage value information correctly, and then try again.", "Warning Salvage value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
        
        private void btnOperatingCost_Click(object sender, EventArgs e)
        {
            if (btnOperatingCost.BackColor != Color.LightGreen)
            {
                //File path for duty catergory                
                string DutyFilePath = strDirectory + "SaveFiles\\DefineDutyCategory.txt";
                //check mixturefeed as default
                rdbMixtureFeed.Checked = true;

                //Clear all data in all datagridviews
                DataGridView[] AlldgvOPC = { dgvStreamOPC, dgvEquipmentOPC, dgvLaborOPC, dgvLaborMonth };
                con.ClearDGVList(AlldgvOPC);

                //Operating Cost for Equipment Table
                string[] OPC_EquipmentHeader = { "Equipment Name", "Duty/Work", "Duty category", "Duty type", "Unit", "Working hour (hr.)", "Cost per unit ($)", "Total Cost ($)" };
                if (dgvEquipmentSummary.Rows.Count != 0)
                {
                    //Add column Name              
                    con.HeaderTable(dgvEquipmentOPC, OPC_EquipmentHeader);
                    conCD.ReadtxtToList(DutyFilePath, DutyCatergory);
                    for (int i = 0; i < dgvEquipmentSummary.Rows.Count; i++)
                    {
                        string EquipName = dgvEquipmentSummary.Rows[i].Cells[0].Value.ToString();
                        string DutyVal = dgvEquipmentSummary.Rows[i].Cells[2].Value.ToString();
                        string DutyCat = DutyCatergory[i];
                        string DutyType = "Double click to select type";
                        string Unit = dgvEquipmentSummary.Rows[i].Cells[3].Value.ToString();
                        string WorkingHour = txtNumHour_OpC.Text;
                        dgvEquipmentOPC.Rows.Add(EquipName, DutyVal, DutyCat, DutyType, Unit, WorkingHour, "", "");
                    }

                    for (int j = 0; j < dgvEquipmentOPC.RowCount; j++)
                    {
                        dgvEquipmentOPC.Rows[j].Cells[3].Style.BackColor = Color.LightBlue;
                    }
                }

                //Operating Cost for Labor Table
                if (dgvLaborOPC.ColumnCount == 0)
                {
                    string[] OPC_LaborHeader = { " Operating Cost Name", "Number of Labor", "Working hour (hr.)", "Hour salary ($)", "Total Cost ($)" };
                    //Add column Name              
                    con.HeaderTable(dgvLaborOPC, OPC_LaborHeader);
                    dgvLaborOPC.Rows.Add("Double click to select type", "", txtNumHour_OpC.Text, "", "");
                }
                //Operating Cost for Labor per month Table
                if (dgvLaborMonth.ColumnCount == 0)
                {
                    string[] OPC_EmployeeHeader = { " Operating Cost Name", "Number of Labor", "Working month", "Month salary ($)", "Total Cost ($)" };
                    //Add column Name              
                    con.HeaderTable(dgvLaborMonth, OPC_EmployeeHeader);
                    string numMonth = (Convert.ToInt32(txtPeriod.Text) * 12).ToString();
                    dgvLaborMonth.Rows.Add("Double click to select type", "", numMonth, "", "");
                }

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

                for (int i = 1; i < dgvStreamOPC.Rows.Count; i++)
                {
                    dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
                }

                int startRow, endRow, ReadIndexColumn, fillIndexColumn;
                string query;
                //Add chemical price from database
                startRow = 1;
                endRow = dgvStreamOPC.RowCount;
                ReadIndexColumn = 0;
                fillIndexColumn = 1;
                query = "SELECT Price FROM CHEMICAL_PRICE WHERE Chemical_Name";
                conCD.GetDataToDGV(DBPath, dgvStreamOPC, startRow, endRow, ReadIndexColumn, fillIndexColumn, query);

                //Adjust auto column size of datagridview
                con.AutosizeDGV_AllCells(dgvEquipmentOPC);
                con.AutosizeDGV_AllCells(dgvLaborOPC);
                con.AutosizeDGV_AllCells(dgvLaborMonth);

                //Align to center
                dgvEquipmentOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLaborOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLaborMonth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStreamOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                txtTotal_OPC.Text = "";
                txtTotal_OPC.BackColor = Color.LightBlue;

                //Hightlight Green color for component price
                for (int j = 1; j < dgvStreamOPC.RowCount; j++)
                { 
                    string compName = dgvStreamOPC.Rows[j].Cells[1].Value.ToString();
                    if (compName != "")
                    {
                        dgvStreamOPC.Rows[j].Cells[1].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dgvStreamOPC.Rows[j].Cells[1].Style.BackColor = Color.LightBlue;
                    }                    
                }
                con.tbNullValue(txtTotal_OPC);
            }

            //Move to Operating Cost tab
            tabControl1.SelectedIndex = 0;
            tabpage.SelectedIndex = 5;
        }

        private void btnDone_OPC_Click(object sender, EventArgs e)
        {
            if (btnDone_OPC.Text == "Done")
            {
                if (con.StausTotalCost(txtTotal_OPC))
                {
                    btnOperatingCost.BackColor = Color.LightGreen;
                    tabpage.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Please click the calculate button before proceeding this step.", "Warning total cost calculation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedIndex = 1;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    tabControl1.SelectedIndex = 2;
                }
            }

            //-----------------------------------------
            //SaveFile
            //Operating Cost
            string OPCStream = filePathSave + "\\OPCStream.txt";
            string OPCUtility = filePathSave + "\\OPCUtility.txt";
            string OPCLaborHour = filePathSave + "\\OPCLabor_perHour.txt";
            string OPCLaborMonth = filePathSave + "\\OPCLabor_perMonth.txt";
            //Operating Cost
            string OPCTypeCal = "No";
            if (rdbMixtureFeed.Checked == true)
            {
                OPCTypeCal = "Mixture_Feed";
            }
            else if (rdbOverallFeed.Checked == true)
            {
                OPCTypeCal = "Overall_Feed";
            }

            string[] OperatingArray = { txtInterestRate.Text, txtPeriod.Text, txtNumHour_OpC.Text, OPCTypeCal, txtOverallFeed.Text, txtTotal_OPC.Text };
            conSP.SaveDataTable_ArrayVal(dgvStreamOPC, OPCStream, OperatingArray);
            conSP.SaveDataTable(dgvEquipmentOPC, OPCUtility);
            conSP.SaveDataTable(dgvLaborOPC, OPCLaborHour);
            conSP.SaveDataTable(dgvLaborMonth, OPCLaborMonth);
        }

        private void btnProductCredit_Click(object sender, EventArgs e)
        {
            if (btnProductCredit.BackColor != Color.LightGreen)
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
                con.tbNullValue(txtTotal_PC);
            }            
            tabpage.SelectedIndex = 9;
        }

        private void btnCalculateMainPage_Click(object sender, EventArgs e)
        {
            string[] SummaryList = { "Capital Cost", "Operating Cost", "Feedstock Cost", "Maintenance Cost", "Salvage Value", "Product Credit" };
            System.Windows.Forms.Button[] buttons = { btnCapitalCost, btnOperatingCost, btnFeedstockCost, btnMaintenanceCost, btnSalvageValue, btnProductCredit };

            //Check all status of all required cost fields. Ensure all button should be green color before clicking LCC calculation button
            bool buttonStatus = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].BackColor != Color.LightGreen)
                {
                    buttonStatus = false;
                    MessageBox.Show("The " + SummaryList[i] + " field is not completed.\n\nPlease ensure to click the " + SummaryList[i] + " button before proceeding this step.", "Warning missing required cost field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            //Go to LCC calculation logic
            if (buttonStatus)
            {
                dgvSummaryCost.Rows.Clear();
                dgvSummaryCost.Columns.Clear();
                //Operating Cost for Labor Table
                string[] SummaryHeader = { "LCC Name", "Cost ($)" };
                //Add column Name              
                con.HeaderTable(dgvSummaryCost, SummaryHeader);

                //Add Rows

                string[] SummaryData = { txtTotal_CC.Text, txtTotal_OPC.Text, txtTotal_FS.Text, txtTotalMaintenance.Text, txtTotal_SV.Text, txtTotal_PC.Text };
                for (int i = 0; i < SummaryList.Length; i++)
                {
                    dgvSummaryCost.Rows.Add(SummaryList[i], SummaryData[i]);
                }
                dgvSummaryCost.AutoResizeColumns();
                dgvSummaryCost.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    //Create LCC Cost chart
                    //Find Total LCC Cost
                    double Total_LCCCost = 0;
                    if (dgvSummaryCost.Rows.Count != 0)
                    {
                        for (int i = 0; i < dgvSummaryCost.Rows.Count; i++)
                        {
                            if (dgvSummaryCost.Rows[i].Cells[1].Value == null || dgvSummaryCost.Rows[i].Cells[1].Value.ToString() == "")
                            {
                                Total_LCCCost += 0;
                            }
                            else if (dgvSummaryCost.Rows[i].Cells[1].Value.ToString() == "-")
                            {
                                Total_LCCCost += 0;
                            }
                            else
                            {
                                Total_LCCCost += Convert.ToDouble(dgvSummaryCost.Rows[i].Cells[1].Value.ToString());
                            }
                        }

                        // Define data series                   
                        string EquipName_Chart;
                        double PercentEquip_Chart;
                        EquipCostChart.Series[0].Points.Clear();
                        for (int i = 0; i < dgvSummaryCost.Rows.Count; i++)
                        {
                            EquipName_Chart = dgvSummaryCost.Rows[i].Cells[0].Value.ToString();
                            PercentEquip_Chart = Math.Round((Convert.ToDouble(dgvSummaryCost.Rows[i].Cells[1].Value.ToString()) / Total_LCCCost) * 100, 2);
                            EquipCostChart.Series[0].Points.AddXY(EquipName_Chart, PercentEquip_Chart);
                        }

                        // Set chart title (optional)
                        EquipCostChart.Titles.Clear();
                        EquipCostChart.Titles.Add("Percentage of LCC Cost");
                        EquipCostChart.Series[0].IsValueShownAsLabel = true;
                        EquipCostChart.Series[0].IsVisibleInLegend = true;
                    }                   

                    //Go to LCC page
                    tabpage.SelectedIndex = 10;
                }
                catch
                {
                    MessageBox.Show("Please verify that all required cost fields have been completed on each page, and then try again.", "Warning missing required cost fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            if (con.StausTotalCost(txtNumHour_OpC))
            {
                if (txtNumHour_OpC.Text != "")
                {
                    //Equipment Table
                    for (int i = 0; i < dgvEquipmentOPC.Rows.Count; i++)
                    {
                        dgvEquipmentOPC.Rows[i].Cells[5].Value = txtNumHour_OpC.Text;
                    }

                    //Labor Table
                    dgvLaborOPC.Rows[0].Cells[2].Value = txtNumHour_OpC.Text;

                    //Stream Table
                    for (int i = 1; i < dgvStreamOPC.Rows.Count; i++)
                    {
                        dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
                    }
                }

                for (int i = 1; i < dgvStreamOPC.Rows.Count; i++)
                {
                    dgvStreamOPC.Rows[i].Cells[dgvStreamOPC.Columns.Count - 1].Value = "";
                }
                dgvEquipmentOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLaborOPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("The number of working work is not integer.\n\nPlease ensure that you fill the value correctly.", "Warning number of working hour value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            con.StatusTBValue(txtInterestRate, "interest rate");
            con.tbNullValue(txtTotal_OPC);
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue(txtPeriod, "plant life");
            con.tbNullValue(txtTotal_OPC);
        }        
                              
        private void txtCPI_Index_TextChanged(object sender, EventArgs e)
        {
            //con.StatusTBValue(txtCPI_Index, "CEP Cost Index");
            /*try
            {
                if (txtCPI_Index.Text != "")
                {
                    CPI_Index = Convert.ToDouble(txtCPI_Index.Text);
                }
            }
            catch
            {
                MessageBox.Show("Please ensure you fill the CPI correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }                      

        private void rdbCustomCapCost_CheckedChanged(object sender, EventArgs e)
        {
            //Disable combobox
            cbbProcessCap.Enabled = false;

            //Textbox and button enable
            txtOther_CC.Text = "";
            txtOther_CC.BackColor = Color.LightBlue;
            txtOther_CC.Enabled = true;
            btnAdd_CC.Enabled = true;

            //User Defined
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
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                //Add Row data Working Capital Investment
                dgvWorkingCapital.Rows.Add("1", "Working Capital Investmenst (WC)", "");
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
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
            //Enable combobox
            if (cbbProcessCap.Text == "")
            {
                cbbProcessCap.Text = "Fluid processing";
            }           
            cbbProcessCap.Enabled = true;

            //Textbox and button disable
            txtOther_CC.Text = "";
            txtOther_CC.BackColor = Color.LightBlue;
            txtOther_CC.Enabled = false;
            btnAdd_CC.Enabled = false;
          
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
                for  (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
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
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                    {
                        dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                if (dgvWorkingCapital.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
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
            txtTotal_CC.Text = "";
            txtTotal_CC.BackColor = Color.LightBlue;

            //clear datagridview
            dgvEquipment_CC.Rows.Clear();
            dgvEquipment_CC.Columns.Clear();

            dgvOnetime_CC.Rows.Clear();
            dgvOnetime_CC.Columns.Clear();
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

                //Hightlight Green color for component price
                for (int j = 1; j < dgvStreamOPC.RowCount; j++)
                {
                    dgvStreamOPC.Rows[j].Cells[1].Style.BackColor = Color.LightBlue;
                }
            }
            con.tbNullValue(txtTotal_OPC);
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

                for (int i = 1; i < dgvStreamOPC.Rows.Count; i++)
                {
                    dgvStreamOPC.Rows[i].Cells[2].Value = txtNumHour_OpC.Text;
                }

                int startRow, endRow, ReadIndexColumn, fillIndexColumn;
                string query;
                //Add chemical price from database
                startRow = 1;
                endRow = dgvStreamOPC.RowCount;
                ReadIndexColumn = 0;
                fillIndexColumn = 1;
                query = "SELECT Price FROM CHEMICAL_PRICE WHERE Chemical_Name";
                conCD.GetDataToDGV(DBPath, dgvStreamOPC, startRow, endRow, ReadIndexColumn, fillIndexColumn, query);

                //Hightlight Green color for component price
                for (int j = 1; j < dgvStreamOPC.RowCount; j++)
                {
                    string compName = dgvStreamOPC.Rows[j].Cells[1].Value.ToString();
                    if (compName != "")
                    {
                        dgvStreamOPC.Rows[j].Cells[1].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dgvStreamOPC.Rows[j].Cells[1].Style.BackColor = Color.LightBlue;
                    }
                }
            }
            con.tbNullValue(txtTotal_OPC);
        }
        double TotalOPforEconEval = 0;
        private void btnCalOPC_Click(object sender, EventArgs e)
        {
            if (txtInterestRate.BackColor == Color.LightGreen)
            {
                if (txtPeriod.BackColor == Color.LightGreen)
                {
                    if (txtNumHour_OpC.BackColor == Color.LightGreen)
                    {
                        if (con.statusDGV(dgvStreamOPC, tabpage, "Operating Cost"))
                        {
                            //Operating for Cost stream
                            double InterestRateCal;
                            InterestRateCal = con.Cal_AnnualToPresent(txtInterestRate.Text, txtPeriod.Text);
                            double Total_EachRowStream, CostComponent;
                            int RowCount = dgvStreamOPC.Rows.Count;
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
                            for (int i = 0; i < dgvEquipmentOPC.Rows.Count; i++)
                            {
                                DutyEquip = Math.Abs(Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[1].Value.ToString()));
                                WorkingEquip = Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[5].Value.ToString());
                                if (dgvEquipmentOPC.Rows[i].Cells[6].Value == null || dgvEquipmentOPC.Rows[i].Cells[6].Value.ToString() == "")
                                {
                                    CostEquip = 0;
                                    dgvEquipmentOPC.Rows[i].Cells[6].Value = "-";
                                }
                                else if (dgvEquipmentOPC.Rows[i].Cells[6].Value.ToString() == "-")
                                {
                                    CostEquip = 0;
                                }
                                else
                                {
                                    CostEquip = Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[6].Value.ToString());
                                }
                                //Show Total Cost
                                dgvEquipmentOPC.Rows[i].Cells[7].Value = (DutyEquip * WorkingEquip * CostEquip).ToString("#,##0.##");
                            }

                            //Operating for Labor
                            double NumLabor, Working_time, CostSalary, TotalLaborCost;
                            //Labor Cost (per hour)
                            for (int i = 0; i < dgvLaborOPC.Rows.Count; i++)
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
                                    MessageBox.Show("Please ensure you add the information in Labor Cost (per hour) table correctly, and then try again.", "Warning Labor Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                            //Labor Cost (per month)
                            for (int i = 0; i < dgvLaborMonth.Rows.Count; i++)
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
                                    MessageBox.Show("Please ensure you add the information in Labor Cost (per month) table correctly, and then try again.", "Warning Labor Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            //Calculation for Total Cost of Operating Cost
                            double TotalOperatingCost;
                            TotalOperatingCost = 0;
                        
                            for (int i = 1; i < dgvStreamOPC.Rows.Count; i++)
                            {                                              
                                TotalOperatingCost += Convert.ToDouble(dgvStreamOPC.Rows[i].Cells[dgvStreamOPC.Columns.Count - 1].Value.ToString());                                
                            }
                            for (int i = 0; i < dgvEquipmentOPC.Rows.Count; i++)
                            {
                                TotalOperatingCost += Convert.ToDouble(dgvEquipmentOPC.Rows[i].Cells[dgvEquipmentOPC.Columns.Count - 1].Value.ToString());
                            }
                            for (int i = 0; i < dgvLaborOPC.Rows.Count; i++)
                            {
                                TotalOperatingCost += Convert.ToDouble(dgvLaborOPC.Rows[i].Cells[dgvLaborOPC.Columns.Count - 1].Value.ToString());
                            }
                            for (int i = 0; i < dgvLaborMonth.Rows.Count; i++)
                            {
                                TotalOperatingCost += Convert.ToDouble(dgvLaborMonth.Rows[i].Cells[dgvLaborMonth.Columns.Count - 1].Value.ToString());
                            }

                            txtTotal_OPC.Text = (TotalOperatingCost / InterestRateCal).ToString("#,##0.##");

                            //For Total Product Cost Calculation in Economic evaluation
                            TotalOPforEconEval = 0;
                            TotalOPforEconEval = TotalOperatingCost;
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("The number of working hour is not integer.\n\nPlease ensure that you fill the value correctly.", "Warning number of working hour value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The plant life is not integer.\n\nPlease ensure that you fill the value correctly.", "Warning plant life value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("The interate rate is not integer.\n\nPlease ensure that you fill the value correctly.", "Warning interate rate value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                           
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
                for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
                {
                    dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "");
                }
                dgvSalvageValue.AutoResizeColumns();
                dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            if (dgvSalvageValue.Rows.Count != 0)
            {
                for (int i = 0; i < dgvSalvageValue.Rows.Count; i++)
                {
                    dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                }
            }
            salvage_count = 0;

            con.tbNullValue(txtTotal_SV);
        }

        private void rdbPercentFirstCost_CheckedChanged(object sender, EventArgs e)
        {
            if (salvage_count == 0)
            {
                dgvSalvageValue.Rows.Clear();
                dgvSalvageValue.Columns.Clear();
                //Datagridview for equipment
                string[] Equipmet_CC = { "No.", "Name List of Equipment expenses", "Type of Equipment", "% Initial Equipment Cost", "Cost ($)" };
                //Add Column name
                con.HeaderTable2(dgvSalvageValue, Equipmet_CC);
                //Add Row data
                double InitialEquipCost;
                for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
                {
                    InitialEquipCost = Convert.ToDouble(dgvEquipment_CC.Rows[i].Cells[3].Value.ToString());
                    dgvSalvageValue.Rows.Add("", dgvEquipment_CC.Rows[i].Cells[1].Value.ToString(), dgvEquipment_CC.Rows[i].Cells[2].Value.ToString(), "10", (0.1 * InitialEquipCost).ToString("#,##0.##"));
                }
                dgvSalvageValue.AutoResizeColumns();
                dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            if (dgvSalvageValue.Rows.Count != 0)
            {
                for (int i = 0; i < dgvSalvageValue.Rows.Count; i++)
                {
                    dgvSalvageValue.Rows[i].Cells[0].Value = i + 1;
                }
            }
            salvage_count = 0;

            con.tbNullValue(txtTotal_SV);
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
            //InterestRateCal = con.Cal_InterestRate(txtInterestRate.Text, txtPeriod.Text);
            double Total_EachRowStream, CostComponent;
            int RowCount;
            //For Main Product
            RowCount = dgvMainP.Rows.Count;
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
            RowCount = dgvSideP.Rows.Count;
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
            for (int i = 1; i < dgvMainP.Rows.Count; i++)
            {
                TotalBPCCost += Convert.ToDouble(dgvMainP.Rows[i].Cells[dgvMainP.Columns.Count - 1].Value.ToString());
            }
            for (int i = 1; i < dgvSideP.Rows.Count; i++)
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
            System.Windows.Forms.TextBox[] textbox = { txtCIR, txtPPIR, txtTIR, txtMar, txtRma, txtTax, txtLandCostInvestment };
            string[] comment = { "construction inflation rate", "product price inflation rate", "TPC inflation rate", "minimum acceptable rate of return", "minimum acceptable nominal rate", "income tax rate", "land cost" };


            if (con.StatusTB(textbox, comment))
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

                con.AutosizeDGV(dgvProductCap);
                //Go to Product capacity page
                tabEconEval.SelectedIndex = 1;
            }           
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
            if (txtTotalLCC.BackColor == Color.LightGreen || txtTotalLCC.BackColor == Color.LightYellow)
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
                for (int i = 0; i < dgvProductCap.Rows.Count; i++)
                {
                    dgvEconSummary.Rows[0].Cells[i + 4].Value = dgvProductCap.Rows[i].Cells[1].Value.ToString() + "%";
                }
                //Land
                dgvEconSummary.Rows[2].Cells[1].Value = (Convert.ToDouble(txtLandCostInvestment.Text) * -1).ToString("#,##0.##");
                //Fixed Capital Investment Calculation
                double CalFixCap = 0;
                if (rdbCustomCapCost.Checked == true)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                    {
                        string CapValue = dgvOnetime_CC.Rows[i].Cells[2].Value.ToString();
                        if (CapValue == "-")
                        {
                            CapValue = "0";
                        }
                        CalFixCap += Convert.ToDouble(CapValue);
                    }
                }
                else if (rdbECONCapCost.Checked == true)
                {
                    for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
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
                    string CapValWCT = dgvWorkingCapital.Rows[0].Cells[2].Value.ToString();
                    if (CapValWCT == "-")
                    {
                        CapValWCT = "0";
                    }

                    if (CalFixCap == 0)
                    {
                        dgvEconSummary.Rows[4].Cells[3].Value = 0;
                    }
                    else
                    {
                        dgvEconSummary.Rows[4].Cells[3].Value = ((Convert.ToDouble(CapValWCT) * Sum_FCI) / CalFixCap).ToString("#,##0.##");
                    }                        
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
                int[] SelectRow_PW = { 19, 22, 27, 30 };
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
                dgvEconSummary.Rows[32].Cells[1].Value = ((SumNetProfit / (SumOfTCI * -1) / NumYear) * 100).ToString("#,##0.##") + "%";
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
                System.Windows.Forms.DataVisualization.Charting.Series newSeries = Cum_CashFlowChart.Series.Add("Zero baseline");
                newSeries.ChartType = SeriesChartType.Line;
                System.Windows.Forms.DataVisualization.Charting.Series newSeries2 = Cum_CashFlowChart.Series.Add("CumCashFlow");
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

                System.Windows.Forms.DataVisualization.Charting.Axis yAxis = Cum_CashFlowChart.ChartAreas[0].AxisY;
                yAxis.LabelStyle.Format = "#,0";
                //yAxis.Interval = 10000;
                System.Windows.Forms.DataVisualization.Charting.Legend legend = Cum_CashFlowChart.Legends[0]; // Assuming one legend
                legend.Docking = Docking.Bottom; // Adjust docking as needed (Top, Right, Left)


                //SaveFile
                string EconValProduct = filePathSave + "\\EconomicValueAndProductCapacity.txt";
                string EconSum = filePathSave + "\\EconomicSummary.txt";
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
                
                conSP.SaveData2Tables_ArrayVal(dgvProductCap, dgvEconSummary, EconValProduct, EconSum, EconVal);                


                //Go to Economic Summary page
                tabEconEval.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("There is no data for LCC.\n\nPlease click LCC Calculation button on main page before processing this step.", "Warning missing LCC calculation data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabpage.SelectedIndex = 0;
            }
        }

        private void txtRma_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtRma, "minimum acceptable nominal rate");
        }                                    

        private void cbbProcessCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvWorkingCapital.Columns.Clear();
            dgvWorkingCapital.Rows.Clear();           
            double TotalEquipCost = 0;
            for (int i = 0; i < dgvEquipment_CC.Rows.Count; i++)
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
                for (int i = 0; i < dgvOnetime_CC.Rows.Count; i++)
                {
                    dgvOnetime_CC.Rows[i].Cells[0].Value = i + 1;
                }
            }
            if (dgvWorkingCapital.Rows.Count != 0)
            {
                for (int i = 0; i < dgvWorkingCapital.Rows.Count; i++)
                {
                    dgvWorkingCapital.Rows[i].Cells[0].Value = i + 1;
                }
            }
            txtTotal_CC.Text = TotalCapCost.ToString("#,##0.##");

            //Change color of total capital cost
            if (dgvEquipment_CC.RowCount != 0)
            {
                txtTotal_CC.BackColor = Color.LightGreen;
            }
        }        

        private void btnExcelLCC_Click(object sender, EventArgs e)
        {
            string PJName = txtProjectName.Text;
            string str1 = txtTotalMaintenance.Text;           
            conEx.CreateExcel(PJName, dgvMainP, dgvSideP, dgvSalvageValue, dgvSpecific_MC, str1, dgvRawMat_FS, dgvStreamOPC, dgvEquipmentOPC, dgvLaborOPC, dgvLaborMonth, dgvEquipment_CC, dgvOnetime_CC, dgvWorkingCapital, dgvSummaryCost);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbbUnitDrive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_OPC_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue(txtTotal_OPC);            
        }

        private void btnClearOPC_Click(object sender, EventArgs e)
        {
            //Clear all data in all datagridviews
            DataGridView[] AlldgvOPC = { dgvStreamOPC, dgvEquipmentOPC, dgvLaborOPC, dgvLaborMonth };
            con.ClearDGVList(AlldgvOPC);

            //Clear total operating cost
            txtTotal_OPC.Text = "";
            txtTotal_OPC.BackColor = Color.LightBlue;

            //Change text in overfeed text box to be default
            txtOverallFeed.Text = "Product1";

            //Change color of operating cost button at main page
            btnOperatingCost.BackColor = Color.Transparent;

            //Move to Main page tab
            tabpage.SelectedIndex = 0;
        }

        private void txtNumHour_OpC_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue(txtNumHour_OpC, "number of woking hour");
            con.tbNullValue(txtTotal_OPC);
        }

        private void txtTotalMaintenance_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue(txtTotalMaintenance);
        }

        private void rdbSpecific_MC_TextChanged(object sender, EventArgs e)
        {
            con.tbNullValue(txtTotalMaintenance);
        }

        private void txtTotal_SV_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue(txtTotal_SV);
        }

        private void txtTotal_PC_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue(txtTotal_PC);
        }

        private void txtTotalSummary_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue_expense(txtTotalSummary);
            txtTotalSummary.ForeColor = Color.Red;
        }

        private void txtLCCRevenue_TextChanged(object sender, EventArgs e)
        {
            con.ColorTBValue(txtLCCRevenue);
        }

        private void txtTotalLCC_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalLCC.Text.Contains("-"))
            {
                txtTotalLCC.BackColor = Color.LightYellow;
                txtTotalLCC.ForeColor = Color.Red;
                lblTotalLCC.ForeColor = Color.DarkRed;
            }
            else
            {
                txtTotalLCC.BackColor = Color.LightGreen;
                txtTotalLCC.ForeColor = SystemColors.WindowText;
                lblTotalLCC.ForeColor = Color.DarkGreen;
            }
        }

        private void btnEconomic_Click(object sender, EventArgs e)
        {
            if (txtTotalLCC.BackColor != Color.LightBlue)
            {
                tabEconEval.SelectedIndex = 0;
                tabpage.SelectedIndex = 11;
            }
            else
            {
                MessageBox.Show("There is no data for LCC.\n\nPlease click LCC Calculation button on main page before processing this step.", "Warning missing LCC calculation data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabpage.SelectedIndex = 0;
            }
            
        }

        private void txtCIR_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtCIR, "construction inflation rate");
        }

        private void txtPPIR_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtPPIR, "product price inflation rate");
        }

        private void txtTIR_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtTIR, "TPC inflation rate");
        }

        private void txtMar_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtMar, "minimum acceptable rate of return");
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtTax, "income tax rate");
        }

        private void txtLandCostInvestment_TextChanged(object sender, EventArgs e)
        {
            con.StatusTBValue_Double(txtLandCostInvestment, "land cost");
        }

        private void btnOPCBack_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                tabControl1.SelectedIndex = 1;
            }            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnOPCBack.Visible = false;
                btnDone_OPC.Text = "Next";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                btnOPCBack.Visible = true;
                btnDone_OPC.Text = "Next";
            }
            else
            {
                btnOPCBack.Visible = true;
                btnDone_OPC.Text = "Done";
            }
        }

        private void dgvStreamOPC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void UpdateCompPrice (string price)
        {
            //Update price of component
            int lastcol = dgvStreamOPC.ColumnCount - 1;
            dgvStreamOPC.SelectedRows[0].Cells[1].Value = price;
            dgvStreamOPC.SelectedRows[0].Cells[lastcol].Value = "";

            //Update color of datagridview
            dgvStreamOPC.SelectedRows[0].Cells[1].Style.BackColor = Color.LightGreen;            

            con.tbNullValue(txtTotal_OPC);
        }

        private void dgvStreamOPC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStreamOPC.ColumnCount != 0)
            {
                if (e.RowIndex != 0)
                {
                    string compName = dgvStreamOPC.SelectedRows[0].Cells[0].Value.ToString();
                    string priceVal = dgvStreamOPC.SelectedRows[0].Cells[1].Value.ToString();
                    Utility_Stream_Price page = new Utility_Stream_Price(compName, priceVal, this);
                    page.Show();
                }               
            }
        }
        public void UpdateUtilityPrice (string dutyType, string price)
        {
            //Update value if duty type and price
            dgvEquipmentOPC.SelectedRows[0].Cells[3].Value = dutyType;            
            dgvEquipmentOPC.SelectedRows[0].Cells[6].Value = price;
            dgvEquipmentOPC.SelectedRows[0].Cells[7].Value = "";

            //Update color of datagridview
            dgvEquipmentOPC.SelectedRows[0].Cells[3].Style.BackColor = Color.LightGreen;
            dgvEquipmentOPC.SelectedRows[0].Cells[6].Style.BackColor = Color.LightGreen;

            con.tbNullValue(txtTotal_OPC);
        }

        private void dgvEquipmentOPC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEquipmentOPC.RowCount != 0)
            {
                string EquipName = dgvEquipmentOPC.SelectedRows[0].Cells[0].Value.ToString().Trim();
                Utility_Chemical_Price page = new Utility_Chemical_Price(DBPath, EquipName, this);
                page.Show();
            }
            
        }
        public void UpdateLaborCost (string JobName, string numberLabor, string salary, int type)
        {
            int lastrowLabor;
            if (type == 1)
            {
                //Fill data
                dgvLaborOPC.SelectedRows[0].Cells[0].Value = JobName;
                dgvLaborOPC.SelectedRows[0].Cells[1].Value = numberLabor;
                dgvLaborOPC.SelectedRows[0].Cells[3].Value = salary;

                //Update color of datagridview
                dgvLaborOPC.SelectedRows[0].Cells[0].Style.BackColor = Color.LightGreen;
                dgvLaborOPC.SelectedRows[0].Cells[1].Style.BackColor = Color.LightGreen;
                dgvLaborOPC.SelectedRows[0].Cells[3].Style.BackColor = Color.LightGreen;

                //Add new row
                dgvLaborOPC.Rows.Add("Double click to select type ", "", txtNumHour_OpC.Text, "", "");
                //Change color of cell in last row
                lastrowLabor = dgvLaborOPC.RowCount - 1;
                dgvLaborOPC.Rows[lastrowLabor].Cells[0].Style.BackColor = Color.LightBlue;
            }
            else
            {
                //Fill data
                dgvLaborMonth.SelectedRows[0].Cells[0].Value = JobName;
                dgvLaborMonth.SelectedRows[0].Cells[1].Value = numberLabor;
                dgvLaborMonth.SelectedRows[0].Cells[3].Value = salary;

                //Update color of datagridview
                dgvLaborMonth.SelectedRows[0].Cells[0].Style.BackColor = Color.LightGreen;
                dgvLaborMonth.SelectedRows[0].Cells[1].Style.BackColor = Color.LightGreen;
                dgvLaborMonth.SelectedRows[0].Cells[3].Style.BackColor = Color.LightGreen;

                //Add new row
                string numMonth = (Convert.ToInt32(txtPeriod.Text) * 12).ToString();
                dgvLaborMonth.Rows.Add("Double click to select type ", "", numMonth, "", "");
                //Change color of cell in last row
                lastrowLabor = dgvLaborMonth.RowCount - 1;
                dgvLaborMonth.Rows[lastrowLabor].Cells[0].Style.BackColor = Color.LightBlue;
            }
            con.tbNullValue(txtTotal_OPC);
        }

        private void dgvLaborOPC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ID of labor cost type per hour
            //--ID_DB value comes from database in TypeID column of LABOR_PRICE
            int ID_DB = 1; 
            Utility_Labor_Price page = new Utility_Labor_Price(DBPath, ID_DB, this);
            page.Show();
        }

        private void dgvLaborMonth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ID of labor cost type per hour
            //--ID_DB value comes from database in TypeID column of LABOR_PRICE
            int ID_DB = 2;
            Utility_Labor_Price page = new Utility_Labor_Price(DBPath, ID_DB, this);
            page.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text != "")
            {
                List<string> SaveDataList = new List<string>();
                SaveDataList.Clear();

                //---------------------
                //Location Save Path
                string projectNamePath = filePathSave + "\\Project_Name.txt";

                //Path for define stream and equipment
                string StreamPreview = filePathSave + "\\StreamTablePreview.txt";
                string EquipPreview = filePathSave + "\\EquipmentTablePreview.txt";
                string MainProduct = filePathSave + "\\DefineMainProduct.txt";
                string SideProduct = filePathSave + "\\DefineSideProduct.txt";
                string InputStream = filePathSave + "\\DefineInputStream.txt";
                string OutputStream = filePathSave + "\\DefineOutputStream.txt";
                string InputEquip = filePathSave + "\\DefineEquipment.txt";

                //Capital Cost
                string PurchaseEquip = filePathSave + "\\PurchaseEquipment.txt";
                string FCI = filePathSave + "\\FCI.txt";
                string WCI = filePathSave + "\\WCI.txt";

                //Operating Cost
                string OPCStream = filePathSave + "\\OPCStream.txt";
                string OPCUtility = filePathSave + "\\OPCUtility.txt";
                string OPCLaborHour = filePathSave + "\\OPCLabor_perHour.txt";
                string OPCLaborMonth = filePathSave + "\\OPCLabor_perMonth.txt";
                //string DutyCategory = filePathSave + "\\DefineDutyCategory.txt";

                //FeedStock Cost
                string FeedStock = filePathSave + "\\FeedStockCost.txt";

                //Maintenance Cost
                string Maintenance = filePathSave + "\\MaintenanceCost.txt";

                //Salvage Cost
                string Salvage = filePathSave + "\\SalvageValue.txt";

                //Product Credits
                string MainProductCredit = filePathSave + "\\MainProductCredit.txt";
                string SideProductCredit = filePathSave + "\\SideProductCredit.txt";

                //Economic Evaluation
                string EconValue = filePathSave + "\\EconomicValueAndProductCapacity.txt";
                string EconSummary = filePathSave + "\\EconomicSummary.txt";


                //Save LCC Data
                string AllSaveFiles = conSP.GetLocationSaveFile(conSP.ReadFirstLine(projectNamePath));
                if (AllSaveFiles != "")
                {
                    //-----------------Save Files-----------------
                    SaveDataList.Add("Copyright (C) PSE for SPEED Co., Ltd.");
                    SaveDataList.Add("-----------LCC Save file-----------");
                    SaveDataList.Add("-----------StreamTablePreview-----------");
                    conSP.ReadtxtToList(StreamPreview, SaveDataList);
                    SaveDataList.Add("-----------EquipmentTablePreview-----------");
                    conSP.ReadtxtToList(EquipPreview, SaveDataList);
                    SaveDataList.Add("-----------DefineMainProduct-----------");
                    conSP.ReadtxtToList(MainProduct, SaveDataList);
                    SaveDataList.Add("-----------DefineSideProduct-----------");
                    conSP.ReadtxtToList(SideProduct, SaveDataList);
                    SaveDataList.Add("-----------DefineInputStream-----------");
                    conSP.ReadtxtToList(InputStream, SaveDataList);
                    SaveDataList.Add("-----------DefineOutputStream-----------");
                    conSP.ReadtxtToList(OutputStream, SaveDataList);
                    SaveDataList.Add("-----------DefineEquipment-----------");
                    conSP.ReadtxtToList(InputEquip, SaveDataList);
                    SaveDataList.Add("-----------PurchaseEquipment-----------");
                    conSP.ReadtxtToList(PurchaseEquip, SaveDataList);
                    SaveDataList.Add("-----------FCI-----------");
                    conSP.ReadtxtToList(FCI, SaveDataList);
                    SaveDataList.Add("-----------WCI-----------");
                    conSP.ReadtxtToList(WCI, SaveDataList);
                    SaveDataList.Add("-----------OPCStream-----------");
                    conSP.ReadtxtToList(OPCStream, SaveDataList);
                    SaveDataList.Add("-----------OPCUtility-----------");
                    conSP.ReadtxtToList(OPCUtility, SaveDataList);
                    SaveDataList.Add("-----------OPCLabor_perHour-----------");
                    conSP.ReadtxtToList(OPCLaborHour, SaveDataList);
                    SaveDataList.Add("-----------OPCLabor_perMonth-----------");
                    conSP.ReadtxtToList(OPCLaborMonth, SaveDataList);
                    //SaveDataList.Add("-----------DutyCategory-----------");
                    //conSP.ReadtxtToList(DutyCategory, SaveDataList);
                    SaveDataList.Add("-----------FeedStockCost-----------");
                    conSP.ReadtxtToList(FeedStock, SaveDataList);
                    SaveDataList.Add("-----------MaintenanceCost-----------");
                    conSP.ReadtxtToList(Maintenance, SaveDataList);
                    SaveDataList.Add("-----------SalvageValue-----------");
                    conSP.ReadtxtToList(Salvage, SaveDataList);
                    SaveDataList.Add("-----------MainProductCredit-----------");
                    conSP.ReadtxtToList(MainProductCredit, SaveDataList);
                    SaveDataList.Add("-----------SideProductCredit-----------");
                    conSP.ReadtxtToList(SideProductCredit, SaveDataList);
                    SaveDataList.Add("-----------EconomicValueAndProductCapacity-----------");
                    conSP.ReadtxtToList(EconValue, SaveDataList);
                    SaveDataList.Add("-----------EconomicSummary-----------");
                    conSP.ReadtxtToList(EconSummary, SaveDataList);
                    //Save to txt file
                    conSP.SavetxtFromList(AllSaveFiles, SaveDataList);

                    MessageBox.Show("Data saved successfully to " + AllSaveFiles, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please define project name before proceeding this step.", "Missing project name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void dgvSpecific_MC_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < dgvSpecific_MC.RowCount; i++)
            {
                dgvSpecific_MC.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void txtAddSpecific_MC_TextChanged(object sender, EventArgs e)
        {
            if (txtAddSpecific_MC.Text != "")
            {
                txtAddSpecific_MC.BackColor = Color.LightGreen;
            }
            else
            {
                txtAddSpecific_MC.BackColor = Color.LightBlue;
            }
        }

        private void btnClearAllMain_Click(object sender, EventArgs e)
        {
            dgvSpecific_MC.Rows.Clear();
            gbSpecific_MC.Enabled = false;
            gbPercent_MC.Enabled = false;
            rdbPercent_MC.Checked = false;
            rdbSpecific_MC.Checked = false;
            con.tbNullValue(txtPercent_MC);
            con.tbNullValue(txtTotalMaintenance);
            btnMaintenanceCost.BackColor = Color.Transparent;
            
            tabpage.SelectedIndex = 0;
        }

        private void btnClearSalvage_Click(object sender, EventArgs e)
        {
            dgvSalvageValue.Rows.Clear();
            dgvSalvageValue.Columns.Clear();
            rdbCustomSV.Checked = true;
            con.tbNullValue(txtTotal_SV);
            btnSalvageValue.BackColor = Color.Transparent;
            tabpage.SelectedIndex = 0;
        }

        private void btnClearAllP_Click(object sender, EventArgs e)
        {
            dgvMainP.Rows.Clear();
            dgvMainP.Columns.Clear();
            dgvSideP.Rows.Clear();
            dgvSideP.Columns.Clear();
            con.tbNullValue(txtTotal_PC);
            btnProductCredit.BackColor = Color.Transparent;
            tabpage.SelectedIndex = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conSP.OpenAllSavefiles())
            {
                string projectNamePath = filePathSave + "\\Project_Name.txt";
                string streamTablePath = filePathSave + "\\StreamTablePreview.txt";
                //Capital Cost
                string PurchaseEquip = filePathSave + "\\PurchaseEquipment.txt";
                string FCI = filePathSave + "\\FCI.txt";
                string WCI = filePathSave + "\\WCI.txt";

                //Operating Cost
                string OPCStream = filePathSave + "\\OPCStream.txt";
                string OPCUtility = filePathSave + "\\OPCUtility.txt";
                string OPCLaborHour = filePathSave + "\\OPCLabor_perHour.txt";
                string OPCLaborMonth = filePathSave + "\\OPCLabor_perMonth.txt";
                //string DutyCategory = filePathSave + "\\DefineDutyCategory.txt";

                //FeedStock Cost
                string FeedStock = filePathSave + "\\FeedStockCost.txt";

                //Maintenance Cost
                string Maintenance = filePathSave + "\\MaintenanceCost.txt";

                //Salvage Cost
                string Salvage = filePathSave + "\\SalvageValue.txt";

                //Product Credits
                string MainProductCredit = filePathSave + "\\MainProductCredit.txt";
                string SideProductCredit = filePathSave + "\\SideProductCredit.txt";

                //Economic Evaluation
                string EconValue = filePathSave + "\\EconomicValueAndProductCapacity.txt";
                string EconSummary = filePathSave + "\\EconomicSummary.txt";
                //-------------------------------------
                //Import Project Name
                if (File.Exists(projectNamePath))
                {
                    txtProjectName.Text = conSP.ReadFirstLine(projectNamePath);
                    txtProjectName.ReadOnly = true;
                    btnDefinePJName.BackColor = Color.LightGreen;
                    btnEditPJName.BackColor = Color.LightBlue;
                }
                //-------------------------------------
                //Import Stream Table
                if (File.Exists(streamTablePath))
                {
                    conSP.ImportData(dgvStreamTablePreview, ValueParameter, 0, 0, 1, streamTablePath);
                    StreamName.Clear();
                    ComponentName.Clear();
                    con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
                    //Show file name in Textbox
                    txtStreamtable_OpC.Text = streamTablePath;
                    txtStreamtable_OpC.ReadOnly = true;
                    txtProductFile.Text = streamTablePath;
                    txtProductFile.ReadOnly = true;
                }
                //-------------------------------------
                //Import Equiment Table
                conSP.ImportData(dgvEquipmentPreview, ValueParameter, 0, 0, 1, filePathSave + "\\EquipmentTablePreview.txt");
                //Show file name in Textbox
                txtEquipmentFile.Text = filePathSave + "\\EquipmentTablePreview.txt";
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
                conSP.ImportData(dgvMainProduct, ValueParameter, 0, 0, 1, filePathSave + "\\DefineMainProduct.txt");
                //Side Product
                conSP.ImportData(dgvSideProduct, ValueParameter, 0, 0, 1, filePathSave + "\\DefineSideProduct.txt");
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
                conSP.ImportData(dgvStream_OpC, ValueParameter, 0, 0, 1, filePathSave + "\\DefineInputStream.txt");
                //Output Stream
                conSP.ImportData(dgvStreamOutput_OpC, ValueParameter, 0, 0, 1, filePathSave + "\\DefineOutputStream.txt");
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
                conSP.ImportData(dgvEquipmentSummary, ValueParameter, 0, 0, 1, filePathSave + "\\DefineEquipment.txt");

                btnImport_Stream.BackColor = Color.LightGreen;
                btnImport_Equipment.BackColor = Color.LightGreen;
                btnDefineProduct.BackColor = Color.LightGreen;
                btnDefineStream.BackColor = Color.LightGreen;
                btnDefineEqipment.BackColor = Color.LightGreen;
                pbOne.Visible = false;
                pbTwo.Visible = false;
                pbThree.Visible = false;
                //---------------------------------------
                string firstLine;

                //Capital Cost          
                firstLine = conSP.ImporttxtToDGV_cond(PurchaseEquip, dgvEquipment_CC);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 4)
                {
                    if (ValueParameter[0] == "LCC_default")
                    {
                        rdbECONCapCost.Checked = true;
                        cbbProcessCap.Enabled = true;
                    }
                    else if (ValueParameter[0] == "User_defined")
                    {
                        rdbCustomCapCost.Checked = true;
                        cbbProcessCap.Enabled = false;
                    }
                    cbbProcessCap.Text = ValueParameter[1];
                    con.checkAndaddDataToText(ValueParameter[2], txtTotal_CC);
                    con.checkAndaddDataToText(ValueParameter[3], txtCPI_Index);
                }
                conSP.ImporttxtToDGV(FCI, dgvOnetime_CC);
                conSP.ImporttxtToDGV(WCI, dgvWorkingCapital);
                if (dgvEquipment_CC.ColumnCount != 0 && dgvOnetime_CC.ColumnCount != 0 && dgvWorkingCapital.ColumnCount != 0)
                {
                    btnCapitalCost.BackColor = Color.LightGreen;
                }
                else
                {
                    btnCapitalCost.BackColor = Color.Transparent;
                }

                //---------------------------------------
                //Operating Cost
                firstLine = conSP.ImporttxtToDGV_cond(OPCStream, dgvStreamOPC);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 6)
                {
                    con.checkAndaddDataToText(ValueParameter[0], txtInterestRate);
                    con.checkAndaddDataToText(ValueParameter[1], txtPeriod);
                    con.checkAndaddDataToText(ValueParameter[2], txtNumHour_OpC);
                    if (ValueParameter[3] == "Mixture_Feed")
                    {
                        rdbMixtureFeed.Checked = true;
                    }
                    else
                    {
                        rdbOverallFeed.Checked = true;
                    }
                    con.checkAndaddDataToText(ValueParameter[4], txtOverallFeed);
                    con.checkAndaddDataToText(ValueParameter[5], txtTotal_OPC);
                }
                conSP.ImporttxtToDGV(OPCUtility, dgvEquipmentOPC);
                conSP.ImporttxtToDGV(OPCLaborHour, dgvLaborOPC);
                conSP.ImporttxtToDGV(OPCLaborMonth, dgvLaborMonth);

                con.DataToCenterStyle(dgvStreamOPC);
                con.CellColorWithCond(dgvStreamOPC, 1, "");
                con.CellColorWithCond(dgvStreamOPC, 1, "-");
                con.DataToCenterStyle(dgvEquipmentOPC);
                con.CellColorWithCond(dgvEquipmentOPC, 3, "Double click to select type");
                con.CellColorWithCond(dgvEquipmentOPC, 6, "");
                con.CellColorWithCond(dgvEquipmentOPC, 6, "-");
                con.DataToCenterStyle(dgvLaborOPC);
                con.CellColorWithCond(dgvLaborOPC, 0, "Double click to select type ");
                con.CellColorWithCond(dgvLaborOPC, 1, "");
                con.CellColorWithCond(dgvLaborOPC, 1, "-");
                con.CellColorWithCond(dgvLaborOPC, 3, "");
                con.CellColorWithCond(dgvLaborOPC, 3, "-");
                con.DataToCenterStyle(dgvLaborMonth);
                con.CellColorWithCond(dgvLaborMonth, 0, "Double click to select type ");
                con.CellColorWithCond(dgvLaborMonth, 1, "");
                con.CellColorWithCond(dgvLaborMonth, 1, "-");
                con.CellColorWithCond(dgvLaborMonth, 3, "");
                con.CellColorWithCond(dgvLaborMonth, 3, "-");

                if (dgvStreamOPC.ColumnCount != 0 && dgvEquipmentOPC.ColumnCount != 0 && dgvLaborOPC.ColumnCount != 0 && dgvLaborMonth.ColumnCount != 0)
                {
                    btnOperatingCost.BackColor = Color.LightGreen;
                }
                else
                {
                    btnOperatingCost.BackColor = Color.Transparent;
                }
                btnDone_OPC.Text = "Next";
                //---------------------------------------
                //FeedStock Cost
                firstLine = conSP.ImporttxtToDGV_cond(FeedStock, dgvRawMat_FS);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 1)
                {
                    con.checkAndaddDataToText(ValueParameter[0], txtTotal_FS);
                }
                if (dgvRawMat_FS.ColumnCount != 0)
                {
                    btnFeedstockCost.BackColor = Color.LightGreen;
                }
                else
                {
                    btnFeedstockCost.BackColor = Color.Transparent;
                }
                //Maybe need to revise in the future update
                txtAmount_FS.Text = "1";
                rdbWithTransport.Checked = true;
                //---------------------------------------
                //Maintenance Cost
                firstLine = conSP.ImporttxtToDGV_cond(Maintenance, dgvSpecific_MC);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 4)
                {
                    con.checkAndaddDataToText(ValueParameter[0], txtPreviewCC_MC);
                    con.checkAndaddDataToText(ValueParameter[1], txtPercent_MC);
                    if (ValueParameter[2] == "Percentage")
                    {
                        rdbPercent_MC.Checked = true;
                        gbPercent_MC.Enabled = true;
                        gbSpecific_MC.Enabled = false;
                    }
                    else
                    {
                        rdbSpecific_MC.Checked = true;
                        gbSpecific_MC.Enabled = true;
                        gbPercent_MC.Enabled = false;
                    }
                    con.checkAndaddDataToText(ValueParameter[3], txtTotalMaintenance);
                }
                if (txtTotalMaintenance.BackColor == Color.LightGreen)
                {
                    btnMaintenanceCost.BackColor = Color.LightGreen;
                }
                //---------------------------------------
                //Salvage Cost
                firstLine = conSP.ImporttxtToDGV_cond(Salvage, dgvSalvageValue);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 2)
                {
                    if (ValueParameter[0] == "Percentage")
                    {
                        rdbPercentFirstCost.Checked = true;
                    }
                    else
                    {
                        rdbCustomSV.Checked = true;
                    }
                    con.checkAndaddDataToText(ValueParameter[1], txtTotal_SV);
                }

                if (dgvSalvageValue.ColumnCount > 1)
                {
                    dgvSalvageValue.AutoResizeColumns();
                    dgvSalvageValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvSalvageValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (txtTotal_SV.BackColor == Color.LightGreen)
                {
                    btnSalvageValue.BackColor = Color.LightGreen;
                }

                //---------------------------------------
                //Product credit
                ////Main product Credit
                firstLine = conSP.ImporttxtToDGV_cond(MainProductCredit, dgvMainP);
                conSP.SplitWordToList(ValueParameter, firstLine);
                if (ValueParameter.Count == 1)
                {
                    con.checkAndaddDataToText(ValueParameter[0], txtTotal_PC);
                }

                ////Side product Credit
                conSP.ImporttxtToDGV(SideProductCredit, dgvSideP);

                con.DataToCenterStyle(dgvMainP);
                con.DataToCenterStyle(dgvSideP);

                if (txtTotal_PC.BackColor == Color.LightGreen)
                {
                    btnProductCredit.BackColor = Color.LightGreen;
                }
                //---------------------------------------       
            }
        }
    }
}

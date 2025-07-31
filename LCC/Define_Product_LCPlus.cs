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
using System.Collections;

namespace LCC
{
    public partial class Define_Product_LCPlus : Form
    {
        Function_SaveOpen conSP;
        Function con;       
        string strDirectory = Application.StartupPath + "\\";

        public LCPlus _word;

        double CPI_Index = 0;
        public Define_Product_LCPlus(LCPlus word)
        {
            InitializeComponent();
            conSP = new Function_SaveOpen();
            con = new Function();           
            _word = word;
        }
        List<string> ValueParameter = new List<string>(); //Not releate to any features
        List<string> ComponentName = new List<string>(); //Collect all component in column 0 from stream table preview
        List<string> StreamName = new List<string>(); //Collect all component in all column from stream table preview
        //List for Equipment Table import
        List<string> EquipmentName = new List<string>();
        List<string> EquipmentDuty = new List<string>();
        List<string> EquipmentUnit = new List<string>();

        //List of Duty
        List<string> DutyCategory = new List<string>();

        private void Define_Product_LCPlus_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //Show Stream Location
            string pathStreamFile = strDirectory + "ReadTable\\SteamTable\\dist\\Stream_Table_Location.txt";
            string pathEquipFile = strDirectory + "ReadTable\\EquipmentTable\\dist\\Equipment_Table_Location.txt";
            //Find location path to fill in text box
            string StreamLocation = conSP.ReadFirstLine(pathStreamFile);
            string EquipLocation = conSP.ReadFirstLine(pathEquipFile);

            //Stream preview file
            string dir = strDirectory + "SaveFiles";
            string streampreviewPath = dir + "\\StreamTablePreview.txt";
            string equippreviewPath = dir + "\\EquipmentTablePreview.txt";

            //Show file name in Textbox
            ////Product table
            txtProductFile.Text = StreamLocation;
            txtProductFile.ReadOnly = true;
            ////Stream table
            txtStreamtable.Text = StreamLocation;
            txtStreamtable.ReadOnly = true;
            //Equipment Table
            txtEquipmentFile.Text = EquipLocation;
            txtEquipmentFile.ReadOnly = true;
            //-----------------------------------------------------
            //Import Stream Table Preview
            dgvStreamTablePreview.Rows.Clear();
            dgvStreamTablePreview.Columns.Clear();
            if (File.Exists(streampreviewPath))
            {
                conSP.ImportData(dgvStreamTablePreview, ValueParameter, 0, 0, 1, streampreviewPath);
            }
            //-----------------------------------------------------
            //Import Equipment Table Preview
            dgvEquipmentPreview.Rows.Clear();
            dgvEquipmentPreview.Columns.Clear();
            conSP.ImportData(dgvEquipmentPreview, ValueParameter, 0, 0, 1, equippreviewPath);
            //-----------------------------------------------------
            //List Component Name
            ComponentName.Clear();
            StreamName.Clear();
            con.CollectDataToList(StreamName, ComponentName, dgvStreamTablePreview);
            //-----------------------------------------------------           
            //Define product
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
            //Define stream
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
            //-----------------------------------------------------
            //Define Equipment
            dgvEquipmentSummary.Columns.Clear();
            dgvEquipmentSummary.Rows.Clear();

            DutyCategory.Clear();

            //Add column Name
            string[] EquipmentHeader = { "Equipment Name", "Type of Equipment", "Duty/Work", "Unit", "Sizing", "Sizing Unit", "Material", "Purchase Cost ($)" };
            con.HeaderTable(dgvEquipmentSummary, EquipmentHeader);
            //Add Pump to Table            
            con.CollectEquipDetail(dgvEquipmentPreview, "Pump", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddDataToTable2(dgvEquipmentSummary, "Pump", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Conpressor to Table
            con.CollectEquipDetail(dgvEquipmentPreview, "Compressor", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddDataToTable2(dgvEquipmentSummary, "Compressor", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Reactor to Table
            con.CollectEquipDetail(dgvEquipmentPreview, "ConReactor", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddDataToTable2(dgvEquipmentSummary, "Reactor", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Flash to Table
            con.CollectEquipDetail(dgvEquipmentPreview, "Flash", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddDataToTable2(dgvEquipmentSummary, "Flash", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Heat Exchanger to Table
            con.CollectEquipDetail(dgvEquipmentPreview, "Hx", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddDataToTable2(dgvEquipmentSummary, "Heat Exchanger", EquipmentName, EquipmentDuty, EquipmentUnit);
            //Add Column-Condenser and Column-Reboiler to Table
            con.CollectEquipDetail(dgvEquipmentPreview, "Column", EquipmentName, EquipmentDuty, EquipmentUnit, DutyCategory);
            con.AddColumnFixed2Word(dgvEquipmentSummary, "Column-Reboiler", "Column-Condenser", EquipmentName, EquipmentDuty, EquipmentUnit);
            //CEP Cost index Value
            txtCPI_Index.Text = "521";           
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
            }
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            dgvMainProduct.Rows.Clear();
            dgvSideProduct.Rows.Clear();
        }

        private void btnNextProduct_Click(object sender, EventArgs e)
        {
            if (dgvMainProduct.Rows.Count != 0)
            {
                DefineStreamTab.SelectedIndex = 0;
                tabpage.SelectedIndex = 1;  
            }
            else
            {
                MessageBox.Show("To proceed, please select at least one component within the main product.", "Warning missing component data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabpage_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void Product_Cost_Click(object sender, EventArgs e)
        {

        }

        private void btnAddStreamInput_Click(object sender, EventArgs e)
        {
            dgvStream_OpC.Rows.Add(cbbStreamInput.Text);
        }
        private void btnAddStreamOutput_Click(object sender, EventArgs e)
        {
            dgvStreamOutput_OpC.Rows.Add(cbbStreamOutput.Text);
        }

        private void btnClearStream_Click(object sender, EventArgs e)
        {
            dgvStream_OpC.Rows.Clear();
            dgvStreamOutput_OpC.Rows.Clear();
        }

        private void btnNextStreamTable_Click(object sender, EventArgs e)
        {
            if (dgvStream_OpC.Rows.Count != 0 && dgvStreamOutput_OpC.Rows.Count != 0)
            {
                Eqip_Control.SelectedIndex = 0;
                tabpage.SelectedIndex = 2;
            }
            else if (dgvStream_OpC.Rows.Count == 0 && dgvStreamOutput_OpC.Rows.Count != 0)
            {
                MessageBox.Show("To proceed, please select at least one component for the List of Stream Input.", "Warning missing stream input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dgvStream_OpC.Rows.Count != 0 && dgvStreamOutput_OpC.Rows.Count == 0)
            {
                MessageBox.Show("To proceed, please select at least one component for the List of Stream Output.", "Warning missing stream output", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("To proceed, please select at least one component for both List of Stream Input and List of Stream Output.", "Warning missing both stream input and output", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }              
             
        private void txtCPI_Index_TextChanged(object sender, EventArgs e)
        {
            string message = "The value entered for the CEP cost index must be a number.";
            string titleMessage = "Warning Invalid CEP Cost Index Entry";
            con.checkNumberTB(txtCPI_Index, message, titleMessage);

            //Update CPI index value
            if (txtCPI_Index.BackColor == Color.LightGreen)
            {
                CPI_Index = Convert.ToDouble(txtCPI_Index.Text);
            }
        }        
        
        private void Equipment_Cost_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_DefineEquip_Click(object sender, EventArgs e)
        {
            string txtFileName, LCC_locationPath, Impact_LocationPath;
            string filePath = strDirectory + "SaveFiles";
            string ImpactSavefilePath = strDirectory + "Impact Calculation\\SaveFile";
            string defaultLCC = strDirectory + "DefaultFiles\\LCC";
            //Stram Table Preview
            //conSP.SaveDataTable(dgvStreamTablePreview, filePath + "\\StreamTablePreview.txt");
            //-------------------------------------
            //Eqipment Table Preview
            //conSP.SaveDataTable(dgvEquipmentPreview, filePath + "\\EquipmentTablePreview.txt");
            //-------------------------------------
            //Define product
            //Main Product
            txtFileName = "\\DefineMainProduct.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveDataTable(dgvMainProduct, LCC_locationPath);
            conSP.copyfile(LCC_locationPath, Impact_LocationPath);
            //Side Product
            txtFileName = "\\DefineSideProduct.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveDataTable(dgvSideProduct, LCC_locationPath);
            conSP.copyfile(LCC_locationPath, Impact_LocationPath);
            //-------------------------------------
            //Define Stream
            //Input Stream
            txtFileName = "\\DefineInputStream.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveDataTable(dgvStream_OpC, LCC_locationPath);
            conSP.copyfile(LCC_locationPath, Impact_LocationPath);
            //Output Stream
            txtFileName = "\\DefineOutputStream.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveDataTable(dgvStreamOutput_OpC, LCC_locationPath);
            conSP.copyfile(LCC_locationPath, Impact_LocationPath);
            //-------------------------------------
            //Define Equipment
            txtFileName = "\\DefineEquipment.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveDataTable(dgvEquipmentSummary, LCC_locationPath);
            conSP.copyfile(LCC_locationPath, Impact_LocationPath);

            //Define Duty Category (Save only LCC)
            txtFileName = "\\DefineDutyCategory.txt";
            LCC_locationPath = filePath + txtFileName;
            Impact_LocationPath = ImpactSavefilePath + txtFileName;
            conSP.SaveListTotxt(DutyCategory, LCC_locationPath);
            //-------------------------------------

            //Send LCC default files
            string LCC_Defualt_locationpath;
            string[] LCC_default = { "PurchaseEquipment", "WCI", "FCI", "FeedStockCost", "MaintenanceCost", "OPCStream", "OPCUtility", "OPCLabor_perHour", "OPCLabor_perMonth", "SalvageValue", "MainProductCredit", "SideProductCredit" };
            for (int i = 0; i < LCC_default.Length; i++)
            {
                txtFileName = "\\" + LCC_default[i] + ".txt";
                LCC_Defualt_locationpath = defaultLCC + txtFileName;
                LCC_locationPath = filePath + txtFileName;
                conSP.copyfile(LCC_Defualt_locationpath, LCC_locationPath);
            }

            //Update color button in LCPlus Page
            _word.ChangeDPButton("Yes");
            this.Close();
        }
               
        public void UpdateCost(string sizing, string sizing_unit, string material, string PurchaseCost)
        {
            dgvEquipmentSummary.SelectedRows[0].Cells[4].Value = sizing;
            dgvEquipmentSummary.SelectedRows[0].Cells[5].Value = sizing_unit;
            dgvEquipmentSummary.SelectedRows[0].Cells[6].Value = material;
            dgvEquipmentSummary.SelectedRows[0].Cells[7].Value = PurchaseCost;
        }

        public void UpdateColumnCost(string Colname, string sizing, string sizing_unit, string material, string PurchaseCost)
        {           
            for (int i = 0; i < dgvEquipmentSummary.RowCount; i++)
            {
                string equipName = dgvEquipmentSummary.Rows[i].Cells[0].Value.ToString();
                string equipType = dgvEquipmentSummary.Rows[i].Cells[1].Value.ToString();
                if (equipName == Colname && equipType == "Column-Condenser")
                {
                    //Column-Condenser
                    dgvEquipmentSummary.Rows[i].Cells[4].Value = sizing;
                    dgvEquipmentSummary.Rows[i].Cells[5].Value = sizing_unit;
                    dgvEquipmentSummary.Rows[i].Cells[6].Value = material;
                    dgvEquipmentSummary.Rows[i].Cells[7].Value = PurchaseCost;

                    //Column-Reboiler
                    string NextequipName = dgvEquipmentSummary.Rows[i + 1].Cells[0].Value.ToString();
                    string NetequipType = dgvEquipmentSummary.Rows[i + 1].Cells[1].Value.ToString();
                    if (NextequipName == Colname && NetequipType == "Column-Reboiler")
                    {
                        dgvEquipmentSummary.Rows[i + 1].Cells[4].Value = sizing;
                        dgvEquipmentSummary.Rows[i + 1].Cells[5].Value = sizing_unit;
                        dgvEquipmentSummary.Rows[i + 1].Cells[6].Value = material;
                        dgvEquipmentSummary.Rows[i + 1].Cells[7].Value = "0";
                    }                    
                    break;
                }
                else if (equipName == Colname && equipType == "Column-Reboiler")
                {
                    //Column-Reboiler
                    dgvEquipmentSummary.Rows[i].Cells[4].Value = sizing;
                    dgvEquipmentSummary.Rows[i].Cells[5].Value = sizing_unit;
                    dgvEquipmentSummary.Rows[i].Cells[6].Value = material;
                    dgvEquipmentSummary.Rows[i].Cells[7].Value = PurchaseCost;
                    break;
                }
            }
            
        }

        private void dgvEquipmentSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtCPI_Index.BackColor == Color.LightGreen)
            {
                string wordName = dgvEquipmentSummary.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string wordType = dgvEquipmentSummary.SelectedRows[0].Cells[1].Value.ToString().Trim();
                if (wordType == "Pump")
                {
                    Equipment_Pump Pump_page = new Equipment_Pump(wordName, CPI_Index, this);
                    Pump_page.Show();
                }
                else if (wordType == "Compressor")
                {
                    Equipment_Compressor Comp_page = new Equipment_Compressor(wordName, CPI_Index, this);
                    Comp_page.Show();
                }
                else if (wordType == "Reactor")
                {
                    Equipment_Reactor Reactor_page = new Equipment_Reactor(wordName, CPI_Index, this);
                    Reactor_page.Show();
                }
                else if (wordType == "Flash")
                {
                    Equipment_Flash Flash_page = new Equipment_Flash(wordName, this);
                    Flash_page.Show();
                }
                else if (wordType == "Heat Exchanger")
                {
                    Equipment_HX HX_page = new Equipment_HX(wordName, CPI_Index, this);
                    HX_page.Show();
                }
                else if (wordType == "Column-Reboiler" || wordType == "Column-Condenser")
                {
                    Equipment_Column Column_page = new Equipment_Column(wordName, CPI_Index, this);
                    Column_page.Show();
                }
            }
            else
            {
                string message = "The value entered for the CEP cost index must be a number.";
                string titleMessage = "Warning Invalid CEP Cost Index Entry";
                MessageBox.Show(message, titleMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgvEquipmentSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

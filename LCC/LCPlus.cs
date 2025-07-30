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
using Microsoft.Office.Interop.Excel;


namespace LCC
{
    public partial class LCPlus : Form
    {
        string strDirectory = System.Windows.Forms.Application.StartupPath + "\\";
        string dir = "";
        string filePath = "";
        //Directory of save files
        string filePathSave = System.Windows.Forms.Application.StartupPath + "\\SaveFiles";
        Function_RunEXEandExcel conExe;
        Function_SaveOpen conSP;
        public LCPlus()
        {
            InitializeComponent();
            conExe = new Function_RunEXEandExcel();
            conSP = new Function_SaveOpen();
        }

        private void LCPlus_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //Send Location of LCC Save file folder to impact calculation software
            string SaveFileLocation = strDirectory + "SaveFiles";
            
            string SaveFilePath = strDirectory + "Impact Calculation\\SaveFile\\LCCSaveFilePath\\LCCSaveFilePath.txt";
            if (File.Exists(SaveFilePath))
            {
                File.Delete(SaveFilePath);
            }
            conSP.SaveProjectName_LCPlus(SaveFileLocation, SaveFilePath);

            //Create new Project name file as default
            string filePathLCC = strDirectory + "SaveFiles";
            string filePathImpact = strDirectory + "Impact Calculation\\SaveFile";
            conSP.SaveProjectName_LCPlus("", filePathLCC + "\\Project_Name.txt");
            conSP.SaveProjectName_LCPlus("", filePathImpact + "\\Project_Name.txt");


            //Send LCC default to Save files
            string defaultLCC = strDirectory + "DefaultFiles\\LCC";
            string[] LCC_default = { "PurchaseEquipment", "WCI", "FCI", "FeedStockCost", "MaintenanceCost", "OPCStream", "OPCUtility", "OPCLabor_perHour", "OPCLabor_perMonth", "SalvageValue", "MainProductCredit", "SideProductCredit" };
            for (int i = 0; i < LCC_default.Length; i++)
            {
                string txtFileName = "\\" + LCC_default[i] + ".txt";
                string LCC_Defualt_locationpath = defaultLCC + txtFileName;
                string LCC_locationPath = filePathSave + txtFileName;
                conSP.copyfile(LCC_Defualt_locationpath, LCC_locationPath);
            }
        }

        private void btnLCC_Click(object sender, EventArgs e)
        {
            if (btnDefineProcess.BackColor == Color.LightGreen)
            {
                Form1 page = new Form1();
                page.Show();
                btnLCC.BackColor = Color.LightGreen;
            }
            else
            {
                MessageBox.Show("Please ensure that the define process and product has been completed.", "Warning defind process and product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            /*//for testing
            Form1 page = new Form1();
            page.Show();
            btnLCC.BackColor = Color.LightGreen;*/
        }

        private void btnLCSoft_Click(object sender, EventArgs e)
        {                  
            MessageBox.Show("This feature is currently under development and will be included in the upcoming release", "Upcoming Feature Development and Release", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportStream_Click(object sender, EventArgs e)
        {
            dir = strDirectory + "ReadTable\\SteamTable\\dist";
            filePath = dir + "\\ReadSteamTable.exe";
            string filetxt = dir + "\\Stream_Table_file.txt";
            conExe.RunExE(dir, filePath);

            if (File.Exists(filetxt))
            {
                string stream_preview = strDirectory + "SaveFiles\\StreamTablePreview.txt";
                string stream_preview_impact = strDirectory + "Impact Calculation\\SaveFile\\StreamTablePreview.txt";
                if (conExe.checkWordtxt(filetxt, "Stream Name"))
                {
                    conSP.ConvertStreamToPreview(filetxt, stream_preview);
                    //Delete exist file and copy new file to impact calculation
                    conSP.copyfile(stream_preview, stream_preview_impact);
                    
                    //Change color button
                    btnImportStream.BackColor = Color.LightGreen;
                    btnExternal_convert.BackColor = Color.LightGreen;
                }
            }                 
        }

        private void btnImportEquip_Click(object sender, EventArgs e)
        {
            dir = strDirectory + "ReadTable\\EquipmentTable\\dist";
            filePath = dir + "\\ReadEquipmentTable.exe";
            string filetxt = dir + "\\Equipment_Table_file.txt";
            conExe.RunExE(dir, filePath);

            //Revise data for impact calculation software
            string reviseExepath = dir + "\\ReviseTableToImpact.exe";
            if (conExe.checkWordtxt(filetxt, "Unit Operation Summary"))
            {
                conExe.RunExE(dir, reviseExepath);
                string equip_preview = dir + "\\EquipmentTablePreview.txt";
                string equip_preview_LCC = strDirectory + "\\SaveFiles\\EquipmentTablePreview.txt";
                string equip_preview_impact = strDirectory + "Impact Calculation\\SaveFile\\EquipmentTablePreview.txt";
                //Delete exist file and send new file to impact calculation
                conSP.copyfile(equip_preview, equip_preview_impact);

                //Delete exist file and send new file to LCC
                conSP.copyfile(equip_preview, equip_preview_LCC);

                //Change button color
                btnImportEquip.BackColor = Color.LightGreen;
            }
        }        
        public void ChangePJNameButton (string status)
        {
            if (status == "Yes")
            {
                btnProject.BackColor = Color.LightGreen;
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
           Project_Define_Name Project_page = new Project_Define_Name(this);
           Project_page.Show();            
        }
        public void ChangeDPButton (string data)
        {
            if (data == "Yes")
            {
                btnDefineProcess.BackColor = Color.LightGreen;
            }
        }

        private void btnDefineProcess_Click(object sender, EventArgs e)
        {
            if (btnImportStream.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Please ensure that the stream table has been imported.", "Warning Import Stream Table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnImportEquip.BackColor != Color.LightGreen)
                {
                    MessageBox.Show("Please ensure that the equipment table has been imported.", "Warning Import Equipment Table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Define_Product_LCPlus Process_page = new Define_Product_LCPlus(this);
                    Process_page.Show();
                }
            }                           
        }

        private void btnFootprint_Click(object sender, EventArgs e)
        {
            if (btnDefineProcess.BackColor == Color.LightGreen)
            {
                string dir = strDirectory + "Impact Calculation";
                string filePath = dir + "\\Impact_ProCAFD.exe";
                conExe.RunExE(dir, filePath);
                btnFootprint.BackColor = Color.LightGreen;
            }
            else
            {
                MessageBox.Show("Please ensure that the define process and product has been completed.", "Warning defind process and product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnExternal_convert_Click(object sender, EventArgs e)
        {
            dir = strDirectory + "External Converter";
            filePath = dir + "\\ExternalConverter.exe";         
            conExe.RunExE(dir, filePath);
            btnExternal_convert.BackColor = Color.LightGreen;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {                     
            //Change color of buttons
            if (conSP.OpenAllSavefiles())
            {
                btnProject.BackColor = Color.LightGreen;
                btnExternal_convert.BackColor = Color.LightGreen;
                btnImportStream.BackColor = Color.LightGreen;
                btnImportEquip.BackColor = Color.LightGreen;
                btnDefineProcess.BackColor = Color.LightGreen;
                btnLCC.BackColor = Color.LightGreen;
                btnFootprint.BackColor = Color.LightGreen;
            }            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnProject.BackColor == Color.LightGreen)
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
                MessageBox.Show("Please define the project name first before proceeding this step", "Missing project name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
    }
}

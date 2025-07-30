using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LCC
{
    public partial class Project_Define_Name : Form
    {
        Function_SaveOpen conSP;
        string strDirectory = Application.StartupPath + "\\";

        public LCPlus _word;
        
        public Project_Define_Name(LCPlus word)
        {
            InitializeComponent();
            conSP = new Function_SaveOpen();       
            _word = word;
        }

        private void lblProjectNameTopic_Click(object sender, EventArgs e)
        {

        }

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
                        btnDefinePJName.BackColor = Color.LightGreen;
                        btnEditPJName.BackColor = Color.LightBlue;
                        txtProjectName.ReadOnly = true;                                            
                    }
                }
                if (CheckWord)
                {
                    string filePathLCC = strDirectory + "SaveFiles";
                    string filePathImpact = strDirectory + "Impact Calculation\\SaveFile";
                    conSP.SaveProjectName_LCPlus(txtProjectName.Text, filePathLCC + "\\Project_Name.txt");
                    conSP.SaveProjectName_LCPlus(txtProjectName.Text, filePathImpact + "\\Project_Name.txt");
                    _word.ChangePJNameButton("Yes");
                    this.Close();                  
                }     
            }
            else
            {
                MessageBox.Show("The project name field cannot be blank.", "Warning Project Name Blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditPJName_Click(object sender, EventArgs e)
        {
            txtProjectName.Text = "";
            btnDefinePJName.BackColor = Color.Transparent;
            btnEditPJName.BackColor = Color.Transparent;
            txtProjectName.ReadOnly = false;
        }

        private void Project_Define_Name_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            
            string filePathLCC = strDirectory + "SaveFiles";

            txtProjectName.Text = conSP.ReadFirstLine(filePathLCC + "\\Project_Name.txt").Trim();
            if (txtProjectName.Text != "")
            {
                btnDefinePJName.BackColor = Color.LightGreen;
                btnEditPJName.BackColor = Color.LightBlue;
                txtProjectName.ReadOnly = true;
            }
            else
            {
                txtProjectName.Text = "";
                btnDefinePJName.BackColor = Color.Transparent;
                btnEditPJName.BackColor = Color.Transparent;
                txtProjectName.ReadOnly = false;
            }             
        }
    }
}

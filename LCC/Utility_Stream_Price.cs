using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace LCC
{
    public partial class Utility_Stream_Price: Form
    {
        string compNameMain;
        string priceValMain;

        Form1 _word;

        Function con;
        public Utility_Stream_Price(string compName, string priceVal, Form1 word)
        {
            InitializeComponent();
            compNameMain = compName;
            priceValMain = priceVal;
            _word = word;

            con = new Function();
        }

        private void Utility_Stream_Price_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //Show component name
            txtCompName.Text = compNameMain;

            //Show price value
            if (priceValMain != "")
            {
                txtPrice.BackColor = Color.LightGreen;
            }
            txtPrice.Text = priceValMain;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Edit Component Price page, a feature within the Life Cycle Cost (LCC) section of the software, " +
                "allows users to modify component prices.\n\nThese adjustments are applied to the table upon clicking the Update button.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            string message = "The value entered for the price must be a number.";
            string titleMessage = "Warning Invalid Price Value";
            con.checkNumberTB(txtPrice, message, titleMessage);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPrice.BackColor == Color.LightGreen)
            {
                _word.UpdateCompPrice(txtPrice.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Missing price value.\n\nPlease ensure you add the price value correctly, and then try again.", "Warning incorrect price value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

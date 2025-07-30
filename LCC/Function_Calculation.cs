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
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LCC
{
    class Function_Calculation
    {
        public string PurchaseCost(double alpha, double beta, double sizing, double af, double Current_CPI)
        {
            double BaseCost, PurchaseCost;
            BaseCost = alpha * Math.Pow(sizing, beta);
            PurchaseCost = Math.Round((BaseCost * af * (Current_CPI / 390.4)), 2);
            return PurchaseCost.ToString("#,##0.##");
        }
        public string PurchaseCost_SecondMethod(double a, double b, double c, double d, double e, double f, double Second_C, double sizing, double af, double Current_CPI)
        {
            double BaseCost, PurchaseCost;
            BaseCost = (a * Math.Pow(sizing, 6)) + (b * Math.Pow(sizing, 5)) + (c * Math.Pow(sizing, 4)) + (d * Math.Pow(sizing, 3)) + (e * Math.Pow(sizing, 2)) + (f * sizing) + Second_C;
            PurchaseCost = Math.Round((BaseCost * af * (Current_CPI / 390.4)), 2);
            return PurchaseCost.ToString("#,##0.##");          
        }
        public string PurchaseCost_CoolingTower(double alpha, double beta, double sizing, double af, double Current_CPI)
        {
            double BaseCost, PurchaseCost;
            BaseCost = (sizing * alpha) + beta;
            PurchaseCost = Math.Round((BaseCost * af * (Current_CPI / 390.4)), 2);
            return PurchaseCost.ToString("#,##0.##");
        }
        public double ConvertPower_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {
            double sizing;                    
            if (Unit == "kW")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }               
            }
            else if (Unit == "HP")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.7457)
                {
                    sizing = lowest_Val * 0.7457;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.7457)
                {
                    sizing = highest_Val * 0.7457;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.7457;
                }               
            }
            else
            {
                sizing = 0;
            }
            return sizing;
        }
        public double ConvertDuty_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {
            double sizing;
            if (Unit == "kW")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "MJ/hr")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.277777778)
                {
                    sizing = lowest_Val * 0.277777778;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.277777778)
                {
                    sizing = highest_Val * 0.277777778;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.277777778;
                }
            }
            else if (Unit == "BTU/s")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 1.05506)
                {
                    sizing = lowest_Val * 1.05506;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 1.05506)
                {
                    sizing = highest_Val * 1.05506;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 1.05506;
                }
            }
            else
            {
                sizing = 0;
            }
            return sizing;          
        }
        public double ConvertCapacity_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {

            double sizing;
            if (Unit == "cubic meter (m3)")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "Liters (L)")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.001)
                {
                    sizing = lowest_Val * 0.001;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.001)
                {
                    sizing = highest_Val * 0.001;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.001;
                }
            }
            else if (Unit == "cubic feet (feet3)")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.0283168466)
                {
                    sizing = lowest_Val * 0.0283168466;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.0283168466)
                {
                    sizing = highest_Val * 0.0283168466;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.0283168466;
                }
            }
            else if (Unit == "gallon")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.00378541178)
                {
                    sizing = lowest_Val * 0.00378541178;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.00378541178)
                {
                    sizing = highest_Val * 0.00378541178;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.00378541178;
                }
            }
            else
            {
                sizing = 0;
            }
            return sizing;
        }
        public double ConvertCapacityFlow_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {

            double sizing;
            if (Unit == "cubic meter (m3)/s")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "cubic meter (m3)/hr")
            {
                if (Convert.ToDouble(Value) < lowest_Val / 3600)
                {
                    sizing = lowest_Val / 3600;
                }
                else if (Convert.ToDouble(Value) > highest_Val / 3600)
                {
                    sizing = highest_Val / 3600;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) / 3600;
                }
            }
            else if (Unit == "gallon/s")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.003785)
                {
                    sizing = lowest_Val * 0.003785;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.003785)
                {
                    sizing = highest_Val * 0.003785;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.003785;
                }
            }
            else if (Unit == "cubic feet (feet3)/s")
            {
                if (Convert.ToDouble(Value) < lowest_Val * 0.0283168466)
                {
                    sizing = lowest_Val * 0.0283168466;
                }
                else if (Convert.ToDouble(Value) > highest_Val * 0.0283168466)
                {
                    sizing = highest_Val * 0.0283168466;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * 0.0283168466;
                }
            }
            else
            {
                sizing = 0;
            }
            return sizing;
        }
        public double ConvertArea_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {

            double sizing;
            if (Unit == "sq.meter")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "sq.feet")
            {
                if (Convert.ToDouble(Value) < lowest_Val / 10.764)
                {
                    sizing = lowest_Val / 10.764;
                }
                else if (Convert.ToDouble(Value) > highest_Val / 10.764)
                {
                    sizing = highest_Val / 10.764;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) / 10.764;
                }
            }
            else if (Unit == "sq.inch")
            {
                if (Convert.ToDouble(Value) < lowest_Val / 1550)
                {
                    sizing = lowest_Val * 0.003785;
                }
                else if (Convert.ToDouble(Value) > highest_Val / 1550)
                {
                    sizing = highest_Val / 1550;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) / 1550;
                }
            }           
            else
            {
                sizing = 0;
            }
            return sizing;
        }
        public double ConvertvolumePressure_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {
            double sizing;
            
            if (Unit == "cubic meter (m3)/s * kPa")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "gpm * psi")
            {
                double convertfactor = (0.00006309019640343866 / 6.89476);
                if (Convert.ToDouble(Value) < lowest_Val * convertfactor)
                {
                    sizing = lowest_Val * convertfactor;
                }
                else if (Convert.ToDouble(Value) > highest_Val * convertfactor)
                {
                    sizing = highest_Val * convertfactor;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * convertfactor;
                }
            }
            else
            {
                sizing = 0;
            }
            return sizing;
        }
        public double ConvertHeight_Unit(string Unit, string Value, double lowest_Val, double highest_Val)
        {
            double sizing;

            if (Unit == "meters")
            {
                if (Convert.ToDouble(Value) < lowest_Val)
                {
                    sizing = lowest_Val;
                }
                else if (Convert.ToDouble(Value) > highest_Val)
                {
                    sizing = highest_Val;
                }
                else
                {
                    sizing = Convert.ToDouble(Value);
                }
            }
            else if (Unit == "feet")
            {
                double convertfactor = 0.3048;
                if (Convert.ToDouble(Value) < lowest_Val * convertfactor)
                {
                    sizing = lowest_Val * convertfactor;
                }
                else if (Convert.ToDouble(Value) > highest_Val * convertfactor)
                {
                    sizing = highest_Val * convertfactor;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * convertfactor;
                }
            }
            else if (Unit == "inches")
            {
                double convertfactor = 0.0254;
                if (Convert.ToDouble(Value) < lowest_Val * convertfactor)
                {
                    sizing = lowest_Val * convertfactor;
                }
                else if (Convert.ToDouble(Value) > highest_Val * convertfactor)
                {
                    sizing = highest_Val * convertfactor;
                }
                else
                {
                    sizing = Convert.ToDouble(Value) * convertfactor;
                }
            }
            else
            {
                sizing = 0;
            }
            return sizing;
        }      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Delta_V1._1.Users_Controls
{
    public partial class UC_FACTURE : UserControl
    {
        public UC_FACTURE()
        {
            InitializeComponent();
        }

        private void UC_FACTURE_Load(object sender, EventArgs e)
        {
           
        }

        private void ModeFactureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ModeFactureCheckBox.Checked == true)
            {
                TOTALLabelUSD.Visible = false;
                TVALabelUSD.Visible = false;
                NetLabelUSD.Visible = false;

                TotalUSD.Visible = false;
                TVAUSD.Visible = false;
                NetUSD.Visible = false;

                TOTALLabelCDF.Visible = true;
                TVALabelCDF.Visible = true;
                NETLabelCDF.Visible = true;

                TotalCDF.Visible = true;
                TVACDF.Visible = true;
                NetCDF.Visible = true;
            }
            else
            {
                TOTALLabelUSD.Visible = true;
                TVALabelUSD.Visible = true;
                NetLabelUSD.Visible = true;

                TotalUSD.Visible = true;
                TVAUSD.Visible = true;
                NetUSD.Visible = true;

                TOTALLabelCDF.Visible = false;
                TVALabelCDF.Visible = false;
                NETLabelCDF.Visible = false;

                TotalCDF.Visible = false;
                TVACDF.Visible = false;
                NetCDF.Visible = false;
            }
        }


       
    }
}

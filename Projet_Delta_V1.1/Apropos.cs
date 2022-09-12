using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Delta_V1._1
{
    public partial class Apropos : Form
    {
        public Apropos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Licence d'utilisation de l'application 
        private void Apropos_Load(object sender, EventArgs e)
        {
            LicenceLabel.Text = "Licence d'Utilisation accordée à : " + Environment.UserName;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/");
        }

        private void label20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bndmobetisoft.com/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bndmobetisoft.com/");
        }

        
    }
}

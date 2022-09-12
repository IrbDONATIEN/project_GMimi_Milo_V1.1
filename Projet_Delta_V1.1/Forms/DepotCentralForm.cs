using Projet_Delta_V1._1.Users_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Projet_Delta_V1._1.Classes;
using System.IO;

namespace Projet_Delta_V1._1.Forms
{
    public partial class DepotCentralForm : Form
    {
        int PanelWidth;
        bool isCollapsed;
        bool isCollapsed1;
        bool isCollapsed2;
        MY_DB db = new MY_DB();
        public DepotCentralForm()
        {
            InitializeComponent();
            timer2.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            moveSidePanel(btnDashboard);
            UC_Dashboard Dash = new UC_Dashboard();
            addControls(Dash);
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void DepotCentralForm_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();

            this.KeyPreview = true;
            timer1.Start();
        }

        //La création d'une fonction pour afficher Login et image de l'utilisateur connecté
        public void getImageAndLoginAd()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT u.*, etab.nomEtab as Etablissement, etab.pictures,etab.idCodeEtab FROM utilisateur u INNER JOIN etablissement etab ON etab.codeEtab=u.etablissement WHERE etab.etatEtab=true AND etatCompte=true AND u.id=@uid", db.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = GlobalsAdmin.GlobalUserAdId;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //Affichage de l'image de l'utilisateur en cours
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxAdmin.Image = Image.FromStream(picture);

                //Affichage LOGIN de l'utilisateur connecté
                labelLoginAd.Text = "Retour Bienvenue (" + table.Rows[0]["loginUtilisateur"] + ") ";
                labelCompteAd.Text = Convert.ToString(table.Rows[0][5]);
                labelEtablissementAd.Text = Convert.ToString(table.Rows[0][10]);
                NomEtablissementLabel.Text = Convert.ToString(table.Rows[0][15]);
                IDCodeLabelAd.Text = Convert.ToString(table.Rows[0]["idCodeEtab"]);

                //Affichage de logo de l'etablissement de l'utilisateur en cours
                byte[] pict = (byte[])table.Rows[0]["pictures"];
                MemoryStream pictures = new MemoryStream(pict);
                pictureBoxEtab.Image = Image.FromStream(pictures);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            heureLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void timerDropdown1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                panelDropDown1.Height += 10;
                if (panelDropDown1.Size == panelDropDown1.MaximumSize)
                {
                    timerDropdown1.Stop();
                    isCollapsed1 = false;
                }
            }
            else
            {
                panelDropDown1.Height -= 10;
                if (panelDropDown1.Size == panelDropDown1.MinimumSize)
                {
                    timerDropdown1.Stop();
                    isCollapsed1 = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerDropdown1.Start();
        }

        private void timerDropDow2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                panelDropDown2.Height += 10;
                if (panelDropDown2.Size == panelDropDown2.MaximumSize)
                {
                    timerDropDow2.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                panelDropDown2.Height -= 10;
                if (panelDropDown2.Size == panelDropDown2.MinimumSize)
                {
                    timerDropDow2.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void btnTransactionCommerciale_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnTransactionCommerciale);
            timerDropDow2.Start();
        }

        private void DepotCentralForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control==true && e.KeyCode==Keys.S)
            {
                btnTransactionCommerciale.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.Q)
            {
                btnParametres.PerformClick();
            }
        }

        private void DepotCentralForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int userAd = Convert.ToInt32(GlobalsAdmin.GlobalUserAdId);

            string heureActuelle = Convert.ToString(DateTime.Now.ToLongTimeString());

            using (MySqlCommand command = new MySqlCommand("UPDATE utilisateur, etablissement SET utilisateur.logged=@heure, utilisateur.AsConnected=0,etablissement.connected=0 WHERE etablissement.codeEtab=@idCode AND `id`=@uid", db.getConnection))
            {
                command.Parameters.Add("@heure", MySqlDbType.VarChar).Value = heureActuelle;
                command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userAd;
                command.Parameters.Add("@idCode", MySqlDbType.VarChar).Value = Convert.ToString(IDCodeLabelAd.Text);
                db.openConnection();
                command.ExecuteNonQuery();
            }
            db.closeConnection();

            Application.Exit();
        }

        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnPointVenteActive_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPointVenteActive);
            UC_PointVenteActive PventeActive = new UC_PointVenteActive();
            addControls(PventeActive);
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnParametres);
            timerDropdown1.Start();
        }

        private void btnPointVenteDesactive_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPointVenteDesactive);
            UC_PointVenteDesactive PventeDesActive = new UC_PointVenteDesactive();
            addControls(PventeDesActive);
        }

        private void btnPointVenteEnCours_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPointVenteEnCours);
            UC_PointVenteEnCours PventeEncours = new UC_PointVenteEnCours();
            addControls(PventeEncours);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDashboard);
            UC_Dashboard Dash = new UC_Dashboard();
            addControls(Dash);
        }

        private void btnUtilisateurActive_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUtilisateurActive);
            UC_UserActivate userA = new UC_UserActivate();
            addControls(userA);
        }

        private void btnUtilisateurDesactive_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUtilisateurDesactive);
            UC_UserDesactivate userD = new UC_UserDesactivate();
            addControls(userD);
        }

        private void btnUtilisateurEncours_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUtilisateurEncours);
            UC_UserEnCours userE = new UC_UserEnCours();
            addControls(userE);
        }

        private void btnBCommande_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBCommande);
            UC_ListCmde bcom = new UC_ListCmde();
            addControls(bcom);
        }

        private void btnBEntree_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBEntree);
            UC_ListEntree bE = new UC_ListEntree();
            addControls(bE);
        }

        private void btnBSortie_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBSortie);
            UC_ListSortie bS = new UC_ListSortie();
            addControls(bS);
        }

      

       
    }
}

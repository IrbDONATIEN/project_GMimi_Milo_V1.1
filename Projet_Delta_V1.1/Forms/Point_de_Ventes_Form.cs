using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Projet_Delta_V1._1.Classes;
using System.IO;
using Projet_Delta_V1._1.Users_Controls;

namespace Projet_Delta_V1._1.Forms
{
    public partial class Point_de_Ventes_Form : Form
    {
        int PanelWidth;
        bool isCollapsed;

        public Point_de_Ventes_Form()
        {
            
            InitializeComponent();
            timer2.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            moveSidePanel(btnDashboard);
            UC_FACTURE Dash = new UC_FACTURE();
            addControls(Dash);
        }

        MY_DB db = new MY_DB();
        private void Point_de_Ventes_Form_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginPV();

            //Fonction d'Affichage du menu deroulant 
            int param=0;
            parame(param);
            
            //Fonction de Modification de mot de passe au demarrage
            int mod = 1;
            modifierMotdePasse(mod);
        }

        private bool modifierMotdePasse(int mod)
        {
            bool MotdePasse = false;
            int user = Convert.ToInt32(Globals.GlobalUserId);
            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE `modifpassword`=@mod AND id=@uid", db.getConnection);
            db.openConnection();
            command.Parameters.Add("@mod", MySqlDbType.Int32).Value = mod;
            command.Parameters.Add("@uid",MySqlDbType.Int32).Value=user;
            DataTable table = new DataTable();
            MySqlDataReader lire = command.ExecuteReader();
            table.Load(lire);

            if (table.Rows.Count > 0)
            {
                MotdePasse = true;

                Form formBackgroud = new Form();

                try
                {
                    using (ModifPassAuDemarrageForm ad = new ModifPassAuDemarrageForm())
                    {
                        formBackgroud.StartPosition = FormStartPosition.Manual;
                        formBackgroud.FormBorderStyle = FormBorderStyle.None;
                        formBackgroud.Opacity = .70d;
                        formBackgroud.BackColor = Color.Black;
                        formBackgroud.WindowState = FormWindowState.Maximized;
                        formBackgroud.TopMost = true;
                        formBackgroud.Location = this.Location;
                        formBackgroud.ShowInTaskbar = false;
                        formBackgroud.Show();

                        ad.Owner = formBackgroud;
                        ad.ShowDialog();

                        formBackgroud.Dispose();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    formBackgroud.Dispose();
                }
            }
            return MotdePasse;
        }

        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        public void getImageAndLoginPV()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT u.*, etab.nomEtab as Etablissement, etab.pictures,etab.idCodeEtab FROM utilisateur u INNER JOIN etablissement etab ON etab.codeEtab=u.etablissement WHERE etab.etatEtab=true AND etatCompte=true AND u.id=@uid", db.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //Affichage de l'image de l'utilisateur en cours
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxPV.Image = Image.FromStream(picture);

                //Affichage LOGIN de l'utilisateur connecté
                labelLoginPV.Text = "Retour Bienvenue (" + table.Rows[0]["loginUtilisateur"] + ") ";
                labelComptePV.Text = Convert.ToString(table.Rows[0][5]);
                labelEtablissementPV.Text = Convert.ToString(table.Rows[0][10]);
                NomEtablissementLabelPV.Text = Convert.ToString(table.Rows[0][15]);
                IDCodeLabelPV.Text = Convert.ToString(table.Rows[0]["idCodeEtab"]);
                labelLogin.Text = Convert.ToString(table.Rows[0]["loginUtilisateur"]);

                //Affichage de logo de l'etablissement de l'utilisateur en cours
                byte[] pict = (byte[])table.Rows[0]["pictures"];
                MemoryStream pictures = new MemoryStream(pict);
                pictureBoxEtab.Image = Image.FromStream(pictures);
            }
        }

        private void Point_de_Ventes_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

            int user = Convert.ToInt32(Globals.GlobalUserId);

            string heureActuelle = Convert.ToString(DateTime.Now.ToLongTimeString());

            using (MySqlCommand command = new MySqlCommand("UPDATE `utilisateur`, `etablissement` SET utilisateur.logged=@heure, utilisateur.AsConnected=0,etablissement.connected=0 WHERE etablissement.codeEtab=@code AND utilisateur.loginUtilisateur=@lgn AND utilisateur.id=@uid", db.getConnection))
            {
                command.Parameters.Add("@heure", MySqlDbType.VarChar).Value = heureActuelle;
                command.Parameters.Add("@uid", MySqlDbType.Int32).Value = user;
                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = Convert.ToString(labelEtablissementPV.Text);
                command.Parameters.Add("@lgn",MySqlDbType.VarChar).Value = Convert.ToString(labelLogin.Text);
                db.openConnection();
                command.ExecuteNonQuery();
            }
            db.closeConnection();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            heureLabelPV.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDashboard);
            UC_FACTURE Dash = new UC_FACTURE();
            addControls(Dash);
        }

        private void btnListFacture_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnListFacture);
            UC_ListeFacture ListFacture = new UC_ListeFacture();
            addControls(ListFacture);
        }

        private void btnLigneFacture_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnLigneFacture);
            UC_LigneFacture ListFacture = new UC_LigneFacture();
            addControls(ListFacture);
        }

        private void btnListTransfert_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnListTransfert);
            UC_ListeTransfert ListeTransFert = new UC_ListeTransfert();
            addControls(ListeTransFert);
        }

        private void btnStockEnCours_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStockEnCours);
            UC_StockEnCours StockEnCours = new UC_StockEnCours();
            addControls(StockEnCours);
        }

        private void btnRapportSelection_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnRapportSelection);
            UC_RapportSelection RapportSelection = new UC_RapportSelection();
            addControls(RapportSelection);
        }

        private void btnEntreeStock_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnEntreeStock);
            UC_EntreeStock EntreeStock = new UC_EntreeStock();
            addControls(EntreeStock);
        }

        private void btnBonCommande_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBonCommande);
            UC_BonCommande BonCommande = new UC_BonCommande();
            addControls(BonCommande);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private bool parame(int param)
        {
            bool Existe = false;
            MySqlCommand command = new MySqlCommand("SELECT `param` FROM `parametres` WHERE `param`=@param", db.getConnection);
            db.openConnection();
            command.Parameters.Add("@param",MySqlDbType.Int32).Value = param;
            DataTable table = new DataTable();
            MySqlDataReader lire = command.ExecuteReader();
            table.Load(lire);

            if (table.Rows.Count >0)
            {
                Existe = false;
                panelLeft.Visible = false;
                button2.Visible = false;
                aToolStripMenuItem.Enabled =true ;
                désactiverMenuDéroulantToolStripMenuItem.Enabled = false;
            }
            else
            {
                Existe = true;
                panelLeft.Visible = true;
                button2.Visible = true;
                aToolStripMenuItem.Enabled = false;
                désactiverMenuDéroulantToolStripMenuItem.Enabled = true;
            }
            return Existe;
        }

        private void désactiverMenuDéroulantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir désactivé le Menu Déroulant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    desactiverMenuDeroulant();
                    MessageBox.Show("Menu Déroulant désactivé!");
                    this.OnLoad(e);
                    //Point_de_Ventes_Form_Load(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord !");
            }
        }

        private void desactiverMenuDeroulant()
        {
            MySqlCommand command = new MySqlCommand("UPDATE `parametres` SET `param`=@param", db.getConnection);
            command.Parameters.Add("@param", MySqlDbType.Int32).Value = Convert.ToInt32(0);
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }
            else
            {
                db.closeConnection();
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir activé le Menu Déroulant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    ActiverMenuDeroulant();
                    MessageBox.Show("Menu Déroulant activé!");
                    this.OnLoad(e);
                    //Point_de_Ventes_Form_Load(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord !");
            }
        }

        private void ActiverMenuDeroulant()
        {
            MySqlCommand command = new MySqlCommand("UPDATE `parametres` SET `param`=@param", db.getConnection);
            command.Parameters.Add("@param", MySqlDbType.Int32).Value = Convert.ToInt32(1);
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }
            else
            {
                db.closeConnection();
            }
        }

        private void aperçuAvantImpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
 
       
    }
}

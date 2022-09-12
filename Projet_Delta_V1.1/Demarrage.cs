using Projet_Delta_V1._1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Projet_Delta_V1._1.Classes;

namespace Projet_Delta_V1._1
{
    public partial class Demarrage : Form
    {
        int attempt = 1;
        MY_DB db = new MY_DB();
        public Demarrage()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new Loading());
        }
        private void Demarrage_Load(object sender, EventArgs e)
        {
               //Load
               textBoxLogin.Focus();

               //Chargement des établissement à l'exception de l'etablissement connecté
               IDcodeComboBox.DataSource = getEtablissement();
               IDcodeComboBox.DisplayMember = "Etablissement";
               IDcodeComboBox.ValueMember = "idCode";

               IDcodeComboBox.SelectedItem = null;

               textBoxLogin.Select();

               //Fonction d'Affichage du menu deroulant 
               int param = 1;
               paramEtab(param);
        }

        private bool paramEtab(int param)
        {
            bool Existe = false;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `supp` WHERE `no`=@param", db.getConnection);
            db.openConnection();
            command.Parameters.Add("@param", MySqlDbType.Int32).Value = param;
            DataTable table = new DataTable();
            MySqlDataReader lire = command.ExecuteReader();
            table.Load(lire);

            if (table.Rows.Count > 0)
            {
                Existe = false;
                button4.Visible = false;
            }
            else
            {
                Existe = true;
                button4.Visible = true;
            }
            return Existe;
        }
        
        public DataTable getEtablissement()
        {
            db.closeConnection();

            MySqlCommand command = new MySqlCommand("SELECT utilisateur.idCode, etablissement.nomEtab as Etablissement FROM `utilisateur` INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE etablissement.etatEtab=1 AND utilisateur.etablissement=idCode GROUP BY(idCode)", db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void typeUtilisateurComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formBackgroud = new Form();
            try
            {
                using (Apropos uu = new Apropos())
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

                    uu.Owner = formBackgroud;
                    uu.ShowDialog();

                    formBackgroud.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                formBackgroud.Dispose();
            }
        }

        //Bouton Se connecter à l'application
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if(typeUtilisateurComboBox.SelectedItem.ToString()=="Utilisateur")
            {
                if (attempt < 4)
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE idCode=@idCode AND etablissement.etatEtab=true AND BINARY(`loginUtilisateur`)=@lgn AND BINARY(`passUtilisateur`)=MD5(@pass) AND `typeUtilisateur`=@typeUt AND `etatCompte`=true", db.getConnection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter();

                        DataTable table = new DataTable();

                        command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = textBoxLogin.Text.Trim();
                        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text.Trim();
                        command.Parameters.Add("@typeUt", MySqlDbType.VarChar).Value = typeUtilisateurComboBox.SelectedItem;
                        command.Parameters.Add("@idCode", MySqlDbType.VarChar).Value = IDcodeComboBox.SelectedValue;
                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        //Vérification si les champs sont vide
                        if (verifChamps("login"))
                        {

                            if (table.Rows.Count > 0)
                            {
                                //une variable vue partout dans le programme même dans d'autres formulaires
                                int userid = Convert.ToInt32(table.Rows[0][0].ToString());
                                Globals.SetGlobalUserId(userid);

                                MessageBox.Show("Votre connexion reussie !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Affichage du formulaire principal de l'application
                                this.Hide();
                                Point_de_Ventes_Form pointvente = new Point_de_Ventes_Form();
                                pointvente.Show();
                            }
                            else
                            {
                                //Affichage du message d'erreur
                                MessageBox.Show("Login, Mot de passe, Etablissement et Type utilisateur est invalide, veuillez essayez encore une autre tentative : " + attempt, "Erreur Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            //Affichage du message d'erreur
                            MessageBox.Show("Champs Login, Mot de passe, Etablissement et Type utilisateur est vide, veuillez essayez encore une autre tentative :" + attempt, "Erreur Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    int user = Convert.ToInt32(Globals.GlobalUserId);

                    string heureActuelle = Convert.ToString(DateTime.Now.ToLongTimeString());

                    using (MySqlCommand command = new MySqlCommand("UPDATE `utilisateur`, `etablissement` SET utilisateur.logged=@heure, utilisateur.AsConnected=1,etablissement.connected=1 WHERE etablissement.codeEtab=@ETAB AND utilisateur.etablissement=@code AND utilisateur.id=@uid", db.getConnection))
                    {
                        command.Parameters.Add("@heure", MySqlDbType.VarChar).Value = heureActuelle;
                        command.Parameters.Add("@uid", MySqlDbType.Int32).Value = user;
                        command.Parameters.Add("@code", MySqlDbType.VarChar).Value = Convert.ToString(labelEtab.Text);
                        command.Parameters.Add("@ETAB", MySqlDbType.VarChar).Value = Convert.ToString(labelEtab.Text);
                        db.openConnection();
                        command.ExecuteNonQuery();
                    }
                    db.closeConnection();
                }
                else if (attempt == 4)
                {
                    //MessageBox.Show("Votre tentative de connexion a dépassée");
                    textBoxLogin.Enabled = false;
                    textBoxPassword.Enabled = false;
                    IDcodeComboBox.Enabled = false;
                    typeUtilisateurComboBox.Enabled = false;
                    int user = Convert.ToInt32(Globals.GlobalUserId);

                    string type = Convert.ToString(typeUtilisateurComboBox.SelectedValue);

                    using (MySqlCommand command = new MySqlCommand("UPDATE `utilisateur` SET `etatCompte`=0 WHERE utilisateur.etablissement=@ETAB AND `typeUtilisateur`=@user AND `id`=@uid", db.getConnection))
                    {
                        command.Parameters.Add("@uid", MySqlDbType.Int32).Value = user;
                        command.Parameters.Add("@user", MySqlDbType.VarChar).Value = type;
                        command.Parameters.Add("@ETAB", MySqlDbType.VarChar).Value = Convert.ToString(labelEtab.Text);
                        db.openConnection();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Votre compte a été bloqué pour tentative d'usurpation de mot de passe ! Veuillez contacter l'Administrateur!");
                        btnLogin.Enabled = false;
                        Application.Exit();
                    }
                    db.closeConnection();
                }
                attempt++;
            }
            else
            {
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE idCode=@idCode AND etablissement.etatEtab=true AND BINARY(`loginUtilisateur`)=@lgn AND BINARY(`passUtilisateur`)=MD5(@pass) AND `typeUtilisateur`=@typeUt AND `etatCompte`=true", db.getConnection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DataTable table = new DataTable();

                    command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = textBoxLogin.Text.Trim();
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text.Trim();
                    command.Parameters.Add("@typeUt", MySqlDbType.VarChar).Value = typeUtilisateurComboBox.SelectedItem;
                    command.Parameters.Add("@idCode", MySqlDbType.VarChar).Value = IDcodeComboBox.SelectedValue;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    //Vérification si les champs sont vide
                    if (verifChamps("login"))
                    {
                        if (table.Rows.Count > 0)
                        {
                            //une variable vue partout dans le programme même dans d'autres formulaires
                            int useradId = Convert.ToInt32(table.Rows[0][0].ToString());
                            GlobalsAdmin.SetGlobalUseradId(useradId);

                            MessageBox.Show("Votre connexion reussie !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Affichage du formulaire principal de l'application
                            this.Hide();
                            DepotCentralForm depotForm = new DepotCentralForm();
                            depotForm.Show();
                        }
                        else
                        {
                            //Affichage du message d'erreur
                            MessageBox.Show("Login, Mot de passe, Etablissement et Type utilisateur est invalide", "Erreur Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        //Affichage du message d'erreur
                        MessageBox.Show("Champs Login, Mot de passe, Etablissement et Type utilisateur est vide", "Erreur Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                int userAd = Convert.ToInt32(GlobalsAdmin.GlobalUserAdId);

                string heureActuelle = Convert.ToString(DateTime.Now.ToLongTimeString());

                using (MySqlCommand command = new MySqlCommand("UPDATE utilisateur, etablissement SET utilisateur.logged=@heure, utilisateur.AsConnected=1,etablissement.connected=1 WHERE etablissement.codeEtab=@idCode AND `id`=@uid", db.getConnection))
                {
                    command.Parameters.Add("@heure", MySqlDbType.VarChar).Value = heureActuelle;
                    command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userAd;
                    command.Parameters.Add("@idCode", MySqlDbType.VarChar).Value = IDcodeComboBox.SelectedValue;
                    db.openConnection();
                    command.ExecuteNonQuery();
                }
                db.closeConnection();
            }
        }

        //La création de la fonction pour tester si tous les champs sont remplies
        public bool verifChamps(string operation)
        {
            bool check = false;
            //Si l'opération est de créer un nouveau compte
            if (operation == "login")
            {
                //Si tu veux ajouter Prenom ou nom, la vérification doit être faite avec if and else
                if (textBoxLogin.Text.Trim().Equals("") || textBoxPassword.Text.Trim().Equals("") || typeUtilisateurComboBox.Text.Trim().Equals("") || IDcodeComboBox.Text.Trim().Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }

        //Changement de l'etat de visibilite du mot de passe saisie dans le champ mot de passe
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formBackgroud = new Form();
            try
            {
                using (EtablissementAdministrateurForm ad = new EtablissementAdministrateurForm())
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                formBackgroud.Dispose();
            }
            this.OnLoad(e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bndmobetisoft.com/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gmimimilo.com/");
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            chercherEtab(textBoxLogin.Text);
        }

        private void chercherEtab(string login)
        {
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT `etablissement` FROM `utilisateur` WHERE loginUtilisateur=@lgn", db.getConnection);

            db.openConnection();

            command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = login;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
           
            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                labelEtab.Text = Convert.ToString(table.Rows[0]["etablissement"]);
            }
        }


                  
        
    }
}

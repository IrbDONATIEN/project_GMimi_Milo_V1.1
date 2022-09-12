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

namespace Projet_Delta_V1._1.Forms
{
    public partial class AjouterUtilisateurForm : Form
    {
        public AjouterUtilisateurForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Variables getters et setters
        public string userAdId { get; set; }
        public bool isUpdateUser { get; set; }

        MY_DB db = new MY_DB();
        UTILISATEUR utilisateurs = new UTILISATEUR();
        private void BrowserButton_Click(object sender, EventArgs e)
        {
            //Sélection et Affichage d'une image à partir de PictureBox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sélectionner Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                picturePictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void AjouterUtilisateurForm_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();

            typeUtilisateurComboBox.SelectedIndex = 0;
            etatCompteComboBox.SelectedIndex = 0;

            //Chargement de données dans le combobox pour la modification du nom du groupe
            etablissementComboBox.DataSource = getEtablissements();
            etablissementComboBox.DisplayMember = "nomEtab";
            etablissementComboBox.ValueMember = "codeEtab";

            if (this.isUpdateUser)
            {
                chargerUpdateUser();
                label3.Visible = true;
                labelID.Visible = true;
                labelUserID.Visible = true;
                textBoxSearch.Visible = true;
                btnModifierCompte.Visible = true;
                btnSupprimerCompte.Visible = true;
                CreerCompteUtilisateurButton.Visible = false;
                UserGroupBox.Text = "Modifier Ancien Utilisateur";
            }
        }

        private void chargerUpdateUser()
        {
            DataTable dtUser = GetChargerUpdateUser();

            DataRow row = dtUser.Rows[0];

            labelUserID.Text = row["id"].ToString();

            int mod = Convert.ToInt32(row["modifpassword"]);

            if(mod==1)
            {
                ModifpassCheckBox.Checked = true;
            }
            else
            {
                ModifpassCheckBox.Checked = false;
            }
            
            prenomUtilisateurTextBox.Text = row["prenomUtilisateur"].ToString();
            nomUtilisateurTextBox.Text = row["nomUtilisateur"].ToString();
            loginTextBox.Text = row["loginUtilisateur"].ToString();
            passTextBox.Text = row["passUtilisateur"].ToString();
            ConfirmerPassTextBox.Text = row["passUtilisateur"].ToString();
            etatCompteComboBox.SelectedValue = row["etatCompte"].ToString();
            typeUtilisateurComboBox.SelectedValue = row["typeUtilisateur"].ToString();
            etablissementComboBox.SelectedValue = row["etablissement"].ToString();

            byte[] pic = (byte[])row["picture"];
            MemoryStream picture = new MemoryStream(pic);
            picturePictureBox.Image = Image.FromStream(picture);
        }

        private DataTable GetChargerUpdateUser()
        {
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE `id`=@ID", db.getConnection);

            db.openConnection();

            command.Parameters.AddWithValue("@ID", this.userAdId);

            MySqlDataReader reader = command.ExecuteReader();

            table.Load(reader);

            return table;
        }

        public DataTable getEtablissements()
        {
            string IDCode = Convert.ToString(IDCodeLabelAd.Text);

            MySqlCommand command = new MySqlCommand("SELECT `codeEtab`, `nomEtab`, `adresseEtab`, `registreCommercial`, `villeEtab`, `dateCreationEtab`, `etatEtab` FROM `etablissement` WHERE `idCodeEtab`=@IDCode AND `etatEtab`=true", db.getConnection);
            DataTable table = new DataTable();
            command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = IDCode;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }

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
                //Affichage le code de l'Etablissement connecte
                labelEtablissementAd.Text = Convert.ToString(table.Rows[0][10]);
                IDCodeLabelAd.Text = Convert.ToString(table.Rows[0]["idCodeEtab"]);
            }
        }

        private void CreerCompteUtilisateurButton_Click(object sender, EventArgs e)
        {
            try
            {
                string prenom = Convert.ToString(prenomUtilisateurTextBox.Text);
                string nom = Convert.ToString(nomUtilisateurTextBox.Text);
                string login = Convert.ToString(loginTextBox.Text);
                string typeUt = Convert.ToString(typeUtilisateurComboBox.SelectedItem);
                string pass = passTextBox.Text.ToString();
                string IDCode = Convert.ToString(IDCodeLabelAd.Text);
                bool etatCompte = false;
                int valider = Convert.ToInt32(0);
                if ((etatCompteComboBox.SelectedIndex == 0))
                {

                    etatCompte = true;
                }
                else
                {
                    etatCompte = false;
                }

                if ((ModifpassCheckBox.Checked==true))
                {
                    valider = 1;
                }
                else
                {
                    valider = 0;
                }

                DateTime dateCreation = Convert.ToDateTime(DateTime.Now.Date.Date);
                string heureCreation = Convert.ToString(DateTime.Now.ToLongTimeString());
                string etabliss = Convert.ToString(etablissementComboBox.SelectedValue);
                if (verifUser())
                {
                    MemoryStream picture = new MemoryStream();
                    picturePictureBox.Image.Save(picture, picturePictureBox.Image.RawFormat);
                    if (!utilisateurs.loginExists(login, etabliss, "register"))
                    {
                        if (passTextBox.Text.Trim() == ConfirmerPassTextBox.Text.Trim())
                        {
                            if (utilisateurs.insererUtilisateur(prenom, nom, login, pass, typeUt, etatCompte, dateCreation, heureCreation, etabliss, picture, IDCode,valider))
                            {
                                MessageBox.Show("La création de votre compte est éffectuée avec succès", "Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                typeUtilisateurComboBox.SelectedItem = null;
                                prenomUtilisateurTextBox.Clear();
                                nomUtilisateurTextBox.Clear();
                                passTextBox.Clear();
                                ConfirmerPassTextBox.Clear();
                                loginTextBox.Clear();
                                prenomUtilisateurTextBox.Focus();
                                etatCompteComboBox.SelectedIndex = 0;
                                picturePictureBox.Image= null;
                                this.Close();
                                AjouterUtilisateurForm_Load(null, null);
                          
                            }
                            else
                            {
                                MessageBox.Show("La création de votre compte non éffectuée avec succès", "Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le premier mot de passe et mot de passe de confirmation n'est pas conforme", "Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login saisi existe, veuillez saisir un autre", "Login Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez remplir tout les champs pour créer Compte Utilisateur", "Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool verifUser()
        {
            if ((prenomUtilisateurTextBox.Text.Trim().Equals("")) || (nomUtilisateurTextBox.Text.Trim().Equals("")) || (loginTextBox.Text.Trim().Equals("")) || (passTextBox.Text.Trim().Equals("")) || (ConfirmerPassTextBox.Text.Trim().Equals("")) || (picturePictureBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnModifierCompte_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(labelUserID.Text);
                string prenom = Convert.ToString(prenomUtilisateurTextBox.Text);
                string nom = Convert.ToString(nomUtilisateurTextBox.Text);
                string login = Convert.ToString(loginTextBox.Text);
                string typeUt = Convert.ToString(typeUtilisateurComboBox.SelectedItem);
                string pass = passTextBox.Text.ToString();
                string IDCode = Convert.ToString(IDCodeLabelAd.Text);
                bool etatCompte = false;
                int valider = Convert.ToInt32(0);


                if ((etatCompteComboBox.SelectedIndex == 0))
                {

                    etatCompte = true;
                }
                else
                {
                    etatCompte = false;
                }

                if ((ModifpassCheckBox.Checked))
                {
                    valider = 1;
                }
                else
                {
                    valider = 0;
                }

                DateTime dateCreation = Convert.ToDateTime(DateTime.Now.Date.Date);
                string heureCreation = Convert.ToString(DateTime.Now.ToLongTimeString());
                string etabliss = Convert.ToString(etablissementComboBox.SelectedValue);
                if (verifUser())
                {
                    MemoryStream picture = new MemoryStream();
                    picturePictureBox.Image.Save(picture, picturePictureBox.Image.RawFormat);
                    if (!utilisateurs.loginExists(login, etabliss, "edit"))
                    {
                        if (passTextBox.Text.Trim() == ConfirmerPassTextBox.Text.Trim())
                        {
                            if (utilisateurs.updateUtilisateur(ID,prenom,nom,login,pass,etabliss,picture,typeUt,etatCompte,valider))
                            {
                                MessageBox.Show("La Modification de votre compte utilisateur est éffectuée avec succès", "Modifier Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AjouterUtilisateurForm_Load(null, null);
                            }
                            else
                            {
                                MessageBox.Show("La Modification de votre compte utilisateur non éffectuée avec succès", "Modifier Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le premier mot de passe et mot de passe de confirmation n'est pas conforme", "Modifier Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login saisi existe, veuillez saisir un autre", "Login Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez remplir tout les champs pour Modifier Compte Utilisateur", "Modifier Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            textBoxSearch.Focus();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUsers(textBoxSearch.Text);
        }

        private void SearchUsers(string userId)
        {
            try
            {
                if (!verifUtilisateurID(userId))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT `id`, `prenomUtilisateur`, `nomUtilisateur`, `loginUtilisateur`, `passUtilisateur`, `typeUtilisateur`, `etatCompte`, `dateCreation`, `heureCreation`, `etablissement`, `picture` FROM `utilisateur` WHERE `idCode`=@IDcode AND `id`=" + userId))
                    {
                        DataTable table = getChercherUtilisateurs(command);
                        if (table.Rows.Count > 0)
                        {

                            labelUserID.Text = table.Rows[0]["id"].ToString();
                            prenomUtilisateurTextBox.Text = table.Rows[0]["prenomUtilisateur"].ToString();
                            nomUtilisateurTextBox.Text = table.Rows[0]["nomUtilisateur"].ToString();
                            loginTextBox.Text = table.Rows[0]["loginUtilisateur"].ToString();

                            //Pour le mot de passe
                            passTextBox.Text = table.Rows[0]["passUtilisateur"].ToString();
                            ConfirmerPassTextBox.Text = table.Rows[0]["passUtilisateur"].ToString();
                            
                            //Type Utilisateur
                            etablissementComboBox.SelectedValue = table.Rows[0]["etablissement"].ToString();
                            typeUtilisateurComboBox.SelectedValue = table.Rows[0]["typeUtilisateur"].ToString();
                            
                            //Affichage image dans pictureBox
                            byte[] pic = (byte[])table.Rows[0]["picture"];
                            MemoryStream picture = new MemoryStream(pic);
                            picturePictureBox.Image = Image.FromStream(picture);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce ID de Compte Utilisateur  n'existe pas veuillez saisir ID correct svp !", "Recherche Compte Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Vous devrez saisir le numéro Compte Utilisateur pour chercher !", "Numero Compte Utilisateur invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearch.Focus();
            }
        }

        public bool verifUtilisateurID(string userId)
        {
            string IDCode = Convert.ToString(IDCodeLabelAd.Text);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE `idCode`=@IDcode AND `id`=@uid", db.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

            command.Parameters.Add("@IDcode", MySqlDbType.VarChar).Value = IDCode;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getChercherUtilisateurs(MySqlCommand command)
        {
            string IDCodes = Convert.ToString(IDCodeLabelAd.Text);
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.Add("@IDcode", MySqlDbType.VarChar).Value = IDCodes;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void btnSupprimerCompte_Click(object sender, EventArgs e)
        {
            try
            {
                int utilisateurId = Convert.ToInt32(labelUserID.Text);
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir supprimé cet Utilisateur?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    supprimerUtilisateur(utilisateurId);
                    MessageBox.Show("Votre Utilisateur est supprimé de l'application !");
                    this.Close();
                    this.OnLoad(e);
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Utilisateur a supprimé!");
            }
        }

        public bool supprimerUtilisateur(int utilisateurId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `utilisateur` WHERE `etatCompte`=1 AND `id`=@ID AND `idCode`=@idCode AND AsConnected=0", db.getConnection);

            //Création des objets 
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = utilisateurId;
            command.Parameters.Add("@idCode", MySqlDbType.VarChar).Value = Convert.ToString(IDCodeLabelAd.Text);
            //Ouverture la base de données
            db.openConnection();
            //Condition de vérification  si la variable de base de donnée command est exécuteé une seule fois
            //Pour qu'on fermer la connexion à la base 
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

              
    }
}

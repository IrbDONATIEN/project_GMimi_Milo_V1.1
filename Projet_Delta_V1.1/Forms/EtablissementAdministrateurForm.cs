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
using System.IO;
using Projet_Delta_V1._1.Classes;

namespace Projet_Delta_V1._1.Forms
{
    public partial class EtablissementAdministrateurForm : Form
    {
        public EtablissementAdministrateurForm()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        ETABLISSEMENT etablissements = new ETABLISSEMENT();
        UTILISATEUR utilisateurs = new UTILISATEUR();
        private void EtablissementAdministrateurForm_Load(object sender, EventArgs e)
        {
            etatCompteComboBox.SelectedIndex = 0;
            EtatEtabcomboBox.SelectedIndex = 0;
            typeUtilisateurComboBox.SelectedIndex = 0;
            villeComboBox.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Création de la fonction pour vérifier les données de l'Etablissement
        bool verifEtab()
        {
            if (((nomEtabTextBox.Text.Trim().Equals("")) || (registreCommercialTextBox.Text.Trim().Equals("")) || (adresseEtabTextBox.Text.Trim().Equals("")) || (pictureEtabPictureBox.Image == null)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Création de la fonction pour vérifier les données de l'utilisateur
        bool verifUser()
        {
            if ((prenomUtilisateurTextBox.Text.Trim().Equals("")) || (nomUtilisateurTextBox.Text.Trim().Equals("")) || (loginTextBox.Text.Trim().Equals("")) || (passTextBox.Text.Trim().Equals("")) || (ConfirmerPassTextBox.Text.Trim().Equals("")) || (UserPictureBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Selection du logo de l'Etablissement
        private void BrowserEtabButton_Click(object sender, EventArgs e)
        {
            //Sélection et Affichage d'une image à partir de PictureBox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sélectionner logo Etablissement(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureEtabPictureBox.Image= Image.FromFile(opf.FileName);
            }
        }

        //Selection de l'image de l'utilisateur
        private void BrowserUserButton_Click(object sender, EventArgs e)
        {
            //Sélection et Affichage d'une image à partir de PictureBox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sélectionner Image Utilisateur (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                UserPictureBox.Image= Image.FromFile(opf.FileName);
            }
        }

        //Creation d'etablissement administrateur
        private void ConfirmerEtabButton_Click(object sender, EventArgs e)
        {
            try
            {
                //la variable contenant le code établissement
                string codeEtablissements;

                //Si le code établissement existe
                bool iscodeEtablissementsExiste = true;


                while (iscodeEtablissementsExiste)
                {
                    //Utilisation de la fonction de génération de code établissement
                    codeEtablissements = GenerateCodeEtablissements();

                    //Utilisation de la fonction de vérification si le code établissement 
                    //existe déjà dans la base de données
                    //Si le code établissement existe qu'on vérifie par la fonction suivante
                    iscodeEtablissementsExiste = CheckSiCodeEtablissementsExistes(codeEtablissements);
                    codeEtabLabel.Text = codeEtablissements;
                }

                string code = Convert.ToString(codeEtabLabel.Text);
                string nom = Convert.ToString(nomEtabTextBox.Text);
                string adress = adresseEtabTextBox.Text.ToString();
                string registre = registreCommercialTextBox.Text.ToString();
                string ville = Convert.ToString(villeComboBox.SelectedItem);
                DateTime dateCreationEtab = DateTime.Now.Date;
                bool etatEtab = false;
                string idEtab = Convert.ToString(codeEtabLabel.Text);
                if ((EtatEtabcomboBox.SelectedIndex == 0))
                {
                    etatEtab = true;
                }
                else
                {
                    etatEtab = false;
                }

                if (verifEtab())
                {
                    MemoryStream pic = new MemoryStream();

                    if (!etablissements.verifEtablissementNom(nom))
                    {
                        pictureEtabPictureBox.Image.Save(pic, pictureEtabPictureBox.Image.RawFormat);

                        if (etablissements.insererEtablissement(code,nom,adress,registre,ville,dateCreationEtab,etatEtab,pic,idEtab))
                        {
                            int cid = Convert.ToInt32(1);

                            updateSupp(cid);

                            MessageBox.Show("La création de votre établissement éffectuée avec succès", "Création Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Boutons
                            ConfirmerEtabButton.Enabled = false;
                            AnnulerEtabButton.Enabled = false;
                            BrowserEtabButton.Enabled = false;
                            pictureEtabPictureBox.Enabled = false;
                            //Zones textes
                            nomEtabTextBox.Enabled = false;
                            nomEtabTextBox.Clear();
                            registreCommercialTextBox.Enabled = false;
                            registreCommercialTextBox.Clear();
                            villeComboBox.SelectedItem = null;
                            villeComboBox.Enabled = false;
                            EtatEtabcomboBox.SelectedIndex = 0;
                            EtatEtabcomboBox.Enabled = false;
                            adresseEtabTextBox.Enabled = false;
                            adresseEtabTextBox.Clear();
                            pictureEtabPictureBox.Image = null;
                            UtilisateurAdminGroupBox.Enabled = true;
                            prenomUtilisateurTextBox.Focus();
                            button3.Enabled = false;
                            AnnulerEtabButton.Enabled = false;
                            AnnulerUserButton.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("La création de votre établissement non éffectuée avec succès", "Création Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ce nom d'établissement existe déjà veuillez choisir un autre");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez remplir tous les champs pour créer établissement", "Création Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private bool updateSupp(int cid)
        {

            MySqlCommand command = new MySqlCommand("UPDATE `supp` SET `no`=@no", db.getConnection);

            command.Parameters.Add("@no", MySqlDbType.Int32).Value =cid;

            db.openConnection();

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

        //Verification de code d'Etablissement genere dans la base de donnees
        private bool CheckSiCodeEtablissementsExistes(string codeEtablissements)
        {
            bool FaitcodeEtablissementsExiste = false;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `etablissement` WHERE `codeEtab`=@CodeEtab", db.getConnection);

            db.openConnection();

            command.Parameters.Add("@CodeEtab", MySqlDbType.VarChar).Value = codeEtablissements;

            DataTable table = new DataTable();

            MySqlDataReader lire = command.ExecuteReader();

            table.Load(lire);

            if (table.Rows.Count > 0)
            {
                FaitcodeEtablissementsExiste = true;
            }

            return FaitcodeEtablissementsExiste;
        }

        //Creation de fonction de generation de code unique pour l'etablissement
        private string GenerateCodeEtablissements()
        {
            //Génération de numéro automatiquement
            //ETABXXXX
            string codeEtablissements;

            Random rnd = new Random();
            int orderpart2 = rnd.Next(1000, 99999);

            codeEtablissements = "ETAB" + orderpart2;

            return codeEtablissements;
        }

        private void AnnulerEtabButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnnulerUserButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Creation de l'utilisateur administrateur
        private void CreerCompteUtilisateurButton_Click(object sender, EventArgs e)
        {
            try
            {
                string prenom = Convert.ToString(prenomUtilisateurTextBox.Text);
                string nom = Convert.ToString(nomUtilisateurTextBox.Text);
                string login = Convert.ToString(loginTextBox.Text);
                string typeUt = Convert.ToString(typeUtilisateurComboBox.SelectedItem);
                string pass = passTextBox.Text.ToString();
                string IDCode = Convert.ToString(codeEtabLabel.Text);
                bool etatCompte = false;

                if ((etatCompteComboBox.SelectedIndex == 0))
                {

                    etatCompte = true;
                }
                else
                {
                    etatCompte = false;
                }

                DateTime dateCreation = Convert.ToDateTime(DateTime.Now.Date.Date);
                string heureCreation = Convert.ToString(DateTime.Now.ToLongTimeString());
                string etabliss = Convert.ToString(codeEtabLabel.Text);
                int valider = 0;
                if (verifUser())
                {
                    MemoryStream picture = new MemoryStream();
                    UserPictureBox.Image.Save(picture, UserPictureBox.Image.RawFormat);
                    if (!utilisateurs.loginExists(login, etabliss, "register"))
                    {
                        if (passTextBox.Text.Trim() == ConfirmerPassTextBox.Text.Trim())
                        {
                            if (utilisateurs.insererUtilisateur(prenom, nom, login, pass, typeUt, etatCompte, dateCreation, heureCreation, etabliss, picture, IDCode,valider))
                            {
                                MessageBox.Show("La création de votre compte est éffectuée avec succès", "Compte Administrateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                typeUtilisateurComboBox.SelectedItem = null;
                                prenomUtilisateurTextBox.Clear();
                                nomUtilisateurTextBox.Clear();
                                passTextBox.Clear();
                                ConfirmerPassTextBox.Clear();
                                loginTextBox.Clear();
                                prenomUtilisateurTextBox.Focus();
                                etatCompteComboBox.SelectedIndex = 0;
                                UserPictureBox.Image = null;
                                this.Close();
                                EtablissementAdministrateurForm_Load(null, null);
                            }
                            else
                            {
                                MessageBox.Show("La création de votre compte non éffectuée avec succès", "Compte Administrateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le premier mot de passe et mot de passe de confirmation n'est pas conforme", "Compte Administrateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login saisi existe, veuillez saisir un autre", "Login Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez remplir tout les champs pour créer compte Administrateur", "Compte Administrateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

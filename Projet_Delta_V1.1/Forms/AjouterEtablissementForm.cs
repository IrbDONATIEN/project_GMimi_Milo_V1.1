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
    public partial class AjouterEtablissementForm : Form
    {
        public AjouterEtablissementForm()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        ETABLISSEMENT etablissements = new ETABLISSEMENT();
        //Variables getters et setters
        public string etablissementAdId { get; set; }
        public bool isUpdateEtablissement { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AjouterEtablissementForm_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();

            EtatEtabcomboBox.SelectedIndex = 0;
            villeComboBox.SelectedIndex = 0;

            if (this.isUpdateEtablissement)
            {
                chargerUpdateEtablissement();
                label3.Visible = true;
                textBoxSearch.Visible = true;
                ModifierEtablissementButton.Visible = true;
                SupprimerEtablissementButton.Visible = true;
                NouvelEtabButton.Visible = false;
                AnnulerButton.Visible = false;
                ConfirmerEtabButton.Visible = false;
                label2.Text = "MODIFIER ETABLISSEMENT";
                NouvelEtabButton.Enabled = false;
                nomEtabTextBox.Enabled = true;
                registreCommercialTextBox.Enabled = true;
                villeComboBox.Enabled = true;
                adresseEtabTextBox.Enabled = true;
                EtatEtabcomboBox.Enabled = true;
                picturePictureBox.Enabled = true;

                //Buttons
                BrowserButton.Enabled = true;
                AnnulerButton.Enabled = true;
                ConfirmerEtabButton.Enabled = true;
            }
        }

        private void chargerUpdateEtablissement()
        {
            DataTable dtEtab = GetChargerUpdateEtablissement();

            DataRow row = dtEtab.Rows[0];

            codeEtabTextBox.Text = row["codeEtab"].ToString();

            nomEtabTextBox.Text = row["nomEtab"].ToString();
            registreCommercialTextBox.Text = row["registreCommercial"].ToString();
            villeComboBox.SelectedValue = row["villeEtab"].ToString();
            adresseEtabTextBox.Text = row["adresseEtab"].ToString();
            EtatEtabcomboBox.SelectedValue = row["etatEtab"].ToString();

            byte[] pic = (byte[])row["pictures"];
            MemoryStream picture = new MemoryStream(pic);
            picturePictureBox.Image = Image.FromStream(picture);
        }

        private DataTable GetChargerUpdateEtablissement()
        {
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `etablissement` WHERE `codeEtab`=@codeEtab", db.getConnection);

            db.openConnection();

            command.Parameters.AddWithValue("@codeEtab", this.etablissementAdId);

            MySqlDataReader reader = command.ExecuteReader();

            table.Load(reader);

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

        private void BrowserButton_Click(object sender, EventArgs e)
        {
            //Sélection et Affichage d'une image à partir de PictureBox
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sélectionner logo Etablissement(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                picturePictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void NouvelEtabButton_Click(object sender, EventArgs e)
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
                codeEtabTextBox.Text = codeEtablissements;

                nomEtabTextBox.Focus();
            }
            NouvelEtabButton.Enabled = false;
            nomEtabTextBox.Enabled = true;
            registreCommercialTextBox.Enabled = true;
            villeComboBox.Enabled = true;
            adresseEtabTextBox.Enabled = true;
            EtatEtabcomboBox.Enabled = true;
            picturePictureBox.Enabled = true;

            //Buttons
            BrowserButton.Enabled = true;
            AnnulerButton.Enabled = true;
            ConfirmerEtabButton.Enabled = true;
            nomEtabTextBox.Focus();
        }

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

        private void AnnulerButton_Click(object sender, EventArgs e)
        {
            NouvelEtabButton.Enabled = true;
            nomEtabTextBox.Enabled = false;
            registreCommercialTextBox.Enabled = false;
            villeComboBox.Enabled = false;
            adresseEtabTextBox.Enabled = false;
            EtatEtabcomboBox.Enabled = false;
            picturePictureBox.Enabled = false;

            //Buttons
            BrowserButton.Enabled = false;
            AnnulerButton.Enabled = false;
            ConfirmerEtabButton.Enabled = false;
        }

        private void ConfirmerEtabButton_Click(object sender, EventArgs e)
        {
            try
            {
                string code = Convert.ToString(codeEtabTextBox.Text);
                string nom = Convert.ToString(nomEtabTextBox.Text);
                string adress = adresseEtabTextBox.Text.ToString();
                string registre = registreCommercialTextBox.Text.ToString();
                string ville = Convert.ToString(villeComboBox.SelectedItem);
                DateTime dateCreationEtab = DateTime.Now.Date;
                bool etatEtab = true;
                string idEtab = Convert.ToString(IDCodeLabelAd.Text);
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
                         picturePictureBox.Image.Save(pic, picturePictureBox.Image.RawFormat);
                         if (etablissements.insererEtablissement(code,nom,adress,registre,ville,dateCreationEtab,etatEtab,pic,idEtab))
                         {
                             MessageBox.Show("La création de votre établissement non éffectuée avec succès", "Création Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             NouvelEtabButton.Enabled = true;
                             nomEtabTextBox.Enabled = false;
                             codeEtabTextBox.Clear();
                             nomEtabTextBox.Clear();
                             adresseEtabTextBox.Clear();
                             registreCommercialTextBox.Clear();
                             
                             registreCommercialTextBox.Enabled = false;
                             villeComboBox.Enabled = false;
                             adresseEtabTextBox.Enabled = false;
                             EtatEtabcomboBox.Enabled = false;
                             picturePictureBox.Enabled = false;

                             //Buttons
                             BrowserButton.Enabled = false;
                             AnnulerButton.Enabled = false;
                             ConfirmerEtabButton.Enabled = false;
                             AjouterEtablissementForm_Load(null, null);
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
                    MessageBox.Show("Vous devez remplir tout les champs pour créer établissement", "Création Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        //Création de la fonction pour vérifier les données
        bool verifEtab()
        {
            if ((codeEtabTextBox.Text.Trim().Equals("")) || (nomEtabTextBox.Text.Trim().Equals("")) || (registreCommercialTextBox.Text.Trim().Equals("")) || (adresseEtabTextBox.Text.Trim().Equals("")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchEtablissements(textBoxSearch.Text);
        }

        private void searchEtablissements(string codeEtab)
        {
            try
            {
                string IDCode = Convert.ToString(IDCodeLabelAd.Text);
                if (!verifCodeEtablissement(codeEtab))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT `codeEtab`, `nomEtab`, `adresseEtab`, `registreCommercial`, `villeEtab`, `dateCreationEtab`, `etatEtab`, `pictures`, `idCodeEtab`, `connected` FROM `etablissement` WHERE `idCodeEtab`=@IDCode AND `codeEtab`=@codeEtab", db.getConnection))
                    {
                        command.Parameters.Add("@codeEtab",MySqlDbType.VarChar).Value = codeEtab;

                        command.Parameters.Add("@IDCode",MySqlDbType.VarChar).Value=IDCode;

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {

                            codeEtabTextBox.Text = table.Rows[0]["codeEtab"].ToString();
                            nomEtabTextBox.Text=table.Rows[0]["nomEtab"].ToString();
                            registreCommercialTextBox.Text = table.Rows[0]["registreCommercial"].ToString();
                            villeComboBox.SelectedValue = table.Rows[0]["villeEtab"].ToString();
                            adresseEtabTextBox.Text = table.Rows[0]["adresseEtab"].ToString();
                            EtatEtabcomboBox.SelectedValue = table.Rows[0]["etatEtab"].ToString();

                            //Affichage image dans pictureBox
                            byte[] pic = (byte[])table.Rows[0]["pictures"];
                            MemoryStream picture = new MemoryStream(pic);
                            picturePictureBox.Image = Image.FromStream(picture);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce code Etablissement n'existe pas veuillez saisir code Etablissement correct svp !", "Recherche Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch 
            {
                MessageBox.Show("Veullez remplir tous les champs avant de faire cette action!", "Recherche Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool verifCodeEtablissement(string codeEtab)
        {
            string IDCode = Convert.ToString(IDCodeLabelAd.Text);
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM `etablissement` WHERE `idCodeEtab`=@IDCode AND `codeEtab`=@codeEtab", db.getConnection);

            command.Parameters.Add("@codeEtab", MySqlDbType.VarChar).Value = codeEtab;

            command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = IDCode;

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
        //Bouton modifier l'Etablissement déjà dans la base de données
        private void ModifierEtablissementButton_Click(object sender, EventArgs e)
        {
            try
            {
                string code = Convert.ToString(codeEtabTextBox.Text);
                string nom = Convert.ToString(nomEtabTextBox.Text);
                string adress = adresseEtabTextBox.Text.ToString();
                string registre = registreCommercialTextBox.Text.ToString();
                string ville = Convert.ToString(villeComboBox.SelectedItem);
                DateTime dateCreationEtab = DateTime.Now.Date;
                bool etatEtab = false;
                string idEtab = Convert.ToString(IDCodeLabelAd.Text);
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
                        picturePictureBox.Image.Save(pic, picturePictureBox.Image.RawFormat);
                        if (etablissements.modifierEtablissement(code, nom, adress, registre, ville, dateCreationEtab, etatEtab, pic, idEtab))
                        {
                            MessageBox.Show("La modification de votre établissement éffectuée avec succès", "Modification Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ModifierEtablissementButton.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("La modification de votre établissement non éffectuée avec succès!", "Modification Etablissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Bouton Supprimer l'Etablissement en cours
        private void SupprimerEtablissementButton_Click(object sender, EventArgs e)
        {
            try
            {
                string IdEtablissement= Convert.ToString(codeEtabTextBox.Text);
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir supprimé cet Etablissement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    supprimerEtablissement(IdEtablissement);
                    MessageBox.Show("Votre Etablissement est supprimé de l'application !");
                    this.Close();
                    this.OnLoad(e);
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Etablissement a supprimé!");
            }
        }

        public bool supprimerEtablissement(string IdEtablissement)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `etablissement` WHERE `etatEtab`=1 AND `codeEtab`=@ID AND `idCodeEtab`=@idCode AND connected=0", db.getConnection);

            //Création des objets 
            command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = IdEtablissement;
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

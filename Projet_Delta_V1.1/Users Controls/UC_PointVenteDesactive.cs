using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Projet_Delta_V1._1.Classes;

namespace Projet_Delta_V1._1.Users_Controls
{
    public partial class UC_PointVenteDesactive : UserControl
    {
        public UC_PointVenteDesactive()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        private void UC_PointVenteDesactive_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();
            //Chargement des etablissements en cours
            chargerEtablissements(new MySqlCommand("SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=false AND `idCodeEtab`=@IDCode"));
            //Compter les nombres des points des ventes desactives 
            CompterPointVenteDesactive();
        }

        string etablissementId;

        private void CompterPointVenteDesactive()
        {
            if (dataGridViewListEtablissementDesactive.Rows.Count > 0)
            {
                int nbre = Convert.ToInt32(dataGridViewListEtablissementDesactive.Rows.Count);
                if (nbre <= 1)
                {
                    labelNumberPointVenteDesactive.Text = "Le Point de Vente Désactivé: " + '0' + dataGridViewListEtablissementDesactive.Rows.Count.ToString();
                }
                else if (nbre <= 9)
                {
                    labelNumberPointVenteDesactive.Text = "Les Point(s) de(s) Vente(s) Désactivé(s):  " + '0' + dataGridViewListEtablissementDesactive.Rows.Count.ToString();
                }
                else
                {
                    labelNumberPointVenteDesactive.Text = "Les Point(s) de(s) Vente(s) Désactivé(s): " + dataGridViewListEtablissementDesactive.Rows.Count.ToString();
                }
            }
            else
            {
                labelNumberPointVenteDesactive.Text = "Le Point de Vente Désactivé :" + "00";
            }
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

        private void chargerEtablissements(MySqlCommand command)
        {
            dataGridViewListEtablissementDesactive.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListEtablissementDesactive.RowTemplate.Height = 80;
            dataGridViewListEtablissementDesactive.DataSource = getEtablissements(command);

            //Colonne 10 a l'index de l'image dans datagridview
            picCol = (DataGridViewImageColumn)dataGridViewListEtablissementDesactive.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewListEtablissementDesactive.AllowUserToAddRows = false;
        }

        //Création de la fonction qui retourne les données des étudiants 
        public DataTable getEtablissements(MySqlCommand command)
        {
            string idCode = Convert.ToString(IDCodeLabelAd.Text);
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = idCode;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void comboBoxSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                if (comboBoxSearch.SelectedItem.ToString().Equals("CODE"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=false AND idCodeEtab=@IDCode AND codeEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("ETABLISSEMENT"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=false AND idCodeEtab=@IDCode AND nomEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("VILLE"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=false AND idCodeEtab=@IDCode AND villeEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                MySqlCommand command = new MySqlCommand(query);
                chargerGrid(command);
                //Compter les nombres des points des ventes desactives 
                CompterPointVenteDesactive();

                if (textBoxSearch.Text == "")
                {
                    this.OnLoad(e);
                }
            }
            catch
            {
                MessageBox.Show("Veuillez saisir le critère de recherche!");
                textBoxSearch.Clear();
            }
        }

        private void chargerGrid(MySqlCommand command)
        {
            dataGridViewListEtablissementDesactive.ReadOnly = true;

            dataGridViewListEtablissementDesactive.DataSource = getSearchEtab(command);

            dataGridViewListEtablissementDesactive.AllowUserToAddRows = false;
        }

        private object getSearchEtab(MySqlCommand command)
        {
            string idCode = Convert.ToString(IDCodeLabelAd.Text);
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = idCode;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void btnRestaurerEtablissement_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir restauré cet Etablissement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (!etablissementId.Equals(string.Empty))
                    {
                        restaurerEtablissement(etablissementId);

                        MessageBox.Show("Votre Etablissement est restauré dans la Corbeille!");

                        this.OnLoad(e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Etablissement a restauré!");
            }
        }

        public bool restaurerEtablissement(string etablissementId)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `etablissement` SET `etatEtab`=1 WHERE `codeEtab`=@codeEtab AND `idCodeEtab`=@idCode AND connected=0", db.getConnection);

            //Création des objets 
            command.Parameters.Add("@codeEtab", MySqlDbType.VarChar).Value = etablissementId;
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

        private void btnSupprimerEtablissementDefinitivement_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir supprimé définitivement cet Etablissement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (!etablissementId.Equals(string.Empty))
                    {
                        deleteDefinitivementEtablissement(etablissementId);

                        MessageBox.Show("Votre Etablissement est supprimé définitivement !");

                        this.OnLoad(e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Etablissement a supprimé définitivement!");
            }
        }

        public bool deleteDefinitivementEtablissement(string etablissementId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `etablissement` WHERE `codeEtab`=@codeEtab AND `idCodeEtab`=@idCode AND connected=0", db.getConnection);

            //Création des objets 
            command.Parameters.Add("@codeEtab", MySqlDbType.VarChar).Value = etablissementId;
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

        private void dataGridViewListEtablissementDesactive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewListEtablissementDesactive.SelectedRows)
            {
                etablissementId = (string)item.Cells[0].Value;
            }
        }

       

    }
}

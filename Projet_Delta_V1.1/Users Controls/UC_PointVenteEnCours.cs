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
    public partial class UC_PointVenteEnCours : UserControl
    {
        public UC_PointVenteEnCours()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        private void UC_PointVenteEnCours_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();
            //Chargement des etablissements en cours
            chargerEtablissements(new MySqlCommand("SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE connected=1 AND `etatEtab`=1 AND `idCodeEtab`=@IDCode"));
            //Compter les nombres des points des ventes actives
            CompterPointVenteEnCours();
        }

        private void CompterPointVenteEnCours()
        {
            if (dataGridViewListEtablissementEnCours.Rows.Count > 0)
            {
                int nbre = Convert.ToInt32(dataGridViewListEtablissementEnCours.Rows.Count);
                if (nbre <= 1)
                {
                    labelNumberPointVenteEnCours.Text = "Le Point de Vente en Cours: " + '0' + dataGridViewListEtablissementEnCours.Rows.Count.ToString();
                }
                else if (nbre <= 9)
                {
                    labelNumberPointVenteEnCours.Text = "Les Point(s) de(s) Vente(s) en Cours:  " + '0' + dataGridViewListEtablissementEnCours.Rows.Count.ToString();
                }
                else
                {
                    labelNumberPointVenteEnCours.Text = "Les Point(s) de(s) Vente(s) en Cours: " + dataGridViewListEtablissementEnCours.Rows.Count.ToString();
                }
            }
            else
            {
                labelNumberPointVenteEnCours.Text = "Le Point de Vente en Cours :" + "00";
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
            dataGridViewListEtablissementEnCours.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListEtablissementEnCours.RowTemplate.Height = 80;
            dataGridViewListEtablissementEnCours.DataSource = getEtablissements(command);

            //Colonne 10 a l'index de l'image dans datagridview
            picCol = (DataGridViewImageColumn)dataGridViewListEtablissementEnCours.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewListEtablissementEnCours.AllowUserToAddRows = false;
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

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
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
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND connected=1 AND idCodeEtab=@IDCode AND codeEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("ETABLISSEMENT"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation', `pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND connected=1 AND idCodeEtab=@IDCode AND nomEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("VILLE"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND connected=1 AND idCodeEtab=@IDCode AND villeEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                MySqlCommand command = new MySqlCommand(query);
                chargerGrid(command);
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
            dataGridViewListEtablissementEnCours.ReadOnly = true;

            dataGridViewListEtablissementEnCours.DataSource = getSearchEtab(command);

            dataGridViewListEtablissementEnCours.AllowUserToAddRows = false;
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


    }
}

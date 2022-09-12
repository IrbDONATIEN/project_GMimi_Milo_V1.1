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
    public partial class UC_UserEnCours : UserControl
    {
        public UC_UserEnCours()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        private void UC_UserEnCours_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();
            //Chargement des utilisateurs en cours pour tous les etablissements 
            chargerUtilisateurs(new MySqlCommand("SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=1 AND utilisateur.idCode=@IDcode"));
            //Compter les utilisateurs actives pour les etablissements en cours
            CompterUserEnCours();

            checkBox.Checked = true;
        }

        private void CompterUserEnCours()
        {
            if (dataGridViewListUsereEnCours.Rows.Count > 0)
            {
                int nbre = Convert.ToInt32(dataGridViewListUsereEnCours.Rows.Count);
                if (nbre <= 1)
                {
                    labelNumberUserActive.Text = "L'Utilisateur En Cours: " + '0' + dataGridViewListUsereEnCours.Rows.Count.ToString();
                }
                else if (nbre <= 9)
                {
                    labelNumberUserActive.Text = "Les Utilisateur(s) En Cours: " + '0' + dataGridViewListUsereEnCours.Rows.Count.ToString();
                }
                else
                {
                    labelNumberUserActive.Text = "Les Utilisateur(s) En Cours: " + dataGridViewListUsereEnCours.Rows.Count.ToString();
                }
            }
            else
            {
                labelNumberUserActive.Text = "L'Utilisateur En Cours :" + "00";
            }
        }

        private void chargerUtilisateurs(MySqlCommand command)
        {
            dataGridViewListUsereEnCours.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListUsereEnCours.RowTemplate.Height = 90;
            dataGridViewListUsereEnCours.DataSource = getUtilisateursEnCours(command);

            //Colonne 10 a l'index de l'image dans datagridview
            picCol = (DataGridViewImageColumn)dataGridViewListUsereEnCours.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewListUsereEnCours.AllowUserToAddRows = false;
        }

        private object getUtilisateursEnCours(MySqlCommand command)
        {
            string IDCode = Convert.ToString(IDCodeLabelAd.Text);
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.Add("@IDcode", MySqlDbType.VarChar).Value = IDCode;
            DataTable table = new DataTable();
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

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                checkBox.Text = "Mode synthétique";
                dataGridViewListUsereEnCours.Columns[5].Visible = false;
            }
            else
            {
                dataGridViewListUsereEnCours.Columns[5].Visible = true;
                checkBox.Text = "Prendre compte de tout";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                if (comboBoxSearch.SelectedItem.ToString().Equals("ID"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=true AND utilisateur.idCode=@IDcode AND utilisateur.id='" + textBoxSearch.Text.Trim() + "'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("PRENOM"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=true AND utilisateur.idCode=@IDcode AND utilisateur.prenomUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("NOM"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=true AND utilisateur.idCode=@IDcode AND utilisateur.nomUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("LOGIN"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=true AND utilisateur.idCode=@IDcode AND utilisateur.loginUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("ETABLISSEMENT"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=true AND utilisateur.AsConnected=true AND utilisateur.idCode=@IDcode AND etablissement.nomEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                MySqlCommand command = new MySqlCommand(query);
                chargerGrid(command);
                //Compter les nombres des utilisateurs desactives 
                CompterUserEnCours();

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
            dataGridViewListUsereEnCours.ReadOnly = true;

            dataGridViewListUsereEnCours.DataSource = getSearchUserEnCours(command);

            dataGridViewListUsereEnCours.AllowUserToAddRows = false;
        }

        private object getSearchUserEnCours(MySqlCommand command)
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
            textBoxSearch.Clear();
            textBoxSearch.Focus();
        }

       

    }
}

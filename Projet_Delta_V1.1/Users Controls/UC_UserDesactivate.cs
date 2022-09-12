using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projet_Delta_V1._1.Classes;
using MySql.Data.MySqlClient;

namespace Projet_Delta_V1._1.Users_Controls
{
    public partial class UC_UserDesactivate : UserControl
    {
        public UC_UserDesactivate()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        private void UC_UserDesactivate_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();
            //Chargement des utilisateurs en cours pour tous les etablissements 
            chargerUtilisateurs(new MySqlCommand("SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=False AND utilisateur.idCode=@IDcode"));
            //Compter les utilisateurs actives pour les etablissements en cours
            CompterUserDesactive();

            checkBox.Checked = true;
        }

        private void CompterUserDesactive()
        {
            if (dataGridViewListUserDesactive.Rows.Count > 0)
            {
                int nbre = Convert.ToInt32(dataGridViewListUserDesactive.Rows.Count);
                if (nbre <= 1)
                {
                    labelNumberUserActive.Text = "L'Utilisateur Désactivé: " + '0' + dataGridViewListUserDesactive.Rows.Count.ToString();
                }
                else if (nbre <= 9)
                {
                    labelNumberUserActive.Text = "Les Utilisateur(s) Désactivé(s): " + '0' + dataGridViewListUserDesactive.Rows.Count.ToString();
                }
                else
                {
                    labelNumberUserActive.Text = "Les Utilisateur(s) Désactivé(s): " + dataGridViewListUserDesactive.Rows.Count.ToString();
                }
            }
            else
            {
                labelNumberUserActive.Text = "L'Utilisateur Désactivé :" + "00";
            }
        }

        private void chargerUtilisateurs(MySqlCommand command)
        {
            dataGridViewListUserDesactive.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListUserDesactive.RowTemplate.Height = 90;
            dataGridViewListUserDesactive.DataSource = getUtilisateursDesactives(command);

            //Colonne 10 a l'index de l'image dans datagridview
            picCol = (DataGridViewImageColumn)dataGridViewListUserDesactive.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewListUserDesactive.AllowUserToAddRows = false;
        }

        private object getUtilisateursDesactives(MySqlCommand command)
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
                dataGridViewListUserDesactive.Columns[5].Visible = false;
            }
            else
            {
                dataGridViewListUserDesactive.Columns[5].Visible = true;
                checkBox.Text = "Prendre compte de tout";
            }
        }

        private void btnRestaurerUtilisateur_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir restauré cet Utilisateur?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (!utilisateurId.Equals(string.Empty))
                    {
                        restaurerUtilisateur(utilisateurId);

                        MessageBox.Show("Votre Utilisateur est restauré de la Corbeille!");

                        this.OnLoad(e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Utilisateur a restauré!");
            }
        }

        public bool restaurerUtilisateur(int utilisateurId)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `utilisateur` SET `etatCompte`=1 WHERE `etatCompte`=0 AND `id`=@ID AND `idCode`=@idCode AND AsConnected=0", db.getConnection);

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

        int utilisateurId;
        private void dataGridViewListUserDesactive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewListUserDesactive.SelectedRows)
            {
                utilisateurId = (int)item.Cells[0].Value;
            }
        }

        private void btnSupprimerUtilisateurDefinitivement_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir supprimé cet Utilisateur définitivement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (!utilisateurId.Equals(string.Empty))
                    {
                        supprimerUtilisateur(utilisateurId);

                        MessageBox.Show("Votre Utilisateur est supprimé de l'application !");

                        this.OnLoad(e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Utilisateur a supprimé!");
            }
        }

        public bool supprimerUtilisateur(int utilisateurId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `utilisateur` WHERE `etatCompte`=0 AND `id`=@ID AND `idCode`=@idCode AND AsConnected=0", db.getConnection);

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

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                if (comboBoxSearch.SelectedItem.ToString().Equals("ID"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=false AND utilisateur.idCode=@IDcode AND utilisateur.id='" + textBoxSearch.Text.Trim() + "'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("PRENOM"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=false AND utilisateur.idCode=@IDcode AND utilisateur.prenomUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("NOM"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=false AND utilisateur.idCode=@IDcode AND utilisateur.nomUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("LOGIN"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=false AND utilisateur.idCode=@IDcode AND utilisateur.loginUtilisateur LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                else if (comboBoxSearch.SelectedItem.ToString().Equals("ETABLISSEMENT"))
                {
                    query = "SELECT utilisateur.id as ID, utilisateur.prenomUtilisateur as Prenom, utilisateur.nomUtilisateur as Nom, utilisateur.loginUtilisateur as Login, utilisateur.typeUtilisateur as 'Type Utilisateur',utilisateur.logged as Logged,utilisateur.etablissement as 'CODE',etablissement.nomEtab as Etablissement, utilisateur.picture as Image FROM utilisateur INNER JOIN etablissement ON etablissement.codeEtab=utilisateur.etablissement WHERE utilisateur.etatCompte=false AND utilisateur.idCode=@IDcode AND etablissement.nomEtab LIKE '%" + textBoxSearch.Text.Trim() + "%'";
                }
                MySqlCommand command = new MySqlCommand(query);
                chargerGrid(command);
                //Compter les nombres des utilisateurs desactives 
                CompterUserDesactive();

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
            dataGridViewListUserDesactive.ReadOnly = true;

            dataGridViewListUserDesactive.DataSource = getSearchUserDesactive(command);

            dataGridViewListUserDesactive.AllowUserToAddRows = false;
        }

        private object getSearchUserDesactive(MySqlCommand command)
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

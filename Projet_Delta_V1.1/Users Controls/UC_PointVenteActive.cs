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
using Projet_Delta_V1._1.Forms;
using Projet_Delta_V1._1.Classes;

namespace Projet_Delta_V1._1.Users_Controls
{
    public partial class UC_PointVenteActive : UserControl
    {
        public UC_PointVenteActive()
        {
            InitializeComponent();
        }

        MY_DB db = new MY_DB();
        private void btnNouvelEtablissement_Click(object sender, EventArgs e)
        {
            using(AjouterEtablissementForm AjF=new AjouterEtablissementForm())
            {
                AjF.ShowDialog();
                this.OnLoad(e);
            }
        }

        string etablissementId;

        private void UC_PointVenteActive_Load(object sender, EventArgs e)
        {
            //Affichage Image et Username de l'utilisateur connecté
            getImageAndLoginAd();
            //Chargement des etablissements en cours
            chargerEtablissements(new MySqlCommand("SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation', `pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND `idCodeEtab`=@IDCode"));
            //Compter les nombres des points des ventes actives
            CompterPointVenteActive();
        }

        private void CompterPointVenteActive()
        {
            if (dataGridViewListEtablissement.Rows.Count > 0)
            {
                int nbre = Convert.ToInt32(dataGridViewListEtablissement.Rows.Count);
                if (nbre <= 1)
                {
                    labelNumberPointVenteActive.Text ="Le Point de Vente activé: "+ '0' + dataGridViewListEtablissement.Rows.Count.ToString();
                }
                else if (nbre <= 9)
                {
                    labelNumberPointVenteActive.Text ="Les Point(s) de(s) Vente(s) Activé(s):  "+ '0' + dataGridViewListEtablissement.Rows.Count.ToString();
                }
                else
                {
                    labelNumberPointVenteActive.Text ="Les Point(s) de(s) Vente(s) Activé(s): "+ dataGridViewListEtablissement.Rows.Count.ToString();
                }
            }
            else
            {
                labelNumberPointVenteActive.Text ="Le Point de Vente Activé :"+ "00";
            }
        }

        private void chargerEtablissements(MySqlCommand command)
        {
            dataGridViewListEtablissement.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListEtablissement.RowTemplate.Height = 80;
            dataGridViewListEtablissement.DataSource = getEtablissements(command);

            //Colonne 10 a l'index de l'image dans datagridview
            picCol = (DataGridViewImageColumn)dataGridViewListEtablissement.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewListEtablissement.AllowUserToAddRows = false;
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

        private void btnSupprimerEtablissement_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Etes-vous sûr de vouloir supprimé cet Etablissement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (!etablissementId.Equals(string.Empty))
                    {
                        deleteEtablissement(etablissementId);

                        MessageBox.Show("Votre Etablissement est placé dans la Corbeille!");

                        this.OnLoad(e);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Veuillez cliquer d'abord sur l'Etablissement a supprimé!");
            }
        }

        public bool deleteEtablissement(string etablissementId)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `etablissement` SET `etatEtab`=0 WHERE `etatEtab`=1 AND `codeEtab`=@codeEtab AND `idCodeEtab`=@idCode AND connected=0", db.getConnection);

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

        private void dataGridViewListEtablissement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewListEtablissement.SelectedRows)
            {
                etablissementId = (string)item.Cells[0].Value;
            }
        }

        private void textBoxSearchEtab_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                if (comboBoxSearchEtab.SelectedItem.ToString().Equals("CODE"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND idCodeEtab=@IDCode AND codeEtab LIKE '%" + textBoxSearchEtab.Text.Trim() + "%'";
                }
                else if (comboBoxSearchEtab.SelectedItem.ToString().Equals("ETABLISSEMENT"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND idCodeEtab=@IDCode AND nomEtab LIKE '%" + textBoxSearchEtab.Text.Trim() + "%'";
                }
                else if (comboBoxSearchEtab.SelectedItem.ToString().Equals("VILLE"))
                {
                    query = "SELECT `codeEtab`, `nomEtab` as Etablissement, `adresseEtab` as Adresse, `registreCommercial` as Registre, `villeEtab` as Ville, `dateCreationEtab` as 'Date Creation',`pictures` as Logo FROM `etablissement` WHERE `etatEtab`=true AND idCodeEtab=@IDCode AND villeEtab LIKE '%" + textBoxSearchEtab.Text.Trim() + "%'";
                }
                MySqlCommand command = new MySqlCommand(query);
                chargerGrid(command);
                //Compter les nombres des points des ventes 
                CompterPointVenteActive();

                if (textBoxSearchEtab.Text == "")
                {
                    this.OnLoad(e);
                }
            }
            catch 
            {
                MessageBox.Show("Veuillez saisir le critère de recherche!");
                textBoxSearchEtab.Clear();
            }
        }

        private void chargerGrid(MySqlCommand command)
        {
            dataGridViewListEtablissement.ReadOnly = true;

            dataGridViewListEtablissement.DataSource=getSearchEtab(command);

            dataGridViewListEtablissement.AllowUserToAddRows = false;
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

        private void comboBoxSearchEtab_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxSearchEtab.Focus();
        }

        private void dataGridViewListEtablissement_MouseDown(object sender, MouseEventArgs e)
        {
            //Mettre le menu contextuel dans le datagridview par click gauche
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewListEtablissement.HitTest(e.X, e.Y);
                dataGridViewListEtablissement.Rows[hti.RowIndex].Selected = true;
                contextMenuStrip1.Show(dataGridViewListEtablissement, e.X, e.Y);
            }
        }

        private void dataGridViewListEtablissement_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridViewListEtablissement.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            string etablissementAdId = dataGridViewListEtablissement.Rows[index].Cells["codeEtab"].Value.ToString();

            showUpdateEtablissementAd(etablissementAdId, true);
        }

        private void showUpdateEtablissementAd(string etablissementAdId, bool etabliss)
        {
            AjouterEtablissementForm modiEtablissementF = new AjouterEtablissementForm();

            modiEtablissementF.etablissementAdId = etablissementAdId;

            modiEtablissementF.isUpdateEtablissement = etabliss;

            modiEtablissementF.ShowDialog();

            UC_PointVenteActive_Load(null, null);
        }

        private void modiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridViewListEtablissement.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            string etablissementAdId = dataGridViewListEtablissement.Rows[index].Cells["codeEtab"].Value.ToString();

            showUpdateEtablissementAd(etablissementAdId, true);
        }

      

       
    }
}

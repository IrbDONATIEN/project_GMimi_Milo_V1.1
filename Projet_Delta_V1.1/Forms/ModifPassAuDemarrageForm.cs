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
    public partial class ModifPassAuDemarrageForm : Form
    {
        
        public ModifPassAuDemarrageForm()
        {
            InitializeComponent();
        }

        MY_DB db=new MY_DB();

        private void ModifPassAuDemarrageForm_Load(object sender, EventArgs e)
        {
            //Fonction d'affichage de la fenetre de modification à la connexion de l'utilisateur
            AfficherMotdePasse();
        }

        public void AfficherMotdePasse()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE id=@uid", db.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                textBoxLogin.Text = Convert.ToString(table.Rows[0][3]);

                textBoxAncienPass.Text=Convert.ToString(table.Rows[0][4]);

                PrenomTextBox.Text = Convert.ToString(table.Rows[0][1]);

                NomTextBox.Text= Convert.ToString(table.Rows[0][2]);

                //Affichage de l'image de l'utilisateur en cours
                byte[] pic = (byte[])table.Rows[0]["picture"];

                MemoryStream picture = new MemoryStream(pic);

                PictureBox.Image = Image.FromStream(picture);

                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnValiderMotdePass_Click(object sender, EventArgs e)
        {
            string motdepasse = Convert.ToString(textBoxNouveauPass.Text);

            string motdepassec = Convert.ToString(textBoxConfirmerNouveauPass.Text);

            string ancienpassword = Convert.ToString(textBoxAncienPass.Text);

            string login = Convert.ToString(textBoxLogin.Text);

            int id = Convert.ToInt32(Globals.GlobalUserId);

            int valider = Convert.ToInt32(0);

            if (motdepasse.Trim().Equals("") || motdepassec.Trim().Equals("") || login.Trim().Equals("") || ancienpassword.Trim().Equals(""))
            {
                MessageBox.Show("Champs nouveau mot de passe et confirmation mot de passe est obligatoire!","Modifier Mot de Passe",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (motdepasse == motdepassec)
                {
                    if (VerificationLogin(login))
                    {
                       
                         if (!Verification(motdepasse))
                         {
                             UTILISATEUR user = new UTILISATEUR();

                             if(user.modificationMotdePasseAuDemarrage(id,motdepasse,valider))
                             {
                                 MessageBox.Show("Modification du Nouveau Mot de Passe reussi!","Modification Mot de Passe",MessageBoxButtons.OK,MessageBoxIcon.Information);

                                 this.OnLoad(e);

                                 this.Close();
                             }
                             else
                             {
                                  MessageBox.Show("Erreur rencontree lors de l'exécution!","Modification Mot de Passe",MessageBoxButtons.OK,MessageBoxIcon.Error);
                             }
                          }
                          else
                          {
                               MessageBox.Show("Veuillez Utiliser un autre mot de passe!", "Vérification d'Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          }
                    }
                    else
                    {
                        MessageBox.Show("Le Login Utilisateur doit etre conforme!", "Vérification d'Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Les deux mot de passe ne sont pas conforment!","Conformite Mot de Passe",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        //Fonction de verification de la conformite du login dans la base de donnees
        private bool VerificationLogin(string login)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE `loginUtilisateur`=@lgn AND `id`=@uid", db.getConnection);
            command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //Retourne faux si le login existe déjà
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        //Fonction de verification de la differenciation  de mot de passe par l'utilisateur se trouvant  dans la base de donnees
        private bool Verification(string motdepasse)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `utilisateur` WHERE `passUtilisateur`=MD5(@motdepasse) AND `id`=@uid", db.getConnection);
            command.Parameters.Add("@motdepasse", MySqlDbType.VarChar).Value = motdepasse;
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //Retourne faux si le mot de passe existe déjà
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

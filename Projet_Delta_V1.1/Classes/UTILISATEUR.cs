using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projet_Delta_V1._1.Classes
{
    public class UTILISATEUR
    {
        MY_DB db = new MY_DB();

        //La fonction de la vérification si le login  existe dans la base de données
        //précisement dans la table utilisateur
        //listbox C# + Mysql
        public bool loginExists(string login, string etablissement, string operation, int userid = 0)
        {
            string query = " ";
            if (operation == "register")
            {
                query = "SELECT * FROM `utilisateur` WHERE etablissement=@etablissement AND `loginUtilisateur`=@lgn";
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM `utilisateur` WHERE etablissement=@etablissement AND `loginUtilisateur`=@lgn AND id<>@uid";
            }

            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userid;
            command.Parameters.Add("@etablissement", MySqlDbType.VarChar).Value = etablissement;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            //Si user existe retourne vrai ou true en anglais
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //L'insertion d'un nouveau utilisateur dans la base de données
        public bool insererUtilisateur(string prenom, string nom, string login, string password, string typeUtilisateur, Boolean etatCompte, DateTime dateCreation, string heureCreation, string etabliss, MemoryStream picture, string IDCode,int valider)
        {
            string log = "0";

            using (MySqlCommand command = new MySqlCommand("INSERT INTO `utilisateur`(`prenomUtilisateur`, `nomUtilisateur`, `loginUtilisateur`, `passUtilisateur`, `typeUtilisateur`, `etatCompte`, `dateCreation`, `heureCreation`,`logged`,`etablissement`,`picture`,`idCode`,`modifpassword`) VALUES (@pm,@nm,@lgn,MD5(@pass),@type,@etat,@date,@heure,@log,@etablis,@pic,@IDCode,@valider)", db.getConnection))
            {
                //@pm,@nm,@lgn,@pass,@type,@etat,@date,@heure,@etablis,@pic
                command.Parameters.Add("@pm", MySqlDbType.VarChar).Value = prenom;
                command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nom;
                command.Parameters.Add("@lgn", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@type", MySqlDbType.VarChar).Value = typeUtilisateur;
                command.Parameters.Add("@etat", MySqlDbType.Bit).Value = etatCompte;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateCreation;
                command.Parameters.Add("@heure", MySqlDbType.VarChar).Value = heureCreation;
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
                command.Parameters.Add("@etablis", MySqlDbType.VarChar).Value = etabliss;
                command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
                command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = IDCode;
                command.Parameters.Add("@valider", MySqlDbType.Int32).Value = valider;

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

        }

        //La création de la fonction pour modifier ou éditer les données de l'utilisateur en cours
        public bool updateUtilisateur(int userid, string prenom, string nom, string login, string password, string etablissement, MemoryStream picture, string type, bool etat,int valider)
        {

            MySqlCommand command = new MySqlCommand("UPDATE `utilisateur` SET `prenomUtilisateur`=@prenom,`nomUtilisateur`=@nom,`loginUtilisateur`=@login,`passUtilisateur`=MD5(@pass),`typeUtilisateur`=@type,`etatCompte`=@etat,`etablissement`=@codeEtab,`picture`=@pic,`modifpassword`=@valider WHERE etablissement=@codeEtab AND `id`=@uid", db.getConnection);

            command.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.Add("@codeEtab", MySqlDbType.VarChar).Value = etablissement;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@etat", MySqlDbType.Bit).Value = etat;
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userid;
            command.Parameters.Add("@valider", MySqlDbType.Int32).Value = valider;
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

        //La creation de la fonction de modification de mot de passe au demarrage de l'application par l'utilisateur
        public bool modificationMotdePasseAuDemarrage(int userid, string motdepassedemarrage, int valider)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `utilisateur` SET `passUtilisateur`=MD5(@motpass),`modifpassword`=@valider WHERE `id`=@uid", db.getConnection);

            command.Parameters.Add("@motpass", MySqlDbType.VarChar).Value = motdepassedemarrage;

            command.Parameters.Add("@valider", MySqlDbType.Int32).Value = valider;

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userid;

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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace Projet_Delta_V1._1.Classes
{
    public class ETABLISSEMENT
    {
        MY_DB db = new MY_DB();

        //Vérifier si le nom établissement qu'on a saisie existe dans la base de données 
        public bool verifEtablissementNom(string nomEtab)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `etablissement` WHERE `nomEtab`=@nom", db.getConnection);

            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nomEtab;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //Retourne faux si le nom établissement existe déjà
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        //L'insertion d'un nouvel établissement dans la base de données
        public bool insererEtablissement(string codeEtab, string nomEtab, string adresseEtab, string registreCommercial, string villeEtab, DateTime dateCreationEtab, Boolean etatEtab, MemoryStream pictures, string idCodeEtab)
        {
            using (MySqlCommand command = new MySqlCommand("INSERT INTO `etablissement`(`codeEtab`, `nomEtab`, `adresseEtab`, `registreCommercial`, `villeEtab`, `dateCreationEtab`, `etatEtab`, `pictures`, `idCodeEtab`) VALUES (@code,@nom,@addr,@reg,@ville,@date,@etat,@pic,@IDCode)", db.getConnection))
            {
                //@code,@nom,@addr,@reg,@ville,@date,@etat
                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = codeEtab;
                command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nomEtab;
                command.Parameters.Add("@addr", MySqlDbType.Text).Value = adresseEtab;
                command.Parameters.Add("@reg", MySqlDbType.VarChar).Value = registreCommercial;
                command.Parameters.Add("@ville", MySqlDbType.VarChar).Value =villeEtab;
                command.Parameters.Add("@etat", MySqlDbType.Bit).Value = etatEtab;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateCreationEtab;
                command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = idCodeEtab;
                command.Parameters.Add("@pic", MySqlDbType.Blob).Value = pictures.ToArray();

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

        //La modification d'un ancien établissement dans la base de données
        public bool modifierEtablissement(string codeEtab, string nomEtab, string adresseEtab, string registreCommercial, string villeEtab, DateTime dateCreationEtab, Boolean etatEtab, MemoryStream pictures, string idCodeEtab)
        {
            using (MySqlCommand command = new MySqlCommand("UPDATE `etablissement` SET `nomEtab`=@nom,`adresseEtab`=@addr,`registreCommercial`=@reg,`villeEtab`=@ville,`dateCreationEtab`=@date,`etatEtab`=@etat,`pictures`=@pic,`idCodeEtab`=@IDCode WHERE codeEtab=@code", db.getConnection))
            {
                //@code,@nom,@addr,@reg,@ville,@etat,@date,@IDCode,@pic
                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = codeEtab;
                command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nomEtab;
                command.Parameters.Add("@addr", MySqlDbType.Text).Value = adresseEtab;
                command.Parameters.Add("@reg", MySqlDbType.VarChar).Value = registreCommercial;
                command.Parameters.Add("@ville", MySqlDbType.VarChar).Value = villeEtab;
                command.Parameters.Add("@etat", MySqlDbType.Bit).Value = etatEtab;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateCreationEtab;
                command.Parameters.Add("@IDCode", MySqlDbType.VarChar).Value = idCodeEtab;
                command.Parameters.Add("@pic", MySqlDbType.Blob).Value = pictures.ToArray();

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
}

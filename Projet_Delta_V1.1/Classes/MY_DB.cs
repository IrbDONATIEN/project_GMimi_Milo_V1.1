using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Delta_V1._1.Classes
{
    public class MY_DB
    {
        //La connection à la base de données crée
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projet_delta_v11");

        //La ligne de code précédente retourne 
        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        //Ouverture de la connection à la base de données
        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        //Fermeture de la connection à la base de données 
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}

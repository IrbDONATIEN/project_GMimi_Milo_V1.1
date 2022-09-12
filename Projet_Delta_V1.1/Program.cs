using Projet_Delta_V1._1.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Delta_V1._1
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Demarrage());

            /*Demarrage fLogin = new Demarrage();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                //Application.Run(new GMimi_Milo());
            }
            else
            {
                Application.Exit();
            }*/
        }
    }
}

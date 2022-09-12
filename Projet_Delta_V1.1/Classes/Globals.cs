using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Delta_V1._1.Classes
{
    public class Globals
    {
        public static int GlobalUserId { get; private set; }

        public static void SetGlobalUserId(int userid)
        {
            GlobalUserId = userid;
        }
    }
}

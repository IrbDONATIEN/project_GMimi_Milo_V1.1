using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Delta_V1._1.Classes
{
    public class GlobalsAdmin
    {
        public static int GlobalUserAdId { get; private set; }

        public static void SetGlobalUseradId(int useradId)
        {
            GlobalUserAdId = useradId;
        }
    }
}

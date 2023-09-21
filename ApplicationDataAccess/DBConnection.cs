using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ApplicationDataAccess
{
    public class DBConnection
    {
        public static string ConnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
    }
}

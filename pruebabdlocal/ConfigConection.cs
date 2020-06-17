using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace pruebabdlocal
{
    public static class ConfigConection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    }
}

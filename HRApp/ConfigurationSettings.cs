using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HRApp
{
    public static class ConfigurationSettings
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["OEADB"].ConnectionString;
    }
}
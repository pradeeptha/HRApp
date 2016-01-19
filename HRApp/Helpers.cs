using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRApp
{
    public class Helpers
    {
        public static int GetUserIdByUserName(string userName)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("GetUserIdByUserName", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("UserName", userName);
                cmd.Parameters.AddRange(new SqlParameter[] { param1 });
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int GetRoleByUserName(string userName)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("GetRoleByUserName", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("UserName", userName);
                cmd.Parameters.AddRange(new SqlParameter[] { param1 });
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
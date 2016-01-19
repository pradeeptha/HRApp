using Microsoft.AspNet.Identity;
using HRApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HRApp
{
    public class OEAUserStore : IQueryableUserStore<OEAUser, int>, IUserPasswordStore<OEAUser,int>, 
        IUserLoginStore<OEAUser, int>,
        IUserRoleStore<OEAUser,int>,
        IUserEmailStore<OEAUser,int>,
        IUserLockoutStore<OEAUser,int>,
        IUserTwoFactorStore<OEAUser,int>
    {
        
        
        IQueryable<OEAUser> IQueryableUserStore<OEAUser, int>.Users
        {
            get { throw new NotImplementedException(); }
        }

        Task IUserStore<OEAUser, int>.CreateAsync(OEAUser user)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("CreateUser", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("UserName", user.UserName);
                SqlParameter param2 = new SqlParameter("PasswordHash", user.Password);
                SqlParameter param3 = new SqlParameter("MobileNumber", user.MobileNumber);
                SqlParameter param4 = new SqlParameter("City", user.City);
                cmd.Parameters.AddRange(new SqlParameter[] { param1, param2, param3, param4 });
                cmd.ExecuteNonQuery();


            }
            return Task.FromResult(1);
        }

        Task IUserStore<OEAUser, int>.DeleteAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task<OEAUser> IUserStore<OEAUser, int>.FindByIdAsync(int userId)
        {
            OEAUser user = new OEAUser();
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Users where UserId = '" + userId + "'", sqlconn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    user.UserId = (int)row["UserId"];
                    user.UserName = row["UserName"].ToString();
                    user.Password = row["PasswordHash"].ToString();
                    user.MobileNumber = row["MobileNumber"].ToString();
                    user.City = row["City"].ToString();
                }
            }

            return Task.FromResult(user);
        }

        Task<OEAUser> IUserStore<OEAUser, int>.FindByNameAsync(string userName)
        {
            OEAUser user = new OEAUser();
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Users where UserName = '" + userName + "'", sqlconn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    user.UserId = (int)row["UserId"];
                    user.UserName = row["UserName"].ToString();
                    user.Password = row["PasswordHash"].ToString();
                    user.MobileNumber = row["MobileNumber"].ToString();
                    user.City = row["City"].ToString();
                }
            }

            return Task.FromResult(user);
        }

        Task IUserStore<OEAUser, int>.UpdateAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPasswordStore<OEAUser, int>.GetPasswordHashAsync(OEAUser user)
        {
            return Task.FromResult(user.Password);
        }

        Task<bool> IUserPasswordStore<OEAUser, int>.HasPasswordAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserPasswordStore<OEAUser, int>.SetPasswordHashAsync(OEAUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        Task IUserLoginStore<OEAUser, int>.AddLoginAsync(OEAUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        Task<OEAUser> IUserLoginStore<OEAUser, int>.FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        Task<IList<UserLoginInfo>> IUserLoginStore<OEAUser, int>.GetLoginsAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserLoginStore<OEAUser, int>.RemoveLoginAsync(OEAUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        Task IUserRoleStore<OEAUser, int>.AddToRoleAsync(OEAUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        Task<IList<string>> IUserRoleStore<OEAUser, int>.GetRolesAsync(OEAUser user)
        {
            IList<string> roles = new List<string>();
            //using (SqlConnection sqlconn = new SqlConnection(connectionstring))
            //{
            //    sqlconn.Open();
            //    SqlCommand cmd = new SqlCommand("GetRoles", sqlconn);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    SqlParameter param1 = new SqlParameter("userid", user.UserId);
            //    cmd.Parameters.AddRange(new SqlParameter[] { param1 });
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    dataAdapter.Fill(ds);
            //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        foreach(DataRow row in ds.Tables[0].Rows)
            //        {
            //            roles.Add(row["RoleName"].ToString());
            //        }

                   
            //    }
            //}

            return Task.FromResult(roles);
        }

        Task<bool> IUserRoleStore<OEAUser, int>.IsInRoleAsync(OEAUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        Task IUserRoleStore<OEAUser, int>.RemoveFromRoleAsync(OEAUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        Task<OEAUser> IUserEmailStore<OEAUser, int>.FindByEmailAsync(string email)
        {
            return Task.FromResult(new OEAUser());
        }

        Task<string> IUserEmailStore<OEAUser, int>.GetEmailAsync(OEAUser user)
        {
            return Task.FromResult<string>("test@test.com");
        }

        Task<bool> IUserEmailStore<OEAUser, int>.GetEmailConfirmedAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<OEAUser, int>.SetEmailAsync(OEAUser user, string email)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<OEAUser, int>.SetEmailConfirmedAsync(OEAUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        Task<int> IUserLockoutStore<OEAUser, int>.GetAccessFailedCountAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserLockoutStore<OEAUser, int>.GetLockoutEnabledAsync(OEAUser user)
        {
            return Task.FromResult(false);
        }

        Task<DateTimeOffset> IUserLockoutStore<OEAUser, int>.GetLockoutEndDateAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task<int> IUserLockoutStore<OEAUser, int>.IncrementAccessFailedCountAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserLockoutStore<OEAUser, int>.ResetAccessFailedCountAsync(OEAUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserLockoutStore<OEAUser, int>.SetLockoutEnabledAsync(OEAUser user, bool enabled)
        {
            return Task.FromResult(1);
        }

        Task IUserLockoutStore<OEAUser, int>.SetLockoutEndDateAsync(OEAUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(1);
        }

        Task<bool> IUserTwoFactorStore<OEAUser, int>.GetTwoFactorEnabledAsync(OEAUser user)
        {
            return Task.FromResult(false);
        }

        Task IUserTwoFactorStore<OEAUser, int>.SetTwoFactorEnabledAsync(OEAUser user, bool enabled)
        {
            return Task.FromResult(1);
        }
    }
}
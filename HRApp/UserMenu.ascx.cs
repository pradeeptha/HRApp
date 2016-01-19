using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRApp
{
    public partial class UserMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.IsInRole("Admin"))
            {

            }
        }
    }
}
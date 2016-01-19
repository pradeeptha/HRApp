using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRApp
{
    public partial class SubmitRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationSettings.connectionstring);
                conn.Open();
                string query = "SELECT ServiceRequestId,ServiceRequestType FROM ServiceRequestTypes ";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable table = new DataTable();


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);

                ServiceRequestsddl.DataSource = table;
                ServiceRequestsddl.DataValueField = "ServiceRequestId"; //The Value of the DropDownList, to get it you should call ddlDepartments.SelectedValue;
                ServiceRequestsddl.DataTextField = "ServiceRequestType"; //The Name shown of the DropDownList.
                ServiceRequestsddl.DataBind();

                
                query = "SELECT DepartmentId,DepartmentName FROM Departments ";
                cmd = new SqlCommand(query, conn);
                
                adapter = new SqlDataAdapter(cmd);
                table.Clear();
                adapter.Fill(table);

                Departmentsddl.DataSource = table;
                Departmentsddl.DataValueField = "DepartmentId"; //The Value of the DropDownList, to get it you should call ddlDepartments.SelectedValue;
                Departmentsddl.DataTextField = "DepartmentName"; //The Name shown of the DropDownList.
                Departmentsddl.DataBind();
            }
        }

        protected void CreateServiceRequest_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.connectionstring))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("CreateServiceRequest", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("UserId",Helpers.GetUserIdByUserName(User.Identity.Name));
                SqlParameter param2 = new SqlParameter("DepartmentId", Departmentsddl.SelectedItem.Value);
                SqlParameter param3 = new SqlParameter("ServiceRequestTypeID", ServiceRequestsddl.SelectedItem.Value);
                SqlParameter param4 = new SqlParameter("Issue", Issue.Text);
                cmd.Parameters.AddRange(new SqlParameter[] { param1, param2, param3, param4 });
                cmd.ExecuteNonQuery();
            }
        }
    }
}
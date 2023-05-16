using FinanceClient.FinanceServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceClient
{
    public partial class Login : System.Web.UI.Page
    {
        FinanceWebServiceSoapClient client = new FinanceWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string result = client.Login(email.Value, pwd.Value);
            if (result == "Success")
            {
                Session["email"] = email.Value;
                Response.Redirect("~/MyFinances.aspx");
            }
            else
            {
                errorLbl.Text = "Wrong Login Creditials";
            }
        }
    }
}
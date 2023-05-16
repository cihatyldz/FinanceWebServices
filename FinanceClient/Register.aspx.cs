using FinanceClient.FinanceServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceClient
{
    public partial class Register : System.Web.UI.Page
    {
        FinanceWebServiceSoapClient client = new FinanceWebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            var result = client.Register(name.Value, email.Value, pwd.Value);
            if (result == "Success")
            {
                resLbl.Text = "Registration is a success";
            }
            else
            {
                resLbl.Text = result;
            }
        }
    }
}
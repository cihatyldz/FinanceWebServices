using FinanceClient.FinanceServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceClient
{
    public partial class MyFinances : System.Web.UI.Page
    {
        FinanceWebServiceSoapClient client = new FinanceWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            MyRecords();
        }

        protected void AddRecord_Click(object sender, EventArgs e)
        {

            client.AddRecord(desc.Value, Convert.ToInt32(amount.Value), Session["email"].ToString());
            Response.Redirect("MyFinances.aspx");
        }

        public void MyRecords()
        {
            rpt.DataSource = client.GetAllRecords(Session["email"].ToString());
            rpt.DataBind();
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                client.DeleteRecord(id);
                Response.Redirect("MyFinances.aspx");
            }
        }
    }
}
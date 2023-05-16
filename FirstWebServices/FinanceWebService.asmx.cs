using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography;
using System.Text;

namespace FirstWebServices
{
    /// <summary>
    /// Summary description for FinanceWebService
    /// </summary>
    [WebService(Namespace = "https://localhost:44324/FinanceWebService.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FinanceWebService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Greetings")]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod(Description = "Register new user")]
        public string Register(string fullname, string email, string pwd)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Email from Users where Email=@email";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            var i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Insert into Users(FullName,Email,Password) values(@name,@email,@pwd)";
                cmd1.Parameters.AddWithValue("@email", email);
                cmd1.Parameters.AddWithValue("@name", fullname);
                cmd1.Parameters.AddWithValue("@pwd", Encrypt(pwd));
                cmd1.ExecuteNonQuery();
                con.Close();
                return "Success";
            }
            else
            {
                return "There is already a registered user with this email";
            }
        }



        [WebMethod(Description = "Sign in of a registered user")]
        public string Login(string email, string pwd)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select*from Users where Email= @user and Password=@password";
            cmd.Parameters.AddWithValue("@user", email);
            cmd.Parameters.AddWithValue("@password", Encrypt(pwd));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            var i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 1)
            {
                return "Success";
            }
            else
            {
                return "Fail";
            }
        }


        [WebMethod(Description = "Add financial record")]
        public void AddRecord(string desc, int amount, string email)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string str = "insert into Finances(Description,Amount,Email) values(@desc,@amount,@email)";
            SqlCommand cmd1 = new SqlCommand(str, conn);
            cmd1.Parameters.AddWithValue("@desc", desc);
            cmd1.Parameters.AddWithValue("@amount", amount);
            cmd1.Parameters.AddWithValue("@email", email);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }


        [WebMethod(Description = "Delete financial record")]
        public void DeleteRecord(int id)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string str = "Delete from Finances where ID=@id";
            SqlCommand cmd1 = new SqlCommand(str, conn);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }



        [WebMethod(Description = "Update financial record")]
        public void UpdateRecord(int id, string desc, int amount)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string str = "update Finances set Description=@desc,Amount=@amount where ID=@id";
            SqlCommand cmd1 = new SqlCommand(str, conn);
            cmd1.Parameters.AddWithValue("@desc", desc);
            cmd1.Parameters.AddWithValue("@amount", amount);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }



        [WebMethod(Description = "Get all financial records")]
        public DataTable GetAllRecords(string email)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Finances] where Email=@useremail", con);
            cmd.Parameters.AddWithValue("@useremail", email);
            DataTable dt = new DataTable("FinancesDt");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }



        static string Encrypt(string value)//for encryption of text
        {

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }


    }
}

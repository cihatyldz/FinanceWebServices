using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FirstWebServices
{
    /// <summary>
    /// Summary description for GreetingServices
    /// </summary>
    [WebService(Namespace = "https://localhost:44324/GreetingServices.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GreetingServices : System.Web.Services.WebService
    {

        [WebMethod(Description = "This is a Hello World")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string PersonalGreeting(string name)
        {
            return "Hello " + name ;
        }



        [WebMethod(Description = "This is a Hello Worls with a year", MessageName = "HelloWithYear")]
        public string PersonalGreeting(int year)
        {
            return "Hello World it is year " + year;
        }


    }
}

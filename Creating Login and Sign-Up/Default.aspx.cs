using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Creating_Login_and_Sign_Up
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string INFO = User.Identity.Name + ",";
            INFO += User.Identity.AuthenticationType + ",";

            INFO += User.Identity.IsAuthenticated;

            INFO += User.IsInRole("CM");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp2007_Assignment2
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //logout
            var AuthenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            AuthenticationManager.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}
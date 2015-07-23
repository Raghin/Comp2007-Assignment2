using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Comp2007_Assignment2.Models;
using System.Web.ModelBinding;

namespace Comp2007_Assignment2
{
    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Books b = new Books();
                b.Name = txtName.Text;
                b.Genre = txtGenre.Text;
                b.AltName = txtAlt.Text;
                b.Length = txtLength.Text;
                conn.Books1.Add(b);
                conn.SaveChanges();
                Response.Redirect("books.aspx");
            }
        }
    }
}
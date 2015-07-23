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
            if(!IsPostBack)
            {
                if(Request.QueryString.Keys.Count > 0)
                {
                    getBook();
                }
            }
        }

        protected void getBook()
        {
            using(DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 BookID = Convert.ToInt32(Request.QueryString["BookID"]);

                var b = (from books in conn.Books1
                         where books.BookID == BookID
                         select books).FirstOrDefault();

                txtName.Text = b.Name;
                txtGenre.Text = b.Genre;
                txtAlt.Text = b.AltName;
                txtLength.Text = b.Length;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Books b = new Books();

                if(Request.QueryString.Count > 0)
                {
                    Int32 BookID = Convert.ToInt32(Request.QueryString["BookID"]);

                    b = (from books in conn.Books1
                         where books.BookID == BookID
                         select books).FirstOrDefault();
                }

                b.Name = txtName.Text;
                b.Genre = txtGenre.Text;
                b.AltName = txtAlt.Text;
                b.Length = txtLength.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Books1.Add(b);
                }

                conn.SaveChanges();
                Response.Redirect("books.aspx");
            }
        }
    }
}
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
    public partial class show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    getShow();
                }
            }
        }

        protected void getShow()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 ShowID = Convert.ToInt32(Request.QueryString["ShowID"]);

                var s = (from Show in conn.Shows1
                         where Show.ShowID == ShowID
                         select Show).FirstOrDefault();

                txtName.Text = s.Name;
                txtGenre.Text = s.Genre;
                txtAlt.Text = s.AltName;
                txtLength.Text = s.Length;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Shows s = new Shows();

                if (Request.QueryString.Count > 0)
                {
                    Int32 ShowID = Convert.ToInt32(Request.QueryString["ShowID"]);

                    s = (from Show in conn.Shows1
                         where Show.ShowID == ShowID
                         select Show).FirstOrDefault();
                }

                s.Name = txtName.Text;
                s.Genre = txtGenre.Text;
                s.AltName = txtAlt.Text;
                s.Length = txtLength.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Shows1.Add(s);
                }

                conn.SaveChanges();
                Response.Redirect("shows.aspx");
            }
        }
    }
}
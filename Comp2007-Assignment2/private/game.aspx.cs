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
    public partial class game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    getGame();
                }
            }
        }

        protected void getGame()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                var b = (from Game in conn.Games1
                         where Game.GameID == GameID
                         select Game).FirstOrDefault();

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
                Games b = new Games();

                if (Request.QueryString.Count > 0)
                {
                    Int32 GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    b = (from Game in conn.Games1
                         where Game.GameID == GameID
                         select Game).FirstOrDefault();
                }

                b.Name = txtName.Text;
                b.Genre = txtGenre.Text;
                b.AltName = txtAlt.Text;
                b.Length = txtLength.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Games1.Add(b);
                }

                conn.SaveChanges();
                Response.Redirect("games.aspx");
            }
        }
    }
}
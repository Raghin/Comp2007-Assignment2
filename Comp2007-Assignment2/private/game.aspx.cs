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

                var g = (from Game in conn.Games1
                         where Game.GameID == GameID
                         select Game).FirstOrDefault();

                txtName.Text = g.Name;
                txtGenre.Text = g.Genre;
                txtAlt.Text = g.AltName;
                txtLength.Text = g.Length;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Games g = new Games();

                if (Request.QueryString.Count > 0)
                {
                    Int32 GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    g = (from Game in conn.Games1
                         where Game.GameID == GameID
                         select Game).FirstOrDefault();
                }

                g.Name = txtName.Text;
                g.Genre = txtGenre.Text;
                g.AltName = txtAlt.Text;
                g.Length = txtLength.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Games1.Add(g);
                }

                conn.SaveChanges();
                Response.Redirect("games.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference entity framework models
using Comp2007_Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007_Assignment2
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "Name";
                getItems();
            }
        }

        protected void getItems()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //var item = (from g in conn.Games1 select new { g.Name, g.Genre, g.AltName, g.Length }).Union(from b in conn.Books1 select new { b.Name, b.Genre, b.AltName, b.Length }).Union(from s in conn.Shows1 select new { s.Name, s.Genre, s.AltName, s.Length });
                var game = (from g in conn.Games1 select g);
                var book = (from b in conn.Books1 select b);
                var show = (from s in conn.Shows1 select s);

                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdgames.DataSource = game.AsQueryable().OrderBy(Sort).ToList();
                grdBooks.DataSource = book.AsQueryable().OrderBy(Sort).ToList();
                grdShows.DataSource = show.AsQueryable().OrderBy(Sort).ToList();
                grdgames.DataBind();
                grdBooks.DataBind();
                grdShows.DataBind();
            }
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            getItems();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdgames_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdgames.PageIndex = e.NewPageIndex;
            getItems();
        }

        protected void grdBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBooks.PageIndex = e.NewPageIndex;
            getItems();
        }

        protected void grdShows_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShows.PageIndex = e.NewPageIndex;
            getItems();
        }

        protected void ddlView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlView.SelectedValue == "All")
            {
                viewBooks.Visible = true;
                viewGames.Visible = true;
                viewShows.Visible = true;
            }
            else if(ddlView.SelectedValue == "Games")
            {
                viewBooks.Visible = false;
                viewGames.Visible = true;
                viewShows.Visible = false;
            }
            else if(ddlView.SelectedValue == "Books")
            {
                viewBooks.Visible = true;
                viewGames.Visible = false;
                viewShows.Visible = false;
            }
            else if(ddlView.SelectedValue == "Shows")
            {
                viewBooks.Visible = false;
                viewGames.Visible = false;
                viewShows.Visible = true;
            }
        }

        protected void grdgames_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string ID = grdgames.DataKeys[currentRowIndex].Value.ToString();
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 GameID = Convert.ToInt32(ID);
                var userName = HttpContext.Current.User.Identity.Name;
                Records objR = new Records();
                AspNetUsers objU = (from u in conn.AspNetUsers1 where u.UserName == userName select u).FirstOrDefault();
                Games objG = (from g in conn.Games1 where g.GameID == GameID select g).FirstOrDefault();
                objR.UserID = objU.Id;
                objR.GameID = objG.GameID;
                objR.Status = false;
                objR.Progress = "None";

                conn.Records1.Add(objR);
                conn.SaveChanges();
            }
        }

        protected void grdBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string ID = grdBooks.DataKeys[currentRowIndex].Value.ToString();
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 BookID = Convert.ToInt32(ID);
                var userName = HttpContext.Current.User.Identity.Name;
                Records objR = new Records();
                AspNetUsers objU = (from u in conn.AspNetUsers1 where u.UserName == userName select u).FirstOrDefault();
                Books objB = (from b in conn.Books1 where b.BookID == BookID select b).FirstOrDefault();
                objR.UserID = objU.Id;
                objR.BookID = objB.BookID;
                objR.Status = false;
                objR.Progress = "None";

                conn.Records1.Add(objR);
                conn.SaveChanges();
            }
        }

        protected void grdShows_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string ID = grdShows.DataKeys[currentRowIndex].Value.ToString();
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 ShowID = Convert.ToInt32(ID);
                var userName = HttpContext.Current.User.Identity.Name;
                Records objR = new Records();
                AspNetUsers objU = (from u in conn.AspNetUsers1 where u.UserName == userName select u).FirstOrDefault();
                Shows objS = (from s in conn.Shows1 where s.ShowID == ShowID select s).FirstOrDefault();
                objR.UserID = objU.Id;
                objR.ShowID = objS.ShowID;
                objR.Status = false;
                objR.Progress = "None";

                conn.Records1.Add(objR);
                conn.SaveChanges();
            }
        }
    }
}
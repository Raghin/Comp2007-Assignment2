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
    public partial class games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "GameID";
                GetGames();
            }
        }

        protected void GetGames()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var game = from g in conn.Games1 select g;

                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdGames.DataSource = game.AsQueryable().OrderBy(Sort).ToList();
                grdGames.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdGames.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetGames();
        }

        protected void grdGames_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 GameID = Convert.ToInt32(grdGames.DataKeys[e.RowIndex].Values["GameID"]);

                var g = (from Game in conn.Games1
                         where Game.GameID == GameID
                         select Game).FirstOrDefault();

                conn.Games1.Remove(g);
                conn.SaveChanges();

                GetGames();
            }
        }

        protected void grdGames_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            GetGames();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdGames_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGames.PageIndex = e.NewPageIndex;
            GetGames();
        }

        protected void grdGames_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gameRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("game.aspx");
        }
    }
}
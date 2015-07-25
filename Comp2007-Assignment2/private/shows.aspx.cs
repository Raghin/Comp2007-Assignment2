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
    public partial class shows : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "ShowID";
                getShows();
            }
        }

        protected void getShows()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var show = from s in conn.Shows1 select s;

                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdShows.DataSource = show.AsQueryable().OrderBy(Sort).ToList();
                grdShows.DataBind();
            }
        }

        protected void showRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("show.aspx");
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdShows.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getShows();
        }

        protected void grdShows_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 ShowID = Convert.ToInt32(grdShows.DataKeys[e.RowIndex].Values["ShowID"]);

                var s = (from Show in conn.Shows1
                         where Show.ShowID == ShowID
                         select Show).FirstOrDefault();

                conn.Shows1.Remove(s);
                conn.SaveChanges();

                getShows();
            }
        }

        protected void grdShows_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdShows_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShows.PageIndex = e.NewPageIndex;
            getShows();
        }

        protected void grdShows_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            getShows();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }
    }
}
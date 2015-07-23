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
    public partial class temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "BookID";
                GetBooks();
            }
        }

        protected void GetBooks()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var book = from b in conn.Books1 select b;

                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdBooks.DataSource = book.AsQueryable().OrderBy(Sort).ToList();
                grdBooks.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdBooks.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetBooks();
        }

        protected void grdBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using(DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 BookID = Convert.ToInt32(grdBooks.DataKeys[e.RowIndex].Values["BookID"]);

                var b = (from books in conn.Books1
                         where books.BookID == BookID
                         select books).FirstOrDefault();

                conn.Books1.Remove(b);
                conn.SaveChanges();

                GetBooks();
            }
        }

        protected void grdBooks_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            GetBooks();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBooks.PageIndex = e.NewPageIndex;
            GetBooks();
        }

        protected void grdBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void bookRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("book.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference our entity framework models
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
    }
}
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
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "Name";
                getRecords();
            }
        }

        protected void getRecords()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var userName = HttpContext.Current.User.Identity.Name;
                AspNetUsers objU = (from u in conn.AspNetUsers1 where u.UserName == userName select u).FirstOrDefault();

                var record = (from r in conn.Records1
                              join s in conn.Shows1 on r.ShowID equals s.ShowID
                              where r.UserID == objU.Id
                              select new { r.RecordID, s.Name, s.Genre, s.AltName, s.Length, r.Progress}).Union(from r in conn.Records1
                              join b in conn.Books1 on r.BookID equals b.BookID
                              where r.UserID == objU.Id
                              select new { r.RecordID, b.Name, b.Genre, b.AltName, b.Length, r.Progress}).Union(from r in conn.Records1
                              join g in conn.Games1 on r.GameID equals g.GameID
                              where r.UserID == objU.Id
                              select new { r.RecordID, g.Name, g.Genre, g.AltName, g.Length, r.Progress});

                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdRecords.DataSource = record.AsQueryable().OrderBy(Sort).ToList();
                grdRecords.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdRecords.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getRecords();
        }

        protected void grdRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Int32 RecordID = Convert.ToInt32(grdRecords.DataKeys[e.RowIndex].Values["RecordID"]);

                var r = (from record in conn.Records1
                         where record.RecordID == RecordID
                         select record).FirstOrDefault();

                conn.Records1.Remove(r);
                conn.SaveChanges();

                getRecords();
            }
        }

        protected void grdRecords_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            getRecords();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRecords.PageIndex = e.NewPageIndex;
            getRecords();
        }

        protected void grdRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            int ID = Convert.ToInt32(grdRecords.DataKeys[currentRowIndex].Value);
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Records record = (from r in conn.Records1 where r.RecordID == ID select r).FirstOrDefault();
                record.Progress = txtUpdate.Text;
                conn.SaveChanges();
            }

            Response.Redirect("manage.aspx");
        }
    }
}
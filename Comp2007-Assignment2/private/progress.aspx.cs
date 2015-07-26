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
    public partial class progress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                Records r = new Records();

                Int32 RecordID = Convert.ToInt32(Request.QueryString["RecordID"]);

                r = (from record in conn.Records1
                     where record.RecordID == RecordID
                     select record).FirstOrDefault();

                r.Progress = txtProgress.Text;

                conn.SaveChanges();
                Response.Redirect("manage.aspx");
            }
        }
    }
}
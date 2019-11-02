using bussinesslogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace percobaan
{
    public partial class tampilanutama : System.Web.UI.Page
    {
        controlleruser ctl;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiViewdataobat.SetActiveView(View1);
            RefreshData();
        }
        private void RefreshData()
        {
            ctl = new controlleruser();
            GridView1.DataSource = ctl.getdatauserhak();
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
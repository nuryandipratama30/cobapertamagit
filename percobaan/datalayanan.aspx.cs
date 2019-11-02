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
    public partial class datalayanan : System.Web.UI.Page
    {
        controllerlayanan ctl;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiViewlayanan.SetActiveView(View1);

            RefreshData();
        }
        private void RefreshData()
        {
            ctl = new controllerlayanan();
            GridView1.DataSource = ctl.getdatalayanan();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiViewlayanan.SetActiveView(View2);
            btnsaveupd.Text = "Simpan";
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewlayanan.SetActiveView(View1);
            RefreshData();
        }

        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            ctl = new controllerlayanan();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                if (ctl.Insertdatalayanan(txtkodeolayanan.Text, txtnamalayanan.Text, txtketerangan.Text))
                {
                    ShowMessage("Insert Success");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    ShowMessage("Insert Failed");
                }
            }
            else
            {
                if (ctl.Updatedatalayanan(Session["kode_layanan"].ToString(), txtnamalayanan.Text, txtketerangan.Text))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiViewlayanan.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txtnamalayanan.Text = "";
            txtkodeolayanan.Text = "";
            txtketerangan.Text = "";
            btnsaveupd.Text = "Simpan";
        }
        void ShowMessage(String message)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert(" + message + ");", true);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "ubah")
            {
                MultiViewlayanan.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllerlayanan();
                dt = ctl.getdatalayanan(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_layanan"] = dt.Rows[0]["kode_layanan"].ToString();
                    txtnamalayanan.Text = dt.Rows[0]["nama_layanan"].ToString();
                    txtketerangan.Text = dt.Rows[0]["keterangan"].ToString();
                    txtkodeolayanan.Text = dt.Rows[0]["kode_layanan"].ToString();

                    btnsaveupd.Text = "update";
                }
                else
                {
                    ShowMessage("Data Not Found");
                }
            }
            else
            {
                string c_val = Request.Form["konfirmasi"];
                if (c_val == "Yes")
                {
                    Delete(e.CommandArgument.ToString());
                    RefreshData();
                    ClearField();
                    MultiViewlayanan.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {
            ctl = new controllerlayanan();
            if (ctl.Deletedatalayanan(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewlayanan.SetActiveView(View1);
                RefreshData();
            }
            else
            {
                ShowMessage("Delete Failed");
            }
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
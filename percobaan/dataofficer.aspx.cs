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
    public partial class dataofficer : System.Web.UI.Page
    {
        controllerofficer ctl;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiViewofficer.SetActiveView(View1);

            RefreshData();
        }
        private void RefreshData()
        {
            ctl = new controllerofficer();
            GridView1.DataSource = ctl.getdataofficer();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiViewofficer.SetActiveView(View2);
            btnsaveupd.Text = "Simpan";
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewofficer.SetActiveView(View1);
            RefreshData();
        }
        string sts;
        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            if (rb_aktif.Checked)
            {
                sts = "Aktif";
            }
            else if (rb_tidak_aktif.Checked)
            {
                sts = "Tidak Aktif";
            }
            ctl = new controllerofficer();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                
                if (ctl.Insertdataofficer(txtkodeofficer.Text, txtnamaofficer.Text, txtnotelp.Text, txtalamat.Text, txtbagian.Text, sts))
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
                if (ctl.Updatedataofficer(Session["kode_officer"].ToString(), txtnamaofficer.Text, txtnotelp.Text, txtalamat.Text, txtbagian.Text, sts))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiViewofficer.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txtnamaofficer.Text = "";
            txtkodeofficer.Text = "";
            txtnotelp.Text = "";
            txtalamat.Text = "";
            txtbagian.Text = "";
            rb_aktif.Checked=false;
            rb_tidak_aktif.Checked = false;
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
                MultiViewofficer.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllerofficer();
                dt = ctl.getdataofficer(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_officer"] = dt.Rows[0]["kode_officer"].ToString();
                    txtnamaofficer.Text = dt.Rows[0]["nama_officer"].ToString();
                    txtnotelp.Text = dt.Rows[0]["telp"].ToString();
                    txtalamat.Text = dt.Rows[0]["alamat"].ToString();
                    txtbagian.Text = dt.Rows[0]["bagian"].ToString();
                   // txtstatus.Text = dt.Rows[0]["status"].ToString();
                    sts = dt.Rows[0]["status"].ToString();
                    if (sts == "Aktif")
                    {
                        rb_aktif.Checked = true;
                    }
                    else
                    {
                        rb_tidak_aktif.Checked = true;
                    }
                    txtkodeofficer.Text = dt.Rows[0]["kode_officer"].ToString();

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
                    MultiViewofficer.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {
            ctl = new controllerofficer();
            if (ctl.Deletedataofficer(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewofficer.SetActiveView(View1);
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
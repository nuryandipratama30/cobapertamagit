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
    public partial class dataorder : System.Web.UI.Page
    {
        controllerklien ctlk;
        controllerorder ctlo;
        controllerofficer ctlof;
        controllerlayanan ctll;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiVieworder.SetActiveView(View1);
            RefreshData();
        }
        private void RefreshData()
        {
            ctlo = new controllerorder();
            GridView1.DataSource = ctlo.getdataorder();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiVieworder.SetActiveView(View2);
            btnsaveupd.Text = "Simpan";
            ClearField();
            //DataTable dt = new DataTable();
            ctlk = new controllerklien();
            ddlkodeklien.DataSource = ctlk.getdataklien();
            ddlkodeklien.DataBind();
            ddlkodeklien.DataTextField = "kode_klien";
            ddlkodeklien.DataValueField = "kode_klien";
            ddlkodeklien.DataBind();

            ctlof= new controllerofficer();
            ddlkodeofficer.DataSource = ctlof.getdataofficer();
            ddlkodeofficer.DataBind();
            ddlkodeofficer.DataTextField = "kode_officer";
            ddlkodeofficer.DataValueField = "kode_officer";
            ddlkodeofficer.DataBind();

            ctll = new controllerlayanan();
            ddlkodelayanan.DataSource = ctll.getdatalayanan();
            ddlkodelayanan.DataBind();
            ddlkodelayanan.DataTextField = "kode_layanan";
            ddlkodelayanan.DataValueField = "kode_layanan";
            ddlkodelayanan.DataBind();

        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiVieworder.SetActiveView(View1);
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
            ctlo = new controllerorder();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                if (ctlo.Insertdataorder(txtkodeorder.Text, ddlkodeklien.SelectedValue, ddlkodelayanan.SelectedValue, ddlkodeofficer.SelectedValue, txtlayanan.Text, txtdeskripsi.Text, txtnoakta.Text, txtnoberkas.Text, txtsifatakta.Text, sts, txtbiaya.Text,txtcatatan.Text))
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
                if (ctlo.Updatedataorder(Session["kode_order"].ToString(), ddlkodeklien.SelectedValue, ddlkodelayanan.SelectedValue, ddlkodeofficer.SelectedValue, txtlayanan.Text, txtdeskripsi.Text, txtnoakta.Text, txtnoberkas.Text, txtsifatakta.Text, sts, txtbiaya.Text, txtcatatan.Text))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiVieworder.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txtkodeorder.Text = "";
            //txtkodeklien.Text = "";
            txtlayanan.Text = "";
            txtbiaya.Text = "";
            txtcatatan.Text = "";
            txtdeskripsi.Text = "";
            txtnoakta.Text = "";
            txtnoberkas.Text = "";
            txtsifatakta.Text = "";
            txtcatatan.Text = "";
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
                MultiVieworder.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctlo = new controllerorder();
                dt = ctlo.getdataorder(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("masuk");
                    Session["kode_order"] = dt.Rows[0]["kode_order"].ToString();
                    txtkodeorder.Text = dt.Rows[0]["kode_order"].ToString();
                    //=========================================================//
                    ctlk = new controllerklien();
                    ddlkodeklien.DataSource = ctlk.getdataklien();
                    ddlkodeklien.DataBind();
                    ddlkodeklien.DataTextField = "kode_klien";
                    ddlkodeklien.DataValueField = "kode_klien";
                    ddlkodeklien.DataBind();
                    //========================================================//
                    ctlof = new controllerofficer();
                    ddlkodeofficer.DataSource = ctlof.getdataofficer();
                    ddlkodeofficer.DataBind();
                    //ddlkodeofficer.SelectedValue = dt.Rows[0]["kode_officer"].ToString();
                    ddlkodeofficer.DataTextField = "kode_officer";
                    ddlkodeofficer.DataValueField = "kode_officer";
                    ddlkodeofficer.DataBind();
                    //=========================================================//
                    ctll = new controllerlayanan();
                    ddlkodelayanan.DataSource = ctll.getdatalayanan();
                    ddlkodelayanan.DataBind();
                    ddlkodelayanan.DataTextField = "kode_layanan";
                    ddlkodelayanan.DataValueField = "kode_layanan";
                    //ddlkodelayanan.SelectedValue = dt.Rows[0]["kode_layanan"].ToString();
                    ddlkodelayanan.DataBind();
                    //=========================================================//
                    txtlayanan.Text = dt.Rows[0]["layanan"].ToString();
                    txtbiaya.Text = dt.Rows[0]["biaya"].ToString();
                    txtcatatan.Text = dt.Rows[0]["catatan"].ToString();
                    txtdeskripsi.Text = dt.Rows[0]["deskripsi"].ToString();
                    txtnoakta.Text = dt.Rows[0]["no_akta"].ToString();
                    txtnoberkas.Text = dt.Rows[0]["no_berkas"].ToString();
                    txtsifatakta.Text = dt.Rows[0]["sifat_akta"].ToString();
                    //txtstatus.Text = dt.Rows[0]["status"].ToString();
                    sts = dt.Rows[0]["status"].ToString();
                    if (sts == "Aktif")
                    {
                        rb_aktif.Checked = true;
                    }
                    else
                    {
                        rb_tidak_aktif.Checked = true;
                    }
                    btnsaveupd.Text = "update";

                }
            }
            else if (e.CommandName == "btndetilorder")
            {
                MultiVieworder.SetActiveView(View3);
                DataTable dtt = new DataTable();
                ctlo = new controllerorder();
                dtt = ctlo.getdataorder(e.CommandArgument.ToString());
                if (dtt.Rows.Count > 0)
                {
                    Session["kode_order"] = dtt.Rows[0]["kode_order"].ToString();
                    lblkodeorder.Text = dtt.Rows[0]["kode_order"].ToString();
                    lblkodeklien.Text = dtt.Rows[0]["kode_klien"].ToString();
                    lblkodeofficer.Text = dtt.Rows[0]["kode_officer"].ToString();
                    lblkodelayanan.Text = dtt.Rows[0]["kode_layanan"].ToString();

                    // ShowMessage(lblnamaklien.Text);
                    lbllayanan.Text = dtt.Rows[0]["layanan"].ToString();
                    lbldeskripsi.Text = dtt.Rows[0]["deskripsi"].ToString();
                    lblnoakta.Text = dtt.Rows[0]["no_akta"].ToString();
                    lblsifatakta.Text = dtt.Rows[0]["sifat_akta"].ToString();
                    lblnoberkas.Text = dtt.Rows[0]["no_berkas"].ToString();
                    lbltglorder.Text = dtt.Rows[0]["tgl_order"].ToString();
                    lblstatus.Text = dtt.Rows[0]["status"].ToString();
                    lblbiaya.Text = dtt.Rows[0]["biaya"].ToString();
                    lblcatatan.Text = dtt.Rows[0]["catatan"].ToString();

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
                    MultiVieworder.SetActiveView(View1);
                }
            }
        }
        protected void btnkembali_Click(object sender, EventArgs e)
        {
            MultiVieworder.SetActiveView(View1);
            RefreshData();
        }
        private void Delete(string p)
        {
            ctlo = new controllerorder();
            if (ctlo.Deletedataorder(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiVieworder.SetActiveView(View1);
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
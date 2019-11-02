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
    public partial class datasuratmasuk : System.Web.UI.Page
    {
        controllersuratmasuk ctl;
        controllerofficer ctlof;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                cascadingdropdown();
            }
            MultiViewsuratmasuk.SetActiveView(View1);

            RefreshData();
        }
        protected void cascadingdropdown()
        {
            ctlof = new controllerofficer();
            ddlnama_officer.DataSource = ctlof.getdataofficer();
            //ddlprovinsi.DataTextField = "nama_provinsi";
            //ddlprovinsi.DataValueField = "id_provinsi";
            ddlnama_officer.DataBind();

            //ddlprovinsi.Items.Insert(0, new ListItem("---Select Provinsi-----", "0"));

        }
        private void RefreshData()
        {
            ctl = new controllersuratmasuk();
            GridView1.DataSource = ctl.getdatasuratmasuk();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiViewsuratmasuk.SetActiveView(View2);
            btnsaveupd.Text = "Simpan";
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewsuratmasuk.SetActiveView(View1);
            RefreshData();
        }

        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            ctl = new controllersuratmasuk();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                if (ctl.Insertdatasuratmasukklien(txtno_surat.Text, ddlnama_officer.SelectedValue,txttglsurat.Text,txtperihal.Text,txtasalsurat.Text,txtdisposisi.Text,txtcatatan.Text))
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
                if (ctl.Updatedatasuratmasuk(Session["no_surat"].ToString(), ddlnama_officer.SelectedValue, txttglsurat.Text, txtperihal.Text, txtasalsurat.Text, txtdisposisi.Text, txtcatatan.Text))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiViewsuratmasuk.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txtasalsurat.Text = "";
            txtcatatan.Text = "";
            txtdisposisi.Text = "";
            txtno_surat.Text = "";
            txtperihal.Text = "";
            txttglsurat.Text = "";
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
                MultiViewsuratmasuk.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllersuratmasuk();
                dt = ctl.getdatasuratmasuk(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["no_surat"] = dt.Rows[0]["no_surat"].ToString();
                    txtasalsurat.Text = dt.Rows[0]["asal_surat"].ToString();
                    txtcatatan.Text = dt.Rows[0]["catatan"].ToString();
                    txtdisposisi.Text = dt.Rows[0]["disposisi"].ToString();
                    txtno_surat.Text = dt.Rows[0]["no_surat"].ToString();
                    txtperihal.Text = dt.Rows[0]["perihal"].ToString();
                    txttglsurat.Text = dt.Rows[0]["tgl_surat"].ToString();

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
                    MultiViewsuratmasuk.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {
            ctl = new controllersuratmasuk();
            if (ctl.Deletedatasuratmasuk(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewsuratmasuk.SetActiveView(View1);
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
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
    public partial class datasuratkeluar : System.Web.UI.Page
    {
        controllersuratkeluar ctl;
        controllerofficer ctlof;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                cascadingdropdown();
            }
            MultiViewsuratkeluar.SetActiveView(View1);

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
            ctl = new controllersuratkeluar();
            GridView1.DataSource = ctl.getdatasuratkeluar();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiViewsuratkeluar.SetActiveView(View2);
            btnsaveupd.Text = "Simpan";
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewsuratkeluar.SetActiveView(View1);
            RefreshData();
        }

        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            ctl = new controllersuratkeluar();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                if (ctl.Insertdatasuratkeluar(txtno_surat.Text, ddlnama_officer.SelectedValue, txttglsurat.Text, txtperihal.Text, txttujuansurat.Text, txtcatatan.Text))
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
                if (ctl.Updatedatasuratkeluar(Session["no_surat"].ToString(), ddlnama_officer.SelectedValue, txttglsurat.Text, txtperihal.Text, txttujuansurat.Text, txtcatatan.Text))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiViewsuratkeluar.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txttujuansurat.Text = "";
            txtcatatan.Text = "";
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
                MultiViewsuratkeluar.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllersuratkeluar();
                dt = ctl.getdatasuratkeluar(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["no_surat"] = dt.Rows[0]["no_surat"].ToString();
                    txttujuansurat.Text = dt.Rows[0]["tujuan_surat"].ToString();
                    txtcatatan.Text = dt.Rows[0]["catatan"].ToString();
                    txtno_surat.Text = dt.Rows[0]["no_surat"].ToString();
                    txtperihal.Text = dt.Rows[0]["perihal"].ToString();
                    txttglsurat.Text = dt.Rows[0]["tgl_surat"].ToString();
                    ddlnama_officer.SelectedItem.Text = dt.Rows[0]["nama_officer"].ToString();
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
                    MultiViewsuratkeluar.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {
            ctl = new controllersuratkeluar();
            if (ctl.Deletedatasuratkeluar(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewsuratkeluar.SetActiveView(View1);
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
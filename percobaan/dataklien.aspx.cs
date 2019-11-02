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
    public partial class dataklien : System.Web.UI.Page
    {
        controllerklien ctl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                cascadingdropdown();
            }
            MultiViewklien.SetActiveView(View1);
            RefreshData();
        }
        private void RefreshData()
        {
            ctl = new controllerklien();
            GridView1.DataSource = ctl.getdataklien();
            GridView1.DataBind();
        }

        protected void cascadingdropdown()
        {
            ctl = new controllerklien();
            ddlprovinsi.DataSource = ctl.getdatapropinsi();
            //ddlprovinsi.DataTextField = "nama_provinsi";
            //ddlprovinsi.DataValueField = "id_provinsi";
            ddlprovinsi.DataBind();
  
            //ddlprovinsi.Items.Insert(0, new ListItem("---Select Provinsi-----", "0"));

        }
        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            btnsaveupd.Text = "Simpan";
            MultiViewklien.SetActiveView(View2);
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewklien.SetActiveView(View1);
            RefreshData();
        }

        protected void btnkembali_Click(object sender, EventArgs e)
        {
            MultiViewklien.SetActiveView(View1);
            RefreshData();
        }

        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            ctl = new controllerklien();
            if (btnsaveupd.Text.ToLower() == "simpan")
            {
                if (ctl.Insertdataklien(txtkodeklien.Text, txtnamaklien.Text, txtemail.Text, txtnotelp.Text, txtalamat.Text, ddlkabupaten.SelectedValue, ddlprovinsi.SelectedValue, txtcatatan.Text))
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
                if (ctl.Updatedataklien(Session["kode_klien"].ToString(), txtnamaklien.Text, txtemail.Text, txtnotelp.Text, txtalamat.Text, ddlkabupaten.SelectedValue, ddlprovinsi.SelectedValue, txtcatatan.Text))
                {
                    ShowMessage("Update Success");
                }
                else
                {
                    ShowMessage("Update Failed");
                }
            }
            ClearField();
            MultiViewklien.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            txtnamaklien.Text = "";
            txtkodeklien.Text = "";
            txtnotelp.Text = "";
            txtalamat.Text = "";
            // txtkabupaten.Text = "";
            // txtprov.Text = "";
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
                MultiViewklien.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllerklien();
                dt = ctl.getdataklien(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_klien"] = dt.Rows[0]["kode_klien"].ToString();
                    txtnamaklien.Text = dt.Rows[0]["nama_klien"].ToString();
                    txtnotelp.Text = dt.Rows[0]["telp"].ToString();
                    txtalamat.Text = dt.Rows[0]["alamat"].ToString();
                    //txtkabupaten.Text = dt.Rows[0]["kab_kota"].ToString();
                    //txtprov.Text = dt.Rows[0]["provinsi"].ToString();
                    txtkodeklien.Text = dt.Rows[0]["kode_klien"].ToString();
                    txtcatatan.Text = dt.Rows[0]["catatan"].ToString();
                    txtemail.Text = dt.Rows[0]["email"].ToString();
                    btnsaveupd.Text = "update";

                }
                else
                {
                    ShowMessage("Data Not Found");
                }
            }
            else if (e.CommandName == "btndetilklien")
            {
                MultiViewklien.SetActiveView(View3);
                DataTable dt = new DataTable();
                ctl = new controllerklien();
                dt = ctl.getdataklien(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_klien"] = dt.Rows[0]["kode_klien"].ToString();
                    lblnamaklien.Text = dt.Rows[0]["nama_klien"].ToString();
                    ShowMessage(lblnamaklien.Text);
                    lblnotelp.Text = dt.Rows[0]["telp"].ToString();
                    lblalamat.Text = dt.Rows[0]["alamat"].ToString();
                    lblkabupaten.Text = dt.Rows[0]["nama_kabupaten"].ToString();
                    lblprovinsi.Text = dt.Rows[0]["nama_provinsi"].ToString();
                    lblkodeklien.Text = dt.Rows[0]["kode_klien"].ToString();
                    lblcatatan.Text = dt.Rows[0]["catatan"].ToString();
                    lbltgldaftar.Text = dt.Rows[0]["tgl_daftar"].ToString();
                    lblemail.Text = dt.Rows[0]["email"].ToString();
                    

                }
                else
                {
                    ShowMessage("Data Not Found");
                }
            }
            else
            {
                string c_val = Request.Form["konfirmasi"];
                //Response.Write("<script>alert('masuk')</script>");
                if (c_val == "Yes")
                {
                    ShowMessage("hjhvjh");
                    Delete(e.CommandArgument.ToString());
                    RefreshData();
                    ClearField();
                    MultiViewklien.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {

            ctl = new controllerklien();
            if (ctl.Deletedataklien(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewklien.SetActiveView(View1);
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

        string id_prov;
        protected void ddlprovinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlkabupaten.Items.Clear();
            ddlkabupaten.Items.Add("--select kabupaten--");
            id_prov = ddlprovinsi.SelectedValue;
            ShowMessage(id_prov);
            ShowMessage("hbh");
            ctl = new controllerklien();
            ddlkabupaten.DataSource = ctl.getdatakabupaten(id_prov);

            //ddlprovinsi.DataTextField = "nama_kabupaten";
            //ddlprovinsi.DataValueField = "id_kabupaten";
            ddlkabupaten.DataBind();
            // ddlprovinsi.Items.Insert(0, new ListItem("---Select Kabupaten---", "0"));
            MultiViewklien.SetActiveView(View2);
        }

        protected void ddlkabupaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string id_prov = ddlprovinsi.SelectedValue;
            //ctl = new controllerklien();
            //ddlprovinsi.DataSource = ctl.getdatakabupaten(id_prov);
            //MultiViewklien.SetActiveView(View2);
            //ddlprovinsi.DataTextField = "nama_kabupaten";
            //ddlprovinsi.DataValueField = "id_kabupaten";
            //ddlprovinsi.DataBind();
            //ddlprovinsi.Items.Insert(0, new ListItem("---Select Kabupaten---", "0"));
        }

    }
}
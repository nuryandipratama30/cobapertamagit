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
    public partial class data_efiling : System.Web.UI.Page
    {
        controllerefiiing ctl;
        controllerorder ctlo;
        controllerklien ctlk;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiViewefiling.SetActiveView(View1);

            RefreshData();
        }
        private void RefreshData()
        {
            ctl = new controllerefiiing();
            GridView1.DataSource = ctl.getdataefiling();
            GridView1.DataBind();
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            MultiViewefiling.SetActiveView(View2);
            //btnsaveupd.Text = "Simpan";
            ClearField();
        }

        protected void btncancelupd_Click(object sender, EventArgs e)
        {
            MultiViewefiling.SetActiveView(View1);
            RefreshData();
        }

        protected void btnsaveupd_Click(object sender, EventArgs e)
        {
            ctl = new controllerefiiing();
            HttpPostedFile postedfile = FileUpload1.PostedFile;
            string filenama = Path.GetFileName(postedfile.FileName);
            string fileextension = Path.GetExtension(filenama);
            int filesize = postedfile.ContentLength;
            if (fileextension.ToLower() == ".docx" || fileextension.ToLower() == ".pdf" || fileextension.ToLower() == ".pptx")
            {

                Stream stream = postedfile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                byte[] bytes = binaryreader.ReadBytes((int)stream.Length);

                if (ctl.Insertdataefiling(txtkodeefiling.Text, ddljenis.SelectedValue, ddlinfo.SelectedValue,filenama, filesize, txtcatatan.Text, bytes, txttgl.Text))
                {
                    Response.Write("<script>alert('Update Berhasil')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update gagal')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('file bukan dokumen')</script>");
            }
            //if (btnsaveupd.Text.ToLower() == "simpan")
            //{
            //    if (ctl.Insertdatalayanan(txtkodeolayanan.Text, txtnamalayanan.Text, txtketerangan.Text))
            //    {
            //        ShowMessage("Insert Success");
            //        Response.Redirect(Request.RawUrl);
            //    }
            //    else
            //    {
            //        ShowMessage("Insert Failed");
            //    }
            //}
            //else
            //{
            //    if (ctl.Updatedatalayanan(Session["kode_layanan"].ToString(), txtnamalayanan.Text, txtketerangan.Text))
            //    {
            //        ShowMessage("Update Success");
            //    }
            //    else
            //    {
            //        ShowMessage("Update Failed");
            //    }
            //}
            ClearField();
            MultiViewefiling.SetActiveView(View1);
            RefreshData();
        }

        void ClearField()
        {
            //txtnamalayanan.Text = "";
            //txtkodeolayanan.Text = "";
            //txtketerangan.Text = "";
            //btnsaveupd.Text = "Simpan";
        }
        void ShowMessage(String message)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert(" + message + ");", true);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "ubah")
            {
                MultiViewefiling.SetActiveView(View2);
                DataTable dt = new DataTable();
                ctl = new controllerefiiing();
                dt = ctl.getdataefiling(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_layanan"] = dt.Rows[0]["kode_layanan"].ToString();
                    //txtnamalayanan.Text = dt.Rows[0]["nama_layanan"].ToString();
                    //txtketerangan.Text = dt.Rows[0]["keterangan"].ToString();
                    //txtkodeolayanan.Text = dt.Rows[0]["kode_layanan"].ToString();

                    //btnsaveupd.Text = "update";
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
                    MultiViewefiling.SetActiveView(View1);
                }
            }
        }
        private void Delete(string p)
        {
            ctl = new controllerefiiing();
            if (ctl.Deletedataefiling(p))
            {
                ShowMessage("Delete Success");
                ClearField();
                MultiViewefiling.SetActiveView(View1);
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

        //string id;
        protected void ddljenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctlo = new controllerorder();
            ctlk = new controllerklien();
            ddlinfo.Items.Clear();
            ddlinfo.Items.Add("--select info--");
            if (ddljenis.SelectedValue == "Order")
            {
                if ((IsPostBack))
                {
                    ddlinfo.DataSource = ctlo.getdataorder();
                    ddlinfo.DataTextField = "kode_order";
                    ddlinfo.DataValueField = "kode_order";
                }
            }
            else if (ddljenis.SelectedValue == "Klien")
            {
                if ((IsPostBack))
                {
                    ddlinfo.DataSource = ctlk.getdataklien();
                    ddlinfo.DataTextField = "nama_klien";
                    ddlinfo.DataValueField = "kode_klien";
                }
            }
            //id = ddlprovinsi.SelectedValue;
            //ShowMessage(id_prov);
            // ShowMessage("hbh");
            //ctl = new controllerklien();


            
            ddlinfo.DataBind();
            MultiViewefiling.SetActiveView(View2);

        }

        protected void gbtambahinfo_Click(object sender, ImageClickEventArgs e)
        {
            ShowMessage("hbdsigs");
        }

        protected void ddlinfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
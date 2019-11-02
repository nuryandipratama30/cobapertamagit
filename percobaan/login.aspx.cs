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
    public partial class login : System.Web.UI.Page
    {
        controlleruser ctl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //MultiViewdatapasien.SetActiveView(View1);
        }
        string status;
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ctl = new controlleruser();
            dt = ctl.getdatauserhak(txtusername.Text, txtpass.Text);
            if (dt.Rows.Count > 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#mymodal').modal('show');</script>", false);
                Session["Username"] = txtusername.Text;
                status = dt.Rows[0]["status"].ToString();
                if (status.ToLower() == "admin")
                {
                    Response.Redirect("~/tampilanutama.aspx");// nama form yang akan dituju ketika login berhasil
                    Session.RemoveAll();
                }
                else if(status.ToLower()=="user"){
                    Response.Redirect("~/tampilanutamauser.aspx");// nama form yang akan dituju ketika login berhasil
                    Session.RemoveAll();
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#mymodal').modal('show');</script>", false);
               ShowMessage("password dan username salah");
            }

            //if (txtusername.Text.ToLower() == "yandi" && txtpass.Text == "1234")
            //{
            //    ShowMessage("login sukses");
            //    //Session.Remove("Login berhasil");
            //    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('berhasil login');", true);
            //    //Session[]
            //    Response.Redirect("~/tampilanutama.aspx");
            //}
        }

        

        void ShowMessage(string Mes)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('" + Mes + "');", true);
        }


    }
}
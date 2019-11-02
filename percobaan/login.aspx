<%@ Page Title="" Language="C#" MasterPageFile="~/masterlogin.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="percobaan.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Mainlogin" runat="server">
    <form id="formdatapasien" runat="server">
        <div class="p-b-0" style="padding-left: 5px; width: auto">
            <img src="stylelogin/images/ini-ikatan-notaris-indonesia-logo-vector.png" width="400" height="300" alt="AVATAR" />
        </div>

        <span class="login100-form-title p-t-20 p-b-45">Sistem Informasi Notaris
        </span>

        <div class="wrap-input100 validate-input m-b-10" data-validate="Username is required">
            <%--<input class="input100" type="text" ID="username" placeholder="Username">--%>
            <asp:TextBox ID="txtusername" runat="server" placeholder="Username" CssClass="input100"></asp:TextBox>
            <span class="focus-input100"></span>
            <span class="symbol-input100">
                <i class="fa fa-user"></i>
            </span>
        </div>

        <div class="wrap-input100 validate-input m-b-10" data-validate="Password is required">
            <%--<input class="input100" type="password" ID="pass" placeholder="Password">--%>
            <asp:TextBox ID="txtpass" TextMode="Password" placeholder="Password" runat="server" CssClass="input100"></asp:TextBox>
            <span class="focus-input100"></span>
            <span class="symbol-input100">
                <i class="fa fa-lock"></i>
            </span>
        </div>

        <div class="container-login100-form-btn p-t-10">
            <%--<button class="login100-form-btn">
                        Login
                    </button>--%>
            <asp:Button ID="btnlogin" runat="server" Text="Login" class="login100-form-btn" Width="79px" CausesValidation="False" OnClick="btnlogin_Click" />
        </div>
        <div id="mymoodal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Label">Login Gagal</asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="text-center w-full p-t-25 p-b-100">
            <a href="#" class="txt1">Forgot Username / Password?
            </a>
        </div>

        <div class="text-center w-full">
            <a class="txt1" href="#">Create new account
				<i class="fa fa-long-arrow-right"></i>
            </a>
        </div>


    </form>
</asp:Content>

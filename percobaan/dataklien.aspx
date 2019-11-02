<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dataklien.aspx.cs" Inherits="percobaan.dataklien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdataklienn" runat="server">
        <asp:MultiView ID="MultiViewklien" runat="server">
            <asp:View ID="View1" runat="server">
                <label style="padding-left: 510px; font-size: 40pt">Data Klien</label>
                <br />
                <div>
                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary pull-left" Text="Tambah Klien" CausesValidation="False" OnClick="btnAdd0_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-striped table-hover table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kode_klien" HeaderText="Kode Klien" />
                        <%--<asp:ButtonField HeaderText="Nama Klien" ButtonType="Link" CommandName="btndetilklien" ControlStyle-ForeColor="Blue" DataTextField="nama_klien" />--%>
                        <asp:BoundField DataField="nama_klien" HeaderText="Nama Klien" />
                        <%--<asp:BoundField HeaderText="EMail" DataField="email" />--%>
                        <asp:BoundField DataField="telp" HeaderText="Telp/Hp" />
                        <asp:BoundField DataField="alamat" HeaderText="Alamat" />
                        <%--<asp:BoundField HeaderText="Kabupaten" DataField="nama_kabupaten" />--%><%--<asp:BoundField HeaderText="Provinsi" DataField="nama_provinsi" />--%>
                        <asp:BoundField DataField="tgl_daftar" HeaderText="Tanggal Daftar" />
                        <asp:BoundField DataField="catatan" HeaderText="Catatan" />
                        <asp:TemplateField ControlStyle-ForeColor="Blue" HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_klien").ToString()%>' CommandName="ubah"><img src="stylelogin/images/edit.png" title="ubah" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_klien").ToString()%>' CommandName="hapus" OnClientClick="ConfirmDelete()"><img src="stylelogin/images/delete.png" title="hapus" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_klien").ToString()%>' CommandName="btndetilklien" ControlStyle-ForeColor="Blue">Detil</asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle ForeColor="Blue" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%--<SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="modal-header" style="text-align: center">
                    <label><b style="font-size: 16pt">Form Klien</b></label>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtkodeklien">
                            Kode Klien
                        </label>
                        <asp:TextBox ID="txtkodeklien" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeklien"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="hanya bisa menginputkan huruf K,L dan 4 digit angka dibelakangnya(ex KL0001)" ForeColor="Red" ControlToValidate="txtkodeklien"
                            ValidationExpression="^\b[0-9KK]{6}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtnamaofficer">
                            Nama Lengkap
                        </label>
                        <asp:TextBox ID="txtnamaklien" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnamaklien"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="tidak boleh ada angka dan tanda lain selain '" ForeColor="Red" ControlToValidate="txtnamaklien"
                            ValidationExpression="^\b[a-zA-Z\s_\']{1,100}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtemail">
                            e-Mail
                        </label>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="hanya bisa menginputkan angka dan tidak lebih dari 13 digit" ForeColor="Red" ControlToValidate="txtemail"
                            ValidationExpression="^\b[0-9]{4,13}$"></asp:RegularExpressionValidator>--%>
                    </div>
                    <div class="form-group">
                        <label for="txtnotelp">
                            No Telp/Hp
                        </label>
                        <asp:TextBox ID="txtnotelp" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnotelp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="hanya bisa menginputkan angka dan tidak lebih dari 13 digit" ForeColor="Red" ControlToValidate="txtnotelp"
                            ValidationExpression="^\b[0-9]{4,13}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtalamat">
                            Alamat
                        </label>
                        <asp:TextBox ID="txtalamat" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtalamat"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="ddlprovinsi">
                            Provinsi
                        </label>
                        <asp:DropDownList ID="ddlprovinsi" CssClass="form-control" runat="server" AutoPostBack="True"
                            DataTextField="nama_provinsi" DataValueField="id_provinsi" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlprovinsi_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select Provinsi--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="ddlkabupaten">
                            Kabupaten
                        </label>
                        <asp:DropDownList ID="ddlkabupaten" CssClass="form-control" runat="server" AppendDataBoundItems="true" DataTextField="nama_kabupaten"
                            DataValueField="id_kabupaten" OnSelectedIndexChanged="ddlkabupaten_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txttgldaftar">
                            Tanggal Daftar
                        </label>
                        <asp:TextBox ID="txttgldaftar" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txttgldaftar"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtcatatan">
                            Catatan
                        </label>
                        <asp:TextBox ID="txtcatatan" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtcatatan"></asp:RequiredFieldValidator>
                    </div>
                    <!-- <div class="form-group">
                                    <label for="FileUpload2">
                                        Foto
                                    </label>
                                    <asp:FileUpload ID="FileUpload2" CssClass="form-control" runat="server" />
                                </div>-->
                </div>
                <!--<div class="modal-body">
                                ISI FORM
                            </div>-->
                <div class="modal-footer">
                    <asp:Button ID="btncancelupd" runat="server" CssClass="btn btn-primary pull-left" Text="Batal" CausesValidation="False" OnClick="btncancelupd_Click" />
                    <asp:Button ID="btnsaveupd" runat="server" Text="Simpan" CssClass="btn btn-primary" Width="79px" CausesValidation="False" OnClick="btnsaveupd_Click" />
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td style="height: 26px; width: 184px">
                            <label for="lblkodeklien">
                                Kode Klien
                            </label>
                        </td>
                        <td style="height: 26px">:</td>
                        <td style="height: 26px">
                            <asp:Label ID="lblkodeklien" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblnamaklien">
                                Nama Lengkap
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblnamaklien" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblemail">
                                e-Mail
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblnotelp">
                                No Telp/Hp
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblnotelp" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblalamat">
                                Alamat
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblalamat" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblprovinsi">
                                Provinsi
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblprovinsi" runat="server" Text="Label"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblkabupaten">
                                Kabupaten
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblkabupaten" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lbltgldaftar">
                                Tanggal Daftar
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lbltgldaftar" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblcatatan">
                                Catatan
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblcatatan" runat="server" Text="lblcatatan"></asp:Label>
                    </tr>
                </table>
   
                <div class="modal-footer">
                    <asp:Button ID="btnkembali" runat="server" CssClass="btn btn-primary pull-left" Text="Kembali" CausesValidation="False" OnClick="btnkembali_Click" />
                </div>
            </asp:View>
        </asp:MultiView>
    </form>
    <script src="styletampilan/vendors/jquery/dist/jquery.min.js"></script>
    <script src="styletampilan/vendors/datatables.net/js/jquery.dataTables.js"></script>
    <script src="styletampilan/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="styletampilan/vendors/datatables.net-bs4/js/dataTables.bootstrap4.js"></script>
    <script src="styletampilan/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="styletampilan/vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="styletampilan/assets/js/init-scripts/data-table/datatables-init.js"></script>
    <script>
        function ConfirmDelete() {
            var c_val = document.createElement("INPUT");
            c_val.type = "hidden";
            c_val.name = "konfirmasi";
            if (confirm("apakah anda yakin")) {
                c_val.value = "Yes";
            }
            else {
                c_val.value = "No";
            }
            document.forms["formdataklienn"].appendChild(c_val);
        }
        $(function () {
            $('.gvv').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
        $(document).ready(function () {
            $(".nav li").removeClass("active");
            $('#Datapasien').addClass('active');
        });
    </script>
</asp:Content>

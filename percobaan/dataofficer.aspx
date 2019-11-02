<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dataofficer.aspx.cs" Inherits="percobaan.dataofficer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdataofficer" runat="server">
        <asp:MultiView ID="MultiViewofficer" runat="server">
            <asp:View ID="View1" runat="server">
                <label style="padding-left: 500px; font-size: 40pt">Data Officer</label>
                <br />
                <div>
                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary pull-left" Text="Tambah Officer" CausesValidation="False" OnClick="btnAdd0_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-striped table-hover table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kode_officer" HeaderText="Kode Officer" />
                        <asp:BoundField DataField="nama_officer" HeaderText="Nama Officer" />
                        <asp:BoundField DataField="telp" HeaderText="Telp/Hp" />
                        <asp:BoundField DataField="alamat" HeaderText="Alamat" />
                        <asp:BoundField DataField="bagian" HeaderText="Bagian " />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:TemplateField ControlStyle-ForeColor="Blue" HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_officer").ToString()%>' CommandName="ubah"><img src="stylelogin/images/edit.png" title="ubah" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_officer").ToString()%>' CommandName="hapus" OnClientClick="ConfirmDelete()"><img src="stylelogin/images/delete.png" title="hapus" width="20" /></asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle ForeColor="Blue" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="modal-header" style="text-align: center">
                    <label><b style="font-size: 14pt">Form Officer</b></label></div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtkodeofficer">
                            Kode Officer
                        </label>
                        <asp:TextBox ID="txtkodeofficer" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeofficer"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="hanya boleh menginputkan huruf K,O,F dan 3 digit angka dibelakangnya(ex KOF001)" ForeColor="Red" ControlToValidate="txtkodeofficer"
                            ValidationExpression="^\b[0-9KOF]{6}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtnamaofficer">
                            Nama Lengkap
                        </label>
                        <asp:TextBox ID="txtnamaofficer" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnamaofficer"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="tidak boleh ada angka dan tanda lain selain '" ForeColor="Red" ControlToValidate="txtnamaofficer"
                            ValidationExpression="^\b[a-zA-Z\s_\']{1,100}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtnotelp">
                            No Telp/Hp
                        </label>
                        <asp:TextBox ID="txtnotelp" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnotelp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="hanya bisa menginputkan angka dan tidak lebih dari 13" ForeColor="Red" ControlToValidate="txtnotelp"
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
                        <label for="txtbagian">
                            Bagian
                        </label>
                        <asp:TextBox ID="txtbagian" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtbagian"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="maaf hanya bisa menggunakan huruf" ForeColor="Red" ControlToValidate="txtbagian"
                            ValidationExpression="^\b[a-zA-Z\s_]{1,50}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="status">
                            Status
                        </label>
                    </div>
                    <div class="form-group">
                        <asp:RadioButton ID="rb_aktif" Text="Aktif" style="padding-right:100px" BorderStyle="Groove" runat="server" GroupName="status" />
                        <asp:RadioButton ID="rb_tidak_aktif" Text="Tidak Aktif" style="padding-right:70px" BorderStyle="Groove" runat="server" GroupName="status" />
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
            document.forms["formdataofficer"].appendChild(c_val);
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

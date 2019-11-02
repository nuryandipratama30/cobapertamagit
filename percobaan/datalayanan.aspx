<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datalayanan.aspx.cs" Inherits="percobaan.datalayanan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdatalayanan" runat="server">
        <asp:MultiView ID="MultiViewlayanan" runat="server">
            <asp:View ID="View1" runat="server">
                <label style="padding-left: 500px; font-size: 40pt">Data Layanan</label>
                <br />
                <div>
                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary pull-left" Text="Tambah Layanan" CausesValidation="False" OnClick="btnAdd0_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-striped table-hover table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kode_layanan" HeaderText="Kode Layanan" />
                        <asp:BoundField DataField="nama_layanan" HeaderText="Nama Layanan" />
                        <asp:BoundField DataField="keterangan" HeaderText="Keterangan" />
                        <asp:TemplateField ControlStyle-ForeColor="Blue" HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_layanan").ToString()%>' CommandName="ubah"><img src="stylelogin/images/edit.png" title="ubah" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_layanan").ToString()%>' CommandName="hapus" OnClientClick="ConfirmDelete()"><img src="stylelogin/images/delete.png" title="hapus" width="20" /></asp:LinkButton>
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
                    <label><b>Form Layanan</b></label></div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtkodeolayanan">
                            Kode Layanan
                        </label>
                        <asp:TextBox ID="txtkodeolayanan" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeolayanan"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="hanya bisa menginputkan huruf K,L dan 4 digit angka dibelakangnya(ex KL0001)" ForeColor="Red" ControlToValidate="txtkodeolayanan"
                            ValidationExpression="^\b[0-9KL]{6}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtnamalayanan">
                            Nama Lengkap
                        </label>
                        <asp:TextBox ID="txtnamalayanan" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnamalayanan"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="tidak boleh ada angka dan tanda lain selain '," ForeColor="Red" ControlToValidate="txtnamalayanan"
                            ValidationExpression="^\b[a-zA-Z\s_\']{1,100}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtketerangan">
                            Alamat
                        </label>
                        <asp:TextBox ID="txtketerangan" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtketerangan"></asp:RequiredFieldValidator>
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
            document.forms["formdatalayanan"].appendChild(c_val);
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

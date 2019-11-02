<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datasuratmasuk.aspx.cs" Inherits="percobaan.datasuratmasuk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdatasuratmasuk" runat="server">
        <asp:MultiView ID="MultiViewsuratmasuk" runat="server">
            <asp:View ID="View1" runat="server">
                <label style="padding-left: 400px; font-size: 40pt">Data Surat Masuk</label>
                <br />
                <div>
                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary pull-left" Text="Tambah Layanan" CausesValidation="False" OnClick="btnAdd0_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-striped table-hover table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nama_officer" HeaderText="Nama Officer" />
                        <asp:BoundField DataField="no_surat" HeaderText="No Surat" />
                        <asp:BoundField DataField="tgl_surat" HeaderText="Tanggal Surat" />
                        <asp:BoundField DataField="perihal" HeaderText="Perihal" />
                        <asp:BoundField DataField="asal_surat" HeaderText="Asal Surat" />
                        <asp:BoundField DataField="disposisi" HeaderText="Disposisi" />
                        <%--<asp:BoundField HeaderText="Keterangan" DataField="disposisi" />--%>
                        <asp:TemplateField ControlStyle-ForeColor="Blue" HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("no_surat").ToString()%>' CommandName="ubah"><img src="stylelogin/images/edit.png" title="ubah" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("no_surat").ToString()%>' CommandName="hapus" OnClientClick="ConfirmDelete()"><img src="stylelogin/images/delete.png" title="hapus" width="20" /></asp:LinkButton>
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
                    <label><b>Form Surat Masuk</b></label>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="ddlnama_officer">
                            Nama Officer
                        </label>
                        <asp:DropDownList ID="ddlnama_officer" CssClass="form-control" runat="server" DataTextField="nama_officer" DataValueField="kode_officer" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">--Nama Officer--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtno_surat">
                            No Surat
                        </label>
                        <asp:TextBox ID="txtno_surat" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtno_surat"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="tidak boleh ada angka dan tanda lain selain '," ForeColor="Red" ControlToValidate="txtno_surat"
                            ValidationExpression="^\b[0-9\]{1,100}$"></asp:RegularExpressionValidator>--%>
                    </div>
                    <div class="form-group">
                        <label for="txttglsurat">
                            Tanggal Surat
                        </label>
                        <asp:TextBox ID="txttglsurat" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txttglsurat"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtperihal">
                            Perihal
                        </label>
                        <asp:TextBox ID="txtperihal" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtperihal"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="tidak boleh ada angka dan tanda lain selain '" ForeColor="Red" ControlToValidate="txtperihal"
                            ValidationExpression="^\b[a-zA-Z\s_\']{1,100}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtasalsurat">
                            Asal Surat
                        </label>
                        <asp:TextBox ID="txtasalsurat" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtasalsurat"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Error Format" ForeColor="Red" ControlToValidate="txtasalsurat"
                            ValidationExpression="^\b[a-zA-Z\s_\-]{1,20}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtdisposisi">
                            Disposisi
                        </label>
                        <asp:TextBox ID="txtdisposisi" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtdisposisi"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Error Format" ForeColor="Red" ControlToValidate="txtdisposisi"
                            ValidationExpression="^\b[a-zA-Z\s_\-\']{1,20}$"></asp:RegularExpressionValidator>
                    </div>

                    <div class="form-group">
                        <label for="txtcatatan">
                            Alamat
                        </label>
                        <asp:TextBox ID="txtcatatan" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtcatatan"></asp:RequiredFieldValidator>
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
            document.forms["formdatasuratmasuk"].appendChild(c_val);
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

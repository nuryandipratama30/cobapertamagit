<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tampilanutama.aspx.cs" Inherits="percobaan.tampilanutama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdataobat" runat="server">
        <asp:MultiView ID="MultiViewdataobat" runat="server">
            <asp:View ID="View1" runat="server">
                <p style="padding-left: 400px; font-size: 30pt">Data Pengguna</p>
                <br />
                <div>
                    <button type="button" onclick="btnAdd0_Click" class="btn btn-default" data-toggle="modal"
                        data-target="#modal_form">
                        ADD DATA
                    </button>
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-bordered table-hover dataTables_filter" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Username" DataField="Username" />
                        <asp:BoundField HeaderText="Password" DataField="password" />
                        <asp:BoundField HeaderText="Status" DataField="status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btubah" CommandArgument='<%#Eval("Username").ToString() %>' CommandName="ubah" runat="server" CausesValidation="false">Ubah</asp:LinkButton>
                                <asp:LinkButton ID="btnhapus" runat="server" CommandArgument='<%#Eval("Username").ToString() %>' CommandName="Hapus" OnClientClick="ConfirmDelete()" CausesValidation="false">Hapus</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />

                <%--<div id="modal_form" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="form-group">
                                    <label for="txtkodeobat">
                                        Kode Obat
                                    </label>
                                    <asp:TextBox ID="txtkodeobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeobat"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="hanya bisa menginputkan huruf K,O dan 4 digit angka dibelakangnya(ex KO0001)" ForeColor="Red" ControlToValidate="txtkodeobat"
                                        ValidationExpression="^\b[0-9KP]{6}$"></asp:RegularExpressionValidator>

                                </div>
                                <div class="form-group">
                                    <label for="txtnamaobat">
                                        Nama Obat
                                    </label>
                                    <asp:TextBox ID="txtnamaobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnamaobat"></asp:RequiredFieldValidator>
                                
                                </div>
                                <div class="form-group">
                                    <label for="txtkhasiat">
                                        Khasiat Obat
                                    </label>
                                    <asp:TextBox ID="txtkhasiat" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkhasiat"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtktgobat">
                                        Kategori Obat
                                    </label>
                                    <asp:TextBox ID="txtktgobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtktgobat"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtdosisobat">
                                        Dosis Obat
                                    </label>
                                    <asp:TextBox ID="txtdosisobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtdosisobat"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtsatuanobat">
                                        Satuan Obat
                                    </label>
                                    <asp:TextBox ID="txtsatuanobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtsatuanobat"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtstokobat">
                                        Stok Obat
                                    </label>
                                    <asp:TextBox ID="txtstokobat" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtstokobat"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <!--<div class="modal-body">
                                ISI FORM
                            </div>-->
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary pull-left" data-dismiss="modal">Batal</button>
                                <asp:Button ID="btnsave" runat="server" Text="Simpan" CssClass="btn btn-primary" Width="79px" CausesValidation="False" OnClick="btnsave_Click" />
                            </div>
                        </div>
                    </div>
                </div>--%>
            </asp:View>
            <%--<asp:View ID="View2" runat="server">

                <div class="modal-header">
                    <div class="form-group">
                        <label for="txtkodeobatupd">
                            Kode Obat
                        </label>
                        <asp:TextBox ID="txtkodeobatupd" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeobatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtnamaobatupd">
                            Nama Obat
                        </label>
                        <asp:TextBox ID="txtnamaobatupd" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnamaobatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtkhasiatupd">
                            Khasiat Obat
                        </label>
                        <asp:TextBox ID="txtkhasiatupd" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkhasiatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtktgobatupd">
                            Kategori Obat
                        </label>
                        <asp:TextBox ID="txtktgobatupd" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtktgobatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtdosisobatupd">
                            Dosis Obat
                        </label>
                        <asp:TextBox ID="txtdosisobatupd" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtdosisobatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtsatuanobatupd">
                            Satuan Obat
                        </label>
                        <asp:TextBox ID="txtsatuanobatupd" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtsatuanobatupd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtstokobatupd">
                            Stok Obat
                        </label>
                        <asp:TextBox ID="txtstokobatupd" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtstokobatupd"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--<div class="modal-body">
                                ISI FORM
                            </div>-->
                <div class="modal-footer">
                    <asp:Button ID="btncancelupd" runat="server" Text="Batal" CssClass="btn btn-primary pull-left" Width="79px" CausesValidation="False" OnClick="btncancelupd_Click" />
                    <asp:Button ID="btnsaveupd" runat="server" Text="Simpan" CssClass="btn btn-primary" Width="79px" CausesValidation="False" OnClick="btnsaveupd_Click" />
                </div>

            </asp:View>--%>
        </asp:MultiView>
    </form>
    <!-- jQuery 3 -->
    <script src="styletampilan/vendors/jquery/dist/jquery.min.js"></script>
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
            document.forms["formdataobat"].appendChild(c_val);
        }
        $(function () {
            $('.gvv').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
        $(document).ready(function () {
            $(".nav li").removeClass("active");
            $('#Dataobat').addClass('active');
        });
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dataorder.aspx.cs" Inherits="percobaan.dataorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formdataorder" runat="server">
        <asp:MultiView ID="MultiVieworder" runat="server">
            <asp:View ID="View1" runat="server">
                <label style="padding-left: 520px; font-size: 40pt">Data Order</label>
                <br />
                <div>
                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary pull-left" Text="Tambah Order" CausesValidation="False" OnClick="btnAdd0_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="gvv table table-striped table-hover table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kode_order" HeaderText="Kode Order" />
                        <%--<asp:BoundField HeaderText="Kode Klien" DataField="kode_klien" />--%><%--<asp:BoundField HeaderText="Kode Officer" DataField="kode_officer" />--%><%--<asp:BoundField HeaderText="Kode Layanan" DataField="kode_layanan" />--%>
                        <asp:BoundField DataField="layanan" HeaderText="Layanan" />
                        <%--<asp:BoundField HeaderText="Deskripsi" DataField="deskripsi" />--%>
                        <asp:BoundField DataField="no_akta" HeaderText="No Akta" />
                        <asp:BoundField DataField="no_berkas" HeaderText="No Berkas" />
                        <asp:BoundField DataField="sifat_akta" HeaderText="Sifat Akta" />
                        <%--<asp:BoundField HeaderText="Status" DataField="status" />--%>
                        <asp:BoundField DataField="biaya" HeaderText="Biaya" />
                        <%--<asp:BoundField HeaderText="Tanggal Order" DataField="tgl_order" />--%><%--<asp:BoundField HeaderText="Catatan" DataField="catatan" />--%>
                        <asp:TemplateField ControlStyle-ForeColor="Blue" HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_order").ToString()%>' CommandName="ubah"><img src="stylelogin/images/edit.png" title="ubah" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_order").ToString()%>' CommandName="hapus" OnClientClick="ConfirmDelete()"><img src="stylelogin/images/delete.png" title="hapus" width="20" /></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("kode_order").ToString()%>' CommandName="btndetilorder" ControlStyle-ForeColor="Blue">Detil</asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle ForeColor="Blue" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="modal-header" style="text-align: center">
                    <label><b>Form Order</b></label>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtkodeorder">
                            Kode Order
                        </label>
                        <asp:TextBox ID="txtkodeorder" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtkodeorder"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="hanya bisa menginputkan huruf K,O dan 4 digit angka dibelakangnya(ex KO0001)" ForeColor="Red" ControlToValidate="txtkodeorder"
                            ValidationExpression="^\b[0-9KO]{6}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="ddlkodeklien">
                            Kode Klien
                        </label>
                        <asp:DropDownList ID="ddlkodeklien" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="ddlkodelayanan">
                            Kode Layanan
                        </label>
                        <asp:DropDownList ID="ddlkodelayanan" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="ddlkodeofficer">
                            Kode Officer
                        </label>
                        <asp:DropDownList ID="ddlkodeofficer" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txtlayanan">
                            Layanan
                        </label>
                        <asp:TextBox ID="txtlayanan" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtlayanan"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Hanya Boleh menginputkan huruf" ForeColor="Red" ControlToValidate="txtlayanan"
                            ValidationExpression="^\b[a-zA-Z\s_]{1,100}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtdeskripsi">
                            Deskripsi
                        </label>
                        <asp:TextBox ID="txtdeskripsi" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtdeskripsi"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtnoakta">
                            No Akta
                        </label>
                        <asp:TextBox ID="txtnoakta" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnoakta"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="hanya bisa menginputkan angka" ForeColor="Red" ControlToValidate="txtnoakta"
                            ValidationExpression="^\b[0-9]{0,13}$"></asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtnoberkas">
                            No Berkas
                        </label>
                        <asp:TextBox ID="txtnoberkas" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtnoberkas"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="hanya bisa menginputkan angka" ForeColor="Red" ControlToValidate="txtnoberkas"
                            ValidationExpression="^\b[0-9]{0,13}$"></asp:RegularExpressionValidator>

                    </div>

                    <div class="form-group">
                        <label for="txtsifatakta">
                            Sifat Akta
                        </label>
                        <asp:TextBox ID="txtsifatakta" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtsifatakta"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="maaf hanya bisa menggunakan huruf" ForeColor="Red" ControlToValidate="txtsifatakta"
                            ValidationExpression="^\b[a-zA-Z\s_]{1,50}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="status">
                            Status
                        </label>
                    </div>
                    <div class="form-group">
                        <asp:RadioButton ID="rb_aktif" Text="Aktif" Style="padding-right: 100px" BorderStyle="Groove" runat="server" GroupName="status" />
                        <asp:RadioButton ID="rb_tidak_aktif" Text="Tidak Aktif" Style="padding-right: 70px" BorderStyle="Groove" runat="server" GroupName="status" />
                    </div>
                    <div class="form-group">
                        <label for="txtbiaya">
                            Biaya
                        </label>
                        <asp:TextBox ID="txtbiaya" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtbiaya"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="hanya bisa menginputkan angka" ForeColor="Red" ControlToValidate="txtbiaya"
                            ValidationExpression="^\b[0-9]{1,13}$"></asp:RegularExpressionValidator>

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
                            <label for="lblkodeorder">
                                Kode Order
                            </label>
                        </td>
                        <td style="height: 26px">:</td>
                        <td style="height: 26px">
                            <asp:Label ID="lblkodeorder" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 184px">
                            <label for="lblkodeklien">
                                Kode Klien
                            </label>
                        </td>
                        <td style="height: 26px">:</td>
                        <td style="height: 26px">
                            <asp:Label ID="lblkodeklien" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 184px">
                            <label for="lblkodelayanan">
                                Kode Layanan
                            </label>
                        </td>
                        <td style="height: 26px">:</td>
                        <td style="height: 26px">
                            <asp:Label ID="lblkodelayanan" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 184px">
                            <label for="lblkodeofficer">
                                Kode Officer
                            </label>
                        </td>
                        <td style="height: 26px">:</td>
                        <td style="height: 26px">
                            <asp:Label ID="lblkodeofficer" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lbllayanan">
                                Layanan
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lbllayanan" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lbldeskripsi">
                                Deskripsi
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lbldeskripsi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblnoakta">
                                Nomor Akta
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblnoakta" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblnoberkas">
                                Nomor Berkas
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblnoberkas" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblsifatakta">
                                Sifat Akta
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblsifatakta" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblstatus">
                                Status
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lbltglorder">
                                Tanggal Order
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lbltglorder" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblbiaya">
                                Biaya
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblbiaya" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <label for="lblcatatan">
                                Catatan
                            </label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblcatatan" runat="server" Text="lblcatatan"></asp:Label></td>
                    </tr>
                </table>

                <div class="pl-0 pt-3">
                    <asp:Button ID="btnkembali" runat="server" CssClass="btn btn-primary" Text="Kembali" CausesValidation="False" OnClick="btnkembali_Click" />
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
            document.forms["formdataorder"].appendChild(c_val);
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

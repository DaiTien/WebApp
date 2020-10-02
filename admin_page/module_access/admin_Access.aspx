<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_Access.aspx.cs" Inherits="admin_page_module_access_admin_Access" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script type="text/javascript">
        <%--function UF() {
            swal("Bạn muốn đặt quyền hạn cho user này?",
                "",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        var change = document.getElementById('<%=btnPhanQuyen.ClientID%>');
                        change.click();
                    }
                });
        }--%>
        function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }
        function btnCT() {
            document.getElementById('<%=btnCT.ClientID%>').click();
        }
        // get ID Module
        function checkid(id) {
            var arrayvalue = document.getElementById("<%= txtDanhSachChecked.ClientID %>").value;
            var array = JSON.parse("[" + arrayvalue + "]");
            var index = array.indexOf(id);
            if (index > -1) {
                array.splice(index, 1);
                document.getElementById("<%= txtDanhSachChecked.ClientID %>").value = array;
                document.getElementById("<%= txtCountChecked.ClientID %>").value = document.getElementById("<%= txtCountChecked.ClientID %>").value - 1;
            }
            else {
                document.getElementById("<%= txtCountChecked.ClientID %>").value = array.push(id);
                document.getElementById("<%= txtDanhSachChecked.ClientID %>").value = array;
            }
        }
        //Lấy Id module
        function myModule(id) {
            document.getElementById("<%= IdModule.ClientID%>").value = id;
            document.getElementById("<%= btnModule.ClientID%>").click();
        }
        //Lấy Id của User rồi load form của User ấy ra
        function myForm(id) {
            document.getElementById("<%= IdUser.ClientID%>").value = id;
            document.getElementById("<%= btnUser.ClientID%>").click();
        }
        //Get id Form
        function checkFormID(id) {
            var arr = document.getElementById("<%= txtId.ClientID %>").value;
            var array2 = JSON.parse("[" + arr + "]");
            var index2 = array2.indexOf(id);
            if (index2 > -1) {
                array2.splice(index2, 1);
                document.getElementById("<%= txtId.ClientID %>").value = array2;
                document.getElementById("<%= txtCountId.ClientID %>").value = document.getElementById("<%= txtCountId.ClientID %>").value - 1;
            }
            else {
                document.getElementById("<%= txtCountId.ClientID %>").value = array2.push(id);
                document.getElementById("<%= txtId.ClientID %>").value = array2;
            }
        }
        //Get ID Username
        function checkIdUser(id) {
            var arr = document.getElementById("<%= txtIdUser.ClientID %>").value;
            var arrayU = JSON.parse("[" + arr + "]");
            var indexU = arrayU.indexOf(id);
            if (indexU > -1) {
                arrayU.splice(indexU, 1);
                document.getElementById("<%= txtIdUser.ClientID %>").value = arrayU;
                document.getElementById("<%= txtCountIdUser.ClientID %>").value = document.getElementById("<%= txtCountIdUser.ClientID %>").value - 1;
            }
            else {
                document.getElementById("<%= txtCountIdUser.ClientID %>").value = arrayU.push(id);
                document.getElementById("<%= txtIdUser.ClientID %>").value = arrayU;
            }
        }
    </script>
    <asp:UpdatePanel ID="upAccess" runat="server">
        <ContentTemplate>
            <input id="txtDanhSachChecked" runat="server" type="text" placeholder="idModule"  />
            <input id="txtCountChecked" runat="server" type="text" />
            <input id="txtId" runat="server" type="text" placeholder="idForm" />
            <input id="txtCountId" runat="server" type="text" />
            <input id="txtIdUser" runat="server" type="text" placeholder="idUser" />
            <input id="txtCountIdUser" runat="server" type="text" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title-block hidden-xs-up">
        <h3 class="title">Phân quyền Group User - Module - Form<span class="sparkline bar" data-type="bar"></span></h3>
    </div>
    <div class="card card-block">
        <div class="row">
            <div class="col-lg-3">
                <div class="ct" style="display: none">
                    <asp:Button CssClass="btn btn-primary" ID="btnChiTiet" runat="server" OnClick="btnChiTiet_Click" Text="chi tiết"></asp:Button>
                    <asp:Button CssClass="btn btn-primary" ID="btnCT" runat="server" OnClick="btnCT_Click" Text="chi tiết"></asp:Button>
                </div>
                <h4 class="title">Group User</h4>
                <hr />
                <dx:ASPxGridView ID="grvGUser" runat="server" ClientInstanceName="grvGUser" KeyFieldName="groupuser_id" Width="100%">
                    <Columns>
                        <dx:GridViewDataColumn Caption="Groupuser Name" FieldName="groupuser_name" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataColumn>
                    </Columns>
                    <ClientSideEvents RowDblClick="btnChiTiet" />
                    <%--<ClientSideEvents FocusedRowChanged="function(s,e){grvForm.Refresh();}" />--%>
                    <SettingsBehavior AllowFocusedRow="true" />
                    <SettingsText EmptyDataRow="Empty" />
                    <SettingsLoadingPanel Text="Loading..." />
                    <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                </dx:ASPxGridView>
            </div>
            <%--List Module--%>
            <div class="col-lg-3">
                <h4 class="title">List Module</h4>
                <hr />
                <div class="mdl-name col-12">
                    <asp:Repeater ID="rptModule" runat="server">
                        <ItemTemplate>
                            <div class="col-12 ">
                                <label class="label-checkbox font-weight-normal">
                                    <input type="checkbox" id="<%#Eval("module_id") %>" value="(<%#Eval("module_id") %>)" <%#Eval("check123") %> onclick="checkid(<%#Eval("module_id") %> )">
                                </label>
                                <a href="javascript: void(0);" id="btnmdf" class="btn btn-ligt" onclick="myModule(<%#Eval("module_id") %> );LoadF() "><%#Eval("module_name")%></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-sm-10">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnLuuM" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnLuuM_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--User--%>
            <div class="col-lg-3">
                <h4 class="title">User</h4>
                <hr />
                <asp:Repeater ID="rpUser" runat="server">
                    <ItemTemplate>
                        <div class="col-12 ">
                            <label class="label-checkbox font-weight-normal">
                                <input type="checkbox" id="<%#Eval("username_id") %>" value="(<%#Eval("username_id") %>)"  onclick="checkIdUser(<%#Eval("username_id") %> )">
                            </label>
                            <a href="javascript:void(0);" id="btnUser" class="btn btn-ligt" onclick="myModule(<%#Eval("username_id") %> );"><%#Eval("username_username")%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%--<dx:ASPxGridView ID="grvUser" runat="server" ClientInstanceName="grvUser" KeyFieldName="username_id" Width="100%">
                    <Columns>
                        <dx:GridViewDataColumn Caption="User Name" FieldName="username_username" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataColumn>
                    </Columns>
                    <ClientSideEvents FocusedRowChanged="function(s,e){grvUserForm.Refresh();}" />
                    <ClientSideEvents RowDblClick="btnCT" />
                    <SettingsBehavior AllowFocusedRow="true" />
                    <SettingsText EmptyDataRow="Empty" />
                    <SettingsLoadingPanel Text="Loading..." />
                    <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                </dx:ASPxGridView>--%>
            </div>
            <%--List Form--%>
            <div class="col-lg-3">
                <h4 class="title">List Form</h4>
                <hr />
                <div class="mdl-name col-12">
                    <asp:Repeater ID="rptForm" runat="server">
                        <ItemTemplate>
                            <div class="col-1 ">
                                <input type="checkbox" id="<%#Eval("form_id") %>" value="(<%#Eval("form_id") %>)" <%#Eval("check123") %> onclick="checkFormID(<%#Eval("form_id") %> )">
                            </div>
                            <p><%#Eval("form_name") %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-sm-10">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnLuF" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnLuF_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--End list form--%>
        </div>
    </div>
    <div style="display: none">
        <input id="IdModule" type="text" runat="server" />
        <button id="btnModule" runat="server" onserverclick="btnForm_ServerClick"></button>
        <input id="IdUser" type="text" runat="server" />
        <button id="btnUser" runat="server" onserverclick="btnUser_ServerClick"></button>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


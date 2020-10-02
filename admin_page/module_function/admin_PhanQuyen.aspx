<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_PhanQuyen.aspx.cs" Inherits="admin_page_module_function_admin_PhanQuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <link href="../../admin_css/sweetalert.css" rel="stylesheet" />
    <script src="../../admin_js/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
    <div class="az-content pd-y-20 pd-lg-y-30 pd-xl-y-40">
        <div class="container-fluid">
            <!-- az-content-left -->
            <div class="az-content-body d-flex flex-column">
                <div class="az-content-breadcrumb">
                    <span>Admin</span>
                    <span>Phân quyền</span>
                </div>
                <h2 class="az-content-title">Phân quyền</h2>


                <div class="card card-table-one">
                    <div class="row">

                        <div class="col-md-6">
                            <div class="az-content-label mg-b-5">Thêm tài khoản</div>
                            <div class="form-group">
                                <label class="form-control-label">Họ tên:</label>
                                <asp:TextBox ID="txttenVN" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Giới tính:</label>
                                        <select id="slGioitinh" runat="server" class="form-control">
                                            <option value="0">Nữ</option>
                                            <option value="1">Nam</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Bộ phận:</label>
                                        <asp:DropDownList ID="ddlBophan" Width="90%" CssClass="form-control" DataValueField="groupuser_id" DataTextField="groupuser_name" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>Số điện thoại:</label>
                                <asp:TextBox ID="txtPhone" runat="server" onkeypress="return isNumber(event)" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Tài khoản:</label>
                                <asp:TextBox ID="txtAccount" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Mật khẩu:</label>
                                <asp:TextBox ID="txtPass" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                            </div>
                            <div class="form-group">
                                <a href="javascript:void(0);" id="btnLuu" class="btn btn-primary" runat="server" onserverclick="btnLuu_ServerClick">Thêm</a>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div id="modaldemo1" class="modal">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content modal-content-demo">
                                        <div class="modal-header">
                                            <h6 class="modal-title">Đổi Mật Khẩu</h6>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <%--<div class="row">
                                                <div class="col-md-3 mg-t-10">Mật Khẩu Cũ : </div>
                                                <input id="txtMKcu" runat="server" placeholder="Nhập mật khẩu cũ" class="col-md-4 mg-t-10 form-control" />
                                            </div>--%>
                                            <div class="row">
                                                <div class="col-md-3 mg-t-10">Mật Khẩu mới : </div>
                                                <input id="txtMKmoi" runat="server" placeholder="Nhập mật khẩu mới" class="col-md-4 mg-t-10 form-control" />
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3 mg-t-10">Xác nhận mật khẩu : </div>
                                                <input id="txtXacnhanMk" runat="server" placeholder="Nhập lại mật khẩu mới" class="col-md-4 mg-t-10 form-control" />
                                            </div>
                                            <%--<div class="row">
                                                <div class="col-md-3 mg-t-10">Email : </div>
                                                <input id="txtgmail" runat="server" placeholder="Nhập Email" class="col-md-4 mg-t-10 form-control" />
                                            </div>--%>
                                            <div class="row">
                                                <button id="btnDoiMatKhau" runat="server" onserverclick="btnDoiMatKhau_ServerClick" class="btn btn-primary mg-t-10">Lưu</button>
                                            </div>
                                            <!-- modal-dialog -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="ht-20"></div>
                            <div class="table-responsive ">
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Tài Khoản</th>
                                            <%--<th>Mật Khẩu</th>--%>
                                            <th>Bộ Phận</th>
                                            <th class="wd-80">Hành động</th>
                                            <th class="wd-80">ResetPassword</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpUser" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("username_username") %></td>
                                                    <%--<td><%#Eval("username_password") %></td>--%>
                                                    <td><%#Eval("groupuser_name") %></td>
                                                    <td><a href="#" id="btnDlt" class="btn btn-danger" onclick="getId(<%#Eval("username_id") %>);">Xóa</a></td>
                                                    <td><a href="#" id="btnReset" class="btn btn-primary" onclick="getIdDoiMatKhau(<%#Eval("username_id") %>)">ResetPassword</a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="ht-40"></div>
                    <div style="display: none">
                        <input id="txtId" runat="server" type="text" />
                        <a href="#" id="btnXoa" runat="server" onserverclick="btnXoa_ServerClick1"></a>
                        <a href="#" id="btnResert" runat="server" onserverclick="btnDoiMatKhau_ServerClick"></a>
                    </div>

                </div>
                <div class="ht-40"></div>

            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>

    <script>
        function getId(id) {
            document.getElementById("<%= txtId.ClientID %>").value = id;
            document.getElementById("<%= btnXoa.ClientID %>").click();
        }
        function getIdDoiMatKhau(id) {
            document.getElementById("<%= txtId.ClientID %>").value = id;
            document.getElementById("<%= btnResert.ClientID%>").click();
        }
        //Xóa
        <%--function confirmDel() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%= btnXoa.ClientID %>").click();
                    }
                });
            }--%>
</script>




</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


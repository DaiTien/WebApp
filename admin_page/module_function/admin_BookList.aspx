<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_BookList.aspx.cs" Inherits="admin_page_module_function_admin_BookList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
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
                    <span>Booking</span>
                    <span>Danh Sách Booking</span>
                </div>
                <h2 class="az-content-title">Danh Sách Booking</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->



                <div>
                    <div class="row d-flex flex-row-reverse mg-b-20">
                        <%--<div class="col-sm-2 col-md-2"><a href="#" class="btn btn-primary btn-block ">Sửa</a></div>--%>
                        <div class="col-sm-2 col-md-2"><a href="#" onclick="btnThem();" class="btn btn-primary btn-block">Thêm</a></div>
                    </div>
                    <!--Edit-->

                    <!-- End Edit-->
                    <table id="example2" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="wd-5p">Mã giao dịch</th>
                                <%--<th class="wd-5p">Giá / Ngày</th>
                                <th class="wd-5p">Loại giá</th>
                                <th class="wd-5p">Giá trị hiển thị</th>
                                <th class="wd-5p">Tên CTKM</th>--%>
                                <th class="wd-5p">Tòa nhà</th>
                                <th class="wd-5p">Số phòng</th>
                                <th class="wd-5p">Ngày đến</th>
                                <th class="wd-5p">Ngày đi</th>
                                <th class="wd-5p">Tên khách</th>
                                <th class="wd-5p">ID khách</th>
                                <th class="wd-5p">Quốc tịch</th>
                                <th class="wd-5p">Ngày book</th>
                                <th class="wd-5p">Tình trạng</th>
                                <th class="wd-5p">Ghi chú</th>
                                <th class="wd-5p">Hành Động</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpOrder" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("order_codeTrading") %></td>
                                        <%--<td>100000đ</td>
                                        <td>10000đ</td>
                                        <td>10000đ</td>
                                        <td>121434</td>--%>
                                        <td><%#Eval("building_name") %></td>
                                        <td><%#Eval("order_amount") %></td>
                                        <td><%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_nameGuest") %></td>
                                        <td><%#Eval("order_IdGuest") %></td>
                                        <td><%#Eval("order_country") %></td>
                                        <td><%#Eval("order_dateBook","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_status") %></td>
                                        <td><%#Eval("order_Ghichu") %></td>
                                        <%--<td><a id="<%#Eval("order_id") %>" href="admin_SearchRoom.aspx" class="btn btn-primary" onclick="checkIRoom(<%#Eval("order_id") %>);btnShow();">Hành động</a></td>--%>
                                        <td><a class="btn btn-primary" href="javascript:void(0)" onclick="checkIRoom(<%#Eval("order_id") %>);btnShow();">Edit</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <div class="ht-40"></div>
            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
    <input id="btnAct" type="button" onserverclick="btnAct_ServerClick" runat="server" hidden />
    <input id="btnAdd" type="button" onserverclick="btnAdd_ServerClick" runat="server" hidden />
    <input id="txtId" runat="server" type="text" placeholder="id" hidden />
    <input id="txtCountId" runat="server" type="text" hidden />
    <script>
        function btnThem() {
            document.getElementById('<%=btnAdd.ClientID%>').click();
        }
        function btnShow() {
            document.getElementById('<%=btnAct.ClientID%>').click();
        }
        function Clear() {
            document.getElementById("<%= txtId.ClientID %>").value = "";
            document.getElementById("<%= txtCountId.ClientID %>").value = "";
        }
        function checkIRoom(id) {
            document.getElementById("<%= txtId.ClientID %>").value = id;
        }
        function clicksearch(a) {
            document.location.href = "/admin_page/module_function/admin_BookAddEdit1.aspx?tinhtrang=" + a ;
        }
    </script>
    <!-- az-content1 -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_SearchRoom.aspx.cs" Inherits="admin_page_module_function_admin_SearchRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script src="../../admin_js/sweetalert.min.js"></script>
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
                    <span>Search</span>
                </div>
                <h2 class="az-content-title">Search</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <%--<div class="row d-flex flex-row-reverse mg-b-20">
                        <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block">Check Out</button></div>
                        <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block">No Show</button></div>
                        <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block">Check In</button></div>
                    </div>--%>
                </div>
                <div>
                    <%--<div class="row d-flex flex-row-reverse mg-b-20">
                        <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block ">Sửa</button></div>
                        <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block">Thêm</button></div>

                    </div>--%>
                </div>

                <div class="card card-table-one">
                    <div class="row">
                        <div class="col-md-3 wd-200 mg-b-20">
                            <label for="">Từ ngày:</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        Date:
                                    </div>
                                </div>
                                <input id="dateStart" runat="server" type="text" class="form-control" placeholder="DD/MM/YYYY" />
                            </div>
                        </div>
                        <div class=" col-md-3 wd-200 mg-b-20 ">
                            <label for="">Đến ngày:</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        Date:
                                    </div>
                                </div>
                                <input id="dateEnd" runat="server" type="text" class="form-control" placeholder="DD/MM/YYYY" />
                            </div>
                        </div>
                        <div class="col-md-3 wd-200 mg-b-20">
                            <label>Chọn buiding:</label>
                            <asp:DropDownList ID="ddBuilding" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-1 mg-t-7 pd-l-0 pd-r-30 ">
                            <label></label>
                            <button id="btnLoc" runat="server" onserverclick="btnLoc_ServerClick" class="btn btn-primary btn-block ">Lọc</button>
                        </div>
                        <div class="col-md-1 mg-t-7 pd-l-0 pd-r-30 ">
                            <label></label>
                            <button id="btnBook" runat="server" onserverclick="btnBook_ServerClick" class="btn btn-primary btn-block">Book</button>
                        </div>
                    </div>

                    <div class="ht-20"></div>
                    <div class="table-responsive ">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th class="wd-20 ">Check</th>
                                    <th>Tên Phòng</th>
                                    <th>Loại Phòng</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpRoom" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <label class="ckbox">
                                                    <input type="checkbox" onclick="checkIRoom(<%#Eval("room_id")%>)"><span></span></label>
                                            </td>
                                            <td><%#Eval("room_name") %></td>
                                            <td><%#Eval("listing_name") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </div>
                <div class="ht-40"></div>

            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
    <input id="txtId" runat="server" type="text" placeholder="id" hidden />
    <input id="txtCountId" runat="server" type="text" hidden />
    <script>
        function checkIRoom(id) {
            var arr = document.getElementById("<%= txtId.ClientID %>").value;
            var arrayU = JSON.parse("[" + arr + "]");
            var indexU = arrayU.indexOf(id);
            if (indexU > -1) {
                arrayU.splice(indexU, 1);
                document.getElementById("<%= txtId.ClientID %>").value = arrayU;
                document.getElementById("<%= txtCountId.ClientID %>").value = document.getElementById("<%= txtCountId.ClientID %>").value - 1;
            }
            else {
                document.getElementById("<%= txtCountId.ClientID %>").value = arrayU.push(id);
                document.getElementById("<%= txtId.ClientID %>").value = arrayU;
            }
        }
    </script>
    <!-- az-content -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

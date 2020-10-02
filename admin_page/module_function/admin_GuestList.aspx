<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_GuestList.aspx.cs" Inherits="admin_page_module_function_admin_VerifyGuest" %>

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
                    <span>Danh Sách Guest</span>
                </div>
                <h2 class="az-content-title">Danh Sách Guest</h2>
                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <div class="flex-wrap d-flex mg-b-20">
                        <div class="wd-25p mg-r-5">
                            <p class="mg-b-10">Building</p>
                            <asp:DropDownList ID="ddBuilding" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" runat="server"></asp:DropDownList>
                        </div>

                        <div class="mg-t-15 mg-r-15">
                            <p></p>
                            <a href="#" class="btn btn-primary btn-block ">Lọc</a>

                        </div>

                    </div>
                    <%--<div id="modaldemo1" class="modal">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content modal-content-demo">
                                <div class="modal-header">
                                    <h6 class="modal-title">Chi Tiết Verify Guest</h6>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-4 mg-t-30">Tên khách</div>
                                        <div class="col-md-4 mg-t-30">Số hộ chiếu</div>
                                        <div class="col-md-4 mg-t-30">ID khách</div>
                                        <div class="col-md-4 mg-t-30">Quốc tịch</div>
                                        <div class="col-md-4 mg-t-30">Khu vực địa lý</div>
                                        <div class="col-md-4 mg-t-30">Ngày sinh</div>
                                        <div class="col-md-4 mg-t-30">Email</div>
                                        <div class="col-md-4 mg-t-30">Số mobile</div>
                                        <div class="col-md-4 mg-t-30">Nghề nghiệp</div>
                                        <div class="col-md-4 mg-t-30">Ngày đến</div>
                                        <div class="col-md-4 mg-t-30">Ngày đi</div>
                                        <div class="col-md-4 mg-t-30">Tòa nhà</div>
                                        <div class="col-md-4 mg-t-30">Số phòng</div>
                                    </div>
                                    <div class="ht-20"></div>
                                    <div class="row">
                                        <div class=" col-md-6">
                                            <button class="btn btn-primary btn-block">Duyệt</button>
                                        </div>
                                        <div class=" col-md-6">
                                            <button class="btn btn-primary btn-block">Không Duyệt</button>
                                        </div>
                                    </div>
                                    <div class="ht-20"></div>
                                    <textarea rows="6" class="form-control" placeholder="Ghi chú"></textarea>
                                </div>


                            </div>
                        </div>
                        <!-- modal-dialog -->
                    </div>--%>
                    <!-- modal -->
                    <table id="example2" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="wd-5p">Tên khách</th>
                                <th class="wd-5p">ID khách</th>
                                <th class="wd-5p">Quốc tịch</th>
                                <th class="wd-10p">Khu vực địa lý</th>
                                <th class="wd-5p">Ngày sinh</th>
                                <th class="wd-5p">Nghề nghiệp</th>
                                <th class="wd-5p">Ngày đến</th>
                                <th class="wd-5p">Ngày đi</th>
                                <th class="wd-5p">Tòa nhà</th>
                                <th class="wd-5p">Hành động</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpGuest" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("order_nameGuest") %></td>
                                        <td><%#Eval("order_IdGuest") %></td>
                                        <td><%#Eval("order_country") %></td>
                                        <td><%#Eval("order_khuvucdialy") %></td>
                                        <td><%#Eval("order_guestNgaySinh","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_guestNgheNghiep") %></td>
                                        <td><%# String.Format("{0:dd/MM}", Eval("order_checkin")) %></td>
                                        <td><%# String.Format("{0:dd/MM}", Eval("order_checkout")) %></td>
                                        <td><%#Eval("building_name") %></td>
                                        <td>
                                            <a class="btn btn-primary btn-block" href="#" onclick="getID(<%#Eval("order_id") %>)">Chi Tiết</a>
                                        </td>

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
    <div style="display: none">
        <asp:Button ID="btnChiTiet" runat="server" OnClick="btnChiTiet_Click" />
        <input runat="server" id="idGuest" type="text" />
    </div>
    <input id="btnAct" type="button" onserverclick="btnAct_ServerClick" runat="server" hidden />
    <input id="txtId" runat="server" type="text" placeholder="id" hidden />
    <input id="txtCountId" runat="server" type="text" hidden />
    <script>
        function getID(id) {
            document.getElementById("<%= idGuest.ClientID %>").value = id;
            document.getElementById("<%= btnChiTiet.ClientID %>").click();
        }
        function btnShow() {
            document.getElementById('<%=btnAct.ClientID%>').click();
        }
        function Clear() {
            document.getElementById("<%= txtId.ClientID %>").value = "";
            document.getElementById("<%= txtCountId.ClientID %>").value = "";
        }
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


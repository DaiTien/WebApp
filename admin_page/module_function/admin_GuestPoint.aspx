<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_GuestPoint.aspx.cs" Inherits="admin_page_module_function_admin_GuestPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <link href="../../admin_css/sweetalert.css" rel="stylesheet" />
    <script src="../../admin_js/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="az-content pd-y-20 pd-lg-y-30 pd-xl-y-40">
        <div class="container-fluid">
            <!-- az-content-left -->
            <div class="az-content-body d-flex flex-column">
                <div class="az-content-breadcrumb">
                    <span>Admin</span>
                    <span>View</span>
                    <span>View Guest</span>

                </div>
                <h2 class="az-content-title">Xem điểm khách hàng</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <div class="flex-wrap d-flex mg-b-20">
                        <div class="mx-wd-20p mg-r-5">
                            <p class="mg-b-10">ID khách hàng :</p>
                            <input id="txtIdKhach" runat="server" type="text" class="form-control" placeholder="nhập ID khách hàng" />
                        </div>


                        <div class="mg-t-15 mg-r-15">
                            <p></p>
                            <a href="javascript:void(0)" id="btnTimKiem" runat="server" onserverclick="btnTimKiem_ServerClick" class="btn btn-primary btn-block ">Tìm kiếm</a>

                        </div>
                        <%--<asp:Repeater ID="rpViewTimKiem" runat="server">
                            <ItemTemplate>--%>
                                <div class="mx-wd-20p mg-r-5">
                                    <p class="mg-b-10">Tổng điểm tích lũy :</p>
                                    <input id="txtDiemtichluy" runat="server" type="text" class="form-control" disabled="disabled"  />
                                </div>
                                <div class="mx-wd-20p mg-r-5">
                                    <p class="mg-b-10">Tổng điểm TRIPLE money :</p>
                                    <input type="text" class="form-control" value="<%=tripleMoney %>" disabled="disabled"  />
                                </div>
                            <%--</ItemTemplate>
                        </asp:Repeater>--%>

                        <%--<div class="mg-t-15">
                            <p></p>
                            <button class="btn btn-primary btn-block" id="btnXuatExcel" runat="server" onserverclick="btnXuatExcel_ServerClick">Xuất Excel</button>


                        </div>--%>
                    </div>
                    <asp:Repeater ID="rpViewChiTiet" runat="server">
                        <ItemTemplate>
                            <div id="modaldemo<%#Eval("order_id") %>" class="modal">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content modal-content-demo">
                                        <div class="modal-header">
                                            <h6 class="modal-title">Chi Tiết View Guest</h6>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-6 mg-t-10">Tên Khách: <%#Eval("order_nameGuest") %></div>
                                                <div class="col-md-6 mg-t-10">Số Hộ Chiếu: <%#Eval("order_passport") %></div>
                                                <div class="col-md-6 mg-t-10">ID Khách: <%#Eval("order_IdGuest") %></div>
                                                <div class="col-md-6 mg-t-10">Quốc Tịch: <%#Eval("order_country") %></div>
                                                <div class="col-md-6 mg-t-10">Khu Vực Địa Lý: <%#Eval("order_khuvucdialy") %></div>
                                                <div class="col-md-6 mg-t-10">Ngày Sinh: <%#Eval("order_guestNgaySinh","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Email: <%#Eval("order_guestEmail") %></div>
                                                <div class="col-md-6 mg-t-10">Số Mobile: <%#Eval("order_guestPhone") %></div>
                                                <div class="col-md-6 mg-t-10">Phương tiện liên lạc khác: <%#Eval("order_phuongtienlienlackhac") %></div>
                                                <div class="col-md-6 mg-t-10">Nghề nghiệp: <%#Eval("order_guestNgheNghiep") %></div>
                                                <div class="col-md-6 mg-t-10">Ngày đến - ngày đi: <%#Eval("order_checkin","{0:dd/MM/yyyy}") %> - <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Tòa nhà: <%#Eval("building_name") %></div>
                                                <div class="col-md-6 mg-t-10">Số phòng: <%#Eval("order_amount") %></div>
                                                <div class="col-md-6 mg-t-10">Kênh book: <%#Eval("order_kenhBook") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm ở trước khi tới: <%#Eval("order_diadiemotruockhitoi") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm đến sau khi đi: <%#Eval("order_diadiemdensaukhidi") %></div>
                                                <div class="col-md-6 mg-t-10">Dự kiến thời gian quay lại: <%#Eval("order_dukienthoigianquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm nếu quay lại: <%#Eval("order_diadiemneuquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Dự kiến thời gian ở nếu quay lại: <%#Eval("order_dukienthoigianoneuquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Tính cách:</div>
                                                <div class="col-md-6 mg-t-10">Góp ý của khách: <%#Eval("order_gopykhachhang") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Điểm tích lũy: <%#Eval("dtl_diemtichluy") %></div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- modal-dialog -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- modal -->
                    <table id="example2" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="wd-10p">Tên khách</th>
                                <th class="wd-10p">ID khách</th>
                                <th class="wd-5p">Quốc tịch</th>
                                <th class="wd-10p">Khu vực địa lý</th>
                                <th class="wd-5p">Ngày sinh</th>
                                <th class="wd-5p">Email</th>
                                <th class="wd-5p">Số mobile</th>
                                <th class="wd-5p">Phương tiện liên hệ khác</th>
                                <th class="wd-5p">Nghề nghiệp</th>
                                <th class="wd-5p">Ngày đến</th>
                                <th class="wd-5p">Ngày đi</th>
                                <th class="wd-5p">Tòa nhà</th>
                                <th class="wd-5p">Số phòng</th>
                                <th class="wd-5p">Hành động</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpGuestPoint" runat="server">
                                <ItemTemplate>
                                    <%--<tr>
                                        <td><%#Eval("order_nameGuest") %></td>
                                        <td><%#Eval("dtl_IdGuest") %></td>
                                        <td><%#Eval("order_country") %></td>
                                        <td>Châu âu</td>
                                        <td><%#Eval("order_guestNgaySinh","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_guestEmail") %></td>
                                        <td><%#Eval("order_guestPhone") %></td>
                                        <td><%#Eval("order_phuongtienlienlackhac") %></td>
                                        <td><%#Eval("order_guestNgheNghiep") %></td>
                                        <td><%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("building_name") %></td>
                                        <td><%#Eval("order_amount") %></td>
                                        <td><a class="btn btn-primary btn-block" href="#" data-toggle="modal" data-target="#modaldemo<%#Eval("dtl_id") %>" onclick="getID(<%#Eval("dtl_id") %>)">Chi Tiết</a></td>
                                    </tr>--%>
                                    <tr>
                                        <td><%#Eval("order_nameGuest") %></td>
                                        <td><%#Eval("order_IdGuest") %></td>
                                        <td><%#Eval("order_country") %></td>
                                        <td><%#Eval("order_khuvucdialy") %></td>
                                        <td><%#Eval("order_guestNgaySinh","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_guestEmail") %></td>
                                        <td><%#Eval("order_guestPhone") %></td>
                                        <td><%#Eval("order_phuongtienlienlackhac") %></td>
                                        <td><%#Eval("order_guestNgheNghiep") %></td>
                                        <td><%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("building_name") %></td>
                                        <td><%#Eval("order_amount") %></td>
                                        <td><a class="btn btn-primary btn-block" href="#" data-toggle="modal" data-target="#modaldemo<%#Eval("order_id") %>" onclick="getID(<%#Eval("order_id") %>)">Chi Tiết</a></td>
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
        <input id="txtId" runat="server" type="text" value="" hidden="hidden" />
    </div>
    <script>
        function getID(id) {
            document.getElementById("<%= txtId.ClientID%>").value = id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


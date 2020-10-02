<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ViewGuest.aspx.cs" Inherits="admin_page_module_function_admin_ViewGuest" %>

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
                    <span>View</span>
                    <span>View Guest</span>

                </div>
                <h2 class="az-content-title">View Guest</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <div class="flex-wrap d-flex mg-b-20">
                        <div class="wd-25p mg-r-5">
                            <p class="mg-b-10">Building</p>
                            <%--<select class="form-control select2-no-search">
                                <option label="Choose one"></option>
                                <option value="Firefox">Firefox</option>
                                <option value="Chrome">Chrome</option>
                                <option value="Safari">Safari</option>
                                <option value="Opera">Opera</option>
                                <option value="Internet Explorer">Internet Explorer</option>
                            </select>--%>
                            <asp:DropDownList ID="ddBuilding" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" runat="server"></asp:DropDownList>
                        </div>

                        <div class="mg-t-15 mg-r-15">
                            <p></p>
                            <a href="#" id="btnLoc" runat="server" onserverclick="btnLoc_ServerClick" class="btn btn-primary btn-block ">Lọc</a>

                        </div>
                        <%--<div class="mg-t-15">
                            <p></p>
                            <button class="btn btn-primary btn-block" id="btnXuatExcel" runat="server" onserverclick="btnXuatExcel_ServerClick">Xuất Excel</button>


                        </div>--%>
                    </div>
                    <asp:Repeater ID="rpChitiet" runat="server">
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
                                                <div class="col-md-6 mg-t-10">Tên Khách:<%#Eval("order_nameGuest") %></div>
                                                <div class="col-md-6 mg-t-10">Số người đi cùng :</div>
                                                <div class="col-md-6 mg-t-10">Số Hộ Chiếu:<%#Eval("order_passport") %></div>
                                                <div class="col-md-6 mg-t-10">Kênh book:<%#Eval("order_kenhBook") %></div>
                                                <div class="col-md-6 mg-t-10">ID Khách:<%#Eval("order_IdGuest") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm ở trước khi tới:<%#Eval("order_diadiemotruockhitoi") %></div>
                                                <div class="col-md-6 mg-t-10">Quốc Tịch:<%#Eval("order_country") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm đến sau khi đi:<%#Eval("order_diadiemdensaukhidi") %></div>
                                                <div class="col-md-6 mg-t-10">Khu Vực Địa Lý:<%#Eval("order_khuvucdialy") %></div>
                                                <div class="col-md-6 mg-t-10">Dự kiến thời gian ở nếu quay lại:<%#Eval("order_dukienthoigianoneuquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Ngày Sinh:<%#Eval("order_guestNgaySinh","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Địa điểm nếu quay lại:<%#Eval("order_diadiemneuquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Email:<%#Eval("order_guestEmail") %></div>
                                                <div class="col-md-6 mg-t-10">Dự kiến thời gian quay lại:<%#Eval("order_dukienthoigianquaylai") %></div>
                                                <div class="col-md-6 mg-t-10">Số Mobile:<%#Eval("order_guestPhone") %></div>
                                                <div class="col-md-6 mg-t-10">Tính cách: <%#Eval("order_tinhcach") %></div>
                                                <div class="col-md-6 mg-t-10">Phương tiện liên lạc khác:<%#Eval("order_phuongtienlienlackhac") %></div>
                                                <div class="col-md-6 mg-t-10">Lý do đi du lịch, công tác: <%#Eval("order_lydo") %></div>
                                                <div class="col-md-6 mg-t-10">Nghề nghiệp:<%#Eval("order_guestNgheNghiep") %></div>
                                                <div class="col-md-6 mg-t-10">Góp ý của khách:<%#Eval("order_gopykhachhang") %></div>
                                                <div class="col-md-6 mg-t-10">Ngày :<%#Eval("order_checkin","{0:dd/MM/yyyy}") %> - <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Tổng tiền phòng tích lũy: <%#Eval("dtl_sumRoomprice") %></div>
                                                <div class="col-md-6 mg-t-10">Tòa nhà:<%#Eval("building_name") %></div>
                                                <div class="col-md-6 mg-t-10">Tổng tiền ăn uống tích lũy: <%#Eval("dtl_sumEatprice") %></div>
                                                <div class="col-md-6 mg-t-10">Số phòng:<%#Eval("order_amount") %></div>
                                                <div class="col-md-6 mg-t-10">Hạng khách hàng theo điểm phát sinh trong 1 năm: <%#Eval("dtl_hangGuest") %></div>
                                                <div class="col-md-6 mg-t-10">Điểm tích lũy: <%#Eval("dtl_diemtichluy") %></div>
                                                <div class="col-md-6 mg-t-10">Tiền quy đổi từ điểm tích lũy(TRIPLE money):</div>
                                      
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
                            <asp:Repeater ID="rpViewGuest" runat="server">
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
    </div>
    <!-- az-content -->
    <input runat="server" id="idGuest" type="text" hidden />
    <script>
        function getID(id) {
            document.getElementById("<%= idGuest.ClientID %>").value = id;
        }
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


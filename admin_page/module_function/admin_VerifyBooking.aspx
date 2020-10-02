<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_VerifyBooking.aspx.cs" Inherits="admin_page_module_function_admin_VerifyBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function clickData() {
            document.getElementById("btn_modal").click();
            //alert("ádfygdsahf")
        }
    </script>
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
                    <span>Verify</span>
                    <span>Verify books</span>
                </div>
                <h2 class="az-content-title">Verify Books</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <%--<div>
                    <asp:UpdatePanel runat="server" ID="rp_abc">
                        <ContentTemplate>
                            <a href="javascript:void(0)" class="btn btn-primary btn-block" id="btnChitiet" runat="server" onserverclick="btnChitiet_ServerClick" type="button" onclick="clickData()">Chi Tiết</a>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>--%>
                <div>
                    <div class="row d-flex flex-row-reverse mg-b-20">

                        <%-- <div class="col-sm-2 col-md-2">
                            <button class="btn btn-primary btn-block" id="btn_modal" type="button" data-toggle="modal" data-target="#modaldemo1">Chi Tiết</button></div>--%>
                    </div>
                    <asp:Repeater ID="rpChitiet" runat="server">
                        <ItemTemplate>
                            <div id="modaldemo<%#Eval("order_id") %>" class="modal">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content modal-content-demo">
                                        <div class="modal-header">
                                            <h6 class="modal-title">Chi Tiết Verify Booking</h6>
                                            <button type="button" onclick="Clear()" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-6 mg-t-10">Mã Giao Dịch : <%#Eval("order_codeTrading") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu phòng (từ ngày ... Đến ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Gía phòng / Ngày : <%#Eval("order_priceRoom", "{0:n0}") %>₫</div>
                                                <%--<div class="col-md-6 mg-t-10">Doang thu ăn uống (ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Loại giá : <%#Eval("order_loaiGia") %></div>
                                                <div class="col-md-6 mg-t-10">Giá trị hiển thị : <%#Eval("order_priceShow", "{0:n0}") %>₫</div>
                                                <div class="col-md-6 mg-t-10">Tên CTKM : <%#Eval("order_nameCTKM") %></div>
                                                <div class="col-md-6 mg-t-10">Tòa nhà : <%#Eval("building_name") %></div>
                                                <div class="col-md-6 mg-t-10">Số Phòng : <%#Eval("order_amount") %></div>
                                                <div class="col-md-6 mg-t-10">Ngày : <%#Eval("order_checkin","{0:dd/MM/yyyy}") %> - <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Tên Khách : <%#Eval("order_nameGuest") %></div>
                                                <div class="col-md-6 mg-t-10">ID Khách : <%#Eval("order_IdGuest") %></div>
                                                <div class="col-md-6 mg-t-10">OTA / TA Booking ID (if any) : <%#Eval("order_OTATABookingID") %></div>
                                                <div class="col-md-6 mg-t-10">Quốc Tịch : <%#Eval("order_country") %></div>
                                                <div class="col-md-6 mg-t-10">Room Prepaid / Deposit Amount : <%#Eval("order_RoomPrepaid","{0:n0}") %>₫</div>
                                                <div class="col-md-6 mg-t-10">Ngày Book : <%#Eval("order_dateBook","{0:dd/MM/yyyy}") %></div>
                                                <div class="col-md-6 mg-t-10">Room Collect Amount :</div>
                                                <div class="col-md-6 mg-t-10">Kênh Book : <%#Eval("order_kenhBook") %></div>
                                                <div class="col-md-6 mg-t-10">Pay when checkin :<%#Eval("order_PaywhenCheckin","{0:0,0}") %> ₫</div>
                                                <div class="col-md-6 mg-t-10">Collect Account :<%#Eval("order_CollectAccount") %></div>
                                                <div class="col-md-6 mg-t-10">Number of Adult :<%#Eval("order_NumberofAdult") %></div>
                                                <div class="col-md-6 mg-t-10">Number of U7-12 Child :<%#Eval("order_NumberofU712Child") %></div>
                                                <div class="col-md-6 mg-t-10">Extra bed :<%#Eval("order_Extrabed") %></div>
                                                <div class="col-md-6 mg-t-10">Additional Room charge :<%#Eval("order_Additionalroomcharge","{0:0,0}") %> ₫</div>
                                                <div class="col-md-6 mg-t-10">Special Request (if any) :<%#Eval("order_SpecialRequest") %></div>
                                                <div class="col-md-6 mg-t-10">Other Collection for special request :<%#Eval("order_Collectionforspecialrequest","{0:0,0}") %></div>
                                            </div>
                                            <div class="ht-20"></div>
                                            <div class="row">
                                                <div class=" col-md-6">
                                                    <button id="btnDuyet" runat="server" onserverclick="btnDuyet_ServerClick" class="btn btn-primary btn-block">Duyệt</button>
                                                </div>
                                                <div class=" col-md-6">
                                                    <a href="javascript:void(0)" id="KoDuyet" onclick="GhiChu(<%#Eval("order_id") %>);" class="btn btn-primary btn-block">Không Duyệt</a>
                                                </div>
                                            </div>
                                            <div class="ht-20"></div>
                                            <textarea id="txtGhiChu<%#Eval("order_id") %>" rows="6" class="form-control" placeholder="Ghi chú"></textarea>
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
                                <th class="wd-5p">Mã giao dịch</th>
                                <th class="wd-5p">Giá phòng theo ngày</th>
                                <th class="wd-5p">Loại giá</th>
                                <th class="wd-5p">Tên CTKM</th>
                                <th class="wd-5p">Tòa nhà</th>
                                <th class="wd-5p">Số Phòng</th>
                                <th class="wd-5p">Ngày đến</th>
                                <th class="wd-5p">Ngày đi</th>
                                <th class="wd-5p">Tên khách</th>
                                <th class="wd-5p">Quốc tịch</th>
                                <th class="wd-5p">Kênh book</th>
                                <th class="wd-5p">Ngày book</th>
                                <th class="wd-5p">Tình Trạng</th>
                                <th class="wd-5p">Ghi chú</th>
                                <th class="wd-5p">Chi tiết</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpViewBook" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td><%#Eval("order_codeTrading") %></td>
                                        <td><%#Eval("order_priceRoom") %></td>
                                        <td><%#Eval("order_loaiGia") %></td>
                                        <td><%#Eval("order_nameCTKM") %></td>
                                        <td><%#Eval("building_name") %></td>
                                        <td><%#Eval("order_amount") %></td>
                                        <td><%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_nameGuest") %> </td>
                                        <td><%#Eval("order_country") %></td>
                                        <td><%#Eval("order_kenhBook") %></td>
                                        <td><%#Eval("order_dateBook","{0:dd/MM/yyyy}") %></td>
                                        <td><%#Eval("order_status") %></td>
                                        <td><%#Eval("order_Ghichu") %></td>
                                        <%--<td><a id="<%#Eval("book_id") %>" href="javascript:void(0);" class="btn btn-primary" onclick="checkIRoom(<%#Eval("book_id") %>);btnShow();">Duyệt</a></td>--%>
                                        <td><a class="btn btn-primary btn-block" href="javascript:void(0);" data-toggle="modal" data-target="#modaldemo<%#Eval("order_id") %>" onclick="getIRoom(<%#Eval("order_id") %>);">Xem</a></td>
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
    <div style="display:none">
        <%--<input id="btnDuyet" type="button" onserverclick="btnDuyet_ServerClick" runat="server" hidden />--%>
        <input id="txtId" runat="server" type="text" placeholder="id"  />
        <input id="txtCountId" runat="server" type="text" />
        <input id="txtIdCt" runat="server" type="text" placeholder="id chi tiết" />
        <input id="txtCountIdCt" runat="server" type="text"  />
        <input id="txtGhichu" runat="server" type="text" />
        <a href="" id="btnKhongDuyet" runat="server" onserverclick="btnKoDuyet_ServerClick"></a>
    </div>
    <script>
        <%--function btnShow() {
            document.getElementById('<%=btnDuyet.ClientID%>').click();
        }--%>
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
        //Nút chi tiết
        //Xóa id trên input
        function Clear() {
            document.getElementById("<%= txtIdCt.ClientID %>").value = "";
            document.getElementById("<%= txtCountIdCt.ClientID %>").value = "";
        }
        function getIRoom(id) {
            document.getElementById("<%= txtIdCt.ClientID %>").value = id;
        }
        function GhiChu(id) {
            document.getElementById("<%= txtGhichu.ClientID %>").value = document.getElementById("txtGhiChu" + id).value;
            document.getElementById("<%= btnKhongDuyet.ClientID %>").click();
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


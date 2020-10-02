<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_BookUpdateStatus.aspx.cs" Inherits="admin_page_module_function_admin_BookUpdateStatus" %>

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
                    <span>Booking</span>
                    <span>Cập Nhật Tình Trạng</span>
                </div>
                <h2 class="az-content-title">Quản Lý Lưu Trú</h2>

                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <!-- Dịch Vụ -->
                    <asp:Repeater ID="rpOrder" runat="server" OnItemDataBound="rpOrder_ItemDataBound">
                        <ItemTemplate>
                            <div id="modaldemo<%#Eval("order_id") %>" class="modal">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content modal-content-demo">
                                        <div class="modal-header">
                                            <h6 class="modal-title">Thông tin dịch vụ</h6>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="table-responsive">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th>Service</th>
                                                            <th>Note</th>
                                                            <th>Date</th>
                                                            <th>Amount</th>
                                                            <th>Service charge(%)</th>
                                                            <th>Total</th>
                                                            <th>Paid</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rpDichVu" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><%#Eval("dv_name") %></td>
                                                                    <td><%#Eval("dv_thongtin") %></td>
                                                                    <td><%#Eval("dv_ngay","{0:dd/MM/yyyy}") %></td>
                                                                    <td><%#Eval("dv_price","{0:0,00}") %> đ</td>
                                                                    <td><%#Eval("dv_Servicecharge") %></td>
                                                                    <td><%#Eval("dv_total","{0:0,00}") %> đ</td>
                                                                    <td>
                                                                        <label class="ckbox">
                                                                            <input disabled="disabled" type="checkbox" <%#Eval("checkedd") %>><span></span>
                                                                        </label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="mg-t-30">
                                                <div class="row">
                                                    <div class="col-md-4 col-sm-6">
                                                        <label class="form-control-label mg-t-10">Service:</label>
                                                        <select id="selectDichVu<%#Eval("order_id") %>" class="form-control">
                                                            <option value="Ăn uống">Ăn uống</option>
                                                            <option value="Thuê xe">Thuê Xe</option>
                                                            <option value="Du lịch">Du lịch</option>
                                                            <option value="Vé máy bay">Vé máy bay</option>
                                                            <option value="Giặt là">Giặt là</option>
                                                            <option value="Spa">Spa</option>
                                                            <option value="Minibar">Minibar</option>
                                                            <option value="Khác">Khác</option>
                                                        </select>
                                                        <label class="form-control-label mg-t-10">Date:</label>
                                                        <input id="txtNgay<%#Eval("order_id") %>" class="form-control" type="date" placeholder="DD/MM/YYYY" />
                                                    </div>
                                                    <div class="col-md-4 col-sm-6">

                                                        <label class="form-control-label mg-t-10">Amount:</label>
                                                        <input id="txtGia<%#Eval("order_id") %>" class="form-control number" type="text" required="" />
                                                        <label class="form-control-label mg-t-10">Service charge(%)</label>
                                                        <div class="input-group mb-3">
                                                            <input id="txtServicecharge<%#Eval("order_id") %>" type="text" class="form-control" placeholder="Service charge" aria-label="Service charge" aria-describedby="basic-addon2">
                                                            <div class="input-group-append">
                                                                <span class="input-group-text" id="basic-addon2">%</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 col-sm-6">

                                                        <label class="form-control-label mg-t-10">Note:</label>
                                                        <input id="txtThongtin<%#Eval("order_id") %>" type="text" class="form-control" placeholder="Note" required="" />

                                                        <label class="form-control-label mg-t-10"></label>
                                                        <label class="ckbox mg-t-25">
                                                            <input id="check<%#Eval("order_id") %>" type="checkbox"><span>Paid</span>
                                                        </label>
                                                    </div>
                                                </div>

                                                <div class="ht-30"></div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <a href="javascript:void(0)" id="Luu" onclick="myDichVu(<%#Eval("order_id") %>);" class="btn btn-primary btn-block">Lưu</a>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div>
                                                <input id="txtDichVu" type="text" />
                                                <input id="txtTTin"type="text" />
                                                <input id="txtPrice" type="text" />
                                                <input id="txtDate" type="text" />
                                            </div>--%>
                                            <!-- modal-dialog -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- End Dịch Vụ -->
                    <!-- Chi tiết-->
                    <asp:Repeater ID="rpChitiet" runat="server">
                        <ItemTemplate>
                            <div id="modalchitiet<%#Eval("order_id") %>" class="modal">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content modal-content-demo">
                                        <div class="modal-header">
                                            <h6 class="modal-title">Thông tin dịch vụ</h6>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-6 mg-t-10">Mã Giao Dịch : <%#Eval("order_codeTrading") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu phòng (từ ngày ... Đến ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Giá phòng / Ngày : <%#Eval("order_priceRoom","{0:0,00}") %> đ</div>
                                                <%--<div class="col-md-6 mg-t-10">Doang thu ăn uống (ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Loại giá : <%#Eval("order_loaiGia") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu thuê xe (ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Giá trị hiển thị : <%#Eval("order_priceShow","{0:0,00}") %> đ</div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu du lịch (ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Tên CTKM : <%#Eval("order_nameCTKM") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu vé máy bay(ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Tòa nhà : <%#Eval("building_name") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu giặt là (ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Số Phòng : <%#Eval("order_amount") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu Spa(ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Ngày : <%#Eval("order_checkin","{0:dd/MM/yyyy}") %> - <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu minibar(ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">Tên Khách : <%#Eval("order_nameGuest") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Doanh thu khác(ngày) :</div>--%>
                                                <div class="col-md-6 mg-t-10">ID Khách : <%#Eval("order_IdGuest") %></div>
                                                <div class="col-md-6 mg-t-10">OTA / TA Booking ID (if any) : <%#Eval("order_OTATABookingID") %></div>
                                                <div class="col-md-6 mg-t-10">Quốc Tịch : <%#Eval("order_country") %></div>
                                                <div class="col-md-6 mg-t-10">Room Prepaid / Deposit Amount : <%#Eval("order_RoomPrepaid","{0:0,00}") %> đ</div>
                                                <div class="col-md-6 mg-t-10">Ngày Book : <%#Eval("order_dateBook","{0:dd/MM/yyyy}") %></div>
                                                <%--<div class="col-md-6 mg-t-10">Room Collect Amount :</div>--%>
                                                <div class="col-md-6 mg-t-10">Kênh Book : <%#Eval("order_kenhBook") %></div>
                                                <div class="col-md-6 mg-t-10">Pay when checkin : <%#Eval("order_PaywhenCheckin","{0:0,00}") %> đ</div>
                                                <div class="col-md-6 mg-t-10">Collect Account : <%#Eval("order_CollectAccount") %></div>
                                                <div class="col-md-6 mg-t-10">Number of Adult : <%#Eval("order_NumberofAdult") %></div>
                                                <div class="col-md-6 mg-t-10">Number of U7-12 Child : <%#Eval("order_NumberofU712Child") %></div>
                                                <div class="col-md-6 mg-t-10">Extra bed : <%#Eval("order_Extrabed") %></div>
                                                <div class="col-md-6 mg-t-10">Additional Room charge : <%#Eval("order_Additionalroomcharge","{0:0,00}") %> đ</div>
                                                <div class="col-md-6 mg-t-10">Special Request (if any) : <%#Eval("order_SpecialRequest") %></div>
                                                <div class="col-md-6 mg-t-10">Other Collection for special request : <%#Eval("order_Collectionforspecialrequest","{0:0,00}") %></div>

                                            </div>

                                            <div class="row mg-t-30" style="<%#Eval("hiddenn") %>">
                                                <div class=" col-md-4">
                                                    <button id="btnCheckIn" runat="server" class="btn btn-primary btn-block" onserverclick="btnCheckIn_ServerClick">Check In</button>
                                                </div>
                                                <div class=" col-md-4">
                                                    <button id="btnNoShow" runat="server" class="btn btn-primary btn-block" onserverclick="btnNoShow_ServerClick">No Show(Đã thu tiền)</button>
                                                </div>
                                                <div class=" col-md-4">
                                                    <button id="btnHuy" onclick="GhiChu(<%#Eval("order_id") %>);" class="btn btn-primary btn-block">Hủy</button>
                                                </div>
                                                <div class="ht-20"></div>
                                                <div class=" col-md-12 mg-t-20">
                                                    <textarea id="txtGhiChu<%#Eval("order_id") %>" rows="6" class="form-control" placeholder="Ghi chú nếu hủy"></textarea>
                                                </div>
                                            </div>
                                            <div class="mg-t-30" style="<%#Eval("hidden") %>">
                                                <div class="mb-3">
                                                    Phương Thức Thanh Toán :
                                                        <div class="row">
                                                            <div class="col-md-4 pd-lg-0 mt-1">
                                                                <input class="ml-3" type="checkbox" onclick="Checked1(<%#Eval("order_id") %>);" name="my-input" id="cash<%#Eval("order_id") %>">
                                                                <label for="yes">Cash</label>
                                                            </div>
                                                            <div class="col-md-8 mb-2">
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <div class="input-group-text" style="width: 88px">
                                                                            Số tiền:
                                                                        </div>
                                                                    </div>
                                                                    <input type="text" id="txtSoTien<%#Eval("order_id") %>" disabled="disabled" class="form-control number" name="name" value="0" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 pd-lg-0 mt-1">
                                                                <input class="ml-3" type="checkbox" onclick="Checked2(<%#Eval("order_id")%>);" name="my-input" id="card<%#Eval("order_id") %>">
                                                                <label for="yes">Cà Thẻ</label>
                                                            </div>
                                                            <div class="col-md-8 ">
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <div class="input-group-text" style="width: 88px">
                                                                            Phí cà thẻ:
                                                                        </div>
                                                                    </div>
                                                                    <input type="text" id="txtPhiCaThe<%#Eval("order_id") %>" disabled="disabled" class="form-control" name="name" value="0" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                </div>
                                                <style>
                                                    input[type=checkbox] {
                                                        width: 20px;
                                                        height: 20px;
                                                        vertical-align: middle;
                                                        position: relative;
                                                        bottom: 1px;
                                                    }
                                                </style>
                                                <div class="row">
                                                    <%--<div class="col-md-6">
                                                        <a href="javascript:void(0)" id="Luu" runat="server" onclick="myDichVu()" onserverclick="Luu_ServerClick" class="btn btn-primary btn-block">Lưu</a>
                                                    </div>--%>
                                                    <div class=" col-md-6">
                                                        <button id="btnCheckOut" onclick="phuongThucThanhToan(<%#Eval("order_id") %>)" class="btn btn-primary btn-block">Check Out</button>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- modal-dialog -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- End Chi tiết-->
                    <!-- modal -->
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>Mã giao dịch</th>
                                    <th>Giá phòng theo ngày</th>
                                    <th>Loại giá</th>
                                    <th>Tên CTKM</th>
                                    <th>Tòa nhà</th>
                                    <th>Số Phòng</th>
                                    <th>Checkin - Checkout</th>
                                    <th>Tên khách</th>
                                    <th>Quốc tịch</th>
                                    <th>Kênh book</th>
                                    <th>Ngày book</th>
                                    <th>Tình Trạng</th>
                                    <th>Chi tiết</th>
                                    <th>Dịch Vụ</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpShow" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("order_codeTrading") %></td>
                                            <td><%#Eval("order_priceRoom","{0:0,00}") %></td>
                                            <td><%#Eval("order_loaiGia") %></td>
                                            <td><%#Eval("order_nameCTKM") %></td>
                                            <td><%#Eval("building_name") %></td>
                                            <td><%#Eval("order_amount") %></td>
                                            <td><%#Eval("order_checkin","{0:dd/MM/yyyy}") %> <i class="fa fa-arrow-right"></i><%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                            <td><%#Eval("order_nameGuest") %> </td>
                                            <td><%#Eval("order_country") %></td>
                                            <td><%#Eval("order_kenhBook") %></td>
                                            <td><%#Eval("order_dateBook","{0:dd/MM/yyyy}") %></td>
                                            <td><%#Eval("order_status") %></td>
                                            <td><a class="btn btn-primary btn-block" href="javascript:void(0);" data-toggle="modal" data-target="#modalchitiet<%#Eval("order_id") %>" onclick="checkIRoom(<%#Eval("order_id") %>)">Xem</a></td>
                                            <td><a class="btn btn-primary btn-block" href="javascript:void(0);" data-toggle="modal" data-target="#modaldemo<%#Eval("order_id") %>" onclick="getIdDichVu(<%#Eval("order_id") %>)" style="<%#Eval("hidden") %>">D.Vụ</a></td>
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
    <asp:UpdatePanel ID="upDichVu" runat="server">
        <ContentTemplate>
            <%-- <a id="btnDichVu" runat="server" onserverclick="btnDichVu_ServerClick"></a>--%>
            <input id="txtIdCt" runat="server" type="text" placeholder="id dịch vụ" hidden="hidden" />

        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none">
        <input id="txtDichVu" runat="server" type="text" />
        <input id="txtTTin" runat="server" type="text" />
        <input id="txtPrice" runat="server" type="text" />
        <input id="txtDate" runat="server" type="text" />
        <input id="txtServicecharge" runat="server" type="text" />
        <input id="check" runat="server" type="checkbox" />
        <input id="txtGhiChu" runat="server" type="text" />
        <a href="#" id="btnHuy" runat="server" onserverclick="btnHuy_ServerClick"></a>
        <a href="#" id="btnLuu" runat="server" onserverclick="Luu_ServerClick"></a>
        <a href="#" id="btnOut" runat="server" onserverclick="btnCheckOut_ServerClick"></a>
        <input id="checkCash" runat="server" type="checkbox" />
        <input id="checkCard" runat="server" type="checkbox" />
        <input id="SoTien" runat="server" type="text" />
        <input id="PhiCaThe" runat="server" type="text" />
    </div>
    <input id="txtId" runat="server" type="text" placeholder="id" hidden="hidden" />
    <input id="txtCountId" runat="server" type="text" hidden="hidden" />
    <input id="txtCountIdCt" runat="server" type="text" hidden="hidden" />

    <script>

        function checkIRoom(id) {
            document.getElementById("<%= txtId.ClientID %>").value = id;
        }
        function SetNull() {
           <%-- document.getElementById("<%= txtThongtin.ClientID %>").value = " ";
            document.getElementById("<%= txtGia.ClientID %>").value = " ";
            document.getElementById("<%= txtNgay.ClientID %>").value = " ";--%>
        }
        function getIdDichVu(id) {
            document.getElementById("<%= txtIdCt.ClientID %>").value = id;
            <%--document.getElementById("<%= btnDichVu.ClientID %>").click(); --%>
        }
        function myDichVu(id) {
            document.getElementById("<%= txtDichVu.ClientID %>").value = document.getElementById("selectDichVu" + id).value;
            document.getElementById("<%= txtTTin.ClientID %>").value = document.getElementById("txtThongtin" + id).value;
            document.getElementById("<%= txtPrice.ClientID %>").value = document.getElementById("txtGia" + id).value;
            document.getElementById("<%= txtDate.ClientID %>").value = document.getElementById("txtNgay" + id).value;
            document.getElementById("<%= txtServicecharge.ClientID %>").value = document.getElementById("txtServicecharge" + id).value;
            document.getElementById("<%= check.ClientID %>").checked = document.getElementById("check" + id).checked;
            document.getElementById("<%= btnLuu.ClientID %>").click();
        }
        function phuongThucThanhToan(id) {
            document.getElementById("<%= SoTien.ClientID%>").value = document.getElementById("txtSoTien" + id).value;
            document.getElementById("<%= PhiCaThe.ClientID%>").value = document.getElementById("txtPhiCaThe" + id).value;
            document.getElementById("<%= btnOut.ClientID%>").click();
        }
        function GhiChu(id) {
            document.getElementById("<%= txtGhiChu.ClientID %>").value = document.getElementById("txtGhiChu" + id).value;
            document.getElementById("<%= btnHuy.ClientID %>").click();
        }
        function Checked1(id) {
            document.getElementById("cash" + id).onchange = function () {
                document.getElementById("txtSoTien" + id).disabled = !this.checked;
            };
            document.getElementById("<%= checkCash.ClientID %>").checked = document.getElementById("cash" + id).checked;
        } function Checked2(id) {
            document.getElementById("card" + id).onchange = function () {
                document.getElementById("txtPhiCaThe" + id).disabled = !this.checked;
            };
            document.getElementById("<%= checkCard.ClientID %>").checked = document.getElementById("card" + id).checked;
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


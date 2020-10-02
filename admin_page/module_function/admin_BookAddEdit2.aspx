<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_BookAddEdit2.aspx.cs" Inherits="admin_page_module_function_admin_BookAddEdit2" %>

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
                    <span>Danh Sách Booking</span>
                    <span>Edit Booking</span>
                </div>
                <h2 class="az-content-title">Edit Booking</h2>

                <div class="ht-40"></div>
                <div class="card card-table-one">
                    <div class="row">
                        <div class="col-md-3 wd-200 mg-b-20">
                            <label for="">Lưu trú từ ngày:</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        Date:
                                    </div>
                                </div>
                                <input id="dateStar" runat="server" type="text" class="form-control" disabled="disabled" placeholder="DD/MM/YYYY" />
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
                                <input id="dateEnd" runat="server" type="text" class="form-control" disabled="disabled" placeholder="DD/MM/YYYY" />
                            </div>
                        </div>
                        <div class="col-md-3 wd-200 mg-b-20 ">
                            <label>Chọn buiding:</label>
                            <asp:DropDownList ID="ddBuilding" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" Enabled="false" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-3 wd-200 mg-b-20 ">
                            <label>Chọn loại phòng:</label>
                            <asp:DropDownList ID="ddListing" CssClass="form-control" DataValueField="listing_id" DataTextField="listing_name" Enabled="false" runat="server"></asp:DropDownList>
                        </div>
                        <%--<div class="col-md-1 mg-t-7 pd-l-0 pd-r-30">
                            <label></label>
                            <button id="btnLoc" runat="server" onserverclick="btnLoc_ServerClick" class="btn btn-primary btn-block ">Lọc</button></div>--%>
                    </div>

                    <div class="ht-20"></div>
                    <div class="table-responsive ">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th class="wd-20 ">Check</th>
                                    <th>Số Phòng</th>
                                    <th>Loại Phòng</th>
                                    <th>Giá niêm yết</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpRoom" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <label class="ckbox">
                                                    <input type="checkbox" onclick="checkIRoom(<%#Eval("room_id")%>); /*UpdatePrice()*/"><span></span></label>
                                            </td>
                                            <td><%#Eval("room_name") %></td>
                                            <td><%#Eval("listing_name") %></td>
                                            <td><%#Eval("listing_price","{0:0,0}") %> đ</td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="ht-20"></div>
                    <!--Nhập giá v.v -->
                    <div class="row">
                        <div class="col-md-8 wd-200 mg-b-20">
                            <div class="row">

                                <div class="col-md-6 wd-200 mg-b-20">

                                    <label for="">Khuyến mãi từ ngày:</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                Date:
                                            </div>
                                        </div>
                                        <input id="txtDateStar" <%=Disabled %> type="text" class="form-control fc-datepicker" autocomplete="off" placeholder="DD/MM/YYYY" />
                                    </div>
                                </div>
                                <div class=" col-md-6 wd-200 mg-b-20 ">
                                    <label for="">Đến ngày:</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                Date:
                                            </div>
                                        </div>
                                        <input id="txtDateEnd" <%=Disabled %> type="text" class="form-control fc-datepicker" autocomplete="off" placeholder="DD/MM/YYYY" />
                                    </div>
                                </div>
                                <div class="col-md-6 wd-200 mg-b-20 ">
                                    <label>Giá niêm yết:</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                VNĐ:
                                            </div>
                                        </div>
                                        <input id="txtGiaShow" <%=Disabled %> value="<%=giaNiemyet %>₫" type="text" onkeypress="return isNumber(event)" class="form-control number" />
                                    </div>
                                </div>
                                <div class="col-md-6 wd-200 mg-b-20 ">
                                    <label>Giá thực/ngày(giá khuyến mãi):</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                VNĐ:
                                            </div>
                                        </div>
                                        <input id="txtGiaRoom" onkeypress="return isNumber(event)" <%=Disabled %> type="text" class="form-control number" />
                                    </div>
                                </div>

                                <div class="col-md-6 wd-200 mg-b-20">
                                    <a href="javascript:void(0)" id="btnXN" runat="server" onclick="getNgay();" class="btn btn-primary">Xác Nhận</a>
                                </div>

                                <div class=" col-md-9  wd-200 mg-b-20 ">
                                    <label for="">Tên chương trình khuyến mãi :</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                Tên:
                                            </div>
                                        </div>
                                        <input id="txtTCTKM" runat="server" type="text" class="form-control" />
                                    </div>
                                </div>

                                <div class="col-md-3 mg-t-7 pd-l-0 pd-r-30">
                                    <label></label>
                                    <a href="#" id="btnBook" runat="server" onserverclick="btnBook_ServerClick" class="btn btn-primary btn-block">Book</a>
                                </div>
                                <div class="col-md-3 wd-200 mg-b-20">
                                    <label></label>
                                    <a href="#" id="btnCheckInNow" runat="server" onserverclick="btnCheckInNow_ServerClick" class="btn btn-primary">CheckIn Ngay</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 wd-200 mg-b-20">
                            <label>Chi tiết Giá phòng/ 1 ngày:</label>
                            <asp:UpdatePanel ID="UpdateShowPrice" runat="server">
                                <ContentTemplate>
                                    <div class="table-responsive ">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr>

                                                    <th>Ngày</th>
                                                    <th>Giá</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpViewPrice" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("oddp_date") %></td>
                                                            <td><%#Eval("oddp_price","{0:0,00}") %> đ</td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
                <div class="ht-40"></div>
            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
    <input id="txtNgayDen" runat="server" type="text" hidden="hidden" />
    <input id="txtNgayDi" runat="server" type="text" hidden="hidden" />
    <input id="txtGiahienthi" runat="server" type="text" hidden="hidden" />
    <input id="txtGiaphong" runat="server" type="text" hidden="hidden" />
    <input id="txtId" runat="server" type="text" placeholder="id" hidden="hidden" />
    <input id="txtCountId" runat="server" type="text" hidden="hidden" />
    <asp:UpdatePanel ID="UpdatePrice" runat="server">
        <ContentTemplate>
            <a href="#" id="btnUpdate" runat="server" onserverclick="btnUpdate_ServerClick" hidden="hidden"></a>
            <a href="#" id="btnXacNhan" runat="server" onserverclick="btnXacNhan_ServerClick" hidden="hidden"></a>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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
        function getNgay() {
            document.getElementById("<%=txtNgayDen.ClientID%>").value = document.getElementById("txtDateStar").value
            document.getElementById("<%=txtNgayDi.ClientID%>").value = document.getElementById("txtDateEnd").value
            document.getElementById("<%=txtGiahienthi.ClientID%>").value = document.getElementById("txtGiaShow").value
            document.getElementById("<%=txtGiaphong.ClientID%>").value = document.getElementById("txtGiaRoom").value
            document.getElementById("<%=btnXacNhan.ClientID%>").click();
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        function UpdatePrice() {
            document.getElementById("<%= btnUpdate.ClientID%>").click();
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
    <script type="text/javascript"> 
        $(window).on('load', function () {
            document.getElementById("<%=txtGiahienthi.ClientID%>").value = document.getElementById("txtGiaShow").value
        });

    </script>
</asp:Content>


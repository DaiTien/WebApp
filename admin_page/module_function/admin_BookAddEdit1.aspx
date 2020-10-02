<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_BookAddEdit1.aspx.cs" Inherits="admin_page_module_function_admin_BookAddEdit1" %>

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
                    <span>Nhập thông tin booking</span>
                </div>
                <h2 class="az-content-title">Nhập thông tin booking</h2>


                <div class="card card-table-one">
                    <div class="row">
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Mã giao dịch:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtCodeTrading" runat="server" disabled="disabled" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Loại giá:</label>
                            </div>
                            <div class="col-md-8">
                                <select id="txtLoaigia" runat="server" class=" form-control">
                                    <option value="Giá ngày">Giá ngày</option>
                                    <option value="Giá tuần">Giá tuần</option>
                                    <option value="Giá nữa tháng">Giá nữa tháng</option>
                                    <option value="Giá tháng">Giá tháng</option>
                                </select>
                                <%--<input id="txtLoaigia" runat="server" class="form-control" placeholder="" type="text"/>--%>
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày đến:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="dateStar" runat="server" type="text" class="form-control fc-datepicker" autocomplete="off" placeholder="DD/MM/YYYY" />

                            </div>

                        </div>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Giá niêm yết:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtGiahienthi" runat="server" class="form-control" placeholder="" type="text"/>
                            </div>
                        </div>--%>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tên khách:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtTenKhach" runat="server" class="form-control" autocomplete="off" placeholder="" type="text" />
                            </div>



                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày đi:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="dateEnd" runat="server" type="text" class="form-control fc-datepicker" autocomplete="off" placeholder="DD/MM/YYYY" />
                            </div>


                        </div>

                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Giá thực / Ngày:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtGiaphong" runat="server" class="form-control" placeholder="" type="text"/>
                            </div>
                        </div>--%>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Số hộ chiếu:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtSohochieu" runat="server" class="form-control" autocomplete="off" placeholder="" type="text" />

                            </div>

                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày book:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtNgayBook" runat="server" type="text" class="form-control fc-datepicker" autocomplete="off" placeholder="DD/MM/YYYY" />
                            </div>

                        </div>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tên chương trình khuyến mãi:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtTCTKM" runat="server" class="form-control" placeholder="" type="text"/>
                            </div>
                        </div>--%>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>ID khách:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtIDkhach" runat="server" class="form-control" autocomplete="off" disabled="disabled" placeholder="" type="text" />
                                <a href="javascript:void(0);" class="btn btn-primary" id="btnDuyetIdGuest" runat="server" onserverclick="btnDuyetIdGuest_ServerClick" style="position: absolute; top: 0; right: 16px;">Duyệt ID</a>
                            </div>

                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tòa nhà:</label>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddBuilding" OnSelectedIndexChanged="ddBuilding_SelectedIndexChanged" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Kênh book:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtKenhbook" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>OTA / TA Booking ID (if any):</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtOTATABookingID" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Room Prepaid / Deposit Amount:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtRoomPrepaid" runat="server" value="0" class="form-control number" autocomplete="off" onkeypress="return isNumber(event)" placeholder="" type="text" />
                            </div>
                        </div>

                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Loại phòng:</label>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddListing" CssClass="form-control" DataValueField="listing_id" DataTextField="listing_name" runat="server"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Quốc tịch:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtQuoctich" runat="server" class="form-control" autocomplete="off" placeholder="" type="text" />
                            </div>
                        </div>



                    </div>
                    <div class="col-md-2 mg-t-10 pd-l-0 ">
                        <label></label>
                        <button id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick" class="btn btn-primary btn-block ">Lưu</button>
                    </div>
                    <div class="ht-40"></div>


                </div>
                <div class="ht-40"></div>

            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
    <!-- az-content -->
    <script>
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
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


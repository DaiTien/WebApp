<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_GuestEdit.aspx.cs" Inherits="admin_page_module_function_admin_GuestEdit" %>

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
                    <span>Danh Sách Guest</span>
                    <span>Edit Guest</span>
                    <span>Nhập thông tin Guest</span>
                </div>
                <h2 class="az-content-title">Nhập thông tin guest</h2>


                <div class="card card-table-one">
                    <div class="row">
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tên Khách:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtnameGuest" disabled="disabled" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Số Hộ Chiếu:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtSoHoChieu" disabled="disabled" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>ID Khách:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtIdGuest" disabled="disabled" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Quốc Tịch:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtCountry" runat="server" disabled="disabled" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Khu vực địa lý:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtKVDL" runat="server" disabled="disabled" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>

                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày Sinh:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdateSinh" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>

                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Email:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtEmail" runat="server" type="text" class="form-control" placeholder="" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Số Mobile:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtPhone" runat="server" type="text" onkeypress="return isNumber(event)" class="form-control" placeholder="" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Phương tiện liên lạc khác:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtptllk" runat="server" type="text" class="form-control" placeholder="" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Nghề nghiệp:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtNgheNghiep" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày Đến:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdateDen" disabled="disabled" runat="server" class="form-control" placeholder="DD/MM/YYYY" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày Đi:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdateDi" disabled="disabled" runat="server" class="form-control" placeholder="DD/MM/YYYY" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tòa Nhà:</label>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddBuilding" disabled="disabled" CssClass="form-control" DataValueField="building_id" DataTextField="building_name" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Số Phòng:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtSoPhong" runat="server" disabled="disabled" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Kênh book:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtKenhbook" runat="server" disabled="disabled" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Địa điểm ở trước khi tới:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtddotkt" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Địa điểm đến sau khi đi:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdddskd" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Dự kiến thời gian quay lại:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdktgql" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Địa điểm nếu quay lại:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtddnql" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Dự kiến thời gian ở nếu quay lại:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdktgonql" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tính cách:</label>
                            </div>
                            <div class="col-md-8">
                                <select id="slTinhcach" runat="server" class="form-control">
                                    <option label="Chọn Tính Cách"></option>
                                    <option value="Lịch Sự & Dễ Mến">Lịch Sự & Dễ Mến</option>
                                    <option value="Khó Tính & Hay Phàn Nàn">Khó Tính & Hay Phàn Nàn</option>
                                    <option value="Bình Dị & Ít Nói">Bình Dị & Ít Nói</option>
                                    <option value="Phóng Khoáng & Sôi Nổi">Phóng Khoáng & Sôi Nổi</option>
                                    <option value="Nóng Tính">Nóng Tính</option>
                                    <option value="Kỹ Tính & Trầm Lặng">Kỹ Tính & Trầm Lặng</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>lý do đi du lịch, công tác:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtlydo" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Góp ý của khách:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtgopykhachhang" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Điểm tích lũy:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdtl" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>--%>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Tiêu tiền tích lũy:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txttttl" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>--%>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Ngày tiêu tiền tích lũy:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtntttl" runat="server" class="form-control" placeholder="DD/MM/yyyy" type="text" />
                            </div>
                        </div>--%>
                        <%--<div class="col-md-6 mg-t-30 d-flex">
                            <div class="col-md-4 pd-lg-0">
                                <label>Dịch vụ tiêu tiền tích lũy:</label>
                            </div>
                            <div class="col-md-8">
                                <input id="txtdvtttl" runat="server" class="form-control" placeholder="" type="text" />
                            </div>
                        </div>--%>
                    </div>
                    <div class="col-md-2 mg-t-10 pd-l-0 ">
                        <label></label>
                        <a href="#" id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick" class="btn btn-primary btn-block ">Lưu</a>
                    </div>
                    <div class="ht-40"></div>
                </div>
                <div class="ht-40"></div>
            </div>
            <!-- az-content-body -->
            s
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


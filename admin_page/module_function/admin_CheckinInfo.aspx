<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_CheckinInfo.aspx.cs" Inherits="admin_page_module_function_admin_CheckinInfo" %>

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
                    <span>Staff</span>
                    <span>Cập nhật tình trạng</span>
                    <span>Nhập thông tin Check-in</span>
                </div>
                <h2 class="az-content-title">Nhập thông tin Check-in</h2>


                <div class="card card-table-one">
                    <div class="row">
                        <div class="col-md-4 col-sm-6">
                            <label class="form-control-label mg-t-15">Number of Adult:</label>
                            <input id="txtNumberofAdult" runat="server" class="form-control" name="firstname" placeholder="Number of Adult" type="text" onkeypress="return isNumber(event)" autocomplete="off" required="" />
                            <label class="form-control-label mg-t-15">Number of U7-12 Child:</label>
                            <input id="txtNumberofU712Child" runat="server" class="form-control" name="firstname" placeholder="Number of U7-12 Child" type="text" onkeypress="return isNumber(event)" autocomplete="off" required="" />


                        </div>
                        <div class="col-md-4 col-sm-6">
                            <label class="form-control-label mg-t-15">Extra bed:</label>
                            <input id="txtExtrabed" runat="server" class="form-control" name="firstname" placeholder="Extra bed" type="text" autocomplete="off" required="" />
                            <label class="form-control-label mg-t-15">Additional room charge:</label>
                            <input id="txtAdditionalroomcharge" runat="server" class="form-control number" name="firstname" onkeypress="return isNumber(event)" placeholder="Additional room charge" type="text" autocomplete="off" required="" />

                        </div>
                        <div class="col-md-4 col-sm-6">
                            <label class="form-control-label mg-t-15">Pay when Check-in:</label>
                            <input id="txtPaywhenCheckin" runat="server" class="form-control number" name="firstname" placeholder="Pay when Check-in" onkeypress="return isNumber(event)" type="text" autocomplete="off" required="" />

                            <label class="form-control-label mg-t-15">Collect Account:</label>
                            <select id="slCollectAccount" runat="server" class=" form-control">
                                <option value="Travel Agency">Travel Agency</option>
                                <option value="Guest">Guest</option>
                            </select>
                        </div>
                        <div class="col-md-8 col-sm-6">
                            <label class="form-control-label mg-t-15">Special Request (if any):</label>
                            <input id="txtSpecialRequest" runat="server" class="form-control" name="firstname" placeholder="Special Request (if any)" type="text" autocomplete="off" required="" />

                        </div>
                        <div class="col-md-4 col-sm-6">
                            <label class="form-control-label mg-t-15">Collection for special request:</label>
                            <input id="txtCollectionforspecialrequest" runat="server" class="form-control number" name="firstname" placeholder="Collection for special request" type="text" autocomplete="off" required="" />

                        </div>

                    </div>
                    <div class="col-md-2 mg-t-30 pd-l-0 ">
                        <a href="javascript:void(0);" id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick" class="btn btn-primary btn-block ">Lưu</a>
                    </div>
                    <div class="ht-40"></div>
                </div>
                <div class="ht-40"></div>

            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
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


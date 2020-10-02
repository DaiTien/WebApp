<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ChangePassword.aspx.cs" Inherits="admin_page_module_access_admin_ChangePassword" %>

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
    <div class="az-content-body az-content-body-profile">
        <div class="az-profile-body">
            
                <div class="az-content-label mg-b-30 text-center">Change Password</div>
                <div class="pd-30 pd-sm-40 bg-gray-200 wd-xl-50p m-auto" >
                    <div class="row row-xs align-items-center mg-b-20">
                        <div class="col-md-4">
                            <label class="form-label mg-b-0">Enter the old password</label>
                        </div>
                        <!-- col -->
                        <div class="col-md-8 mg-t-5 mg-md-t-0">
                            <input type="password" class="form-control" id="txtMKcu" runat="server" placeholder="Enter the old password"/>
                        </div>
                        <!-- col -->
                    </div>
                    <!-- row -->

                    <div class="row row-xs align-items-center mg-b-20">
                        <div class="col-md-4">
                            <label class="form-label mg-b-0">Enter your new password</label>
                        </div>
                        <!-- col -->
                        <div class="col-md-8 mg-t-5 mg-md-t-0">
                            <input type="password" class="form-control" id="txtMKmoi" runat="server" placeholder="Enter your new password"/>
                        </div>
                        <!-- col -->
                    </div>
                    <!-- row -->

                    <div class="row row-xs align-items-center mg-b-20">
                        <div class="col-md-4">
                            <label class="form-label mg-b-0">Enter a new password</label>
                        </div>
                        <!-- col -->
                        <div class="col-md-8 mg-t-5 mg-md-t-0">
                            <input type="password" class="form-control" id="txtXacnhanMk" runat="server" placeholder="Enter a new password"/>
                        </div>
                        <!-- col -->
                    </div>
                    <!-- row -->

                    <button class="btn btn-az-primary pd-x-30 mg-r-5" type="button" id="btn_ChangerPass" runat="server" onserverclick="btn_ChangerPass_ServerClick">Change Password</button>
                    <a href="/admin-home" class="btn btn-dark pd-x-30">Cancel</a>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


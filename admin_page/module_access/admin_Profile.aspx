<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_Profile.aspx.cs" Inherits="admin_page_module_access_admin_Profile" %>

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

    <div class="az-content az-content-profile">
        <div class="container mn-ht-100p">
            <div class="az-content-left az-content-left-profile">

                <div class="az-profile-overview">
                    <div class="az-img-user">
                        <img src="/admin_images/avatar.jpg" alt="">
                    </div>
                    <!-- az-img-user -->
                    <div class="d-flex justify-content-between mg-b-20">
                        <div>
                            <h5 class="az-profile-name">Root</h5>
                            <p class="az-profile-name-text"><%=chucvu %></p>
                        </div>
                    </div>
                    <hr class="mg-y-30">
                </div>
                <!-- az-profile-overview -->

            </div>
            <!-- az-content-left -->
            <div class="az-content-body az-content-body-profile">
                <div class="az-profile-body">
                    <div class="row">
                        <div class="col-md-5 col-xl-4 mg-t-40 mg-md-t-0">
                            <div class="az-content-label tx-13 mg-b-25">Contact Information</div>
                            <asp:Repeater runat="server" ID="rp_Profile">
                                <ItemTemplate>
                                    <div class="az-profile-contact-list">
                                        <div class="media">
                                            <div class="media-icon"><i class="icon ion-ios-person"></i></div>
                                            <div class="media-body">
                                                <span>Profile</span>
                                                <div>
                                                    <input type="text" id="txtusername_fullname" class="form-control" name="name" value="<%#Eval("username_fullname") %>" />
                                                </div>
                                            </div>
                                            <!-- media-body -->
                                        </div>
                                        <!-- media -->
                                        <div class="media">
                                            <div class="media-icon"><i class="icon ion-md-mail"></i></div>
                                            <div class="media-body">
                                                <span>Email</span>
                                                <div>
                                                    <input type="text" id="username_email" class="form-control" name="name" value="<%#Eval("username_email") %>" />
                                                </div>
                                            </div>
                                            <!-- media-body -->
                                        </div>
                                        <!-- media -->
                                        <div class="media">
                                            <div class="media-icon"><i class="icon ion-md-phone-portrait"></i></div>
                                            <div class="media-body">
                                                <span>Mobile</span>
                                                <div>
                                                    <input type="text" id="username_phone" class="form-control" name="name" value="<%#Eval("username_phone") %>" />
                                                </div>
                                            </div>
                                            <!-- media-body -->
                                        </div>

                                        <!-- media -->

                                        <%--<div class="media">
                                            <div class="media-icon"><i class="icon ion-md-locate"></i></div>
                                            <div class="media-body">
                                                <span>Address</span>
                                                <div>Đà Nẵng, Việt Nam</div>
                                            </div>
                                            <!-- media-body -->
                                        </div>--%>
                                        <!-- media -->
                                    </div>
                                    <!-- az-profile-contact-list -->
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="media pt-3 ">
                                <button type="button" class="btn btn-primary" onclick=" getacount();" runat="server" id="btnChanger" onserverclick="btnChanger_ServerClick" >Thay đổi thông tin</button>
                                <!-- media-body -->
                            </div>
                        </div>
                        <!-- col -->
                    </div>
                    <!-- row -->
                    <div class="mg-b-20"></div>
                </div>
                <!-- az-profile-body -->
            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
    <!-- az-content -->
    <div style="display:none">
        <input type="text" name="name" runat="server" value="" id="txt_Profile" />
        <input type="text" name="name" runat="server" value="" id="txt_Email" />
        <input type="text" name="name" runat="server" value="" id="txt_Mobile" />
    </div>
    <script>
        function getacount() {
            document.getElementById("<%=txt_Profile.ClientID%>").value = document.getElementById("txtusername_fullname").value
            document.getElementById("<%=txt_Email.ClientID%>").value = document.getElementById("username_email").value
            document.getElementById("<%=txt_Mobile.ClientID%>").value = document.getElementById("username_phone").value
        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


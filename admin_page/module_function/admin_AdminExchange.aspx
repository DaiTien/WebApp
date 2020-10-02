<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_AdminExchange.aspx.cs" Inherits="admin_page_module_function_admin_AdminExchange" %>

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
                    <span>Quy đổi điểm</span>
                </div>
                <h2 class="az-content-title">Quy đổi điểm</h2>

                <div class="card card-table-one">
                    <asp:Repeater ID="rpMucDoiDiem" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-6 mg-t-30 d-flex">
                                    <div class="col-md-4 pd-lg-0">
                                        <label>Tiền phòng:</label>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <input id="txtRoomprice" type="text" class="form-control number" onkeypress="return isNumber(event)" placeholder="<%#Eval("mdd_Roomprice") %>" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                            <div class="input-group-append">
                                                <span class="input-group-text" id="basic-addon2">= 1 điểm tích lũy</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 mg-t-30 d-flex">
                                    <div class="col-md-4 pd-lg-0">
                                        <label>Tiền ăn uống:</label>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <input id="txtEatprice" type="text" onkeypress="return isNumber(event)" class="form-control number" placeholder="<%#Eval("mdd_Eatprice") %>" aria-label="Recipient's username" aria-describedby="basic-addon1" />
                                            <div class="input-group-append">
                                                <span class="input-group-text" id="basic-addon1">= 1 điểm tích lũy</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 mg-t-30 d-flex">
                                    <div class="col-md-4 pd-lg-0">
                                        <label>Điểm quy đổi ra tiền Triple:</label>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <input id="txtTriplemoney" type="text" onkeypress="return isNumber(event)" class="form-control" placeholder="<%#Eval("mdd_Triplemoney") %>" aria-label="Recipient's username" aria-describedby="basic-addon3" />
                                            <div class="input-group-append">
                                                <span class="input-group-text" id="basic-addon3">= 1 TRIPLE money</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="col-md-2 mg-t-10 pd-l-0 ">
                        <label></label>
                        <a href="#" id="btnLuu" runat="server" onclick="getValue();" onserverclick="btnLuu_ServerClick" class="btn btn-primary btn-block ">Lưu</a>
                    </div>
                    <div class="ht-40"></div>
                </div>
                <div class="ht-40"></div>

            </div>
            <!-- az-content-body -->
        </div>
        <div style="display: none">
            <input id="txtPriceRoom" runat="server" type="text" />
            <input id="txtPriceEat" runat="server" type="text" />
            <input id="txtTripleMoney2" runat="server" type="text" />
        </div>
        <!-- container -->
        <script>
            function getValue() {
                document.getElementById("<%=txtPriceRoom.ClientID%>").value = document.getElementById("txtRoomprice").value;
                document.getElementById("<%=txtPriceEat.ClientID%>").value = document.getElementById("txtEatprice").value;
                document.getElementById("<%=txtTripleMoney2.ClientID%>").value = document.getElementById("txtTriplemoney").value;
            }
        </script>
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
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


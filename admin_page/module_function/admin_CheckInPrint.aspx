<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_CheckInPrint.aspx.cs" Inherits="admin_page_module_function_admin_CheckInPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check in - TRIPLE Serviced Apartment & Hotel</title>
    <link href="/admin_css/css_triple/azia.css" rel="stylesheet" />
    <link href="/admin_css/css_triple/paper.css" rel="stylesheet" />
    <link href="../../admin_css/sweetalert.css" rel="stylesheet" />
    <script src="../../admin_js/sweetalert.js"></script>
    <style>
        @page {
            size: A4;
        }
    </style>
</head>
<body class="A4">
    <form method="post" runat="server">
        <asp:ScriptManager runat="server" ID="src"></asp:ScriptManager>
        <section class="sheet padding-10mm">

            <!-- Write HTML just like a web page -->
            <article>
                <div class="header">
                    <div class="container-fluid">
                        <div class="d-flex justify-content-center align-items-center">
                            <img src="/uploadimages/Logo-TRIPLE.png" alt="logo" style="height: 130px; margin-right: 20px;" />
                            <div class="">
                                <h4>TRIPLE Serviced Apartment & Hotel (Group)</h4>
                                <span>Da Nang:	(+84) 90 198 0803 </span><span class="ml-2">booking.tripledanang@gmail.com</span>
                                <br />
                                <span>Hoi An:	(+84) 90 148 0803</span><span class="ml-3">booking.triplehoian@gmail.com</span>
                                <br />
                                <span>www.triplegroup.net</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div>

                    <div class="az-content pd-y-20 pd-lg-y-30 pd-xl-y-40">
                        <div class="container">
                            <!-- az-content-left -->

                            <div class="az-content-body d-flex flex-column">
                                <div class="az-content-label text-center">
                                    <h2>REGISTRATION FORM</h2>
                                </div>
                                <div class="card border-0">
                                    <table class="table table-bordered">
                                        <asp:Repeater ID="rpShowPrint" runat="server">
                                            <ItemTemplate>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">Location: <%#Eval("building_name") %></td>
                                                        <td>Transaction No.: <%#Eval("order_codeTrading") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">Guest’s name: <%#Eval("order_nameGuest") %> </td>
                                                        <td>Passport / ID No.: <%#Eval("order_passport") %>  </td>
                                                        <td>Nationality : <%#Eval("order_country") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>TRIPLE’s ID: <%#Eval("order_IdGuest") %> </td>
                                                        <td>Phone number: <%#Eval("order_guestPhone") %> </td>
                                                        <td colspan="2">Email: <%#Eval("order_guestEmail") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Room type : <%#Eval("listring_name") %> </td>
                                                        <td>Room No.: <%#Eval("order_amount") %> </td>
                                                        <td>Check-in date : <%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                                        <td>Check-out date : <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Total room bill: <%=total %></td>
                                                        <td>Rate type: <%#Eval("order_loaiGia") %> </td>
                                                        <td>Booking channel / TA: <%#Eval("order_kenhBook") %> </td>
                                                        <td>OTA / TA Booking ID : <%#Eval("order_OTATABookingID") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Number of Adult : <%#Eval("order_NumberofAdult") %></td>
                                                        <td>Number of U7-12 Child : <%#Eval("order_NumberofU712Child") %></td>
                                                        <td>Extra bed : <%#Eval("order_Extrabed") %></td>
                                                        <td>Additional room charge : <%#Eval("order_Additionalroomcharge","{0:0,00}") %>đ</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="valign-top align-baseline">Room Prepaid / Deposit Amount: <%#Eval("order_RoomPrepaid","{0:0,00}") %> đ</td>
                                                        <td class="valign-top align-baseline">Room Collect Amount: <%=RoomCollectAmount %></td>
                                                        <td class="valign-top align-baseline">Pay when checkin : <%#Eval("order_PaywhenCheckin","{0:0,00}") %> đ</td>
                                                        <td class="valign-top align-baseline">Collect Account: <%#Eval("order_CollectAccount") %>
                                        <%--<label class="ckbox mg-b-10">
                                            <input type="checkbox"><span>Travel Agency</span>
                                        </label>
                                                            <label class="ckbox">
                                                                <input type="checkbox"><span> Guest</span>
                                                            </label>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">Special Request (if any) : <%#Eval("order_SpecialRequest") %></td>
                                                        <td>Collection for special request : <%#Eval("order_Collectionforspecialrequest") %></td>
                                                    </tr>
                                                </tbody>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                <p class="mg-t-20">By signing this registration card, I agree to be bound by the hotel policy, rules and regulations. I hereby acknowledge that I am jointly and severally liable with the foregoing person, company and association for the payment of the cost and payable charges incurred in connection with all services provided by the hotel under this registration, including cancellation charge for any services agreed and confirmed at the time of reservation.</p>
                                <div class="card border-0">
                                    <table class="table table-bordered">
                                        <tbody>
                                            <tr>
                                                <th class="ht-100 wd-50p valign-top align-baseline ">Guest’s Signature</th>
                                                <th class="ht-100 wd-50p valign-top align-baseline">Receptionist</th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <p class="mg-t-20 text-center">Enjoy staying with us</p>
                            </div>
                            <!-- az-content-body -->
                        </div>
                        <!-- container -->
                    </div>
                </div>
            </article>

        </section>
        <br />
        <br />
        <div class="container-fluid text-center">
            <asp:UpdatePanel runat="server" ID="upOut">
                <ContentTemplate>
                    <a href="javascript:void(0);" onclick="PrintA4()" class="btn-light btn">In thử</a>
                    <a href="javascript:void(0);" id="btnXacNhan" runat="server" onserverclick="btnXacNhan_ServerClick" onclick="PrintA4()" class="btn-dark btn">Xác Nhận</a>
                    <a id="btnBack" href="javascript:void(0);" runat="server" class="btn btn-success" onserverclick="btnBack_ServerClick">Trở lại</a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <script src="/admin_js/js_triple/jquery.min.js"></script>
        <script src="/admin_js/js_triple/printThis.js"></script>
        <script type="text/javascript" language="javascript"> 
            function PrintA4() {
                $('section').printThis();
            }
        </script>
        <br />
        <br />
    </form>
</body>
</html>

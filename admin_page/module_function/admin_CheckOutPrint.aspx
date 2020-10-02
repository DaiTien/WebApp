<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_CheckOutPrint.aspx.cs" Inherits="admin_page_module_function_admin_CheckOutPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check out - TRIPLE Serviced Apartment & Hotel</title>
    <link href="/admin_css/css_triple/azia.css" rel="stylesheet" />
    <link href="/admin_css/css_triple/paper.css" rel="stylesheet" />
    <link href="../../admin_css/sweetalert.css" rel="stylesheet" />
    <script src="../../admin_js/sweetalert.js"></script>
    <style>
         .ckbox input[type='checkbox'][disabled] + span, .ckbox input[type='checkbox'][disabled] + span:before, .ckbox input[type='checkbox'][disabled] + span:after {
            opacity: 1;
        }

        .ckbox span:after {
            background-image: url(/admin_images/bg-check.png);
            background-color: transparent;
        }

        .ckbox span:before {
            border: 1px solid #000000;
        }
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
                                    <h2>CHECK-OUT INVOICE</h2>
                                </div>
                                <div class="card border-0 mg-b-20">
                                    <table class="table table-bordered">
                                        <asp:Repeater ID="rpShowCheckOut1" runat="server">
                                            <ItemTemplate>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">Location: <%#Eval("building_name") %></td>
                                                        <td>Transacton No.: <%#Eval("order_codeTrading") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Guest’s name: <%#Eval("order_nameGuest") %></td>
                                                        <td>Room No.:  <%#Eval("order_amount") %> </td>
                                                        <td>Check-in date: <%#Eval("order_checkin","{0:dd/MM/yyyy}") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td>TRIPLE’s ID: <%#Eval("order_IdGuest") %></td>
                                                        <td>Booking Channel / TA:  <%#Eval("order_kenhBook") %> </td>
                                                        <td>Check-out date: <%#Eval("order_checkout","{0:dd/MM/yyyy}") %></td>
                                                    </tr>
                                                </tbody>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                <p class="text-right mg-0">(Currency: VND or exchange to VND)</p>
                                <div class="card border-0">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th class="wd-50" scope="col">No.</th>
                                                <th class="wd-400" scope="col">Service</th>
                                                <th class="wd-150" scope="col">Note</th>
                                                <th class="wd-150" scope="col">Date</th>
                                                <th class="wd-150" scope="col">Amount</th>
                                                <th class="wd-150" scope="col">Service charge</th>
                                                <th class="wd-150" scope="col">Total Bill</th>
                                                <th class="wd-50" scope="col">Paid</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>ToTal Room Bill</td>
                                                <td></td>
                                                <td></td>
                                                <td>0</td>
                                                <td>0</td>
                                                <td class="text-right"><%= total %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Additional room charge</td>
                                                <td></td>
                                                <td></td>
                                                <td>0</td>
                                                <td>0</td>
                                                <td class="text-right"><%= additionalroomcharge %></td>
                                                <td></td>
                                            </tr>
                                            <asp:Repeater ID="rpDichVu" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <th scope="row"><%= Stt++%></th>
                                                        <td><%#Eval("dv_name") %></td>
                                                        <td><%#Eval("dv_thongtin") %></td>
                                                        <td><%#Eval("dv_ngay","{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("dv_price","{0:0,00}") %> đ</td>
                                                        <td><%#Eval("dv_Servicecharge") %></td>
                                                        <td class="text-right"><%#Eval("dv_total","{0:0,00}") %> đ</td>
                                                        <td>
                                                            <label class="ckbox">
                                                                <input disabled="disabled" type="checkbox" <%#Eval("checkedd") %>><span></span>
                                                            </label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Total all Bills</td>
                                                <td class="text-right"><%= TotalallBills%></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Room Prepaid / Deposit</td>
                                                <td class="text-right"><%= roomPrepaid %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Pay when checkin </td>
                                                <td class="text-right"><%= Paywhencheckin %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Paid</td>
                                                <td class="text-right"><%= paid %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Balance Pay Now</td>
                                                <%--<td class="text-right"><%= (Totalall + additionalroomcharge + total) - roomPrepaid - Paywhencheckin %></td>--%>
                                                <td class="text-right"><%= BalancePayNow %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2"></td>
                                                <td class="text-right"></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Pay by cash</td>
                                                <td class="text-right"><%=Paybycash %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Pay by card</td>
                                                <td class="text-right"><%=Paybycard %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Fee of card payment</td>
                                                <td class="text-right"><%=Feeofcardpayment %></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" scope="row" class="none"></th>
                                                <td colspan="2">Swipping card amount</td>
                                                <td class="text-right"><%=Swippingcardamount %></td>
                                                <td></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="card border-0">
                                    <table class="table table-bordered">
                                        <tbody>
                                            <tr>
                                                <th class="ht-100 wd-50p valign-top align-baseline ">Guest’s Signature
                                                </th>
                                                <th class="ht-100 wd-50p valign-top align-baseline">Receptionist</th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <p class="text-center mg-t-20">Thanks for staying with us</p>
                                <style>
                                    table tr .none {
                                        border-bottom: 1px solid #fffff0 !important;
                                        border-left: 1px solid #fffff0 !important;
                                    }
                                </style>

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
            <asp:UpdatePanel runat="server" ID="up_In">
                <ContentTemplate>
                    <a href="javascript:void(0);" onclick="PrintA4()" class="btn-light btn">In thử</a>
                    <a id="btnIN" href="javascript:void(0);" runat="server" onclick="PrintA4()" class="btn btn-dark" onserverclick="btnXN_ServerClick">Xác nhận</a>
                    <a id="btnBack" href="javascript:void(0);" runat="server" class="btn btn-info" onserverclick="btnBack_ServerClick">Trở lại</a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <script src="/admin_js/js_triple/jquery.min.js"></script>
        <script src="/admin_js/js_triple/printThis.js"></script>
        <script>
            function PrintA4() {
                $('section').printThis();
            }
        </script>
        <br />
        <br />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPrintA4.aspx.cs" Inherits="admin_page_module_function_TestPrintA4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/admin_css/css_triple/azia.css" rel="stylesheet" />
    <link href="/admin_css/css_triple/paper.css" rel="stylesheet" />
    <style>
        @page {
            size: A4;
        }
    </style>

</head>
<body class="A4">
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
                                    <tbody>
                                        <tr>
                                            <td colspan="3">Location: TRIPLE</td>
                                            <td>Transaction No.:</td>

                                        </tr>
                                        <tr>
                                            <td colspan="2">Guest’s name: </td>
                                            <td>Passport / ID No.:  </td>
                                            <td>Nationality:</td>
                                        </tr>
                                        <tr>
                                            <td>TRIPLE’s ID: </td>
                                            <td>Phone number:  </td>
                                            <td colspan="2">Email:</td>
                                        </tr>
                                        <tr>

                                            <td>Room type: </td>
                                            <td>Room No.: </td>
                                            <td>Check-in date:</td>
                                            <td>Check-out date:</td>
                                        </tr>
                                        <tr>

                                            <td>Total room bill: </td>
                                            <td>Rate type: </td>
                                            <td>Booking channel / TA: </td>
                                            <td>OTA / TA Booking ID:</td>
                                        </tr>
                                        <tr>
                                            <td>Number of Adult:</td>
                                            <td>Number of U7-12 Child:</td>
                                            <td>Extra bed:</td>
                                            <td>Additional room charge:</td>
                                        </tr>
                                        <tr>

                                            <td class="valign-top align-baseline">Room Prepaid / Deposit Amount: </td>
                                            <td class="valign-top align-baseline">Room Collect Amount:</td>
                                            <td class="valign-top align-baseline">Pay when checkin:</td>
                                            <td class="valign-top align-baseline">Collect Account:
                                        <label class="ckbox mg-b-10">
                                            <input type="checkbox"><span>Travel Agency</span>
                                        </label>
                                                <label class="ckbox">
                                                    <input type="checkbox"><span> Guest</span>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">Special Request (if any): </td>
                                            <td>Collection for special request: </td>
                                        </tr>


                                    </tbody>
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
        <button onclick="PrintA4()" class="btn-light btn">In thử</button>
        <button class="btn-dark btn">Xác nhận</button>
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
</body>
</html>

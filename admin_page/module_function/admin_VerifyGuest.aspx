<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_VerifyGuest.aspx.cs" Inherits="admin_page_module_function_admin_VerifyGuest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
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
                    <span>Verify</span>
                    <span>Verify Guest</span>
                </div>
                <h2 class="az-content-title">Verify Guest</h2>
                <!-- <div class="az-content-label mg-b-5">Responsive DataTable</div>
          <p class="mg-b-20">Responsive is an extension for DataTables that resolves that problem by optimising the table's layout for different screen sizes through the dynamic insertion and removal of columns from the table.</p> -->

                <div>
                    <div class="row d-flex flex-row-reverse mg-b-20">
                        <div class="col-sm-2 col-md-2"><a href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modaldemo1">Chi Tiết</a></div>

                    </div>
                    <div id="modaldemo1" class="modal">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content modal-content-demo">
                                <div class="modal-header">
                                    <h6 class="modal-title">Chi Tiết Verify Guest</h6>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-4 mg-t-30">Tên khách</div>
                                        <div class="col-md-4 mg-t-30">Số hộ chiếu</div>
                                        <div class="col-md-4 mg-t-30">ID khách</div>
                                        <div class="col-md-4 mg-t-30">Quốc tịch</div>
                                        <div class="col-md-4 mg-t-30">Khu vực địa lý</div>
                                        <div class="col-md-4 mg-t-30">Ngày sinh</div>
                                        <div class="col-md-4 mg-t-30">Email</div>
                                        <div class="col-md-4 mg-t-30">Số mobile</div>
                                        <div class="col-md-4 mg-t-30">Nghề nghiệp</div>
                                        <div class="col-md-4 mg-t-30">Ngày đến</div>
                                        <div class="col-md-4 mg-t-30">Ngày đi</div>
                                        <div class="col-md-4 mg-t-30">Tòa nhà</div>
                                        <div class="col-md-4 mg-t-30">Số phòng</div>
                                    </div>
                                    <div class="ht-20"></div>
                                    <div class="row">
                                        <div class=" col-md-6">
                                            <button class="btn btn-primary btn-block">Duyệt</button>
                                        </div>
                                        <div class=" col-md-6">
                                            <button class="btn btn-primary btn-block">Không Duyệt</button>
                                        </div>
                                    </div>
                                    <div class="ht-20"></div>
                                    <textarea rows="6" class="form-control" placeholder="Ghi chú"></textarea>
                                </div>


                            </div>
                        </div>
                        <!-- modal-dialog -->
                    </div>
                    <!-- modal -->
                    <table id="example2" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="wd-5p">Tên khách</th>
                                <th class="wd-5p">Số hộ chiếu</th>
                                <th class="wd-5p">ID khách</th>
                                <th class="wd-5p">Quốc tịch</th>
                                <th class="wd-10p">Khu vực địa lý</th>
                                <th class="wd-5p">Ngày sinh</th>
                                <th class="wd-10p">Email</th>
                                <th class="wd-5p">Số mobile</th>
                                <th class="wd-5p">Nghề nghiệp</th>
                                <th class="wd-5p">Ngày đến</th>
                                <th class="wd-5p">Ngày đi</th>
                                <th class="wd-5p">Tòa nhà</th>
                                <th class="wd-5p">Số phòng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Alex Nixon</td>
                                <td>124321235452</td>
                                <td>12425537</td>
                                <td>Australia</td>
                                <td>Tiger Nixon</td>
                                <td>18/9/1989</td>
                                <td>alexnixon1989@gmail.com</td>
                                <td>0324104100</td>
                                <td>Kĩ sư</td>
                                <td>14/4</td>
                                <td>16/4</td>
                                <td>System Architect</td>
                                <td>P1004</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="ht-40"></div>


            </div>
            <!-- az-content-body -->
        </div>
        <!-- container -->
    </div>
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


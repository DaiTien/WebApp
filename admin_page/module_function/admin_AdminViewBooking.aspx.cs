using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_AdminViewBooking : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable _idRoom = new DataTable();
    DataTable Load_ExportExcel = new DataTable();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            //Load Tòa Nhà
            ddBuilding.Items.Clear();
            ddBuilding.Items.Insert(0, "Chọn Tòa Nhà");
            ddBuilding.AppendDataBoundItems = true;
            ddBuilding.DataSource = from ct in db.tbBuildings select ct;
            ddBuilding.DataBind();
        }
        loadChitiet();

    }
    protected void loadData()
    {
        var getDataa = from b in db.tbOrders
                       join bd in db.tbBuildings on b.building_id equals bd.building_id
                       orderby b.order_id descending
                       //where b.book_show == true
                       select new
                       {
                           b.order_id,
                           b.order_codeTrading,
                           b.order_priceRoom,
                           b.order_loaiGia,
                           b.order_nameCTKM,
                           b.order_kenhBook,
                           b.order_amount,
                           b.order_checkin,
                           b.order_checkout,
                           b.order_dateBook,
                           b.order_nameGuest,
                           b.order_country,
                           b.order_status,
                           bd.building_id,
                           bd.building_name
                       };
        rpViewBook.DataSource = getDataa;
        rpViewBook.DataBind();
    }
    protected void loadChitiet()
    {

        var getValue = (from bk in db.tbOrders
                        join bd in db.tbBuildings on bk.building_id equals bd.building_id
                        orderby bk.order_dateBook descending
                        select new
                        {
                            bk.order_id,
                            bk.order_codeTrading,
                            bk.order_amount,
                            bk.order_checkin,
                            bk.order_checkout,
                            bk.order_dateBook,
                            bk.order_kenhBook,
                            bk.order_status,
                            bk.order_priceShow,
                            bk.order_IdGuest,
                            bk.order_loaiGia,
                            bk.order_nameGuest,
                            bk.order_priceRoom,
                            bk.order_country,
                            bk.order_nameCTKM,
                            bk.order_SpecialRequest,
                            bk.order_Extrabed,
                            bk.order_CollectAccount,
                            bk.order_Collectionforspecialrequest,
                            bk.order_OTATABookingID,
                            bk.order_Additionalroomcharge,
                            bk.order_PaywhenCheckin,
                            bk.order_NumberofAdult,
                            bk.order_NumberofU712Child,
                            bk.order_RoomPrepaid,
                            bd.building_id,
                            bd.building_name,
                        });
        rpViewChitiet.DataSource = getValue;
        rpViewChitiet.DataBind();

    }
    protected void btnDuyet_ServerClick(object sender, EventArgs e)
    {
        _idRoom = (DataTable)Session["_idRoom"];
        var checkValue = from b in db.tbQuanLyBooks
                         where b.book_id == Convert.ToInt32(txtId.Value)
                         select b;
        if (checkValue.Count() > 0)
        {
            var update = checkValue.FirstOrDefault();
            update.book_active = "Verified-Notcheck";
            update.book_show = false;
            db.SubmitChanges();
            if (Session["_idRoom"] != null)
            {
                var getID = from row in _idRoom.AsEnumerable()
                            join r in db.tbRooms on row.Field<int>("room_id") equals r.room_id
                            select new
                            {
                                id = row.Field<int>("room_id"),
                                r.listing_id
                            };
                foreach (var item in getID)
                {
                    tbLockRoom ins = new tbLockRoom();
                    ins.room_id = item.id;
                    ins.lookroom_dateStart = update.book_checkin;
                    ins.lookroom_dateEnd = update.book_checkout;
                    ins.listing_id = item.listing_id;
                    db.tbLockRooms.InsertOnSubmit(ins);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch
                    {

                    }
                }
                Session["_idRoom"] = null;
            }
            loadData();
        }
    }

    protected void btnXuatExcel_ServerClick(object sender, EventArgs e)
    {

        //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        //var workbook = new ExcelFile();
        //var worksheet = workbook.Worksheets.Add("DataTable to Sheet");
        var getDataa = from b in db.tbOrders
                       join bd in db.tbBuildings on b.building_id equals bd.building_id
                       orderby b.order_id descending
                       //where b.book_show == true
                       select new
                       {
                           b.order_id,
                           b.order_codeTrading,
                           b.order_priceRoom,
                           b.order_loaiGia,
                           b.order_nameCTKM,
                           b.order_kenhBook,
                           b.order_amount,
                           b.order_checkin,
                           b.order_checkout,
                           b.order_dateBook,
                           b.order_nameGuest,
                           b.order_country,
                           b.order_status,
                           bd.building_id,
                           bd.building_name
                       };
        Load_ExportExcel.Columns.Add("MÃ GIAO DỊCH", typeof(string));
        Load_ExportExcel.Columns.Add("GIÁ PHÒNG THEO NGÀY", typeof(string));
        Load_ExportExcel.Columns.Add("LOẠI GIÁ", typeof(string));
        Load_ExportExcel.Columns.Add("TÊN CTKM", typeof(string));
        Load_ExportExcel.Columns.Add("TÒA NHÀ", typeof(string));
        Load_ExportExcel.Columns.Add("SỐ PHÒNG", typeof(string));
        Load_ExportExcel.Columns.Add("NGÀY ĐẾN", typeof(DateTime));
        Load_ExportExcel.Columns.Add("NGÀY ĐI", typeof(DateTime));
        Load_ExportExcel.Columns.Add("TÊN KHÁCH", typeof(string));
        Load_ExportExcel.Columns.Add("QUỐC TỊCH", typeof(string));
        Load_ExportExcel.Columns.Add("KÊNH BOOK", typeof(string));
        Load_ExportExcel.Columns.Add("NGÀY BOOK", typeof(DateTime));
        foreach (var item_room in getDataa)
        {
            DataRow insertrow = Load_ExportExcel.NewRow();
            insertrow["MÃ GIAO DỊCH"] = item_room.order_codeTrading;
            insertrow["TÒA NHÀ"] = item_room.building_name;
            insertrow["TÊN KHÁCH"] = item_room.order_nameGuest;
            insertrow["QUỐC TỊCH"] = item_room.order_country;
            insertrow["NGÀY BOOK"] = item_room.order_dateBook;
            insertrow["NGÀY ĐẾN"] = item_room.order_checkin;
            insertrow["NGÀY ĐI"] = item_room.order_checkout;
            insertrow["SỐ PHÒNG"] = item_room.order_amount;
            insertrow["LOẠI GIÁ"] = item_room.order_loaiGia;
            insertrow["GIÁ PHÒNG THEO NGÀY"] = item_room.order_priceRoom;
            insertrow["TÊN CTKM"] = item_room.order_nameCTKM;
            insertrow["KÊNH BOOK"] = item_room.order_kenhBook;
            Load_ExportExcel.Rows.Add(insertrow);
        }
        //worksheet.Cells[0, 0].Value = "DataTable insert example:";
        //worksheet.InsertDataTable(Load_ExportExcel,
        //    new InsertDataTableOptions()
        //    {
        //        ColumnHeaders = true,
        //        StartRow = 2
        //    });

        //workbook.Save("DataTable to Sheet.xlsx");

        ExportToExcel(Load_ExportExcel);
        Response.Redirect("~/admin_page/module_function/admin_AdminViewBooking.aspx");
    }

    protected void btnNhapExcel_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/admin_page/module_function/admin_ImportExcel.aspx");
    }
    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string filename = "Danh Sách Booking.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    }
    //Lọc
    protected void btnLoc_ServerClick(object sender, EventArgs e)
    {
        if (ddBuilding.SelectedValue == "Chọn Tòa Nhà" && slLoaiNgay.Value == "" && txtTuNgay.Value == "" && txtDenNgay.Value == "")
        {
            var getValue = from od in db.tbOrders
                           join bd in db.tbBuildings on od.building_id equals bd.building_id
                           orderby od.order_id descending
                           select new
                           {
                               od.order_id,
                               od.order_codeTrading,
                               od.order_priceRoom,
                               od.order_loaiGia,
                               od.order_nameCTKM,
                               od.order_kenhBook,
                               od.order_amount,
                               od.order_checkin,
                               od.order_checkout,
                               od.order_dateBook,
                               od.order_nameGuest,
                               od.order_country,
                               od.order_status,
                               bd.building_id,
                               bd.building_name
                           };
            rpViewBook.DataSource = getValue;
            rpViewBook.DataBind();

        }
        else if (txtTuNgay.Value != "" && txtDenNgay.Value != "" && ddBuilding.SelectedValue == "Chọn Tòa Nhà" && slLoaiNgay.Value == "")
        {
            var getValue = from od in db.tbOrders
                           join bd in db.tbBuildings on od.building_id equals bd.building_id
                           where od.order_checkin >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkout <= Convert.ToDateTime(txtDenNgay.Value)
                           orderby od.order_id descending
                           select new
                           {
                               od.order_id,
                               od.order_codeTrading,
                               od.order_priceRoom,
                               od.order_loaiGia,
                               od.order_nameCTKM,
                               od.order_kenhBook,
                               od.order_amount,
                               od.order_checkin,
                               od.order_checkout,
                               od.order_dateBook,
                               od.order_nameGuest,
                               od.order_country,
                               od.order_status,
                               bd.building_id,
                               bd.building_name
                           };
            rpViewBook.DataSource = getValue;
            rpViewBook.DataBind();
        }
        else if (txtTuNgay.Value != "" && txtDenNgay.Value != "" && ddBuilding.SelectedValue != "Chọn Tòa Nhà")
        {
            var getValue = from od in db.tbOrders
                           join bd in db.tbBuildings on od.building_id equals bd.building_id
                           where bd.building_id == Convert.ToInt32(ddBuilding.SelectedValue)
                           && od.order_checkin >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkout <= Convert.ToDateTime(txtDenNgay.Value)
                           orderby od.order_id descending
                           select new
                           {
                               od.order_id,
                               od.order_codeTrading,
                               od.order_priceRoom,
                               od.order_loaiGia,
                               od.order_nameCTKM,
                               od.order_kenhBook,
                               od.order_amount,
                               od.order_checkin,
                               od.order_checkout,
                               od.order_dateBook,
                               od.order_nameGuest,
                               od.order_country,
                               od.order_status,
                               bd.building_id,
                               bd.building_name
                           };
            rpViewBook.DataSource = getValue;
            rpViewBook.DataBind();
        }
        else if (txtTuNgay.Value != "" && txtDenNgay.Value != "" && slLoaiNgay.Value != "" && ddBuilding.SelectedValue != "Chọn Tòa Nhà")
        {
            if (slLoaiNgay.Value == "Check in")
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where bd.building_id == Convert.ToInt32(ddBuilding.SelectedValue) && od.order_checkin >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkin <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
            else if (slLoaiNgay.Value == "Check out")
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where bd.building_id == Convert.ToInt32(ddBuilding.SelectedValue) && od.order_checkout >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkout <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
            else
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where bd.building_id == Convert.ToInt32(ddBuilding.SelectedValue) && od.order_dateBook >= Convert.ToDateTime(txtTuNgay.Value) && od.order_dateBook <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
        }
        else if (txtTuNgay.Value != "" && txtDenNgay.Value != "" && slLoaiNgay.Value != "")
        {
            if (slLoaiNgay.Value == "Check in")
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where od.order_checkin >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkin <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
            else if (slLoaiNgay.Value == "Check out")
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where od.order_checkout >= Convert.ToDateTime(txtTuNgay.Value) && od.order_checkout <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
            else
            {
                var getValue = from od in db.tbOrders
                               join bd in db.tbBuildings on od.building_id equals bd.building_id
                               where od.order_dateBook >= Convert.ToDateTime(txtTuNgay.Value) && od.order_dateBook <= Convert.ToDateTime(txtDenNgay.Value)
                               orderby od.order_id descending
                               select new
                               {
                                   od.order_id,
                                   od.order_codeTrading,
                                   od.order_priceRoom,
                                   od.order_loaiGia,
                                   od.order_nameCTKM,
                                   od.order_kenhBook,
                                   od.order_amount,
                                   od.order_checkin,
                                   od.order_checkout,
                                   od.order_dateBook,
                                   od.order_nameGuest,
                                   od.order_country,
                                   od.order_status,
                                   bd.building_id,
                                   bd.building_name
                               };
                rpViewBook.DataSource = getValue;
                rpViewBook.DataBind();
            }
        }
        else
        {
            var getValue = from od in db.tbOrders
                           join bd in db.tbBuildings on od.building_id equals bd.building_id
                           where bd.building_id == Convert.ToInt32(ddBuilding.SelectedValue)
                           orderby od.order_id descending
                           select new
                           {
                               od.order_id,
                               od.order_codeTrading,
                               od.order_priceRoom,
                               od.order_loaiGia,
                               od.order_nameCTKM,
                               od.order_kenhBook,
                               od.order_amount,
                               od.order_checkin,
                               od.order_checkout,
                               od.order_dateBook,
                               od.order_nameGuest,
                               od.order_country,
                               od.order_status,
                               bd.building_id,
                               bd.building_name
                           };
            rpViewBook.DataSource = getValue;
            rpViewBook.DataBind();
        }
    }
}
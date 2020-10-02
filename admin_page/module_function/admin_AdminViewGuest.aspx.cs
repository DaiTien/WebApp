using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_page_module_function_admin_AdminViewGuest : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    DataTable Load_ExportExcel = new DataTable();
    public string hangGuest="Member";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
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
        var getGuest = from guest in db.tbOrders
                       join building in db.tbBuildings on guest.building_id equals building.building_id
                       //join listing in db.tbListings on building.building_id equals listing.building_id
                       //join room in db.tbRooms on listing.listing_id equals room.listing_id
                       select new
                       {
                           guest.order_id,
                           guest.order_nameGuest,
                           guest.order_country,
                           guest.order_checkin,
                           guest.order_checkout,
                           guest.order_khuvucdialy,
                           guest.order_guestNgaySinh,
                           guest.order_guestNgheNghiep,
                           guest.order_IdGuest,
                           building.building_name,
                       };
        rpViewGuest.DataSource = getGuest;
        rpViewGuest.DataBind();
    }
    protected void loadChitiet()
    {
        var getGuest = from guest in db.tbOrders
                       join building in db.tbBuildings on guest.building_id equals building.building_id
                       //join listing in db.tbListings on building.building_id equals listing.building_id
                       //join room in db.tbRooms on listing.listing_id equals room.listing_id
                       join dtl in db.tbDiemTichLuys on guest.order_IdGuest equals dtl.dtl_IdGuest
                       select new
                       {
                           guest.order_id,
                           guest.order_nameGuest,
                           guest.order_country,
                           guest.order_checkin,
                           guest.order_checkout,
                           guest.order_kenhBook,
                           guest.order_diadiemdensaukhidi,
                           guest.order_diadiemneuquaylai,
                           guest.order_tieutientichluy,
                           guest.order_phuongtienlienlackhac,
                           guest.order_ngaytieutientichluy,
                           guest.order_passport,
                           guest.order_guestNgheNghiep,
                           guest.order_tinhcach,
                           guest.order_lydo,
                           guest.order_khuvucdialy,
                           guest.order_guestPhone,
                           guest.order_diadiemotruockhitoi,
                           guest.order_dukienthoigianquaylai,
                           guest.order_gopykhachhang,
                           guest.order_dichvutieutientichluy,
                           guest.order_amount,
                           guest.order_IdGuest,
                           guest.order_guestEmail,
                           guest.order_guestNgaySinh,
                           guest.order_diemtichluy,
                           guest.order_dukienthoigianoneuquaylai,
                           building.building_name,
                           dtl.dtl_id,
                           dtl.dtl_sumRoomprice,
                           dtl.dtl_sumEatprice,
                           dtl.dtl_diemtichluy,
                           dtl.dtl_hangGuest
                       };
        rpChitiet.DataSource = getGuest;
        rpChitiet.DataBind();
    }
    protected void btnXuatExcel_ServerClick(object sender, EventArgs e)
    {

        //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        //var workbook = new ExcelFile();
        //var worksheet = workbook.Worksheets.Add("DataTable to Sheet");
        var getGuest = from guest in db.tbOrders
                       join building in db.tbBuildings on guest.building_id equals building.building_id
                       join listing in db.tbListings on building.building_id equals listing.building_id
                       join room in db.tbRooms on listing.listing_id equals room.listing_id
                       select new
                       {
                           guest.order_id,
                           guest.order_nameGuest,
                           guest.order_country,
                           guest.order_checkin,
                           guest.order_checkout,
                           guest.order_khuvucdialy,
                           guest.order_guestNgaySinh,
                           guest.order_guestNgheNghiep,
                           guest.order_IdGuest,
                           building.building_name,
                           room.room_name
                       };
        Load_ExportExcel.Columns.Add("TÊN KHÁCH", typeof(string));
        Load_ExportExcel.Columns.Add("ID KHÁCH", typeof(string));
        Load_ExportExcel.Columns.Add("QUỐC TỊCH", typeof(string));
        Load_ExportExcel.Columns.Add("KHU VỰC ĐỊA LÝ", typeof(string));
        Load_ExportExcel.Columns.Add("NGÀY SINH", typeof(string));
        Load_ExportExcel.Columns.Add("NGHỀ NGHIỆP", typeof(string));
        Load_ExportExcel.Columns.Add("NGÀY ĐẾN", typeof(DateTime));
        Load_ExportExcel.Columns.Add("NGÀY ĐI", typeof(DateTime));
        Load_ExportExcel.Columns.Add("TÒA NHÀ", typeof(string));
        foreach (var item_room in getGuest)
        {
            DataRow insertrow = Load_ExportExcel.NewRow();
            insertrow["TÊN KHÁCH"] = item_room.order_nameGuest;
            insertrow["ID KHÁCH"] = item_room.building_name;
            insertrow["QUỐC TỊCH"] = item_room.order_nameGuest;
            insertrow["KHU VỰC ĐỊA LÝ"] = item_room.order_khuvucdialy;
            insertrow["NGÀY SINH"] = item_room.order_guestNgaySinh;
            insertrow["NGHỀ NGHIỆP"] = item_room.order_guestNgheNghiep;
            insertrow["NGÀY ĐẾN"] = item_room.order_checkin;
            insertrow["NGÀY ĐI"] = item_room.order_checkout;
            insertrow["TÒA NHÀ"] = item_room.building_name;
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
    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string filename = "Danh Sách Khách Hàng.xls";
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

    protected void btn_Loc_ServerClick(object sender, EventArgs e)
    {
        if (ddBuilding.SelectedValue != "Chọn Tòa Nhà")
        {
            var getGuest = from guest in db.tbOrders
                           join building in db.tbBuildings on guest.building_id equals building.building_id
                           //join listing in db.tbListings on building.building_id equals listing.building_id
                           //join room in db.tbRooms on listing.listing_id equals room.listing_id
                           where building.building_id == Convert.ToInt32(ddBuilding.SelectedValue)
                           select new
                           {
                               guest.order_id,
                               guest.order_nameGuest,
                               guest.order_country,
                               guest.order_checkin,
                               guest.order_checkout,
                               guest.order_khuvucdialy,
                               guest.order_guestNgaySinh,
                               guest.order_guestNgheNghiep,
                               guest.order_IdGuest,
                               building.building_name,
                               //room.room_name
                           };
            rpViewGuest.DataSource = getGuest;
            rpViewGuest.DataBind();

        }
        else
        {
            var getGuest = from guest in db.tbOrders
                           join building in db.tbBuildings on guest.building_id equals building.building_id
                           //join listing in db.tbListings on building.building_id equals listing.building_id
                           //join room in db.tbRooms on listing.listing_id equals room.listing_id
                           select new
                           {
                               guest.order_id,
                               guest.order_nameGuest,
                               guest.order_country,
                               guest.order_checkin,
                               guest.order_checkout,
                               guest.order_khuvucdialy,
                               guest.order_guestNgaySinh,
                               guest.order_guestNgheNghiep,
                               guest.order_IdGuest,
                               building.building_name,
                               //room.room_name
                           };
            rpViewGuest.DataSource = getGuest;
            rpViewGuest.DataBind();
        }
    }
}
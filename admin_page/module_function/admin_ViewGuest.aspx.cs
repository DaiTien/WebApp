using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_ViewGuest : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
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
                           //room.room_name
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
                           guest.order_tinhcach,
                           guest.order_lydo,
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

    protected void btnLoc_ServerClick(object sender, EventArgs e)
    {
        if (ddBuilding.SelectedValue != "Chọn Tòa Nhà")
        {
            var getGuest = from guest in db.tbOrders
                           join building in db.tbBuildings on guest.building_id equals building.building_id
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
                           };
            rpViewGuest.DataSource = getGuest;
            rpViewGuest.DataBind();

        }
        else
        {
            var getGuest = from guest in db.tbOrders
                           join building in db.tbBuildings on guest.building_id equals building.building_id
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
    }
}
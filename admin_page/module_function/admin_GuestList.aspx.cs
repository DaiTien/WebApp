using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_VerifyGuest : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
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
    }
    protected void loadData()
    {
        var getGuest = from guest in db.tbOrders
                       join building in db.tbBuildings on guest.building_id equals building.building_id
                       //join listing in db.tbListings on building.building_id equals listing.building_id
                       //join room in db.tbRooms on listing.listing_id equals room.listing_id
                       orderby guest.order_checkin descending
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
        rpGuest.DataSource = getGuest;
        rpGuest.DataBind();
    }

    protected void btnAct_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        Session["idGuest"] = idGuest.Value;
        Response.Redirect("/admin-edit-guest");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_CheckInPrint : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int amount=0, totalall = 0;
    public string total, RoomCollectAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnBack.Visible = false;
        if (!IsPostBack)
        {
        }
        if (Session["_Id"] != null)
        {
            loadData();
            //loadTotal();
        }
    }
    protected void loadTotal()
    {
        var getPrice = from pr in db.tbOrders
                       where pr.order_id == Convert.ToInt32(Session["_Id"].ToString())
                       select new
                       {
                           pr.order_id,
                           pr.order_totalprice
                       };
        foreach ( var item in getPrice)
        {
            totalall = totalall + Convert.ToInt32(item.order_totalprice);
        }
        total= Convert.ToDecimal(totalall).ToString("#,##0.###")+" đ";
    }
    protected void loadData()
    {
        var getData = from dt in db.tbOrders
                      join bd in db.tbBuildings on dt.building_id equals bd.building_id
                      where dt.order_id == Convert.ToInt32(Session["_Id"].ToString())
                      select new
                      {
                          dt.order_id,
                          bd.building_id,
                          bd.building_name,
                          dt.order_codeTrading,
                          dt.order_nameGuest,
                          dt.order_passport,
                          dt.order_country,
                          dt.order_kenhBook,
                          dt.order_IdGuest,
                          dt.order_guestPhone,
                          dt.order_guestEmail,
                          dt.listring_name,
                          dt.order_amount,
                          dt.order_checkin,
                          dt.order_checkout,
                          dt.order_loaiGia,
                          dt.order_NumberofAdult,
                          dt.order_NumberofU712Child,
                          dt.order_Extrabed,
                          dt.order_Additionalroomcharge,
                          dt.order_PaywhenCheckin,
                          dt.order_SpecialRequest,
                          dt.order_Collectionforspecialrequest,
                          dt.order_OTATABookingID,
                          dt.order_RoomPrepaid,
                          dt.order_CollectAccount
                      };
        rpShowPrint.DataSource = getData;
        rpShowPrint.DataBind();
        foreach ( var item in getData)
        {
            amount = Convert.ToInt32(item.order_Additionalroomcharge) - Convert.ToInt32(item.order_RoomPrepaid);
        }
        loadTotal();
        int RoomCollect = totalall + amount;
        RoomCollectAmount = Convert.ToDecimal(RoomCollect).ToString("#,##0.###")+" đ";
    }

    protected void btnXacNhan_ServerClick(object sender, EventArgs e)
    {
        var getValue = from dt in db.tbOrders
                       where dt.order_id == Convert.ToInt32(Session["_Id"].ToString())
                       select dt;
        if (getValue.Count() > 0)
        {
            var update = getValue.FirstOrDefault();
            update.order_status = "Verified-CheckIn";
            update.order_IN = true;
            db.SubmitChanges();
        }
        //btnXacNhan.Visible = false;
        //btnBack.Visible = true;
    }

    protected void btnBack_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin-book-update-status");
    }
}
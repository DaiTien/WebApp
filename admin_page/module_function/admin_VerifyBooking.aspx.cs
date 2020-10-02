using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_VerifyBooking : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable RoomId = new DataTable();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            loadChiTiet();
        }
    }
    protected void loadChiTiet()
    {
        var a = (from bk in db.tbOrders
                 join bd in db.tbBuildings on bk.building_id equals bd.building_id
                 orderby bk.order_id descending
                 select new
                 {
                     bk.order_id,
                     bk.order_codeTrading,
                     bk.order_amount,
                     bk.order_checkin,
                     bk.order_checkout,
                     bk.order_dateBook,
                     bk.order_kenhBook,
                     bk.order_priceShow,
                     bk.order_SpecialRequest,
                     bk.order_Extrabed,
                     bk.order_CollectAccount,
                     bk.order_Collectionforspecialrequest,
                     bk.order_Additionalroomcharge,
                     bk.order_PaywhenCheckin,
                     bk.order_NumberofAdult,
                     bk.order_NumberofU712Child,
                     bk.order_IdGuest,
                     bk.order_RoomPrepaid,
                     bk.order_OTATABookingID,
                     bk.order_loaiGia,
                     bk.order_nameGuest,
                     bk.order_priceRoom,
                     bk.order_country,
                     bk.order_nameCTKM,
                     bd.building_id,
                     bd.building_name,
                 });
        rpChitiet.DataSource = a;
        rpChitiet.DataBind();
    }
    protected void loadData()
    {
        var getDataa = from o in db.tbOrders
                       join bd in db.tbBuildings on o.building_id equals bd.building_id
                       orderby o.order_dateBook descending
                       where o.order_Show == true
                       select new
                       {
                           o.order_id,
                           o.order_codeTrading,
                           o.order_priceRoom,
                           o.order_loaiGia,
                           o.order_nameCTKM,
                           o.order_kenhBook,
                           o.order_amount,
                           o.order_checkin,
                           o.order_checkout,
                           o.order_dateBook,
                           o.order_Ghichu,
                           o.order_nameGuest,
                           o.order_country,
                           o.order_status,
                           bd.building_id,
                           bd.building_name
                       };
        rpViewBook.DataSource = getDataa;
        rpViewBook.DataBind();
    }
    protected void btnDuyet_ServerClick(object sender, EventArgs e)
    {
        RoomId = (DataTable)Session["RoomId"];
        string _id = txtIdCt.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            var getValue = from b in db.tbOrders
                           where b.order_id == Convert.ToInt32(item)
                           select b;
            if (getValue.Count() > 0)
            {
                var update = getValue.FirstOrDefault();
                if (update.order_hidden == null)
                {
                    update.order_Show = false;
                    //Nhả phòng
                    var getLockRoom = from r in db.tbLockRooms
                                      where r.order_id == Convert.ToInt32(item)
                                      select r;
                    foreach (var room in getLockRoom)
                    {
                        room.lookroom_active = false;
                        db.SubmitChanges();
                    }
                    txtIdCt.Value = " ";
                }
                else
                {
                    update.order_Show = false;
                    update.order_status = "verified";
                    update.order_hidden = false;
                    db.SubmitChanges();
                    if (Session["RoomId"] != null)
                    {
                        var getID = from row in RoomId.AsEnumerable()
                                    join r in db.tbRooms on row.Field<int>("room_id") equals r.room_id
                                    select new
                                    {
                                        id = row.Field<int>("room_id"),
                                        r.listing_id
                                    };
                        foreach (var it in getID)
                        {
                            tbLockRoom ins = new tbLockRoom();
                            ins.room_id = it.id;
                            ins.lookroom_dateStart = update.order_checkin;
                            ins.lookroom_dateEnd = update.order_checkout;
                            ins.listing_id = it.listing_id;
                            ins.lookroom_active = true;
                            ins.order_id = update.order_id;
                            db.tbLockRooms.InsertOnSubmit(ins);
                            db.SubmitChanges();
                        }
                        Session["RoomId"] = null;
                    }
                    txtIdCt.Value = " ";
                }
                
            }
        }
        loadData();
        alert.alert_Success(Page,"Duyệt Thành Công","");
    }
    protected void btnKoDuyet_ServerClick(object sender, EventArgs e)
    {
        string _id = txtIdCt.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            var getValue = from b in db.tbOrders
                           where b.order_id == Convert.ToInt32(item)
                           select b;
            if (getValue.Count() > 0)
            {
                var update = getValue.FirstOrDefault();
                if (update.order_hidden==null)
                {
                    update.order_Show = false;
                    update.order_hidden = false;
                    update.order_status = "Verified";
                    update.order_Ghichu = txtGhichu.Value;
                    db.SubmitChanges();
                    txtIdCt.Value = " ";
                }
                else
                {
                    update.order_Show = false;
                    update.order_hidden = true;
                    update.order_status = "Unverified";
                    update.order_Ghichu = txtGhichu.Value;
                    db.SubmitChanges();
                    txtIdCt.Value = " ";
                    alert.alert_Success(Page, "Đã chuyển về Booking", "");

                }
            }
        }
        loadData();
    }
}
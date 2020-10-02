using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_SearchRoom : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable tbTableBook = new DataTable();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        tbTableBook = (DataTable)Session["tbTableBook"];
        if (Session["tbTableBook"] != null)
        {
            //get value in Session["tbTableBook"]
            var getValue = (from row in tbTableBook.AsEnumerable()
                            select row).First();
            //Show value lên
            string a = getValue.ItemArray[0].ToString();
            a = a.Split(' ')[0];
            DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", null);
            dateStart.Value = dt.ToString("dd/MM/yyyy");
            string b = getValue.ItemArray[1].ToString();
            b = b.Split(' ')[0];
            DateTime dt2 = DateTime.ParseExact(b, "dd/MM/yyyy", null);
            dateEnd.Value = dt2.ToString("dd/MM/yyyy");
            //dateEnd.Value = getValue.Field<string>("order_checkout");
            ddBuilding.SelectedValue = getValue.Field<int>("building_id").ToString();
            //Session["tbTableBook"] = null;
        }
        if (!IsPostBack)
        {
            //Đổ Building
            ddBuilding.Items.Clear();
            ddBuilding.Items.Insert(0, "0");
            ddBuilding.AppendDataBoundItems = true;
            ddBuilding.DataSource = from ct in db.tbBuildings select ct;
            ddBuilding.DataBind();
        }
        loadData();
    }
    protected void loadData()
    {

    }

    protected void btnLoc_ServerClick(object sender, EventArgs e)
    {
        getRoomKhongKhoa();
    }
    public void getRoomKhongKhoa()
    {
        //tạo DataTable để lưu danh sách phòng hợp lệ
        DataTable room = new DataTable();
        room.Columns.Add("room_id", typeof(int));
        room.Columns.Add("room_name", typeof(string));
        room.Columns.Add("listing_id", typeof(int));
        //room.Columns.Add("room_active", typeof(bool));
        //room.Columns.Add("Active", typeof(string));
        // b1 mình sẽ đi lấy danh sách toàn bộ phòng của 1 building
        var listRoom_Building = from r in db.tbRooms
                                join l in db.tbListings on r.listing_id equals l.listing_id
                                join b in db.tbBuildings on l.building_id equals b.building_id
                                where b.building_id == Convert.ToInt32(ddBuilding.SelectedValue)
                                select r;
        //b2 mình đem toàn bộ phòng đi duyệt qua cái lockroom, nếu phòng nào ko có trong khoảng thời gian đó thì mình cho show ra
        //string ds_Room_Rong = "";
        foreach (var item_Room in listRoom_Building)
        {
            var check_Room_Block = from r in db.tbLockRooms
                                   where r.room_id == item_Room.room_id
                                   select r;
            //DateTime dt = DateTime.ParseExact(dateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string start = dateStart.Value;
            string end = dateEnd.Value;
            // Kiểm tra phòng p101 có trong bảng khóa phòng từ ngày đến ngày ko? 
            var check_Room = from r in check_Room_Block
                             where (r.lookroom_dateStart <= Convert.ToDateTime(start) && Convert.ToDateTime(start) <= r.lookroom_dateEnd)
                                  || (r.lookroom_dateStart <= Convert.ToDateTime(end) && Convert.ToDateTime(end) <= r.lookroom_dateEnd)
                                 || (Convert.ToDateTime(start) <= r.lookroom_dateStart && r.lookroom_dateStart <= Convert.ToDateTime(end))
                                  || (Convert.ToDateTime(start) <= r.lookroom_dateEnd && r.lookroom_dateEnd <= Convert.ToDateTime(end))
                             select r;
            if (check_Room.Count() > 0)
            {

            }
            else
            {
                //ds_Room_Rong = ds_Room_Rong + item_Room.room_name + ",";
                //room.Rows.Add(item_Room.room_name, item_Room.listing_id, item_Room);
                DataRow row = room.NewRow();
                row["room_id"] = item_Room.room_id;
                row["room_name"] = item_Room.room_name;
                row["listing_id"] = item_Room.listing_id;
                //row["room_active"] = item_Room.room_active;
                room.Rows.Add(row);
            }
        }
        // b3 : đổ lên rp
        //where row.Field<int>("Age") >= 3
        var query = from row in room.AsEnumerable()
                    join lt in db.tbListings on row.Field<int>("Listing_id") equals lt.listing_id
                    //join r in db.tb_Rooms on row.Field<int>("room_id") equals r.room_id
                    join bd in db.tbBuildings on lt.building_id equals bd.building_id
                    join ct in db.tbCities on bd.city_id equals ct.city_id
                    //where lt.listing_id == Convert.ToInt32(ddListing.SelectedValue)
                    select new
                    {
                        //r.room_id,
                        lt.listing_id,
                        lt.listing_name,
                        bd.building_id,
                        bd.building_name,
                        ct.city_id,
                        ct.city_name,
                        room_name = row.Field<string>("room_name"),
                        room_id = row.Field<int>("room_id"),
                        //room_active = row.Field<bool>("room_active")==true?"Chưa khóa":""
                    };
        rpRoom.DataSource = query;
        rpRoom.DataBind();
        //Session["tbRoom"] = room;
    }

    protected void btnBook_ServerClick(object sender, EventArgs e)
    {
        alert.alert_Success(Page, "Đã gửi thông tin về Admin", "");
        //Tạo table để lưu trữ id room được checked (chọn)
        DataTable _idRoom = new DataTable();
        _idRoom.Columns.Add("room_id", typeof(int));
        //Lấy id của checked
        string _id = txtId.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            DataRow row = _idRoom.NewRow();
            row["room_id"] = item;
            _idRoom.Rows.Add(row);
        }
        //Lưu Session
        Session["_idRoom"] = _idRoom;
        //Lấy Value từ Session["tbTableBook"]  và Lưu dữ liệu vào tbQuanLyBook
        tbTableBook = (DataTable)Session["tbTableBook"];
        if (Session["tbTableBook"] != null)
        {
            //get value in Session["tbTableBook"]
            var getValue = from row in tbTableBook.AsEnumerable()
                           select new {
                               checkin = row.Field<string>("order_checkin"),
                               checkout = row.Field<string>("order_checkout"),
                               order_id = row.Field<int>("order_id")
                           };
            //Lưu value vào tbQuanLyBook
            foreach (var item in getValue)
            {
                var getOrder = (from od in db.tbOrders
                                where od.order_id == item.order_id
                                select od).First();
                tbQuanLyBook ins = new tbQuanLyBook();
                ins.book_checkin = Convert.ToDateTime(item.checkin);
                ins.book_checkout = Convert.ToDateTime(item.checkout);
                ins.book_active = "Unverified";
                ins.book_show = true;
                ins.book_codeTrading = getOrder.order_codeTrading;
                ins.book_dateBook = getOrder.order_dateBook;
                ins.book_email = getOrder.order_email;
                ins.book_phone = getOrder.order_phone;
                ins.book_nationality = getOrder.order_country;
                ins.book_giaShow = getOrder.order_priceShow;
                ins.book_loaigia = getOrder.order_loaiGia;
                ins.book_priceRoom = getOrder.order_priceRoom;
                ins.book_IdGuest = getOrder.order_IdGuest;
                ins.book_kenhBook = getOrder.order_kenhBook;
                ins.book_nameGuest = getOrder.order_nameGuest;
                ins.book_nameCTKM = getOrder.order_nameCTKM;
                ins.account_id = getOrder.account_id;
                ins.building_id = getOrder.building_id;
                db.tbQuanLyBooks.InsertOnSubmit(ins);
                try
                {
                    db.SubmitChanges();
                }
                catch
                {

                }
            }
            Session["tbTableBook"] = null;
        }
        //Response.Redirect("/admin_page/module_function/admin_BookAddEdit2.aspx");
    }
}
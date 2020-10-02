using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_BookAddEdit2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable tbTable = new DataTable();
    public string Disabled, giaNiemyet, start, end;
    string tinhtrang, getfulldate, getfulldate1;
    int datein, monthin, yearin, datein1, monthin1, yearin1;


    cls_Alert alert = new cls_Alert();

    protected void Page_Load(object sender, EventArgs e)
    {
        //tinhtrang = Request.Params["tinhtrang"];
        if (Session["TinhTrang"] != null)
        {
            if (Session["TinhTrang"].ToString() == "Edit")
            {
                Disabled = "disabled";
                btnXN.Visible = false;

            }
        }
        //Lấy giá niêm yết
        tbTable = (DataTable)Session["tbTable"];
        if (Session["tbTable"] != null)
        {
            var getvalue = (from row in tbTable.AsEnumerable()
                            select row).First();
            //Get giá của Listing
            var getPriceListing = (from lt in db.tbListings
                                   where lt.listing_id == getvalue.Field<int>("listing_id")
                                   select new
                                   {
                                       lt.listing_id,
                                       lt.listing_price
                                   }).First();
            giaNiemyet = Convert.ToDecimal(getPriceListing.listing_price).ToString("#,##0.###");
            //String.Format("{0:0,0}", giaNiemyet = Convert.ToString(getPriceListing.listing_price));
        }
        //End
        if (!IsPostBack)
        {
            //Đổ Building
            ddBuilding.Items.Clear();
            ddBuilding.Items.Insert(0, "0");
            ddBuilding.AppendDataBoundItems = true;
            ddBuilding.DataSource = from ct in db.tbBuildings select ct;
            ddBuilding.DataBind();
            //Đổ Listing
            ddListing.Items.Clear();
            ddListing.Items.Insert(0, "0");
            ddListing.AppendDataBoundItems = true;
            ddListing.DataSource = from lt in db.tbListings select lt;
            ddListing.DataBind();
            //tự động đổ dữ liệu để lọc phòng
            tbTable = (DataTable)Session["tbTable"];
            if (Session["tbTable"] != null)
            {
                var getvalue = (from row in tbTable.AsEnumerable()
                                select row).First();
                //Get giá của Listing
                var getPriceListing = (from lt in db.tbListings
                                       where lt.listing_id == getvalue.Field<int>("listing_id")
                                       select new
                                       {
                                           lt.listing_id,
                                           lt.listing_price
                                       }).First();
                DateTime get = DateTime.Now;
                string getdate = get.ToString();
                string[] gett = getdate.Split('/');
                if (Convert.ToInt32(gett[1]) > 12)
                {
                    string a = getvalue.ItemArray[4].ToString();
                    a = a.Split(' ')[0].Trim();
                    string[] date = a.Split('/');
                    datein = Convert.ToInt32(date[0]);
                    monthin = Convert.ToInt32(date[1]);
                    yearin = Convert.ToInt32(date[2]);
                    if (Convert.ToInt32(datein) < 10) getfulldate = "0" + datein + "/" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(monthin) < 10 && (Convert.ToInt32(datein) >= 10))) getfulldate = datein + "/" + "0" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(monthin) < 10 && (Convert.ToInt32(datein) < 10))) getfulldate = "0" + datein + "/" + "0" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(datein) >= 10 && (Convert.ToInt32(monthin) >= 10))) getfulldate = datein + "/" + monthin + "/" + yearin;

                    DateTime dt = DateTime.ParseExact(getfulldate, "MM/dd/yyyy", null);
                    dateStar.Value = dt.ToString("dd/MM/yyyy");
                    string b = getvalue.ItemArray[5].ToString();
                    b = b.Split(' ')[0];
                    string[] date1 = b.Split('/');
                    datein1 = Convert.ToInt32(date1[0]);
                    monthin1 = Convert.ToInt32(date1[1]);
                    yearin1 = Convert.ToInt32(date1[2]);
                    if (Convert.ToInt32(datein1) < 10) getfulldate1 = "0" + datein1 + "/" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(monthin1) < 10 && (Convert.ToInt32(datein1) >= 10))) getfulldate1 = datein1 + "/" + "0" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(monthin1) < 10 && (Convert.ToInt32(datein1) < 10))) getfulldate1 = "0" + datein1 + "/" + "0" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(datein1) >= 10 && (Convert.ToInt32(monthin1) >= 10))) getfulldate1 = datein1 + "/" + monthin1 + "/" + yearin1;
                    DateTime dt2 = DateTime.ParseExact(getfulldate1, "MM/dd/yyyy", null);
                    dateEnd.Value = dt2.ToString("dd/MM/yyyy");
                }
                else if (Convert.ToInt32(gett[1]) <= 12)
                {

                    string a = getvalue.ItemArray[4].ToString();
                    a = a.Split(' ')[0].Trim();
                    string[] date = a.Split('/');
                    datein = Convert.ToInt32(date[0]);
                    monthin = Convert.ToInt32(date[1]);
                    yearin = Convert.ToInt32(date[2]);
                    if (Convert.ToInt32(datein) < 10) getfulldate = "0" + datein + "/" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(monthin) < 10 && (Convert.ToInt32(datein) >= 10))) getfulldate = datein + "/" + "0" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(monthin) < 10 && (Convert.ToInt32(datein) < 10))) getfulldate = "0" + datein + "/" + "0" + monthin + "/" + yearin;
                    if ((Convert.ToInt32(datein) >= 10 && (Convert.ToInt32(monthin) >= 10))) getfulldate = datein + "/" + monthin + "/" + yearin;


                    DateTime dt = DateTime.ParseExact(getfulldate, "dd/MM/yyyy", null);
                    dateStar.Value = dt.ToString("dd/MM/yyyy");
                    string b = getvalue.ItemArray[5].ToString();
                    b = b.Split(' ')[0];
                    string[] date1 = b.Split('/');
                    datein1 = Convert.ToInt32(date1[0]);
                    monthin1 = Convert.ToInt32(date1[1]);
                    yearin1 = Convert.ToInt32(date1[2]);
                    if (Convert.ToInt32(datein1) < 10) getfulldate1 = "0" + datein1 + "/" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(monthin1) < 10 && (Convert.ToInt32(datein1) >= 10))) getfulldate1 = datein1 + "/" + "0" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(monthin1) < 10 && (Convert.ToInt32(datein1) < 10))) getfulldate1 = "0" + datein1 + "/" + "0" + monthin1 + "/" + yearin1;
                    if ((Convert.ToInt32(datein1) >= 10 && (Convert.ToInt32(monthin1) >= 10))) getfulldate1 = datein1 + "/" + monthin1 + "/" + yearin1;
                    DateTime dt2 = DateTime.ParseExact(getfulldate1, "dd/MM/yyyy", null);
                    dateEnd.Value = dt2.ToString("dd/MM/yyyy");
                }
                ddBuilding.SelectedValue = getvalue.Field<int>("building_id").ToString();
                ddListing.SelectedValue = getvalue.Field<int>("listing_id").ToString();
                if (Session["IdOrder"] != null)
                {
                    loadData();
                }
            }
            //Load Rooom
            getRoomKhongKhoa();
            //Load ViewPrice
            if (Session["IdOrder"] != null)
            {
                loadViewPrice();
            }
            else if (Session["tbViewGia"] != null)
            {
                DataTable ViewGia = new DataTable();
                ViewGia = (DataTable)Session["tbViewGia"];
                var getData = from row in ViewGia.AsEnumerable()
                              select new
                              {
                                  oddp_date = row.Field<DateTime>("Ngay").ToString("dd/MM/yyyy"),
                                  oddp_price = row.Field<int>("Gia")
                              };
                rpViewPrice.DataSource = getData;
                rpViewPrice.DataBind();
            }
        }
    }
    protected void loadData()
    {
        var getData = (from od in db.tbOrders
                       where od.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                       select new
                       {
                           od.order_id,
                           od.order_priceShow,
                           od.order_priceRoom,
                           od.order_nameCTKM
                       }).FirstOrDefault();
        txtGiahienthi.Value = getData.order_priceShow;
        txtGiaphong.Value = getData.order_priceRoom;
        txtTCTKM.Value = getData.order_nameCTKM;
    }
    protected void loadViewPrice()
    {
        var getprice = from p in db.tbOrderDetailDatePrices
                       where p.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                       select new
                       {
                           p.oddp_id,
                           p.oddp_date,
                           p.oddp_price
                       };
        rpViewPrice.DataSource = getprice;
        rpViewPrice.DataBind();
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
                                //join b in db.tbBuildings on l.building_id equals b.building_id
                                where l.listing_id == Convert.ToInt32(ddListing.SelectedValue)
                                select r;
        //b2 mình đem toàn bộ phòng đi duyệt qua cái lockroom, nếu phòng nào ko có trong khoảng thời gian đó thì mình cho show ra
        //string ds_Room_Rong = "";
        foreach (var item_Room in listRoom_Building)
        {
            var check_Room_Block = from r in db.tbLockRooms
                                   where r.room_id == item_Room.room_id && r.lookroom_active == true
                                   select r;
            DateTime get = DateTime.Now;
            string getdate = get.ToString();
            string[] gett = getdate.Split('/');
            if (Convert.ToInt32(gett[1]) > 12)
            {
                DateTime dt = DateTime.ParseExact(dateStar.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                start = dt.ToString("MM/dd/yyyy");
                DateTime dt1 = DateTime.ParseExact(dateEnd.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                end = dt1.ToString("MM/dd/yyyy");

            }
            else if (Convert.ToInt32(gett[1]) <= 12)
            {
                DateTime dt = DateTime.ParseExact(dateStar.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                start = dt.ToString("dd/MM/yyyy");
                DateTime dt1 = DateTime.ParseExact(dateEnd.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                end = dt1.ToString("dd/MM/yyyy");

            }
            //DateTime dt = DateTime.ParseExact(dateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //string start = dateStar.Value;
            //string end = dateEnd.Value;
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
                        lt.listing_price,
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
    protected void btnLoc_ServerClick(object sender, EventArgs e)
    {
        getRoomKhongKhoa();
    }
    //public string Matutang()
    //{
    //    int year = DateTime.Now.Year;
    //    var list = from nk in db.tbOrders select nk;
    //    string s = "";
    //    if (list.Count() <= 0)
    //        s = "000001";
    //    else
    //    {
    //        var list1 = from nk in db.tbOrders orderby nk.order_id descending select nk;
    //        string chuoi = list1.First().order_codeTrading;
    //        chuoi = chuoi.Split('-')[2];
    //        int k;
    //        k = Convert.ToInt32(chuoi.Substring(0, 6));
    //        k = k + 1;
    //        if (k < 10) s = s + "00000";
    //        else if (k < 100)
    //            s = s + "0000";
    //        else if (k < 1000)
    //            s = s + "000";
    //        else if (k < 10000)
    //            s = s + "00";
    //        else if (k < 100000)
    //            s = s + "0";
    //        s = s + k.ToString();
    //    }
    //    return s;
    //}
    public string Matutang()
    {
        int year = DateTime.Now.Year;
        var list = from nk in db.tbOrders select nk;
        string s = "";
        if (list.Count() <= 0)
            s = "000001";
        else
        {
            var list1 = from nk in db.tbOrders orderby nk.order_matutangbook descending select nk;
            string chuoi = list1.First().order_matutangbook;
            chuoi = chuoi.Split('-')[1];
            int k;
            k = Convert.ToInt32(chuoi.Substring(0, 6));
            k = k + 1;
            if (k < 10) s = s + "00000";
            else if (k < 100)
                s = s + "0000";
            else if (k < 1000)
                s = s + "000";
            else if (k < 10000)
                s = s + "00";
            else if (k < 100000)
                s = s + "0";
            s = s + k.ToString();
        }
        return s;
    }
    protected void btnBook_ServerClick(object sender, EventArgs e)
    {
        cls_BookAddEdit2 cls = new cls_BookAddEdit2();
        //Tạo table để lưu trữ id room và loại phòng được checked (chọn)
        DataTable _idRoom = new DataTable();
        _idRoom.Columns.Add("soLuong", typeof(string));
        //Kiểm tra báo lỗi chưa chọn phòng 
        if (txtId.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng chọn phòng", "");
        }
        else
        {
            //Đếm số phòng và loại phòng được checked
            var getListing = from lt in db.tbListings
                             select new
                             {
                                 lt.listing_id,
                                 lt.listing_name
                             };
            foreach (var _id in getListing)
            {
                string room = txtId.Value;
                string[] getID = room.Split(',');
                foreach (var item in getID)
                {
                    int sumRom = 0;
                    var check = from r in db.tbRooms where r.room_id == Convert.ToInt32(item) && r.listing_id == _id.listing_id select new { r.room_id, r.room_name };
                    foreach (var r in check)
                    {
                        sumRom = sumRom + 1;
                        DataRow row = _idRoom.NewRow();
                        row["soLuong"] = sumRom + " Phòng " + r.room_name;
                        _idRoom.Rows.Add(row);
                    }
                    //sumRoom = sumRoom + 1;
                }
                //Đếm số lượng phòng cùng 1 loại Listing
            }
            //Lưu Session
            //Session["_idRoom"] = _idRoom;
            var getRoom = (from r in _idRoom.AsEnumerable()
                           select new { soLuong = r.Field<string>("soLuong") });
            string soLuong = "";
            foreach (var itm in getRoom)
            {
                soLuong = soLuong + itm.soLuong + " ,";
            }
            ///Lưu ID Room
            DataTable RoomId = new DataTable();
            RoomId.Columns.Add("room_id", typeof(int));
            //Lấy id của checked
            int SoPhong = 0;
            string idd = txtId.Value;
            string[] getId = idd.Split(',');
            foreach (var item in getId)
            {
                SoPhong = SoPhong + 1;
                DataRow row = RoomId.NewRow();
                row["room_id"] = item;
                RoomId.Rows.Add(row);
            }
            //Lưu Session
            Session["RoomId"] = RoomId;

            //Mã giao dịch
            string str_day = (DateTime.Now).ToString("yyyy/MM/dd");
            //// nếu txt_buildingid < 10 thì lưu thê số 0 ở trước
            if (Convert.ToInt32(ddBuilding.SelectedValue) < 10) ddBuilding.SelectedValue = "0" + ddBuilding.SelectedValue;
            string a = str_day + "-" + ddBuilding.SelectedValue + "-" + Matutang();
            string order_codeTrading = str_day + "-" + ddBuilding.SelectedValue + "-" + Matutang();
            //Lấy dữ liệu trong Session["tbTable"]
            tbTable = (DataTable)Session["tbTable"];
            if (Session["tbTable"] != null)
            {
                //get Value trong session
                var getvalue = (from row in tbTable.AsEnumerable()
                                select new
                                {
                                    checkin = row.Field<DateTime>("checkin"),
                                    checkout = row.Field<DateTime>("checkout"),
                                    building_id = row.Field<int>("building_id"),
                                    listing_id = row.Field<int>("listing_id"),
                                    loaiGia = row.Field<string>("loaiGia"),
                                    //giaShow = row.Field<string>("giaShow"),
                                    //tenCTKM = row.Field<string>("tenCTKM"),
                                    //giaRoom = row.Field<string>("giaRoom"),
                                    tenKhach = row.Field<string>("tenKhach"),
                                    idKhach = row.Field<string>("idKhach"),
                                    country = row.Field<string>("country"),
                                    kenhBook = row.Field<string>("kenhBook"),
                                    dateBook = row.Field<DateTime>("dateBook"),
                                    codeTrading = row.Field<string>("codeTrading"),
                                    passport = row.Field<string>("passport"),
                                    OTATABookingID = row.Field<string>("OTATABookingID"),
                                    RoomPrepaid = row.Field<string>("RoomPrepaid"),
                                    MaTuTangGuest = row.Field<string>("MatuTangGuest")
                                }).First();
                var getNameListing = (from lt in db.tbListings
                                      where lt.listing_id == getvalue.listing_id
                                      select new
                                      {
                                          lt.listing_id,
                                          lt.listing_name
                                      }).First();
                DataTable tbTableBook = new DataTable();
                //Check value có chưa chưa thì ins rồi thi update
                if (Session["IdOrder"] != null)
                {
                    var check = from d in db.tbOrders
                                where d.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                                select d;
                    //Tính tổng tiền giá listing 
                    var getlt = from lt in db.tbOrderDetailDatePrices
                                where lt.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                                select new
                                {
                                    lt.oddp_id,
                                    lt.oddp_price
                                };
                    int SumPriceLT = 0;
                    foreach (var item in getlt)
                    {
                        SumPriceLT = SumPriceLT + Convert.ToInt32(item.oddp_price);
                    }
                    int totalPrice = SumPriceLT * SoPhong;
                    string roomPr = "";
                    string RoomPrepaid = "";
                    if (getvalue.RoomPrepaid.Contains("."))
                    {
                        roomPr= getvalue.RoomPrepaid.Replace(".",",");
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    else
                    {
                        roomPr = getvalue.RoomPrepaid;
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    //Nếu có thì thực hiện Update
                    if (check.Count() > 0)
                    {
                        cls.Linq_Sua(Convert.ToInt32(Session["IdOrder"].ToString()), getvalue.codeTrading, getvalue.loaiGia, txtGiahienthi.Value, txtTCTKM.Value, getvalue.building_id, txtGiaphong.Value, getvalue.checkin, getvalue.checkout, getvalue.tenKhach, getvalue.idKhach, getvalue.country, getvalue.kenhBook, getvalue.dateBook, soLuong, getvalue.passport, getNameListing.listing_name, getvalue.OTATABookingID, Convert.ToInt32(RoomPrepaid), totalPrice, Matutang(), getvalue.MaTuTangGuest);
                    }
                    else
                    {
                        //Nếu chưa có thì insert vào tbOrder
                        cls.Linq_Them(order_codeTrading, getvalue.loaiGia, txtGiahienthi.Value, txtTCTKM.Value, getvalue.building_id, txtGiaphong.Value, getvalue.checkin, getvalue.checkout, getvalue.tenKhach, getvalue.idKhach, getvalue.country, getvalue.kenhBook, getvalue.dateBook, soLuong, getvalue.passport, getNameListing.listing_name, getvalue.OTATABookingID, Convert.ToInt32(RoomPrepaid), totalPrice, Matutang(), getvalue.MaTuTangGuest);
                    }
                }
                else
                {
                    string roomPr = "";
                    string RoomPrepaid = "";
                    if (getvalue.RoomPrepaid.Contains("."))
                    {
                        roomPr = getvalue.RoomPrepaid.Replace(".", ",");
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    else
                    {
                        roomPr = getvalue.RoomPrepaid;
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    //cls.Linq_Them(order_codeTrading, getvalue.loaiGia, txtGiahienthi.Value, txtTCTKM.Value, getvalue.building_id, txtGiaphong.Value, getvalue.checkin, getvalue.checkout, getvalue.tenKhach, getvalue.idKhach, getvalue.country, getvalue.kenhBook, getvalue.dateBook, soLuong, getvalue.passport, getNameListing.listing_name, getvalue.OTATABookingID, Convert.ToInt32(getvalue.RoomPrepaid));
                    tbOrder ins = new tbOrder();
                    ins.order_codeTrading = order_codeTrading;
                    ins.order_loaiGia = getvalue.loaiGia;
                    ins.order_priceShow = txtGiahienthi.Value;
                    ins.order_nameCTKM = txtTCTKM.Value;
                    ins.building_id = getvalue.building_id;
                    ins.order_priceRoom = txtGiaphong.Value;
                    ins.order_checkin = getvalue.checkin;
                    ins.order_checkout = getvalue.checkout;
                    ins.order_nameGuest = getvalue.tenKhach;
                    ins.order_IdGuest = getvalue.idKhach;
                    ins.order_country = getvalue.country;
                    ins.order_kenhBook = getvalue.kenhBook;
                    ins.order_dateBook = getvalue.dateBook;
                    ins.order_amount = soLuong;
                    ins.order_hidden = true;
                    ins.order_Show = true;
                    ins.order_status = "Unverified";
                    ins.order_matutangbook = "Book-" + Matutang();
                    ins.order_matutangGuest = getvalue.MaTuTangGuest;
                    ins.order_passport = getvalue.passport;
                    ins.listring_name = getNameListing.listing_name;
                    ins.order_OTATABookingID = getvalue.OTATABookingID;
                    ins.order_RoomPrepaid = Convert.ToInt32(RoomPrepaid);
                    db.tbOrders.InsertOnSubmit(ins);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch
                    {
                    }
                    //Lấy dữ liệu từ DataTable
                    int totalPrice = 0;
                    DataTable ViewGia = new DataTable();
                    ViewGia = (DataTable)Session["tbViewGia"];
                    if (Session["tbViewGia"] != null)
                    {
                        var getData = from row in ViewGia.AsEnumerable()
                                      select new
                                      {
                                          oddp_date = row.Field<DateTime>("Ngay").ToString("dd/MM/yyyy"),
                                          oddp_price = row.Field<int>("Gia")
                                      };
                        foreach (var it in getData)
                        {
                            tbOrderDetailDatePrice inn = new tbOrderDetailDatePrice();
                            inn.order_id = ins.order_id;
                            inn.oddp_date = it.oddp_date;
                            inn.oddp_price = it.oddp_price + "";
                            inn.listing_id = getvalue.listing_id;
                            db.tbOrderDetailDatePrices.InsertOnSubmit(inn);
                            db.SubmitChanges();
                        }
                        //Tính tổng tiền giá listing 
                        var getlt = from lt in db.tbOrderDetailDatePrices
                                    where lt.order_id == ins.order_id
                                    select new
                                    {
                                        lt.oddp_id,
                                        lt.oddp_price
                                    };
                        int SumPriceLT = 0;
                        foreach (var item in getlt)
                        {
                            SumPriceLT = SumPriceLT + Convert.ToInt32(item.oddp_price);
                        }
                        totalPrice = SumPriceLT * SoPhong;
                    }
                    var check = from ck in db.tbOrders
                                where ck.order_id == ins.order_id
                                select ck;
                    if (check.Count() > 0)
                    {
                        var up = check.FirstOrDefault();
                        up.order_totalprice = Convert.ToString(totalPrice);
                        db.SubmitChanges();
                    }


                }
            }
            Session["IdOrder"] = null;
            alert.alert_Success(Page, "Đã Chuyển Thông Tin Về Admin", "");
        }
    }

    protected void btnXacNhan_ServerClick(object sender, EventArgs e)
    {
        DataTable ViewGia = new DataTable();
        ViewGia = (DataTable)Session["tbViewGia"];
        //Tính số ngày giữa ngày đến và ngày đi được khuyến mãi
        TimeSpan tongNgay = Convert.ToDateTime(txtNgayDi.Value) - Convert.ToDateTime(txtNgayDen.Value);
        //Get giá áp dụng cho các ngày khuyến mãi
        string giaKhuyenMai = txtGiaphong.Value;
        string[] priceKM = giaKhuyenMai.Split(',');
        string priceKhuyenMai = "";
        foreach (var item in priceKM)
        {
            priceKhuyenMai = priceKhuyenMai + item;
        }
        int giaKM = Convert.ToInt32(priceKhuyenMai);
        //Update lại giá Khuyến mãi nếu có khuyến mãi
        DateTime times = Convert.ToDateTime(txtNgayDen.Value);
        for (int i = 0; i <= tongNgay.Days - 1; i++)
        {
            var get = from r in ViewGia.AsEnumerable()
                      where r.Field<DateTime>("Ngay") == times.AddDays(i)
                      select r;
            foreach (DataRow row in get)
            {
                row["Gia"] = giaKM;
                row["KhuyenMai"] = true;
            };
        }
        //Update lại giá niêm yết nếu có thay đổi
        //Bước 1 : Lấy những ngày có chương trình khuyến mãi
        //Tính giá rồi Lấy những ngày ko có chương trình khuyến mãi
        string gia = "";
        string Gianiem = "";
        if (txtGiahienthi.Value.Contains("."))
        {
            gia = txtGiahienthi.Value.Replace(".",",");
            string[] giaShow = gia.Split(',');
            foreach (var item in giaShow)
            {
                Gianiem = Gianiem + item;
            }
        }
        else
        {
            gia = txtGiahienthi.Value;
            string[] giaShow = gia.Split(',');
            foreach (var item in giaShow)
            {
                Gianiem = Gianiem + item;
            }
        }
        var gett = from r in ViewGia.AsEnumerable()
                   where r.Field<bool>("KhuyenMai") == false
                   select r;
        foreach (DataRow row in gett)
        {
            row["Gia"] = Convert.ToInt32(Gianiem);
        };
        //End
        //
        //View 
        var getData = from row in ViewGia.AsEnumerable()
                      select new
                      {
                          oddp_date = row.Field<DateTime>("Ngay").ToString("dd/MM/yyyy"),
                          oddp_price = row.Field<int>("Gia")
                      };
        rpViewPrice.DataSource = getData;
        rpViewPrice.DataBind();
    }

    protected void btnUpdate_ServerClick(object sender, EventArgs e)
    {
        DataTable ViewGia = new DataTable();
        ViewGia = (DataTable)Session["tbViewGia"];
        // Đếm số lượng phòng 
        int SoPhong = Convert.ToInt32(txtCountId.Value);
        // Get giá của từng ngày được lưu trong Table ViewGia
        //var getGia = (from pr in ViewGia.AsEnumerable()
        //             select new
        //             {
        //                 price = pr.Field<int>("Gia")
        //             }).First();
        var Price = (from pr in db.tbListings
                     where pr.listing_id == Convert.ToInt32(ddListing.SelectedValue)
                     select new
                     {
                         pr.listing_id,
                         pr.listing_price
                     }).First();
        //Giá tiền
        if (Convert.ToInt32(txtCountId.Value) == 0)
        {

        }
        else
        {
            if (txtId.Value != "")
            {

            }
            int PriceShow = SoPhong * Convert.ToInt32(giaNiemyet);
            //Update tbViewGia
            var getPrice = (from r in ViewGia.AsEnumerable()
                            select new
                            {
                                price = r.Field<int>("Gia"),
                                day = r.Field<DateTime>("Ngay")
                            });
            foreach (var item in getPrice)
            {
                var getValue = from dt in ViewGia.AsEnumerable()
                               where dt.Field<DateTime>("Ngay") == item.day
                               select dt;
                foreach (DataRow row in getValue)
                {
                    row["Gia"] = PriceShow;
                }
            }


            //Show gia
            var getData = from row in ViewGia.AsEnumerable()
                          select new
                          {
                              oddp_date = row.Field<DateTime>("Ngay").ToString("dd/MM/yyyy"),
                              oddp_price = row.Field<int>("Gia")
                          };
            rpViewPrice.DataSource = getData;
            rpViewPrice.DataBind();
        }
    }

    protected void btnCheckInNow_ServerClick(object sender, EventArgs e)
    {
        cls_BookAddEdit2 cls = new cls_BookAddEdit2();
        //Tạo table để lưu trữ id room và loại phòng được checked (chọn)
        DataTable _idRoom = new DataTable();
        _idRoom.Columns.Add("soLuong", typeof(string));
        //Kiểm tra báo lỗi chưa chọn phòng 
        if (txtId.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng chọn phòng", "");
        }
        else
        {
            //Đếm số phòng và loại phòng được checked
            var getListing = from lt in db.tbListings
                             select new
                             {
                                 lt.listing_id,
                                 lt.listing_name
                             };
            foreach (var _id in getListing)
            {
                string room = txtId.Value;
                string[] getID = room.Split(',');
                foreach (var item in getID)
                {
                    int sumRom = 0;
                    var check = from r in db.tbRooms where r.room_id == Convert.ToInt32(item) && r.listing_id == _id.listing_id select new { r.room_id, r.room_name };
                    foreach (var r in check)
                    {
                        sumRom = sumRom + 1;
                        DataRow row = _idRoom.NewRow();
                        row["soLuong"] = sumRom + " Phòng " + r.room_name;
                        _idRoom.Rows.Add(row);
                    }
                    //sumRoom = sumRoom + 1;
                }
                //Đếm số lượng phòng cùng 1 loại Listing
            }
            //Lưu Session
            //Session["_idRoom"] = _idRoom;
            var getRoom = (from r in _idRoom.AsEnumerable()
                           select new { soLuong = r.Field<string>("soLuong") });
            string soLuong = "";
            foreach (var itm in getRoom)
            {
                soLuong = soLuong + itm.soLuong + " ,";
            }
            ///Lưu ID Room
            DataTable RoomId = new DataTable();
            RoomId.Columns.Add("room_id", typeof(int));
            //Lấy id của checked
            int SoPhong = 0;
            string idd = txtId.Value;
            string[] getId = idd.Split(',');
            foreach (var item in getId)
            {
                SoPhong = SoPhong + 1;
                DataRow row = RoomId.NewRow();
                row["room_id"] = item;
                RoomId.Rows.Add(row);
            }
            //Lưu Session
            Session["RoomId"] = RoomId;

            //Mã giao dịch
            string str_day = (DateTime.Now).ToString("yyyy/MM/dd");
            //// nếu txt_buildingid < 10 thì lưu thê số 0 ở trước
            if (Convert.ToInt32(ddBuilding.SelectedValue) < 10) ddBuilding.SelectedValue = "0" + ddBuilding.SelectedValue;
            string a = str_day + "-" + ddBuilding.SelectedValue + "-" + Matutang();
            string order_codeTrading = str_day + "-" + ddBuilding.SelectedValue + "-" + Matutang();
            //Lấy dữ liệu trong Session["tbTable"]
            tbTable = (DataTable)Session["tbTable"];
            if (Session["tbTable"] != null)
            {
                //get Value trong session
                var getvalue = (from row in tbTable.AsEnumerable()
                                select new
                                {
                                    checkin = row.Field<DateTime>("checkin"),
                                    checkout = row.Field<DateTime>("checkout"),
                                    building_id = row.Field<int>("building_id"),
                                    listing_id = row.Field<int>("listing_id"),
                                    loaiGia = row.Field<string>("loaiGia"),
                                    //giaShow = row.Field<string>("giaShow"),
                                    //tenCTKM = row.Field<string>("tenCTKM"),
                                    //giaRoom = row.Field<string>("giaRoom"),
                                    tenKhach = row.Field<string>("tenKhach"),
                                    idKhach = row.Field<string>("idKhach"),
                                    country = row.Field<string>("country"),
                                    kenhBook = row.Field<string>("kenhBook"),
                                    dateBook = row.Field<DateTime>("dateBook"),
                                    codeTrading = row.Field<string>("codeTrading"),
                                    passport = row.Field<string>("passport"),
                                    OTATABookingID = row.Field<string>("OTATABookingID"),
                                    RoomPrepaid = row.Field<string>("RoomPrepaid"),
                                    MaTuTangGuest = row.Field<string>("MatuTangGuest")
                                }).First();
                var getNameListing = (from lt in db.tbListings
                                      where lt.listing_id == getvalue.listing_id
                                      select new
                                      {
                                          lt.listing_id,
                                          lt.listing_name
                                      }).First();
                DataTable tbTableBook = new DataTable();
                //Check value có chưa chưa thì ins rồi thi update
                if (Session["IdOrder"] != null)
                {
                    var check = from d in db.tbOrders
                                where d.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                                select d;
                    //Tính tổng tiền giá listing 
                    var getlt = from lt in db.tbOrderDetailDatePrices
                                where lt.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                                select new
                                {
                                    lt.oddp_id,
                                    lt.oddp_price
                                };
                    int SumPriceLT = 0;
                    foreach (var item in getlt)
                    {
                        SumPriceLT = SumPriceLT + Convert.ToInt32(item.oddp_price);
                    }
                    int totalPrice = SumPriceLT * SoPhong;
                    string roomPr = "";
                    string RoomPrepaid = "";
                    if (getvalue.RoomPrepaid.Contains("."))
                    {
                        roomPr = getvalue.RoomPrepaid.Replace(".", ",");
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    else
                    {
                        roomPr = getvalue.RoomPrepaid;
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    //Nếu có thì thực hiện Update
                    if (check.Count() > 0)
                    {
                        //cls.Linq_Sua(Convert.ToInt32(Session["IdOrder"].ToString()), getvalue.codeTrading, getvalue.loaiGia, txtGiahienthi.Value, txtTCTKM.Value, getvalue.building_id, txtGiaphong.Value, getvalue.checkin, getvalue.checkout, getvalue.tenKhach, getvalue.idKhach, getvalue.country, getvalue.kenhBook, getvalue.dateBook, soLuong, getvalue.passport, getNameListing.listing_name, getvalue.OTATABookingID, Convert.ToInt32(RoomPrepaid), totalPrice, Matutang(), getvalue.MaTuTangGuest);
                        var getData = (from dt in db.tbOrders
                                      where dt.order_id == Convert.ToInt32(Session["IdOrder"].ToString())
                                      select dt);
                        if (getData.Count()>0)
                        {
                            var update = getData.FirstOrDefault();
                            update.order_loaiGia = getvalue.loaiGia;
                            update.order_priceShow = txtGiahienthi.Value;
                            update.order_nameCTKM = txtTCTKM.Value;
                            update.building_id = getvalue.building_id;
                            update.order_priceRoom = txtGiaphong.Value;
                            update.order_checkin = getvalue.checkin;
                            update.order_checkout = getvalue.checkout;
                            update.order_nameGuest = getvalue.tenKhach;
                            update.order_IdGuest = getvalue.idKhach;
                            update.order_country = getvalue.country;
                            update.order_kenhBook = getvalue.kenhBook;
                            update.order_dateBook = getvalue.dateBook;
                            update.order_amount = soLuong;
                            update.order_hidden = false;
                            update.order_Show = false;
                            update.order_IN = true;
                            update.order_status = "verified-CheckIn";
                            update.order_passport = getvalue.passport;
                            update.listring_name = getNameListing.listing_name;
                            update.order_OTATABookingID = getvalue.OTATABookingID;
                            update.order_RoomPrepaid = Convert.ToInt32(RoomPrepaid);
                            update.order_totalprice = Convert.ToString(totalPrice);
                            update.order_matutangbook = "Book-" + Matutang();
                            update.order_matutangGuest = getvalue.MaTuTangGuest;
                            try
                            {
                                db.SubmitChanges();
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        //Nếu chưa có thì insert vào tbOrder
                        tbOrder ins = new tbOrder();
                        ins.order_codeTrading = order_codeTrading;
                        ins.order_loaiGia = getvalue.loaiGia;
                        ins.order_priceShow = txtGiahienthi.Value;
                        ins.order_nameCTKM = txtTCTKM.Value;
                        ins.building_id = getvalue.building_id;
                        ins.order_priceRoom = txtGiaphong.Value;
                        ins.order_checkin = getvalue.checkin;
                        ins.order_checkout = getvalue.checkout;
                        ins.order_nameGuest = getvalue.tenKhach;
                        ins.order_IdGuest = getvalue.idKhach;
                        ins.order_country = getvalue.country;
                        ins.order_kenhBook = getvalue.kenhBook;
                        ins.order_dateBook = getvalue.dateBook;
                        ins.order_amount = soLuong;
                        ins.order_hidden = false;
                        ins.order_Show = false;
                        ins.order_IN = true;
                        ins.order_status = "verified-CheckIn";
                        ins.order_passport = getvalue.passport;
                        ins.listring_name = getNameListing.listing_name;
                        ins.order_OTATABookingID = getvalue.OTATABookingID;
                        ins.order_RoomPrepaid = Convert.ToInt32(RoomPrepaid);
                        ins.order_totalprice = Convert.ToString(totalPrice);
                        ins.order_matutangbook = "Book-" + Matutang();
                        ins.order_matutangGuest = getvalue.MaTuTangGuest;
                        db.tbOrders.InsertOnSubmit(ins);
                        try
                        {
                            db.SubmitChanges();
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    string roomPr = "";
                    string RoomPrepaid = "";
                    if (getvalue.RoomPrepaid.Contains("."))
                    {
                        roomPr = getvalue.RoomPrepaid.Replace(".", ",");
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    else
                    {
                        roomPr = getvalue.RoomPrepaid;
                        string[] roomPre = roomPr.Split(',');
                        foreach (var item in roomPre)
                        {
                            RoomPrepaid = RoomPrepaid + item;
                        }
                    }
                    //cls.Linq_Them(order_codeTrading, getvalue.loaiGia, txtGiahienthi.Value, txtTCTKM.Value, getvalue.building_id, txtGiaphong.Value, getvalue.checkin, getvalue.checkout, getvalue.tenKhach, getvalue.idKhach, getvalue.country, getvalue.kenhBook, getvalue.dateBook, soLuong, getvalue.passport, getNameListing.listing_name, getvalue.OTATABookingID, Convert.ToInt32(getvalue.RoomPrepaid));
                    tbOrder ins = new tbOrder();
                    ins.order_codeTrading = order_codeTrading;
                    ins.order_loaiGia = getvalue.loaiGia;
                    ins.order_priceShow = txtGiahienthi.Value;
                    ins.order_nameCTKM = txtTCTKM.Value;
                    ins.building_id = getvalue.building_id;
                    ins.order_priceRoom = txtGiaphong.Value;
                    ins.order_checkin = getvalue.checkin;
                    ins.order_checkout = getvalue.checkout;
                    ins.order_nameGuest = getvalue.tenKhach;
                    ins.order_IdGuest = getvalue.idKhach;
                    ins.order_country = getvalue.country;
                    ins.order_kenhBook = getvalue.kenhBook;
                    ins.order_dateBook = getvalue.dateBook;
                    ins.order_amount = soLuong;
                    ins.order_hidden = false;
                    ins.order_Show = false;
                    ins.order_status = "Unverified";
                    ins.order_matutangbook = "Book-" + Matutang();
                    ins.order_matutangGuest = getvalue.MaTuTangGuest;
                    ins.order_passport = getvalue.passport;
                    ins.listring_name = getNameListing.listing_name;
                    ins.order_OTATABookingID = getvalue.OTATABookingID;
                    ins.order_RoomPrepaid = Convert.ToInt32(RoomPrepaid);
                    db.tbOrders.InsertOnSubmit(ins);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch
                    {
                    }
                    //Lấy dữ liệu từ DataTable
                    int totalPrice = 0;
                    DataTable ViewGia = new DataTable();
                    ViewGia = (DataTable)Session["tbViewGia"];
                    if (Session["tbViewGia"] != null)
                    {
                        var getData = from row in ViewGia.AsEnumerable()
                                      select new
                                      {
                                          oddp_date = row.Field<DateTime>("Ngay").ToString("dd/MM/yyyy"),
                                          oddp_price = row.Field<int>("Gia")
                                      };
                        foreach (var it in getData)
                        {
                            tbOrderDetailDatePrice inn = new tbOrderDetailDatePrice();
                            inn.order_id = ins.order_id;
                            inn.oddp_date = it.oddp_date;
                            inn.oddp_price = it.oddp_price + "";
                            inn.listing_id = getvalue.listing_id;
                            db.tbOrderDetailDatePrices.InsertOnSubmit(inn);
                            db.SubmitChanges();
                        }
                        //Tính tổng tiền giá listing 
                        var getlt = from lt in db.tbOrderDetailDatePrices
                                    where lt.order_id == ins.order_id
                                    select new
                                    {
                                        lt.oddp_id,
                                        lt.oddp_price
                                    };
                        int SumPriceLT = 0;
                        foreach (var item in getlt)
                        {
                            SumPriceLT = SumPriceLT + Convert.ToInt32(item.oddp_price);
                        }
                        totalPrice = SumPriceLT * SoPhong;
                    }
                    var check = from ck in db.tbOrders
                                where ck.order_id == ins.order_id
                                select ck;
                    if (check.Count() > 0)
                    {
                        var up = check.FirstOrDefault();
                        up.order_totalprice = Convert.ToString(totalPrice);
                        db.SubmitChanges();
                    }
                    Session["_Id"] = ins.order_id;
                }
            }
            Response.Redirect("/admin-checkin-info");
        }
    }
}
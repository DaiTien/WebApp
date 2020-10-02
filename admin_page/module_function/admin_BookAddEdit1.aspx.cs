using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_BookAddEdit1 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable tbTableBook = new DataTable();
    cls_Alert alert = new cls_Alert();
    string tinhtrang;
    DateTime start, end, datebook;
    protected void Page_Load(object sender, EventArgs e)
    {
        //tinhtrang = Request.Params["tinhtrang"];
        if (!IsPostBack)
        {
            //
            if (Session["IdOrder"] != null)
            {
                //get value in Session["tbTableBook"]
                //var getValue = (from row in tbTableBook.AsEnumerable()
                //                select row).First();
                ////Show value lên
                //var a = getValue.ItemArray[0].ToString();
                //a = a.Split(' ')[0];
                //DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", null);
                //dateStar.Value = dt.ToString("dd/MM/yyyy");
                //string b = getValue.ItemArray[1].ToString();
                //b = b.Split(' ')[0];
                //DateTime dt2 = DateTime.ParseExact(b, "dd/MM/yyyy", null);
                //dateEnd.Value = dt2.ToString("dd/MM/yyyy");
                ////dateEnd.Value = getValue.Field<string>("order_checkout");
                //ddBuilding.SelectedValue = getValue.Field<int>("building_id").ToString();
                //txtTenKhach.Value = getValue.Field<string>("order_nameGuest");
                //txtIDkhach.Value = getValue.Field<string>("order_IdGuest");
                //txtQuoctich.Value = getValue.Field<string>("order_country");
                //txtCodeTrading.Value = getValue.Field<string>("order_codeTrading");
                //txtNgayBook.Value = getValue.Field<DateTime>("order_dateBook").ToString("dd/MM/yyyy");
                //ddListing.DataSource = from lt in db.tbListings
                //                       where lt.building_id ==getValue.Field<int>("building_id")
                //                       select lt;
                //ddListing.DataBind();
                ////var localDateTime = DateTime.Now.ToString("yyyy-MM-dd").Replace(' ', 'T');
                ////txtNgay.Value = localDateTime;

                loadData();
            }
            else
            {
                dateStar.Value = "";
                dateEnd.Value = "";
                txtTenKhach.Value = "";
                txtIDkhach.Value = "";
                txtQuoctich.Value = "";
                txtCodeTrading.Value = "";
                txtNgayBook.Value = "";
                //Đổ Building
                ddBuilding.Items.Clear();
                ddBuilding.Items.Insert(0, "Chọn Tòa Nhà");
                ddBuilding.AppendDataBoundItems = true;
                ddBuilding.DataSource = from ct in db.tbBuildings select ct;
                ddBuilding.DataBind();
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
                           od.order_codeTrading,
                           od.order_checkin,
                           od.order_checkout,
                           od.order_dateBook,
                           od.building_id,
                           od.listring_name,
                           od.order_loaiGia,
                           od.order_nameGuest,
                           od.order_IdGuest,
                           od.order_kenhBook,
                           od.order_RoomPrepaid,
                           od.order_country,
                           od.order_passport
                       }).FirstOrDefault();
        txtCodeTrading.Value = getData.order_codeTrading;
     
        dateStar.Value = String.Format("{0:dd/MM/yyyy}", getData.order_checkin);
        //dateStar.Value = getData.order_checkin.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
        dateEnd.Value = String.Format("{0:dd/MM/yyyy}", getData.order_checkout);
        //dateEnd.Value = getData.order_checkout.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
        txtNgayBook.Value = String.Format("{0:dd/MM/yyyy}", getData.order_dateBook);
        //txtNgayBook.Value = getData.order_dateBook.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
        ddBuilding.DataSource = from bd in db.tbBuildings where bd.building_id == getData.building_id select bd;
        ddBuilding.DataBind();
        ddListing.DataSource = from lt in db.tbListings where lt.building_id == getData.building_id select lt;
        ddListing.DataBind();
        txtLoaigia.Value = getData.order_loaiGia;
        txtTenKhach.Value = getData.order_nameGuest;
        txtIDkhach.Value = getData.order_IdGuest;
        txtKenhbook.Value = getData.order_kenhBook;
        txtQuoctich.Value = getData.order_country;
        txtSohochieu.Value = getData.order_passport;
        //txtRoomPrepaid.Value = Convert.ToDecimal(getData.order_RoomPrepaid).ToString("#,##0.00"); 
        txtRoomPrepaid.Value = Convert.ToDecimal(getData.order_RoomPrepaid).ToString("#,##0.###");
        //txtRoomPrepaid.Value = Convert.ToString(getData.order_RoomPrepaid);
        //tinhtrang = Request.Params["tinhtrang"];
    }
    protected void AddData()
    {
        string roomPre = txtRoomPrepaid.Value;
        string[] roomPr = roomPre.Split(',');
        string RoomPrepaid = "";
        foreach (var item in roomPr)
        {
            RoomPrepaid = RoomPrepaid + item;
        }
        //Tạo DataTbale
        DataTable tbTable = new DataTable();
        tbTable.Columns.Add("codeTrading", typeof(string));
        tbTable.Columns.Add("loaiGia", typeof(string));
        //tbTable.Columns.Add("giaShow", typeof(string));
        //tbTable.Columns.Add("tenCTKM", typeof(string));
        tbTable.Columns.Add("building_id", typeof(int));
        tbTable.Columns.Add("listing_id", typeof(int));
        //tbTable.Columns.Add("giaRoom", typeof(string));
        tbTable.Columns.Add("checkin", typeof(DateTime));
        tbTable.Columns.Add("checkout", typeof(DateTime));
        tbTable.Columns.Add("tenKhach", typeof(string));
        tbTable.Columns.Add("idKhach", typeof(string));
        tbTable.Columns.Add("country", typeof(string));
        tbTable.Columns.Add("kenhBook", typeof(string));
        tbTable.Columns.Add("dateBook", typeof(DateTime));
        tbTable.Columns.Add("passport", typeof(string));
        tbTable.Columns.Add("OTATABookingID", typeof(string));
        tbTable.Columns.Add("RoomPrepaid", typeof(string));
        tbTable.Columns.Add("MatuTangGuest", typeof(string));
        DataRow row = tbTable.NewRow();
        row["codeTrading"] = txtCodeTrading.Value;
        row["loaiGia"] = txtLoaigia.Value;
        //row["giaShow"] = txtGiahienthi.Value;
        //row["tenCTKM"] = txtTCTKM.Value;
        row["building_id"] = Convert.ToInt32(ddBuilding.SelectedValue);
        row["listing_id"] = Convert.ToInt32(ddListing.SelectedValue);
        //row["giaRoom"] = txtGiaphong.Value;
         start = DateTime.ParseExact(dateStar.Value,"dd/MM/yyyy",null);
        end = DateTime.ParseExact(dateEnd.Value, "dd/MM/yyyy", null);
        datebook= DateTime.ParseExact(txtNgayBook.Value, "dd/MM/yyyy", null);
        row["checkin"] = start;
        row["checkout"] = end ;
        row["tenKhach"] = txtTenKhach.Value;
        row["idKhach"] = txtIDkhach.Value;
        row["country"] = txtQuoctich.Value;
        row["kenhBook"] = txtKenhbook.Value;
        row["dateBook"] = datebook;
        row["passport"] = txtSohochieu.Value;
        row["OTATABookingID"] = txtOTATABookingID.Value;
        row["RoomPrepaid"] = RoomPrepaid;
        row["MatuTangGuest"] = "Guest-"+ Matutang() ;
        tbTable.Rows.Add(row);
        //Lưu vào Session
        Session["tbTable"] = tbTable;
        ///
        TinhGiaNgay();


    }
    protected void TinhGiaNgay()
    {
        //Tạo DataTable view giá
        DataTable ViewGia = new DataTable();
        ViewGia.Columns.Add("Ngay", typeof(DateTime));
        ViewGia.Columns.Add("Gia", typeof(int));
        ViewGia.Columns.Add("KhuyenMai", typeof(bool));
        //Tính số ngày giữa ngày đến và ngày đi
        start = DateTime.ParseExact(dateStar.Value, "dd/MM/yyyy", null);
        end = DateTime.ParseExact(dateEnd.Value, "dd/MM/yyyy", null);
        datebook = DateTime.ParseExact(txtNgayBook.Value, "dd/MM/yyyy", null);
        TimeSpan tongDay = end - start;
        //Get giá của Listing đã chọn
        var getPrice = (from lt in db.tbListings
                        where lt.listing_id == Convert.ToInt32(ddListing.SelectedValue)
                        select new
                        {
                            lt.listing_id,
                            lt.listing_price
                        }).First();
        DateTime times = start;
        for (int i = 0; i <= tongDay.Days - 1; i++)
        {
            DataRow row = ViewGia.NewRow();
            row["Ngay"] = times.AddDays(i);
            row["Gia"] = getPrice.listing_price;
            row["KhuyenMai"] = false;
            ViewGia.Rows.Add(row);
        }
        Session["tbViewGia"] = ViewGia;

    }
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if (ddBuilding.SelectedItem.Value.ToString() == "Chọn Tòa Nhà")
        {
            alert.alert_Error(Page, "Vui lòng chọn Tòa Nhà", "");
        }
        else if (ddListing.SelectedItem.Value.ToString() == "Chọn Loại Phòng")
        {
            alert.alert_Error(Page, "Vui lòng chọn Loại Phòng", "");
        }
        else if (dateStar.Value == "" || dateEnd.Value == "" || txtNgayBook.Value == "" || txtTenKhach.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin", "");
        }
        else if (Session["IdOrder"] != null)
        {
            //Tạo DataTbale
            DataTable tbTable = new DataTable();
            tbTable.Columns.Add("codeTrading", typeof(string));
            tbTable.Columns.Add("loaiGia", typeof(string));
            //tbTable.Columns.Add("giaShow", typeof(string));
            //tbTable.Columns.Add("tenCTKM", typeof(string));
            tbTable.Columns.Add("building_id", typeof(int));
            tbTable.Columns.Add("listing_id", typeof(int));
            //tbTable.Columns.Add("giaRoom", typeof(string));
            tbTable.Columns.Add("checkin", typeof(DateTime));
            tbTable.Columns.Add("checkout", typeof(DateTime));
            tbTable.Columns.Add("tenKhach", typeof(string));
            tbTable.Columns.Add("idKhach", typeof(string));
            tbTable.Columns.Add("country", typeof(string));
            tbTable.Columns.Add("kenhBook", typeof(string));
            tbTable.Columns.Add("dateBook", typeof(DateTime));
            tbTable.Columns.Add("orderId", typeof(int));
            tbTable.Columns.Add("passport", typeof(string));
            tbTable.Columns.Add("OTATABookingID", typeof(string));
            tbTable.Columns.Add("RoomPrepaid", typeof(string));
            tbTable.Columns.Add("MatuTangGuest", typeof(string));
            DataRow row = tbTable.NewRow();
            row["codeTrading"] = txtCodeTrading.Value;
            row["loaiGia"] = txtLoaigia.Value;
            //row["giaShow"] = txtGiahienthi.Value;
            //row["tenCTKM"] = txtTCTKM.Value;
            row["building_id"] = Convert.ToInt32(ddBuilding.SelectedValue);
            row["listing_id"] = Convert.ToInt32(ddListing.SelectedValue);
            //row["giaRoom"] = txtGiaphong.Value;\
            start = DateTime.ParseExact(dateStar.Value, "dd/MM/yyyy", null);
            end = DateTime.ParseExact(dateEnd.Value, "dd/MM/yyyy", null);
            datebook = DateTime.ParseExact(txtNgayBook.Value, "dd/MM/yyyy", null);
            row["checkin"] = start;
            row["checkout"] = end;
            row["tenKhach"] = txtTenKhach.Value;
            row["idKhach"] = txtIDkhach.Value;
            row["country"] = txtQuoctich.Value;
            row["kenhBook"] = txtKenhbook.Value;
            row["dateBook"] = datebook;
            row["orderId"] = Convert.ToInt32(Session["IdOrder"].ToString());
            row["passport"] = txtSohochieu.Value;
            row["OTATABookingID"] = txtOTATABookingID.Value;
            row["RoomPrepaid"] = txtRoomPrepaid.Value;
            row["MatuTangGuest"] = "Guest-" + Matutang();
            tbTable.Rows.Add(row);
            //Lưu vào Session
            Session["tbTable"] = tbTable;
            Response.Redirect("/admin-add-edit2");

        }
        else
        {
            AddData();
            Response.Redirect("/admin-add-edit2");

        }


    }

    protected void ddBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Đổ loại phòng
        ddListing.Items.Clear();
        ddListing.Items.Insert(0, "Chọn Loại Phòng");
        ddListing.AppendDataBoundItems = true;
        var getData = from lt in db.tbListings
                      where lt.building_id == Convert.ToInt32(ddBuilding.SelectedItem.Value)
                      select lt;
        ddListing.DataSource = getData;
        ddListing.DataBind();
    }
    //public string Matutang()
    //{
    //    int year = DateTime.Now.Year;
    //    var list = from nk in db.tbOrders
    //               where nk.order_IdGuest != null
    //               select nk;
    //    string s = "";
    //    if (list.Count() <= 0)
    //        s = "00001";
    //    else
    //    {
    //        var list1 = from nk in db.tbOrders orderby nk.order_IdGuest descending select nk;
    //        string chuoi = list1.First().order_IdGuest;
    //        chuoi = chuoi.Split('-')[2];
    //        int k;
    //        k = Convert.ToInt32(chuoi.Substring(0, 5));
    //        k = k + 1;
    //        if (k < 10) s = s + "0000";
    //        else if (k < 100)
    //            s = s + "000";
    //        else if (k < 1000)
    //            s = s + "00";
    //        else if (k < 10000)
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
            s = "00001";
        else
        {
            var list1 = from nk in db.tbOrders orderby nk.order_matutangGuest descending select nk;
            string chuoi = list1.First().order_matutangGuest;
            chuoi = chuoi.Split('-')[1];
            int k;
            k = Convert.ToInt32(chuoi.Substring(0, 5));
            k = k + 1;
            if (k < 10) s = s + "0000";
            else if (k < 100)
                s = s + "000";
            else if (k < 1000)
                s = s + "00";
            else if (k < 10000)
                s = s + "0";
            s = s + k.ToString();
        }
        return s;
    }
    protected void btnDuyetIdGuest_ServerClick(object sender, EventArgs e)
    {
        string abbc;
        if (txtSohochieu.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng nhập Số Hộ Chiếu", "");
        }
        else if (ddBuilding.SelectedItem.Value.ToString() == "Chọn Tòa Nhà")
        {
            alert.alert_Error(Page, "Vui lòng chọn Tòa Nhà", "");
        }
        else
        {
            //b1: Kiểm tra số hộ chiếu của khách đã có trong csdl chưa
            var checkHC = from hc in db.tbOrders
                          where hc.order_passport == txtSohochieu.Value
                          select new
                          {
                              hc.order_id,
                              hc.order_passport,
                              hc.order_IdGuest
                          };
            if (checkHC.Count() > 0)
            {
                //b2: Nếu có rồi thì lấy ID của Khách
                var _ID = checkHC.FirstOrDefault();
                txtIDkhach.Value = _ID.order_IdGuest;
            }
            else
            {
                //Nếu chưa thì tự sinh một ID mới (mỗi Số HC là một ID)
                DateTime time = DateTime.Now;
                string thang = time.Month.ToString();
                string nam = time.Year.ToString();
                string yy = nam.Substring(nam.Length - 2, 2);
                //Bắt đầu điều kiện
                if (Convert.ToInt32(ddBuilding.SelectedValue) < 10 && Convert.ToInt32(thang) < 10)
                {
                    ddBuilding.SelectedValue = "0" + ddBuilding.SelectedValue;
                    string mm = "0" + thang;
                    abbc = yy + mm + "-" + ddBuilding.SelectedValue;
                }
                else
                if (Convert.ToInt32(thang) < 10)
                {
                    string mm = "0" + thang;
                    abbc = yy + mm + "-" + ddBuilding.SelectedValue;
                }
                else
                {
                    //Kết hợp chuỗi
                    abbc = yy + thang + "-" + ddBuilding.SelectedValue;
                }
                txtIDkhach.Value = abbc + "-" + Matutang();
                string Idkhach = abbc + "-" + Matutang();
                //Khi Khách có ID thì lưu value vào tbDiemTichLuy với thứ hạng là Member
                //Check value đã có hay chưa
                var check = from ck in db.tbDiemTichLuys
                            where ck.dtl_IdGuest == Idkhach
                            select ck;
                if (check.Count()>0)
                {

                }
                else
                {
                    tbDiemTichLuy ins = new tbDiemTichLuy();
                    ins.dtl_diemtichluy = 0;
                    ins.dtl_sumEatprice = 0;
                    ins.dtl_sumRoomprice = 0;
                    ins.dtl_IdGuest = Idkhach;
                    ins.dtl_hangGuest = "Member";
                    db.tbDiemTichLuys.InsertOnSubmit(ins);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
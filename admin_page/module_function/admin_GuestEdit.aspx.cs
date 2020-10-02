using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_GuestEdit : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            // get toàn bộ order, check xem có bảng ghi nào đã quá 7 ngày kể từ khi checkout chưa.
            var getTimeTruoc7Ngay = from t in db.tbOrders where t.order_id == Convert.ToInt32(Session["idGuest"].ToString()) && t.order_timeCheckOut.Value.AddDays(7) < DateTime.Now select t;
            // Nếu có những bài tập quá 7 ngày thì sẽ tiếp tục get trong bảng bài tập của tài khoản đó
            if (getTimeTruoc7Ngay.Count() > 0)
            {
                foreach (var item in getTimeTruoc7Ngay)
                {
                    btnLuu.Visible = true;
                }
            }
        }
    }
    protected void loadData()
    {
        var getGuest = (from guest in db.tbOrders
                        join building in db.tbBuildings on guest.building_id equals building.building_id
                        //join listing in db.tbListings on building.building_id equals listing.building_id
                        //join room in db.tbRooms on listing.listing_id equals room.listing_id
                        where guest.order_id == Convert.ToInt32(Session["idGuest"].ToString())
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
                            guest.order_lydo,
                            guest.order_amount,
                            guest.order_IdGuest,
                            guest.order_guestEmail,
                            guest.order_guestNgaySinh,
                            guest.order_diemtichluy,
                            guest.order_dukienthoigianoneuquaylai,
                            guest.building_id,
                            building.building_name,
                        }).FirstOrDefault();
        txtIdGuest.Value = getGuest.order_IdGuest;
        txtEmail.Value = getGuest.order_guestEmail;
        txtnameGuest.Value = getGuest.order_nameGuest;
        txtCountry.Value = getGuest.order_country;
        txtdateDen.Value = String.Format("{0:dd/MM/yyyy}", getGuest.order_checkin);
        txtdateDi.Value = String.Format("{0:dd/MM/yyyy}", getGuest.order_checkout);
        txtKenhbook.Value = getGuest.order_kenhBook;
        ddBuilding.DataSource = from building in db.tbBuildings where building.building_id == getGuest.building_id select building;
        ddBuilding.DataBind();
        //ddBuilding.Items.FindByText(getGuest.building_name).Selected = true;
        txtdddskd.Value = getGuest.order_diadiemdensaukhidi;
        txtddnql.Value = getGuest.order_diadiemneuquaylai;
        txtptllk.Value = getGuest.order_phuongtienlienlackhac;
        //txttttl.Value = getGuest.order_tieutientichluy;
        txtdktgonql.Value = getGuest.order_dukienthoigianoneuquaylai;
        //txtntttl.Value = getGuest.order_tieutientichluy;
        txtSoHoChieu.Value = getGuest.order_passport;
        txtNgheNghiep.Value = getGuest.order_guestNgheNghiep;
        txtKVDL.Value = getGuest.order_khuvucdialy;
        txtPhone.Value = getGuest.order_guestPhone;
        txtSoPhong.Value = getGuest.order_amount;
        txtddotkt.Value = getGuest.order_diadiemotruockhitoi;
        txtdktgql.Value = getGuest.order_dukienthoigianquaylai;
        txtgopykhachhang.Value = getGuest.order_gopykhachhang;
        txtlydo.Value = getGuest.order_lydo;
        //txtdvtttl.Value = getGuest.order_dichvutieutientichluy;
        //txtdtl.Value = getGuest.order_diemtichluy;
        txtdateSinh.Value= String.Format("{0:dd/MM/yyyy}", getGuest.order_guestNgaySinh);
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if(txtdateSinh.Value!="" && txtdateDen.Value != "" && txtdateDi.Value != "" )
        {
            var getOrder = (from order in db.tbOrders
                            where order.order_id == Convert.ToInt32(Session["idGuest"].ToString())
                            select order).FirstOrDefault();
            getOrder.order_nameGuest = txtnameGuest.Value;
            getOrder.order_country = txtCountry.Value;
            getOrder.order_kenhBook = txtKenhbook.Value;
            getOrder.order_diadiemdensaukhidi = txtdddskd.Value;
            getOrder.order_diadiemneuquaylai = txtddnql.Value;
            getOrder.order_phuongtienlienlackhac = txtptllk.Value;
            //getOrder.order_tieutientichluy = txttttl.Value;
            //getOrder.order_ngaytieutientichluy = txtntttl.Value;
            getOrder.order_passport = txtSoHoChieu.Value;
            getOrder.order_IdGuest = txtIdGuest.Value;
            getOrder.order_guestEmail = txtEmail.Value;
            getOrder.order_guestNgheNghiep = txtNgheNghiep.Value;
            getOrder.order_khuvucdialy = txtKVDL.Value;
            getOrder.order_guestPhone = txtPhone.Value;
            getOrder.order_amount = txtSoPhong.Value;
            getOrder.order_diadiemotruockhitoi = txtddotkt.Value;
            getOrder.order_dukienthoigianquaylai = txtdktgql.Value;
            getOrder.order_gopykhachhang = txtgopykhachhang.Value;
            getOrder.order_tinhcach = slTinhcach.Value;
            getOrder.order_lydo = txtlydo.Value;
            getOrder.order_dukienthoigianoneuquaylai = txtdktgonql.Value;
            //getOrder.order_dichvutieutientichluy = txtdvtttl.Value;
            //getOrder.order_diemtichluy = txtdtl.Value;
            //var getBuilding = (from building in db.tbBuildings
            //                   join order in db.tbOrders on building.building_id equals order.building_id
            //                   where order.order_id == Convert.ToInt32(Session["idGuest"].ToString())
            //                   select building).FirstOrDefault();
            getOrder.building_id = Convert.ToInt32(ddBuilding.SelectedValue);
            try
            {
                getOrder.order_checkin = Convert.ToDateTime(txtdateDen.Value);
                getOrder.order_checkout = Convert.ToDateTime(txtdateDi.Value);
                getOrder.order_guestNgaySinh = Convert.ToDateTime(txtdateSinh.Value);
                db.SubmitChanges();
                alert.alert_Success(Page,"Lưu Thành Công!!","");
            }
            catch
            {

            }
            //Response.Redirect("/admin_page/module_function/admin_GuestEdit.aspx");
        }
        else
        {
            alert.alert_Error(Page, "Lỗi!", "");
        }
    }
}
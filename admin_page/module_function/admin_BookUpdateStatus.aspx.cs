using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_BookUpdateStatus : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    DataTable tbTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();

        }
        loadDichVu();
        loadChiTiet();

    }
    protected void loadData()
    {
        var getDataa = from b in db.tbOrders
                       join bd in db.tbBuildings on b.building_id equals bd.building_id
                       orderby b.order_id descending
                       where b.order_hidden == false
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
                           bd.building_name,
                           hidden = b.order_IN == true ? "" : "display: none"
                       };
        rpShow.DataSource = getDataa;
        rpShow.DataBind();
    }
    protected void loadDichVu()
    {
        rpOrder.DataSource = from o in db.tbOrders select o;
        rpOrder.DataBind();

    }
    protected void loadChiTiet()
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
                            hidden = bk.order_IN == true ? "" : "display: none",
                            hiddenn = bk.order_IN == true ? "display: none" : ""
                        });
        rpChitiet.DataSource = getValue;
        rpChitiet.DataBind();
    }
    //Load Thông tin
    protected void loadThongTin()
    {
        var getValue = (from b in db.tbOrders
                        where b.order_id == Convert.ToInt32(txtIdCt.Value)
                        select new
                        {
                            b.order_id,
                            b.order_codeTrading
                        }).First();
        //txtcodeTrading.Value = getValue.book_codeTrading;

    }

    protected void btnCheckOut_ServerClick(object sender, EventArgs e)
    {
        if (checkCash.Checked == false && checkCard.Checked == false)
        {
            alert.alert_Warning(Page, "Vui lòng chọn phương thức thanh toán", "");
        }
        else
        {
            string _id = txtId.Value;
            string[] getId = _id.Split(',');
            foreach (var item in getId)
            {
                //var check = (from ck in db.tbOrders
                //             where ck.order_id == Convert.ToInt32(item)
                //             select ck);

                ////Tính tiền phòng của Order
                ////var getPrice = from pr in db.tbOrderDetailDatePrices
                ////               where pr.order_id == Convert.ToInt32(item)
                ////               select pr;
                ////int sumPriceRoom = 0;
                ////foreach (var priceRoom in getPrice)
                ////{
                ////    sumPriceRoom = sumPriceRoom + Convert.ToInt32(priceRoom.oddp_price);
                ////}
                ////Tính tổng tiền ăn uống
                //var getPriceeat = from tt in db.tbDichVus
                //                  where tt.order_id == Convert.ToInt32(item) && tt.dv_name == "Ăn uống"
                //                  select tt;
                //int sumPriceEat = 0;
                //foreach (var priceEat in getPriceeat)
                //{
                //    sumPriceEat = sumPriceEat + Convert.ToInt32(priceEat.dv_price);
                //}
                ////Get Mức đổi điểm
                //var getMDD = (from mdd in db.tbMucDoiDiems
                //              select mdd).FirstOrDefault();
                ////Kiểm tra
                //if (check.Count() > 0)
                //{
                //    ////Thay đổi tình trạng
                //    var update = check.FirstOrDefault();
                //    //update.order_status = "Verify-CheckOut";
                //    //db.SubmitChanges();
                //    ////End thay đổi tình trạng
                //    var checkk = from d in db.tbDiemTichLuys
                //                 where d.dtl_IdGuest == update.order_IdGuest
                //                 select d;
                //    if (checkk.Count() > 0)
                //    {
                //        //Nếu đã có thì cộng dồn vào
                //        var up = checkk.FirstOrDefault();
                //        up.dtl_sumRoomprice = up.dtl_sumRoomprice + Convert.ToInt32(update.order_totalprice);
                //        up.dtl_sumEatprice = up.dtl_sumEatprice + sumPriceEat;
                //        up.order_id = Convert.ToInt32(item);
                //        up.dtl_diemtichluy =  up.dtl_sumRoomprice / getMDD.mdd_Roomprice  + up.dtl_sumEatprice / getMDD.mdd_Eatprice;
                //        if (up.dtl_diemtichluy <= 200)
                //        {
                //            up.dtl_hangGuest = "Member";
                //        }
                //        else if (up.dtl_diemtichluy >= 200 && up.dtl_diemtichluy < 600)
                //        {
                //            up.dtl_hangGuest = "BẠC";
                //        }
                //        else if (up.dtl_diemtichluy >= 600 && up.dtl_diemtichluy < 1200)
                //        {
                //            up.dtl_hangGuest = "VÀNG";
                //        }
                //        else if (up.dtl_diemtichluy >= 1200)
                //        {
                //            up.dtl_hangGuest = "PLATINUM";
                //        }
                //        db.SubmitChanges();
                //    }
                //    else
                //    {
                //        //Lưu Tổng tiền vào bảng ghi
                //        tbDiemTichLuy ins = new tbDiemTichLuy();
                //        ins.dtl_sumRoomprice = Convert.ToInt32(update.order_totalprice);
                //        ins.dtl_sumEatprice = sumPriceEat;
                //        ins.order_id = Convert.ToInt32(item);
                //        ins.dtl_IdGuest = update.order_IdGuest;
                //        ins.dtl_diemtichluy = Convert.ToInt32(update.order_totalprice) / getMDD.mdd_Roomprice + sumPriceEat / getMDD.mdd_Eatprice;
                //        if (ins.dtl_diemtichluy <= 200)
                //        {
                //            ins.dtl_hangGuest = "Member";
                //        }else if (ins.dtl_diemtichluy >= 200 && ins.dtl_diemtichluy < 600)
                //        {
                //            ins.dtl_hangGuest = "BẠC";
                //        }
                //        else if (ins.dtl_diemtichluy >= 600 && ins.dtl_diemtichluy < 1200)
                //        {
                //            ins.dtl_hangGuest = "VÀNG";
                //        }
                //        else if (ins.dtl_diemtichluy >= 1200)
                //        {
                //            ins.dtl_hangGuest = "PLATINUM";
                //        }
                //        db.tbDiemTichLuys.InsertOnSubmit(ins);
                //        try
                //        {
                //            db.SubmitChanges();
                //        }
                //        catch
                //        {

                //        }
                //    }
                //}
            }
            loadData();
            //Tạo DaTaTable lưu Phương Thức Thanh toán:
            DataTable tbPhuongThucThanhToan = new DataTable();
            tbPhuongThucThanhToan.Columns.Add("soTien", typeof(string));
            tbPhuongThucThanhToan.Columns.Add("phiCathe", typeof(string));
            //
            DataRow row = tbPhuongThucThanhToan.NewRow();
            row["soTien"] = SoTien.Value;
            row["phiCathe"] = PhiCaThe.Value;
            tbPhuongThucThanhToan.Rows.Add(row);
            //Lưu Session tbPhuongThucThanhToan
            Session["tbPhuongThucThanhToan"] = tbPhuongThucThanhToan;
            //Session trước khi chuyển qua form admin_CheckOutPrint.aspx
            Session["_Id"] = txtId.Value;
            Response.Redirect("/admin-checkout-print");
        }
    }

    protected void btnNoShow_ServerClick(object sender, EventArgs e)
    {

        string _id = txtId.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            //Cập nhật tình trạng
            var check = from ck in db.tbOrders
                        where ck.order_id == Convert.ToInt32(item)
                        select ck;
            if (check.Count() > 0)
            {
                var update = check.FirstOrDefault();
                update.order_status = update.order_status + "-NoShow";
                //update.order_Show = true;
                db.SubmitChanges();
            }
            //Nhả phòng
            var getLockRoom = from r in db.tbLockRooms
                              where r.order_id == Convert.ToInt32(item)
                              select r;
            foreach (var room in getLockRoom)
            {
                room.lookroom_active = false;
                db.SubmitChanges();
            }
        }
        txtId.Value = "";
        loadData();

    }

    protected void btnCheckIn_ServerClick(object sender, EventArgs e)
    {
        string _id = txtId.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            var check = from ck in db.tbOrders
                        where ck.order_id == Convert.ToInt32(item)
                        select ck;
            if (check.Count() > 0)
            {
                var update = check.FirstOrDefault();
                //update.order_status = "Verified-CheckIn";
                //update.order_IN = true;
                db.SubmitChanges();
            }
        }
        loadData();
        //Session trước khi chuyển qua form Check_inInfo.aspx
        Session["_Id"] = txtId.Value;
        Response.Redirect("/admin-checkin-info");
    }
    protected void Luu_ServerClick(object sender, EventArgs e)
    {
        if (txtPrice.Value == "" || txtDate.Value == "" || txtServicecharge.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin!", "");
        }
        else
        {
            var getValue = (from b in db.tbOrders
                            where b.order_id == Convert.ToInt32(txtIdCt.Value)
                            select new
                            {
                                b.order_id,
                                b.order_codeTrading
                            }).First();
            //txtPrice.Value
            string price = txtPrice.Value;
            string[] pricee = price.Split(',');
            string PriceDichVu = "";
            foreach (var item in pricee)
            {
                PriceDichVu = PriceDichVu + item;
            }
            tbDichVu ins = new tbDichVu();
            ins.dv_name = txtDichVu.Value;
            ins.dv_thongtin = txtTTin.Value;
            ins.dv_price = Convert.ToInt32(PriceDichVu);
            ins.dv_ngay = Convert.ToDateTime(txtDate.Value);
            ins.dv_codeTrading = getValue.order_codeTrading;
            ins.order_id = getValue.order_id;
            ins.dv_Servicecharge = Convert.ToInt32(txtServicecharge.Value);
            ins.dv_total = (Convert.ToInt32(PriceDichVu) + (Convert.ToInt32(PriceDichVu) * Convert.ToInt32(txtServicecharge.Value) / 100));
            if (check.Checked)
            {
                ins.dv_paid = true;
            }
            else
            {
                ins.dv_paid = false;
            }
            db.tbDichVus.InsertOnSubmit(ins);
            try
            {
                db.SubmitChanges();
                Response.Redirect("/admin-book-update-status");
                //alert.alert_Success(Page, "Lưu Thành Công", "");
            }
            catch
            {

            }
        }

    }

    protected void btnHuy_ServerClick(object sender, EventArgs e)
    {
        string _id = txtId.Value;
        string[] getId = _id.Split(',');
        foreach (var item in getId)
        {
            //Cập nhật tình trạng
            var check = from ck in db.tbOrders
                        where ck.order_id == Convert.ToInt32(item)
                        select ck;
            if (check.Count() > 0)
            {
                var update = check.FirstOrDefault();
                update.order_status = "Cancel";
                update.order_Show = true;
                update.order_hidden = null;
                update.order_Ghichu = txtGhiChu.Value;
                db.SubmitChanges();
            }
            ////Nhả phòng
            //var getLockRoom = from r in db.tbLockRooms
            //                  where r.order_id == Convert.ToInt32(item)
            //                  select r;
            //foreach (var room in getLockRoom)
            //{
            //    room.lookroom_active = false;
            //    db.SubmitChanges();
            //}
        }
        loadData();
    }

    protected void rpOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpDichVu = e.Item.FindControl("rpDichVu") as Repeater;
        int order_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "order_id").ToString());
        string avc = txtIdCt.Value;
        var getData = from dv in db.tbDichVus
                      where dv.order_id == order_id
                      select new
                      {
                          dv.dv_id,
                          dv.dv_name,
                          dv.dv_thongtin,
                          dv.dv_ngay,
                          dv.dv_price,
                          dv.dv_codeTrading,
                          dv.order_id,
                          dv.dv_Servicecharge,
                          dv.dv_total,
                          checkedd = dv.dv_paid == true ? "checked" : ""
                      };
        rpDichVu.DataSource = getData;
        rpDichVu.DataBind();
    }
}
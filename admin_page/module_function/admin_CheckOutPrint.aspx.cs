using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_CheckOutPrint : System.Web.UI.Page
{
    DataTable tbPhuongThucThanhToan = new DataTable();
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int Stt = 3, Totalall = 0,Paybycardd=0, allBills=0, Swippingcardamountt=0, Paybycashh=0, paidd = 0, additionalroomchargee=0, totall=0, roomPrepaidd = 0, BalancePayNoww = 0, Paywhencheckinn = 0;
    public string total, additionalroomcharge, TotalallBills, roomPrepaid, Paywhencheckin, paid,Swippingcardamount, Feeofcardpayment, BalancePayNow, Paybycash, Paybycard;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnBack.Visible = false;
        //this.Page.ClientScript.GetPostBackEventReference(this, string.Empty);
        ClientScript.GetPostBackEventReference(this, "");
        if (!IsPostBack)
        {
            
        }
        loadThongTin();
        loadDichVu();
        Totaall();
        paidAll();
        loadTotal();
        BalancePay();
        loadPaybyCash();
    }
    //Balance Pay Now
    protected void BalancePay()
    {
        //Totaall();
        //loadThongTin();
        BalancePayNoww = allBills - roomPrepaidd - Paywhencheckinn - paidd;
        BalancePayNow = Convert.ToDecimal(BalancePayNoww).ToString("#,##0.###")+" đ";
    }
    //Total all Bills
    protected void Totaall()
    {
        var getValue = from tt in db.tbDichVus
                       where tt.order_id == Convert.ToInt32(Session["_Id"].ToString())
                       select new
                       {
                           tt.order_id,
                           tt.dv_total
                       };
        foreach (var item in getValue)
        {
            Totalall = Totalall + Convert.ToInt32(item.dv_total);
        }
        loadTotal();
        loadThongTin();
        allBills = Totalall + additionalroomchargee + totall;
        TotalallBills = Convert.ToDecimal(allBills).ToString("#,##0.###") + " đ";
    }
    //Paid
    protected void paidAll()
    {
        var getValue = from tt in db.tbDichVus
                       where tt.order_id == Convert.ToInt32(Session["_Id"].ToString()) && tt.dv_paid == true
                       select new
                       {
                           tt.order_id,
                           tt.dv_total
                       };
        foreach (var item in getValue)
        {
            paidd = paidd + Convert.ToInt32(item.dv_total);
        }
        paid = Convert.ToDecimal(paidd).ToString("#,##0.###") + " đ";
    }
    //Total room bill – tiền phòng
    protected void loadTotal()
    {
        var getPrice = from pr in db.tbOrders
                       where pr.order_id == Convert.ToInt32(Session["_Id"].ToString())
                       select new
                       {
                           pr.order_id,
                           pr.order_totalprice
                       };
        foreach (var item in getPrice)
        {
            //string totall = Convert.ToDecimal(total).ToString("#,##0.###"); 
            totall = Convert.ToInt32(item.order_totalprice);
            //total = totall;
        }
        total = Convert.ToDecimal(totall).ToString("#,##0.###") + " đ";
    }
    protected void loadThongTin()
    {
        var getTT = (from tt in db.tbOrders
                     join bd in db.tbBuildings on tt.building_id equals bd.building_id
                     where tt.order_id == Convert.ToInt32(Session["_Id"].ToString())
                     select new
                     {
                         tt.order_id,
                         bd.building_id,
                         bd.building_name,
                         tt.order_codeTrading,
                         tt.order_nameGuest,
                         tt.order_amount,
                         tt.order_checkin,
                         tt.order_checkout,
                         tt.order_IdGuest,
                         tt.order_kenhBook,
                         tt.order_RoomPrepaid,
                         tt.order_PaywhenCheckin,
                         tt.order_Additionalroomcharge
                     });
        rpShowCheckOut1.DataSource = getTT;
        rpShowCheckOut1.DataBind();
        foreach (var item in getTT)
        {
            roomPrepaidd = Convert.ToInt32(item.order_RoomPrepaid);
            Paywhencheckinn = Convert.ToInt32(item.order_PaywhenCheckin);
            additionalroomchargee = Convert.ToInt32(item.order_Additionalroomcharge);
        }
        additionalroomcharge = Convert.ToDecimal(additionalroomchargee).ToString("#,##0.###") + " đ";
        roomPrepaid = Convert.ToDecimal(roomPrepaidd).ToString("#,##0.###") + " đ";
        Paywhencheckin = Convert.ToDecimal(Paywhencheckinn).ToString("#,##0.###") + " đ";
    }
    protected void loadDichVu()
    {
        var getData = from dv in db.tbDichVus
                      where dv.order_id == Convert.ToInt32(Session["_Id"].ToString())
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

    protected void btnXN_ServerClick(object sender, EventArgs e)
    {
        
        var getValue = from dt in db.tbOrders
                       where dt.order_id == Convert.ToInt32(Session["_Id"].ToString())
                       select dt;
        //Tính tổng tiền ăn uống
        var getPriceeat = from tt in db.tbDichVus
                          where tt.order_id == Convert.ToInt32(Session["_Id"].ToString()) && tt.dv_name == "Ăn uống"
                          select tt;
        int sumPriceEat = 0;
        foreach (var priceEat in getPriceeat)
        {
            sumPriceEat = sumPriceEat + Convert.ToInt32(priceEat.dv_price);
        }
        //Get Mức đổi điểm
        var getMDD = (from mdd in db.tbMucDoiDiems
                      select mdd).FirstOrDefault();
        //Kiểm tra
        if (getValue.Count() > 0)
        {
            var update = getValue.FirstOrDefault();
            //Thay đổi tình trạng
            update.order_status = "Verified-CheckOut";
            update.order_timeCheckOut = DateTime.Now;
            db.SubmitChanges();
            //End thay đổi tìn trạng
            var checkk = from d in db.tbDiemTichLuys
                         where d.dtl_IdGuest == update.order_IdGuest
                         select d;
            if (checkk.Count() > 0)
            {
                //Nếu đã có thì cộng dồn vào và kiểm tra thứ hạng
                var up = checkk.FirstOrDefault();
                up.dtl_sumRoomprice = up.dtl_sumRoomprice + Convert.ToInt32(update.order_totalprice);
                up.dtl_sumEatprice = up.dtl_sumEatprice + sumPriceEat;
                up.order_id = Convert.ToInt32(Session["_Id"].ToString());
                up.dtl_diemtichluy = up.dtl_sumRoomprice / getMDD.mdd_Roomprice + up.dtl_sumEatprice / getMDD.mdd_Eatprice;
                if (up.dtl_diemtichluy <= 200)
                {
                    up.dtl_hangGuest = "Member";
                }
                else if (up.dtl_diemtichluy >= 200 && up.dtl_diemtichluy < 600)
                {
                    up.dtl_hangGuest = "BẠC";
                }
                else if (up.dtl_diemtichluy >= 600 && up.dtl_diemtichluy < 1200)
                {
                    up.dtl_hangGuest = "VÀNG";
                }
                else if (up.dtl_diemtichluy >= 1200)
                {
                    up.dtl_hangGuest = "PLATINUM";
                }
                db.SubmitChanges();
                // tạo ra nút trở lại.
                //btnIN.Visible = false;
                //btnBack.Visible = true;
            }
            else
            {
                //Lưu Tổng tiền vào bảng ghi
                tbDiemTichLuy ins = new tbDiemTichLuy();
                ins.dtl_sumRoomprice = Convert.ToInt32(update.order_totalprice);
                ins.dtl_sumEatprice = sumPriceEat;
                ins.order_id = Convert.ToInt32(Session["_Id"].ToString());
                ins.dtl_IdGuest = update.order_IdGuest;
                ins.dtl_diemtichluy = Convert.ToInt32(update.order_totalprice) / getMDD.mdd_Roomprice + sumPriceEat / getMDD.mdd_Eatprice;
                if (ins.dtl_diemtichluy <= 200)
                {
                    ins.dtl_hangGuest = "Member";
                }
                else if (ins.dtl_diemtichluy >= 200 && ins.dtl_diemtichluy < 600)
                {
                    ins.dtl_hangGuest = "BẠC";
                }
                else if (ins.dtl_diemtichluy >= 600 && ins.dtl_diemtichluy < 1200)
                {
                    ins.dtl_hangGuest = "VÀNG";
                }
                else if (ins.dtl_diemtichluy >= 1200)
                {
                    ins.dtl_hangGuest = "PLATINUM";
                }
                db.tbDiemTichLuys.InsertOnSubmit(ins);
                try
                {
                    db.SubmitChanges();
                    btnIN.Visible = false;
                    btnBack.Visible = true;
                }
                catch
                {

                }
            }
            //Nhả Phòng 
            var getLockRoom = from r in db.tbLockRooms
                              where r.order_id == Convert.ToInt32(Session["_Id"].ToString())
                              select r;
            foreach (var room in getLockRoom)
            {
                room.lookroom_active = false;
                db.SubmitChanges();
            }
        }
        
    }
    protected void loadPaybyCash()
    {
        tbPhuongThucThanhToan = (DataTable)Session["tbPhuongThucThanhToan"];
        if (Session["tbPhuongThucThanhToan"] != null)
        {
            var getData = (from r in tbPhuongThucThanhToan.AsEnumerable()
                          select new
                          {
                              soTien = r.Field<string>("soTien"),
                              phiCaThe = r.Field<string>("phiCathe")
                          }).First();
            string paycasd = "";
            string Paycashby = "";
            if (getData.soTien.Contains("."))
            {
                paycasd = getData.soTien.Replace(".", ",");
                string[] pay = paycasd.Split(',');
                foreach (var item in pay)
                {
                    Paycashby = Paycashby + item;
                }
            }
            else
            {
                paycasd = getData.soTien;
                string[] pay = paycasd.Split(',');
                foreach (var item in pay)
                {
                    Paycashby = Paycashby + item;
                }
            }
            Paybycash = getData.soTien + " đ";
            Paybycardd = BalancePayNoww - Convert.ToInt32(Paycashby);
            int phicathe = Convert.ToInt32(getData.phiCaThe);
            double phantramphicathe =(double) phicathe / (double) 100;
            int Feeofcardpaymentt = Convert.ToInt32(Paybycardd * phantramphicathe);
            Swippingcardamountt = Paybycardd + Feeofcardpaymentt;
            Paybycard = Convert.ToDecimal(Paybycardd).ToString("#,##0.###") + " đ";
            Feeofcardpayment = Convert.ToDecimal(Feeofcardpaymentt).ToString("#,##0.###") + " đ";
            Swippingcardamount = Convert.ToDecimal(Swippingcardamountt).ToString("#,##0.###") + " đ";
        }
    }
    protected void btnBack_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin-book-update-status");
    }
}
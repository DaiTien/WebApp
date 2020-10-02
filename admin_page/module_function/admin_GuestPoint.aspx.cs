using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_GuestPoint : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int tripleMoney, diemtichluy = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            loadChitiet();
            //Load Tòa Nhà
            //ddBuilding.Items.Clear();
            //ddBuilding.Items.Insert(0, "Chọn Tòa Nhà");
            //ddBuilding.AppendDataBoundItems = true;
            //ddBuilding.DataSource = from ct in db.tbBuildings select ct;
            //ddBuilding.DataBind();
        }
        if (txtIdKhach.Value != "")
        {
            //Get Tổng điểm tích lũy
            var getTongDiemTichLuy = from td in db.tbDiemTichLuys
                                      where td.dtl_IdGuest == txtIdKhach.Value
                                      select new
                                      {
                                          td.dtl_diemtichluy
                                      };
            if (getTongDiemTichLuy.Count()>0)
            {
                loadTriplemoney();
            }
        }
    }
    protected void loadTriplemoney()
    {
        //Get Tổng điểm tích lũy
        var getTongDiemTichLuy = (from td in db.tbDiemTichLuys
                                 where td.dtl_IdGuest == txtIdKhach.Value
                                 select new
                                 {
                                     td.dtl_diemtichluy
                                 }).First();
        // Get mức quy đổi
        var getMucDoiDiem = (from mdd in db.tbMucDoiDiems
                            select new
                            {
                                mdd.mdd_Triplemoney,
                            }).First();
        tripleMoney = Convert.ToInt32(getTongDiemTichLuy.dtl_diemtichluy / getMucDoiDiem.mdd_Triplemoney);
    }
    protected void loadData()
    {
        //var getData = from dt in db.tbDiemTichLuys
        //              join od in db.tbOrders on dt.dtl_IdGuest equals od.order_IdGuest
        //              join bd in db.tbBuildings on od.building_id equals bd.building_id
        //              select new
        //              {
        //                  dt.dtl_id,
        //                  dt.dtl_IdGuest,
        //                  od.order_id,
        //                  od.order_nameGuest,
        //                  od.order_country,
        //                  od.order_guestNgaySinh,
        //                  od.order_guestEmail,
        //                  od.order_guestPhone,
        //                  od.order_phuongtienlienlackhac,
        //                  od.order_guestNgheNghiep,
        //                  od.order_checkin,
        //                  od.order_checkout,
        //                  od.order_amount,
        //                  bd.building_id,
        //                  bd.building_name
        //              };
        var getData = from od in db.tbOrders
                      join bd in db.tbBuildings on od.building_id equals bd.building_id
                      select new
                      {
                          od.order_id,
                          od.order_IdGuest,
                          od.order_nameGuest,
                          od.order_country,
                          od.order_guestNgaySinh,
                          od.order_guestEmail,
                          od.order_guestPhone,
                          od.order_phuongtienlienlackhac,
                          od.order_guestNgheNghiep,
                          od.order_checkin,
                          od.order_checkout,
                          od.order_khuvucdialy,
                          od.order_amount,
                          bd.building_id,
                          bd.building_name
                      };
        rpGuestPoint.DataSource = getData;
        rpGuestPoint.DataBind();
    }
    protected void loadChitiet()
    {
        var getData = from od in db.tbOrders
                      join bd in db.tbBuildings on od.building_id equals bd.building_id
                      select new
                      {

                          od.order_id,
                          od.order_IdGuest,
                          od.order_nameGuest,
                          od.order_passport,
                          od.order_country,
                          od.order_khuvucdialy,
                          od.order_guestNgaySinh,
                          od.order_guestEmail,
                          od.order_guestPhone,
                          od.order_phuongtienlienlackhac,
                          od.order_guestNgheNghiep,
                          od.order_checkin,
                          od.order_checkout,
                          od.order_kenhBook,
                          od.order_diadiemotruockhitoi,
                          od.order_diadiemdensaukhidi,
                          od.order_dukienthoigianquaylai,
                          od.order_diadiemneuquaylai,
                          od.order_dukienthoigianoneuquaylai,
                          od.order_gopykhachhang,
                          od.order_amount,
                          bd.building_id,
                          bd.building_name
                      };
        rpViewChiTiet.DataSource = getData;
        rpViewChiTiet.DataBind();
    }

    protected void btnTimKiem_ServerClick(object sender, EventArgs e)
    {
        //Get mức đổi điểm
        var getM = (from m in db.tbMucDoiDiems
                    select m).First();
        //Get điểm tích lũy
        var getDt = from dt in db.tbDiemTichLuys
                    where dt.dtl_IdGuest == txtIdKhach.Value
                    select dt;
        if (getDt.Count() > 0)
        {
            var get = getDt.FirstOrDefault();
            txtDiemtichluy.Value = get.dtl_diemtichluy + "";
            //tripleMoney = Convert.ToInt32(get.dtl_diemtichluy / getM.mdd_Triplemoney);
        }
        else if (txtIdKhach.Value != "")
        {
            alert.alert_Success(Page, "Khách chưa có điểm tích lũy", "");
            txtDiemtichluy.Value = "";
            //tripleMoney = 0;
        }
        if (txtIdKhach.Value != "")
        {
            var getData = from od in db.tbOrders
                          where od.order_IdGuest == txtIdKhach.Value
                          join bd in db.tbBuildings on od.building_id equals bd.building_id
                          select new
                          {
                              od.order_id,
                              od.order_IdGuest,
                              od.order_nameGuest,
                              od.order_country,
                              od.order_guestNgaySinh,
                              od.order_guestEmail,
                              od.order_guestPhone,
                              od.order_phuongtienlienlackhac,
                              od.order_guestNgheNghiep,
                              od.order_checkin,
                              od.order_checkout,
                              od.order_khuvucdialy,
                              od.order_amount,
                              bd.building_id,
                              bd.building_name
                          };
            rpGuestPoint.DataSource = getData;
            rpGuestPoint.DataBind();
        }
        else
        {
            loadData();
        }

    }
}
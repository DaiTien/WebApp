using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_BookList : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    DataTable tbTableBook;
    string tinhtrang;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
        }
        loadData();
        //loadEdit();
    }
    protected void loadData()
    {
        var getData = from od in db.tbOrders
                      join bd in db.tbBuildings on od.building_id equals bd.building_id
                      orderby od.order_id descending
                      where od.order_hidden == true
                      select new
                      {
                          od.order_id,
                          od.order_name,
                          od.order_checkin,
                          od.order_checkout,
                          od.order_codeTrading,
                          od.order_dateBook,
                          od.order_amount,
                          od.order_nameGuest,
                          od.order_country,
                          od.order_IdGuest,
                          od.order_status,
                          od.order_Ghichu,
                          bd.building_id,
                          bd.building_name
                      };
        rpOrder.DataSource = getData;
        rpOrder.DataBind();
    }
    //protected void loadEdit()
    //{
    //    var getData = from od in db.tbOrders
    //                  join bd in db.tbBuildings on od.building_id equals bd.building_id
    //                  select new
    //                  {
    //                      od.order_id,
    //                      //od.order_name,
    //                      //od.order_checkin,
    //                      //od.order_checkout,
    //                      od.order_codeTrading,
    //                      //od.order_dateBook,
    //                      //od.order_amount,
    //                      od.order_nameGuest,
    //                      od.order_country,
    //                      od.order_IdGuest,
    //                      bd.building_id,
    //                      bd.building_name
    //                  };
    //    rpEdit.DataSource = getData;
    //    rpEdit.DataBind();
    //}
    protected void btnAct_ServerClick(object sender, EventArgs e)
    {
        //var getData = (from od in db.tbOrders where od.order_id == Convert.ToInt32(txtId.Value) select od).FirstOrDefault();
        //if (tbTableBook == null)
        //{
        //    //Tạo tb lưu dữ liệu
        //    tbTableBook = new DataTable();
        //    tbTableBook.Columns.Add(new DataColumn("order_checkin", typeof(DateTime)));
        //    tbTableBook.Columns.Add(new DataColumn("order_checkout", typeof(DateTime)));
        //    tbTableBook.Columns.Add(new DataColumn("building_id", typeof(int)));
        //    tbTableBook.Columns.Add(new DataColumn("order_id", typeof(int)));
        //    tbTableBook.Columns.Add(new DataColumn("order_nameGuest", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_IdGuest", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_country", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_dateBook", typeof(DateTime)));
        //    tbTableBook.Columns.Add(new DataColumn("order_codeTrading", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_email", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_amount", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_phone", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_priceShow", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_loaiGia", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_priceRoom", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_kenhBook", typeof(string)));
        //    tbTableBook.Columns.Add(new DataColumn("order_nameCTKM", typeof(string)));

        //    //
        //    DataRow row = tbTableBook.NewRow();
        //    row["order_checkin"] = getData.order_checkin;
        //    row["order_checkout"] = getData.order_checkout;
        //    row["building_id"] = getData.building_id;
        //    row["order_id"] = getData.order_id;
        //    row["order_nameGuest"] = getData.order_nameGuest;
        //    row["order_IdGuest"] = getData.order_IdGuest;
        //    row["order_country"] = getData.order_country;
        //    row["order_dateBook"] = getData.order_dateBook;
        //    row["order_codeTrading"] = getData.order_codeTrading;
        //    row["order_email"] = getData.order_email;
        //    row["order_amount"] = getData.order_amount;
        //    row["order_phone"] = getData.order_phone;
        //    row["order_priceShow"] = getData.order_priceShow;
        //    row["order_loaiGia"] = getData.order_loaiGia;
        //    row["order_priceRoom"] = getData.order_priceRoom;
        //    row["order_kenhBook"] = getData.order_kenhBook;
        //    row["order_nameCTKM"] = getData.order_nameCTKM;
        //    //row["room_active"] = item_Room.room_active;
        //    tbTableBook.Rows.Add(row);
        //    //Lưu Session
        //    Session["tbTableBook"] = tbTableBook;
        //}
        tinhtrang = "Edit";
        Session["TinhTrang"] = tinhtrang.ToString();
        Session["IdOrder"] = txtId.Value;
        Response.Redirect("/admin-add-edit1");
    }


    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        tinhtrang = "Thêm";
        Session["TinhTrang"] = tinhtrang.ToString();
        Session["IdOrder"] = null;
        Response.Redirect("/admin-add-edit1");
    }
}
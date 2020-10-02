using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_AdminExchange : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    protected void loadData()
    {
        var getData = from dt in db.tbMucDoiDiems
                      select dt;
        rpMucDoiDiem.DataSource = getData;
        rpMucDoiDiem.DataBind();
    }
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        //Kiểm tra dữ liệu
        if (txtPriceRoom.Value == "" || txtPriceEat.Value == "" || txtTripleMoney2.Value == "")
        {
            alert.alert_Error(Page,"Chưa nhập đầy đủ thông tin","");
        }
        else
        {
            var check = from dt in db.tbMucDoiDiems
                        select dt;
            if (check.Count() > 0)
            {
                //Nếu có thì chỉ cần update
                var update = check.First();
                update.mdd_Roomprice = Convert.ToInt32(txtPriceRoom.Value);
                update.mdd_Eatprice = Convert.ToInt32(txtPriceEat.Value);
                update.mdd_Triplemoney = Convert.ToInt32(txtTripleMoney2.Value);
                try
                {
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Lưu Thành Công", "");
                }
                catch
                {

                }
            }
            else
            {
                //Nếu chưa thì ins vào bảng ghi
                tbMucDoiDiem ins = new tbMucDoiDiem();
                ins.mdd_Roomprice = Convert.ToInt32(txtPriceRoom.Value);
                ins.mdd_Eatprice = Convert.ToInt32(txtPriceEat.Value);
                ins.mdd_Triplemoney = Convert.ToInt32(txtTripleMoney2.Value);
                db.tbMucDoiDiems.InsertOnSubmit(ins);
                try
                {
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Lưu Thành Công", "");
                }
                catch
                {

                }
            }
        }
    }
}
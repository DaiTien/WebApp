using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_CheckinInfo : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if (Session["_Id"] != null)
        {
            //get bảng ghi trên bảng Order
            var getOrder = from od in db.tbOrders
                     where od.order_id == Convert.ToInt32(Session["_Id"].ToString())
                     select od;
            //txtAdditionalroomcharge.Value
            string Additional = txtAdditionalroomcharge.Value;
            string[] Additionalroom = Additional.Split(',');
            string Additionalroomcharge = "";
            foreach (var item in Additionalroom)
            {
                Additionalroomcharge = Additionalroomcharge + item;
            }
            //txtPaywhenCheckin
            string Paywhen = txtPaywhenCheckin.Value;
            string[] txtPaywhen = Paywhen.Split(',');
            string PaywhenCheckin = "";
            foreach (var item in txtPaywhen)
            {
                PaywhenCheckin = PaywhenCheckin + item;
            }
            //thực hiện ins/update vào bảng ghi
            if (getOrder.Count() > 0)
            {
                var update = getOrder.FirstOrDefault();
                update.order_NumberofAdult = Convert.ToInt32(txtNumberofAdult.Value);
                update.order_NumberofU712Child = Convert.ToInt32(txtNumberofU712Child.Value);
                update.order_SpecialRequest = txtSpecialRequest.Value;
                update.order_Additionalroomcharge = Convert.ToInt32(Additionalroomcharge);
                update.order_Extrabed = txtExtrabed.Value;
                update.order_PaywhenCheckin = Convert.ToInt32(PaywhenCheckin);
                update.order_CollectAccount = slCollectAccount.Value;
                update.order_Collectionforspecialrequest = txtCollectionforspecialrequest.Value;
                try
                {
                    db.SubmitChanges();
                    alert.alert_Update(Page,"Lưu Thành Công!","");
                }
                catch
                {

                }
            }
        }
        Response.Redirect("/admin-checkin-print");
    }
}
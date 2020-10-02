using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_ChangePassword : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_ChangerPass_ServerClick(object sender, EventArgs e)
    {
        admin_User getusername = Session["AdminLogined"] as admin_User;
        cls_security md5 = new cls_security();
        string passmd5 = md5.HashCode(txtMKcu.Value);
        var checkTaiKhoan = (from tk in db.admin_Users where tk.username_id == getusername.username_id select tk).FirstOrDefault();
        if (checkTaiKhoan.username_password != passmd5)
        {
            alert.alert_Error(Page, "Mật khẩu cũ nhập không đúng!", "");

        }
        else if (checkTaiKhoan.username_password == passmd5)
        {
            if (txtMKmoi.Value == "" || txtXacnhanMk.Value == "")
            {
                alert.alert_Error(Page, "Bạn chưa nhập mật khẩu mới!", "");
            }
            else if (txtMKmoi.Value != txtXacnhanMk.Value)
            {
                alert.alert_Error(Page, "Mật khẩu nhập không khớp!", "");
            }
            else
            {
                var update = (from tk in db.admin_Users where tk.username_id == getusername.username_id select tk).FirstOrDefault();
                update.username_password = md5.HashCode(txtXacnhanMk.Value);
                db.SubmitChanges();
                alert.alert_Success(Page, "Mật khẩu đã được thay đổi!", "");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_Profile : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public string chucvu;
    protected void Page_Load(object sender, EventArgs e)
    {
        //var listUser = (admin_User);
        admin_User getusername = Session["AdminLogined"] as admin_User;
        var checkchucvu = (from checkcuser in db.admin_Users
                           join checkcv in db.admin_GroupUsers on checkcuser.groupuser_id equals checkcv.groupuser_id
                           where checkcuser.username_id == getusername.username_id
                           select checkcv);
        chucvu = (checkchucvu.SingleOrDefault().groupuser_name).ToString();
        Loaddata();
    }
    protected void Loaddata()
    {
        admin_User getusername = Session["AdminLogined"] as admin_User;
        var listUsser = (from checkcuser in db.admin_Users
                         where checkcuser.username_id == getusername.username_id
                         select checkcuser);
        rp_Profile.DataSource = listUsser;
        rp_Profile.DataBind();
    }
    private bool isEmail(string txtEmail)
    {
        Regex re = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
        return re.IsMatch(txtEmail);
    }
    protected void btnChanger_ServerClick(object sender, EventArgs e)
    {
        admin_User getusername = Session["AdminLogined"] as admin_User;
        var checkchucvu = (from checkcuser in db.admin_Users
                           where checkcuser.username_id == getusername.username_id
                           select checkcuser).FirstOrDefault();
        if (txt_Email.Value != checkchucvu.username_email || txt_Mobile.Value != checkchucvu.username_phone || txt_Profile.Value != checkchucvu.username_fullname)
        {
            if (txt_Profile.Value != checkchucvu.username_fullname)
            {
                checkchucvu.username_fullname = txt_Profile.Value;
                alert.alert_Success(Page, "Thay Đổi Thành Công", "");
                db.SubmitChanges();
            }
            else if (txt_Mobile.Value != checkchucvu.username_phone)
            {
                checkchucvu.username_phone = txt_Mobile.Value;
                alert.alert_Success(Page, "Thay Đổi Thành Công", "");
                db.SubmitChanges();
            }
            else if (txt_Email.Value != checkchucvu.username_email)
            {
                if (isEmail(txt_Email.Value) == true)
                {
                    checkchucvu.username_email = txt_Email.Value;
                    alert.alert_Success(Page, "Thay Đổi Thành Công", "");
                    db.SubmitChanges();
                }
                else
                {
                    alert.alert_Error(Page, "Vui Lòng Kiểm Tra Lại Email Của Bạn", "");
                }
            }

        }
        else
        {
            alert.alert_Error(Page, "Vui Lòng nhập thông tin để thay đổi", "");
        }
        Loaddata();
    }
}
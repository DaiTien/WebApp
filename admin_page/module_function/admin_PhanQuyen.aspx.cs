using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_admin_PhanQuyen : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlBophan.Items.Clear();
            ddlBophan.Items.Insert(0, "Chọn Bộ Phận");
            ddlBophan.AppendDataBoundItems = true;
            ddlBophan.DataSource = from bp in db.admin_GroupUsers
                                   where bp.groupuser_id != 1 && bp.groupuser_id != 2
                                   select bp;
            ddlBophan.DataBind();
            //Load USer
            loadUser();
        }
    }
    protected void loadUser()
    {
        var getUser = from us in db.admin_Users
                      join gr in db.admin_GroupUsers on us.groupuser_id equals gr.groupuser_id
                      where us.username_id != 1 && us.username_id != 2
                      select new
                      {
                          us.username_id,
                          us.username_username,
                          us.username_password,
                          gr.groupuser_id,
                          gr.groupuser_name
                      };
        rpUser.DataSource = getUser;
        rpUser.DataBind();
    }
    public bool checknull()
    {
        if (txttenVN.Text != "" && txtAccount.Text != "" && txtPass.Text != "" && txtPhone.Text != "")
            return true;
        else return false;
    }
    //Kiểm tra Email
    private bool isEmail(string txtEmail)
    {
        Regex re = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
        return re.IsMatch(txtEmail);
    }
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "MyFunc()", true);
        //Mã hóa mật khẩu MD5
        cls_security md5 = new cls_security();
        string passWord = txtPass.Text.Trim();
        string passmd5 = md5.HashCode(txtPass.Text);
        //Kiểm tra Email vs Phone có trong CSDL chưa
        var checkemailphone = from check in db.admin_Users where check.username_phone == txtPhone.Text select check;
        //Run
        if (checknull() == false)
        {
            alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin", "");
        }
        else if (txtEmail.Text == "")
        {
            alert.alert_Error(Page, "Vui lòng nhập Email", "");
        }
        else if (isEmail(txtEmail.Text) != true)
        {
            alert.alert_Error(Page, "Vui Lòng Kiểm tra lại mail của bạn", "");
        }
        else if (checkemailphone.Count() > 0)
        {
            alert.alert_Error(Page, "Số điện thoại đã tồn tại!, Vui lòng kiểm tra lại", "");
        }
        else
        {
            admin_User ins = new admin_User();
            ins.username_active = true;
            ins.username_email = txtEmail.Text;
            ins.username_fullname = txttenVN.Text;
            ins.username_username = txtAccount.Text;
            ins.username_phone = txtPhone.Text;
            ins.username_password = passmd5;
            if (slGioitinh.Value == "0")
            {
                ins.username_gender = false;
            }
            else
            {
                ins.username_gender = true;
            }
            ins.groupuser_id = Convert.ToInt32(ddlBophan.SelectedValue);
            db.admin_Users.InsertOnSubmit(ins);
            try
            {
                db.SubmitChanges();
                alert.alert_Success(Page, "Thêm Thành Công!", "");
                loadUser();
            }
            catch
            {

            }
        }

    }
    protected void btnXoa_ServerClick1(object sender, EventArgs e)
    {
        cls_DeleteUser del;
        var getValue = from dt in db.admin_Users
                       where dt.username_id == Convert.ToInt32(txtId.Value)
                       select new
                       {
                           dt.username_id,
                       };
        foreach (var item in getValue)
        {
            del = new cls_DeleteUser();
            if (del.Linq_Xoa(item.username_id))
            {
                alert.alert_Success(Page, "Xóa Thành Công", "");
                loadUser();
            }
        }
    }
    protected void btnDoiMatKhau_ServerClick(object sender, EventArgs e)
    {
        //cls_security md5 = new cls_security();
        ////string passmd5 = md5.HashCode(txtMKcu.Value);
        //var checkTaiKhoan = (from tk in db.admin_Users where tk.username_id == Convert.ToInt32(txtId.Value) select tk).FirstOrDefault();
        //if (checkTaiKhoan.username_password != passmd5)
        //{
        //    alert.alert_Error(Page, "Mật khẩu cũ nhập không đúng!", "");

        //}
        //else if (checkTaiKhoan.username_password == passmd5)
        //{
        //    if (txtMKmoi.Value == "" || txtXacnhanMk.Value == "")
        //    {
        //        alert.alert_Error(Page, "Bạn chưa nhập mật khẩu mới!", "");
        //    }
        //    else if (txtMKmoi.Value != txtXacnhanMk.Value)
        //    {
        //        alert.alert_Error(Page, "Mật khẩu nhập không khớp!", "");
        //    }
        //    else
        //    {
        //        var update = (from tk in db.admin_Users where tk.username_id == Convert.ToInt32(txtId.Value) select tk).FirstOrDefault();
        //        update.username_password = md5.HashCode(txtXacnhanMk.Value);
        //        update.username_email = txtEmail.Text;
        //        db.SubmitChanges();

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Mật khẩu đã được thay đổi!', '','success').then(function(){window.location = '/admin-login';})", true);
        //    }
        //}
        cls_security md5 = new cls_security();
        int numIterations = 12345;
        admin_User update = (from u in db.admin_Users where u.username_id == Convert.ToInt32(txtId.Value) select u).SingleOrDefault();
        update.username_password = md5.HashCode(numIterations.ToString());
        //update.username_password = "12378248145104161527610811213823414203124130";
        db.SubmitChanges();
        var fromAddress = "tinnhankhachhang@gmail.com";//  tinnhankhachhang@gmail.com
                                                       // pass : abc123#!
        var toAddress = update.username_email; // 
        const string fromPassword = "jcstiaveptusqrxm";//Password of your Email address jcstiaveptusqrxm
        string subject = "Mật khẩu mới của admin";
        string body = "Mật khẩu mới để vào lại website quản trị : " + numIterations.ToString();
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        smtp.Send(fromAddress, toAddress, subject, body);
        //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Vui lòng check mail để xác nhận mật khẩu mới!', '','success').then(function(){window.location = '/admin-login';})", true);
        alert.alert_Success(Page, "Mật Khẩu đã gửi tới Gmail của Nhân Viên!", "");
    }
}
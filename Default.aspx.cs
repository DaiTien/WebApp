﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            Response.Redirect("/Admin_Default.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                txtUser.Value = Request.Cookies["UserName"].Value;
            }
        }
    }
    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        cls_security md5 = new cls_security();
        string passmd5 = md5.HashCode(txtPassword.Value);
        string userName = txtUser.Value.Trim();
        var viewUserName = from tb in db.admin_Users
                           where tb.username_username == userName.ToLower()
                           && tb.username_password == passmd5
                           && tb.username_active == true
                           select tb;
        if (viewUserName.Count() > 0)
        {
            admin_User list = viewUserName.Single();
            Session["AdminLogined"] = list;

            if (remember.Checked)
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(15);
            else
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserName"].Value = txtUser.Value.Trim();

            Response.Redirect("/admin-home");
        }
        else
        {
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Sai tên đăng nhập / mật khẩu!', '','warning')", true);
            alert.alert_Error(Page, "Sai tên đăng nhập / mật khẩu!", "");
        }
    }
}
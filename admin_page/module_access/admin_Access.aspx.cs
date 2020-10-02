using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_Access : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        loadGroupUser();
        loadUser();
        check123();
        //btnLuF.Visible = false;
    }
    private void check123()
    {
        if (txtDanhSachChecked.Value == "")
        {
            int _idGUser = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
            var checkedd = from ck1 in db.admin_Modules
                           select new
                           {
                               ck1.module_id,
                               ck1.module_name,
                               check123 = (from um in db.admin_AccessGroupUserModules
                                           where um.gum_active == true && um.groupuser_id == _idGUser
                                           && um.module_id == ck1.module_id
                                           select um).Count() > 0 ? "checked" : ""
                           };
            rptModule.DataSource = checkedd;
            rptModule.DataBind();
        }
        else
        {
            var list = from a in db.admin_Modules
                       select new
                       {
                           a.module_id,
                           a.module_name,
                           a.module_position,
                           check123 = ""
                       };
            var list2 = from u in list.AsEnumerable()
                        select new
                        {
                            u.module_id,
                            u.module_name,
                            amenities_name = u.module_name,
                            check123 = txtDanhSachChecked.Value.Contains(u.module_id.ToString()) ? "checked" : "",
                        };
            rptModule.DataSource = list2;
            rptModule.DataBind();
        }
    }
    private void loadGroupUser()
    {
        admin_User logedMember = Session["AdminLogined"] as admin_User;
        var getData = from tb in db.admin_GroupUsers
                      select tb;
        grvGUser.DataSource = getData;
        grvGUser.DataBind();
    }
    private void loadUser()
    {
        id = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        var getData = from tb in db.admin_Users
                      where tb.groupuser_id == id
                      select tb;
        rpUser.DataSource = getData;
        rpUser.DataBind();
        //loadUserForm();
    }
    

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        var getData = from tb in db.admin_Users
                      where tb.groupuser_id == id
                      select tb;
        rpUser.DataSource = getData;
        rpUser.DataBind();
        rptForm.DataSource = "";
        rptForm.DataBind();
        btnLuF.Visible = false;
        //loadUserForm();
    }
    protected void btnLuuM_Click(object sender, EventArgs e)
    {
        int _idGUser = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        //Lấy idModule
        string checkid = txtDanhSachChecked.Value;
        string[] getcheckid = checkid.Split(',');
        foreach (var item in getcheckid)
        {
            var checkGUM = from tb in db.admin_AccessGroupUserModules
                           where tb.groupuser_id == _idGUser
                           && tb.module_id == Convert.ToInt32(item)
                           select tb;
            if (checkGUM.Count() > 0)
            {
                admin_AccessGroupUserModule update = checkGUM.FirstOrDefault();
                if (update.gum_active == true)
                    update.gum_active = false;
                else
                    update.gum_active = true;
            }
            else
            {
                admin_AccessGroupUserModule insert = new admin_AccessGroupUserModule();
                insert.groupuser_id = _idGUser;
                insert.module_id = Convert.ToInt32(item);
                insert.gum_active = true;
                db.admin_AccessGroupUserModules.InsertOnSubmit(insert);
            }
            try
            {
                db.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){rptModule.Refresh();})", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thất bại','','error')", true);
            }
        }
        txtDanhSachChecked.Value = "";
        txtCountChecked.Value = "0";
    }

    protected void btnLuF_Click(object sender, EventArgs e)
    {
        int _idGUser = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        //int _idUser = Convert.ToInt32(grvUser.GetRowValues(grvUser.FocusedRowIndex, new string[] { "username_id" }));
        //Lấy idForm
        string checkidF = txtId.Value;
        string[] getcheckid = checkidF.Split(',');
        foreach (var item in getcheckid)
        {
            var checkGUF = from tb in db.admin_AccessGroupUserForms
                           where tb.groupuser_id == _idGUser
                           && tb.form_id == Convert.ToInt32(item)
                           select tb;
            if (checkGUF.Count() > 0)
            {
                admin_AccessGroupUserForm update = checkGUF.FirstOrDefault();
                if (update.guf_active == true)
                    update.guf_active = false;
                else
                    update.guf_active = true;
            }
            else
            {
                admin_AccessGroupUserForm insert = new admin_AccessGroupUserForm();
                insert.groupuser_id = _idGUser;
                insert.form_id = Convert.ToInt32(item);
                insert.guf_active = true;
                db.admin_AccessGroupUserForms.InsertOnSubmit(insert);
            }
            try
            {
                db.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvForm.Refresh();grvUserForm.Refresh();})", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thất bại','','error')", true);
            }
            string checkidUser = txtIdUser.Value;
            string[] getcheckidU = checkidUser.Split(',');
            //Insert value vào admin_AccessUserForm
            foreach (var _idUser in getcheckidU)
            {
                var checkUF = from tb in db.admin_AccessUserForms
                              where tb.username_id == Convert.ToInt32(_idUser)
                               && tb.form_id == Convert.ToInt32(item)
                              select tb;
                if (checkUF.Count() > 0)
                {
                    admin_AccessUserForm update = checkUF.FirstOrDefault();
                    if (update.uf_active == true)
                        update.uf_active = false;
                    else
                        update.uf_active = true;
                }
                else
                {
                    admin_AccessUserForm insert = new admin_AccessUserForm();
                    insert.username_id = Convert.ToInt32(_idUser);
                    insert.form_id = Convert.ToInt32(item);
                    insert.uf_active = true;
                    db.admin_AccessUserForms.InsertOnSubmit(insert);
                }
                try
                {
                    db.SubmitChanges();
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvUserForm.Refresh();})", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thất bại','','error')", true);
                }
            }
            
        }
        txtId.Value = "";
        txtCountId.Value = "0";
        //txtIdUser.Value = "";
        //txtCountIdUser.Value = "0";
        //btnLuF.Visible = true;

    }

    //Load Form lên List Form
    protected void btnForm_ServerClick(object sender, EventArgs e)
    {
        int _idGUser = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        var getData = from tb in db.admin_Forms
                      join md in db.admin_Modules on tb.module_id equals md.module_id
                      where md.module_id == Convert.ToInt32(IdModule.Value)
                      select new
                      {
                          md.module_id,
                          tb.form_id,
                          tb.form_name,
                          check123 = (from guf in db.admin_AccessGroupUserForms
                                      where guf.groupuser_id == _idGUser
                                      && guf.form_id == tb.form_id
                                      && guf.guf_active == true
                                      select guf).Count() > 0 ? "checked" : ""
                          //check123 = ""
                      };
        rptForm.DataSource = getData;
        rptForm.DataBind();
        btnLuF.Visible = true;
    }

    protected void btnCT_Click(object sender, EventArgs e)
    {

    }

    protected void btnUser_ServerClick(object sender, EventArgs e)
    {
        int _idGUser = Convert.ToInt32(grvGUser.GetRowValues(grvGUser.FocusedRowIndex, new string[] { "groupuser_id" }));
        var getData = from tb in db.admin_Forms
                      join md in db.admin_Modules on tb.module_id equals md.module_id
                      where md.module_id == Convert.ToInt32(IdModule.Value)
                      select new
                      {
                          md.module_id,
                          tb.form_id,
                          tb.form_name,
                          check123 = (from guf in db.admin_AccessGroupUserForms
                                      where guf.groupuser_id == _idGUser
                                      && guf.form_id == tb.form_id
                                      && guf.guf_active == true
                                      select guf).Count() > 0 ? "checked" : ""
                          //check123 = ""
                      };
        rptForm.DataSource = getData;
        rptForm.DataBind();
    }
}
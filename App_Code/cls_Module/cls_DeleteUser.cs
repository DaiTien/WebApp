using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_DeleteUser
/// </summary>
public class cls_DeleteUser
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_DeleteUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Xoa(int username_id)
    {
        admin_User delete = db.admin_Users.Where(x => x.username_id == username_id).FirstOrDefault();
        db.admin_Users.DeleteOnSubmit(delete);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
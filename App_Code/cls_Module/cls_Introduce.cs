using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_Introduce
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Introduce()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string introduce_title, string introduce_title1, string introduce_content, string image)
    {
        tbIntroduce insert = new tbIntroduce();
        insert.introduce_title = introduce_title;
        //insert.introduce_title1 = introduce_title1;
        insert.introduce_content = introduce_content;
        insert.introduce_active = false;
        if (image != "" || image != null)
            insert.inrtroduce_image = image;
        insert.inrtroduce_date = DateTime.Now;
        db.tbIntroduces.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int introduce_id, string introduce_title, string introduce_title1, string introduce_content, string image)
    {

        tbIntroduce update = db.tbIntroduces.Where(x => x.introduct_id == introduce_id).FirstOrDefault();
        update.introduce_title = introduce_title;
        //update.introduce_title1 = introduce_title1;
        update.introduce_content = introduce_content;
        if (image != null)
            update.inrtroduce_image = image;
        //update.introduce_dateup = DateTime.Now;
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
    public bool Linq_Xoa(int introduce_id)
    {
        tbIntroduce delete = db.tbIntroduces.Where(x => x.introduct_id == introduce_id).FirstOrDefault();
        db.tbIntroduces.DeleteOnSubmit(delete);
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
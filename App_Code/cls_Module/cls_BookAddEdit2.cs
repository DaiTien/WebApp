using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_BookAddEdit2
/// </summary>
public class cls_BookAddEdit2
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_BookAddEdit2()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string maGD, string loaiGia, string giaShow, string nameCTKM, int building, string priceRoom, DateTime checkin, DateTime checkout, string nameGuest,string IdGuest,string nationality, string Kenh,DateTime dateBook,string soPhong, string passPort, string listingName, string OAT, int roomPrepaid,int totalPrice,string matutang, string matutangGuest)
    {
        tbOrder ins = new tbOrder();
        ins.order_codeTrading = maGD;
        ins.order_loaiGia = loaiGia;
        ins.order_priceShow = giaShow;
        ins.order_nameCTKM = nameCTKM;
        ins.building_id = building;
        ins.order_priceRoom = priceRoom;
        ins.order_checkin = checkin;
        ins.order_checkout = checkout;
        ins.order_nameGuest = nameGuest;
        ins.order_IdGuest = IdGuest;
        ins.order_country = nationality;
        ins.order_kenhBook = Kenh;
        ins.order_dateBook = dateBook;
        ins.order_amount = soPhong;
        ins.order_hidden = true;
        ins.order_Show = true;
        ins.order_status = "Unverified";
        ins.order_passport = passPort;
        ins.listring_name = listingName;
        ins.order_OTATABookingID = OAT;
        ins.order_RoomPrepaid = roomPrepaid;
        ins.order_totalprice = Convert.ToString(totalPrice);
        ins.order_matutangbook ="Book-"+ matutang;
        ins.order_matutangGuest = matutangGuest;
        db.tbOrders.InsertOnSubmit(ins);
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
    public bool Linq_Sua(int order_id, string maGD, string loaiGia, string giaShow, string nameCTKM, int building, string priceRoom, DateTime checkin, DateTime checkout, string nameGuest, string IdGuest, string nationality, string Kenh, DateTime dateBook, string soPhong, string passPort, string listingName, string OAT, int roomPrepaid, int totalPrice, string matutang, string matutangGuest)
    {

        tbOrder ins = db.tbOrders.Where(x => x.order_id == order_id).FirstOrDefault();
        ins.order_codeTrading = maGD;
        ins.order_loaiGia = loaiGia;
        ins.order_priceShow = giaShow;
        ins.order_nameCTKM = nameCTKM;
        ins.building_id = building;
        ins.order_priceRoom = priceRoom;
        ins.order_checkin = checkin;
        ins.order_checkout = checkout;
        ins.order_nameGuest = nameGuest;
        ins.order_IdGuest = IdGuest;
        ins.order_country = nationality;
        ins.order_kenhBook = Kenh;
        ins.order_dateBook = dateBook;
        ins.order_amount = soPhong;
        ins.order_hidden = true;
        ins.order_Show = true;
        ins.order_passport = passPort;
        ins.listring_name = listingName;
        ins.order_OTATABookingID = OAT;
        ins.order_RoomPrepaid = roomPrepaid;
        ins.order_status = "Unverified";
        ins.order_matutangbook = "Book-" + matutang;
        ins.order_matutangGuest = matutangGuest;
        ins.order_totalprice = Convert.ToString(totalPrice);
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
    //public bool Linq_Xoa(int giaovien_id)
    //{
    //    admin_User delete1 = db.admin_Users.Where(x => x.username_id == giaovien_id).FirstOrDefault();
    //    db.admin_Users.DeleteOnSubmit(delete1);
    //    try
    //    {
    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
}
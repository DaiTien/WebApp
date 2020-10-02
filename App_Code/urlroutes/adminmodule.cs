using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
	public adminmodule()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Module SEO
        list.Add("moduleseo|admin-seo|~/admin_page/module_function/module_SEO.aspx");
        //Module Language
        list.Add("modulelanguage|admin-ngon-ngu|~/admin_page/module_function/admin_LanguagePage.aspx");
        //list.Add("moduleaccount|admin-accounths|~/admin_page/module_function/module_Account.aspx");
        //Quản lý website
        list.Add("moduleintroduce|admin-introduce|~/admin_page/module_function/module_Introduce.aspx");
        list.Add("moduleslide|admin-slide|~/admin_page/module_function/module_Slide.aspx");
        list.Add("modulegioithieu|admin-gioi-thieu|~/admin_page/module_function/module_GioiThieu.aspx");
        //Quản lý sản phẩm
        list.Add("moduleproduct|admin-product|~/admin_page/module_function/module_Product.aspx");
        list.Add("moduleproductcate|admin-product-cate|~/admin_page/module_function/module_ProductCate.aspx");
        //Tin Tức
        list.Add("moduletintuc|admin-tin-tuc|~/admin_page/module_function/module_TinTuc.aspx");
        //Admin
        list.Add("moduleadminviewbooking|admin-view-booking|~/admin_page/module_function/admin_AdminViewBooking.aspx");
        list.Add("moduleadminviewguest|admin-view-guest|~/admin_page/module_function/admin_AdminViewGuest.aspx");
        list.Add("moduleadminphanquyen|admin-phan-quyen|~/admin_page/module_function/admin_PhanQuyen.aspx");
        list.Add("moduleadminexchange|admin-exchange|~/admin_page/module_function/admin_AdminExchange.aspx");
        list.Add("moduleadminguestpoint|admin-guest-point|~/admin_page/module_function/admin_GuestPoint.aspx");
        //Input
        list.Add("moduleadminupdatestatus|admin-book-update-status|~/admin_page/module_function/admin_BookUpdateStatus.aspx");
        list.Add("moduleadmindanhsachbooking|admin-danh-sach-booking|~/admin_page/module_function/admin_BookList.aspx");
        list.Add("moduleadmindanhsachguest|admin-danh-sach-guest|~/admin_page/module_function/admin_GuestList.aspx");
        list.Add("moduleadminbookaddedit1|admin-add-edit1|~/admin_page/module_function/admin_BookAddEdit1.aspx");
        list.Add("moduleadminbookaddedit2|admin-add-edit2|~/admin_page/module_function/admin_BookAddEdit2.aspx");
        list.Add("moduleadmincheckininfo|admin-checkin-info|~/admin_page/module_function/admin_CheckinInfo.aspx");
        list.Add("moduleadmincheckinprint|admin-checkin-print|~/admin_page/module_function/admin_CheckInPrint.aspx");
        list.Add("moduleadmincheckoutprint|admin-checkout-print|~/admin_page/module_function/admin_CheckOutPrint.aspx");
        list.Add("moduleadmineidtguest|admin-edit-guest|~/admin_page/module_function/admin_GuestEdit.aspx");

        //Verify
        list.Add("moduleadminverifybooking|admin-verify-booking|~/admin_page/module_function/admin_VerifyBooking.aspx");
        //View
        list.Add("moduleviewbooking|admin-booking-views|~/admin_page/module_function/admin_ViewBooking.aspx");
        list.Add("moduleviewguest|admin-guest-views|~/admin_page/module_function/admin_ViewGuest.aspx");
        return list;
    }
}
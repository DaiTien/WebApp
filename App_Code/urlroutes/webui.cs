using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for webui
/// </summary>
public class webui
{
	public webui()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        list.Add("webTrangChu|trang-chu.html|~/Default.aspx");
        // Introduce
        list.Add("webgioithieu|gioi-thieu|~/web_module/web_GioiThieu.aspx");
        // Đăng ký khóa học
        list.Add("webfigermath|finger-math-1|~/web_module/web_FingerMath1.aspx");
        // Tin tức
        // Tin tức chi tiết
        // Liên hệ
        list.Add("weblienhe|lien-he|~/web_module/web_LienHe.aspx");
        // khách hàng nổi bật -> Khóa học nổi bật

        list.Add("webkhoahoctieubieu|khoa-hoc-tieu-bieu|~/web_module/web_KhoaHoc.aspx");
      //  list.Add("weblienhe|lien-he|~/web_module/web_Contact.aspx");
        //list.Add("webkhachhang|khach-hang-noi-bat/{name}-{id}|~/web_module/web_KhachHang.aspx");
        list.Add("webkhoahocnoibat|khoa-hoc-noi-bat/{name}-{id}|~/web_module/web_KhoaHocDetail.aspx");
        // Bài tập bàn tay

        list.Add("webhocdenbantay1|hocdenbantay1-{id}|~/web_module/web_HocDem1.aspx");
        list.Add("webhocdenbantay2|hocdenbantay2-{id}|~/web_module/web_HocDem2.aspx");
        list.Add("webfigermath1|figermath1-{id}|~/web_module/web_FingerMath1.aspx");
        list.Add("webfigermath2|figermath2-{id}|~/web_module/web_FingerMath2.aspx");
        list.Add("webfigermath3|figermath3-{id}|~/web_module/web_FingerMath3.aspx");
        // Soroban Cơ Bản
        list.Add("webfoundation1|foundation1-{id}|~/web_module/web_Foundation1.aspx");
        list.Add("webfoundation2|foundation2-{id}|~/web_module/web_Foundation2.aspx");
        list.Add("webhocdemsorobal|hocdemsorobal-{id}|~/web_module/web_BTNangCao1.aspx");
        //Abacus nâng cao
        list.Add("webelementery1|elementery1-{id}|~/web_module/web_Elementery1.aspx");
        list.Add("webelementery2|elementery2-{id}|~/web_module/web_Elementery2.aspx");
        // bài tập chi tiết
        list.Add("webfigermathbantaynhapmon1|bai-tap-ban-tay-nhap-mon-{id}|~//web_module/web_GameNhapMon_1.aspx");
        list.Add("webfigermathsoroban1|bai-tap-soroban-nhap-mon-{id}|~//web_module/web_GameNhapMon_1.aspx");
        // Bài tập soroban

        //Sticker
        list.Add("websticker|sticker|~/web_module/web_Sticker.aspx");
        // học đếm 1
        // tin tức
        list.Add("webtintuc|{name}-{id}|~//web_module/web_News.aspx");
        list.Add("webtintucchitiet|tin-tuc/{name}-{id}|~//web_module/web_TinTucChiTiet.aspx");
        //bài tập
        list.Add("webbaitapfingermath1|{name}-{id}|~//web_module/web_GameNhapMon_1.aspx");
        return list;

    }
}
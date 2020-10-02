using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class admin_page_module_function_admin_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    //protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
    //    string FileName = GridView1.Caption;
    //    string Extension = Path.GetExtension(FileName);
    //    string FilePath = Server.MapPath(FolderPath + FileName);
    //    Import_To_Grid(FilePath, Extension);
    //    GridView1.PageIndex = e.NewPageIndex;
    //    GridView1.DataBind();
    //}
    private void Import_To_Grid(string FilePath, string Extension)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
            default:
                break;
        }
        conStr = String.Format(conStr, FilePath, 1);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;
        connExcel.Open();
        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();
        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        //string connString = "";
        //string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = fileuploadExcel.PostedFile.FileName;
        ////Connection String to Excel Workbook
        //if (strFileType.Trim() == ".xls")
        //{
        //    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //}
        //else if (strFileType.Trim() == ".xlsx")
        //{
        //    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //}
        //string query = "SELECT * FROM [Sheet1$]";
        //OleDbConnection conn = new OleDbConnection(connString);
        //if (conn.State == ConnectionState.Closed)
        //    conn.Open();
        //OleDbCommand cmd = new OleDbCommand(query, conn);
        //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //grvExcelData.DataSource = ds.Tables[0];
        //grvExcelData.DataBind();
        //da.Dispose();
        //conn.Close();
        //conn.Dispose();
        if (FileUpload1.HasFile)
        {
            //Tạo đường dẫn
            string foldeUpload = Server.MapPath("~/FileUpLoads/Excel/");
            if (!Directory.Exists(foldeUpload))
            {
                Directory.CreateDirectory(foldeUpload);
            }
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            //string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath("~/FileUpLoads/Excel/"+ FileName);
            FileUpload1.SaveAs(FilePath);
            Import_To_Grid(FilePath, Extension);
        }

    }
}
<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ImportExcel.aspx.cs" Inherits="admin_page_module_function_admin_UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
    <div class="content">
        <formview id="form1" runat="server">
            <div>
                <b>Please Select Excel File: </b>
                <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;&nbsp;
                <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" />
                <br />
                <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label><br />
                <asp:GridView ID="GridView1" runat="server">
                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                </asp:GridView>
            </div>
        </formview>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

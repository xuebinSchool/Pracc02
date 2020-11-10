<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInsert.aspx.cs" Inherits="Prac02.ProductInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 93%;">
        <tr>
            <td style="width: 147px">Product Name</td>
            <td>
                <asp:TextBox ID="tb_ProductName" runat="server" Width="575px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 147px">Product Desc</td>
            <td>
                <asp:TextBox ID="tb_ProductDesc" runat="server" Height="140px" TextMode="MultiLine" Width="575px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 147px">Unit Price</td>
            <td>
                <asp:TextBox ID="tb_UnitPrice" runat="server" Width="575px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 147px">Stock Level</td>
            <td>
                <asp:TextBox ID="tb_StockLevel" runat="server" CssClass="form-control"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td style="width: 147px; height: 34px;">Product Image</td>
            <td style="height: 34px">
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control"/>
             </td>
        </tr>
         <tr>
            <td style="width: 147px">&nbsp;</td>
            <td>
                <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
             </td>
        </tr>
         <tr>
            <td style="width: 147px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td style="width: 147px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_Insert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="btn_Insert_Click"/>
                <asp:Button ID="btn_View_Product_List" runat="server" OnClick="Button2_Click" Text="View Product List" CssClass="btn btn-secondary"/>
             </td>
        </tr>
    </table>
</asp:Content>

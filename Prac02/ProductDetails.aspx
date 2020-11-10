<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Prac02.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 93%;">
        <tr>
            <td rowspan="3" style="width: 15px">
                <asp:Image ID="img_Product" runat="server" Height="96px" Width="99px" />
            </td>
            <td style="height: 20px">
                <asp:Label ID="lbl_ProdName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lbl_ProdDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 24px"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Price" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btn_Add_To_Cart" runat="server" Text="Add to Cart" CssClass="btn btn-secondary"/>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="btn btn-primary"/>
            </td>
        </tr>
    </table>
</asp:Content>

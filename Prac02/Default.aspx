<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prac02._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Your friendly Neightbourhood Health Supplement Store</h1>
    </div>

    <div class="row">
        <h1><%: Title %></h1>
        <h2>E Store Web APplication can help you find the perfect health supplements.</h2>
        <p>We're all about health supplements. You can oreder any of our supplement today.
            Each supplement listing has detailed information to help you choose the right supplement.
        </p>
    </div>

</asp:Content>

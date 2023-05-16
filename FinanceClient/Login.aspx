<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" 
    Inherits="FinanceClient.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="mb-3">
  <label for="email" class="form-label">Email</label>
  <input type="email" class="form-control" id="email" runat="server">
</div>
<div class="mb-3">
  <label for="pwd" class="form-label">Password</label>
  <input type="password" class="form-control" id="pwd" runat="server">
</div><br />
    <asp:Button ID="loginBtn" CssClass="btn primary" runat="server" Text="Login" OnClick="loginBtn_Click"/>
    <br />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
</asp:Content>

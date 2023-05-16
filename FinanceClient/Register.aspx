<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" Inherits="FinanceClient.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="mb-3">
  <label for="name" class="form-label">Full Name</label>
  <input type="text" class="form-control" id="name" runat="server">
</div>
    <div class="mb-3">
  <label for="email" class="form-label">Email</label>
  <input type="email" class="form-control" id="email" runat="server">
</div>
<div class="mb-3">
  <label for="pwd" class="form-label">Password</label>
  <input type="password" class="form-control" id="pwd" runat="server">
</div><br />
    <asp:Button ID="registerBtn" CssClass="btn primary" runat="server" Text="Register" OnClick="registerBtn_Click"/>
    <br />
    <asp:Label ID="resLbl" runat="server" Text=""></asp:Label>
</asp:Content>
<%@ Page Title="Login" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Comp2007_Assignment2.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Login</h1>

    <div>
        <asp:Label ID="lblStatus" runat="server" CssClass="label label-danger" />
    </div>

    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="submit" runat="server" text="Login" CssClass="btn btn-primary" OnClick="submit_Click"/>
    </div>
</asp:Content>

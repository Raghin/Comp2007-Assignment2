<%@ Page Title="register" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Comp2007_Assignment2.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <h6>All fields are required</h6>

    <div class="form-group-lg">
        <asp:Label ID="lblStatus" runat="server" CssClass="label label-info"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required />
    </div>
    <div class="form-group">
        <label for="txtConfirm" class="col-sm-2">Confirm:</label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" />
        <asp:CompareValidator runat="server" ControlToValidate="txtPassword" ControlToCompare="txtConfirm" Operator="Equal"
            ErrorMessage="Passwords must match" CssClass="label label-danger" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="submit" runat="server" Text="register" CssClass="btn btn-primary" OnClick="submit_Click" />
    </div>

</asp:Content>

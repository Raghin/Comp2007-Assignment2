<%@ Page Title="progress" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="progress.aspx.cs" Inherits="Comp2007_Assignment2.progress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="txtProgress" class="col-sm-3">Progress:</label>
        <asp:TextBox ID="txtProgress" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save Progress" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>

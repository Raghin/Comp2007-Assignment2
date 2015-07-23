<%@ Page Title="Book" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="Comp2007_Assignment2.book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Book Details</h1>

    <div>
        Here you enter the information about the book you wish to add to the list.
        Only the book name is required, however when possible please add a genre and
        length of the book in pages (# pages). Example:
    </div>
    <div>
        Length: 350 pages
    </div>
    <div class="form-group">
        <label for="txtName" class="col-sm-3">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtGenre" class="col-sm-3">Genre:</label>
        <asp:TextBox ID="txtGenre" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtAlt" class="col-sm-3">Alternate Name:</label>
        <asp:TextBox ID="txtAlt" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtLength" class="col-sm-3">Length:</label>
        <asp:TextBox ID="txtLength" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Add Book" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>

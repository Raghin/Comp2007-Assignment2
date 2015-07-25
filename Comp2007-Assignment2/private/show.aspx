<%@ Page Title="show" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Comp2007_Assignment2.show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Show Details</h1>

    <div class="well">
        Here you enter the information about the show you wish to add to the list.
        Only the show name is required, however when possible please add a genre and
        length of the show in either episodes, or minutes for a movie (# episodes / # Minutes). Example:
    </div>
    <div class="well">
        Length: 12 Episodes / 150 Minutes
    </div>
    <div class="form-group">
        <label for="txtName" class="col-sm-3">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtGenre" class="col-sm-3">Genre:</label>
        <asp:TextBox ID="txtGenre" runat="server" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtAlt" class="col-sm-3">Alternate Name:</label>
        <asp:TextBox ID="txtAlt" runat="server" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtLength" class="col-sm-3">Length:</label>
        <asp:TextBox ID="txtLength" runat="server" MaxLength="50" />
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save Show" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>

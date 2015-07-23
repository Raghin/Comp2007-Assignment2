<%@ Page Title="game" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="game.aspx.cs" Inherits="Comp2007_Assignment2.game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Game Details</h1>

    <div>
        Here you enter the information about the game you wish to add to the list.
        Only the game name is required, however when possible please add a genre and
        length of the game in hours (# - # hours). Example:
    </div>
    <div>
        Length: 50-65 hours
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
        <asp:Button ID="btnSave" runat="server" Text="Save Game" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>

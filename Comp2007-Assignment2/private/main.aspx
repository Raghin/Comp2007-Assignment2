<%@ Page Title="main" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Comp2007_Assignment2.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Search</h1>
    <div class="well">
        Here you can search for existing titles to add to your collection.
    </div>
    <div>
        <label for="ddlView">Type to view:</label>
        <asp:DropDownList ID="ddlView" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlView_SelectedIndexChanged">
            <asp:ListItem Text="All" />
            <asp:ListItem Text="Games" />
            <asp:ListItem Text="Books" />
            <asp:ListItem Text="Shows" />
        </asp:DropDownList>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
        </asp:DropDownList>

    </div>
    <h4>Games</h4>
    <asp:GridView ID="grdgames" runat="server" CssClass="table table-striped table-hover sort display"
        AutoGenerateColumns="false" DataKeyNames="GameID" AllowPaging="true" AllowSorting="true" 
        OnPageIndexChanging="grdgames_PageIndexChanging" PageSize="4" OnRowCommand="grdgames_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:ButtonField Text ="Add" HeaderText="Add to Collection" ButtonType="Button" CommandName="getID" />
        </Columns>
    </asp:GridView>
    <label for="txtName" class="col-sm-3">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    <h4>Books</h4>
    <asp:GridView ID="grdBooks" runat="server" CssClass="table table-striped table-hover sort display"
        AutoGenerateColumns="false" DataKeyNames="BookID" AllowPaging="true" AllowSorting="true" 
        OnPageIndexChanging="grdBooks_PageIndexChanging" PageSize="4" OnRowCommand="grdBooks_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:ButtonField Text ="Add" HeaderText="Add to Collection" ButtonType="Button" CommandName="getID" />
        </Columns>
    </asp:GridView>
    <h4>Shows</h4>
    <asp:GridView ID="grdShows" runat="server" CssClass="table table-striped table-hover sort display"
        AutoGenerateColumns="false" DataKeyNames="ShowID" AllowPaging="true" AllowSorting="true" 
        OnPageIndexChanging="grdShows_PageIndexChanging" PageSize="4" OnRowCommand="grdShows_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:ButtonField Text ="Add" HeaderText="Add to Collection" ButtonType="Button" CommandName="getID" />
        </Columns>
    </asp:GridView>
</asp:Content>

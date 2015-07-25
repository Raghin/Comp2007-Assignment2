<%@ Page Title="games" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="games.aspx.cs" Inherits="Comp2007_Assignment2.games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Games</h1>
    <div class="well">
        Here we have a list of all the games currently inside the database. Please note this is simply 
        a list of games that can be added to and information edited if some portions are missing. You
        will not be able to create records from this page. Also note that game lengths are estimates.
        If you wish to obtain the most accurate estimate of a games length, it is recommended to use
        http://howlongtobeat.com/.
    </div>
    <div class="col-sm">
        <asp:Button ID="gameRedirect" runat="server" Text="Add Game" CssClass="btn btn-primary"
             OnClick="gameRedirect_Click" />
    </div>
    <div>
        <label for="ddlPageSize">Games Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdGames" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="GameID" AllowPaging="true" PageSize="5" AllowSorting="true" OnRowDeleting="grdGames_RowDeleting"
        OnSorting="grdGames_Sorting" OnPageIndexChanging="grdGames_PageIndexChanging" OnRowDataBound="grdGames_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/game.aspx" 
                DataNavigateUrlFields="GameID" DataNavigateUrlFormatString="game.aspx?GameID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div class="col-sm">
        <asp:Button ID="gameRedirect2" runat="server" Text="Add Game" CssClass="btn btn-primary"
             OnClick="gameRedirect_Click" />
    </div>
</asp:Content>

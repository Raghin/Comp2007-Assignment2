<%@ Page Title="shows" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="shows.aspx.cs" Inherits="Comp2007_Assignment2.shows" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Shows</h1>
    <div class="well">
        Here we have a list of all the shows currently inside the database. Please note this is simply 
        a list of shows that can be added to and information edited if some portions are missing. You
        will not be able to create records from this page.
    </div>
    <div class="col-sm">
        <asp:Button ID="showRedirect" runat="server" Text="Add Show" CssClass="btn btn-primary"
             OnClick="showRedirect_Click" />
    </div>
    <div>
        <label for="ddlPageSize">Shows Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdShows" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="ShowID" AllowPaging="true" PageSize="5" AllowSorting="true" OnRowDeleting="grdShows_RowDeleting"
        OnSorting="grdShows_Sorting" OnPageIndexChanging="grdShows_PageIndexChanging" OnRowDataBound="grdShows_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/show.aspx" 
                DataNavigateUrlFields="ShowID" DataNavigateUrlFormatString="show.aspx?ShowID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div class="col-sm">
        <asp:Button ID="showRedirect2" runat="server" Text="Add Show" CssClass="btn btn-primary"
             OnClick="showRedirect_Click" />
    </div>
</asp:Content>

<%@ Page Title="Books" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="Comp2007_Assignment2.temp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Books</h1>
    <div>
        Here we have a list of all the books currently inside the database. Please note this is simply 
        a list of books that can be added to and information edited if some portions are missing. You
        will not be able to create records from this page.
    </div>
    <a href="book.aspx">Add Book</a>
    <div>
        <label for="ddlPageSize">Books Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdBooks" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="BookID" AllowPaging="true" PageSize="5" AllowSorting="true" OnRowDeleting="grdBooks_RowDeleting"
        OnSorting="grdBooks_Sorting" OnPageIndexChanging="grdBooks_PageIndexChanging" OnRowDataBound="grdBooks_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" sortexpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" sortexpression="Length" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/book.aspx" 
                DataNavigateUrlFields="BookID" DataNavigateUrlFormatString="book.aspx?BookID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>

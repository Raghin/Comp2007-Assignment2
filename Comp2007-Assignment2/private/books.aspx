<%@ Page Title="Books" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="Comp2007_Assignment2.temp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Books</h1>
    <a href="book.aspx">Add Book</a>
    
    <asp:GridView ID="grdBooks" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="BookID" AllowPaging="true" PageSize="3" AllowSorting="true">
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

﻿<%@ Page Title="manage" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Assignment2.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Comp2007_Assignment2.manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Collection</h1>
    <div class="well">
        Here we have a list of all the items you have added to your collection. From here you may 
        edit your progress through the item (IE books, page #/shows, episode # etc) or remove items 
        from your collection. To update the progress of an item, click on the items progress text field.
    </div>
    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdRecords" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display"
        DataKeyNames="RecordID" AllowPaging="true" PageSize="5" AllowSorting="true" OnRowDeleting="grdRecords_RowDeleting"
        OnSorting="grdRecords_Sorting" OnPageIndexChanging="grdRecords_PageIndexChanging" on>
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="AltName" HeaderText="Alternate Name" SortExpression="AltName" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
            <asp:HyperLinkField HeaderText="Progress" DataTextField="Progress" NavigateUrl="~/progress.aspx" 
                DataNavigateUrlFields="RecordID" DataNavigateUrlFormatString="progress.aspx?RecordID={0}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Remove" HeaderText="Remove Record" ButtonType="Button" />
        </Columns>
    </asp:GridView>
</asp:Content>

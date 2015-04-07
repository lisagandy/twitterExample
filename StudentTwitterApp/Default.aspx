<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Tweet3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 169px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1">
        <tr>
            <td class="style2">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="LoadUser" Value="LoadUser"></asp:MenuItem>
        </Items>
    </asp:Menu>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="344px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Run" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="410px" TextMode="MultiLine" 
                    Width="642px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
</asp:Content>

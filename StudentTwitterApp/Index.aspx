<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Tweet3.WebForm2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: -webkit-linear-gradient(#29344F, #879FD6); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(#29344F, #879FD6); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(#29344F, #879FD6); /* For Firefox 3.6 to 15 */
            background: linear-gradient(#29344F, #879FD6); /* Standard syntax */
            font-family: Verdana;
            font-size: 0.8em;
        }
        
        .lblStyle
        {
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="3" cellspacing="3" width="100%">
        <tr>
            <td style="width: 15%;">
                <asp:Menu ID="Menu1" runat="server" BackColor="Transparent" DynamicHorizontalOffset="2"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#FFFFFF" OnMenuItemClick="Menu1_MenuItemClick"
                    StaticSubMenuIndent="10px" Style="font-size: large; font-family: 'Stencil Std'">
                    <DynamicHoverStyle BackColor="Transparent" ForeColor="#FFFFFF" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="Transparent" />
                    <DynamicSelectedStyle BackColor="#FFFFFF" />
                    <Items>
                        <asp:MenuItem Text="Load User" Value="LoadUser" ToolTip="Loaduser(Screen_Name)">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Get Followers" Value="GetFollowers"></asp:MenuItem>
                        <asp:MenuItem Text="Show Trends" Value="ShowTrends" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="GetUserLocation" Value="GetUserLocation"></asp:MenuItem>
                        <asp:MenuItem Text="Display Tweets" Value="DisplayTweets"></asp:MenuItem>
                        <asp:MenuItem Text="Get Profile Image" Value="GetProfileImage"></asp:MenuItem>
                        <asp:MenuItem Text="Post Tweet" Value="PostTweet" 
                            ToolTip="PostTweet(Status,Screenname)">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Tweet Time chart" Value="TweetTimechart"></asp:MenuItem>
                        <asp:MenuItem Text="GetFromUrl" Value="GetFromUrl" 
                            ToolTip="GetFrom Url(Complete URL from twitter api console)"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#FFCC66" />
                </asp:Menu>
            </td>
            <td style="width: 85%;">
                <asp:TextBox ID="txtConsole" runat="server" BackColor="#333333" ForeColor="White"
                    TextMode="MultiLine" Width="98%" Height="200px"></asp:TextBox>
                <asp:Panel ID="pnlReqKeys" runat="server" Width="98%" Height="200px" CssClass="lblStyle"
                    Visible="False">
                    <asp:Label ID="Label5" runat="server" Text="Please Enter the below details."></asp:Label>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Token:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" Width="265px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Token Secret:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" Width="264px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Consumer Key:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" Width="264px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Consumer Secret:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" Width="264px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnRegKeySubmit" runat="server" Text="Continue" OnClick="btnRegKeySubmit_Click" />
                                <asp:Button ID="btnRegKeyCancel" runat="server" Text="Cancel" OnClick="btnRegKeyCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnRun" runat="server" OnClick="btnRun_Click" Text="Run" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="250px" Width="98%" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="54px" Width="86px" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Chart ID="Chart1" runat="server" Height="194px" Visible="False">
                    <Series>
                        <asp:Series Name="Time">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

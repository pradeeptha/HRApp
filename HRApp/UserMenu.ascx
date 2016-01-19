<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu.ascx.cs" Inherits="HRApp.UserMenu" %>
<% if(HttpContext.Current.User.IsInRole("Admin")) { %>
    <li><a runat="server" href="~/">Home</a></li>
    <li><a runat="server" href="~/UserInfo">User Info</a></li>
    <li><a runat="server" href="~/SubmitRequest">Submit Request</a></li>
<%} %>
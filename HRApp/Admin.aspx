<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="HRApp.Admin" %>

<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContent" runat="server">
   <li><a runat="server" href="~/">Home</a></li>
    <li><a runat="server" href="~/UserInfo">User Info</a></li>
    <li><a runat="server" href="~/UpdateExam">Update Exam</a></li>
    <li><a runat="server" href="~/Result">Result</a></li>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

</asp:Content>

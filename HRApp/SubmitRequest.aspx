<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SubmitRequest.aspx.cs" Inherits="HRApp.SubmitRequest" %>

<%@ Register TagPrefix="uc" TagName="UserMenu" 
    Src="~/UserMenu.ascx" %>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContent" runat="server">
    <uc:UserMenu runat="server"></uc:UserMenu>
   <%--<li><a runat="server" href="~/">Home</a></li>
    <li><a runat="server" href="~/UserInfo">User Info</a></li>
    <li><a runat="server" href="~/UpdateExam">Update Exam</a></li>
    <li><a runat="server" href="~/Result">Result</a></li>--%>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new Service Request</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ServiceRequestsddl" CssClass="col-md-2 control-label">Service Request Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ServiceRequestsddl" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ServiceRequestsddl"
                    CssClass="text-danger" ErrorMessage="The service request field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Departmentsddl" CssClass="col-md-2 control-label">Department</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Departmentsddl" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Departmentsddl"
                    CssClass="text-danger" ErrorMessage="The Department field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Issue" CssClass="col-md-2 control-label">Issue</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Issue" CssClass="form-control" EnableViewState="False" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Issue"
                    CssClass="text-danger" ErrorMessage="The Issue field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateServiceRequest_Click" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

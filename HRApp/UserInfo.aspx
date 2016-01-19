<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserInfo.aspx.cs" Inherits="HRApp.UserInfo" %>
<%@ Register TagPrefix="uc" TagName="UserMenu" 
    Src="~/UserMenu.ascx" %>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContent" runat="server">
    <% if(HttpContext.Current.User.IsInRole("Admin")) { %>
    <uc:UserMenu runat="server"></uc:UserMenu>
   <%--<li><a runat="server" href="~/">Home</a></li>
    <li><a runat="server" href="~/UserInfo">User Info</a></li>
    <li><a runat="server" href="~/UpdateExam">Update Exam</a></li>
    <li><a runat="server" href="~/Result">Result</a></li>--%>
    <%} %>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="overflow: hidden;">
        <asp:Repeater ID="rptUserInfo" runat="server">

            <HeaderTemplate>
              <table border="1">
              <tr>
                 <th>User Name</th>
                 <th>Mobile Number</th>
                 <th>City</th>
              </tr>
            </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td bgcolor="#CCFFCC">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("UserName") %>' />
              </td>
              <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("MobileNumber") %>' />
              </td>
               <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label3" 
                      text='<%# Eval("City") %>' />
              </td>
          </tr>
          </ItemTemplate>

          <AlternatingItemTemplate>
          <tr>
              <td>
                <asp:Label runat="server" ID="Label4" 
                    text='<%# Eval("UserName") %>' />
              </td>
              <td>
                  <asp:Label runat="server" ID="Label5" 
                      text='<%# Eval("MobileNumber") %>' />
              </td>
               <td>
                  <asp:Label runat="server" ID="Label6" 
                      text='<%# Eval("City") %>' />
              </td>
          </tr>
          </AlternatingItemTemplate>

          <FooterTemplate>
              </table>
          </FooterTemplate>

           <%-- <ItemTemplate>

                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-md-2 control-label">Candidate Name</label>
                        <div class="col-md-10">
                            <asp:Label runat="server" ID="lblname" Text='<%#Eval("UserName")%>'></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 control-label">Mobile Number</label>
                        <div class="col-md-10">
                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 control-label">City</label>
                        <div class="col-md-10">
                            <asp:Label runat="server" ID="Label2" Text='<%#Eval("City") %>'></asp:Label>
                        </div>
                    </div>
                </div>

           </ItemTemplate>--%>
        </asp:Repeater>

        <div style="overflow: hidden;">
            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                <ItemTemplate>
                        <asp:LinkButton ID="btnPage"
            style="padding:8px; margin:2px; background:#ffa100; border:solid 1px #666; font:8pt tahoma;"
        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
            runat="server" ForeColor="White" Font-Bold="True"><%# Container.DataItem %>
                        </asp:LinkButton>
               </ItemTemplate>
            </asp:Repeater>
        </div>
   </div>

</asp:Content>

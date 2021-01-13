<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Front_End._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if(LoggedInPerson != null) {
           if (LoggedInPerson.Type == "Student") { %>
            <meta http-equiv="refresh" content="0;url=StudentHome.aspx" />
        <% } else if(LoggedInPerson.Type == "Teacher" || LoggedInPerson.Type == "SysAdmin") { %>
            <meta http-equiv="refresh" content="0;url=Home.aspx" />
        <% }
       } %>
</asp:Content>

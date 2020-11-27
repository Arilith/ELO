<%@ Page Title="UserList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Front_End.UserList" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto"><%: Title %></h2>
    <table class="table-striped ">
        <tr>
            <th>Naam</th>
            <th>Leeftijd</th>
            <th>Datum</th>
            <th>School</th>
            <th>Rol</th>
            <th>UserID</th>
        </tr>
        <% foreach (Person person in personList){ %> 
            <tr>
                <th><%: person.Name %></th>
                <th><%: person.Age %></th>
                <th><%: person.RegistrationDate %></th>
                <th><%: person.School %></th>
                <th><%: person.Type %></th>
                <th><%: person.UserID %></th>
            </tr>     
        <% } %>
    </table>
</asp:Content>

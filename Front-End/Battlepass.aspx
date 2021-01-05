<%@ Page Title="BattlePass" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BattlePass.aspx.cs" Inherits="Front_End.BattlePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto">BattlePass</h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
        table, th, td {
            border: 1px solid gray!important;
        }
    </style>
    <table class="table-striped table-bordered ">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Leeftijd</th>
                <th>Datum</th>
                <th>School</th>
                <th>Rol</th>
                <th>UserID</th>
                <th>Mentor</th>
                <th>Klasnaam</th>
            </tr>
        </thead>
        <tbody>
            <%-- <% foreach (Level level in levelMan.GetLevelListFromDB(loggedInPerson.School)){ %>  --%>
            <%--     <tr> --%>
            <%--         <td><%: student.Name %></td> --%>
            <%--         <td><%: student.Age %></td> --%>
            <%--         <td><%: student.RegistrationDate %></td> --%>
            <%--         <td><%: student.School %></td> --%>
            <%--         <td><%: student.Type %></td> --%>
            <%--         <td><%: student.UserId %></td> --%>
            <%--         <td><% if(student.Mentor != null) { %><%: student.Mentor.Name %> <% } else { %>Onbekend <% } %></td> --%>
            <%--         <td><% if(student.PartOfClass != null) { %><%: student.PartOfClass.Name %> <% } else { %>Onbekend <% } %></td> --%>
            <%--     </tr>      --%>
            <%-- <% } %> --%>
        </tbody>
    </table><br/>
</asp:Content>

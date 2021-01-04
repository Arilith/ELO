<%@ Page Title="gradelist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gradelist.aspx.cs" Inherits="Front_End.UserList" %>
<%@ Import Namespace="ELO" %>
    
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto">Cijferlijst</h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }

        table, th, td {
            border:1px solid gray;
        }
    </style>
    <table>
        <thead>
            <tr>
                <th>Naam</th>
                <th>Klasnaam</th>
                <th>Vak</th>
                <th>Datum</th>
                <th>Weging</th>
                <th>Cijfer</th>

            </tr>
        </thead>
        <tbody>
            <% foreach (Grade grade in Manager.gradeMan.GetGradeList()){ %> 
                <tr>
                    <td><%: grade.student.Name %></td>
                    <td><%: grade._class.Name%></td>
                    <td><%: grade.subject %></td>
                    <td><%: grade.date %></td>
                    <td><%: grade.weight %></td>
                    <td><% if (grade.grade < 55) { %><i style="color: darkred; "><%: grade.grade %></i> <% } else { %><i style="color: lawngreen; "><%: grade.grade %></i><% } %></td>
                </tr>     
            <% } %>
        </tbody>

</table>
</asp:Content>


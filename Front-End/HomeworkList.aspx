<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeworkList.aspx.cs" Inherits="Front_End.HomeworkList" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto">Huiswerk</h2>
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
            <th>Klas</th>
            <th>Vak</th>
            <th>Datum</th>
            <th>Titel</th>
            <th>Beschrijving</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (Homework homework in HomeworkManager.GetHomeWorkFromDB(LoggedInStudent.School)){ %>  %>
        <tr> 
        <td><%: homework._class.Name %></td>
        <td><%: homework.Subject %></td>
        <td><%: homework.DueDate %></td>
        <td><%: homework.Title %></td>
        <td><%: homework.Content%></td>
        <td><%: homework.Exp %></td>
        </tr>
        <% } %>
        </tbody>
    </table>
    <br/>
    
</asp:Content>

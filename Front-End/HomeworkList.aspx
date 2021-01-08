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
            <th>Vak</th>
            <th>inleverdatum</th>
            <th>Titel</th>
            <th>Beschrijving</th>
            <th>Te verdienen punten</th>
            <th>Afvinken</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (Homework homework in HomeworkManager.GetHomeWorkForClassFromDB(LoggedInStudent.School, LoggedInStudent.PartOfClass)){ %> 
        <tr> 
        <td><%: homework.Subject.Name %></td>
        <td><%: homework.DueDate %></td>
        <td><%: homework.Title %></td>
        <td><%: homework.Content%></td>
        <td><%: homework.Exp %></td>
            <td> <input type="checkbox"/></td>
        </tr>

        <% } %>
        </tbody>
    </table>
    <br/>
    
</asp:Content>

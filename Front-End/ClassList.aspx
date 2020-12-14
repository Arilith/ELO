<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Front_End.ClassList" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto"><%: Title %></h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
    </style>
    <table class="table-striped table-bordered ">
        <thead>
        <tr>
            <th>Klasnaam</th>
            <th>Klasmentor</th>
            <th>Niveau</th>
            <th>Leshuis</th>
            <th>Cluster</th>
            <th>Leerjaar</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School)){ %> 
            <tr>
                <td><%: _class.Name %></td>
                <td><% if (_class.Mentor != null) { %><%: _class.Mentor %><% } else { %> Geen mentor<% } %></td>
                <td><%: _class.Level %></td>
                <td><%: _class.LesHuis %></td>
                <td><%: _class.Cluster %></td>
                <td><%: _class.StudyYear %></td>
               
            </tr>     
        <% } %>
        </tbody>
    </table>
</asp:Content>

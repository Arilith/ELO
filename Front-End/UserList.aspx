﻿<%@ Page Title="UserList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Front_End.UserList" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto">Gebruikerslijst</h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
    </style>
    <table class="table-striped table-bordered styled-table">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Leerlingnummer</th>
                <th>Email</th>
                <th>Mentor</th>
                <th>Klasnaam</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Student student in usermanager.GetPersonListFromDB(loggedInPerson.School, "Student")){ %> 
                <tr>
                    <td><%: student.Name %></td>
                    <td><%: student.LeerlingNummer %></td>
                    <td><%: student.Email %></td>
                    <td><% if(student.Mentor != null) { %><%: student.Mentor.Name %> <% } else { %>Onbekend <% } %></td>
                    <td><% if(student.PartOfClass != null) { %><%: student.PartOfClass.Name %> <% } else { %>Onbekend <% } %></td>
                </tr>     
            <% } %>
        </tbody>
    </table><br/>
    <table class="table-striped table-bordered styled-table">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Datum</th>
                <th>School</th>
                <th>Rol</th>
                <th>UserID</th>
                <th>Vak</th>
                <th>Mentor Klas</th>
                <th>Bewerken</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Teacher teacher in usermanager.GetPersonListFromDB(loggedInPerson.School, "Teacher")){ %>
                <tr>
                    <td><%: teacher.Name %></td>
                    <td><%: teacher.RegistrationDate %></td>
                    <td><%: teacher.School %></td>
                    <td><%: teacher.Type %></td>
                    <td><%: teacher.UserId %></td>
                    <td><% if(teacher.Subject != null) { %> <%: teacher.Subject.Name %> <% }  %></td>
                    <td><% if(teacher.MentorForClass != null) { %> <%: teacher.MentorForClass.Name %> <% }  %></td>
                    <td><a href="ManageUser?uuid=<%: teacher.UserId %>" class="btn btn-info">Bewerken</a></td>
                </tr>
            <% } %>
        </tbody>
    </table><br/>
    <table class="table-striped table-bordered styled-table">
        <thead>
        <tr>
            <th>Klasnaam</th>
            <th>Leshuis</th>
            <th>Cluster</th>
            <th>Mentor</th>
            <th>Jaargang</th>
            <th>Bewerken</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School)) { %>
            <tr>
                <td><%: _class.Name %></td>
                <td><%: _class.LesHuis %></td>
                <td><%: _class.Cluster %></td>
                <td><% if(_class.Mentor != null) { %><%: _class.Mentor.Name %> <% } %></td>
                <td><%: _class.StudyYear %></td>
                <td><a href="StudentsByClass" class="btn btn-primary">Mentor veranderen</a></td>
            </tr>
        <% } %>
        </tbody>
    </table>
</asp:Content>

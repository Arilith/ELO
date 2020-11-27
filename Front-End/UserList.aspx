<%@ Page Title="UserList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Front_End.UserList" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto"><%: Title %></h2>
    <table class="table-striped ">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Leeftijd</th>
                <th>Datum</th>
                <th>School</th>
                <th>Rol</th>
                <th>UserID</th>
                <th>isTeacher</th>
                <th>subject</th>
                <th>classname</th>
                <th>studentsInClass</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Teacher teacher in personList){ %> 
                <tr>
                    <td><%: teacher.Name %></td>
                    <td><%: teacher.Age %></td>
                    <td><%: teacher.RegistrationDate %></td>
                    <td><%: teacher.School %></td>
                    <td><%: teacher.Type %></td>
                    <td><%: teacher.UserId %></td>
                    <td><%: teacher.HasGroup ? "Ja" : "Nee" %></td>
                    <td><%: teacher.Subject %></td>
                    <td><%: teacher.MentorForClass.Name %></td>
                    <td><%: teacher.MentorForClass.AmountOfStudents %></td>
                </tr>     
            <% } %>
        </tbody>
    </table>
</asp:Content>

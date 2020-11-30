<%@ Page Title="UserList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Front_End.UserList" %>
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
                <th>Naam</th>
                <th>Leeftijd</th>
                <th>Datum</th>
                <th>School</th>
                <th>Rol</th>
                <th>UserID</th>
                <th>Mentor</th>
                <th>Klasnaam</th>
                <th>studentsInClass</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Student student in userMan.GetStudentList()){ %> 
                <tr>
                    <td><%: student.Name %></td>
                    <td><%: student.Age %></td>
                    <td><%: student.RegistrationDate %></td>
                    <td><%: student.School %></td>
                    <td><%: student.Type %></td>
                    <td><%: student.UserId %></td>
                    <td><%: student.Mentor.Name %></td>
                    <td><%: student.PartOfClass.Name %></td>
                    <td><%: student.PartOfClass.AmountOfStudents %></td>
                </tr>     
            <% } %>
        </tbody>
    </table>
    <table class="table-striped table-bordered">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Leeftijd</th>
                <th>Datum</th>
                <th>School</th>
                <th>Rol</th>
                <th>UserID</th>
                <th>Vak</th>
                <th>Mentor Klas</th>
                <th>Studenten in huidige klas</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Teacher teacher in userMan.GetTeacherList()){ %> 
                <tr>
                    <td><%: teacher.Name %></td>
                    <td><%: teacher.Age %></td>
                    <td><%: teacher.RegistrationDate %></td>
                    <td><%: teacher.School %></td>
                    <td><%: teacher.Type %></td>
                    <td><%: teacher.UserId %></td>
                    <td><%: teacher.Subject %></td>
                    <td><%: teacher.MentorForClass.Name %></td>
                    <td><%: teacher.MentorForClass.AmountOfStudents %></td>
                </tr>     
            <% } %>
        </tbody>
    </table>
    <table class="table-striped table-bordered">
        <thead>
        <tr>
            <th>Klasnaam</th>
            <th>Aantal leerlingen</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (Class clazz in classMan.classList){ %> 
            <tr>
                <td><%: clazz.Name %></td>
                <td><%: clazz.AmountOfStudents %></td>

            </tr>     
        <% } %>
        </tbody>
    </table>
</asp:Content>

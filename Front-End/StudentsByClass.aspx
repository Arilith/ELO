<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsByClass.aspx.cs" Inherits="Front_End.StudentsByClass" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto"><%: Title %></h2>
    <form method="post" id="classform" name="classform">
        <label for="class">Selecteer een klas</label>
        <select id="class" name="class" class="form-control">
            <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School)) { %>
                <option value="<%: _class.UUID %>"><%: _class.Name %></option>
            <% } %>
        </select><br/><br/>
        <button class="btn btn-success" type="submit">Verstuur</button>
    </form>
    <% if (IsPostBack) { %>
        <div class="row">
            <div class="col-lg-6">
                <style>
                    td {
                        padding: 10px;
                    }
                    th {
                        padding: 10px;
                    }
                </style>
        
                <h2>Klassenlijst van klas: <%: classManager.GetClassFromDatabase(Request.Form["class"]).Name %></h2>
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
                    </tr>
                    </thead>
                    <tbody>
                    <% foreach (Student student in classManager.GetStudentsInClass(Request.Form["class"])){ %> 
                        <tr>
                            <td><%: student.Name %></td>
                            <td><%: student.Age %></td>
                            <td><%: student.RegistrationDate %></td>
                            <td><%: student.School %></td>
                            <td><%: student.Type %></td>
                            <td><%: student.UserId %></td>
                            <td><% if(student.Mentor != null) { %><%: student.Mentor.Name %> <% } else { %>Onbekend <% } %></td>
                        </tr>     
                    <% } %>
                    </tbody>
                </table>
            </div>
            <div class="col-lg-6">

            </div>
        </div>
    <% } %>
</asp:Content>

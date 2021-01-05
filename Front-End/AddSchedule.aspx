<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Front_End.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <%@ Import Namespace="ELO" %>
            <% DateTime now = DateTime.Now; %>
        <h2>Rooster veranderen</h2>
        <label for="teacherName">Teacher</label><br/>
        <select id="teacherName" class="form-control" name="teacherName">
            <% foreach (Teacher teacher in userMan.GetPersonListFromDB(loggedInPerson.School, "Teacher"))
               { %>
                <option value="<%: teacher.UserId %>"><%: teacher.UserName %></option>
            <% } %>
        </select><br/>

        <label for="subjectName">Subject</label><br/>
        <select id="subjectName" class="form-control" name="subjectName">
            <% foreach (Subject subject in subjectMan.GetSubjectList(loggedInPerson.School))
               { %>
                <option value="<%: subject.uuid %>"><%: subject.Name %></option>
            <% } %>
        </select><br/>

        <label for="classroom">Classroom</label><br/>
        <input id="classroom" class="form-control" name="classroom" type="text" required aria-autocomplete="list"/><br/>

        <label for="_class">Class</label><br/>
        <select id="teacherName" class="form-control" name="teacherName">
            <% foreach (Class _class in classMan.GetClassListFromDatabase(loggedInPerson.School))
               { %>
                <option value="<%: _class.UUID %>"><%: _class.Name %></option>
            <% } %>
        </select><br/>
            
            
        <label for="Date">Date+Time</label><br/>
        <input id="dateTime" class="form-control" name="dateTime" type="datetime-local" required/><br/>

        <button style="width: auto" type="submit" class="btn btn-success">Voeg Toe</button><br/><br/><br/>
        <br />
    </div>
</asp:Content>
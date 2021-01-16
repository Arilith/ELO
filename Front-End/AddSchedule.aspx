<%@ Page Title="Rooster item toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Front_End.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <%@ Import Namespace="ELO" %>
            <% DateTime now = DateTime.Now; %>
        <h2>Rooster item toevoegen</h2>
        <label for="teacherName">Teacher</label><br/>

        <%-- selectievak leraar --%>
        <div class="jelly-form" style="width:356px">
        <select id="teacherName" class="form-control" name="teacherName" required>
            <option selected disabled hidden>Niet Abdhulla Klapstulla</option>
            <% foreach (Teacher teacher in userMan.GetPersonListFromDB(loggedInPerson.School, "Teacher"))
               { %>
                <option ><%: teacher.Name %></option>
            <% } %>
        </select><br/>

        <%-- selectievak vak --%>
        <label for="subjectName">Subject</label><br/>
        <select id="subjectName" class="form-control" name="subjectName" required>
            <option selected disabled hidden>Niet Klapstoelvouwen</option>
            <% foreach (Subject subject in subjectManager.GetSubjectList(loggedInPerson.School))
               { %>
                <option ><%: subject.Name %></option>
            <% } %>
        </select><br/>

        <%-- invulveld classroom --%>
        <label for="classroom">Classroom</label><br/>
        <input id="classroom" class="form-control" name="classroom" placeholder="VH133" type="text" required aria-autocomplete="list"/><br/>

        <%-- selectievak klas --%>
        <label for="_class">Class</label><br/>
        <select id="_class" class="form-control" name="_class" required>
            <option selected disabled hidden>Niet 5H3</option>
            <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School))
               { %>
                <option value="<%: _class.UUID %>"><%: _class.Name %></option>
            <% } %>
        </select><br/>

        <%-- selectievak datum en tijd --%>
        <label for="date">Date</label><br/>
        <input id="date" class="form-control" name="date" type="date" required/><br/>

            <%-- <%Selectievak Lesuur %> --%>
            <label for="lesuur">Lesuur</label><br/>
        <select id="lesuur" class="form-control" name="lesuur" required>
            <%
                for (int i = 1; i <= TodayMan.LesUren.Count; i++)
                { %>
                      <option value="<%: i%>">Lesuur <%:i %> (<%: TodayMan.LesUren[i] %>)</option><%
                } %>
                </select>
            <button style="width: auto" type="submit" class="btn btn-success">Voeg Toe</button></div><br/><br/><br/>
        <br />
    </div>
    <div><asp:Label ID="OutputLabelSchedule" runat="server"></asp:Label></div>
</asp:Content>
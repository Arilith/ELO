<%@ Page Title="Docent Toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="Front_End.AddTeacher" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-lg-6">
            <form method="post" id="addteacher" name="addteacher">
                <label for="name">Naam</label><br/>
                <input id="name" class="form-control" name="name" type="text" required/>
        
                <label for="username">Gebruikersnaam</label><br/>
                <input id="username" class="form-control" name="username" type="text" required />
                
                <label for="email">Email Adres</label><br/>
                <input id="email" class="form-control" name="email" type="email" required />
                
                <label for="password">Wachtwoord</label><br/>
                <input id="password" class="form-control" name="password" type="password" required />

                <label for="school">School</label><br/>
                <select id="school" name="school" class="form-control">
                    <% foreach (School school in schoolManager.GetSchoolList()) { %>
                        <option><%: school.Name %></option>
                    <% } %>
                </select>
        
               <%--  <label for="subject">Vak</label><br/> --%>
               <%--  <select name="subject" id="subject" class="form-control"> --%>
               <%--      <option value="">Geen vak</option> --%>
               <%--      <% foreach (Subject subject in Manager.subjectMan.GetSubjectList()) { %> --%>
               <%--          <option><%: subject.Name %></option> --%>
               <%--      <% } %> --%>
               <%--  </select> --%>
               <%-- <label for="mentorclass">Mentorklas</label><br/> --%>
               <%--  <select id="mentorclass" class="form-control" name="mentorclass"> --%>
               <%--      <option value="">Geen klas</option> --%>
               <%--      <% foreach (Class _class in Manager.classMan.GetClassList()) { %> --%>
               <%--          <option><%: _class.Name %></option> --%>
               <%--      <% } %> --%>
               <%--  </select> --%>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
        </div>
        <asp:Label ID="OutputLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
<%@ Page Title="Docent Toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="Front_End.AddTeacher" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2><%: Title %></h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addteacher" name="addteacher">
                    <div class="jelly-form" style="width:356px">
                    <label for="name">Naam</label><br/>
                    <input id="name" class="form-control" name="name" type="text" placeholder="Jan de hoop" required/><br/>

                    <label for="username">Gebruikersnaam</label><br/>
                    <input id="username" class="form-control" name="username" type="text" placeholder="Jdehoop" required /><br/>

                    <label for="email">Email Adres</label><br/>
                    <input id="email" class="form-control" name="email" type="email" placeholder="jdehoop@school.nl" required /><br/>

                    <label for="password">Wachtwoord</label><br/>
                    <input id="password" class="form-control" name="password" type="password"  placeholder="Wachtwoord" required /><br/>
                     <label for="subject">Vak</label><br/>
                        <select name="subject" id="subject" class="form-control">
                        <option value="">Geen vak</option>
                        <% foreach (Subject subject in subjectManager.GetSubjectList(loggedInPerson.School)) { %>
                            <option value="<%: subject.uuid %>"><%: subject.Name %></option>
                        <% } %>
                        </select>
                        <br/>
                   <label for="class">Mentorklas</label><br/>
                    <select id="class" class="form-control" name="class">
                        <option value="">Geen klas</option>
                        <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School)) { %>
                            <option value="<%: _class.UUID %>"><%: _class.Name %></option>
                        <% } %>
                    </select><br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                        </div>
                </form>
            </div>
            <asp:Label ID="OutputLabel" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
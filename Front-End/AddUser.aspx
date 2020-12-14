<%@ Page Title="Leerling toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Front_End.AddUser" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-lg-6">
            <form method="post" id="addstudent" name="addstudent">
                <label for="name">Naam</label><br/>
                <input id="name" class="form-control" name="name" type="text" required/>

                <label for="age">Leeftijd</label><br/>
                <input id="age" class="form-control" name="age" type="number" min="10" max="99" required/>

                <label for="school">School</label><br/>
                <select id="school" class="form-control" name="school">
                    <% foreach (School school in Manager.schoolManager.GetSchoolList()) { %>
                        <option><%: school.Name %></option>
                    <% } %>
                </select>
        
                <label for="mentor">Mentor</label><br/>
                <select id="mentor" class="form-control" name="mentor">
                    <% foreach (Teacher teacher in Manager.userMan.GetTeacherList()) { %>
                        <option><%: teacher.Name %></option>
                    <% } %>
                </select>
        
                <label for="class">Klas</label><br/>
                <select id="class" class="form-control" name="class">
                    <% foreach (Class _class in Manager.classMan.GetClassList()) { %>
                        <option><%: _class.Name %></option>
                    <% } %>
                </select>
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>

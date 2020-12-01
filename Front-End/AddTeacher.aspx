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

                <label for="age">Leeftijd</label><br/>
                <input id="age" class="form-control" name="age" type="number" min="10" max="99" required/>

                <label for="school">School</label><br/>
                <input id="school" class="form-control" name="school" type="text" required/>
        
                <label for="subject">Vak</label><br/>
                <input type="text" name="subject" id="subject" class="form-control" required />
        
                <label for="mentorclass">Mentorklas</label><br/>
                <select id="mentorclass" class="form-control" name="mentorclass">
                    <% foreach (Class _class in Manager.classMan.GetClassList()) { %>
                        <option><%: _class.Name %></option>
                    <% } %>
                </select>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
        </div>
        <asp:Label ID="OutputLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
<%@ Page Title="Leerling toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Front_End.AddUser" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-lg-6">
            Wil je meerdere studenten in een keer toevoegen?
            Upload dan op <a href="~/UploadCSV" runat="server">deze</a> pagina een CSV-bestand.<br/><br/>
            <form method="post" id="addstudent" name="addstudent">
                <div class="jelly-form" style="width:356px">
                <label for="name">Naam</label><br/>
                <input id="name" class="form-control" name="name" type="text" placeholder="Joep Pieters" required/><br/>
                
                <label for="leerlingnummer">Leerlingnummer</label><br/>
                <input id="leerlingnummer" class="form-control" name="leerlingnummer" type="number" placeholder="123456" required/><br/>

                <label for="password">Wachtwoord</label><br/>
                <input id="password" class="form-control" name="password" type="password" placeholder="Wachtwoord123" required/><br/>
                
                <label for="email">Email</label><br/>
                <input id="email" class="form-control" name="email" type="email" placeholder="j.pieters@student.school.nl" required/><br/>

                <label for="class">Klas</label><br/>
                <select id="class" class="form-control" name="class">
                    <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInUser.School)) { %>
                        <option value="<%: _class.UUID %>"><%: _class.Name %></option>
                    <% } %>
                </select>
                <br/>
                <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button></div>
            </form>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
        </div>
</asp:Content>

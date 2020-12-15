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
                
                <label for="leerlingnummer">Leerlingnummer</label><br/>
                <input id="leerlingnummer" class="form-control" name="leerlingnummer" type="number" required/>

                <label for="password">Wachtwoord</label><br/>
                <input id="password" class="form-control" name="password" type="password" required/>
                
                <label for="email">Email</label><br/>
                <input id="email" class="form-control" name="email" type="email" required/>

                <label for="class">Klas</label><br/>
                <select id="class" class="form-control" name="class">
                    <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInUser.School)) { %>
                        <option value="<%: _class.UUID %>"><%: _class.Name %></option>
                    <% } %>
                </select>
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>

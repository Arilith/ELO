<%@ Page Title="Gebruiker toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Front_End.AddUser" %>
<%@ Import Namespace="System.Activities.Statements" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h2>
    <div class="row">
        <div class="col-lg-6">
            <p>
                Docent invoeren:
            </p>
            <form method="post" id="addstudent" name="addstudent">
                <label for="name">Naam</label><br/>
                <input id="name" class="form-control" name="name" type="text" required/>

                <label for="age">Leeftijd</label><br/>
                <input id="age" class="form-control" name="age" type="number" min="10" max="99" required/>

                <label for="school">School</label><br/>
                <input id="school" class="form-control" name="school" type="text" required/>
        
                <label for="mentor">Mentor</label><br/>
                <select id="mentor" class="form-control" name="mentor">
                    <option>Tristan van der Wal</option>
                    <option>Rob Broeren</option>
                    <option>Jos Antens</option>
                </select>
        
                <label for="class">Klas</label><br/>
                <select id="class" class="form-control" name="class">
                    <option>PD-B-18</option>
                    <option>PD-B-17</option>
                    <option>PD-B-16</option>
                </select>
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <%
                
            %>
        </div>
    </div>
</asp:Content>

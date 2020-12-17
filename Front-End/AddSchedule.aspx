<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Front_End.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <%@ Import Namespace="ELO" %>
            <% DateTime now = DateTime.Now; %>
        <h2>Rooster veranderen</h2>
        <label for="teacher">Teacher</label><br/>
        <input id="teacher" class="form-control" name="teacher" type="text" required aria-autocomplete="list"/><br/>

        <label for="subject">Subject</label><br/>
        <input id="subject" class="form-control" name="subject" type="text" required aria-autocomplete="list"/><br/>

        <label for="classroom">Classroom</label><br/>
        <input id="classroom" class="form-control" name="classroom" type="text" required aria-autocomplete="list"/><br/>

        <label for="_class">Class</label><br/>
        <input id="_class" class="form-control" name="_class" type="text" required  aria-autocomplete="list"/><br/>
            
            
        <label for="Date">Date+Time</label><br/>
        <input id="dateTime" class="form-control" name="Date" type="datetime-local" required/><br/>

        <button style="width: auto" type="submit" class="btn btn-success">Voeg Toe</button><br/><br/><br/>
        <br />
    </div>
</asp:Content>
﻿<%@ Page Title="Mentor & Leerlingen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsByClass.aspx.cs" Inherits="Front_End.StudentsByClass" %>
<%@ Import Namespace="ELO" %>
<%@ Import Namespace="Org.BouncyCastle.Ocsp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (!IsPostBack && Request["class"] == null) { %>
    <form method="post" id="classform" name="classform">
        <div class="jelly-form" style="width:356px">
        <label for="class">Selecteer een klas</label>
            <select id="class" name="class" class="form-control">
            <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School))
               { %>
                <option <% if(Request["class"] == _class.UUID) { %>selected <% } %>value="<%: _class.UUID %>"><%: _class.Name %></option>
            <% } %>
        </select><br/><br/>
        <button class="btn btn-success" type="submit">Verstuur</button></div>
    </form>
    <% } %>
    <% if (IsPostBack && Request.Form["mentor"] == null || Request["class"] != null)
       {
           string requestedClass;
           if (Request["class"] != null)
           {
               requestedClass = Request["class"];
           }
           else
           {
               requestedClass = Request.Form["class"];
           }
    
    %>
        <div class="row">
            <div class="col-lg-9">
                <style>
                    td {
                        padding: 10px;
                    }
                    th {
                        padding: 10px;
                    }
                </style>
        
                <h2>Klassenlijst van klas: <%: classManager.GetClassFromDatabase(requestedClass).Name %></h2>
                <table class="table-striped table-bordered styled-table">
                    <thead>
                    <tr>
                        <th>Naam</th>
                        <th>Leeftijd</th>
                        <th>Datum</th>
                        <th>School</th>
                        <th>Rol</th>
                        <th>UserID</th>
                        <th>Mentor</th>
                    </tr>
                    </thead>
                    <tbody>
                    <% foreach (Student student in classManager.GetStudentsInClass(requestedClass)){ %> 
                        <tr>
                            <td><%: student.Name %></td>
                            <td><%: student.Age %></td>
                            <td><%: student.RegistrationDate %></td>
                            <td><%: student.School %></td>
                            <td><%: student.Type %></td>
                            <td><%: student.UserId %></td>
                            <td><% if(student.Mentor != null) { %><%: student.Mentor.Name %> <% } else { %>Onbekend <% } %></td>
                        </tr>     
                    <% } %>
                    </tbody>
                </table>
            </div>
            <div class="col-lg-3">
                <h2>Mentor veranderen</h2>
                <form method="post" name="addmentor" id="addmentor">
                    <div class="jelly-form" style="width:356px">
                    <input type="hidden" value="<%: requestedClass %>" name="class" id="class" class="form-control"/>
                    <label for="mentor">Mentor</label><br/>
                    <select name="mentor" id="mentor" class="form-control">
                        <% Class foundClass = classManager.GetClassFromDatabase(requestedClass); foreach (Teacher mentor in userManager.GetPersonList("Teacher", loggedInPerson.School)) { %>
                            <option <% if(foundClass.Mentor != null && mentor.UserId == foundClass.Mentor.UserId) { %>selected <% } %> value="<%: mentor.UserId %>"><%: mentor.Name %></option>    
                        <% } %>
                    </select><br/>
                    <button type="submit" class="btn btn-info">Verander</button></div>
                    <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
                </form>
            </div>
        </div>
    <% } %>
</asp:Content>

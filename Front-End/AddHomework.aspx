﻿<%@ Page Title="Huiswerk toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHomework.aspx.cs" Inherits="Front_End.AddHomework" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Huiswerk toevoegen</h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addstudent" name="homework">
                    <label for="subject">Vak</label><br/>
                    <div class="jelly-form" style="width:356px">
                    <select id="subject" class="form-control" name="subject" type="text" placeholder="Nederlands" required><br/>
                        <% if (LoggedInTeacher.Subject != null) { %>
                            <option selected value="<%: LoggedInTeacher.Subject.uuid %>"><%: LoggedInTeacher.Subject.Name %></option>
                        <% } else { %>
                            <option disabled selected>Je bent een leraar zonder vak!</option>
                        <% } %>
                    </select>
                    <label for="_class">Klas</label><br/>
                    <select id="_class" class="form-control" name="_class" placeholder="Klas 1B"><br/>

                        <% foreach (Class _class in classManager.GetClassListFromDatabase(LoggedInPerson.School)) { %>
                            <option value ="<%: _class.UUID %>"><%: _class.Name %></option>
                        <% } %>

                    </select><br/>

                    <label for="dueDate">Datum</label><br/>
                    <input id="dueDate" class="form-control" name="dueDate" type="date" required/><br/>
               
                    <label for="istest">Is dit een toets?</label>
                    <input type="checkbox" class="bigger" name="istest" id="istest" /><br/>
                        
                    <label for="forgrade">Krijg je hier een cijfer voor?</label>
                    <input type="checkbox" class="bigger" name="forgrade" id="forgrade" /><br/>

                    <label for="title">Huiswerk</label><br/>
                    <input id="title" class="form-control" name="title" type="text" placeholder="Opdracht 1 tot en met 6" required/><br/>      
                    <br/>

                    <label for="content">Beschrijving</label><br/>
                    <input id="content" class="form-control" name="content" type="text" placeholder="Pagina 22 t/m 25" required/><br/>      
                    <br/>

                    <label for="exp">Te verdienen punten</label><br/>
                    <input id="exp" class="form-control" name="exp" type="number" placeholder="100" required/><br/>      
                    <br/>
                        </div>

                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                </form>
                <asp:Label ID="OutputLabel" runat="server"></asp:Label>
                <%
                
                %>
            </div>
        </div>
    </div>
</asp:Content>

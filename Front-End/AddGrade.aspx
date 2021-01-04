﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="Front_End.AddGrade" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Cijfer Invoeren</h2>
        <div class="row">
            <div class="col-lg-6">
                <% if (!IsPostBack)
                   { %>
                <form method="post" id="selectclass" name="selectclass">
                    <label for="_class">Selecteer een Klas</label><br/>
                    <select id="_class" class="form-control" name="_class">
                        <% foreach (Class _class in classMan.GetClassList())
                           { %>
                            <option><%: _class.Name %></option>
                        <% } %>
                    </select><br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Selecteren</button>
                </form>
                <% } %>
                <% if (IsPostBack && Request.Form["studentName"] == null) { %>
                <form method="post" id="addgrade" name="addgrade">
                    <input type="hidden" value="<%: Request.Form["_class"] %>" name="_class" id="_class" class="form-control"/>
                    <label for="studentName">Naam student</label><br/>
                    <select id="studentName" class="form-control" name="studentName">
                        <% foreach (Student student in userMan.GetStudentList())
                           { %>
                            <option value="<%: student.UserId %>"><%: student.Name %></option>
                        <% } %>
                    </select><br/>

                    <label for="subject">Vak</label><br/>
                    <input id="subject" class="form-control" name="subject" type="text" required/><br/>

                    <label for="date">Datum</label><br/>
                    <input id="date" class="form-control" name="date" type="text" required/><br/>

                    <label for="weight">Weging</label><br/>
                    <input id="weight" class="form-control" name="weight" type="text" required/>  <br/>

                    <label for="grade">Cijfer</label><br/>
                    <input id="grade" class="form-control" name="grade" type="text" required/><br/>
                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Invoeren</button>
                </form>
                <% } %>
            </div>
        </div>
    </div>
    
</asp:Content>

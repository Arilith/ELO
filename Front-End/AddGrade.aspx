<%@ Page Title="Cijfers invoeren" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="Front_End.AddGrade" %>
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
                    <div class="jelly-form" style="width:356px">
                    <select id="_class" class="form-control" name="_class">
                        <% foreach (Class _class in classMan.GetClassListFromDatabase(LoggedInPerson.School))
                           { %>
                            <option value="<%: _class.UUID%>"><%: _class.Name %></option>
                        <% } %>
                    </select><br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Selecteren</button>
                        </div>
                </form>
                <% } %>
                <% if (IsPostBack && Request.Form["studentName"] == null) { %>
                <form method="post" id="addgrade" name="addgrade">
                    <div class="jelly-form" style="width:356px">
                        <input type="hidden" value="<%: Request.Form["_class"] %>" name="_class" id="_class" class="form-control"/>
                        <label for="studentName">Naam student</label><br/>
                        <select id="studentName" class="form-control" name="studentName">
                            <% foreach (Student student in userMan.GetStudentsOfClass(Request.Form["_class"]))
                               { %>
                                <option value="<%: student.UserId %>"><%: student.Name %></option>
                            <% } %>
                        </select><br/>

                        <label for="subject">Vak</label><br/>
                        <select id="subject" class="form-control" name="subject">
                            <% foreach (Subject subject in subjectMan.GetSubjectList(LoggedInPerson.School))
                               { %>
                                <option value="<%: subject.uuid%>"><%: subject.Name %></option>
                            <% } %>
                        </select><br/>
                        
                        <label for="homework">Huiswerk/Toets</label><br/>
                        <select id="homework" class="form-control" name="homework">
                            <% foreach (Homework homework in homeworkManager.GetHomeworkForSubjectFromDB(LoggedInPerson.School, LoggedInTeacher.Subject))
                               { %>
                                <option value="<%: homework.UUID %>"><%: homework.Title %> <% if(homework.IsTest) { %> (TOETS) <% } %></option>
                            <% } %>
                        </select><br/>

                        <label for="weight">Weging</label><br/>
                        <input id="weight" class="form-control" name="weight" type="text" required/>  <br/>

                        <label for="grade">Cijfer</label><br/>
                        <input id="grade" class="form-control" name="grade" type="text" required/><br/>
                        <br/>
                        <button style="width: auto" type="submit" class="btn btn-success">Invoeren</button>
                    </div>
                </form>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>

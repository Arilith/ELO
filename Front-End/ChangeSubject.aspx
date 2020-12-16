<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeSubject.aspx.cs" Inherits="Front_End.ChangeSubject" %>
<%@ Import Namespace="ELO" %>
<%-- <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> --%>
<%--     <h2 draggable="auto"><%: Title %></h2> --%>
<%--     <% if (!IsPostBack) { %> --%>
<%--     <form method="post" id="subjectform" name="subjectform"> --%>
<%--         <label for="subject">Selecteer een vak</label> --%>
<%--         <select id="subject" name="subject" class="form-control"> --%>
<%-- $1$             <% foreach (Subject subject in subjectManager.GetSubjectList(loggedInPerson.School)) #1# --%>
<%-- $1$                { %> #1# --%>
<%-- $1$                 <option value="<%: subject.uuid %>"><%: subject.Name %></option> #1# --%>
<%-- $1$             <% } %> #1# --%>
<%--         </select><br/><br/> --%>
<%--         <button class="btn btn-success" type="submit">Verstuur</button> --%>
<%--     </form> --%>
<%--     <% } %> --%>
<%--     <% if (IsPostBack && Request.Form["mentor"] == null) { %> --%>
<%--         <div class="row"> --%>
<%--             <div class="col-lg-9"> --%>
<%--                 <style> --%>
<%--                     td { --%>
<%--                         padding: 10px; --%>
<%--                     } --%>
<%--                     th { --%>
<%--                         padding: 10px; --%>
<%--                     } --%>
<%--                 </style> --%>
<%--          --%>
<%--                 <h2>Klassenlijst van klas: <%: classManager.GetClassFromDatabase(Request.Form["class"]).Name %></h2> --%>
<%--                 <table class="table-striped table-bordered "> --%>
<%--                     <thead> --%>
<%--                     <tr> --%>
<%--                         <th>Naam</th> --%>
<%--                         <th>Leeftijd</th> --%>
<%--                         <th>Datum</th> --%>
<%--                         <th>School</th> --%>
<%--                         <th>Rol</th> --%>
<%--                         <th>UserID</th> --%>
<%--                         <th>Mentor</th> --%>
<%--                     </tr> --%>
<%--                     </thead> --%>
<%--                     <tbody> --%>
<%--                     <% foreach (Student student in classManager.GetStudentsInClass(Request.Form["class"])){ %>  --%>
<%--                         <tr> --%>
<%--                             <td><%: student.Name %></td> --%>
<%--                             <td><%: student.Age %></td> --%>
<%--                             <td><%: student.RegistrationDate %></td> --%>
<%--                             <td><%: student.School %></td> --%>
<%--                             <td><%: student.Type %></td> --%>
<%--                             <td><%: student.UserId %></td> --%>
<%--                             <td><% if(student.Mentor != null) { %><%: student.Mentor.Name %> <% } else { %>Onbekend <% } %></td> --%>
<%--                         </tr>      --%>
<%--                     <% } %> --%>
<%--                     </tbody> --%>
<%--                 </table> --%>
<%--             </div> --%>
<%--             <div class="col-lg-3"> --%>
<%--                 <h2>Mentor veranderen</h2> --%>
<%--                 <form method="post" name="addmentor" id="addmentor"> --%>
<%--                     <input type="hidden" value="<%: Request.Form["class"] %>" name="class" id="class" class="form-control"/> --%>
<%--                     <label for="mentor">Mentor</label><br/> --%>
<%--                     <select name="mentor" id="mentor" class="form-control"> --%>
<%--                         <% foreach (Teacher mentor in userManager.GetPersonList("Teacher", loggedInPerson.School)) { %> --%>
<%--                             <option value="<%: mentor.UserId %>"><%: mentor.Name %></option>     --%>
<%--                         <% } %> --%>
<%--                     </select><br/> --%>
<%--                     <button type="submit" class="btn btn-info">Verander</button> --%>
<%--                     <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label> --%>
<%--                 </form> --%>
<%--             </div> --%>
<%--         </div> --%>
<%--     <% } %> --%>
<%-- </asp:Content> --%>
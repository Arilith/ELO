<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckAttendance.aspx.cs" Inherits="Front_End.CheckAttendance" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <h2 draggable="auto"><%: Title %></h2>
    <% if (!IsPostBack) { %>
    <form method="post" id="classform" name="classform">
        <label for="class">Selecteer een klas</label>
        <select id="class" name="class" class="form-control">
            <% foreach (Class _class in classManager.GetClassListFromDatabase(LoggedInPerson.School))
               { %>
                <option value="<%: _class.UUID %>"><%: _class.Name %></option>
            <% } %>
        </select><br/><br/>
        <button class="btn btn-success" type="submit">Verstuur</button>
    </form>
    <% } %>
    <% if (IsPostBack && Request.Form["attendance"] == null) { %>
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
        
                <h2>Aanwezigheid van klas: <%: classManager.GetClassFromDatabase(Request.Form["class"]).Name %></h2>
                <table class="table-striped table-bordered ">
                    <thead>
                    <tr>
                    <th>Student</th>
                    <th>Aanwezig </th>
                    <th>Afwezig onwettig </th>
                    <th>Afwezig Wettig</th>
                    <th>Te laat onwettig</th>
                    <th>Te laat wettig</th>
                    <th>Huiswerk vergeten</th>
                    <th>Verwijdering</th>      

                    </tr>
                    </thead>
                    <tbody>
                    $items = $pages->get(1)->children();
                    <% foreach (Student student in classManager.GetStudentsInClass(Request.Form["class"])){ %> 
                    <tr>
                        <td><%: student.Name %></td>
                        <td> <input type="radio" id="present" name="items" value="present"></td>
                        <td> <input type="radio" id="absent" name="items" value="absent"></td>
                        <td> <input type="radio" id="leave" name="RButton" value="leave"></td>
                        <td> <input type="radio" id="late" name="RButton" value="late"></td>
                        <td> <input type="radio" id="lateAllow" name="RButton" value="lateAllow"></td>
                        <td> <input type="checkbox" id="forgot" name="forgot" value="forgot"></td>
                        <td> <input type="checkbox" id="expelled" name="expelled" value="expelled"></td>
                       </tr>     
                    <% } %>
                    </tbody>
                </table>
            </div>
            <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
            <asp:Label ID="OutputLabel" runat="server"></asp:Label>
        </div>
    <% } %>
</asp:Content>

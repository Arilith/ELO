<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckAttendance.aspx.cs" Inherits="Front_End.CheckAttendance" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <h2 draggable="auto"><%: Title %></h2>
    <% if (!IsPostBack) { %>
    <form method="post" id="classform" name="classform">
        <label for="class">Selecteer een klas</label>
        <select id="class" name="class" class="form-control">
            <% foreach (Class _class in classManager.GetClassListFromDatabase(loggedInPerson.School))
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
                    <% foreach (Student student in classManager.GetStudentsInClass(Request.Form["class"])){ %> 
                    <tr>
                        <td><%: student.Name %></td>
                        <td> <input type="checkbox" id="CheckBoxA" name="CheckBoxA" value="Aanwezig"></td>
                        <td> <input type="checkbox" id="CheckBoxAO" name="CheckBoxAO" value="Afwezig Onwettig"></td>
                        <td> <input type="checkbox" id="CheckBoxAW" name="CheckBoxAW" value="Afwezig Wettig"></td>
                        <td> <input type="checkbox" id="CheckBoxTLO" name="CheckBoxTLO" value="Te laat onwettig"></td>
                        <td> <input type="checkbox" id="CheckBoxTLW" name="CheckBoxTLW" value="Te laat wettig"></td>
                        <td> <input type="checkbox" id="CheckBoxHWV" name="CheckBoxHWV" value="Huiswerk vergeten"></td>
                        <td> <input type="checkbox" id="CheckBoxVW" name="CheckBoxVW" value="Verwijdering"></td>
                       </tr>     
                    <% } %>
                    </tbody>
                </table>
            </div>
            
        </div>
    <% } %>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="Front_End.AddGrade" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <h2>Cijfers</h2>
    <div class="row">
        <div class="col-lg-6">
            <p>
               Cijfers:
            </p>
            <form method="post" id="addstudent" name="homework">

                <label for="studentName">Naam student</label><br/>
                <select id="name" class="form-control" name="name">
                    <% foreach (Student student in Manager.userMan.GetStudentList()) {  %>
                        <option><%: student.Name %></option>
                    <% } %>
                </select>

                <label for="subject">Vak</label><br/>
                <input id="subject" class="form-control" name="subject" type="text" required/>

                <label for="_class">Klas</label><br/>
                <select id="_class" class="form-control" name="_class">
                <% foreach (Class _class in Manager.classMan.GetClassList()) {  %>
                        <option><%: _class.Name %></option>
                    <% } %>
                </select>

                <label for="date">Datum</label><br/>
                <input id="date" class="form-control" name="date" type="text" required/>

                <label for="weight">weging</label><br/>
                <input id="weight" class="form-control" name="weight" type="text" required/>  

                <label for="grade">cijfer</label><br/>
                <input id="grade" class="form-control" name="grade" type="text" required/>
                <br/>
                <button style="width: auto" type="submit" class="form-control">voer cijfer in</button>
            </form>
            <%
                
            %>
        </div>
    </div>
</asp:Content>

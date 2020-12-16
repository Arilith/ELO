<%@ Page Title="Huiswerk toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHomework.aspx.cs" Inherits="Front_End.AddHomework" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Huiswerk toevoegen</h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addstudent" name="homework">
                    <label for="subject">Vak</label><br/>
                    <input id="subject" class="form-control" name="subject" type="text" placeholder="Nederlands" required/><br/>

                    <label for="_class">Klas</label><br/>
                    <select id="_class" class="form-control" name="_class" placeholder="Klas 1B"><br/>

                        <% foreach (Class _class in Manager.classMan.GetClassList()) { %>
                            <option><%: _class.Name %></option>
                        <% } %>

                    </select><br/>

                    <label for="dueDate">Datum</label><br/>
                    <input id="dueDate" class="form-control" name="dueDate" type="date" placeholder="16-12-2020" required/><br/>
               

                    <label for="work">Huiswerk</label><br/>
                    <input id="work" class="form-control" name="work" type="text" placeholder="Opdracht 1 tot en met 6" required/><br/>      
                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                </form>
                <asp:Label ID="OutputLabel" runat="server"></asp:Label>
                <%
                
                %>
            </div>
        </div>
    </div>
</asp:Content>

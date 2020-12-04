<%@ Page Title="Huiswerk toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHomework.aspx.cs" Inherits="Front_End.AddHomework" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
       <h2>Huiswerk
	</h2>
    <div class="row">
        <div class="col-lg-6">
            <p>
                Huiswerk:
            </p>
            <form method="post" id="addstudent" name="homework">
                <label for="subject">Vak</label><br/>
                <input id="subject" class="form-control" name="subject" type="text" required/>

                <label for="_class">Klas</label><br/>
                <select id="_class" class="form-control" name="_class">

                   <% foreach (Class _class in Manager.classMan.GetClassList()) { %>
                        <option><%: _class.Name %></option>
                    <% } %>

                </select>

                <label for="dueDate">Datum</label><br/>
                <input id="dueDate" class="form-control" name="dueDate" type="text" required/>

                <label for="work">Huiswerk</label><br/>
                <input id="work" class="form-control" name="work" type="text" required/>      
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <asp:Label ID="OutputLabel" runat="server"></asp:Label>
            <%
                
            %>
        </div>
    </div>
</asp:Content>

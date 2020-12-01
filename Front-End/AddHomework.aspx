<%@ Page Title="Huiswerk toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHomework.aspx.cs" Inherits="Front_End.AddHomework" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
	<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <h2>Huiswerk</h2>
    <div class="row">
        <div class="col-lg-6">
            <p>
                Huiswerk:
            </p>
            <form method="post" id="addstudent" name="homework">
                <label for="subject">Vak</label><br/>
                <input id="subject" class="form-control" name="subject" type="text" required/>

                <label for="group">Klas</label><br/>
                <select id="group" class="form-control" name="group">
                    <option>PD-B-18</option>
                    <option>PD-B-17</option>
                    <option>PD-B-16</option>
                </select>

                <label for="dueDate">Datum</label><br/>
                <input id="dueDate" class="form-control" name="dueDate" type="text" required/>

                <label for="homework">Huiswerk</label><br/>
                <input id="homework" class="form-control" name="homework" type="text" required/>      
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <%
                
            %>
        </div>
    </div>
</asp:Content>

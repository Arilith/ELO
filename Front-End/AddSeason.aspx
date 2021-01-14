<%@ Page Title="Seizoen toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSeason.aspx.cs" Inherits="Front_End.AddSeason" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Seizoen toevoegen</h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addstudent" name="homework">
                    <div class="jelly-form">
                    <label for="startDate">Start Datum</label><br/>
                    <input id="startDate" class="form-control" name="startdate" type="date" required/><br/>

                    <label for="endDate">Eind Datum</label><br/>
                    <input id="endDate" class="form-control" name="enddate" type="date" required/><br/>
               

                    <label for="seasonname">Seizoen Naam</label><br/>
                    <input id="seasonname" class="form-control" name="seasonname" type="text"  required/><br/>      
                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                    </div>
                </form>
                <asp:Label ID="OutputLabel" runat="server"></asp:Label>
                <%
                
                %>
            </div>
        </div>
    </div>
</asp:Content>

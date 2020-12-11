<%@ Page Title="Klas aanmaken" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="Front_End.AddClass" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-lg-6">
            <form method="post" id="addteacher" name="addteacher">
                <label for="name">Klasnaam</label><br/>
                <input id="name" class="form-control" name="name" type="text" required/>
                <br/>
                <label for="cluster">Cluster</label><br/>
                <input id="cluster" class="form-control" name="cluster" type="text" required/>
                <br/>
                <label for="leshuis">Leshuis</label><br/>
                <input id="leshuis" class="form-control" name="leshuis" type="text" required/>
                <br/>
                <label for="stream">Stroom</label><br/>
                <input id="stream" class="form-control" name="stream" type="text" required/>
                <br/>
                <label for="studyyear">Studiejaar</label><br/>
                <input id="studyyear" class="form-control" name="studyyear" type="number" min="1" max="6" required/>
                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
        </div>
        <asp:Label ID="OutputLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
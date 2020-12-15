<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLeermiddel.aspx.cs" Inherits="Front_End.AddLeermiddel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-lg-6">
            <form method="post" id="addleermiddel" name="addleermiddel">
                <label for="subject">vak</label><br/>
                <input id="subject" class="form-control" name="subject" type="text" required/>

                <label for="niveau">niveau</label><br/>
                <input id="niveau" class="form-control" name="niveau" type="text" required/>

                <label for="leerjaar">leerjaar</label><br/>
                <input id="leerjaar" class="form-control" name="leerjaar" type="text" required/>

                <label for="link">link</label><br/>
                <input id="link" class="form-control" name="link" type="text" required/>

                <label for="description">beschrijving</label><br/>
                <input id="description" class="form-control" name="description" type="text" required/>        

                <br/>
                <button style="width: auto" type="submit" class="form-control">Verstuur</button>
            </form>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>


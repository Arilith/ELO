<%@ Page Title="Leermiddel Toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLeermiddel.aspx.cs" Inherits="Front_End.AddLeermiddel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2><%: Title %></h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addleermiddel" name="addleermiddel">
                    <label for="subject">Vak</label><br/>
                    <input id="subject" class="form-control" name="subject" type="text" required/><br/>

                    <label for="niveau">Niveau</label><br/>
                    <input id="niveau" class="form-control" name="niveau" type="text" required/><br/>

                    <label for="leerjaar">Leerjaar</label><br/>
                    <input id="leerjaar" class="form-control" name="leerjaar" type="text" required/><br/>

                    <label for="link">Link</label><br/>
                    <input id="link" class="form-control" name="link" type="text" required/><br/>

                    <label for="description">Beschrijving</label><br/>
                    <input id="description" class="form-control" name="description" type="text" required/> <br/>       

                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                </form>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    
</asp:Content>


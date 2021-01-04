<%@ Page Title="Beloningen toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHomework.aspx.cs" Inherits="Front_End.AddHomework" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Beloningen toevoegen</h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addrewards" name="reward">
                    <label for="reward">Reward</label><br/>
                    <input id="reward" class="form-control" name="reward" type="text" placeholder="Kortingsbon" required/><br/>

                    <label for="rewardDescription">Beschrijving</label><br/>
                    <input id="rewardDescription" class="form-control" name="rewardDescription" type="text" placeholder="10% korting op een broodje" required/><br/>
               

                    <label for="imageURL">Afbeelding</label><br/>
                    <input id="imageURL" class="form-control" name="imageURL" type="img" required/><br/>      
                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                </form>
                <asp:Label ID="OutputLabel" runat="server"></asp:Label>             
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Beloningen toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRewards.aspx.cs" Inherits="Front_End.AddRewards" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2>Beloningen toevoegen</h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addrewards" name="reward">
                    <div class="jelly-form">
                        <label for="title">Reward</label><br/>
                        <input id="title" class="form-control" name="title" type="text" placeholder="Kortingsbon" required/><br/>
                        <label for="rewardDescription">Beschrijving</label><br/>
                        <input id="rewardDescription" class="form-control" name="rewardDescription" type="text" placeholder="10% korting op een broodje" required/><br/>
                        <label for="imageURL">Afbeelding URL</label><br/>
                        <input id="imageURL" class="form-control" name="imageURL" type="text" /><br/>
                        <label for="requiredLevel">Gekoppeld Level</label><br/>
                        <select id="levelUUID" name="levelUUID" class="form-control">
                            <% foreach(Level level in levelManager.GetLevelListFromDB(loggedInPerson.School)) { %>
                                <option value="<%: level.UUID %>"><%: level.LevelNumber %> (Seizoen: <%: level.ThisSeason %>)</option>
                            <% } %>
                        </select>
                        <br/>
                        <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                    </div>
                </form>
                <asp:Label ID="OutputLabel" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

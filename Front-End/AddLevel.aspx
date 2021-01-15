<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLevel.aspx.cs" Inherits="Front_End.AddLevel" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2><%: Title %></h2>
        <div class="row">
            <div class="col-lg-6">
                <form method="post" id="addteacher" name="addlevel">
                    <label for="levelnummer">Aantal levels</label><br/>
                    <input id="levelnummer" class="form-control" name="levelnummer" type="number" placeholder="1 t/m 100" min="1" max="100" required/>
                    <br/>
                    <label for="requiredexp">Benodigde XP voor max. level</label><br/>
                    <input id="requiredexp" class="form-control" name="requiredexp" type="number" placeholder="10000" required/>
                    <br/>
                    <label for="season">Seizoen</label><br/>
                    <select id="season" class="form-control" name="season" required>
                        <option selected disabled hidden>Seizoen 1</option>
                        <% foreach (Season season in seasonManager.getSeasonListFromDB(loggedInPerson.School))
                           { %>
                            <option value="<%: season.UUID %>"><%: season.SeasonName %>(<%:season.StartDate %> t/m <%:season.EndDate %>)</option>
                        <% } %>
                    </select>
                    <br/>
                    <button style="width: auto" type="submit" class="btn btn-success">Verstuur</button>
                </form>
            </div>
            <asp:Label ID="OutputLabel" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

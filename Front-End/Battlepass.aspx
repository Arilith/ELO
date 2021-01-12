<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BattlePass.aspx.cs" Inherits="Front_End.BattlePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Seizoen</h2>
    <style>
        td {
            padding: 10px;
        }

        th {
            padding: 10px;
        }

        table, th, td {
            border: 1px solid gray !important;
        }
    </style>
    <div class="row">
        <div class="col-lg-1"></div>
        <%
            Dictionary<Level, Reward>.KeyCollection levelKeys = battlePassItems.Keys;
            foreach (Level level in levelKeys)
            {

        %>
        <a href="#" class="list-group-item active">
            <h4 class="list-group-item-heading"></h4>
            <p class="list-group-item-text">
                <b><%: level.LevelNumber %></b><br />
            </p>
        </a>
        <a href="#" class="list-group-item">
            <h4 class="list-group-item-heading"></h4>
            <p class="list-group-item-text">
                <%-- <%: level.rewardUUID  Hier moet de reward komen  %> --%>
                <br />
                <%: level.RequiredExp%>
            </p>
        </a>
        <br />
    </div>

    <% } %>
    <div class="col-lg-1"></div>
</asp:Content>
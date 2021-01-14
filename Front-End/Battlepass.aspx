<%@ Page Title="Puntenoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BattlePass.aspx.cs" Inherits="Front_End.BattlePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Puntenoverzicht</h2>

    <div class="row">
        <div class="col-lg-4">
            <div class="container-info2">
                <div class="container-title">Top 10 OBA1 aantal punten</div>
                    <div class="container-content">
                    <div class="row">
                    <b>Sem</b>
                        <div class="container">
                            <div class="skills sem">100</div>
                        </div>

                    <b>Sam</b>
                        <div class="container">
                            <div class="skills sam">95</div>
                        </div>

                    <b>Joep</b>
                        <div class="container">
                            <div class="skills joep">92</div>
                        </div>

                    <b>Henk</b>
                        <div class="container">
                            <div class="skills henk">87</div>
                        </div>
                    <b>Pieter</b>
                        <div class="container">
                            <div class="skills pieter">86</div>
                        </div>
                    <b>Jan-piet</b>
                        <div class="container">
                            <div class="skills jan-piet">79</div>
                        </div>
                    <b>Abigail</b>
                        <div class="container">
                            <div class="skills abigail">76</div>
                        </div>
                    <b>Joey</b>
                        <div class="container">
                            <div class="skills joey">75</div>
                        </div>
                    <b>Daniëlle</b>
                        <div class="container">
                            <div class="skills danielle">74</div>
                        </div>
                    <b>May</b>
                        <div class="container">
                            <div class="skills may">72</div>
                        </div>
                        </div>
                        </div>
                </div>
            </div>
        <div class="col-lg-4" style="margin-left: 10%">
            <div class="container-info2">
                <div class="container-title">Rewards</div>
                <div class="container-content">
                <div class="row">
                    <input type="checkbox" checked="checked">
                    <label>50% korting op een product bij de cafetaria van school - 150 punten</label>
                    <br>
                    <input type="checkbox">
                    <label>Een les vrijstelling krijgen voor een vak waarvoor je een 8,0 of hoger staat (Mag niet gebruikt worden bij nieuwe uitleg!) - 500 punten</label>
                    <br />
                    <input type="checkbox">
                    <label>Geen aantekening krijgen in Studycluster met huiswerk vergeten - 400 punten</label>
                    <br /><br />
                    <button style="width: auto" type="submit" class="btn btn-success">Claim reward</button>
                </div>
                </div>
            </div>
                <div class="container-info2">
                <div class="container-title">Laatst behaalde punten</div>
                <div class="container-content">
                <div class="row">
                    <b>Duits - huiswerk week 2 - 10/15 punten<br><br />
                    Engels - Opdracht 15 en 16 over grammatica - 3/8 punten<br /><br />
                    Wiskunde - Huiswerk goniometrie - 16/16 punten</b>

                    </div>
                    </div>
        </div>
        </div>
        </div>
    <div class="outer">
        <%
            Dictionary<Level, Reward>.KeyCollection levelKeys = GetBattlePass(loggedInPerson.School).Keys;
            foreach (Level level in levelKeys)
            {

        %>     
            <div class="container-info2 normal">       
            <div class="container-title">Level <%: level.LevelNumber %></div><br />
            <div class="container-content">
                    <div class="row">
            <b>Reward: <% Reward foundReward = rewardMan.FindReward(level.rewardUUID); %>
                <%: foundReward.Title %>
                <br />
                Xp nodig voor volgend level: <%: level.RequiredExp %></b>
                    </div>
                </div>
              </div>
          
           
    <% } %>
        </div>
</asp:Content>
<%@ Page Title="Puntenoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BattlePass.aspx.cs" Inherits="Front_End.BattlePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Puntenoverzicht</h2>
    <%//TOP 10 UIT je klas %>
    <%// pattlepass levels %>
    <style>
        .outer div {
            width: 20% !important;
        }

        .container-info2 .container-title {
            margin-bottom: 0px !important;
        }
    </style>
    <div class="row">
        <div class="col-lg-12">
            <div class="outer" style="margin-left: 25px;">
                <%
                    int maxExp = 0;
                    int i = 0;
                    Dictionary<Level, Reward>.KeyCollection levelKeys = GetBattlePass(loggedInPerson.School).Keys;
                    foreach (Level level in levelKeys)
                    {
                        i++;
                        maxExp = level.RequiredExp;
                %>
                <div class="container-info2 normal">
                    <div class="container-title">Level <%: level.LevelNumber %></div>
                    <br />
                    <div class="container-content" style="width: 100% !important;">
                        <div class="row" style="width: 100% !important;">
                            <div class="col-lg-6" style="width: 50% !important;">
                                <b>Reward: <% Reward foundReward = rewardMan.FindReward(level.rewardUUID); %>
                                    <%: foundReward.Title %>
                                    <br />
                                    Benodigd XP: <%: level.RequiredExp %> 
                                    <% bool hasGotLevel = false;
                                       if (loggedInPerson.Exp >= level.RequiredExp)
                                       {
                                           hasGotLevel = true; %>
                                        <b> Behaald!</b>
                                    <% } %>
                                </b> <br/><br/>
                                <% if(hasGotLevel && !rewardsToHide.Contains(i.ToString())) { %><form method="POST"><input type="hidden" value="<%: foundReward.UUID %>" name="rewardUUID" id="rewardUUID" /><input type="hidden" value="<%: i %>" name="rewardID" id="rewardID"/><button type="submit" class="btn btn-info">Claim!</button></form><% } else if(rewardsToHide.Contains(i.ToString())) { %> 
                                    <a href="#" class="btn btn-success">Geclaimed!</a>
                                <% } else { %>
                                    <a href="#" class="btn btn-danger">Nog <%: level.RequiredExp - loggedInPerson.Exp %>XP nodig!</a>
                                <% } %>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <% } %>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="container-info2">
                <div class="container-title">Top 5 van <%:loggedInStudent.PartOfClass.Name %></div>
                <div class="container-content">
                    <div class="row">
                        <%
                            List<Student> sortedStudents = userMan.GetStudentsOfClass(loggedInStudent.PartOfClass.UUID, 5).OrderByDescending(o => o.Exp).ToList();
                            //voor iedere Student in de klas van de ingelogde persoon
                            foreach (Student student in sortedStudents)
                            {
                        %><b><%:student.Name %></b>
                        <div class="container">
                            <% int xppercent = Convert.ToInt32(Math.Round((double)student.Exp / maxExp * 100, 0)); %>
                            <div class="skills" style="width: <%: xppercent %>%"><%:student.Exp %></div>
                        </div>
                        <% }%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="margin-left: 10%">
            <div class="container-info2">
                <div class="container-title">Eerder geclaimde rewards</div>
                <div class="container-content">
                    <div class="row">
                        <% foreach (Reward reward in rewardMan.GetStudentRewards(loggedInPerson.UserId))
                           { %>
                            <b><%: reward.Title %></b><br/>
                            <i><%: reward.RewardDescription %></i><br><br/>
                        <% } %>
                    </div>
                </div>
            </div>

            <%-- <div class="container-info2"> --%>
            <%--     <div class="container-title">Laatst behaalde punten</div> --%>
            <%--     <div class="container-content"> --%>
            <%--         <div class="row"> --%>
            <%--             <b>Duits - huiswerk week 2 - 10/15 punten<br> --%>
            <%--                 <br /> --%>
            <%--                 Engels - Opdracht 15 en 16 over grammatica - 3/8 punten<br /> --%>
            <%--                 <br /> --%>
            <%--                 Wiskunde - Huiswerk goniometrie - 16/16 punten</b> --%>
            <%--         </div> --%>
            <%--     </div> --%>
            <%-- </div> --%>
        </div>
    </div>
</asp:Content>
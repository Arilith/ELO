<%@ Page Title="Puntenoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BattlePass.aspx.cs" Inherits="Front_End.BattlePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Puntenoverzicht</h2>
    <%//TOP 10 UIT je klas %>
    <%// pattlepass levels %>
    <div class="row">
        <div class="col-lg-12">
            <div class="outer" style="margin-left: 25px;">
                <%
                    Dictionary<Level, Reward>.KeyCollection levelKeys = GetBattlePass(loggedInPerson.School).Keys;
                    foreach (Level level in levelKeys)
                    {

                %>
                <div class="container-info2 normal">
                    <div class="container-title">Level <%: level.LevelNumber %></div>
                    <br />
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
        </div>
        <div class="col-lg-4">
            <div class="container-info2">
                <div class="container-title">Top 5 van <%:loggedInStudent.PartOfClass.Name %></div>
                <div class="container-content">
                    <div class="row">
                        <%
                            List<Student> sortedStudents = userMan.GetStudentsOfClass(loggedInStudent.PartOfClass.UUID).OrderByDescending(o => o.Exp).ToList();
                            //voor iedere Student in de klas van de ingelogde persoon
                            foreach (Student student in sortedStudents)
                            {
                        %><b><%:student.Name %></b>
                        <div class="container">
                            <div class="skills sam"><%:student.Exp %></div>
                        </div>
                        <% }%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="margin-left: 10%">
            <div class="container-info2">
                <div class="container-title">Rewards</div>
                <div class="container-content">
                    <div class="row">
                        <% Dictionary<Level, Reward>.KeyCollection rewardKeys = GetBattlePass(loggedInPerson.School).Keys;
                           foreach (Level level in rewardKeys)
                           { %>
                        <input type="checkbox" checked="checked">
                        <label>50% korting op een product bij de cafetaria van school - 150 punten</label>
                        <br>
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
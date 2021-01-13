﻿<%@ Page Title="Hoofdpagina" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="Front_End.StudentHome" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/11f866fbe1.js" crossorigin="anonymous"></script>
    <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
    </meta>
    <div class="row">
        <div class="col-lg-4">
            <a href="Schedule.aspx"><div class="container-info">
                <div class="container-title">Volgend uur</div>
                <div class="container-content">
                    <div class="row">
                        <div class="col-lg-3"><img src="Content/Pictures/Hoofd_leraar.jpg" style="border-radius:50%; width: 65px; "/></div>
                        <div class="col-lg-9">
                            Engels <i class="fas fa-flag-usa"></i> - E16<br/>
                            <b>HW: Opdracht 5 tm 8<%  %></b>
                        </div>
                    </div>
                </div>
            </div>
                </a>
            <a href="UploadFile.aspx">
            <div class="container-info">
                <div class="container-title">Opdrachten</div>
                 <div class="container-content">
                    <div class="row">
                            <b style="left:50px; position:absolute">Engels <i class="fas fa-flag-usa"></i> - Inleverdatum 07-01-2021</b><br/><br />
                            <p class="middle">Maak de online opdracht over werkwoorden op www.ofcourse.nl</p>
                    </div>
                </div>
            </div>
                </a>
        </div>
        <div class="col-lg-4">
            <a href="Gradelist.aspx">
            <div class="container-info">
                <div class="container-title">Laatste cijfers</div>
                <div class="container-content">
                    <div class="row">
                        <%
                            // deze loop laat d ingelogde student zijn/haar 3 laatst behaalde cijfers zien
                            gradeMan = new GradeMan();
                            foreach (Grade grade in gradeMan.GetRecentGrades(loggedInStudent.UserId, 3))
                            {
                                string gradeSubject = grade.subject.Name;

                                homeworkMan = new HwMan();
                                Homework returnHomework = homeworkMan.GetHomeworkFromDB(grade.Homework.UUID);
                                homeworkMan = null;
                                string gradeDescription = returnHomework.Title;

                                string gradeGrade = Convert.ToString(Math.Round(grade.grade, 3));

                                subjectMan = new SubjectManager();
                                Subject returnSubject = subjectMan.FindSubjectInDatabase(grade.subject.uuid);
                                subjectMan = null;
                                string insertIcon = returnSubject.icon;
                        %>
                                <b class="middle"><%: gradeSubject %> <i class="fas <%:insertIcon%>"></i> - <%: gradeDescription %> - <%: gradeGrade %></b><br />
                            <% } %>
                    </div>
                </div>
            </div>
                </a>
            <a href="HomeworkList.aspx">
            <div class="container-info">
                <div class="container-title">3 toetsen deze week</div>
                <div class="container-content">
                    <div class="row">
                            <b class="middle">Duits <i class="fas fa-beer"></i> - Boektoets! Denk aan het meenemen van het boek!</b><br /><br />
                            <b class="middle">Geschiedenis <i class="fas fa-landmark"></i> - SO tweede wereldoorlog</b><br /><br />
                            <b class="middle">Natuurkunde <i class="fas fa-broadcast-tower"></i> - Toets optica</b><br />
                    </div>
                </div>
                </div>
                </a>
        </div>
        <div class="col-lg-4">
            <a href="#">
            <div class="container-info">
                <div class="container-title">Meldingen</div>
                <div class="container-content">
                    <div class="message-holder">
                        <div class="message">
                            <div class="message-title">Aula Gesloten</div>
                            <div class="message-content">M. Hendriks <br/> <br/> Volgende week (7dec - 14dec) is de aula gesloten i.v.m. de toetsweek. Eten kan... </div>
                        </div>
                        <div class="message">
                            <div class="message-title">Aanmelden Romereis</div>
                            <div class="message-content">M. Veldman <br/> <br/> Beste leerlingen klassieke talen, het aanmelden voor de Romereis kan nog... </div>
                        </div>
                    </div>
                </div>
            </div>
                </a>
        </div>
    </div>
</asp:Content>

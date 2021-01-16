<%@ Page Title="Hoofdpagina" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="Front_End.StudentHome" %>
<%@ Import Namespace="ELO" %>
<%@ Import Namespace="Newtonsoft.Json.Linq" %>
<%@ Import Namespace="Org.BouncyCastle.Crypto.Digests" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/11f866fbe1.js" crossorigin="anonymous"></script>
    <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
    </meta>
    <div class="row">
        <div class="col-lg-4">
            <div class="container-info">
                <div class="container-title">Vandaag</div>
                <div class="container-content">
                    <div class="row">
                        <%
                            DateTime today = DateTime.Today;
                            if (todayMan.GetAppointmentsOfToday(loggedInStudent, today).Count != 0)
                            {
                                List<Appointment> todaysLessons = todayMan.GetAppointmentsOfToday(loggedInStudent, today);
                                foreach (Appointment appointment in todaysLessons)
                                {
                                    string insertHomeworkTitle;
                                    Homework returnHomework = appointment.homework;

                                    string insertClassroom = appointment.classroom;
                                    string insertSubjectName = appointment.subject;


                                    if (appointment.homework == null)
                                    {
                                        insertHomeworkTitle = "Geen huiswerk";
                                    }
                                    else {insertHomeworkTitle = returnHomework.Title;}

                        %><div class="col-lg-12"><%: insertSubjectName %>  - <%: insertClassroom %><br/><b>HW: <%: insertHomeworkTitle %><% %></b><br/></div><%

                                }
                            }
                            else
                            {
                                %> Je hebt vandaag geen les. <%
                            }%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="container-info">
                <div class="container-title">Laatste cijfers</div>
                <div class="container-content">
                    <div class="row">
                        <%
                            // deze loop laat d ingelogde student zijn/haar 3 laatst behaalde cijfers zien
                            List<Grade> getRecentGradeList = gradeMan.GetRecentGrades(loggedInStudent.UserId, 3);
                            if (getRecentGradeList.Count >= 1)
                            {

                                foreach (Grade grade in gradeMan.GetRecentGrades(loggedInStudent.UserId, 3))
                                {
                                    string gradeSubject = grade.subject.Name;

                                    Homework returnHomework = homeworkMan.GetHomeworkFromDB(grade.Homework.UUID);

                                    string gradeDescription = returnHomework.Title;

                                    string gradeGrade = Convert.ToString(Math.Round(grade.grade, 3));

                                    Subject returnSubject = subjectMan.FindSubjectInDatabase(grade.subject.uuid);

                                    string insertIcon = returnSubject.icon;

%>
                                <b class="middle"><%: gradeSubject %> <i class="fas <%: insertIcon %>"></i> - <%: gradeDescription %> - <%: gradeGrade %></b><br />
                            <% } %>
                        <% } %>
                            <%else
                            {%>
                                <b>Je hebt nog geen cijfers behaald.</b>
                        <% }%>
                    </div>
                </div>
            </div>
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
        </div>
        <div class="col-lg-4">
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
        </div>
    </div>
</asp:Content>

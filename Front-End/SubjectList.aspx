<%@ Page Title="Vakkenlijst" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectList.aspx.cs" Inherits="Front_End.SubjectList" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/11f866fbe1.js" crossorigin="anonymous"></script>
    <h2 draggable="auto"><%: Title %></h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
    </style>
    <div class="row">
        <div class="col-lg-4">
            <div class="container-info2 normal">
                <div class="container-title">Engels <i class="fas fa-flag-usa"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>W. Kortooms - KOW - OBA1</b>
                        <p>Huiswerk: Maak opdracht 15 en 16 en lees pagina 21 in het bronnenboek</p>
                    </div>
                    </div>
                </div>
            <div class="container-info2 normal">
                <div class="container-title">Scheikunde <i class="fas fa-flask"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>N. Visser - VIN - SCK1</b>
                        <p>Huiswerk: Maak paragraaf 5.2, behalve de plusopdrachten</p>
                    </div>
                </div>
            </div>
            <div class="container-info2 normal">
                <div class="container-title">Geschiedenis <i class="fas fa-landmark"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>T. De Jong - JOT - OBA1</b>
                        <p>Huiswerk: SO Tweede Wereldoorlog</p>
                    </div>
                    </div>
                </div>
            </div>
        <div class="col-lg-4">
            <div class="container-info2 normal">
                <div class="container-title">Wiskunde <i class="fas fa-square-root-alt"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>M. Jacobs - JAM - WIB2</b>
                        <p>Huiswerk: Leer de theorie van meetkunde, maak opdrachten 27 tm 34</p>
                    </div>
                </div>
            </div>
            <div class="container-info2 normal">
                <div class="container-title">Natuurkunde <i class="fas fa-broadcast-tower"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>J. Bourgonjen - BOJ - NAT3</b>
                        <p>Huiswerk: Bestudeer de theorie van radiogolven op pagina 12 en 13, maak opdrachten van paragraaf 2.2</p>
                    </div>
                </div>
            </div>
            <div class="container-info2 normal">
                <div class="container-title">Aardrijkskunde <i class="fas fa-globe-europe"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>M. Van den Broek - BRM - OBA1</b>
                        <p>Huiswerk: Leer waterkringloop en maak opdracht 29 en 30</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="container-info2 normal">
                <div class="container-title">Nederlands <i class="fas fa-bicycle"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>K. Van Driel - DRK - NETL1</b>
                        <p>Huiswerk: Maak opdracht 15 en 16 van Nieuw Nederlands. Huiswerkcontrole!</p>
                    </div>
                </div>
            </div>
            <div class="container-info2 normal">
                <div class="container-title">Duits <i class="fas fa-beer"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>M. Hendriks - HEM - OBA1</b>
                        <p>Huiswerk: Boektoets! Neem je boek mee!</p>
                    </div>
                </div>
            </div>
            <div class="container-info2 normal">
                <div class="container-title">Gym <i class="fas fa-running"></i></div>
                <div class="container-content">
                    <div class="row">
                        <b>F. Roosen - ROF - OBA1</b>
                        <p>Huiswerk: -</p>
                    </div>
                </div>
            </div>
        </div>
    <div class="row">
       
<%--         <div class="col-lg-6"> --%>
<%--             <% foreach (Subject subject in Manager.subjectMan.GetSubjectList()) { %> --%>
<%--                 Lerarenlijst voor <%: subject.Name %> --%>
<%--                 <table class="table-striped table-bordered "> --%>
<%--                     <thead> --%>
<%--                     <tr> --%>
<%--                         <th>Naam leraar</th> --%>
<%--                         <th>School leraar</th> --%>
<%--                     </tr> --%>
<%--                     </thead> --%>
<%--                     <tbody> --%>
<%--                     <% foreach (Teacher teacher in Manager.subjectMan.GetTeacherListBySubject(subject)) --%>
<%--                        { %>  --%>
<%--                         <tr> --%>
<%--                             <td><%: teacher.Name %></td> --%>
<%--                             <td><%: teacher.School %></td> --%>
<%--                         </tr>      --%>
<%--                     <% } %> --%>
<%--                     </tbody> --%>
<%--                 </table><br /><br /> --%>
<%--             <% }  %> --%>
<%--         </div> --%>
    </div>
    
</asp:Content>

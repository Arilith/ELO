﻿<%@ Page Title="Vakkenlijst" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectList.aspx.cs" Inherits="Front_End.SubjectList" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet"/>
    <h2 draggable="auto"><%: Title %></h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
    </style>
    <h3>Vak toevoegen</h3>
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

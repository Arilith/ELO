<%@ Page Title="Cijferlijst" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GradeList.aspx.cs" Inherits="Front_End.GradeList" %>
<%@ Import Namespace="ELO" %>
<%@ Import Namespace="Microsoft.Ajax.Utilities" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
         <script src="https://kit.fontawesome.com/11f866fbe1.js" crossorigin="anonymous"></script>
    <h2 draggable="auto">Cijferlijst</h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
    </style>
    <table class="styled-table">
        <thead>
            <tr class="head-table">
                <th>Vak</th>
                <th>HW 1</th>
                <th>HW 2</th>
                <th>HW 3</th>
                <th>HW 4</th>
                <th>HW 5</th>
                <th>SO 1</th>
                <th>SO 2</th>
                <th>T 1</th>
                <th>T 2</th>
                <th>T 3</th>
                <th>T 4</th>
                <th>T 5</th>
                <th>Rapport 1</th>
                <th>Rapport 2</th>
                <th>Rapport 3</th>
                <th>Eind</th>
            </tr>
            </thead>
        <tbody>
            <tr class="odd">
                <th>Nederlands <i class="fas fa-bicycle"></i></th>
                <th>5,7</th>
                <th class="red">5,4</th>
                <th>9,6</th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>5,8</th>
                <th>10,0</th>
                <th></th>
                <th></th>
                <th></th>
                <th>7,3</th>
                <th>6,7</th>
                <th></th>
                <th>7,3</th>
            </tr>
            <tr>
                <th>Wiskunde <i class="fas fa-square-root-alt"></i></th>
                <th class="red">5,4</th>
                <th>7,9</th>
                <th>8,3</th>
                 <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>7,8</th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>8,1</th>
                <th>7,9</th>
                <th></th>
                <th>8,0</th>                                
            </tr>
            <tr class="odd">
                <th>Engels <i class="fas fa-flag-usa"></i></th>
                <th>10,0</th>
                <th>9,5</th>
                <th></th>
                 <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>8,3</th>
                <th>6,1</th>
                <th></th>
                <th></th>
                <th></th>
                <th>10,0</th>
                <th>9,2</th>
                <th></th>
                <th>9,4</th>           
            </tr>
            <tr>
                <th>Scheikunde <i class="fas fa-flask"></i></th>
                <th class="red">3,2</th>
                <th></th>
                <th></th>
                 <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>7,8</th>
                <th>8,8</th>
                <th>7,7</th>
                <th></th>
                <th></th>
                <th>6,9</th>
                <th>8,5</th>
                <th></th>
                <th>7,8</th>  
            </tr>
            <tr class="odd">
                <th>Duits <i class="fas fa-beer"></i></th>
                <th>6,3</th>
                <th>7,9</th>
                <th>8,3</th>
                 <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th>7,8</th>
                <th>8,2</th>
                <th></th>
                <th></th>
                <th></th>
                <th>7,4</th>
                <th>9,1</th>
                <th></th>
                <th>8,3</th> 
            </tr>
        </tbody>
    </table>
    <%
        List<Grade> gradeList = gradeMan.GetGradeListFromDatabase(LoggedInPerson.UserId);

        List<Grade> distinctSubjects = new List<Grade>();

        distinctSubjects = gradeList.DistinctBy(x => x.subject.Name).ToList();

        foreach (Grade grade in distinctSubjects)
        { %>
        <h2><%: grade.subject.Name %> <i class="fa <%: grade.subject.icon %>"></i></h2>
        <table class="styled-table">
            <thead>
            <tr class="head-table">
                <th>Cijfer</th>
                <th>Datum</th>
                <th>Huiswerk</th>
                <th>Verdiend XP</th>
                <th>Weging</th>
                <th>Gemiddelde na cijfer</th>
            </tr>
            </thead>
            <tbody>
                <% int totalweight = 0;
                   double totalGrade = 0;
                   double totalGradesWithWeight = 0; foreach(Grade fetchedGrade in gradeList) {
                    if(fetchedGrade.subject.Name == grade.subject.Name) {
                        int i = 0;
                        totalGradesWithWeight += fetchedGrade.grade * fetchedGrade.weight;
                        totalweight += fetchedGrade.weight;
                %>
                        <tr class="<%: i % 2 == 0 ? "Odd" : "" %>">
                            <td class="<%: fetchedGrade.grade < 55 ? "red" : ""  %>"><%: fetchedGrade.grade / 10 %></td>
                            <td><%: fetchedGrade.date %></td>
                            <td><%: fetchedGrade.Homework.Title %></td>
                            <td><b><%: fetchedGrade.Homework.Exp * (fetchedGrade.grade / 100) %></b></td>
                            <td><%: fetchedGrade.weight %></td>
                            <td><div class="pull-right"></div><%: Math.Round((totalGradesWithWeight / totalweight) / 10, 2) %></td>
                        </tr>
                    <% i++; } %>
                <% } %>
            </tbody>
        </table>        
    <% } %>
    
</asp:Content>


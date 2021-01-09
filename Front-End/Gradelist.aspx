<%@ Page Title="Cijferlijst" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GradeList.aspx.cs" Inherits="Front_End.GradeList" %>
<%@ Import Namespace="ELO" %>
    
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
    
    <h2 draggable="auto">Cijferlijst</h2>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }

        table, th, td {
            border:1px solid gray;
        }
    </style>
    <table>
        <thead>
            <tr class="head-table">
                <th></th>
                <th>SO 1</th>
                <th>SO 2</th>
                <th>SO 3</th>
                <th>SO 4</th>
                <th>SO 5</th>
                <th>SO 6</th>
                <th>SO 7</th>
                <th>T 1</th>
                <th>T 2</th>
                <th>T 3</th>
                <th>T 4</th>
                <th>T 5</th>
                <th class="eind">Rapport 1</th>
                <th class="eind">Rapport 2</th>
                <th class="eind">Rapport 3</th>
                <th class="eind">Eind</th>
            </tr>
            <tr class="odd">
                <th>Nederlands</th>
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
                <th class="eind">7,3</th>
                <th class="eind">6,7</th>
                <th class="eind"></th>
                <th class="eind">7,3</th>
            </tr>
            <tr>
                <th>Wiskunde</th>
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
                <th class="eind">8,1</th>
                <th class="eind">7,9</th>
                <th class="eind"></th>
                <th class="eind">8,0</th>                                
            </tr>
            <tr class="odd">
                <th>Engels</th>
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
                <th class="eind">10,0</th>
                <th class="eind">9,2</th>
                <th class="eind"></th>
                <th class="eind">9,4</th>           
            </tr>
            <tr>
                <th>Scheikunde</th>
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
                <th class="eind">6,9</th>
                <th class="eind">8,5</th>
                <th class="eind"></th>
                <th class="eind">7,8</th>  
            </tr>
            <tr class="odd">
                <th>Duits</th>
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
                <th class="eind">7,4</th>
                <th class="eind">9,1</th>
                <th class="eind"></th>
                <th class="eind">8,3</th> 
            </tr>

        </thead>
        <tbody>
            <% foreach (Grade grade in gradeMan.GetGradeListFromDatabase(LoggedInPerson.UserId)){ %> 
                <tr>
                    <td><%: grade.student.Name %></td>
                    <td><%: grade.subject.Name %></td>
                    <td><%: grade.date %></td>
                    <td><%: grade.weight %></td>
                    <td><% if (grade.grade < 55) { %><i style="color: darkred; "><%: grade.grade/10 %></i> <% } else { %><i style="color: green; "><%: grade.grade/10 %></i><% } %></td>
                </tr>     
            <% } %>
        </tbody>

</table>
</asp:Content>


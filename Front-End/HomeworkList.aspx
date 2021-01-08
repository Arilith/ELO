<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeworkList.aspx.cs" Inherits="Front_End.HomeworkList" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto">Huiswerk</h2>
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
    <div class="row">
        <div class="col-lg-6">
            <div class="list-group">
                <% foreach (Homework homework in HomeworkManager.GetHomeWorkForClassFromDB(LoggedInStudent.School, LoggedInStudent.PartOfClass)){ %>
                    <a href="#" class="list-group-item active" <% if(homework.IsTest == true) { %>style="background-color: #a94442; border-color: #a94442;"<% } %>>
                            <h4 class="list-group-item-heading"><%: homework.Subject.Name %> - <%: homework.Title %></h4>
                            <p class="list-group-item-text">
                                <div class="pull-right">Voltooid <br/><input type="checkbox" /></div>
                                <%: homework.Content %> <br/> Moet af zijn op: <i><%: homework.DueDate %></i>
                            </p>
                        </a>
                        <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading"></h4>
                            <p class="list-group-item-text">
                                Dit huiswerk is <% if (homework.IsTest == false){ %> geen <% } else { %> <b>wel</b> een <% } %> toets.  <br/><i>Te verdienen XP: <%: homework.Exp  %> </i>
                            </p>
                        </a>
                    <br/>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Upload bestand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="Front_End.FileList" %>
<%@ Import Namespace="ELO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 draggable="auto"><%: Title %></h2>
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
            <tr>
                <th>Bestandnaam</th>
                <th>Geupload op</th>
                <th>Geupload door</th>
                <th>Downloaden</th>
                <th>Heruploaden</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (File file in FileManager.GetFileListByUser(loggedInPerson.UserId)){ %> 
                <tr>
                    <td><%: file.FileName %></td>
                    <td><%: file.UploadDate %></td>
                    <td><%: file.Student.Name %></td>
                    <td><a href="<%: file.FilePath %>" class="btn btn-primary" style="border-radius:0px!important">Downloaden</a></td>
                    <td><a href="UploadFile?homeworkUUID=<%: file.Homework.UUID %>" class="btn btn-warning" style="border-radius:0px!important">Heruploaden</a></td>
                </tr>     
            <% } %>
        </tbody>
    </table>
</asp:Content>
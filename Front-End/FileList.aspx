<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="Front_End.FileList" %>
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
    <table class="table-striped table-bordered ">
        <thead>
            <tr>
                <th>Bestandnaam</th>
                <th>Geupload op</th>
                <th>Geupload door</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (File file in Manager.fileMan.GetFileList()){ %> 
                <tr>
                    <td><%: file.FileName %></td>
                    <td><%: file.UploadDate %></td>
                    <td>Coming soon!</td>
                </tr>     
            <% } %>
        </tbody>
    </table>
</asp:Content>
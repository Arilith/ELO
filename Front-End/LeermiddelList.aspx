<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeermiddelList.aspx.cs" Inherits="Front_End.LeermiddelList" %>
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
        table, th, td {
            border:1px solid black;
        }
    </style>
    <table>
        <thead>
            <tr>
                <th>Vak</th>
                <th>Niveau</th>
                <th>Leerjaar</th>
                <th>Link</th>
                <th>Beschrijving</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Leermiddel leermiddel in Manager.leermiddelMan.GetLeermiddelList()){ %> 
                <tr>
                    <td><%: leermiddel.subject %></td>
                    <td><%: leermiddel.niveau %></td>
                    <td><%: leermiddel.leerjaar %></td>
                    <td><a href="<%: leermiddel.link %>">click</a></td>
                    <td><%: leermiddel.description %></td>
                </tr>     
            <% } %>
        </tbody>
    </table>
</asp:Content>

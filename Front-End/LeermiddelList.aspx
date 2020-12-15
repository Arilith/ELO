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
    </style>
    <table class="table-striped table-bordered ">
        <thead>
            <tr>
                <th>vak</th>
                <th>niveau</th>
                <th>leerjaar</th>
                <th>link</th>
                <th>beschrijving</th>
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

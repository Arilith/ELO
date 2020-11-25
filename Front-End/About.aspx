<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Front_End.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>

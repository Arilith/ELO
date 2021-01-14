<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Front_End.Logout" %>
<% Session["person"] = null; %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <%-- <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" /> --%>
        <link id="link2" rel="stylesheet" href="~/Content/Main.css" type="text/css" runat="server" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" runat="server"/>
    </meta>
    <link rel="icon" href="Studycluster-icon.ico" type="image/x-icon"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="search-overlay">
              <div id="loader"></div>
            <div id="loader-text">Uitloggen... doorsturen naar Login Pagina.
            <meta http-equiv="refresh" content="0;url=login.aspx" /></div>
        </div>
    </form>
</body>
</html>

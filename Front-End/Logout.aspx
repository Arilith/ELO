<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Front_End.Logout" %>
<% Session["person"] = null; %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Uitloggen... doorsturen naar Login Pagina.
            <meta http-equiv="refresh" content="0;url=login.aspx" />
        </div>
    </form>
</body>
</html>

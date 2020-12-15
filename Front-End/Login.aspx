<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Front_End.Login" %>
<%@ Import Namespace="ELO" %>
<%@ Import Namespace="ELO.Managers" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
    </meta>
    <title><%: Page.Title %> - Study Cluster</title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <img src="Content/Pictures/Logo-ELO2Best.png" width=20% style="margin-left:auto; margin-right:auto; display:block" />
                
        <div class="container body-content" style="margin-top: 50px">
            
            <form method="post" action="Login.aspx" name="login">
                Voer je inloggegevens in.<br /><br />
                <label for="school">School</label><br />
                <select id="school" name="school" class="form-control">
                    <% foreach (School school in schoolManager.GetSchoolList()) { %>
                        <option><%: school.Name %></option>
                    <% } %>
                </select>
                <br />
                <label for="leerlingnummer">Leerlingnummer</label><br />
                <input id="leerlingnummer" type="text" name="leerlingnummer" class="form-control" /><br />
                <label for="password">Wachtwoord</label><br />
                <input id="password" type="password" name="password" class="form-control" /><br /><br />
                <button type="submit" class="btn btn-success">Log in</button>
            </form><br/><br/>
            Systeembeheer? Log <a href="~/AdminLogin" runat="server">hier</a> in
            <% if (results != null) { %>
                <meta http-equiv="refresh" content="0;url=Home.aspx" />
            <% } %>
            <hr style="border-top: 1px solid black!important" />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - StudyCluster</p>
            </footer>
        </div>

    </form>
</body>
</html>
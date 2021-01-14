<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Front_End.AdminLogin" %>
<%@ Import Namespace="ELO" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <link id="link1" rel="stylesheet" href="~/Content/Login.css" type="text/css" runat="server" />
    </meta>
    <link rel="icon" href="Studycluster-icon.ico" type="image/x-icon"/>
    <title>Admin register - Study Cluster</title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <div class="bg-image bg-image-admin"><div class="darkening"></div></div>
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
        
        <div class="login-container-register">
            <div class="login-picture"></div>
            <div class="top">
                <img src="https://media.discordapp.net/attachments/788383809133215754/797134629898420304/Logo-Studycluster-wit-beter.png" class="login-logo" />
            </div>
            <div class="bottom">
                <form method="post" action="AdminLogin.aspx" name="login">
                Nieuw administratoraccount aanmaken
                <div>
                    <br />
                <select id="school" class="input-control" name="school">
                    <% foreach (string school in schoolManager.GetSchoolList()) { %>
                        <option><%: school %></option>
                    <% } %>
                </select>
                    </div>

                    <div>
                        <br />
                <input id="username" type="text" name="username" class="input-control" required />
                    <span class="floating-label">Gebruikersnaam</span>
                        </div>
                    <div>
                <input id="name" type="text" name="name" class="input-control" required />
                    <span class="floating-label">Naam</span>
                        </div>
                    <div>
                <input id="email" type="email" name="email" class="input-control" required />
                    <span class="floating-label">E-mailadres</span>
                        </div>
                    <div>
                <input id="password" type="password" name="password" class="input-control" required />
                    <span class="floating-label">Wachtwoord</span>
                        </div>
                <a class="btn btn-info" href="AdminLogin">Inloggen</a>
                    <div class="pull-right">
                <button type="submit" class="btn btn-success" style="margin-right: 25px; display:inline-block">Account aanmaken</button></div>
                    </div>
            </div>
                </form>
    <% if (results != null) { %>
                    <meta http-equiv="refresh" content="0;url=Home.aspx" />
                <% } %>

            <br/><br/>
            
            
            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>

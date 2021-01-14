<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Front_End.UserInfo" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-8">
            <div class="container-info">
                <div class="container-title">Gebruikersinformatie</div>
                <div class="container-content">
                    <div class="row">
                        <div class="col-lg-4">
                            <img src="https://pbs.twimg.com/profile_images/740272510420258817/sd2e6kJy_400x400.jpg" />
                        </div>
                        <div class="col-lg-8">
                            <div class="message-holder">
                                <div class="message">
                                    <%
                                        // als je leerling bent staat hier onder je username en leerlingnummer
                                        if (loggedInPerson.Type == "Student")
                                        {
                                        %><div class="message-title">Gebruikersnaam / Leerlingnummer</div><%
                                        }
                                        // als je leraar of Sysadmin bent staat boven je username:
                                        else
                                        {
                                        %><div class="message-title">Gebruikersnaam</div><%
                                        }
                                    %>
                                    <%
                                        string returnUsername;
                                        string returnLeerlingnummer;
                                        // als leerling zie je hier je naam en leerlingnummer
                                        if (loggedInPerson.Type == "Student")
                                        {

                                            returnUsername = loggedInStudent.Name;
                                            returnLeerlingnummer = loggedInStudent.LeerlingNummer.ToString();
                                            %><div class="message-content"><%: returnUsername %> / <%: returnLeerlingnummer %></div>

                                     <% }
                                        // als docent of sysadmin zie je hier je naam
                                        else
                                        {
                                            returnUsername = loggedInPerson.UserName;
                                            %><div class="message-content"><%: returnUsername %></div><%
                                        }
                                     %>

                                        </div>
                                <div class="message">
                                    <div class="message-title">E-Mail Adres</div>
                                    <%// laat de e-mail van ingelogde persoon zien %>
                                    <div class="message-content"><%:loggedInPerson.Email %></div>
                                </div>
                                <div class="message">
                                    <%// TO BE DONE: als je leerling bent zie je klas, als leraar vak, en als sysadmin niks

                                        if (loggedInPerson.Type == "Student"){%><div class="message-title">Klas</div><% }
                                        if (loggedInPerson.Type == "Teacher"){%><div class="message-title">Vak</div><% } %>

                                    <%if (loggedInPerson.Type == "Student"){%><div class="message-content"><%:loggedInStudent.PartOfClass.Name %></div><% }
                                        if (loggedInPerson.Type == "Teacher"){%><div class="message-content"><%:loggedInTeacher.Subject.Name %></div><% } %>
                                </div>
                                <div class="message">
                                    <%// datum waarop de ingelogde persoon zijn of haar account is aangemaakt %>
                                    <div class="message-title">Geregistreerd op</div>
                                    <div class="message-content"><%:loggedInPerson.RegistrationDate %></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

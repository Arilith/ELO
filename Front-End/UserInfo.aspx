<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Front_End.UserInfo" %>
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
                                    <div class="message-title">Gebruikersnaam / Leerlingnummer</div>
                                    <div class="message-content"></div>
                                </div>
                                <div class="message">
                                    <div class="message-title">E-Mail Adres</div>
                                    <div class="message-content"></div>
                                </div>
                                <div class="message">
                                    <div class="message-title">Klas / Vak</div>
                                    <div class="message-content"></div>
                                </div>
                                <div class="message">
                                    <div class="message-title">Geregistreerd op</div>
                                    <div class="message-content"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

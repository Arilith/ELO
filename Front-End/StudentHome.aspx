<%@ Page Title="Hoofdpagina" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Front_End.Home" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <meta name=vs_targetSchema content="[!output DEFAULT_TARGET_SCHEMA]">
        <link id="link1" rel="stylesheet" href="~/Content/StyleSheet1.css" type="text/css" runat="server" />
    </meta>
 <div class="homebar">
  <div class="homebar-content">
  <img src="Content/Pictures/Logo-ELO2Best.png" style="width:18%; height:18%">
  <div style="width:60px; height:75px; border: 1px solid #000"><img src="Content/Pictures/neds (2).jpg" style="width:100%; height:100%; margin:0" /></div>
  <p class="gegevens"> naam leerling <br>
      leerlingnummer <br>
      e-mail leerling
  </p>
  </div>
</div>
    <div class="row">
        <div class="col-lg-4">
            <div class="container-info">
                <div class="container-title">Volgende uur</div>
                <div class="container-content">
                    <div class="row">
                        <div class="col-lg-3">Foto hier</div>
                        <div class="col-lg-9">
                            Engels - E16<br/>
                            <b>HW: Maak opdracht 14 t/m 17 en lees pagina 54 t/m 58 in het lesboek.</b>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-info">
                <div class="container-title">Opdrachten</div>
                 <div class="container-content">
                    <div class="row">
                            <b class="middle">Engels - Inleverdatum 07-01-2021</b><br/><br />
                            <p class="middle">Maak de online opdracht over werkwoorden op www.ofcourse.nl</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="container-info">
                <div class="container-title">Laatste cijfers</div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="container-info">
                <div class="container-title">Meldingen</div>
                <div class="container-content">
                    <div class="message-holder">
                        <div class="message">
                            <div class="message-title">Aula Gesloten</div>
                            <div class="message-content">M. Hendriks <br/> <br/> Volgende week (7dec - 14dec) is de aula gesloten i.v.m. de toetsweek. Eten kan... </div>
                        </div>
                        <div class="message">
                            <div class="message-title">Aanmelden Romereis</div>
                            <div class="message-content">M. Veldman <br/> <br/> Beste leerlingen klassieke talen, het aanmelden voor de Romereis kan nog... </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h2><asp:TextBox ID="TextBoxTitle" runat="server" Height="33px" BackColor="#999999" style="margin-right: 7px" Width="218px" ForeColor="White"></asp:TextBox>
        <asp:Button ID="ButtonAddBook" runat="server" OnClick="Button1_Click" Text="Add New" Height="33px" Width="131px" BackColor="#999999" ForeColor="White" />
    </h2>

        <table style="width: 97%; height: 89px; margin-top: 10px; margin-bottom: 10px;" border="1">
            <tr>
                <td style="height: 15px; font-weight: bold; width: 1316px;">Title</td>
                <td style="height: 15px; font-weight: bold;">Number</td>
            </tr>
                    
                <tr>
                <td class="modal-lg" style="width: 1316px; height: 10px;">
                </td>
                <td></td>
                </tr>       
        </table>
    
    <p>Aan deze lijst kun je de boeken die in je tas zitten toevoegen zodat je zeker weet dat je ze allemaal bij je hebt.<br />
        Zo kun je dus niet een boek vergeten mee te nemen!<br />
        Vul gewoon de naam in van het boek en klik op de knop.</p>

</asp:Content>
<%@ Page Title="Bestand uploaden" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Front_End.UploadFile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> voor huiswerkopdracht <br/> <i><%: FoundHomework.Subject.Name %> | <%: FoundHomework.Title %>  </i></h2>
    <h3>Huiswerkbeschrijving</h3>
    <p style="margin-top: -40px;">
        <%: FoundHomework.Content %> <br/> 
        <i>Te verdienen XP: </i> <%: FoundHomework.Exp %> <br/>
    </p><br/><br/>
    <p>Upload hier je gemaakte huiswerkbestanden, zodat de docent deze kan beoordelen.<br/> <i>Let op: De maximale bestandsgrootte is 4 megabytes (MB)</i></p>
    <form method="post" id="form1" enctype="multipart/form-data" action="UploadFile.aspx">
        <label for="file">Selecteer een bestand</label>
        <input type="file" name="uploadedFile" required id="uploadedFile" runat="server" style="background-color:transparent!important; margin-top:10px"/><br/><br/>
        <asp:button CssClass="btn btn-success" id="btnUpload" type="submit" text="Upload" runat="server" OnClick="btnUpload_Click" Style="background-color:#5cb85c; border-color:#4cae4c"/><asp:button />
        <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
            <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
        </asp:Panel>
    </form> 
</asp:Content>


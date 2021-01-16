<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UploadCSV.aspx.cs" Inherits="Front_End.UploadCSV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post" id="form1" enctype="multipart/form-data" action="UploadFile.aspx">
        Op deze pagina is het mogelijk om een CSV bestand te uploaden om meerdere leerlingen in een keer toe te voegen.<br/><br/>
        <label for="file">Selecteer een bestand</label>
        <input type="file" name="uploadedFile" required id="uploadedFile" runat="server" style="background-color:transparent!important; margin-top:10px"/><br/><br/>
        <asp:button CssClass="btn btn-success" id="btnUpload" type="submit" text="Upload" runat="server" OnClick="btnUpload_Click" Style="background-color:#5cb85c; border-color:#4cae4c"/><asp:button />
        <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
            <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
        </asp:Panel>
    </form>
</asp:Content>

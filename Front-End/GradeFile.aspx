<%@ Page Title="Beoordelen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GradeFile.aspx.cs" Inherits="Front_End.Content.GradeFile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> van huiswerkopdracht <br/> <i><%: FoundHomework.Title %> | Gemaakt door: <%: FoundStudent.Name  %> (<%: FoundStudent.PartOfClass.Name %>)  </i></h2>
    <h3>Huiswerkbeschrijving</h3>
    <p style="margin-top: -40px;">
        <%: FoundHomework.Content %> <br/>
        <i>Te verdienen XP: </i> <%: FoundHomework.Exp %> <br/>
    </p><br/><br/>
    <p>We</p>
    <form method="post" id="form1" enctype="multipart/form-data" action="../UploadFile.aspx">
        
    </form>
</asp:Content>

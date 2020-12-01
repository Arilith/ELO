<%@ Page Title="BookList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Front_End.BookList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-left: 10px"><%: Title %>My books</h2>
    <h2><asp:TextBox ID="TextBoxTitle" runat="server" Height="28px" BackColor="#666666" style="margin-left: 7px; margin-right: 7px" Width="218px"></asp:TextBox>
        <asp:Button ID="ButtonAddBook" runat="server" OnClick="Button1_Click" Text="Add New" Height="35px" Width="131px" BackColor="#666666" ForeColor="White" style="margin-left: 5px" />
    </h2>

        <table style="width: 97%; height: 89px; margin-top: 10px; margin-bottom: 10px; margin-left: 10px;" border="1">
            <tr>
                <td style="height: 36px; width: 1316px;">Title</td>
                <td style="height: 36px">Number</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 1316px">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>1</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 1316px">Boek2</td>
                <td>2</td>
            </tr>
        </table>
    
    <p>Use this area to provide additional information.</p>
</asp:Content>
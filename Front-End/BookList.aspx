<%@ Page Title="My books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Front_End.BookList" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-left: 10px"><%: Title %></h2>
    <h2><asp:TextBox ID="TextBoxTitle" runat="server" Height="28px" BackColor="#666666" style="margin-left: 7px; margin-right: 7px" Width="218px"></asp:TextBox>
        <asp:Button ID="ButtonAddBook" runat="server" OnClick="Button1_Click" Text="Add New" Height="35px" Width="131px" BackColor="#666666" ForeColor="White" style="margin-left: 5px" />
    </h2>

        <table style="width: 97%; height: 89px; margin-top: 10px; margin-bottom: 10px; margin-left: 10px;" border="1">
            <tr>
                <td style="height: 36px; width: 1316px;">Title</td>
                <td style="height: 36px">Number</td>
            </tr>
            <% foreach (Book book in Manager.bookMan.GetBookList()) { %>
                    
                <tr>
                <td class="modal-lg" style="width: 1316px">
                    <%: book.Title %>
                </td>
                <td> <%: book.Nummer %> </td>
                </tr>       

               <% }  %>
            
        </table>
    
    <p>Use this area to provide additional information.</p>
</asp:Content>
<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="Front_End.AddGrade" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <table class="table-striped table-bordered ">
      
        <thead>
                <tr>
                   
                    <th>Student</th>
                    <th>Afwezig onwettig </th>
                    <th>Afwezig Wettig</th>
                    <th>Te laat onwettig</th>
                    <th>Te laat wettig</th>
                    <th>Huiswerk vergeten</th>
                    <th>Verwijdering</th>      
                </tr>     
        </thead>
     <tbody>
          <% foreach (Student student in Manager.userMan.GetStudentList()){ %> 
         <tr>
             <td><%: student.Name %></td>
             <td> <asp:CheckBox ID="CheckBox1" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBox2" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBox3" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBox4" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBox5" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBox6" runat="server" /></td>

             </tr>
         <% } %>
    </table>
	
 

</asp:Content>

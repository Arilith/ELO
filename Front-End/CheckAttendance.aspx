<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckAttendance.aspx.cs" Inherits="Front_End.CheckAttendance" %>
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
             <td> <asp:CheckBox ID="CheckBoxOA" runat="server" OnCheckedChanged="CheckBoxOA_CheckedChanged"  /></td>
             <td> <asp:CheckBox ID="CheckBoxWA" runat="server" OnCheckedChanged="CheckBoxWA_CheckedChanged"  /></td>
             <td> <asp:CheckBox ID="CheckBoxTLO" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBoxTLW" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBoxHWV" runat="server" /></td>
             <td> <asp:CheckBox ID="CheckBoxVW" runat="server" /></td>

             </tr>
         <% } %>
    </table>
	
 

</asp:Content>

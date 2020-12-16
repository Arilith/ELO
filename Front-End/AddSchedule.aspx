<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Front_End.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <%@ Import Namespace="ELO" %>
            <% DateTime now = DateTime.Now; %>
        <h2>Rooster veranderen</h2>
            <asp:Label ID="LabelTeacher" runat="server" Text="Teacher"></asp:Label><br/>
            <input id="teacher" class="form-control" name="teacher" type="text" required aria-autocomplete="list"/><br/>
            <asp:Label ID="LabelSubject" runat="server" Text="Subject"></asp:Label><br/>
            <input id="subject" class="form-control" name="subject" type="text" required aria-autocomplete="list"/><br/>
            <asp:Label ID="LabelClassroom" runat="server" Text="Classroom"></asp:Label><br/>
            <input id="classroom" class="form-control" name="classroom" type="text" required aria-autocomplete="list"/><br/>
            <asp:Label ID="LabelClass" runat="server" Text="Class"></asp:Label><br/>
            <input id="_class" class="form-control" name="_class" type="text" required  aria-autocomplete="list"/><br/>
            
            
            <label for="Date">Datum</label><br/>
            <input id="Date" class="form-control" name="Date" type="date"  required/><br/>

            <button style="width: auto" type="submit" class="btn btn-success">Voeg Toe</button><br/><br/><br/>
            <asp:Label ID="OutputLabel" runat="server" Text="---------------------------------"></asp:Label>
            <br />
            Rooster voor <%: now.ToString("D")%><table>
            <tr>
                <td>Vak</td>
                <td>lok.</td>
                <td>Tijd</td>
            </tr>
            <tr>
                <%
                //voor de datum die is opgeroepen doe foreach(Appointment appointment in Manager.AppointmentMan.AppointmentList()){
                //<td> :Appointment.Subject </td>
                //<td> :Appointment.Classroom </td>
                //<td> :Appointment.DateTime </td>
                //} %>
            </tr>
        </table>
    </div>
</asp:Content>
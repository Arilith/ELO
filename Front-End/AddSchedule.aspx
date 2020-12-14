<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="Front_End.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="ELO" %>

    <% DateTime now = DateTime.Now; %>

    <strong>
                <asp:Label ID="LabelTeacher" runat="server" Text="Teacher"></asp:Label>
                <input id="teacher" class="form-control" name="teacher" type="text" required style="width: 32%; height: 25px" aria-autocomplete="list"/>
                <asp:Label ID="LabelSubject" runat="server" Text="Subject" style="margin-top:100px"></asp:Label>
                <input id="subject" class="form-control" name="subject" type="text" required style="width: 32%; height: 25px" aria-autocomplete="list"/>
                <asp:Label ID="LabelClassroom" runat="server" Text="Classroom"></asp:Label>
                <input id="classroom" class="form-control" name="classroom" type="text" required style="width: 32%; height: 25px" aria-autocomplete="list"/>
                <asp:Label ID="LabelClass" runat="server" Text="Class"></asp:Label>
                <input id="_class" class="form-control" name="_class" type="text" required style="width: 32%; height: 25px" aria-autocomplete="list"/>
                
                
                <label for="Date">Datum+Tijd</label><br/>
                <input id="Date" class="form-control" name="Date" type="datetime"  required/>

                <button style="width: auto" type="submit" class="form-control">Voeg Toe</button>
                <asp:Label ID="OutputLabel" runat="server" Text="---"></asp:Label>
                <br />
                Rooster voor <%: now.ToString("D")%><table border="1" style="width: 50%;">
            <tr>
                <td style="height: 20px; width: 195px">Vak</td>
                <td style="height: 20px; width: 164px">lok.</td>
                <td style="height: 20px">Tijd</td>
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
</asp:Content>
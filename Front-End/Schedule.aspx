<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
                <input id="name0" class="form-control" name="name0" type="text" required style="width: 32%; height: 25px"/><input id="name1" class="form-control" name="name1" type="text" required style="width: 32%; height: 25px"/><input id="name2" class="form-control" name="name2" type="text" required style="width: 32%; height: 25px"/><input id="name3" class="form-control" name="name3" type="text" required style="width: 32%; height: 25px"/><input id="name4" class="form-control" name="name4" type="text" required style="width: 32%; height: 25px"/><input id="name5" class="form-control" name="name5" type="text" required style="width: 32%; height: 25px"/><input id="name7" class="form-control" name="name7" type="text" required style="width: 32%; height: 25px"/>Rooster voor 08/12/2020<table border="1" style="width: 50%;">
            <tr>
                <td style="height: 20px; width: 195px">Vak</td>
                <td style="height: 20px; width: 164px">lok.</td>
                <td style="height: 20px">Tijd</td>
            </tr>
            <tr>
                <%//krijg hier de datum
                //voor de datum die is opgeroepen doe foreach(Appointment appointment in Manager.AppointmentMan.AppointmentList()){
                //<td> :Appointment.Subject </td>
                //<td> :Appointment.Classroom </td>
                //<td> :Appointment.DateTime </td>
                //} %>
            </tr>
        </table>
    </p>
</asp:Content>

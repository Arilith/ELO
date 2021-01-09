<%@ Page Title="Rooster" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Rooster</h2><h3><%: startDate %> t/m <%: endDate %></h3>
    <style>
        td {
            padding: 10px;
        }
        th {
            padding: 10px;
        }
        table, th, td {
            border: 1px solid gray!important;
        }
    </style>
<%--     <%  --%>
<%--        Dictionary<string, List<Appointment>>.KeyCollection datumKeys = AppointmentsPerDay.Keys; --%>
<%--        foreach(string datum in datumKeys) { %> --%>
<%--             <table class="table-striped table-bordered "> --%>
<%--                 <thead> --%>
<%--                     <tr> --%>
<%--                         <th>Tijd</th> --%>
<%--                         <th>Vak</th> --%>
<%--                         <th>Docent</th> --%>
<%--                         <th>Lokaal</th> --%>
<%--                     </tr> --%>
<%--                 </thead> --%>
<%--                 <tbody> --%>
<%--                     <% foreach (Appointment appointment in AppointmentsPerDay[datum]) { %> --%>
<%--                         <tr> --%>
<%--                             <td><%: appointment.dateAndTime %></td> --%>
<%--                             <td><%: appointment.subject.Name %></td> --%>
<%--                             <td><%: appointment.teacher.UserName %></td> --%>
<%--                             <td><%: appointment.classroom %></td> --%>
<%--                         </tr> --%>
<%--                     <% } %> --%>
<%--                 </tbody> --%>
<%--             </table><br/> --%>
<%--         <% } %> --%>

    <div class="row">
        <div class="col-lg-1"></div>
            <% 
              int amountOfDays = 0; Dictionary<string, List<Appointment>>.KeyCollection datumKeys = AppointmentsPerDay.Keys;
              foreach(string datum in datumKeys)
              {
                  amountOfDays++;
                  if (amountOfDays > 5)
                  {
                      break;
                  }
            %>
                <div class="col-lg-2">
                    <div class="list-group">
                        <% foreach (Appointment appointment in AppointmentsPerDay[datum])
                           { %>
                            <a href="#" class="list-group-item active">
                                <h4 class="list-group-item-heading"></h4>
                                <p class="list-group-item-text">
                                    <b><%: DateTimeFormatInfo.CurrentInfo.GetDayName(appointment.dateAndTime.DayOfWeek) %></b><br/> <%: appointment.dateAndTime.ToString("M") %>
                                </p>
                            </a>
                            <a href="#" class="list-group-item">
                                <h4 class="list-group-item-heading"></h4>
                                <p class="list-group-item-text">
                                    <%: appointment.subject.Name %> <br/> <%: appointment.classroom %> <br/> <%: appointment.teacher.Name %>
                                </p>
                            </a>
                            <br/>
                        <% } %>
                    </div>
                </div>
            <% } %>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
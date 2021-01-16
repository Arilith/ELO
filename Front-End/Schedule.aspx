<%@ Page Title="Rooster" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="ELO" %>
    <h2 draggable="auto">Rooster</h2>
    <h3><%: startDate %> t/m <%: endDate %></h3>
    <style>
        td {
            padding: 10px;
        }

        th {
            padding: 10px;
        }

        table, th, td {
            border: 1px solid gray !important;
        }
    </style>
    <div class="row">
        <div class="col-lg-1"></div>
        <%
            int amountOfDays = 0; Dictionary<string, List<Appointment>>.KeyCollection datumKeys = AppointmentsPerDay.Keys;
            
            foreach (string datum in datumKeys)
            {
                if (AppointmentsPerDay[datum][0].Date < DateTime.Parse(startDate) || AppointmentsPerDay[datum][0].Date > DateTime.Parse(endDate))
                {
                    continue;
                }
                else
                {
                    amountOfDays++;
                    if (amountOfDays > 5)
                    {
                        break;
                    }
                }
                
        %>
            
        <div class="col-lg-2">
            <%: datum %>
            <div class="list-group">
                <%-- Loop door alle lesuren mogelijk. --%>
                <% for(int i = 1; i < TodayMan.LesUren.Count + 1; i++) { %>
                    <% Appointment foundAppointment = AppointmentsPerDay[datum].Find(x => x.LesUur == i); if(foundAppointment != null) { %>
                        <a href="#" class="list-group-item" style="background-color: green; color: lightgreen">
                            <h4 class="list-group-item-heading" ></h4>
                            <p class="list-group-item-text">
                                <b><%: i %>
                                    <%: foundAppointment.subject %> |
                                    <%: foundAppointment.classroom %>
                                    <br />
                                    <%: foundAppointment.teacher %>
                                </b>
                            </p>
                        </a>
                        <br />
                    <% } else { %>
                        <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading"></h4>
                            <p class="list-group-item-text">
                                <b><%: i %> Geen les</b><br />
                            </p>
                        </a> <br/>
                    <% } %>
                <% } %>
            </div>
        </div>
        <% } %>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
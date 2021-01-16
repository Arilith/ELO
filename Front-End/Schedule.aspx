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
            string lastDate = "";
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

                lastDate = datum;
        %>
            
        <div class="col-lg-2">
            <%: DateTime.ParseExact(datum.ToString(), "MM-dd-yyyy", null).ToString("dddd dd-MM-yyyy") %>
            <div class="list-group">
                <%-- Loop door alle lesuren mogelijk. --%>
                <% for(int i = 1; i < TodayMan.LesUren.Count + 1; i++) { %>
                    <% Appointment foundAppointment = AppointmentsPerDay[datum].Find(x => x.LesUur == i); if(foundAppointment != null) { %>
                        <a href="#" class="list-group-item" style="height: 70px; background-color: green; color: lightgreen">
                            <h4 class="list-group-item-heading" ></h4>
                            <p class="list-group-item-text">
                                <b><div class="pull-left">
                                        <%: foundAppointment.subject %> |
                                        <%: foundAppointment.classroom %>
                                        <br />
                                        <%: foundAppointment.teacher %> |
                                        <%: TodayMan.LesUren[i] %>
                                    </div>
                                    <div class="pull-right" style="font-size: 30px;">
                                        <%: i %> 
                                    </div>
                                </b>
                            </p>
                        </a>
                        <br />
                    <% } else { %>
                        <a href="#" class="list-group-item" style="height: 50px;">
                            <h4 class="list-group-item-heading"></h4>
                            <p class="list-group-item-text">
                                <b>
                                    <div class="pull-left">
                                        <%: TodayMan.LesUren[i] %> Geen les
                                    </div>
                                    <div class="pull-right">
                                        <%: i %>
                                    </div>
                                </b><br />
                            </p>
                        </a> <br/>
                    <% } %>
                <% } %>
            </div>
        </div>
        <% } %>
        <% int amountOfDaysToAdd = 0; for (int j = amountOfDays; j < 5; j++)
           { amountOfDaysToAdd++; %>
            <div class="col-lg-2">
                <%: DateTime.ParseExact(lastDate.ToString(), "MM-dd-yyyy", null).AddDays(amountOfDaysToAdd).ToString("dddd dd-MM-yyyy") %>
                <% for(int k = 1; k < TodayMan.LesUren.Count + 1; k++) { %>
                    <a href="#" class="list-group-item" style="height: 50px;">
                        <h4 class="list-group-item-heading"></h4>
                        <p class="list-group-item-text">
                            <b>
                                <div class="pull-left">
                                    <%: TodayMan.LesUren[k] %> Geen les
                                </div>
                                <div class="pull-right">
                                    <%: k %>
                                </div>
                            </b><br />
                        </p>
                    </a> <br/>
                <% } %>
            </div>
        <%  } %>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
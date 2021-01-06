<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="ELO" %>
    <% string date = DateTime.Now.ToString("MM/dd/yyyy"); %>
    <h2 draggable="auto">Rooster <%: date %></h2>
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
    <% 
       Dictionary<string, List<Appointment>>.KeyCollection datumKeys = AppointmentsPerDay.Keys;
       foreach(string datum in datumKeys) { %>
            <table class="table-striped table-bordered ">
                <thead>
                    <tr>
                        <th>Tijd</th>
                        <th>Vak</th>
                        <th>Docent</th>
                        <th>Lokaal</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (Appointment appointment in AppointmentsPerDay[datum]) { %>
                        <tr>
                            <td><%: appointment.dateAndTime %></td>
                            <td><%: appointment.subject.Name %></td>
                            <td><%: appointment.teacher.UserName %></td>
                            <td><%: appointment.classroom %></td>
                        </tr>
                    <% } %>
                </tbody>
            </table><br/>
        <% } %>

        <div id="picker"></div>
    <div>
        <p>Selected date: <span id="selected-date"></span></p>
        <p>Selected time: <span id="selected-time"></span></p>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="https://www.jqueryscript.net/demo/pick-hours-availability-calendar/js/mark-your-calendar.js"></script>
    <script type="text/javascript">
        (function($) {
          $('#picker').markyourcalendar({
              availability: [
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
                  ['1:00', '2:00', '3:00', '4:00', '5:00'],
              ],
              months: ['Januari', 'Feruari', 'Maart', 'April', 'Mei', 'Juni', 'Juli', 'Augustus', 'September', 'October', 'November', 'December'],
              weekdays: ['Zondag', 'Maandag', 'Dinsdag', 'Woensdag', 'Donderdag', 'Vrijdag', 'Zaterdag'],
              startDate: new Date("<%: date %>"),
              onClick: function (ev, data) {
                  // data is a list of datetimes
                  var d = data[0].split(' ')[0];
                  var t = data[0].split(' ')[1];
                  $('#selected-date').html(d);
                  $('#selected-time').html(t);
            },
            onClickNavigator: function(ev, instance) {
              var arr = [
                [
                    ['1:00 OGA 1', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00 ANDERE dag', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00']
                ],
                [
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00'],
                    ['1:00', '2:00', '3:00', '4:00', '5:00']
                ],
                [
                  ['4:00', '5:00'],
                  ['4:00', '5:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00']
                ],
                [
                  ['4:00', '5:00'],
                  ['4:00', '5:00'],
                  ['4:00', '5:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['4:00', '5:00'],
                  ['4:00', '5:00'],
                  ['4:00', '5:00']
                ],
                [
                  ['4:00', '6:00'],
                  ['4:00', '6:00'],
                  ['4:00', '6:00'],
                  ['4:00', '6:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['4:00', '6:00'],
                  ['4:00', '6:00']
                ],
                [
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['3:00', '6:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['3:00', '6:00']
                ],
                [
                  ['3:00', '4:00'],
                  ['3:00', '4:00'],
                  ['3:00', '4:00'],
                  ['3:00', '4:00'],
                  ['3:00', '4:00'],
                  ['3:00', '4:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00']
                ]
              ]
              var rn = Math.floor(Math.random() * 10) % 7;
              instance.setAvailability(arr[rn]);
            }
          });
        })(jQuery);
    </script>

    <script type="text/javascript" src="~/Scripts/mark-your-calendar.js"></script>


</asp:Content>
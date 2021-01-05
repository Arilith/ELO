<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Front_End.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="ELO" %>

    <h2 draggable="auto">Rooster</h2>
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
    <form method="post" name="getdag">
        <input id="datum" name="datum" type="date" placeholder="Selecteer de dag die je wilt zien..." />
    </form>
    <table class="table-striped table-bordered ">
        <thead>
            <tr>
                <th>Tijd</th>
                <th>Vak</th>
                <th>Docent</th>
                <th>Klas</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Appointment appointment in todayMan.GetAppointmentListFromDatabase(loggedInPerson.School, loggedInStudent.PartOfClass.UUID)){ %>
                <tr>
                    <td><%: appointment.time %></td>
                    <td><%: appointment.subject.Name %></td>
                    <td><%: appointment.teacher.UserName %></td>
                    <td><%: appointment._class.Name %></td>
                </tr>
            <% } %>
        </tbody>
    </table><br/>

    <div id="picker"></div>
    <div>
        <p>Selected date: <span id="selected-date"></span></p>
        <p>Selected time: <span id="selected-time"></span></p>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="~/Scripts/mark-your-calendar.js"></script>
    <script type="text/javascript">
        (function($) {
          $('#picker').markyourcalendar({
            availability: [
              ['1:00', '2:00', '3:00', '4:00', '5:00'],
              ['2:00'],
              ['3:00'],
              ['4:00'],
              ['5:00'],
              ['6:00'],
              ['7:00']
            ],
            startDate: new Date("2020-10-25"),
            onClick: function(ev, data) {
              // data is a list of datetimes
              var d = data[0].split(' ')[0];
              var t = data[0].split(' ')[1];
              $('#selected-date').html(d);
              $('#selected-time').html(t);
            },
            onClickNavigator: function(ev, instance) {
              var arr = [
                [
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['1:00', '5:00'],
                  ['2:00', '5:00'],
                  ['3:30'],
                  ['2:00', '5:00'],
                  ['2:00', '5:00'],
                  ['2:00', '5:00']
                ],
                [
                  ['2:00', '5:00'],
                  ['4:00', '5:00', '6:00', '7:00', '8:00'],
                  ['4:00', '5:00'],
                  ['2:00', '5:00'],
                  ['2:00', '5:00'],
                  ['2:00', '5:00'],
                  ['2:00', '5:00']
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


</asp:Content>
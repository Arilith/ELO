<%@ Page Title="Vak toevoegen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="Front_End.AddSubject" %>
<%@ Import Namespace="ELO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet"/>
    <div class="row">
        <div class="col-lg-6">
            <form>
                <div class="jelly-form">
                <label for="name">Naam van het vak</label>
                <input id="name" type="text" name="name" required class="form-control"/><br/>
                <label for="teachers">Selecteer de leraren van dit vak</label><br/>
                <select data-placeholder="Typ een naam in..." class="form-control" name="teachers" id="teachers">
                    <option value="">Geen leraar invoegen.</option>
                    <% foreach (Teacher teacher in userManager.GetPersonListFromDB(loggedInPerson.School, "Teacher")) { %>
                        <option value="<%: teacher.UserId %>"><%: teacher.Name %></option>
                    <% } %>
                </select>
                    <br />
                <label for="icon">Icoon</label>
                <input id="icon" type="text" name="icon" required class="form-control"/>
                <br/><br/>
                <button class="btn btn-success" type="submit">Verstuur</button>
                </div>
            </form>
            <br/>
            <script>
                $(".chosen-select").chosen({
                    no_results_text: "Geen leraren gevonden!"
                })
            </script>
        </div>
    </div>
</asp:Content>

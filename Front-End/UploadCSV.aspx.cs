using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers;
using File = ELO.File;

namespace Front_End
{
    public partial class UploadCSV : System.Web.UI.Page
    {
        private CSVManager csvManager;

        private UserMan userManager;

        private Person loggedInPerson;

        protected void Page_load(object sender, EventArgs e)
        {
            csvManager = new CSVManager();
            userManager = new UserMan();

            loggedInPerson = (Person) Session["person"];

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ExecuteUploadFile();

        }

        private void ExecuteUploadFile()
        {
            string fileName;
            string filePath;
            string folder;
            string currentDateTime = DateTime.Now.ToString();



            folder = Server.MapPath("./UploadedFiles/CSV/");

            fileName = uploadedFile.PostedFile.FileName;
            fileName = Path.GetFileName(fileName);

            //Voeg de huidige datum+tijd toe om ervoor te zorgen dat bestanden met dezelfde naam geupload kunnen worden.
            string fileNameWithDate = AppendTimeStamp(fileName);

            if (uploadedFile.Value != "")
            {

                filePath = folder + fileNameWithDate;
                //Voor de zekerheid toch even checken of het bestand niet al bestaat.
                if (System.IO.File.Exists(filePath))
                {
                    lblUploadResult.Text = fileNameWithDate + " bestaat al! Geef het bestand een andere naam.";
                }
                else
                {
                    //Sla het bestand op.
                    uploadedFile.PostedFile.SaveAs(filePath);

                    //Voeg het toe aan de database.
                    userManager.AddStudentsToDatabase(csvManager.ReadCSV(filePath), loggedInPerson.School);


                    //Manager.fileMan.AddFile(new ELO.File(fileName, filePath, currentDateTime));

                    lblUploadResult.Text = "Je hebt met succes het bestand " + fileNameWithDate + " geuploaded! De leerlingen zullen worden ingevoerd!";
                }
            }
            else
            {
                lblUploadResult.Text = "Selecteer hierboven eerst een bestand!";
            }
            // Display the result of the upload.
            frmConfirmation.Visible = true;
        }

        public string AppendTimeStamp(string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss"),
                Path.GetExtension(fileName)
            );

        }
    }
}
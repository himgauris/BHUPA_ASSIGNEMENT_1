using BHUPA_ASSIGNEMENT_1.BAL;
using BHUPA_ASSIGNEMENT_1.DAL;
using BHUPA_ASSIGNEMENT_1.ErrorHandlingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHUPA_ASSIGNEMENT_1
{
    public partial class ProgramDetails : System.Web.UI.Page
    {
        ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
        string LoginPageURL = System.Configuration.ConfigurationManager.AppSettings["LoginPageURL"];

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                HttpCookie cookieLoginSuccess = HttpContext.Current.Request.Cookies["loginSuccess"];
                if (cookieLoginSuccess == null || cookieLoginSuccess.Value == "0")
                {
                    Response.Redirect(LoginPageURL,false);
                }
                else
                {
                    int ProgramID = Convert.ToInt32(Request.QueryString["id"]);
                    LoadProgramDetails(ProgramID);
                }
            }
            catch (Exception exception)
            {
                HandleError.HandleErrors(exception);
                Server.Transfer(ErrorPageURL,false);
            }
        }

        private void LoadProgramDetails(int programID)
        {
            CommonDBOperations<Program> programs = new CommonDBOperations<Program>(_context);
            Program program_record = programs.GetAllRecords().Single(p => p.ProgramID == programID);

            if (program_record != null)
            {
                ProgramName.Text = program_record.Name;
                Description.Text = program_record.Desc;
                StartTime.Text = Convert.ToString(TimeConversion.GetLocalProgramTime(program_record.StartTime));
                EndTime.Text = Convert.ToString(TimeConversion.GetLocalProgramTime(program_record.EndTime));
                ProgramImage.Text ="<img src='"+ program_record.ProgramImage+"'/>";
            }
        }
    }
}
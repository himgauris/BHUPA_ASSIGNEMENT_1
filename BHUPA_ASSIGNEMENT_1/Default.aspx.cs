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
    public partial class _Default : Page
    {
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
      
        ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                HttpCookie cookieLoginSuccess = HttpContext.Current.Request.Cookies["loginSuccess"];
                if (cookieLoginSuccess != null && cookieLoginSuccess.Value=="1")
                {
                    LoadPaidProgramsList();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "loadViewMoreLink", "loadViewMoreLink();", true);
                }
                else
                    LoadProgramsList();
            }
            catch(Exception exception)
            {
                HandleError.HandleErrors(exception);
                Server.Transfer(ErrorPageURL,false);
            }
        }

        protected void LoadProgramsList()
        {
            CommonDBOperations<Program> programs = new CommonDBOperations<Program>(_context);
            IEnumerable<Program> program_records = programs.GetAllRecords();

            IEnumerable<Program> program_records_acc_time = TimeConversion.UpdateProgramTimings(program_records);

            if (program_records_acc_time != null && program_records_acc_time.Count()>0)
            {
                rptprograms.DataSource = program_records_acc_time;
                rptprograms.DataBind();
            }
        }

      

        protected void LoadPaidProgramsList()
        {
            CommonDBOperations<Program> programs = new CommonDBOperations<Program>(_context);
            IEnumerable<Program> paid_program_records = programs.GetAllRecords().Where(p => p.IsPaidProgram == true);

            IEnumerable<Program> program_paid_records_acc_time = TimeConversion.UpdateProgramTimings(paid_program_records);
            if (program_paid_records_acc_time != null && program_paid_records_acc_time.Count() > 0)
            {
                rptprograms.DataSource = program_paid_records_acc_time;
                rptprograms.DataBind();          
            }
        }
    }
}
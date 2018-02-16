using BHUPA_ASSIGNEMENT_1.DAL;
using BHUPA_ASSIGNEMENT_1.ErrorHandlingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHUPA_ASSIGNEMENT_1.Login_reg_Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
        string LoginPageURL = System.Configuration.ConfigurationManager.AppSettings["LoginPageURL"];

        protected override void OnInit(EventArgs e)
        {
            Register.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNewUser();
            }
            catch(Exception exception)
            {
                HandleError.HandleErrors(exception);
                Server.Transfer(ErrorPageURL,false);
            }
        }

        protected void CreateNewUser()
        {          
            ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
            CommonDBOperations<Event_Users> dal = new CommonDBOperations<Event_Users>(_context);
            Event_Users user = new Event_Users();
            user.FirstName = FirstName.Text;
            user.LastName = LastName.Text;
            user.EmailID = Email.Text;
            user.UserName = UserName.Text;
            user.Password = Password.Text;
            if (user != null)
            {
                dal.InsertRecord(user);
                Response.Redirect(LoginPageURL, false);
            }
            else
                Server.Transfer(ErrorPageURL,false);
        }

    }
}
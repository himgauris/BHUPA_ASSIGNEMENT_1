using BHUPA_ASSIGNEMENT_1.DAL;
using BHUPA_ASSIGNEMENT_1.ErrorHandlingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHUPA_ASSIGNEMENT_1.Login_reg_Pages
{
    //update not working
    public partial class UpdateProfile : System.Web.UI.Page
    {
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
        string LoginPageURL = System.Configuration.ConfigurationManager.AppSettings["LoginPageURL"];

        ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                    LoadExistingValues();
            }
            catch (Exception exception)
            {
                HandleError.HandleErrors(exception);
                Server.Transfer(ErrorPageURL, false);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Register.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
            CommonDBOperations<Event_Users> dal = new CommonDBOperations<Event_Users>(_context);
            Event_Users update_user = new Event_Users();
            HttpCookie cookieUserID = HttpContext.Current.Request.Cookies["userID"];
            if (cookieUserID != null)
            {
                update_user.UserID = Convert.ToInt32(cookieUserID.Value);
                update_user.FirstName = FirstName.Text;
                update_user.LastName = LastName.Text;
                update_user.EmailID = Email.Text;
                update_user.UserName = UserName.Text;
                update_user.Password = Password.Text;

                if (update_user != null)
                {
                    dal.UpdateRecord(update_user);
                    Response.Redirect("/Default.aspx", false);
                }
            }        
            else
                Server.Transfer(ErrorPageURL, false);
        }

        protected int GetloggedInUser()
        {
            HttpCookie cookieUsername = HttpContext.Current.Request.Cookies["userID"];
            if (cookieUsername != null)
                return Convert.ToInt32(cookieUsername.Value);
            else
                return 0;
        }

        protected void LoadExistingValues()
        {
            Event_Users user = new Event_Users(); 
            CommonDBOperations<Event_Users> dal = new CommonDBOperations<Event_Users>(_context);
            if (GetloggedInUser() > 0)
            {
                user = dal.GetByID(GetloggedInUser());
                if (user != null)
                {
                    FirstName.Text = user.FirstName;
                    LastName.Text = user.LastName;
                    UserName.Text = user.UserName;
                    Password.Text = user.Password;
                    Email.Text = user.EmailID;
                    ConfirmPassword.Text = user.Password;
                }
            }
            else
            {
                Response.Redirect(LoginPageURL, false);
            }
        }

    }
}
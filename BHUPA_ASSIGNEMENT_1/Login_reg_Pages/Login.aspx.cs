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
    public partial class Login : System.Web.UI.Page
    {
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
        string LoginPageURL = System.Configuration.ConfigurationManager.AppSettings["LoginPageURL"];

        protected override void OnInit(EventArgs e)
        {
            btnLogin.Click += Login_Click;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckIfValidUser())
                {
                    RedirectToProgramsList();
                }
                else
                {
                    lblMessage.Text = "Please enter correct username or password";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch(Exception exception)
            {
                HandleError.HandleErrors(exception);
                Server.Transfer(ErrorPageURL,false);
            }
        }

        protected void RedirectToProgramsList()
        {
            HttpCookie cookieLoginSuccess = new HttpCookie("loginSuccess");
            cookieLoginSuccess.Value = "1";
            cookieLoginSuccess.Expires = DateTime.Now.AddMinutes(10);
            HttpContext.Current.Response.Cookies.Add(cookieLoginSuccess);
            Response.Redirect("/Default.aspx", false);
        }
        protected Boolean CheckIfValidUser()
        {
            ASS_EventUsersEntities _context = new ASS_EventUsersEntities();
            CommonDBOperations<Event_Users> user = new CommonDBOperations<Event_Users>(_context);

            Event_Users logged_in_user = user.GetAllRecords().Single(p => (p.UserName.Trim() == UserName.Text.Trim() && p.UserName.Trim() == UserName.Text.Trim()));
            if (logged_in_user != null)
            {
                HttpCookie cookieUserID = new HttpCookie("userID");
                cookieUserID.Value = Convert.ToString(logged_in_user.UserID);
                cookieUserID.Expires = DateTime.Now.AddMinutes(10);
                HttpContext.Current.Response.Cookies.Add(cookieUserID);
                return true;
            }

            return false;
        }
    }
}
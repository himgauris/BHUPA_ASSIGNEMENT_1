using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHUPA_ASSIGNEMENT_1
{
    public partial class SiteMaster : MasterPage
    {
        string ErrorPageURL = System.Configuration.ConfigurationManager.AppSettings["ErrorPageURL"];
        string LoginPageURL = System.Configuration.ConfigurationManager.AppSettings["LoginPageURL"];

        protected override void OnLoad(EventArgs e)
        {
            HttpCookie cookieLoginSuccess = HttpContext.Current.Request.Cookies["loginSuccess"];
            lnkLogin.Text = (cookieLoginSuccess != null && cookieLoginSuccess.Value == "1")? "Log out": "Log In";
        }

        protected override void OnInit(EventArgs e)
        {
            lnkLogin.Click += lnkLogin_Click;
        }
  
        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            if(lnkLogin.Text.Trim().ToLower()=="log in")
                Response.Redirect(LoginPageURL,false);

            if (lnkLogin.Text.Trim().ToLower() == "log out")
            {
                HttpCookie cookieLoginSuccess = new HttpCookie("loginSuccess");           
                cookieLoginSuccess.Value = "0";
                cookieLoginSuccess.Expires = DateTime.Now.AddMinutes(10);
                HttpContext.Current.Response.Cookies.Add(cookieLoginSuccess);
                Response.Redirect("/default.aspx");               
            }
        }
    }
}
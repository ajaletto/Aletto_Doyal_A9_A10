﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aletto_Doyal_A9_A10
{
    public partial class Aletto_A9_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["alettoTryIt"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                lblCookieTryit.Text = "Welcome, try it page tester. Enter your username into the text box and press the" +
                    "\"Add\" button to save the entered information in your cookie.";
            }
            else
            {
                lblCookieTryit.Text = "Welcome, " + myCookies["Name"].ToString() + ". Enter your new username into the text box" +
                    " and press the \"Add\" button to change your username to the entered information in your cookie. Otherwise, " +
                    "press the \"Delete\" button to delete your cookie and start over.";
            }
        }

        protected void btnCookieTryitAdd_Click(object sender, EventArgs e)
        {
            HttpCookie myCookies = new HttpCookie("alettoTryIt");
            if (String.IsNullOrWhiteSpace(txtbxCookieTryitInput.Text))
            {
                lblCookieTryItWarning.Text = "You must input your username!";
            }
            else
            {
                myCookies["Value"] = txtbxCookieTryitInput.Text.ToString();
                myCookies.Expires = DateTime.Now.AddDays(1d);
                myCookies.Domain = "Cookie Try It";
                Response.Cookies.Add(myCookies);
                lblCookieTryItWarning.Text = String.Empty;
                txtbxCookieTryitInput.Text = String.Empty;
                lblCookieTryit.Text = "Your username for this try it page (and only this try it page) has been successfully set to \"" +
                    myCookies["Value"].ToString() + "\". Enter your new username into the text box" +
                    " and press the \"Add\" button to change your username to the entered information in your cookie. Otherwise, " +
                    "press the \"Delete\" button to delete your cookie and start over.";
            }
        }

        protected void btnCookieTryitDelete_Click(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["alettoTryIt"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                lblCookieTryItWarning.Text = "You don't have any cookies for this Try It page!";
            }
            else
            {
                HttpCookie myCookie = new HttpCookie("UserSettings");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                lblCookieTryItWarning.Text = String.Empty;
                lblCookieTryit.Text = "Your username for this try it page (and only this try it page) has been successfully deleted. " +
                    "Enter your new username into the text box and press the \"Add\" button to reset your username.";
            }
        }
    }
}
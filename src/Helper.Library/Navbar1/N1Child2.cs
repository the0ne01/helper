﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Helper.Library
{
    public class N1Child2 : BasePage
    {
        public N1Child2(LoginPage loginPage)
        {
            loginPage.Navbar1.Click();
            Child2WebElement.Click();
        }



        public IWebElement Child2WebElement => WebDriver.Driver.FindElement(By.LinkText("Child2"));
    }
}

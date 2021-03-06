﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper.Library.zRecycleBin;
using OpenQA.Selenium;
using Helper.Library;

namespace Helper.Tests
{
    [TestClass]
    public class LoginPageTest
    {
        protected LoginPage page;

        [TestInitialize]
        public void SetupTest()
        {
            page = new LoginPage("to test Login page");
        }

        [TestMethod]
        public void AssertAllElementsEnabled()
        {
            Assert.IsTrue(page.LoginField.Enabled);
            Assert.IsTrue(page.PasswordField.Enabled);
            Assert.IsTrue(page.LoginButton.Enabled);
            Assert.IsTrue(page.RememberMeButton.Enabled);
            Assert.IsTrue(page.ForgotPasswordLink.Enabled);
            Assert.IsTrue(page.CompanyLogo.Enabled);
        }

        [TestMethod]
        public void AssertRecaptchaAndLoginFailMessageDisplayed()
        {
            for (var i = 0; i<5; i++)
            {
                page.LoginAs("wrongUserId", "wrongPassword");
                WebDriver.WaitUntilElementIsVisible(page.webDriver(), By.TagName("li"), 5);
                Assert.IsTrue(page.LoginFailMessage.Displayed);
            }
            Assert.IsTrue(page.Recaptcha.Displayed);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            page.Quit();
        }
    }
}

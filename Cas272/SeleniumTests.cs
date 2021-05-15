using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Cas272.Lib;
using System.Diagnostics;

namespace Cas272
{
    class SeleniumTests : BaseTest
    {
               
        [SetUp]
        public void SetUp()


        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }

        [Test]

        public void TestGoogleSearch()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Logger.beginTest("TestGoogleSearch");
            Logger.log("INFO", "Starting test");

            this.ExplicitWait(500);

            this.GoToURL("https://www.google.com/");
            this.driver.FindElement(By.Id("L2AGLb")).Click();

            this.ExplicitWait(500);

            IWebElement SearchField = this.MyFindElement(By.Name("q"));
            SearchField.SendKeys("Selenium automation with C#");

            this.ExplicitWait(500);

            IWebElement SearchButton = this.MyFindElement(By.Name("btnK"));                    
            SearchButton.Click();

            this.ExplicitWait(500);

            IWebElement ChangeToEnglish = this.MyFindElement(By.PartialLinkText("to English"));
            ChangeToEnglish.Click();

            this.ExplicitWait(2000);

            IWebElement Body = this.MyFindElement(By.TagName("body"));

            bool containsVideos = Body.Text.Contains("Videos");
            stopwatch.Stop();
            Logger.log("INFO", $"Test ran for: {stopwatch.ElapsedMilliseconds / 1000} seconds");

            if (Body.Text.Contains("Videos"))
            {
                Logger.log("ASSERT", "Test passed.");
                Logger.endTest();
                Assert.Pass();
            }
            else
            {
                Logger.log("ASSERT", "Test failed - No videos present.");
                Logger.endTest();
                Assert.Fail("Test failed - No videos present.");
            }
                        
        }

        

    }
}

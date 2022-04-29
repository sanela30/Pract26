using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;


namespace Pract26
{
     class SeleniumTests
    {

        //IWebDriver driverFirefox;
        IWebDriver driverChrome;

        string url = "https://www.google.com/";
        /*
                [Test]
                public void TestGoogleSearchINFirefox()
                {
                    driverFirefox = new FirefoxDriver();
                    driverFirefox.Manage().Window.Maximize();
                    Wait(2000);
                    driverFirefox.Navigate().GoToUrl(url);
                    Wait(2000);

                }
        */

        [Test]
        public void TestGoogleSearchINChrome()
        {
            driverChrome = new ChromeDriver();
            Navigate(driverChrome, url);

            By selector = By.Name("q");
            IWebElement search = FindElement(driverChrome, selector);
            //IWebElement search = FindElement(driverChrome,By.Name("q"));
            
            if(search != null)
            {
                SendKeys(search, "Selenium C#",sendEnter:false);
            }

            selector= By.XPath("//input[@name='btnK']");
            IWebElement button=FindElement(driverChrome, selector);
            if(button != null)
            {
                button.Click();
            }
           
            Wait(4000);
            /*
            selector = By.PartialLinkText("to English");
            IWebElement changeToEnglish=FindElement(driverChrome, selector);
            if(changeToEnglish != null)
            {
                changeToEnglish.Click();
                Wait(2000);
            }*/
            
            IWebElement body = FindElement(driverChrome, By.TagName("body"));
            if(body.Text.Contains("Видео снимци"))
            {
                Assert.Pass("Test completed successfuly.");
            }else
            {
                Assert.Fail("Test failed-no video present");
            }
            /*
            IWebElement nav=FindElement(driverChrome, By.Id("top_nav"));
            if(nav!= null)
            {
               if (nav.Displayed && nav.Enabled)
                {
                    Assert.Pass("Test completed successfuly.");
                }
                else
                {
                    Assert.Fail("Element is not visible");
                }
            }
            else
            {
                Assert.Fail("Test failed-no element present");
            }*/


        }
        [TearDown]
        public void TearDown()
        {
            driverChrome.Close();
        }
        public IWebElement FindElement(IWebDriver driverII,By selector)
        {
            IWebElement elReturn = null;
            try
            {
                elReturn = driverII.FindElement(selector);
            }
            catch (NoSuchElementException)
            {
            }catch(Exception e)
            {
                throw e;
            }
           
            return elReturn;
        }

        private void SendKeys(IWebElement element,string keys,int wait=1000, bool sendEnter=true)
        {
            element.SendKeys(keys);
            Wait(wait);
            if (sendEnter)
            {
                element.SendKeys(Keys.Enter);
            }
        }
        static private void Navigate(IWebDriver driverI,string url,int wait=1000)
        {
            driverI.Manage().Window.Maximize();
            Wait(wait);
            driverI.Navigate().GoToUrl(url);
            Wait(wait);
        }
        static private void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

    }
}

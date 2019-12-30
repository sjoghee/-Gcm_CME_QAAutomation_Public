using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.IE;



namespace CMEQAAutomation
{
   [TestClass]
    class Cmebase
    {
       IWebDriver cmeqadriver;

       [TestMethod]
       public IWebDriver DriverInitialization()
       {

           InternetExplorerOptions options = new InternetExplorerOptions();
           options.PageLoadStrategy = PageLoadStrategy.Eager;
           options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
           options.IgnoreZoomLevel = true;
           cmeqadriver = new InternetExplorerDriver(@"C:\CMEQAAutomation\CMEQAAutomation\packages\Selenium.InternetExplorer.WebDriver.3.141.5\driver", options);

           return cmeqadriver;

          
       }

       [TestMethod]
       public bool validatelementexist(By by)
       {
           try
           {

               cmeqadriver.FindElement(by);
               return true;
           }
           catch (NoSuchElementException)
           {
               return false;
           }
       }
       [TestMethod]
       public void waitforPageload()
       {
           Thread.Sleep(10000);
       }

       [TestMethod]
       public void waitforwire()
       {
           Thread.Sleep(5000);
       }
       [TestMethod]
       public void waitforBatchload()
       {
           Thread.Sleep(15000);
       }
    }

}

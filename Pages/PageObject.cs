using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace dotnet_core_test.Pages
{
    public abstract class PageObject {
        protected IWebDriver _driver = null;

        public PageObject(IWebDriver driver)
        {
            this._driver = driver;
            
        } 
    }

}

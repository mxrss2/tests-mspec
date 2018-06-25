using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace dotnet_core_test.Pages
{
    public class SearchResultsPage : PageObject{
        public SearchResultsPage(IWebDriver driver)
            : base(driver)
        {
            
        }
        
        private IWebElement Results{
            get
            {
                var results = _driver.FindElements(By.CssSelector("#resultStats"));

                if (results.Count == 0) { return null; }
                else
                {
                    return results[0];
                }
            }
        }

        public bool NoResults{
            get{
                return Results == null;
            }
        }

        private IWebElement EndOfPage
        {
            get
            {
                var results = _driver.FindElements(By.CssSelector("#ofr > i"));

                if (results.Count == 0)
                {
                    return null;
                } else
                {
                    return results[0];
                }

            }
        }

        public bool AtEndOfPages { get
            {
                if (EndOfPage != null) {
                    return EndOfPage.Text.StartsWith("In order to show you the most relevant");
                } else {
                    return false;
                }
            }
        }

        public SearchResultsPage ClickOnPage(int page)
        {
            _driver.FindElement(By.CssSelector($"a[aria-label='Page {page}']")).Click();
            return new SearchResultsPage(_driver);
        }

        internal bool OnPage(int page)
        {
            var resultsText = Results.Text;
            return resultsText.StartsWith($"Page {page}");
        }
    }

}

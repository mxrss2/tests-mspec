

namespace dotnet_core_test.Pages
{
    using OpenQA.Selenium;

    public class SearchPage : PageObject
    {
        public SearchPage(IWebDriver driver)
            : base(driver)
        {
            _driver.Navigate().GoToUrl(@"https://google.com/");
        }

        private IWebElement SearchBox { get { return _driver.FindElement(By.Id("lst-ib") ); } }


        public string SearchTerm { 
            get {
                return SearchBox.Text;
            }
            set {
                SearchBox.SendKeys(value);
            }
        }
        
        public SearchResultsPage Submit(){
            _driver.FindElement(By.Name("btnK"))
                .Submit();
            var screenFile = ((ITakesScreenshot)_driver).GetScreenshot();
            screenFile.SaveAsFile("./testFile.png");
            return new SearchResultsPage(_driver);
        }

    }

}

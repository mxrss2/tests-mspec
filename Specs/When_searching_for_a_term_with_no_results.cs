using System;
using Machine.Specifications;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using dotnet_core_test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_core_test.Specs
{
    class When_searching_for_a_term_with_no_results
    {
        Establish context = () =>
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            //options.AddArgument("headless");

            var caps = new ChromeOptions().ToCapabilities();
            ((DesiredCapabilities)caps).SetCapability("name", "chrome");
            ((DesiredCapabilities)caps).SetCapability("name", "chrome");
            driver = new RemoteWebDriver(new Uri("http://192.168.0.25:31366/wd/hub"), options.ToCapabilities());

        };

        Cleanup after = () => {
            driver.Dispose();
            driver = null;
            resultsPage = null;
        };

        static RemoteWebDriver driver;
        static SearchResultsPage resultsPage;
        Because of = () => {
            var page = new SearchPage(driver);
            page.SearchTerm = "hgjaksdk1";
            resultsPage = page.Submit();
        };

        It should_have_no_results = () => Assert.IsTrue(resultsPage.NoResults);

    }
}

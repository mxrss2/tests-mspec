using System;
using Machine.Specifications;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using dotnet_core_test.Pages;

namespace dotnet_core_test.Specs
{
    [Tags("Watchmen"), Tags("UI-Test")]
    class When_clicking_on_a_search_with_many_results
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

        Cleanup after = () =>
        {
            driver.Dispose();
            driver = null;
            resultsPage = null;
        };

        static RemoteWebDriver driver;
        static SearchResultsPage resultsPage;
        Because of = () =>
        {
            var page = new SearchPage(driver);
            page.SearchTerm = "google";
            resultsPage = page.Submit();
            resultsPage.ClickOnPage(6);
        };

        It should_be_on_the_sixth_page = () => resultsPage.OnPage(6).ShouldBeTrue();  //resultsPage.NoResults.ShouldBeTrue();
        It should_not_be_on_final_page_of_results = () => resultsPage.AtEndOfPages.ShouldBeFalse();
    }
}

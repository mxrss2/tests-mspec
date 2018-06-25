using System;
using Machine.Specifications;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using dotnet_core_test.Pages;

namespace dotnet_core_test.Specs
{
    [Tags("Watchmen"), Tags("UI-Test")]
    class When_searching_for_a_term_with_a_manageable_list_of_results
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
            page.SearchTerm = "site:tmz.com mike roth";
            resultsPage = page.Submit();
            resultsPage.ClickOnPage(5);
        };

        It should_be_on_the_final_page = () => { resultsPage.AtEndOfPages.ShouldBeTrue(); }; //resultsPage.NoResults.ShouldBeTrue();

    }
}

namespace Exam_AutomateThePlanet.Pages
{
    using OpenQA.Selenium;

    using System.Threading;

    public partial class AutomateThePlanetPage : BasePage
    {
        public AutomateThePlanetPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ScrolltoQuickNav()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", QuickNavEl);
            js.ExecuteScript("window.scrollBy(0, -120)");
            Thread.Sleep(1000);
        }        
    }
}
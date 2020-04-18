namespace SeleniumTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using FluentAssertions;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using SeleniumTests.Pages.ResizablePage;
    using SeleniumTests.Pages.SelectablePage;
    using SeleniumTests.Pages.SortablePage;
    using NUnit.Framework.Interfaces;

    [TestFixture]
    public class DemoQATestsSecondSuite
    {
        private IWebDriver _driver;
        private ResizablePage _resizePage;
        private SelectablePage _selectPage;
        private SortablePage _sortPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _resizePage = new ResizablePage(_driver);
            _selectPage = new SelectablePage(_driver);
            _sortPage = new SortablePage(_driver);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if ((_driver != null) && (_driver.GetType().GetMethod("Close") != null))
            {
                _driver.Quit();
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(@"..\..\..\Pages\Screenshots\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }            
        }     

        /*************************************************************************************************
        *
        * Resizable Test
        *
        *************************************************************************************************/

        [Test]
        public void ResizableDefault_WidthHeight_ShouldResize()
        {
            _resizePage.NavigateTo("http://demoqa.com/resizable/");

            _resizePage.Resize(_resizePage.HandleObject, 300, 150);

            int width = _resizePage.ResizableObject.Size.Width;
            int height = _resizePage.ResizableObject.Size.Height;
            width.Should().Be(433);
            height.Should().Be(283);
        }

        [Test]
        public void ResizableConstrain_Object_ShouldResizeWithinContainer()
        {
            _resizePage.NavigateTo("http://demoqa.com/resizable/");
            _resizePage.Constrain.Click();
            var resizeObjectFixed = _resizePage.ResizableObjectFixed;
            int widthFixed = resizeObjectFixed.Size.Width;
            int heightFixed = resizeObjectFixed.Size.Height;
            int pointX_Fixed = resizeObjectFixed.Location.X;

            _resizePage.Resize(_resizePage.HandleMovableObject, 0, 200);

            var resizeObjectMovable = _resizePage.ResizableObjectMovable;
            int widthMovable = resizeObjectMovable.Size.Width;
            int heightMovable = resizeObjectMovable.Size.Height;
            int pointX_Movable = resizeObjectMovable.Location.X;

            widthFixed.Should().BeGreaterThan(widthMovable);
            heightFixed.Should().BeGreaterThan(heightMovable);
            pointX_Fixed.Should().BeLessThan(pointX_Movable);
        }

        /*************************************************************************************************
        *
        * Selectable Test
        *
        *************************************************************************************************/

        [Test]
        public void SelectableDefault_ObjectWhenSelected_ShouldContain()
        {            
            _selectPage.NavigateTo("http://demoqa.com/selectable/");
            var selectObject = _selectPage.SelectableObjectFourth;

            selectObject.Click();

            string isSelected = selectObject.GetAttribute("Class");
            isSelected.Should().Contain("ui-selected");

            string background = selectObject.GetCssValue("background-color");
            background.Should().Contain("rgba(243, 152, 20, 1)");
        }

        [Test]
        public void SelectableSerializeMultiple_MultipleObjectText_ShouldBe()
        {
            _selectPage.NavigateTo("http://demoqa.com/selectable/");
            _selectPage.Serialize.Click();

            _selectPage.SelectMultipleSerialize();

            _selectPage.HeaderSelectableObjectSerialize.Text.Should().Be("You’ve selected: #2#3#4#5.");
        }

        /*************************************************************************************************
        *
        * Sortable Test
        *
        *************************************************************************************************/

        [Test]
        public void SortableDefault_SortObjectsToOffset_ShouldBeInRightPosition()
        {
            _sortPage.NavigateTo("http://demoqa.com/sortable/");

            _sortPage.DragAndDropToOffset(_sortPage.SortableThird, 0, 80);
            _sortPage.DragAndDropToOffset(_sortPage.SortableSecond, 0, 170);

            _sortPage.SortableForth.Text.Should().Be("Item 3");
            _sortPage.SortableSeventh.Text.Should().Be("Item 2");
        }

        [Test]
        public void SortableConnectLists_SortListsAndCompare()
        {
            _sortPage.NavigateTo("http://demoqa.com/sortable/");
            _sortPage.ConnectLists.Click();

            _sortPage.SortLists();

            _sortPage.SortableListTwo.Count.Should().BeGreaterThan(_sortPage.SortableListOne.Count);
            _sortPage.SortableListTwo.Should().HaveCount(7);
        }
    }
}

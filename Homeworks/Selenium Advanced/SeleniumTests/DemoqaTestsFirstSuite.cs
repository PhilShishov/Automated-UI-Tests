//namespace SeleniumTests
//{
//    using NUnit.Framework;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Chrome;
//    using FluentAssertions;
//    using System.IO;
//    using System.Reflection;
//    using System.Threading;
//    using SeleniumTests.Pages.DraggablePage;
//    using SeleniumTests.Pages.DroppablePage;
//    using NUnit.Framework.Interfaces;

//    [TestFixture]
//    public class DemoQATestsFirstSuite
//    {
//        private IWebDriver _driver;
//        private DraggablePage _dragPage;
//        private DroppablePage _dropPage;

//        [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

//            _dragPage = new DraggablePage(_driver);
//            _dropPage = new DroppablePage(_driver);
//        }

//        [OneTimeTearDown]
//        public void OneTimeTearDown()
//        {
//            if ((_driver != null) && (_driver.GetType().GetMethod("Close") != null))
//            {
//                _driver.Quit();
//            }
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
//            {
//                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
//                screenshot.SaveAsFile(@"..\..\..\Pages\Screenshots\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
//            }
//        }

//        /*************************************************************************************************
//        *
//        * Draggable Test
//        *
//        *************************************************************************************************/

//        [Test]
//        public void DraggableTestDefault()
//        {
//            _dragPage.NavigateTo();

//            Thread.Sleep(2000);

//            _dragPage.DragAndDropToOffset(_dragPage.DragObject, 130, 240);

//            Thread.Sleep(3000);

//            string position = _dragPage.DragObject.GetAttribute("style");
//            position.Should().Contain("left: 130px; top: 240px;");
//        }

//        [Test]
//        public void DraggableTestVertical()
//        {
//            _dragPage.NavigateTo();
//            _dragPage.ConstrainMovement.Click();

//            Thread.Sleep(2000);

//            _dragPage.DragAndDropToOffset(_dragPage.DragObjectVertical, 0, 200);

//            Thread.Sleep(3000);

//            string position = _dragPage.DragObjectVertical.GetAttribute("style");
//            position.Should().Contain("left: 0px; top: 200px;");
//        }

//        [Test]
//        public void DraggableTestCursor()
//        {
//            _dragPage.NavigateTo();
//            _dragPage.CursorStyle.Click();

//            Thread.Sleep(2000);

//            _dragPage.DragCursor();

//            Thread.Sleep(3000);

//            string cursorTypeAfter = _dragPage.DragObjectCursor.GetCssValue("cursor");
//            cursorTypeAfter.Should().Be("auto");
//        }

//        /*************************************************************************************************
//        *
//        * Droppable Test
//        *
//        *************************************************************************************************/

//        [Test]
//        public void DroppableTestDefault()
//        {
//            _dropPage.GoToUrl();

//            Thread.Sleep(2000);

//            _dropPage.DragAndDrop(_dropPage.DropObject, _dropPage.DropObjectTarget);

//            Thread.Sleep(3000);

//            string backgroundColor = _dropPage.DropTargetAfterAction.GetCssValue("background-color");
//            backgroundColor.Should().Be("rgba(251, 249, 238, 1)");
//        }

//        [Test]
//        public void DroppableTestAccept()
//        {
//            _dropPage.GoToUrl();
//            _dropPage.Accept.Click();
//            var dropTarget = _dropPage.DropObjectValidTarget;

//            Thread.Sleep(2000);

//            _dropPage.DragAndDrop(_dropPage.DropObjectNonValid, dropTarget);
//            dropTarget.Text.Should().NotBe("Dropped!");

//            Thread.Sleep(3000);

//            _dropPage.DragAndDrop(_dropPage.DropObjectAccept, dropTarget);
//            dropTarget.Text.Should().Be("Dropped!");
//        }

//        [Test]
//        public void DroppableTestRevert()
//        {
            //_dropPage.GoToUrl();
//            _dropPage.Revert.Click();
//            var sourceStart = _dropPage.SourceStart.Location;
//            string classBefore = _dropPage.Target.GetAttribute("class");

//            Thread.Sleep(3000);

//            _dropPage.DragAndDrop(_dropPage.SourceStart, _dropPage.Target);

//            Thread.Sleep(4000);

//            string classAfter = _dropPage.FullTarget.GetAttribute("class");
//            var sourceEnd = _dropPage.SourceEnd.Location;

//            classBefore.Should().NotBe(classAfter);
//            sourceStart.Should().Be(sourceEnd);
//        }
//    }
//}

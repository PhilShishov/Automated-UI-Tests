﻿namespace Exam_IpRanges.Pages
{
    using System.Collections.Generic;

    using Exam_AutomateThePlanet.Pages;

    using OpenQA.Selenium;

    public partial class IpHomePage : BasePage
    {
        public IpHomePage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetNames()
        {
            var list = new List<string>();
            foreach (var element in Names)
            {
                list.Add(element.Text);
            }
            return list;
        }
    }
}
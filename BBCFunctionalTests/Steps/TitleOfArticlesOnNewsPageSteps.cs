﻿using BBCFunctionalTests.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace BBCFunctionalTests.Steps
{
    [Binding]
    public class TitleOfArticlesOnNewsPageSteps
    {
        [When(@"I go to the News Page")]
        public void WhenIGoToTheNewsPage()
        {
            HomePage homePage = new HomePage(DriverInstance.Current);
            homePage.ClickOnMenuNews().ClickOnButtonCloseOnPopUpWithProposeOfSabscription();
        }
        
        [Then(@"the title of main article should be ""(.*)""")]
        public void ThenTheTitleOfMainArticleShouldBe(string expectedTitleOfMainArticleOnNewsPage)
        {
            NewsPage newsPage = new NewsPage(DriverInstance.Current);
            Assert.IsTrue(newsPage.GetActualTitleOfMainArticleOnHomePage().Contains(expectedTitleOfMainArticleOnNewsPage));
        }
        [Then(@"the titles of secondary articles should be:")]
        public void ThenTheTitlesOfSecondaryArticlesShouldBe(Table table)
        {
            IEnumerable<string> expectedsecondaryTitles = from row in table.Rows select row["Titles"];

            NewsPage newsPage = new NewsPage(DriverInstance.Current);
            List<string> secondaryTitlesString = new List<string>();

            foreach (IWebElement webElement in newsPage.GetSecondaryArticleTitle())
            {
                string textsecondaryTitlesString = webElement.Text;
                secondaryTitlesString.Add(textsecondaryTitlesString);
            }
            foreach (var titles in expectedsecondaryTitles)
            {
                Assert.IsTrue(secondaryTitlesString.Contains(titles));
            }
            

        }
        [When(@"Entere the text of the Category link of the headline article in Search bar")]
        public void WhenEntereTheTextOfTheCategoryLinkOfTheHeadlineArticleInSearchBar()
        {
            NewsPage newsPage = new NewsPage(DriverInstance.Current);
            newsPage.SendKeysInSearchInputOnNewsPage();
        }

        [Then(@"the title of article should be ""(.*)""")]
        public void ThenTheTitleOfArticleShouldBe(string expectedTitleArticle)
        {
            SearchPage searchPage = new SearchPage(DriverInstance.Current);
            Assert.IsTrue(searchPage.GetTitleArticle().Contains(expectedTitleArticle));
        }
 




    }
}

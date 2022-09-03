using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
namespace lebrisProject.StepDefintion
{
    
   
    [Binding]
    public class LebisPartnerSelectionPageStepDefinitions
    {
        IWebDriver chromeDriver = new ChromeDriver();

        [Given(@"that I am on the lebris website")]
        public void GivenThatIAmOnTheLebrisWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.liberis.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("liberis"));
        }

        [When(@"I click on Get a demo Link")]
        public void WhenIClickOnGetADemoLink()
        {
            var demoBtton = chromeDriver.FindElement(By.ClassName("header-cta"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("header-cta")));
            demoBtton.Click();

        }

        [Then(@"verify we landed on Partner Selection page")]
        public void ThenVerifyWeLandedOnPartnerSelectionPage()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".radio_container > div")));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("become a partner"));

        }

        [Then(@"has the required three Types of partners")]
        public void ThenHasTheRequiredThreeTypesOfPartners()
        {
            IList<IWebElement> testCount = chromeDriver.FindElements(By.CssSelector(".radio_container > div"));
            Assert.IsTrue(testCount.Count() == 3);
        }


        [Then(@"validation message when user does not make a partner selection and click ‘Get a demo’")]
        public void ThenValidationMessageWhenUserDoesNotMakeAPartnerSelectionAndClickGetADemo()
        {
            var demoBtton = chromeDriver.FindElement(By.CssSelector("a[href$= '#0']"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href$= '#0']")));
            demoBtton.Click();
            var validationString = chromeDriver.FindElement(By.CssSelector(".ph-error-inner")).Text;
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ph-error-inner")));
            Assert.True(validationString.Equals("Please select a type of partner"));
        }
        [When(@"we landed on Partner Selection page")]
        public void WhenWeLandedOnPartnerSelectionPage()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".radio_container > div")));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("become a partner"));

        }
        [Then(@"We select broker radio button")]
        public void ThenWeSelectBrokerRadioButton()
        {
            var brokerRadioBtn = chromeDriver.FindElement(By.CssSelector(".radio_container>div:nth-child(1)"));
            brokerRadioBtn.Click();
            var demoBtton = chromeDriver.FindElement(By.CssSelector("a[href$='broker-iso-form']"));
            demoBtton.Click();
        }

        [Then(@"land on broker form")]
        public void ThenLandOnBrokerForm()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("broker-iso-form"));
            var partnerFormSrc = chromeDriver.FindElement(By.CssSelector(".form-base--wrapper>script")).GetAttribute("src");
            Assert.True(partnerFormSrc.Contains("https://liberisuk.formstack.com/forms/js.php/partnership_opportunities"));
        }

        [Then(@"We select ISO radio button")]
        public void ThenWeSelectISORadioButton()
        {
            var ISORadioBtn = chromeDriver.FindElement(By.CssSelector(".radio_container>div:nth-child(2)"));
            ISORadioBtn.Click();
            var demoBtton = chromeDriver.FindElement(By.CssSelector("a[href$= 'broker-iso-form']"));
            demoBtton.Click();
        }

        [Then(@"land on ISO form")]
        public void ThenLandOnISOForm()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("broker-iso-form"));
            var partnerFormSrc = chromeDriver.FindElement(By.CssSelector(".form-base--wrapper>script")).GetAttribute("src");
            Assert.True(partnerFormSrc.Contains("https://liberisuk.formstack.com/forms/js.php/partnership_opportunities"));
    
        }

        [Then(@"We select Strategic Partner radio button")]
        public void ThenWeSelectStrategicPartnerRadioButton()
        {
            var StrategicPartnerRadioBtn = chromeDriver.FindElement(By.CssSelector(".radio_container>div:nth-child(3)"));
            StrategicPartnerRadioBtn.Click();
            var demoBtton = chromeDriver.FindElement(By.CssSelector("a[href$= 'strategic-partner-form']"));
            demoBtton.Click();
        }

        [Then(@"land on Strategic Partner form")]
        public void ThenLandOnStrategicPartnerForm()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".form-base")));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("strategic partner form"));
            var partnerFormSrc = chromeDriver.FindElement(By.CssSelector(".form-base--wrapper>script")).GetAttribute("src");
            Assert.True(partnerFormSrc.Contains("https://liberisuk.formstack.com/forms/js.php/strategic_partner"));
        }

        [When(@"I scroll down to Contact us")]
        public void WhenIScrollDownToContactUs()
        {
            var element = chromeDriver.FindElement(By.CssSelector(".contact-block>a"));
            Actions actions = new Actions(chromeDriver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        [When(@"click on Contact us button")]
        public void WhenClickOnContactUsButton()
        {
            var contsctUsBtn = chromeDriver.FindElement(By.CssSelector(".contact-block>a"));
            contsctUsBtn.Click();
        }


        [Then(@"I land on Contact us page")]
        public void ThenILandOnContactUsPage()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".hero-platform__text>h2")));
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("contact-us"));
            var contactUsHeader = chromeDriver.FindElement(By.CssSelector(".hero-platform__text>h2")).Text;
            Assert.True(contactUsHeader.Contains("Contact us"));

        }


        [After]
        public void dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
            }

            }
    }
}

using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GaugeProjectTemplate
{
	public class LandingPageSpecImplementation 
	{
		public IWebDriver Driver
		{
			get { return DriverFactory.Driver; }
		}

		[Step("Go to home page")]
		public void NavigateToHome()
		{
			Driver.Navigate().GoToUrl(DriverFactory.HostUrl);
		}

		[Step("I see a <Hello Gauge> message")]
		public void VerifyWelcomeMessage(string message)
		{
			var element = Driver.FindElement(By.Id("welcomeMessage"));
			Assert.AreEqual(element.Text, message);
		}

		[Step("I see a <A simple app to facilitate Gauge automation testing.> description")]
		public void VerifyDescription(string description)
		{
			var element = Driver.FindElement(By.Id("description"));
			Assert.AreEqual(element.Text, description);
		}

		[Step("I see a <View Book Listing> link")]
		public void VerifyLink(string linkText)
		{
			var element = Driver.FindElement(By.Id("viewBooksLink"));
			Assert.AreEqual(element.Text, linkText);
		}
	}
}

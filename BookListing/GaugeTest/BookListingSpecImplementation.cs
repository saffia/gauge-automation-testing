using System.Collections.Generic;
using System.Linq;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GaugeProjectTemplate
{
	public class BookListingSpecImplementation
	{
		public IWebDriver Driver
		{
			get { return DriverFactory.Driver; }
		}

		[Step("Go to View Book Listing page")]
		public void NavigateToListingPage()
		{
			Driver.Navigate().GoToUrl("http://localhost:82/Book");
		}

		[Step("Check that the following books are listed <table>")]
		public void ListBooks(Table table)
		{
			var rows = table.GetTableRows();

			foreach (var row in rows)
			{
				SearchBook(row.GetCell("Title"));
				VerifyBookIsListed(row.GetCell("Title"));
			}
		}

		[Step("Search for book with title <title>")]
		public void SearchBook(string title)
		{
			Driver.FindElement(By.Id("searchText")).Clear();
			Driver.FindElement(By.Id("searchText")).SendKeys(title);
			Driver.FindElement(By.Id("searchButton")).Click();
		}

		[Step("The book <title> is listed")]
		public void VerifyBookIsListed(string title)
		{
			var tds = Driver.FindElements(By.TagName("td"));
			var foundItems = tds.Where(td => td.Text.ToLower() == title.ToLower());

			Assert.IsNotNull(foundItems);
			var webElements = foundItems as IList<IWebElement> ?? foundItems.ToList();
			Assert.IsNotEmpty(webElements);
			Assert.GreaterOrEqual(1, webElements.Count());
			foreach (var item in webElements)
			{
				Assert.AreEqual(item.Text.ToLower(), title.ToLower());
			}
		}
		
		[Step("Check that the following books are not listed <table>")]
		public void ListBooksDoesNotExist(Table table)
		{
			var rows = table.GetTableRows();

			foreach (var row in rows)
			{
				SearchBook(row.GetCell("Title"));
				VerifyBookIsNotListed();
			}
		}

		public void VerifyBookIsNotListed()
		{
			var tds = Driver.FindElements(By.TagName("td"));
		
			Assert.IsEmpty(tds);
			var error = Driver.FindElement(By.Id("error"));
			Assert.AreEqual("No results found.", error.Text);
		}
	}
}

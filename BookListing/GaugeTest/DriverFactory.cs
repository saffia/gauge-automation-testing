using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GaugeProjectTemplate
{
	public class DriverFactory
	{
		public static IWebDriver Driver { get; set; }
		public static string HostUrl
		{
			get { return "http://localhost:82/"; }
		}

		[BeforeSuite]
		public static void Setup()
		{
			Driver = new FirefoxDriver();
			Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
		}

		[AfterSuite]
		public static void TearDown()
		{
			Driver.Close();
		}
	}
}

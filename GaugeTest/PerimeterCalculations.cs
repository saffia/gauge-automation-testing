using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauge.CSharp.Lib.Attribute;

namespace GaugeProjectTemplate
{
	public class PerimeterCalculations
	{
		[Step("Output specification title")]
		public void SpecDescription()
		{
			Console.WriteLine("Perimeter Calculations");
		}

		[Step("Calculate rectangle perimeter with length <20> and breadth <10>")]
		public void Rectangle(string param1)
		{
			Assert.
		}
	}
}

using System;
namespace WebCalcServ.Models
{
	public struct CalculateData
	{
		public string RawLine;
		public string Result;
		public List<Tuple<double, double>> coords;
	}
}


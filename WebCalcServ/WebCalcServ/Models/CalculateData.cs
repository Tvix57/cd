using System;
namespace WebCalcServ.Models
{
	public struct CalculateData
	{
		public string RawLine = "";
		public string Result = "";
		public double[] CoordinateX = Array.Empty<double>();
		public double[] CoordinateY = Array.Empty<double>();
        public List<string> History { get; set; } = new();
        public CalculateData() {}
    }
}


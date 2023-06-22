using System;
namespace WebCalcServ.Models
{
	public struct CalculateData
	{
		public string RawLine = String.Empty;
		public string Result = String.Empty;
		public double[] CoordinateX = Array.Empty<double>();
		public double[] CoordinateY = Array.Empty<double>();
        public List<string> History { get; set; } = new();
        public CalculateData() {}
    }
}


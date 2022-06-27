using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
    class TemplateFC13SumErr:Template
    {
		public void SetStructure(string type)
		{
			string[] structLines;
			switch (type)
			{
				case "0":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\SumErr\TemplateFC13SumE_Type0.txt");
					break;
				case "1":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\SumErr\TemplateFC13SumE_Type0.txt");
					break;
				case "2":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\SumErr\TemplateFC13SumE_Type2.txt");
					break;
				case "3":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\SumErr\TemplateFC13SumE_Type3.txt");
					break;
				default:
					structLines = new string[] { " " };
					break;
			}

			unfilledTemplateLines.AddRange(structLines);
		}

		private void Fill(List<string> templateLines, Component component)
		{
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{symbol}}", component.Symbol);
			}
		}

		public List<string> GetFilled(Component component)
		{
			List<string> filledTemplateLines = new List<string>();

			filledTemplateLines.AddRange(unfilledTemplateLines);
			Fill(filledTemplateLines, component);

			return filledTemplateLines;
		}
	}
}

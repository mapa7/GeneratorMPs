using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
	 class TemplateFC10:Template
	{

		public void SetStructure(string type)
		{
			string[] structLines;
			switch (type)
            {
				case "0":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10.txt");
					break;
				case "1":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10.txt");
					break;
				case "2":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10.txt");
					break;
				case "3":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10.txt");
					break;
				case "4":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10_Type4.txt");
					break;
				case "5":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10_Type5.txt");
					break;
				default:
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC10\TemplateFC10.txt");
					break;
			}

			unfilledTemplateLines.AddRange(structLines);
		}

		private void Fill(List<string> templateLines, Component component)
		{
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{symbol}}", component.Symbol);
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{numberCmd}}", component.CommandNumber);
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{partCmd}}", component.CommandPart);
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
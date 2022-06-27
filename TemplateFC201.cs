using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
	 class TemplateFC201:Template
	{
		public TemplateFC201()
		{

		}

		public void GetStructure()
		{
			string[] structLines;
		
			structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC201\TemplateFC201_Type1.txt");
	
			unfilledTemplateLines.AddRange(structLines);
		}

		private void Fill(List<string> templateLines, Component component)
		{
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{symbol}}", component.Symbol);
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{dpAdress}}", component.DpAdress);
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{safetyZone}}", component.SafetyZone);
			}
		}

		public List<string> GetFilled(Component component)
		{
			List<string> filledTemplateLines = new List<string>();

			GetStructure();
			filledTemplateLines.AddRange(unfilledTemplateLines);
			Fill(filledTemplateLines, component);

			return filledTemplateLines;
		}
	}
}
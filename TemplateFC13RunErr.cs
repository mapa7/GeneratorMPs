using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
    class TemplateFC13RunErr:Template
    {
		public void SetStructure(string type)
		{
			string[] structLines;
			switch (type)
			{

				case "0":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\RunErr\TemplateFC13RunE.txt");
					break;

				case "1":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC13\RunErr\TemplateFC13RunE.txt");
					break;

				default:
					structLines = new string[] { " " };
					break;
			}

			unfilledTemplateLines.AddRange(structLines);
		}

		private void Fill(List<string> templateLines, Component component, int startTimer)
		{
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{symbol}}", component.Symbol);
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{timerNumber}}", startTimer.ToString());
			}
		}

		public List<string> GetFilled(Component component, int startTimer)
		{
			List<string> filledTemplateLines = new List<string>();

			filledTemplateLines.AddRange(unfilledTemplateLines);
			Fill(filledTemplateLines, component, startTimer);

			return filledTemplateLines;
		}
	}
}


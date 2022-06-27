using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
	 class TemplateFC16:Template
	{
		public TemplateFC16()
		{

		}

		public void SetStructure(string type)
		{
			string[] structLines;
			switch (type)
            {
				case "2":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC16\TemplateFC16_Type2.txt");
					break;
				case "3":
					structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC16\TemplateFC16_Type3.txt");
					break;
				default:
					structLines = new string[] { " " };
					break;
			}

			unfilledTemplateLines.AddRange(structLines);
		}

		private void Fill(List<string> templateLines, Component component, int startTimer)
		{
			int occurCnt = 0;
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{symbol}}", component.Symbol);
				if(templateLines[i].Contains("{{timerNumber}}"))
				{
			    var timer = startTimer + occurCnt;
				templateLines[i] = ReplaceTagInLine(templateLines[i], "{{timerNumber}}", timer.ToString());
				occurCnt++;
				}
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
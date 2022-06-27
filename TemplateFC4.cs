using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
	 class TemplateFC4:Template
	{

		private const int compStatText = 16;
		private const string firstCompTagToReplace = "{{symbol1}}";
		private const string secondCompTagToReplace = "{{symbol2}}";
		private const string statNuberTagToReplace = "{{numberStat}}";

		public TemplateFC4()
		{

		}

		private string[] GenerateCompTextReplace(Component component)
        {
			string addTextsPath = "";

			switch(component.Type)
            {
				case "0":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type0AddText.txt";
					break;
				case "1":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type1AddText.txt";
					break;
				case "2":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type2AddText.txt";
					break;
				case "3":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type3AddText.txt";
					break;
				case "4":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type4AddText.txt";
					break;
				case "5":
					addTextsPath = @"..\..\..\src\templates\FC4\TemplateFC4_Type5AddText.txt";
					break;
				default:
					break;
            }
		
			var readAddText = System.IO.File.ReadAllLines(addTextsPath);

			string[] addTexts = new string[compStatText];
	
			for(int i=0;i<addTexts.Length;i++)
            {
				if (i < readAddText.Length)
					addTexts[i] = readAddText[i];
				else
					addTexts[i] = "";
			}
			
			string[] genRepl = new string[compStatText];

			for(int i=0;i<genRepl.Length;i++)
            {
				if (component == null || addTexts[i] == "")
					genRepl[i] = zeroTag;
				else
					genRepl[i] = component.Symbol + " " + addTexts[i];
            }

			return genRepl;
        }
		
		private void FillCompData(List<string>templateLines, Component component, string tagToReplace)
        {
			var compSymbolRep = GenerateCompTextReplace(component);
			int occurCnt = 0;

			for (int i = 0; i < templateLines.Count; i++)
			{
				if (templateLines[i].Contains(tagToReplace))
				{
					templateLines[i] = ReplaceTagInLine(templateLines[i], tagToReplace, compSymbolRep[occurCnt]);
					occurCnt++;
				}
			}
		}

		private void FillStatusNumber(List<string> templateLines, string statusNumber,string tagToReplace)
        {
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i], statNuberTagToReplace, statusNumber);
			}
		}

		private void FillZeroTag(List<string> templateLines,string tagToReplace)
		{
			for (int i = 0; i < templateLines.Count; i++)
			{
				templateLines[i] = ReplaceTagInLine(templateLines[i],tagToReplace,zeroTag);
			}
		}

		public List<string> GetFilled(Component component1, Component component2, string statusNumber)
		{
			string[] structLines = System.IO.File.ReadAllLines(@"..\..\..\src\templates\FC4\TemplateFC4.txt");
			unfilledTemplateLines.AddRange(structLines);

			List<string> filledTemplateLines = new List<string>();

			filledTemplateLines.AddRange(unfilledTemplateLines);

			if (component1 != null)			 
				FillCompData(filledTemplateLines, component1, firstCompTagToReplace);
			else
				FillZeroTag(filledTemplateLines,firstCompTagToReplace);

			if (component2 != null)
				FillCompData(filledTemplateLines, component2, secondCompTagToReplace);
			else
				FillZeroTag(filledTemplateLines,secondCompTagToReplace);

			FillStatusNumber(filledTemplateLines, statusNumber, statNuberTagToReplace);

			return filledTemplateLines;
		}


    }
}
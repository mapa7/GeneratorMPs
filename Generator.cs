using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
    
    class Generator
    {
    
        public List<string> GenerateFC10(List<Component> componentList, int startNet)
        {
            List<string>genLines=new List<string>();

            int i = startNet;

            foreach (var component in componentList)
            {
                genLines.Add("NETWORK " + i);
                genLines.Add("");
                genLines.AddRange(GenerateFC10Net(component));
                genLines.Add("");
                i++;
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC10Net(Component component)
        {
            TemplateFC10 template = new TemplateFC10();
            template.SetStructure(component.Type);

            return template.GetFilled(component);
        }

        public List<string> GenerateFC13ReadyErr(List<Component> componentList, int startTimer, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;
            int j = startTimer;

            foreach (var component in componentList)
            {               
                if (component.IsFreqConv())
                {
                    genLines.Add("NETWORK " + i);
                    genLines.Add("");
                    genLines.AddRange(GenerateFC13ReadyErrNet(component, j));
                    genLines.Add("");
                    i++;
                    j++;
                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i-startNet);
            return genLines;
        }

        private List<string> GenerateFC13ReadyErrNet(Component component, int startTimer)
        {
            TemplateFC13ReadyErr template = new TemplateFC13ReadyErr();
            template.SetStructure(component.Type);
            return template.GetFilled(component, startTimer);
        }

        public List<string> GenerateFC13RunErr(List<Component> componentList, int startTimer, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;
            int j = startTimer;

            foreach (var component in componentList)
            {
                if (component.IsFreqConv())
                {
                    genLines.Add("NETWORK " + i);
                    genLines.Add("");
                    genLines.AddRange(GenerateFC13RunErrNet(component, j));
                    genLines.Add("");
                    i++;
                    j++;
                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC13RunErrNet(Component component, int startTimer)
        {
            TemplateFC13RunErr template = new TemplateFC13RunErr();
            template.SetStructure(component.Type);
            return template.GetFilled(component, startTimer);
        }

        public List<string> GenerateFC13SumErr(List<Component> componentList, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;

            foreach (var component in componentList)
            {

                if (component.HasSumOfErr()) 
                { 
                genLines.Add("NETWORK " + i);
                genLines.Add("");
                genLines.AddRange(GenerateFC13SumErrNet(component));
                genLines.Add("");
                i++;
                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC13SumErrNet(Component component)
        {
            TemplateFC13SumErr template = new TemplateFC13SumErr();
            template.SetStructure(component.Type);

            return template.GetFilled(component);
        }

        public List<string> GenerateFC13PosErr(List<Component> componentList, int startTimer, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;
            int j = startTimer;

            foreach (var component in componentList)
            {
                if (component.IsValve())
                {
                    genLines.Add("NETWORK " + i);
                    genLines.Add("");
                    genLines.AddRange(GenerateFC13PosErrNet(component, j));
                    genLines.Add("");
                    i++;
                    j = j + 2;

                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC13PosErrNet(Component component, int startTimer)
        {
            TemplateFC13PosErr template = new TemplateFC13PosErr();
            template.SetStructure(component.Type);
            return template.GetFilled(component, startTimer);
        }

        public List<string> GenerateFC4(List<Component> componentList, int startNet)
        {
            List<string> genLines = new List<string>();

            int j = startNet;

            var comp1 = new Component();
            var comp2 = new Component();

            for (int i=0;i<componentList.Count;i++)
            {
                genLines.Add("NETWORK " + j);
                genLines.Add("");

                comp1 = componentList[i];
                if (i < componentList.Count - 1)
                    comp2 = componentList[i + 1];

                if (comp1.GetStatusNumber() == comp2.GetStatusNumber() && comp1.GetStatusPart()=="X" && comp2.GetStatusPart() == "Y")
                {
                    genLines.AddRange(GenerateFC4Net(comp1, comp2, comp1.GetStatusNumber().ToString()));
                    i = i + 1;
                }
                else if (comp1.GetStatusPart()=="X")
                {
                    genLines.AddRange(GenerateFC4Net(comp1, null, comp1.GetStatusNumber().ToString()));
                }
                else if (comp1.GetStatusPart() == "Y")
                {
                    genLines.AddRange(GenerateFC4Net(null, comp1, comp1.GetStatusNumber().ToString()));
                }

                genLines.Add("");
                j++;
            }

            Console.WriteLine("Wygenerowano {0} networków",j- startNet);
            return genLines;
        }

        private List<string> GenerateFC4Net(Component component1, Component component2, string statusNumber)
        {
            TemplateFC4 template = new TemplateFC4();

            return template.GetFilled(component1, component2, statusNumber);
        }


        public List<string> GenerateFC16(List<Component> componentList,int startTimer, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;
            int j = startTimer;

            foreach (var component in componentList)
            {
                if (component.IsDirectCotrol())
                {
                    genLines.Add("NETWORK " + i);
                    genLines.Add("");
                    genLines.AddRange(GenerateFC16Net(component,j));
                    genLines.Add("");
                    i++;

                    if (component.IsDirectCotrolRL())
                        j = j + 2;
                    else
                        j++;
                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC16Net(Component component, int startTimer)
        {
            TemplateFC16 template = new TemplateFC16();
            template.SetStructure(component.Type);
            return template.GetFilled(component, startTimer);
        }

        public List<string> GenerateFC201(List<Component> componentList, int startNet)
        {
            List<string> genLines = new List<string>();

            int i = startNet;

            foreach (var component in componentList)
            {
                if(component.IsFreqConvSimple())
                { 
                genLines.Add("NETWORK " + i);
                genLines.Add("");
                genLines.AddRange(GenerateFC201Net(component));
                genLines.Add("");
                i++;
                }
            }
            Console.WriteLine("Wygenerowano {0} networków", i- startNet);
            return genLines;
        }

        private List<string> GenerateFC201Net(Component component)
        {
            TemplateFC201 template = new TemplateFC201();
            return template.GetFilled(component);
        }

    }
}

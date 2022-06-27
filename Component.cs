using System;
using System.Collections.Generic;
using System.Text;


namespace GeneratorMPs
{
    class Component
    {
        private string _symbol;
        private string _commandNumber;
        private string _commandPart;
        private string _type;
        private string _safetyZone;
        private string _dpAdress;


        public string Symbol { get => _symbol; }
        public string CommandNumber { get => _commandNumber; }
        public string CommandPart { get => _commandPart; }
        public string Type { get => _type; }
        public string SafetyZone { get => _safetyZone; }
        public string DpAdress { get => _dpAdress; }

        public Component(string symbol, string commandNumber, string commandPart, string type, string safetyZone, string dpAdress)
        {
            this._symbol = symbol;
            this._commandNumber = commandNumber;
            this._commandPart = commandPart;
            this._type = type;
            this._safetyZone = safetyZone;
            this._dpAdress = dpAdress;
        }

        public Component()
        {
        }

        public bool IsFreqConv()
        {
            if (IsFreqConvSimple() || IsFreqConvAdvance())
                return true;
            else
                return false;
        }

       public bool IsFreqConvAdvance()
        {
            if (_type == "0")
                return true;
            else
                return false;
        }

        public bool IsFreqConvSimple()
        {
            if (_type == "1")
                return true;
            else
                return false;
        }

        public bool HasSumOfErr()
        {
            if (_type == "0" || _type == "1" || _type == "2" || _type == "3")
                return true;
            else
                return false;
        }

        public bool IsDirectCotrol()
        {
            if (IsDirectCotrolR()||IsDirectCotrolRL())
                return true;
            else
                return false;
        }

        public bool IsDirectCotrolR()
        {
            if (_type == "2" )
                return true;
            else
                return false;
        }

        public bool IsDirectCotrolRL()
        {
            if ( _type == "3")
                return true;
            else
                return false;
        }

        public bool IsValve()
        {
            if (_type == "4" || _type == "5")
                return true;
            else
                return false;
        }

        public int GetStatusNumber()
        {
            int cmdNumber = 0;
            int.TryParse(_commandNumber,out cmdNumber);

            if (_commandPart == "A" || _commandPart == "B")
                return cmdNumber * 2 - 1;
            else
                return cmdNumber * 2;
        }

        public string GetStatusPart()
        {
            if (_commandPart == "A" || _commandPart == "C")
                return "X";
            else
                return "Y";
        }
       
    }
}

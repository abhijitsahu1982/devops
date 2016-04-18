using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine
{
    public class GlobalVariableCollection
    {
        private static readonly GlobalVariableCollection _instance = new GlobalVariableCollection();

        public IDictionary<string, decimal> _state = new Dictionary<string, decimal>();
       
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static GlobalVariableCollection()
        {
        }

        GlobalVariableCollection()
        {
        }

        public static GlobalVariableCollection Instance
        {
            get
            {
                return _instance;
            }
        }


        public bool Contains(string variableName)
        {
            return _state.ContainsKey(variableName);
        }

        public void Put(string variableName, decimal value)
        {
            if(!_state.ContainsKey(variableName))
            {
                _state.Add(variableName, value);
            }
            else
            {
                _state[variableName] = value;
            }
        }

        public decimal Get(string variableName)
        {
            if (!_state.ContainsKey(variableName))
            {
                throw new Exception("Global variable key not exists with name " + variableName);
            }
             
            return _state[variableName];
        }

    }
}

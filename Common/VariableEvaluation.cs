using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{
    public static class VariableEvaluation
    {
        public static string Evaluate(string value, WorkItem WorkItem, IDictionary<string, decimal> stateLocalVariable)
        {
            //If it is variable
            if (IsVariable(value))
            {
                value = GetVariableValue(stateLocalVariable, value);
            }
            //If it is object property
            else if (IsObjectProperty(value))
            {
                value = GetPropertyValue(WorkItem, value);
            }
            //If it is an expression evaluation
            else if (IsObjectProperty(value))
            {
                //TODO later
            }
            //It is a constant; donot do any thing
            else
            {
                ;
            }
            return value;
        }

        private static bool IsVariable(string value)
        {
            // variable format: [A1]
            return value.StartsWith("[") && value.EndsWith("]");
        }

        private static bool IsObjectProperty(string value)
        {
            // variable format: obj.PropertyName
            return value.StartsWith("obj.");
        }

        private static string GetVariableValue(IDictionary<string, decimal> state, string value)
        {
            // First extract the value from local variables, if local cache exisits
            if (state != null && state.ContainsKey(value))
            {
                return state[value].ToString();
            }
            // Second try from global variables
            else if (GlobalVariableCollection.Instance.Contains(value))
            {
                return GlobalVariableCollection.Instance.Get(value).ToString();
            }
            else
            {
                throw new Exception("Invalid variable name " + value);
            }
        }


        private static string GetPropertyValue(Object WorkItem, string value)
        {
            string fieldName = value.Replace("obj.", "");
            Type itemType = typeof(Object);
            PropertyInfo propertyInfo = itemType.GetProperty(fieldName);
            return propertyInfo.GetValue(WorkItem, null).ToString();
        }
    }
}

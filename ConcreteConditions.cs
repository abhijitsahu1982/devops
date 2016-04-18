using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;


namespace RuleEngine
{
    public class ConcreteCondition : IConditions
    {
        IList<ICondition> conditions = new List<ICondition>();
        public string ConditionName { get; private set; }
        public Common.LogicalOperation Operation
        {
            get;
            private set;
        }

        public void AddCondition(string fieldName, string operatorName, string value)
        {
            conditions.Add(new RuleCondition(fieldName, operatorName, value));
        }

        public ConcreteCondition(string conditionName, Common.LogicalOperation operation)
        {
            ConditionName = conditionName;
            Operation = operation;
        } 

        public bool Validate(WorkItem WorkItem)
        {
            bool result = true;
            foreach (var c in conditions)
            {
                bool res = c.Validate(WorkItem);
                result = result && res;
            }
            return result;
           
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
namespace RuleEngine
{
    public class RuleConditionGroup : IConditionGroup
    {
        IDictionary<int, ICondition> Conditions = new Dictionary<int, ICondition>();        
       
        public Common.LogicalOperation Operation 
        { 
            get; 
            private set; 
        }

        public RuleConditionGroup(Common.LogicalOperation operation)
        {            
            this.Operation = operation;
        }

        public void AddCondition(int count, string fieldName, string operatorName, string value, Common.LogicalOperation operation = Common.LogicalOperation.AND)
        {
            Conditions.Add(count, new RuleCondition(fieldName, operatorName, value, operation));

        }

        public bool Validate(WorkItem obj)
        {

            bool result = true;

            var conditionsToExecute = Conditions.Select(kv => kv.Value).ToList();
            int count = 0;
            foreach (var c in conditionsToExecute)
            {
                var res = c.Validate(obj);

                if (count != 0)
                {
                    var previousCondition = Conditions.Where(k => k.Key == count - 1).ToList();
                    var previousOperation = previousCondition[0].Value.Operation;
                    if (previousOperation == Common.LogicalOperation.AND)
                    {
                        result = result && res;

                    }
                    else
                    {
                        result = result || res;

                    }
                }
                else
                {
                    result = res;
                }
                count++;

            }
                       

            return result;
        }

                
    }
}

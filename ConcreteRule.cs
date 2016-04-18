using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;


namespace RuleEngine
{
    public class ConcreteRule : IRule
    { 
        IList<IConditionGroup> conditionGroup = new List<IConditionGroup>();
        IList<IAction> actions = new List<IAction>();
        public string RuleName { get; private set; }

        public ConcreteRule(string ruleName)
        {
            RuleName = ruleName;
        }

       
        public void AddConditionGroup(RuleConditionGroup group, Common.LogicalOperation operation = Common.LogicalOperation.AND)
        {
            conditionGroup.Add(group);

        }


        public void AddAction(string fieldName, string operatorName, string value, string actionKey = null)
        {
            actions.Add(new RuleAction(fieldName, operatorName, value, actionKey));
        }

        public bool Run(WorkItem obj)
        {


            bool result = true;

            foreach (var c in conditionGroup)
            {
                var res = c.Validate(obj);
                if (c.Operation == Common.LogicalOperation.AND)
                {
                    result = result && res;
                }
                else
                {
                    result = result || res;

                }

            }

            if (result)
            {
                foreach (var a in actions)
                {
                    obj.Fields[a.FieldName].Value = a.Value;
                }
            }

            return result;

        }

    }
}

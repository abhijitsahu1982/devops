using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;


namespace RuleEngine
{
    public class RuleAction : IAction
    {
        public ActionPredicate<WorkItem> Action;

        public RuleAction(ActionPredicate<WorkItem> action, string key = null)
        {
            this.Action = action;
            this.Key = key;

        }

        public RuleAction(string fieldName, string operatorName, string value, string actionKey = null)
        {
            this.FieldName = fieldName;
            this.OperatorName = operatorName;
            this.Value = value;
            this.Key = actionKey;
         }

        public string Key
        {
            get;
            private set;
        }
        public string FieldName 
        { 
            get;
            private set;
        }
        public string OperatorName 
        {
            get;
            private set;
        }
        public string Value 
        {
            get;
            private set;
        }

        public decimal Execute(WorkItem WorkItem, IDictionary<string, decimal> stateLocalVariable)
        {
            string value = VariableEvaluation.Evaluate(Value, WorkItem, stateLocalVariable);

            ActionPredicate<WorkItem> dynamicAction = Dynamic.GetActionPredicate<WorkItem>(FieldName, OperatorName, value);
            return dynamicAction(WorkItem);           
        }

     


    }
}

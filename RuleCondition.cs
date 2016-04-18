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
    public class RuleCondition : ICondition
    {
        readonly Predicate<WorkItem> Conditions = null;
       
        public Common.LogicalOperation Operation 
        { 
            get; 
            private set; 
        }

        public RuleCondition(Predicate<WorkItem> conditions, Common.LogicalOperation operation)
        {
            this.Conditions = conditions;
            this.Operation = operation;
        }

        public bool Validate(WorkItem WorkItem)
        {
            
            if (Conditions != null)
            {
                return Conditions(WorkItem);
            }
            else
            {
                string value = VariableEvaluation.Evaluate(Value, WorkItem, null);

                if (string.Compare(OperatorName,"ContainsAny",true) == 0)
                {
                    return Value.ToLower().Split(',').ToArray().Any(WorkItem.Fields[FieldName].Value.ToString().ToLower().Contains);
                }
                Predicate<WorkItem> dynamicCondition = Dynamic.GetConditionPredicate<WorkItem>(FieldName, OperatorName, value);
                return dynamicCondition(WorkItem); 
                
            }
        }


        public RuleCondition(string fieldName, string operatorName, string value, Common.LogicalOperation operation)
        {
            this.FieldName = fieldName;
            this.OperatorName = operatorName;
            this.Value = value;
            this.Operation = operation;
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
    }
}

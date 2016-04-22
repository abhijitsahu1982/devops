using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Reflection;
using System.IO;

namespace RuleEngine
{
    public class RuleEngineCommon
    {
        


        public void AddRule(string RuleName, IRule rule)
        {
            Rules.Add(RuleName, rule);
        }

        public bool Run(WorkItem obj)
        {
            bool result = false;
            var rules = Rules.Select(kv => kv.Value).ToList();
            foreach (var r in rules)
            {
                result = r.Run(obj);
                if (result)
                    return result;
            }
            return false;

        }

        public void Load()
        {
            
            string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            XDocument doc = XDocument.Load(logFilePath + "\\" + "DataConfig.xml");
            IList<Rule> xmlRuleCollection = (from rules in doc.Descendants("Rules")
                                                from rule in rules.Descendants("Rule")
                                                from conditions in rule.Descendants("Conditions")
                                                from actions in rule.Descendants("Actions")
                                             select new Rule
                                             {

                                                 Name = rule.Attribute("Name").Value,
                                                 ConditionGroup = (from conditionGroups in conditions.Descendants("Group")
                                                                   select new Group
                                                                   {
                                                                       Condition = (from condition in conditionGroups.Descendants("Condition")
                                                                                    select new Condition
                                                                                    {
                                                                                        LogicalOperation = condition.Attribute("LogicalOperation").Value,
                                                                                        FieldName = condition.Attribute("FieldName").Value,
                                                                                        Operation = condition.Attribute("Operation").Value,
                                                                                        Value = condition.Attribute("Value").Value
                                                                                    }).ToList<Condition>(),
                                                                       Operation = conditionGroups.Attribute("Operation").Value
                                                                   }).ToList<Group>(),

                                                 Action = (from action in actions.Descendants("Action")
                                                           select new Action
                                                           {
                                                               FieldName = action.Attribute("FieldName").Value,
                                                               Operation = action.Attribute("Operation").Value,
                                                               Data = action.Attribute("Data").Value
                                                           }).ToList<Action>()


                                             }).ToList<Rule>();
            foreach (var xmlRule in xmlRuleCollection)
            {
                IRule rule = new ConcreteRule(xmlRule.Name);

                foreach (var c in xmlRule.ConditionGroup)
                {

                    var logicalOperator = Common.LogicalOperation.AND;
                    if (c.Operation != string.Empty)
                    {
                        logicalOperator = (Common.LogicalOperation)Enum.Parse(typeof(Common.LogicalOperation), c.Operation);
                    }
                    RuleConditionGroup conditionGroup = new RuleConditionGroup(logicalOperator);
                    int count = 0;
                    foreach (var condition in c.Condition)
                    {

                        conditionGroup.AddCondition(count, condition.FieldName, condition.Operation, condition.Value, logicalOperator);
                        count++;
                    }
                    rule.AddConditionGroup(conditionGroup, logicalOperator);

                }
                foreach (var a in xmlRule.Action)
                {
                    rule.AddAction(a.FieldName, a.Operation, a.Data, a.Key);
                }
                AddRule(xmlRule.Name.ToString(), rule);
               
            }

        }

    }

}

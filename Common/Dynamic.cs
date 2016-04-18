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
    public static class Dynamic
    {

        /// <summary>
        /// Converts for example string value (1.123) to double 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        static public object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType); //recurse
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;

            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return Convert.ChangeType(value, type);
        }


        public static Predicate<T> GetConditionPredicate<T>(string fieldName, string operatorName, string value)
        {
            
            Type itemType = typeof(T);
            ParameterExpression predParam = Expression.Parameter(itemType, "WI");
            PropertyInfo propertyInfo = itemType.GetProperty(fieldName);
            Expression left = Expression.Property(predParam, propertyInfo);
            Expression right = Expression.Constant(ChangeType(value, propertyInfo.PropertyType), propertyInfo.PropertyType);
            Expression result = GetExpression(propertyInfo,operatorName, left, right);
            Func<T, bool> function = (Func<T, bool>)Expression.Lambda(result, new[] { predParam }).Compile();
            return new Predicate<T>(function);
        }

        /// <summary>
        /// Searches if any of the keywords are available in the input string. This is invoked dynamically at runtime.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="containsKeywords"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string input, IEnumerable<string> containsKeywords, StringComparison comparisonType)
        {
            return containsKeywords.Any(keyword => input.IndexOf(keyword, comparisonType) >= 0);
        }

        

        public static ActionPredicate<T> GetActionPredicate<T>(string fieldName, string operatorName, string value)
        {
            
            Type itemType = typeof(T);
            ParameterExpression predParam = Expression.Parameter(itemType, "WI");
            PropertyInfo propertyInfo = itemType.GetProperty(fieldName);
            Expression left = Expression.Property(predParam, propertyInfo);
            Expression right = Expression.Constant(ChangeType(value, propertyInfo.PropertyType), propertyInfo.PropertyType);            
            Expression result = GetExpression(propertyInfo,operatorName, left, right);
             
            Func<T, decimal> function = (Func<T, decimal>)Expression.Lambda(result, new[] { predParam }).Compile();
            return new ActionPredicate<T>(function);

            
        }
        


        public static Expression GetExpression(PropertyInfo propertyInfo,string operatorName, Expression left, Expression right)
        {
            Expression result = null;
            switch (operatorName.ToLower())
            {   
                
                case "contains":
                     var method = propertyInfo.PropertyType.GetMethod(operatorName);
                    result = Expression.Call(left, method, right);
                    break;                
                case "equals":
                    result = Expression.Equal(left, right);
                    break;
                case "assign":
                    result = Expression.Assign(left, right);
                    break;
                case "greaterorequal":
                    result = Expression.GreaterThanOrEqual(left, right);
                    break;
                case "lessorequal":
                    result = Expression.LessThanOrEqual(left, right);
                    break;
                case "greaterthan":
                    result = Expression.GreaterThan(left, right);
                    break;
                case "lessthan":
                    result = Expression.LessThan(left, right);
                    break;
                case "add":
                    result = Expression.Add(left, right);
                    break;
                case "subtract":
                    result = Expression.Subtract(left, right);
                    break;
                case "multiply":
                    result = Expression.Multiply(left, right);
                    break;
                case "divide":
                    result = Expression.Divide(left, right);
                    break;
                default:
                    throw new Exception("Unknown Operator Name");
            }
            return result;
        }
    }
}

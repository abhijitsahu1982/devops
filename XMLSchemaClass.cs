using System.Xml;

namespace XMLSchema
{

    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DataConfig
    {
        private string tFSPathField;
        private string defaultAssigneeField;
        private sbyte timeIntervalField;
        private string dataRepositoryField;
        private DataConfigSearchCondition[] searchConditionsField;
        private DataConfigRule[] rulesField;
        private string debugModeField;
        /// 
        public string TFSPath
        {
            get
            {
                return this.tFSPathField;
            }
            set
            {
                this.tFSPathField = value;
            }
        }
        /// 
        public string DefaultAssignee
        {
            get
            {
                return this.defaultAssigneeField;
            }
            set
            {
                this.defaultAssigneeField = value;
            }
        }
        /// 
        public sbyte TimeInterval
        {
            get
            {
                return this.timeIntervalField;
            }
            set
            {
                this.timeIntervalField = value;
            }
        }
        /// 
        public string DataRepository
        {
            get
            {
                return this.dataRepositoryField;
            }
            set
            {
                this.dataRepositoryField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("SearchCondition", IsNullable = false)]
        public DataConfigSearchCondition[] SearchConditions
        {
            get
            {
                return this.searchConditionsField;
            }
            set
            {
                this.searchConditionsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("Rule", IsNullable = false)]
        public DataConfigRule[] Rules
        {
            get
            {
                return this.rulesField;
            }
            set
            {
                this.rulesField = value;
            }
        }
        /// 
        public string DebugMode
        {
            get
            {
                return this.debugModeField;
            }
            set
            {
                this.debugModeField = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigSearchCondition
    {
        private string fieldNameField;
        private string operationField;
        private string valueField;
        private string logicalOperationField;
        private string value1Field;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LogicalOperation
        {
            get
            {
                return this.logicalOperationField;
            }
            set
            {
                this.logicalOperationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value1
        {
            get
            {
                return this.value1Field;
            }
            set
            {
                this.value1Field = value;
            }
        }
    }
    /// 
    ////[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    ////[System.SerializableAttribute()]
    ////[System.Diagnostics.DebuggerStepThroughAttribute()]
    ////[System.ComponentModel.DesignerCategoryAttribute("code")]
    ////[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRule
    {
        private DataConfigRuleConditions conditionsField;
        private DataConfigRuleAction[] actionsField;
        private string nameField;
        /// 
        public DataConfigRuleConditions Conditions
        {
            get
            {
                return this.conditionsField;
            }
            set
            {
                this.conditionsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlArrayItemAttribute("Action", IsNullable = false)]
        public DataConfigRuleAction[] Actions
        {
            get
            {
                return this.actionsField;
            }
            set
            {
                this.actionsField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRuleConditions
    {
        private DataConfigRuleConditionsCondition[] conditionField;
        private DataConfigRuleConditionsGroup groupField;
        /// 
        [System.Xml.Serialization.XmlElementAttribute("Condition")]
        public DataConfigRuleConditionsCondition[] Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
        /// 
        public DataConfigRuleConditionsGroup Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRuleConditionsCondition
    {
        private string fieldNameField;
        private string operationField;
        private string valueField;
        private string logicalOperationField;
        private string value1Field;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LogicalOperation
        {
            get
            {
                return this.logicalOperationField;
            }
            set
            {
                this.logicalOperationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value1
        {
            get
            {
                return this.value1Field;
            }
            set
            {
                this.value1Field = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRuleConditionsGroup
    {
        private DataConfigRuleConditionsGroupCondition[] conditionField;
        private string operationField;
        /// 
        [System.Xml.Serialization.XmlElementAttribute("Condition")]
        public DataConfigRuleConditionsGroupCondition[] Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRuleConditionsGroupCondition
    {
        private string fieldNameField;
        private string operationField;
        private string valueField;
        private string logicalOperationField;
        private string value1Field;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LogicalOperation
        {
            get
            {
                return this.logicalOperationField;
            }
            set
            {
                this.logicalOperationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value1
        {
            get
            {
                return this.value1Field;
            }
            set
            {
                this.value1Field = value;
            }
        }
    }
    /// 
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataConfigRuleAction
    {
        private string fieldNameField;
        private string operationField;
        private string dataField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
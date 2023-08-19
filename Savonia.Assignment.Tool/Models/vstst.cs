// MIT License

// Copyright (c) 2023 Hamed Fathi

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace VSTest
{
    /// <summary>
    /// <para>Shared between all test types.</para>
    /// </summary>
    [System.ComponentModel.Description("Shared between all test types.")]
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(CodedWebTestElementType))]
    [System.Xml.Serialization.XmlInclude(typeof(DeclarativeWebTestElementType))]
    [System.Xml.Serialization.XmlInclude(typeof(GenericTestType))]
    [System.Xml.Serialization.XmlInclude(typeof(OrderedTestType))]
    [System.Xml.Serialization.XmlInclude(typeof(PlainTextManualTestType))]
    [System.Xml.Serialization.XmlInclude(typeof(UnitTestType))]
    public abstract partial class BaseTestType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeCss> _css;
        /// <summary>
        /// <para>Currituck subsystem something ...</para>
        /// </summary>
        [System.ComponentModel.Description("Currituck subsystem something ...")]
        [System.Xml.Serialization.XmlElement("Css")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeCss> Css
        {
            get
            {
                return _css;
            }
            private set
            {
                _css = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Css collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CssSpecified
        {
            get
            {
                return (Css.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="BaseTestType" /> class.</para>
        /// </summary>
        public BaseTestType()
        {
            _css = new System.Collections.ObjectModel.Collection<BaseTestTypeCss>();
            _description = new System.Collections.ObjectModel.Collection<object>();
            _agent = new System.Collections.ObjectModel.Collection<BaseTestTypeAgent>();
            _owners = new System.Collections.ObjectModel.Collection<BaseTestTypeOwners>();
            _deploymentItems = new System.Collections.ObjectModel.Collection<BaseTestTypeDeploymentItems>();
            _testCategory = new System.Collections.ObjectModel.Collection<BaseTestTypeTestCategory>();
            _execution = new System.Collections.ObjectModel.Collection<BaseTestTypeExecution>();
            _properties = new System.Collections.ObjectModel.Collection<BaseTestTypeProperties>();
            _workItemIDs = new System.Collections.ObjectModel.Collection<WorkItemIDsType>();
            _tcmInformation = new System.Collections.ObjectModel.Collection<TcmInformationType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _description;
        /// <summary>
        /// <para>Describes the test. This is shown in the properties window.</para>
        /// </summary>
        [System.ComponentModel.Description("Describes the test. This is shown in the properties window.")]
        [System.Xml.Serialization.XmlElement("Description")]
        public System.Collections.ObjectModel.Collection<object> Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Description collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DescriptionSpecified
        {
            get
            {
                return (Description.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeAgent> _agent;
        [System.Xml.Serialization.XmlElement("Agent")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeAgent> Agent
        {
            get
            {
                return _agent;
            }
            private set
            {
                _agent = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Agent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentSpecified
        {
            get
            {
                return (Agent.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeOwners> _owners;
        /// <summary>
        /// <para>At the moment only one owner is allowed, but in the future we might extend to multiple owner support.</para>
        /// </summary>
        [System.ComponentModel.Description("At the moment only one owner is allowed, but in the future we might extend to mul" +
            "tiple owner support.")]
        [System.Xml.Serialization.XmlElement("Owners")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeOwners> Owners
        {
            get
            {
                return _owners;
            }
            private set
            {
                _owners = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Owners collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool OwnersSpecified
        {
            get
            {
                return (Owners.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeDeploymentItems> _deploymentItems;
        /// <summary>
        /// <para>Files to deploy before executing this test.</para>
        /// </summary>
        [System.ComponentModel.Description("Files to deploy before executing this test.")]
        [System.Xml.Serialization.XmlElement("DeploymentItems")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeDeploymentItems> DeploymentItems
        {
            get
            {
                return _deploymentItems;
            }
            private set
            {
                _deploymentItems = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DeploymentItems collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DeploymentItemsSpecified
        {
            get
            {
                return (DeploymentItems.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeTestCategory> _testCategory;
        /// <summary>
        /// <para>Categories applied to the test</para>
        /// </summary>
        [System.ComponentModel.Description("Categories applied to the test")]
        [System.Xml.Serialization.XmlElement("TestCategory")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeTestCategory> TestCategory
        {
            get
            {
                return _testCategory;
            }
            private set
            {
                _testCategory = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestCategory collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestCategorySpecified
        {
            get
            {
                return (TestCategory.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeExecution> _execution;
        [System.Xml.Serialization.XmlElement("Execution")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeExecution> Execution
        {
            get
            {
                return _execution;
            }
            private set
            {
                _execution = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Execution collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExecutionSpecified
        {
            get
            {
                return (Execution.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeProperties> _properties;
        [System.Xml.Serialization.XmlElement("Properties")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeProperties> Properties
        {
            get
            {
                return _properties;
            }
            private set
            {
                _properties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Properties collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertiesSpecified
        {
            get
            {
                return (Properties.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WorkItemIDsType> _workItemIDs;
        /// <summary>
        /// <para>References to workitems (bugs, issues) related to this test on the team server.</para>
        /// </summary>
        [System.ComponentModel.Description("References to workitems (bugs, issues) related to this test on the team server.")]
        [System.Xml.Serialization.XmlElement("WorkItemIDs")]
        public System.Collections.ObjectModel.Collection<WorkItemIDsType> WorkItemIDs
        {
            get
            {
                return _workItemIDs;
            }
            private set
            {
                _workItemIDs = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WorkItemIDs collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WorkItemIDsSpecified
        {
            get
            {
                return (WorkItemIDs.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TcmInformationType> _tcmInformation;
        [System.Xml.Serialization.XmlElement("TcmInformation")]
        public System.Collections.ObjectModel.Collection<TcmInformationType> TcmInformation
        {
            get
            {
                return _tcmInformation;
            }
            private set
            {
                _tcmInformation = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TcmInformation collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TcmInformationSpecified
        {
            get
            {
                return (TcmInformation.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isGroupable = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isGroupable")]
        public bool IsGroupable
        {
            get
            {
                return _isGroupable;
            }
            set
            {
                _isGroupable = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _priority = 2147483647;
        [System.ComponentModel.DefaultValue(2147483647)]
        [System.Xml.Serialization.XmlAttribute("priority")]
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _namedCategory = "";
        [System.ComponentModel.DefaultValue("")]
        [System.Xml.Serialization.XmlAttribute("namedCategory")]
        public string NamedCategory
        {
            get
            {
                return _namedCategory;
            }
            set
            {
                _namedCategory = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("storage")]
        public string Storage { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeCss", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeCss
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("projectStructure")]
        public string ProjectStructure { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("iteration")]
        public string Iteration { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeAgent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeAgent
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypeAgentAgentAttribute> _agentAttribute;
        [System.Xml.Serialization.XmlElement("AgentAttribute")]
        public System.Collections.ObjectModel.Collection<BaseTestTypeAgentAgentAttribute> AgentAttribute
        {
            get
            {
                return _agentAttribute;
            }
            private set
            {
                _agentAttribute = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AgentAttribute collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentAttributeSpecified
        {
            get
            {
                return (AgentAttribute.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="BaseTestTypeAgent" /> class.</para>
        /// </summary>
        public BaseTestTypeAgent()
        {
            _agentAttribute = new System.Collections.ObjectModel.Collection<BaseTestTypeAgentAgentAttribute>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _abortRunOnFailure = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("abortRunOnFailure")]
        public bool AbortRunOnFailure
        {
            get
            {
                return _abortRunOnFailure;
            }
            set
            {
                _abortRunOnFailure = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeAgentAgentAttribute", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeAgentAgentAttribute
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeOwners", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeOwners
    {
        /// <summary>
        /// <para>For example REDMOND\user1</para>
        /// </summary>
        [System.ComponentModel.Description("For example REDMOND\\user1")]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Owner")]
        public BaseTestTypeOwnersOwner Owner { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeOwnersOwner", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeOwnersOwner
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeDeploymentItems", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeDeploymentItems : DeploymentItemsType
    {
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DeploymentItemsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(BaseTestTypeDeploymentItems))]
    [System.Xml.Serialization.XmlInclude(typeof(TestRunConfigurationDeployment))]
    [System.Xml.Serialization.XmlInclude(typeof(TestSettingsTypeDeployment))]
    public partial class DeploymentItemsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DeploymentItemsTypeDeploymentItem> _deploymentItem;
        [System.Xml.Serialization.XmlElement("DeploymentItem")]
        public System.Collections.ObjectModel.Collection<DeploymentItemsTypeDeploymentItem> DeploymentItem
        {
            get
            {
                return _deploymentItem;
            }
            private set
            {
                _deploymentItem = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DeploymentItem collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DeploymentItemSpecified
        {
            get
            {
                return (DeploymentItem.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DeploymentItemsType" /> class.</para>
        /// </summary>
        public DeploymentItemsType()
        {
            _deploymentItem = new System.Collections.ObjectModel.Collection<DeploymentItemsTypeDeploymentItem>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DeploymentItemsTypeDeploymentItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DeploymentItemsTypeDeploymentItem
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("filename")]
        public string Filename { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("outputDirectory")]
        public string OutputDirectory { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeTestCategory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeTestCategory : TestCategoryType
    {
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestCategoryType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(BaseTestTypeTestCategory))]
    public partial class TestCategoryType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestCategoryTypeTestCategoryItem> _testCategoryItem;
        [System.Xml.Serialization.XmlElement("TestCategoryItem")]
        public System.Collections.ObjectModel.Collection<TestCategoryTypeTestCategoryItem> TestCategoryItem
        {
            get
            {
                return _testCategoryItem;
            }
            private set
            {
                _testCategoryItem = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestCategoryItem collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestCategoryItemSpecified
        {
            get
            {
                return (TestCategoryItem.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestCategoryType" /> class.</para>
        /// </summary>
        public TestCategoryType()
        {
            _testCategoryItem = new System.Collections.ObjectModel.Collection<TestCategoryTypeTestCategoryItem>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestCategoryTypeTestCategoryItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestCategoryTypeTestCategoryItem
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("TestCategory")]
        public string TestCategory { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeExecution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeExecution
    {
        [System.Xml.Serialization.XmlIgnore()]
        private string _id = "00000000-0000-0000-0000-000000000000";
        [System.ComponentModel.DefaultValue("00000000-0000-0000-0000-000000000000")]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _parentId = "00000000-0000-0000-0000-000000000000";
        [System.ComponentModel.DefaultValue("00000000-0000-0000-0000-000000000000")]
        [System.Xml.Serialization.XmlAttribute("parentId")]
        public string ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isRunOnRestart = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isRunOnRestart")]
        public bool IsRunOnRestart
        {
            get
            {
                return _isRunOnRestart;
            }
            set
            {
                _isRunOnRestart = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _timeOut = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("timeOut")]
        public int TimeOut
        {
            get
            {
                return _timeOut;
            }
            set
            {
                _timeOut = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypeProperties", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypeProperties
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<BaseTestTypePropertiesProperty> _property;
        [System.Xml.Serialization.XmlElement("Property")]
        public System.Collections.ObjectModel.Collection<BaseTestTypePropertiesProperty> Property
        {
            get
            {
                return _property;
            }
            private set
            {
                _property = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Property collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertySpecified
        {
            get
            {
                return (Property.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="BaseTestTypeProperties" /> class.</para>
        /// </summary>
        public BaseTestTypeProperties()
        {
            _property = new System.Collections.ObjectModel.Collection<BaseTestTypePropertiesProperty>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BaseTestTypePropertiesProperty", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BaseTestTypePropertiesProperty
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Key")]
        public object Key { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Value")]
        public object Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WorkItemIDsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WorkItemIDsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<IDElementType> _workItem;
        [System.Xml.Serialization.XmlElement("WorkItem")]
        public System.Collections.ObjectModel.Collection<IDElementType> WorkItem
        {
            get
            {
                return _workItem;
            }
            private set
            {
                _workItem = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WorkItem collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WorkItemSpecified
        {
            get
            {
                return (WorkItem.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WorkItemIDsType" /> class.</para>
        /// </summary>
        public WorkItemIDsType()
        {
            _workItem = new System.Collections.ObjectModel.Collection<IDElementType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("IDElementType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class IDElementType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TcmInformationType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TcmInformationType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum exclusive value: 0.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testCaseId")]
        public int TestCaseId { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum exclusive value: 0.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testRunId")]
        public int TestRunId { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum exclusive value: 0.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testResultId")]
        public int TestResultId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("testIterationId")]
        public string TestIterationId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BrowserType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BrowserType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<HeadersTypeHeader> _headers;
        [System.Xml.Serialization.XmlArray("Headers")]
        [System.Xml.Serialization.XmlArrayItem("Header", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<HeadersTypeHeader> Headers
        {
            get
            {
                return _headers;
            }
            private set
            {
                _headers = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Headers collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool HeadersSpecified
        {
            get
            {
                return (Headers.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="BrowserType" /> class.</para>
        /// </summary>
        public BrowserType()
        {
            _headers = new System.Collections.ObjectModel.Collection<HeadersTypeHeader>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxConnections")]
        public int MaxConnectionsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxConnections property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxConnectionsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxConnections
        {
            get
            {
                if (MaxConnectionsValueSpecified)
                {
                    return MaxConnectionsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxConnectionsValue = value.GetValueOrDefault();
                MaxConnectionsValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("HeadersType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class HeadersType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<HeadersTypeHeader> _header;
        [System.Xml.Serialization.XmlElement("Header")]
        public System.Collections.ObjectModel.Collection<HeadersTypeHeader> Header
        {
            get
            {
                return _header;
            }
            private set
            {
                _header = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Header collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool HeaderSpecified
        {
            get
            {
                return (Header.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="HeadersType" /> class.</para>
        /// </summary>
        public HeadersType()
        {
            _header = new System.Collections.ObjectModel.Collection<HeadersTypeHeader>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("HeadersTypeHeader", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class HeadersTypeHeader
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    /// <summary>
    /// <para>Coded web test in TRX file</para>
    /// </summary>
    [System.ComponentModel.Description("Coded web test in TRX file")]
    [Serializable()]
    [System.Xml.Serialization.XmlType("CodedWebTestElementType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CodedWebTestElementType : BaseTestType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CodedWebTestElementTypeWebTestClass> _webTestClass;
        [System.Xml.Serialization.XmlElement("WebTestClass")]
        public System.Collections.ObjectModel.Collection<CodedWebTestElementTypeWebTestClass> WebTestClass
        {
            get
            {
                return _webTestClass;
            }
            private set
            {
                _webTestClass = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestClass collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestClassSpecified
        {
            get
            {
                return (WebTestClass.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CodedWebTestElementType" /> class.</para>
        /// </summary>
        public CodedWebTestElementType()
        {
            _webTestClass = new System.Collections.ObjectModel.Collection<CodedWebTestElementTypeWebTestClass>();
            _includedWebTests = new System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTests>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTests> _includedWebTests;
        [System.Xml.Serialization.XmlElement("IncludedWebTests")]
        public System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTests> IncludedWebTests
        {
            get
            {
                return _includedWebTests;
            }
            private set
            {
                _includedWebTests = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the IncludedWebTests collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool IncludedWebTestsSpecified
        {
            get
            {
                return (IncludedWebTests.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CodedWebTestElementTypeWebTestClass", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CodedWebTestElementTypeWebTestClass
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("assembly")]
        public string Assembly { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("namespace")]
        public string Namespace { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("class")]
        public string Class { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CodedWebTestElementTypeIncludedWebTests", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CodedWebTestElementTypeIncludedWebTests
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTestsIncludedWebTest> _includedWebTest;
        [System.Xml.Serialization.XmlElement("IncludedWebTest")]
        public System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTestsIncludedWebTest> IncludedWebTest
        {
            get
            {
                return _includedWebTest;
            }
            private set
            {
                _includedWebTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the IncludedWebTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool IncludedWebTestSpecified
        {
            get
            {
                return (IncludedWebTest.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CodedWebTestElementTypeIncludedWebTests" /> class.</para>
        /// </summary>
        public CodedWebTestElementTypeIncludedWebTests()
        {
            _includedWebTest = new System.Collections.ObjectModel.Collection<CodedWebTestElementTypeIncludedWebTestsIncludedWebTest>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CodedWebTestElementTypeIncludedWebTestsIncludedWebTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CodedWebTestElementTypeIncludedWebTestsIncludedWebTest
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testId")]
        public string TestId { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isCodedWebTest = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isCodedWebTest")]
        public bool IsCodedWebTest
        {
            get
            {
                return _isCodedWebTest;
            }
            set
            {
                _isCodedWebTest = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterDescriptorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterDescriptorType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("machineName")]
        public string MachineName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("categoryName")]
        public string CategoryName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("counterName")]
        public string CounterName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("instanceName")]
        public string InstanceName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("baseInstanceName")]
        public string BaseInstanceName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private int _loadTestItemId = -1;
        [System.ComponentModel.DefaultValue(-1)]
        [System.Xml.Serialization.XmlAttribute("loadTestItemId")]
        public int LoadTestItemId
        {
            get
            {
                return _loadTestItemId;
            }
            set
            {
                _loadTestItemId = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterSetType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterSetType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory> _counterCategories;
        [System.Xml.Serialization.XmlArray("CounterCategories")]
        [System.Xml.Serialization.XmlArrayItem("CounterCategory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory> CounterCategories
        {
            get
            {
                return _counterCategories;
            }
            private set
            {
                _counterCategories = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CounterCategories collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CounterCategoriesSpecified
        {
            get
            {
                return (CounterCategories.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterSetType" /> class.</para>
        /// </summary>
        public CounterSetType()
        {
            _counterCategories = new System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("counterSetType")]
        public string CounterSetTypeProperty { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterSetTypeCounterCategories", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterSetTypeCounterCategories
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory> _counterCategory;
        [System.Xml.Serialization.XmlElement("CounterCategory")]
        public System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory> CounterCategory
        {
            get
            {
                return _counterCategory;
            }
            private set
            {
                _counterCategory = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CounterCategory collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CounterCategorySpecified
        {
            get
            {
                return (CounterCategory.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterSetTypeCounterCategories" /> class.</para>
        /// </summary>
        public CounterSetTypeCounterCategories()
        {
            _counterCategory = new System.Collections.ObjectModel.Collection<CounterSetTypeCounterCategoriesCounterCategory>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterSetTypeCounterCategoriesCounterCategory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterSetTypeCounterCategoriesCounterCategory
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterType> _counters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("Counters")]
        [System.Xml.Serialization.XmlArrayItem("Counter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<CounterType> Counters
        {
            get
            {
                return _counters;
            }
            private set
            {
                _counters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterSetTypeCounterCategoriesCounterCategory" /> class.</para>
        /// </summary>
        public CounterSetTypeCounterCategoriesCounterCategory()
        {
            _counters = new System.Collections.ObjectModel.Collection<CounterType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Instances")]
        public object Instances { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterSetTypeCounterCategoriesCounterCategoryCounters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterSetTypeCounterCategoriesCounterCategoryCounters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterType> _counter;
        [System.Xml.Serialization.XmlElement("Counter")]
        public System.Collections.ObjectModel.Collection<CounterType> Counter
        {
            get
            {
                return _counter;
            }
            private set
            {
                _counter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Counter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CounterSpecified
        {
            get
            {
                return (Counter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterSetTypeCounterCategoriesCounterCategoryCounters" /> class.</para>
        /// </summary>
        public CounterSetTypeCounterCategoriesCounterCategoryCounters()
        {
            _counter = new System.Collections.ObjectModel.Collection<CounterType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule> _thresholdRules;
        [System.Xml.Serialization.XmlArray("ThresholdRules")]
        [System.Xml.Serialization.XmlArrayItem("ThresholdRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule> ThresholdRules
        {
            get
            {
                return _thresholdRules;
            }
            private set
            {
                _thresholdRules = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ThresholdRules collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ThresholdRulesSpecified
        {
            get
            {
                return (ThresholdRules.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterType" /> class.</para>
        /// </summary>
        public CounterType()
        {
            _thresholdRules = new System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterTypeThresholdRules", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterTypeThresholdRules
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule> _thresholdRule;
        [System.Xml.Serialization.XmlElement("ThresholdRule")]
        public System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule> ThresholdRule
        {
            get
            {
                return _thresholdRule;
            }
            private set
            {
                _thresholdRule = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ThresholdRule collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ThresholdRuleSpecified
        {
            get
            {
                return (ThresholdRule.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterTypeThresholdRules" /> class.</para>
        /// </summary>
        public CounterTypeThresholdRules()
        {
            _thresholdRule = new System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRule>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterTypeThresholdRulesThresholdRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterTypeThresholdRulesThresholdRule
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter> _parameters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("Parameters")]
        [System.Xml.Serialization.XmlArrayItem("RuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter> Parameters
        {
            get
            {
                return _parameters;
            }
            private set
            {
                _parameters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterTypeThresholdRulesThresholdRule" /> class.</para>
        /// </summary>
        public CounterTypeThresholdRulesThresholdRule()
        {
            _parameters = new System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("className")]
        public string ClassName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterTypeThresholdRulesThresholdRuleParameters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterTypeThresholdRulesThresholdRuleParameters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter> _ruleParameter;
        [System.Xml.Serialization.XmlElement("RuleParameter")]
        public System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter> RuleParameter
        {
            get
            {
                return _ruleParameter;
            }
            private set
            {
                _ruleParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuleParameter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RuleParameterSpecified
        {
            get
            {
                return (RuleParameter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CounterTypeThresholdRulesThresholdRuleParameters" /> class.</para>
        /// </summary>
        public CounterTypeThresholdRulesThresholdRuleParameters()
        {
            _ruleParameter = new System.Collections.ObjectModel.Collection<CounterTypeThresholdRulesThresholdRuleParametersRuleParameter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CounterTypeThresholdRulesThresholdRuleParametersRuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CounterTypeThresholdRulesThresholdRuleParametersRuleParameter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CountersType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CountersType
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("total")]
        public int TotalValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Total property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TotalValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Total
        {
            get
            {
                if (TotalValueSpecified)
                {
                    return TotalValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TotalValue = value.GetValueOrDefault();
                TotalValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _error = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("error")]
        public int Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _failed = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("failed")]
        public int Failed
        {
            get
            {
                return _failed;
            }
            set
            {
                _failed = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _timeout = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("timeout")]
        public int Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _aborted = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("aborted")]
        public int Aborted
        {
            get
            {
                return _aborted;
            }
            set
            {
                _aborted = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _inconclusive = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("inconclusive")]
        public int Inconclusive
        {
            get
            {
                return _inconclusive;
            }
            set
            {
                _inconclusive = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _passedButRunAborted = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("passedButRunAborted")]
        public int PassedButRunAborted
        {
            get
            {
                return _passedButRunAborted;
            }
            set
            {
                _passedButRunAborted = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _notRunnable = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("notRunnable")]
        public int NotRunnable
        {
            get
            {
                return _notRunnable;
            }
            set
            {
                _notRunnable = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _notExecuted = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("notExecuted")]
        public int NotExecuted
        {
            get
            {
                return _notExecuted;
            }
            set
            {
                _notExecuted = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _executed = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("executed")]
        public int Executed
        {
            get
            {
                return _executed;
            }
            set
            {
                _executed = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _disconnected = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("disconnected")]
        public int Disconnected
        {
            get
            {
                return _disconnected;
            }
            set
            {
                _disconnected = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _warning = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("warning")]
        public int Warning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _passed = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("passed")]
        public int Passed
        {
            get
            {
                return _passed;
            }
            set
            {
                _passed = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _completed = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("completed")]
        public int Completed
        {
            get
            {
                return _completed;
            }
            set
            {
                _completed = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _inProgress = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("inProgress")]
        public int InProgress
        {
            get
            {
                return _inProgress;
            }
            set
            {
                _inProgress = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _pending = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("pending")]
        public int Pending
        {
            get
            {
                return _pending;
            }
            set
            {
                _pending = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    /// <summary>
    /// <para>Declarative web test in TRX file</para>
    /// </summary>
    [System.ComponentModel.Description("Declarative web test in TRX file")]
    [Serializable()]
    [System.Xml.Serialization.XmlType("DeclarativeWebTestElementType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DeclarativeWebTestElementType : BaseTestType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("persistedWebTest")]
        public string PersistedWebTest { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DevelopmentServerType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DevelopmentServerType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("pathToWebSite")]
        public string PathToWebSite { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("webApplicationRoot")]
        public string WebApplicationRoot { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ExecutionTypeEnum", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum ExecutionTypeEnum
    {
        [System.Xml.Serialization.XmlEnum("local")]
        Local,
        [System.Xml.Serialization.XmlEnum("remote")]
        Remote,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("HostProcessPlatformTypeEnum", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum HostProcessPlatformTypeEnum
    {
        MSIL,
        X86,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GenericTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("GenericTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class GenericTestType : BaseTestType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GenericTestTypeCommand> _command;
        [System.Xml.Serialization.XmlElement("Command")]
        public System.Collections.ObjectModel.Collection<GenericTestTypeCommand> Command
        {
            get
            {
                return _command;
            }
            private set
            {
                _command = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Command collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CommandSpecified
        {
            get
            {
                return (Command.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="GenericTestType" /> class.</para>
        /// </summary>
        public GenericTestType()
        {
            _command = new System.Collections.ObjectModel.Collection<GenericTestTypeCommand>();
            _summaryXmlFile = new System.Collections.ObjectModel.Collection<GenericTestTypeSummaryXmlFile>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GenericTestTypeSummaryXmlFile> _summaryXmlFile;
        /// <summary>
        /// <para>If this element does not exist it's the same as if it was not enabled.
        ///                But if it's not enabled, we still allow the user to change the file location and persist the file location for later use.</para>
        /// </summary>
        [System.ComponentModel.Description("If this element does not exist it\'s the same as if it was not enabled. But if it\'" +
            "s not enabled, we still allow the user to change the file location and persist t" +
            "he file location for later use.")]
        [System.Xml.Serialization.XmlElement("SummaryXmlFile")]
        public System.Collections.ObjectModel.Collection<GenericTestTypeSummaryXmlFile> SummaryXmlFile
        {
            get
            {
                return _summaryXmlFile;
            }
            private set
            {
                _summaryXmlFile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the SummaryXmlFile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool SummaryXmlFileSpecified
        {
            get
            {
                return (SummaryXmlFile.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GenericTestTypeCommand", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GenericTestTypeCommand
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable> _environmentVariables;
        [System.Xml.Serialization.XmlArray("EnvironmentVariables")]
        [System.Xml.Serialization.XmlArrayItem("EnvironmentVariable", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable> EnvironmentVariables
        {
            get
            {
                return _environmentVariables;
            }
            private set
            {
                _environmentVariables = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the EnvironmentVariables collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool EnvironmentVariablesSpecified
        {
            get
            {
                return (EnvironmentVariables.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="GenericTestTypeCommand" /> class.</para>
        /// </summary>
        public GenericTestTypeCommand()
        {
            _environmentVariables = new System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("filename")]
        public string Filename { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("arguments")]
        public string Arguments { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("workingDirectory")]
        public string WorkingDirectory { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private int _maxDuration = 3600000;
        /// <summary>
        /// <para>This is in addition to the timeout to distinguish between a failed command and a test that timed out.</para>
        /// </summary>
        [System.ComponentModel.DefaultValue(3600000)]
        [System.ComponentModel.Description("This is in addition to the timeout to distinguish between a failed command and a " +
            "test that timed out.")]
        [System.Xml.Serialization.XmlAttribute("maxDuration")]
        public int MaxDuration
        {
            get
            {
                return _maxDuration;
            }
            set
            {
                _maxDuration = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _redirectStandardOutputAndError = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("redirectStandardOutputAndError")]
        public bool RedirectStandardOutputAndError
        {
            get
            {
                return _redirectStandardOutputAndError;
            }
            set
            {
                _redirectStandardOutputAndError = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GenericTestTypeCommandEnvironmentVariables", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GenericTestTypeCommandEnvironmentVariables
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable> _environmentVariable;
        [System.Xml.Serialization.XmlElement("EnvironmentVariable")]
        public System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable> EnvironmentVariable
        {
            get
            {
                return _environmentVariable;
            }
            private set
            {
                _environmentVariable = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the EnvironmentVariable collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool EnvironmentVariableSpecified
        {
            get
            {
                return (EnvironmentVariable.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="GenericTestTypeCommandEnvironmentVariables" /> class.</para>
        /// </summary>
        public GenericTestTypeCommandEnvironmentVariables()
        {
            _environmentVariable = new System.Collections.ObjectModel.Collection<GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GenericTestTypeCommandEnvironmentVariablesEnvironmentVariable
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GenericTestTypeSummaryXmlFile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GenericTestTypeSummaryXmlFile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GraphDescriptorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GraphDescriptorType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("HorizontalZoomRange")]
        public RangeType HorizontalZoomRange { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("VerticalZoomRange")]
        public RangeType VerticalZoomRange { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<PlotDescriptorType> _plotDescriptors;
        [System.Xml.Serialization.XmlArray("PlotDescriptors")]
        [System.Xml.Serialization.XmlArrayItem("PlotDescriptor", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<PlotDescriptorType> PlotDescriptors
        {
            get
            {
                return _plotDescriptors;
            }
            private set
            {
                _plotDescriptors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PlotDescriptors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PlotDescriptorsSpecified
        {
            get
            {
                return (PlotDescriptors.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="GraphDescriptorType" /> class.</para>
        /// </summary>
        public GraphDescriptorType()
        {
            _plotDescriptors = new System.Collections.ObjectModel.Collection<PlotDescriptorType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("graphName")]
        public string GraphName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RangeType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RangeType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("lower")]
        public string Lower { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("upper")]
        public string Upper { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("GraphDescriptorTypePlotDescriptors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class GraphDescriptorTypePlotDescriptors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<PlotDescriptorType> _plotDescriptor;
        [System.Xml.Serialization.XmlElement("PlotDescriptor")]
        public System.Collections.ObjectModel.Collection<PlotDescriptorType> PlotDescriptor
        {
            get
            {
                return _plotDescriptor;
            }
            private set
            {
                _plotDescriptor = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PlotDescriptor collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PlotDescriptorSpecified
        {
            get
            {
                return (PlotDescriptor.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="GraphDescriptorTypePlotDescriptors" /> class.</para>
        /// </summary>
        public GraphDescriptorTypePlotDescriptors()
        {
            _plotDescriptor = new System.Collections.ObjectModel.Collection<PlotDescriptorType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PlotDescriptorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class PlotDescriptorType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterDescriptor")]
        public CounterDescriptorType CounterDescriptor { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("colorArgb")]
        public int ColorArgb { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("lineStyle")]
        public int LineStyle { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("fixedRange")]
        public double FixedRange { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _showOnGraph = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("showOnGraph")]
        public bool ShowOnGraph
        {
            get
            {
                return _showOnGraph;
            }
            set
            {
                _showOnGraph = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isSelected = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isSelected")]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("counterMetadata")]
        public string CounterMetadata { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("rangeGroup")]
        public string RangeGroup { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LinkType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LinkType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("storage")]
        public string Storage { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadRunConfigurationType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadRunConfigurationType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping> _counterSetMappings;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("CounterSetMappings")]
        [System.Xml.Serialization.XmlArrayItem("CounterSetMapping", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping> CounterSetMappings
        {
            get
            {
                return _counterSetMappings;
            }
            private set
            {
                _counterSetMappings = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadRunConfigurationType" /> class.</para>
        /// </summary>
        public LoadRunConfigurationType()
        {
            _counterSetMappings = new System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ContextParameters")]
        public object ContextParameters { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ApplicationsUnderTest")]
        public object ApplicationsUnderTest { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("description")]
        public string Description { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("timingDetailsStorage")]
        public int TimingDetailsStorageValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the TimingDetailsStorage property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TimingDetailsStorageValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? TimingDetailsStorage
        {
            get
            {
                if (TimingDetailsStorageValueSpecified)
                {
                    return TimingDetailsStorageValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TimingDetailsStorageValue = value.GetValueOrDefault();
                TimingDetailsStorageValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _resultsStoreType = 1;
        [System.ComponentModel.DefaultValue(1)]
        [System.Xml.Serialization.XmlAttribute("resultsStoreType")]
        public int ResultsStoreType
        {
            get
            {
                return _resultsStoreType;
            }
            set
            {
                _resultsStoreType = value;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("saveTestLogsOnError")]
        public bool SaveTestLogsOnErrorValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SaveTestLogsOnError property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SaveTestLogsOnErrorValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SaveTestLogsOnError
        {
            get
            {
                if (SaveTestLogsOnErrorValueSpecified)
                {
                    return SaveTestLogsOnErrorValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SaveTestLogsOnErrorValue = value.GetValueOrDefault();
                SaveTestLogsOnErrorValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _saveTestLogsFrequency = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("saveTestLogsFrequency")]
        public int SaveTestLogsFrequency
        {
            get
            {
                return _saveTestLogsFrequency;
            }
            set
            {
                _saveTestLogsFrequency = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _maxErrorDetails = 100;
        [System.ComponentModel.DefaultValue(100)]
        [System.Xml.Serialization.XmlAttribute("maxErrorDetails")]
        public int MaxErrorDetails
        {
            get
            {
                return _maxErrorDetails;
            }
            set
            {
                _maxErrorDetails = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _maxErrorsPerType = 1000;
        [System.ComponentModel.DefaultValue(1000)]
        [System.Xml.Serialization.XmlAttribute("maxErrorsPerType")]
        public int MaxErrorsPerType
        {
            get
            {
                return _maxErrorsPerType;
            }
            set
            {
                _maxErrorsPerType = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _maxThresholdViolations = 1000;
        [System.ComponentModel.DefaultValue(1000)]
        [System.Xml.Serialization.XmlAttribute("maxThresholdViolations")]
        public int MaxThresholdViolations
        {
            get
            {
                return _maxThresholdViolations;
            }
            set
            {
                _maxThresholdViolations = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("maxRequestUrlsReported")]
        public int MaxRequestUrlsReported { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("useTestIterations")]
        public bool UseTestIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the UseTestIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool UseTestIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? UseTestIterations
        {
            get
            {
                if (UseTestIterationsValueSpecified)
                {
                    return UseTestIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                UseTestIterationsValue = value.GetValueOrDefault();
                UseTestIterationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("runDuration")]
        public int RunDuration { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("warmupTime")]
        public int WarmupTime { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("coolDownTime")]
        public int CoolDownTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the CoolDownTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CoolDownTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? CoolDownTime
        {
            get
            {
                if (CoolDownTimeValueSpecified)
                {
                    return CoolDownTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                CoolDownTimeValue = value.GetValueOrDefault();
                CoolDownTimeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("testIterations")]
        public int TestIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the TestIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TestIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? TestIterations
        {
            get
            {
                if (TestIterationsValueSpecified)
                {
                    return TestIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TestIterationsValue = value.GetValueOrDefault();
                TestIterationsValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("webTestConnectionModel")]
        public string WebTestConnectionModel { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("webTestConnectionPoolSize")]
        public int WebTestConnectionPoolSizeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the WebTestConnectionPoolSize property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool WebTestConnectionPoolSizeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? WebTestConnectionPoolSize
        {
            get
            {
                if (WebTestConnectionPoolSizeValueSpecified)
                {
                    return WebTestConnectionPoolSizeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                WebTestConnectionPoolSizeValue = value.GetValueOrDefault();
                WebTestConnectionPoolSizeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("sampleRate")]
        public int SampleRate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("validationLevel")]
        public int ValidationLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("sqlTracingConnectString")]
        public string SqlTracingConnectString { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("sqlTracingConnectStringDisplayValue")]
        public string SqlTracingConnectStringDisplayValue { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("sqlTracingDirectory")]
        public string SqlTracingDirectory { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("sqlTracingEnabled")]
        public bool SqlTracingEnabledValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingEnabled property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingEnabledValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SqlTracingEnabled
        {
            get
            {
                if (SqlTracingEnabledValueSpecified)
                {
                    return SqlTracingEnabledValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingEnabledValue = value.GetValueOrDefault();
                SqlTracingEnabledValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("sqlTracingFileCount")]
        public int SqlTracingFileCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingFileCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingFileCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SqlTracingFileCount
        {
            get
            {
                if (SqlTracingFileCountValueSpecified)
                {
                    return SqlTracingFileCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingFileCountValue = value.GetValueOrDefault();
                SqlTracingFileCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("sqlTracingRolloverEnabled")]
        public bool SqlTracingRolloverEnabledValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingRolloverEnabled property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingRolloverEnabledValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SqlTracingRolloverEnabled
        {
            get
            {
                if (SqlTracingRolloverEnabledValueSpecified)
                {
                    return SqlTracingRolloverEnabledValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingRolloverEnabledValue = value.GetValueOrDefault();
                SqlTracingRolloverEnabledValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("sqlTracingMinimumDuration")]
        public int SqlTracingMinimumDurationValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingMinimumDuration property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingMinimumDurationValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SqlTracingMinimumDuration
        {
            get
            {
                if (SqlTracingMinimumDurationValueSpecified)
                {
                    return SqlTracingMinimumDurationValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingMinimumDurationValue = value.GetValueOrDefault();
                SqlTracingMinimumDurationValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("runUnitTestsInAppDomain")]
        public bool RunUnitTestsInAppDomainValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the RunUnitTestsInAppDomain property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RunUnitTestsInAppDomainValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? RunUnitTestsInAppDomain
        {
            get
            {
                if (RunUnitTestsInAppDomainValueSpecified)
                {
                    return RunUnitTestsInAppDomainValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RunUnitTestsInAppDomainValue = value.GetValueOrDefault();
                RunUnitTestsInAppDomainValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _resourcesRetentionTimeInMinutes = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("resourcesRetentionTimeInMinutes")]
        public int ResourcesRetentionTimeInMinutes
        {
            get
            {
                return _resourcesRetentionTimeInMinutes;
            }
            set
            {
                _resourcesRetentionTimeInMinutes = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadRunConfigurationTypeCounterSetMappings", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadRunConfigurationTypeCounterSetMappings
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping> _counterSetMapping;
        [System.Xml.Serialization.XmlElement("CounterSetMapping")]
        public System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping> CounterSetMapping
        {
            get
            {
                return _counterSetMapping;
            }
            private set
            {
                _counterSetMapping = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CounterSetMapping collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CounterSetMappingSpecified
        {
            get
            {
                return (CounterSetMapping.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadRunConfigurationTypeCounterSetMappings" /> class.</para>
        /// </summary>
        public LoadRunConfigurationTypeCounterSetMappings()
        {
            _counterSetMapping = new System.Collections.ObjectModel.Collection<LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadRunConfigurationTypeCounterSetMappingsCounterSetMapping
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSetReferences")]
        public LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferences CounterSetReferences { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("computerName")]
        public string ComputerName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferences", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferences
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSetReference")]
        public LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference CounterSetReference { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferencesCo" +
        "unterSetReference", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadRunConfigurationTypeCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("counterSetName")]
        public string CounterSetName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultType : TestResultAggregationType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("AnalyzerViewState")]
        public LoadTestResultTypeAnalyzerViewState AnalyzerViewState { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Summary")]
        public LoadTestResultTypeSummary Summary { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private LoadTestRunStatusType _runStatus = VSTest.LoadTestRunStatusType.NotStarted;
        [System.ComponentModel.DefaultValue(VSTest.LoadTestRunStatusType.NotStarted)]
        [System.Xml.Serialization.XmlAttribute("runStatus")]
        public LoadTestRunStatusType RunStatus
        {
            get
            {
                return _runStatus;
            }
            set
            {
                _runStatus = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("runId")]
        public int RunId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("controllerStartTime")]
        public string ControllerStartTime { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("loadTestDuration")]
        public int LoadTestDurationValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the LoadTestDuration property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool LoadTestDurationValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? LoadTestDuration
        {
            get
            {
                if (LoadTestDurationValueSpecified)
                {
                    return LoadTestDurationValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                LoadTestDurationValue = value.GetValueOrDefault();
                LoadTestDurationValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("loadTestWarmupTime")]
        public int LoadTestWarmupTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the LoadTestWarmupTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool LoadTestWarmupTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? LoadTestWarmupTime
        {
            get
            {
                if (LoadTestWarmupTimeValueSpecified)
                {
                    return LoadTestWarmupTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                LoadTestWarmupTimeValue = value.GetValueOrDefault();
                LoadTestWarmupTimeValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _previouslyViewed = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("previouslyViewed")]
        public bool PreviouslyViewed
        {
            get
            {
                return _previouslyViewed;
            }
            set
            {
                _previouslyViewed = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("resultsRepositoryConnectString")]
        public string ResultsRepositoryConnectString { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("resultsStoreType")]
        public LoadTestResultStoreType ResultsStoreTypeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ResultsStoreType property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ResultsStoreTypeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public LoadTestResultStoreType? ResultsStoreType
        {
            get
            {
                if (ResultsStoreTypeValueSpecified)
                {
                    return ResultsStoreTypeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ResultsStoreTypeValue = value.GetValueOrDefault();
                ResultsStoreTypeValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestResultAggregationType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(LoadTestResultType))]
    [System.Xml.Serialization.XmlInclude(typeof(UnitTestResultType))]
    public partial class TestResultAggregationType : TestResultType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Counters")]
        public CountersType Counters { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("InnerResults")]
        public ResultsType InnerResults { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(LoadTestResultType))]
    [System.Xml.Serialization.XmlInclude(typeof(ManualTestResultType))]
    [System.Xml.Serialization.XmlInclude(typeof(TestResultAggregationType))]
    [System.Xml.Serialization.XmlInclude(typeof(UnitTestResultType))]
    [System.Xml.Serialization.XmlInclude(typeof(WebTestResultType))]
    public partial class TestResultType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<OutputType> _output;
        [System.Xml.Serialization.XmlElement("Output")]
        public System.Collections.ObjectModel.Collection<OutputType> Output
        {
            get
            {
                return _output;
            }
            private set
            {
                _output = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Output collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool OutputSpecified
        {
            get
            {
                return (Output.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestResultType" /> class.</para>
        /// </summary>
        public TestResultType()
        {
            _output = new System.Collections.ObjectModel.Collection<OutputType>();
            _workItems = new System.Collections.ObjectModel.Collection<WorkItemIDsType>();
            _timers = new System.Collections.ObjectModel.Collection<TestResultTypeTimers>();
            _resultFiles = new System.Collections.ObjectModel.Collection<ResultFilesType>();
            _fileUris = new System.Collections.ObjectModel.Collection<FileUrisType>();
            _collectorDataEntries = new System.Collections.ObjectModel.Collection<CollectorDataEntriesType>();
            _dataCollectorMessages = new System.Collections.ObjectModel.Collection<DataCollectorMessagesType>();
            _tcmInformation = new System.Collections.ObjectModel.Collection<TcmInformationType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WorkItemIDsType> _workItems;
        [System.Xml.Serialization.XmlElement("WorkItems")]
        public System.Collections.ObjectModel.Collection<WorkItemIDsType> WorkItems
        {
            get
            {
                return _workItems;
            }
            private set
            {
                _workItems = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WorkItems collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WorkItemsSpecified
        {
            get
            {
                return (WorkItems.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestResultTypeTimers> _timers;
        [System.Xml.Serialization.XmlElement("Timers")]
        public System.Collections.ObjectModel.Collection<TestResultTypeTimers> Timers
        {
            get
            {
                return _timers;
            }
            private set
            {
                _timers = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Timers collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TimersSpecified
        {
            get
            {
                return (Timers.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResultFilesType> _resultFiles;
        [System.Xml.Serialization.XmlElement("ResultFiles")]
        public System.Collections.ObjectModel.Collection<ResultFilesType> ResultFiles
        {
            get
            {
                return _resultFiles;
            }
            private set
            {
                _resultFiles = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ResultFiles collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ResultFilesSpecified
        {
            get
            {
                return (ResultFiles.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<FileUrisType> _fileUris;
        [System.Xml.Serialization.XmlElement("FileUris")]
        public System.Collections.ObjectModel.Collection<FileUrisType> FileUris
        {
            get
            {
                return _fileUris;
            }
            private set
            {
                _fileUris = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the FileUris collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool FileUrisSpecified
        {
            get
            {
                return (FileUris.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CollectorDataEntriesType> _collectorDataEntries;
        [System.Xml.Serialization.XmlElement("CollectorDataEntries")]
        public System.Collections.ObjectModel.Collection<CollectorDataEntriesType> CollectorDataEntries
        {
            get
            {
                return _collectorDataEntries;
            }
            private set
            {
                _collectorDataEntries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CollectorDataEntries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CollectorDataEntriesSpecified
        {
            get
            {
                return (CollectorDataEntries.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorMessagesType> _dataCollectorMessages;
        [System.Xml.Serialization.XmlElement("DataCollectorMessages")]
        public System.Collections.ObjectModel.Collection<DataCollectorMessagesType> DataCollectorMessages
        {
            get
            {
                return _dataCollectorMessages;
            }
            private set
            {
                _dataCollectorMessages = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollectorMessages collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorMessagesSpecified
        {
            get
            {
                return (DataCollectorMessages.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TcmInformationType> _tcmInformation;
        [System.Xml.Serialization.XmlElement("TcmInformation")]
        public System.Collections.ObjectModel.Collection<TcmInformationType> TcmInformation
        {
            get
            {
                return _tcmInformation;
            }
            private set
            {
                _tcmInformation = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TcmInformation collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TcmInformationSpecified
        {
            get
            {
                return (TcmInformation.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testName")]
        public string TestName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testType")]
        public string TestType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testId")]
        public string TestId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("executionId")]
        public string ExecutionId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("parentExecutionId")]
        public string ParentExecutionId { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testListId")]
        public string TestListId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("outcome")]
        public string Outcome { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("computerName")]
        public string ComputerName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("relativeResultsDirectory")]
        public string RelativeResultsDirectory { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("startTime")]
        public string StartTime { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("endTime")]
        public string EndTime { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("duration")]
        public string Duration { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _spoolMessage = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("spoolMessage")]
        public bool SpoolMessage
        {
            get
            {
                return _spoolMessage;
            }
            set
            {
                _spoolMessage = value;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("processExitCode")]
        public int ProcessExitCodeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ProcessExitCode property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ProcessExitCodeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? ProcessExitCode
        {
            get
            {
                if (ProcessExitCodeValueSpecified)
                {
                    return ProcessExitCodeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ProcessExitCodeValue = value.GetValueOrDefault();
                ProcessExitCodeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("isAborted")]
        public bool IsAbortedValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IsAborted property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IsAbortedValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? IsAborted
        {
            get
            {
                if (IsAbortedValueSpecified)
                {
                    return IsAbortedValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IsAbortedValue = value.GetValueOrDefault();
                IsAbortedValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("relativeTestOutputDirectory")]
        public string RelativeTestOutputDirectory { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("OutputType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class OutputType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StdOut")]
        public object StdOut { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StdErr")]
        public object StdErr { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DebugTrace")]
        public object DebugTrace { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TraceInfo")]
        public object TraceInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ErrorInfo")]
        public OutputTypeErrorInfo ErrorInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Exception")]
        public object Exception { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _textMessages;
        [System.Xml.Serialization.XmlArray("TextMessages")]
        [System.Xml.Serialization.XmlArrayItem("Message", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<object> TextMessages
        {
            get
            {
                return _textMessages;
            }
            private set
            {
                _textMessages = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TextMessages collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TextMessagesSpecified
        {
            get
            {
                return (TextMessages.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="OutputType" /> class.</para>
        /// </summary>
        public OutputType()
        {
            _textMessages = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("OutputTypeErrorInfo", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class OutputTypeErrorInfo
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Message")]
        public object Message { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StackTrace")]
        public object StackTrace { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("OutputTypeTextMessages", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class OutputTypeTextMessages
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _message;
        [System.Xml.Serialization.XmlElement("Message")]
        public System.Collections.ObjectModel.Collection<object> Message
        {
            get
            {
                return _message;
            }
            private set
            {
                _message = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Message collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool MessageSpecified
        {
            get
            {
                return (Message.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="OutputTypeTextMessages" /> class.</para>
        /// </summary>
        public OutputTypeTextMessages()
        {
            _message = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestResultTypeTimers", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestResultTypeTimers
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestResultTypeTimersTimer> _timer;
        [System.Xml.Serialization.XmlElement("Timer")]
        public System.Collections.ObjectModel.Collection<TestResultTypeTimersTimer> Timer
        {
            get
            {
                return _timer;
            }
            private set
            {
                _timer = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Timer collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TimerSpecified
        {
            get
            {
                return (Timer.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestResultTypeTimers" /> class.</para>
        /// </summary>
        public TestResultTypeTimers()
        {
            _timer = new System.Collections.ObjectModel.Collection<TestResultTypeTimersTimer>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestResultTypeTimersTimer", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestResultTypeTimersTimer
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("startTime")]
        public string StartTime { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("duration")]
        public int DurationValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Duration property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool DurationValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Duration
        {
            get
            {
                if (DurationValueSpecified)
                {
                    return DurationValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DurationValue = value.GetValueOrDefault();
                DurationValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ResultFilesType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ResultFilesType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile> _resultFile;
        [System.Xml.Serialization.XmlElement("ResultFile")]
        public System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile> ResultFile
        {
            get
            {
                return _resultFile;
            }
            private set
            {
                _resultFile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ResultFile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ResultFileSpecified
        {
            get
            {
                return (ResultFile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ResultFilesType" /> class.</para>
        /// </summary>
        public ResultFilesType()
        {
            _resultFile = new System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ResultFilesTypeResultFile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ResultFilesTypeResultFile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("FileUrisType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class FileUrisType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<FileUriType> _fileUri;
        [System.Xml.Serialization.XmlElement("FileUri")]
        public System.Collections.ObjectModel.Collection<FileUriType> FileUri
        {
            get
            {
                return _fileUri;
            }
            private set
            {
                _fileUri = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the FileUri collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool FileUriSpecified
        {
            get
            {
                return (FileUri.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="FileUrisType" /> class.</para>
        /// </summary>
        public FileUrisType()
        {
            _fileUri = new System.Collections.ObjectModel.Collection<FileUriType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("FileUriType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class FileUriType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("file")]
        public string File { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("uri")]
        public string Uri { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CollectorDataEntriesType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CollectorDataEntriesType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CollectorType> _collector;
        [System.Xml.Serialization.XmlElement("Collector")]
        public System.Collections.ObjectModel.Collection<CollectorType> Collector
        {
            get
            {
                return _collector;
            }
            private set
            {
                _collector = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Collector collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CollectorSpecified
        {
            get
            {
                return (Collector.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CollectorDataEntriesType" /> class.</para>
        /// </summary>
        public CollectorDataEntriesType()
        {
            _collector = new System.Collections.ObjectModel.Collection<CollectorType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("CollectorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class CollectorType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<UriAttachmentType> _uriAttachments;
        [System.Xml.Serialization.XmlArray("UriAttachments")]
        [System.Xml.Serialization.XmlArrayItem("UriAttachment", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<UriAttachmentType> UriAttachments
        {
            get
            {
                return _uriAttachments;
            }
            private set
            {
                _uriAttachments = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UriAttachments collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UriAttachmentsSpecified
        {
            get
            {
                return (UriAttachments.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="CollectorType" /> class.</para>
        /// </summary>
        public CollectorType()
        {
            _uriAttachments = new System.Collections.ObjectModel.Collection<UriAttachmentType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("agentName")]
        public string AgentName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("agentDisplayName")]
        public string AgentDisplayName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("collectorDisplayName")]
        public string CollectorDisplayName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isFromRemoteAgent = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isFromRemoteAgent")]
        public bool IsFromRemoteAgent
        {
            get
            {
                return _isFromRemoteAgent;
            }
            set
            {
                _isFromRemoteAgent = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("uri")]
        public string Uri { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UriAttachmentsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UriAttachmentsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<UriAttachmentType> _uriAttachment;
        [System.Xml.Serialization.XmlElement("UriAttachment")]
        public System.Collections.ObjectModel.Collection<UriAttachmentType> UriAttachment
        {
            get
            {
                return _uriAttachment;
            }
            private set
            {
                _uriAttachment = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UriAttachment collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UriAttachmentSpecified
        {
            get
            {
                return (UriAttachment.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="UriAttachmentsType" /> class.</para>
        /// </summary>
        public UriAttachmentsType()
        {
            _uriAttachment = new System.Collections.ObjectModel.Collection<UriAttachmentType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UriAttachmentType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UriAttachmentType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("A")]
        public UriAttachmentTypeA A { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UriAttachmentTypeA", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UriAttachmentTypeA
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("href")]
        public string Href { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorMessagesType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorMessagesType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorMessageType> _dataCollectorMessage;
        [System.Xml.Serialization.XmlElement("DataCollectorMessage")]
        public System.Collections.ObjectModel.Collection<DataCollectorMessageType> DataCollectorMessage
        {
            get
            {
                return _dataCollectorMessage;
            }
            private set
            {
                _dataCollectorMessage = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollectorMessage collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorMessageSpecified
        {
            get
            {
                return (DataCollectorMessage.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorMessagesType" /> class.</para>
        /// </summary>
        public DataCollectorMessagesType()
        {
            _dataCollectorMessage = new System.Collections.ObjectModel.Collection<DataCollectorMessageType>();
            _dataCollectorExceptionMessage = new System.Collections.ObjectModel.Collection<DataCollectorExceptionMessageType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorExceptionMessageType> _dataCollectorExceptionMessage;
        [System.Xml.Serialization.XmlElement("DataCollectorExceptionMessage")]
        public System.Collections.ObjectModel.Collection<DataCollectorExceptionMessageType> DataCollectorExceptionMessage
        {
            get
            {
                return _dataCollectorExceptionMessage;
            }
            private set
            {
                _dataCollectorExceptionMessage = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollectorExceptionMessage collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorExceptionMessageSpecified
        {
            get
            {
                return (DataCollectorExceptionMessage.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorMessageType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(DataCollectorExceptionMessageType))]
    public partial class DataCollectorMessageType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Text")]
        public string Text { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("level")]
        public DataCollectorMessageLevelType Level { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("agentName")]
        public string AgentName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("timestamp")]
        public string Timestamp { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("dataCollectorUri")]
        public string DataCollectorUri { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("dataCollectorFriendlyName")]
        public string DataCollectorFriendlyName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorMessageLevelType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum DataCollectorMessageLevelType
    {
        Error,
        Warning,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorExceptionMessageType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorExceptionMessageType : DataCollectorMessageType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ExceptionType")]
        public string ExceptionType { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ExceptionMessage")]
        public string ExceptionMessage { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StackTrace")]
        public string StackTrace { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ResultsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ResultsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<UnitTestResultType> _unitTestResult;
        [System.Xml.Serialization.XmlElement("UnitTestResult")]
        public System.Collections.ObjectModel.Collection<UnitTestResultType> UnitTestResult
        {
            get
            {
                return _unitTestResult;
            }
            private set
            {
                _unitTestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UnitTestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UnitTestResultSpecified
        {
            get
            {
                return (UnitTestResult.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ResultsType" /> class.</para>
        /// </summary>
        public ResultsType()
        {
            _unitTestResult = new System.Collections.ObjectModel.Collection<UnitTestResultType>();
            _genericTestResult = new System.Collections.ObjectModel.Collection<TestResultAggregationType>();
            _testResult = new System.Collections.ObjectModel.Collection<TestResultType>();
            _manualTestResult = new System.Collections.ObjectModel.Collection<ManualTestResultType>();
            _testResultAggregation = new System.Collections.ObjectModel.Collection<TestResultAggregationType>();
            _webTestResult = new System.Collections.ObjectModel.Collection<WebTestResultType>();
            _loadTestResult = new System.Collections.ObjectModel.Collection<LoadTestResultType>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestResultAggregationType> _genericTestResult;
        [System.Xml.Serialization.XmlElement("GenericTestResult")]
        public System.Collections.ObjectModel.Collection<TestResultAggregationType> GenericTestResult
        {
            get
            {
                return _genericTestResult;
            }
            private set
            {
                _genericTestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the GenericTestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool GenericTestResultSpecified
        {
            get
            {
                return (GenericTestResult.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestResultType> _testResult;
        [System.Xml.Serialization.XmlElement("TestResult")]
        public System.Collections.ObjectModel.Collection<TestResultType> TestResult
        {
            get
            {
                return _testResult;
            }
            private set
            {
                _testResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestResultSpecified
        {
            get
            {
                return (TestResult.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ManualTestResultType> _manualTestResult;
        [System.Xml.Serialization.XmlElement("ManualTestResult")]
        public System.Collections.ObjectModel.Collection<ManualTestResultType> ManualTestResult
        {
            get
            {
                return _manualTestResult;
            }
            private set
            {
                _manualTestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ManualTestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ManualTestResultSpecified
        {
            get
            {
                return (ManualTestResult.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestResultAggregationType> _testResultAggregation;
        /// <summary>
        /// <para>This one can be used by any other test type as they all can internally call another set of tests and produce results, which are later merged into this aggregation for unified presentation to the caller.</para>
        /// </summary>
        [System.ComponentModel.Description("This one can be used by any other test type as they all can internally call anoth" +
            "er set of tests and produce results, which are later merged into this aggregatio" +
            "n for unified presentation to the caller.")]
        [System.Xml.Serialization.XmlElement("TestResultAggregation")]
        public System.Collections.ObjectModel.Collection<TestResultAggregationType> TestResultAggregation
        {
            get
            {
                return _testResultAggregation;
            }
            private set
            {
                _testResultAggregation = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestResultAggregation collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestResultAggregationSpecified
        {
            get
            {
                return (TestResultAggregation.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultType> _webTestResult;
        [System.Xml.Serialization.XmlElement("WebTestResult")]
        public System.Collections.ObjectModel.Collection<WebTestResultType> WebTestResult
        {
            get
            {
                return _webTestResult;
            }
            private set
            {
                _webTestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultSpecified
        {
            get
            {
                return (WebTestResult.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultType> _loadTestResult;
        [System.Xml.Serialization.XmlElement("LoadTestResult")]
        public System.Collections.ObjectModel.Collection<LoadTestResultType> LoadTestResult
        {
            get
            {
                return _loadTestResult;
            }
            private set
            {
                _loadTestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the LoadTestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool LoadTestResultSpecified
        {
            get
            {
                return (LoadTestResult.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestResultType : TestResultAggregationType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ExtensionResult")]
        public UnitTestResultTypeExtensionResult ExtensionResult { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("resultType")]
        public string ResultType { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("dataRowInfo")]
        public string DataRowInfo { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _hasSufficientAccess = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("hasSufficientAccess")]
        public bool HasSufficientAccess
        {
            get
            {
                return _hasSufficientAccess;
            }
            set
            {
                _hasSufficientAccess = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestResultTypeExtensionResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestResultTypeExtensionResult
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="UnitTestResultTypeExtensionResult" /> class.</para>
        /// </summary>
        public UnitTestResultTypeExtensionResult()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlText()]
        public string[] Text { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ManualTestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ManualTestResultType : TestResultType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Comments")]
        public object Comments { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testFile")]
        public string TestFile { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultType : TestResultType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCache> _byteArrayCache;
        [System.Xml.Serialization.XmlElement("ByteArrayCache")]
        public System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCache> ByteArrayCache
        {
            get
            {
                return _byteArrayCache;
            }
            private set
            {
                _byteArrayCache = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ByteArrayCache collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ByteArrayCacheSpecified
        {
            get
            {
                return (ByteArrayCache.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultType" /> class.</para>
        /// </summary>
        public WebTestResultType()
        {
            _byteArrayCache = new System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCache>();
            _testRunConfiguration = new System.Collections.ObjectModel.Collection<TestRunConfiguration>();
            _testSettings = new System.Collections.ObjectModel.Collection<TestSettingsType>();
            _webRequestResults = new System.Collections.ObjectModel.Collection<WebRequestResultsType>();
            _webTestResultDetails = new System.Collections.ObjectModel.Collection<WebTestResultDetailsType>();
            _webTestResultFilePath = new System.Collections.ObjectModel.Collection<string>();
            _webTestRecordedResultFilePath = new System.Collections.ObjectModel.Collection<string>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfiguration> _testRunConfiguration;
        [System.Xml.Serialization.XmlElement("TestRunConfiguration")]
        public System.Collections.ObjectModel.Collection<TestRunConfiguration> TestRunConfiguration
        {
            get
            {
                return _testRunConfiguration;
            }
            private set
            {
                _testRunConfiguration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestRunConfiguration collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestRunConfigurationSpecified
        {
            get
            {
                return (TestRunConfiguration.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestSettingsType> _testSettings;
        [System.Xml.Serialization.XmlElement("TestSettings")]
        public System.Collections.ObjectModel.Collection<TestSettingsType> TestSettings
        {
            get
            {
                return _testSettings;
            }
            private set
            {
                _testSettings = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestSettings collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestSettingsSpecified
        {
            get
            {
                return (TestSettings.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultsType> _webRequestResults;
        [System.Xml.Serialization.XmlElement("WebRequestResults")]
        public System.Collections.ObjectModel.Collection<WebRequestResultsType> WebRequestResults
        {
            get
            {
                return _webRequestResults;
            }
            private set
            {
                _webRequestResults = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebRequestResults collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebRequestResultsSpecified
        {
            get
            {
                return (WebRequestResults.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultDetailsType> _webTestResultDetails;
        [System.Xml.Serialization.XmlElement("WebTestResultDetails")]
        public System.Collections.ObjectModel.Collection<WebTestResultDetailsType> WebTestResultDetails
        {
            get
            {
                return _webTestResultDetails;
            }
            private set
            {
                _webTestResultDetails = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultDetails collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultDetailsSpecified
        {
            get
            {
                return (WebTestResultDetails.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<string> _webTestResultFilePath;
        [System.Xml.Serialization.XmlElement("WebTestResultFilePath")]
        public System.Collections.ObjectModel.Collection<string> WebTestResultFilePath
        {
            get
            {
                return _webTestResultFilePath;
            }
            private set
            {
                _webTestResultFilePath = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultFilePath collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultFilePathSpecified
        {
            get
            {
                return (WebTestResultFilePath.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<string> _webTestRecordedResultFilePath;
        [System.Xml.Serialization.XmlElement("WebTestRecordedResultFilePath")]
        public System.Collections.ObjectModel.Collection<string> WebTestRecordedResultFilePath
        {
            get
            {
                return _webTestRecordedResultFilePath;
            }
            private set
            {
                _webTestRecordedResultFilePath = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestRecordedResultFilePath collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestRecordedResultFilePathSpecified
        {
            get
            {
                return (WebTestRecordedResultFilePath.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private uint _dataRowCount = 0u;
        [System.ComponentModel.DefaultValue(0u)]
        [System.Xml.Serialization.XmlAttribute("dataRowCount")]
        public uint DataRowCount
        {
            get
            {
                return _dataRowCount;
            }
            set
            {
                _dataRowCount = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultTypeByteArrayCache", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultTypeByteArrayCache
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCacheEntry> _entry;
        [System.Xml.Serialization.XmlElement("Entry")]
        public System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCacheEntry> Entry
        {
            get
            {
                return _entry;
            }
            private set
            {
                _entry = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Entry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool EntrySpecified
        {
            get
            {
                return (Entry.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultTypeByteArrayCache" /> class.</para>
        /// </summary>
        public WebTestResultTypeByteArrayCache()
        {
            _entry = new System.Collections.ObjectModel.Collection<WebTestResultTypeByteArrayCacheEntry>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _nextHandle = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("nextHandle")]
        public int NextHandle
        {
            get
            {
                return _nextHandle;
            }
            set
            {
                _nextHandle = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultTypeByteArrayCacheEntry", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultTypeByteArrayCacheEntry
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("handle")]
        public int Handle { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("bytes")]
        public string Bytes { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestRunConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestRunConfiguration
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _description;
        [System.Xml.Serialization.XmlElement("Description")]
        public System.Collections.ObjectModel.Collection<object> Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Description collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DescriptionSpecified
        {
            get
            {
                return (Description.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfiguration" /> class.</para>
        /// </summary>
        public TestRunConfiguration()
        {
            _description = new System.Collections.ObjectModel.Collection<object>();
            _codeCoverage = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverage>();
            _timeouts = new System.Collections.ObjectModel.Collection<TestRunConfigurationTimeouts>();
            _remote = new System.Collections.ObjectModel.Collection<TestRunConfigurationRemote>();
            _deployment = new System.Collections.ObjectModel.Collection<TestRunConfigurationDeployment>();
            _namingScheme = new System.Collections.ObjectModel.Collection<TestRunConfigurationNamingScheme>();
            _scripts = new System.Collections.ObjectModel.Collection<TestRunConfigurationScripts>();
            _buckets = new System.Collections.ObjectModel.Collection<TestRunConfigurationBuckets>();
            _executionThread = new System.Collections.ObjectModel.Collection<TestRunConfigurationExecutionThread>();
            _hosts = new System.Collections.ObjectModel.Collection<TestRunConfigurationHosts>();
            _testTypeSpecific = new System.Collections.ObjectModel.Collection<TestRunConfigurationTestTypeSpecific>();
            _plugins = new System.Collections.ObjectModel.Collection<TestRunConfigurationPlugins>();
            _constraints = new System.Collections.ObjectModel.Collection<TestRunConfigurationConstraints>();
            _execution = new System.Collections.ObjectModel.Collection<TestRunConfigurationExecution>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverage> _codeCoverage;
        [System.Xml.Serialization.XmlElement("CodeCoverage")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverage> CodeCoverage
        {
            get
            {
                return _codeCoverage;
            }
            private set
            {
                _codeCoverage = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CodeCoverage collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CodeCoverageSpecified
        {
            get
            {
                return (CodeCoverage.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationTimeouts> _timeouts;
        [System.Xml.Serialization.XmlElement("Timeouts")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationTimeouts> Timeouts
        {
            get
            {
                return _timeouts;
            }
            private set
            {
                _timeouts = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Timeouts collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TimeoutsSpecified
        {
            get
            {
                return (Timeouts.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationRemote> _remote;
        [System.Xml.Serialization.XmlElement("Remote")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationRemote> Remote
        {
            get
            {
                return _remote;
            }
            private set
            {
                _remote = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Remote collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RemoteSpecified
        {
            get
            {
                return (Remote.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationDeployment> _deployment;
        [System.Xml.Serialization.XmlElement("Deployment")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationDeployment> Deployment
        {
            get
            {
                return _deployment;
            }
            private set
            {
                _deployment = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Deployment collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DeploymentSpecified
        {
            get
            {
                return (Deployment.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationNamingScheme> _namingScheme;
        [System.Xml.Serialization.XmlElement("NamingScheme")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationNamingScheme> NamingScheme
        {
            get
            {
                return _namingScheme;
            }
            private set
            {
                _namingScheme = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the NamingScheme collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool NamingSchemeSpecified
        {
            get
            {
                return (NamingScheme.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationScripts> _scripts;
        [System.Xml.Serialization.XmlElement("Scripts")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationScripts> Scripts
        {
            get
            {
                return _scripts;
            }
            private set
            {
                _scripts = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Scripts collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ScriptsSpecified
        {
            get
            {
                return (Scripts.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationBuckets> _buckets;
        [System.Xml.Serialization.XmlElement("Buckets")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationBuckets> Buckets
        {
            get
            {
                return _buckets;
            }
            private set
            {
                _buckets = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Buckets collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool BucketsSpecified
        {
            get
            {
                return (Buckets.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationExecutionThread> _executionThread;
        [System.Xml.Serialization.XmlElement("ExecutionThread")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationExecutionThread> ExecutionThread
        {
            get
            {
                return _executionThread;
            }
            private set
            {
                _executionThread = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ExecutionThread collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExecutionThreadSpecified
        {
            get
            {
                return (ExecutionThread.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationHosts> _hosts;
        [System.Xml.Serialization.XmlElement("Hosts")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationHosts> Hosts
        {
            get
            {
                return _hosts;
            }
            private set
            {
                _hosts = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Hosts collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool HostsSpecified
        {
            get
            {
                return (Hosts.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationTestTypeSpecific> _testTypeSpecific;
        [System.Xml.Serialization.XmlElement("TestTypeSpecific")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationTestTypeSpecific> TestTypeSpecific
        {
            get
            {
                return _testTypeSpecific;
            }
            private set
            {
                _testTypeSpecific = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestTypeSpecific collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestTypeSpecificSpecified
        {
            get
            {
                return (TestTypeSpecific.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationPlugins> _plugins;
        [System.Xml.Serialization.XmlElement("Plugins")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationPlugins> Plugins
        {
            get
            {
                return _plugins;
            }
            private set
            {
                _plugins = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Plugins collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PluginsSpecified
        {
            get
            {
                return (Plugins.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationConstraints> _constraints;
        [System.Xml.Serialization.XmlElement("Constraints")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationConstraints> Constraints
        {
            get
            {
                return _constraints;
            }
            private set
            {
                _constraints = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Constraints collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ConstraintsSpecified
        {
            get
            {
                return (Constraints.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationExecution> _execution;
        [System.Xml.Serialization.XmlElement("Execution")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationExecution> Execution
        {
            get
            {
                return _execution;
            }
            private set
            {
                _execution = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Execution collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExecutionSpecified
        {
            get
            {
                return (Execution.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isExecutedRemotely = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isExecutedRemotely")]
        public bool IsExecutedRemotely
        {
            get
            {
                return _isExecutedRemotely;
            }
            set
            {
                _isExecutedRemotely = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _abortRunOnError = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("abortRunOnError")]
        public bool AbortRunOnError
        {
            get
            {
                return _abortRunOnError;
            }
            set
            {
                _abortRunOnError = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _autoSaveResults = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("autoSaveResults")]
        public bool AutoSaveResults
        {
            get
            {
                return _autoSaveResults;
            }
            set
            {
                _autoSaveResults = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _mapIPAddresses = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("mapIPAddresses")]
        public bool MapIPAddresses
        {
            get
            {
                return _mapIPAddresses;
            }
            set
            {
                _mapIPAddresses = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _traceExecutionSequence = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("traceExecutionSequence")]
        public bool TraceExecutionSequence
        {
            get
            {
                return _traceExecutionSequence;
            }
            set
            {
                _traceExecutionSequence = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverage", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverage
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem> _regular;
        [System.Xml.Serialization.XmlArray("Regular")]
        [System.Xml.Serialization.XmlArrayItem("CodeCoverageItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem> Regular
        {
            get
            {
                return _regular;
            }
            private set
            {
                _regular = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Regular collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RegularSpecified
        {
            get
            {
                return (Regular.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationCodeCoverage" /> class.</para>
        /// </summary>
        public TestRunConfigurationCodeCoverage()
        {
            _regular = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem>();
            _aspNet = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem> _aspNet;
        [System.Xml.Serialization.XmlArray("AspNet")]
        [System.Xml.Serialization.XmlArrayItem("AspNetCodeCoverageItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem> AspNet
        {
            get
            {
                return _aspNet;
            }
            private set
            {
                _aspNet = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AspNet collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AspNetSpecified
        {
            get
            {
                return (AspNet.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _perTest = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("perTest")]
        public bool PerTest
        {
            get
            {
                return _perTest;
            }
            set
            {
                _perTest = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _instrumentInPlace = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("instrumentInPlace")]
        public bool InstrumentInPlace
        {
            get
            {
                return _instrumentInPlace;
            }
            set
            {
                _instrumentInPlace = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("keyFile")]
        public string KeyFile { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverageRegular", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverageRegular
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem> _codeCoverageItem;
        [System.Xml.Serialization.XmlElement("CodeCoverageItem")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem> CodeCoverageItem
        {
            get
            {
                return _codeCoverageItem;
            }
            private set
            {
                _codeCoverageItem = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CodeCoverageItem collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CodeCoverageItemSpecified
        {
            get
            {
                return (CodeCoverageItem.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationCodeCoverageRegular" /> class.</para>
        /// </summary>
        public TestRunConfigurationCodeCoverageRegular()
        {
            _codeCoverageItem = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItem>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverageRegularCodeCoverageItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverageRegularCodeCoverageItem
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItemKeyFile> _keyFile;
        [System.Xml.Serialization.XmlElement("KeyFile")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItemKeyFile> KeyFile
        {
            get
            {
                return _keyFile;
            }
            private set
            {
                _keyFile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the KeyFile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool KeyFileSpecified
        {
            get
            {
                return (KeyFile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationCodeCoverageRegularCodeCoverageItem" /> class.</para>
        /// </summary>
        public TestRunConfigurationCodeCoverageRegularCodeCoverageItem()
        {
            _keyFile = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageRegularCodeCoverageItemKeyFile>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("binaryFile")]
        public string BinaryFile { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("pdbFile")]
        public string PdbFile { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("outputDirectory")]
        public string OutputDirectory { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _instrumentInPlace = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("instrumentInPlace")]
        public bool InstrumentInPlace
        {
            get
            {
                return _instrumentInPlace;
            }
            set
            {
                _instrumentInPlace = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverageRegularCodeCoverageItemKeyFile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverageRegularCodeCoverageItemKeyFile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isPublicKey = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isPublicKey")]
        public bool IsPublicKey
        {
            get
            {
                return _isPublicKey;
            }
            set
            {
                _isPublicKey = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverageAspNet", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverageAspNet
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem> _aspNetCodeCoverageItem;
        [System.Xml.Serialization.XmlElement("AspNetCodeCoverageItem")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem> AspNetCodeCoverageItem
        {
            get
            {
                return _aspNetCodeCoverageItem;
            }
            private set
            {
                _aspNetCodeCoverageItem = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AspNetCodeCoverageItem collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AspNetCodeCoverageItemSpecified
        {
            get
            {
                return (AspNetCodeCoverageItem.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationCodeCoverageAspNet" /> class.</para>
        /// </summary>
        public TestRunConfigurationCodeCoverageAspNet()
        {
            _aspNetCodeCoverageItem = new System.Collections.ObjectModel.Collection<TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationCodeCoverageAspNetAspNetCodeCoverageItem
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("applicationRoot")]
        public string ApplicationRoot { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("isIIS")]
        public bool IsIISValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IsIIS property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IsIISValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? IsIIS
        {
            get
            {
                if (IsIISValueSpecified)
                {
                    return IsIISValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IsIISValue = value.GetValueOrDefault();
                IsIISValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationTimeouts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationTimeouts
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _runTimeout = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("runTimeout")]
        public int RunTimeout
        {
            get
            {
                return _runTimeout;
            }
            set
            {
                _runTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _testTimeout = 1800000;
        [System.ComponentModel.DefaultValue(1800000)]
        [System.Xml.Serialization.XmlAttribute("testTimeout")]
        public int TestTimeout
        {
            get
            {
                return _testTimeout;
            }
            set
            {
                _testTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _agentNotRespondingTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("agentNotRespondingTimeout")]
        public int AgentNotRespondingTimeout
        {
            get
            {
                return _agentNotRespondingTimeout;
            }
            set
            {
                _agentNotRespondingTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _deploymentTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("deploymentTimeout")]
        public int DeploymentTimeout
        {
            get
            {
                return _deploymentTimeout;
            }
            set
            {
                _deploymentTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _scriptTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("scriptTimeout")]
        public int ScriptTimeout
        {
            get
            {
                return _scriptTimeout;
            }
            set
            {
                _scriptTimeout = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationRemote", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationRemote
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Agent")]
        public TestRunConfigurationRemoteAgent Agent { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("controllerName")]
        public string ControllerName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationRemoteAgent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationRemoteAgent
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _requiredProperties;
        [System.Xml.Serialization.XmlArray("RequiredProperties")]
        [System.Xml.Serialization.XmlArrayItem("Property", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> RequiredProperties
        {
            get
            {
                return _requiredProperties;
            }
            private set
            {
                _requiredProperties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RequiredProperties collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RequiredPropertiesSpecified
        {
            get
            {
                return (RequiredProperties.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationRemoteAgent" /> class.</para>
        /// </summary>
        public TestRunConfigurationRemoteAgent()
        {
            _requiredProperties = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationRemoteAgentRequiredProperties", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationRemoteAgentRequiredProperties
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _property;
        [System.Xml.Serialization.XmlElement("Property")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> Property
        {
            get
            {
                return _property;
            }
            private set
            {
                _property = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Property collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertySpecified
        {
            get
            {
                return (Property.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationRemoteAgentRequiredProperties" /> class.</para>
        /// </summary>
        public TestRunConfigurationRemoteAgentRequiredProperties()
        {
            _property = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NameValuePropertyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NameValuePropertyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationDeployment", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationDeployment : DeploymentItemsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private bool _deploySatelliteAssemblies = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("deploySatelliteAssemblies")]
        public bool DeploySatelliteAssemblies
        {
            get
            {
                return _deploySatelliteAssemblies;
            }
            set
            {
                _deploySatelliteAssemblies = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("ignoredDependentAssemblies")]
        public string IgnoredDependentAssemblies { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("userDeploymentRoot")]
        public string UserDeploymentRoot { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("runDeploymentRoot")]
        public string RunDeploymentRoot { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useDefaultDeploymentRoot = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("useDefaultDeploymentRoot")]
        public bool UseDefaultDeploymentRoot
        {
            get
            {
                return _useDefaultDeploymentRoot;
            }
            set
            {
                _useDefaultDeploymentRoot = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _uploadDeploymentItems = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("uploadDeploymentItems")]
        public bool UploadDeploymentItems
        {
            get
            {
                return _uploadDeploymentItems;
            }
            set
            {
                _uploadDeploymentItems = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationNamingScheme", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationNamingScheme
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("baseName")]
        public string BaseName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _appendTimeStamp = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("appendTimeStamp")]
        public bool AppendTimeStamp
        {
            get
            {
                return _appendTimeStamp;
            }
            set
            {
                _appendTimeStamp = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useDefault = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("useDefault")]
        public bool UseDefault
        {
            get
            {
                return _useDefault;
            }
            set
            {
                _useDefault = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationScripts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationScripts
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("cleanupScript")]
        public string CleanupScript { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("setupScript")]
        public string SetupScript { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationBuckets", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationBuckets
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _size = 200;
        [System.ComponentModel.DefaultValue(200)]
        [System.Xml.Serialization.XmlAttribute("size")]
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationExecutionThread", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationExecutionThread
    {
        [System.Xml.Serialization.XmlIgnore()]
        private string _apartmentState = "0";
        [System.ComponentModel.DefaultValue("0")]
        [System.Xml.Serialization.XmlAttribute("apartmentState")]
        public string ApartmentState
        {
            get
            {
                return _apartmentState;
            }
            set
            {
                _apartmentState = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationHosts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationHosts
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationHostsAspNet> _aspNet;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("AspNet")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationHostsAspNet> AspNet
        {
            get
            {
                return _aspNet;
            }
            private set
            {
                _aspNet = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AspNet collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AspNetSpecified
        {
            get
            {
                return (AspNet.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationHosts" /> class.</para>
        /// </summary>
        public TestRunConfigurationHosts()
        {
            _aspNet = new System.Collections.ObjectModel.Collection<TestRunConfigurationHostsAspNet>();
            _deviceHostRunConfigData = new System.Collections.ObjectModel.Collection<TestRunConfigurationHostsDeviceHostRunConfigData>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfigurationHostsDeviceHostRunConfigData> _deviceHostRunConfigData;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("DeviceHostRunConfigData")]
        public System.Collections.ObjectModel.Collection<TestRunConfigurationHostsDeviceHostRunConfigData> DeviceHostRunConfigData
        {
            get
            {
                return _deviceHostRunConfigData;
            }
            private set
            {
                _deviceHostRunConfigData = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DeviceHostRunConfigData collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DeviceHostRunConfigDataSpecified
        {
            get
            {
                return (DeviceHostRunConfigData.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _skipUnhostableTests = true;
        /// <summary>
        /// <para>New in Orcas</para>
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("New in Orcas")]
        [System.Xml.Serialization.XmlAttribute("skipUnhostableTests")]
        public bool SkipUnhostableTests
        {
            get
            {
                return _skipUnhostableTests;
            }
            set
            {
                _skipUnhostableTests = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationHostsAspNet", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationHostsAspNet
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DevelopmentServer")]
        public DevelopmentServerType DevelopmentServer { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("urlToTest")]
        public string UrlToTest { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("executionType")]
        public string ExecutionType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationHostsDeviceHostRunConfigData", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationHostsDeviceHostRunConfigData
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("deviceId")]
        public string DeviceId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("deviceName")]
        public string DeviceName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("platformId")]
        public string PlatformId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("platformName")]
        public string PlatformName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("uiPlatformId")]
        public string UiPlatformId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationTestTypeSpecific", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationTestTypeSpecific
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> _webTestRunConfiguration;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("WebTestRunConfiguration")]
        public System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> WebTestRunConfiguration
        {
            get
            {
                return _webTestRunConfiguration;
            }
            private set
            {
                _webTestRunConfiguration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestRunConfiguration collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestRunConfigurationSpecified
        {
            get
            {
                return (WebTestRunConfiguration.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationTestTypeSpecific" /> class.</para>
        /// </summary>
        public TestRunConfigurationTestTypeSpecific()
        {
            _webTestRunConfiguration = new System.Collections.ObjectModel.Collection<WebTestRunConfigurationType>();
            _webTestRunConfig = new System.Collections.ObjectModel.Collection<WebTestRunConfigurationType>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> _webTestRunConfig;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// <para>Deprecated. Use WebTestRunConfiguration instead.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("WebTestRunConfig")]
        public System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> WebTestRunConfig
        {
            get
            {
                return _webTestRunConfig;
            }
            private set
            {
                _webTestRunConfig = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestRunConfig collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestRunConfigSpecified
        {
            get
            {
                return (WebTestRunConfig.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRunConfigurationType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRunConfigurationType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Browser")]
        public BrowserType Browser { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Network")]
        public NetworkType Network { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _simulateThinkTimes = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("simulateThinkTimes")]
        public bool SimulateThinkTimes
        {
            get
            {
                return _simulateThinkTimes;
            }
            set
            {
                _simulateThinkTimes = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useNewCookieDefaultPath = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("UseNewCookieDefaultPath")]
        public bool UseNewCookieDefaultPath
        {
            get
            {
                return _useNewCookieDefaultPath;
            }
            set
            {
                _useNewCookieDefaultPath = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _automaticallyDecompressResponse = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("AutomaticallyDecompressResponse")]
        public bool AutomaticallyDecompressResponse
        {
            get
            {
                return _automaticallyDecompressResponse;
            }
            set
            {
                _automaticallyDecompressResponse = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _stepping = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("stepping")]
        public bool Stepping
        {
            get
            {
                return _stepping;
            }
            set
            {
                _stepping = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _runUntilDataExhausted = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("runUntilDataExhausted")]
        public bool RunUntilDataExhausted
        {
            get
            {
                return _runUntilDataExhausted;
            }
            set
            {
                _runUntilDataExhausted = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _iterationCount = 1;
        [System.ComponentModel.DefaultValue(1)]
        [System.Xml.Serialization.XmlAttribute("iterationCount")]
        public int IterationCount
        {
            get
            {
                return _iterationCount;
            }
            set
            {
                _iterationCount = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("testTypeId")]
        public string TestTypeId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NetworkType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NetworkType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("BandwidthInKbps")]
        public float BandwidthInKbps { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("NetworkProfileConfigurationXml")]
        public string NetworkProfileConfigurationXml { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationPlugins", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationPlugins
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _plugin;
        [System.Xml.Serialization.XmlElement("Plugin")]
        public System.Collections.ObjectModel.Collection<object> Plugin
        {
            get
            {
                return _plugin;
            }
            private set
            {
                _plugin = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Plugin collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PluginSpecified
        {
            get
            {
                return (Plugin.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationPlugins" /> class.</para>
        /// </summary>
        public TestRunConfigurationPlugins()
        {
            _plugin = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationConstraints", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationConstraints
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _agent;
        [System.Xml.Serialization.XmlElement("Agent")]
        public System.Collections.ObjectModel.Collection<object> Agent
        {
            get
            {
                return _agent;
            }
            private set
            {
                _agent = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Agent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentSpecified
        {
            get
            {
                return (Agent.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunConfigurationConstraints" /> class.</para>
        /// </summary>
        public TestRunConfigurationConstraints()
        {
            _agent = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunConfigurationExecution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunConfigurationExecution
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _parallelTestCount = 1;
        [System.ComponentModel.DefaultValue(1)]
        [System.Xml.Serialization.XmlAttribute("parallelTestCount")]
        public int ParallelTestCount
        {
            get
            {
                return _parallelTestCount;
            }
            set
            {
                _parallelTestCount = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestSettings", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestSettingsType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Description")]
        public object Description { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Deployment")]
        public TestSettingsTypeDeployment Deployment { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _properties;
        [System.Xml.Serialization.XmlArray("Properties")]
        [System.Xml.Serialization.XmlArrayItem("Property", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> Properties
        {
            get
            {
                return _properties;
            }
            private set
            {
                _properties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Properties collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertiesSpecified
        {
            get
            {
                return (Properties.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestSettingsType" /> class.</para>
        /// </summary>
        public TestSettingsType()
        {
            _properties = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
            _constraints = new System.Collections.ObjectModel.Collection<object>();
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("NamingScheme")]
        public TestSettingsTypeNamingScheme NamingScheme { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Scripts")]
        public TestSettingsTypeScripts Scripts { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _constraints;
        [System.Xml.Serialization.XmlArray("Constraints")]
        [System.Xml.Serialization.XmlArrayItem("Agent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<object> Constraints
        {
            get
            {
                return _constraints;
            }
            private set
            {
                _constraints = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Constraints collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ConstraintsSpecified
        {
            get
            {
                return (Constraints.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("RemoteController")]
        public TestSettingsTypeRemoteController RemoteController { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Execution")]
        public TestSettingsTypeExecution Execution { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("CollectionOnlyAgents")]
        public AgentRuleCollectionType CollectionOnlyAgents { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _abortRunOnError = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("abortRunOnError")]
        public bool AbortRunOnError
        {
            get
            {
                return _abortRunOnError;
            }
            set
            {
                _abortRunOnError = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _autoSaveResults = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("autoSaveResults")]
        public bool AutoSaveResults
        {
            get
            {
                return _autoSaveResults;
            }
            set
            {
                _autoSaveResults = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _mapIPAddresses = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("mapIPAddresses")]
        public bool MapIPAddresses
        {
            get
            {
                return _mapIPAddresses;
            }
            set
            {
                _mapIPAddresses = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _traceExecutionSequence = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("traceExecutionSequence")]
        public bool TraceExecutionSequence
        {
            get
            {
                return _traceExecutionSequence;
            }
            set
            {
                _traceExecutionSequence = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enableDefaultDataCollectors = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("enableDefaultDataCollectors")]
        public bool EnableDefaultDataCollectors
        {
            get
            {
                return _enableDefaultDataCollectors;
            }
            set
            {
                _enableDefaultDataCollectors = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeDeployment", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeDeployment : DeploymentItemsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private bool _deploySatelliteAssemblies = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("deploySatelliteAssemblies")]
        public bool DeploySatelliteAssemblies
        {
            get
            {
                return _deploySatelliteAssemblies;
            }
            set
            {
                _deploySatelliteAssemblies = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("ignoredDependentAssemblies")]
        public string IgnoredDependentAssemblies { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("userDeploymentRoot")]
        public string UserDeploymentRoot { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("runDeploymentRoot")]
        public string RunDeploymentRoot { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useDefaultDeploymentRoot = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("useDefaultDeploymentRoot")]
        public bool UseDefaultDeploymentRoot
        {
            get
            {
                return _useDefaultDeploymentRoot;
            }
            set
            {
                _useDefaultDeploymentRoot = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _uploadDeploymentItems = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("uploadDeploymentItems")]
        public bool UploadDeploymentItems
        {
            get
            {
                return _uploadDeploymentItems;
            }
            set
            {
                _uploadDeploymentItems = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PropertiesType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class PropertiesType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _property;
        [System.Xml.Serialization.XmlElement("Property")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> Property
        {
            get
            {
                return _property;
            }
            private set
            {
                _property = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Property collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertySpecified
        {
            get
            {
                return (Property.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="PropertiesType" /> class.</para>
        /// </summary>
        public PropertiesType()
        {
            _property = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeNamingScheme", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeNamingScheme
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("baseName")]
        public string BaseName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _appendTimeStamp = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("appendTimeStamp")]
        public bool AppendTimeStamp
        {
            get
            {
                return _appendTimeStamp;
            }
            set
            {
                _appendTimeStamp = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useDefault = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("useDefault")]
        public bool UseDefault
        {
            get
            {
                return _useDefault;
            }
            set
            {
                _useDefault = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeScripts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeScripts
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("cleanupScript")]
        public string CleanupScript { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("setupScript")]
        public string SetupScript { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeConstraints", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeConstraints
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _agent;
        [System.Xml.Serialization.XmlElement("Agent")]
        public System.Collections.ObjectModel.Collection<object> Agent
        {
            get
            {
                return _agent;
            }
            private set
            {
                _agent = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Agent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentSpecified
        {
            get
            {
                return (Agent.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestSettingsTypeConstraints" /> class.</para>
        /// </summary>
        public TestSettingsTypeConstraints()
        {
            _agent = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeRemoteController", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeRemoteController
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecution
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Buckets")]
        public TestSettingsTypeExecutionBuckets Buckets { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ExecutionThread")]
        public TestSettingsTypeExecutionExecutionThread ExecutionThread { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Hosts")]
        public TestSettingsTypeExecutionHosts Hosts { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TestTypeSpecific")]
        public TestSettingsTypeExecutionTestTypeSpecific TestTypeSpecific { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Timeouts")]
        public TestSettingsTypeExecutionTimeouts Timeouts { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("AgentRule")]
        public AgentRuleType AgentRule { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private TestSettingsTypeExecutionLocation _location = VSTest.TestSettingsTypeExecutionLocation.Local;
        [System.ComponentModel.DefaultValue(VSTest.TestSettingsTypeExecutionLocation.Local)]
        [System.Xml.Serialization.XmlAttribute("location")]
        public TestSettingsTypeExecutionLocation Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private HostProcessPlatformTypeEnum _hostProcessPlatform = VSTest.HostProcessPlatformTypeEnum.X86;
        [System.ComponentModel.DefaultValue(VSTest.HostProcessPlatformTypeEnum.X86)]
        [System.Xml.Serialization.XmlAttribute("hostProcessPlatform")]
        public HostProcessPlatformTypeEnum HostProcessPlatform
        {
            get
            {
                return _hostProcessPlatform;
            }
            set
            {
                _hostProcessPlatform = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _parallelTestCount = 1;
        [System.ComponentModel.DefaultValue(1)]
        [System.Xml.Serialization.XmlAttribute("parallelTestCount")]
        public int ParallelTestCount
        {
            get
            {
                return _parallelTestCount;
            }
            set
            {
                _parallelTestCount = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionBuckets", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionBuckets
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _threshold = 1000;
        [System.ComponentModel.DefaultValue(1000)]
        [System.Xml.Serialization.XmlAttribute("threshold")]
        public int Threshold
        {
            get
            {
                return _threshold;
            }
            set
            {
                _threshold = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _size = 200;
        [System.ComponentModel.DefaultValue(200)]
        [System.Xml.Serialization.XmlAttribute("size")]
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionExecutionThread", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionExecutionThread
    {
        [System.Xml.Serialization.XmlIgnore()]
        private string _apartmentState = "0";
        [System.ComponentModel.DefaultValue("0")]
        [System.Xml.Serialization.XmlAttribute("apartmentState")]
        public string ApartmentState
        {
            get
            {
                return _apartmentState;
            }
            set
            {
                _apartmentState = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionHosts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionHosts
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsAspNet> _aspNet;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("AspNet")]
        public System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsAspNet> AspNet
        {
            get
            {
                return _aspNet;
            }
            private set
            {
                _aspNet = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AspNet collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AspNetSpecified
        {
            get
            {
                return (AspNet.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestSettingsTypeExecutionHosts" /> class.</para>
        /// </summary>
        public TestSettingsTypeExecutionHosts()
        {
            _aspNet = new System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsAspNet>();
            _deviceHostRunConfigData = new System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsDeviceHostRunConfigData>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsDeviceHostRunConfigData> _deviceHostRunConfigData;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("DeviceHostRunConfigData")]
        public System.Collections.ObjectModel.Collection<TestSettingsTypeExecutionHostsDeviceHostRunConfigData> DeviceHostRunConfigData
        {
            get
            {
                return _deviceHostRunConfigData;
            }
            private set
            {
                _deviceHostRunConfigData = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DeviceHostRunConfigData collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DeviceHostRunConfigDataSpecified
        {
            get
            {
                return (DeviceHostRunConfigData.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _skipUnhostableTests = true;
        /// <summary>
        /// <para>New in Orcas</para>
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("New in Orcas")]
        [System.Xml.Serialization.XmlAttribute("skipUnhostableTests")]
        public bool SkipUnhostableTests
        {
            get
            {
                return _skipUnhostableTests;
            }
            set
            {
                _skipUnhostableTests = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionHostsAspNet", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionHostsAspNet
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DevelopmentServer")]
        public DevelopmentServerType DevelopmentServer { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("urlToTest")]
        public string UrlToTest { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("executionType")]
        public string ExecutionType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionHostsDeviceHostRunConfigData", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionHostsDeviceHostRunConfigData
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("deviceId")]
        public string DeviceId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("deviceName")]
        public string DeviceName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("platformId")]
        public string PlatformId { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("platformName")]
        public string PlatformName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("uiPlatformId")]
        public string UiPlatformId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionTestTypeSpecific", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionTestTypeSpecific
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> _webTestRunConfiguration;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("WebTestRunConfiguration")]
        public System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> WebTestRunConfiguration
        {
            get
            {
                return _webTestRunConfiguration;
            }
            private set
            {
                _webTestRunConfiguration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestRunConfiguration collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestRunConfigurationSpecified
        {
            get
            {
                return (WebTestRunConfiguration.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestSettingsTypeExecutionTestTypeSpecific" /> class.</para>
        /// </summary>
        public TestSettingsTypeExecutionTestTypeSpecific()
        {
            _webTestRunConfiguration = new System.Collections.ObjectModel.Collection<WebTestRunConfigurationType>();
            _webTestRunConfig = new System.Collections.ObjectModel.Collection<WebTestRunConfigurationType>();
            _unitTestRunConfig = new System.Collections.ObjectModel.Collection<AssemblyResolutionSettingsType>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> _webTestRunConfig;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// <para>Deprecated. Use WebTestRunConfiguration instead.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("WebTestRunConfig")]
        public System.Collections.ObjectModel.Collection<WebTestRunConfigurationType> WebTestRunConfig
        {
            get
            {
                return _webTestRunConfig;
            }
            private set
            {
                _webTestRunConfig = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestRunConfig collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestRunConfigSpecified
        {
            get
            {
                return (WebTestRunConfig.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<AssemblyResolutionSettingsType> _unitTestRunConfig;
        /// <summary>
        /// <para>Only one instance is allowed but no check is done due to xsd limitations.</para>
        /// </summary>
        [System.ComponentModel.Description("Only one instance is allowed but no check is done due to xsd limitations.")]
        [System.Xml.Serialization.XmlElement("UnitTestRunConfig")]
        public System.Collections.ObjectModel.Collection<AssemblyResolutionSettingsType> UnitTestRunConfig
        {
            get
            {
                return _unitTestRunConfig;
            }
            private set
            {
                _unitTestRunConfig = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UnitTestRunConfig collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UnitTestRunConfigSpecified
        {
            get
            {
                return (UnitTestRunConfig.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AssemblyResolutionSettingsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestExecution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class AssemblyResolutionSettingsType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("AssemblyResolution")]
        public AssemblyResolutionSettingsTypeAssemblyResolution AssemblyResolution { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("testTypeId")]
        public string TestTypeId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AssemblyResolutionSettingsTypeAssemblyResolution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AssemblyResolutionSettingsTypeAssemblyResolution
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TestDirectory")]
        public AssemblyResolutionSettingsTypeAssemblyResolutionTestDirectory TestDirectory { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType> _runtimeResolution;
        [System.Xml.Serialization.XmlArray("RuntimeResolution")]
        [System.Xml.Serialization.XmlArrayItem("Directory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType> RuntimeResolution
        {
            get
            {
                return _runtimeResolution;
            }
            private set
            {
                _runtimeResolution = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuntimeResolution collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RuntimeResolutionSpecified
        {
            get
            {
                return (RuntimeResolution.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AssemblyResolutionSettingsTypeAssemblyResolution" /> class.</para>
        /// </summary>
        public AssemblyResolutionSettingsTypeAssemblyResolution()
        {
            _runtimeResolution = new System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType>();
            _discoveryResolution = new System.Collections.ObjectModel.Collection<ResolutionDirectoryType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResolutionDirectoryType> _discoveryResolution;
        [System.Xml.Serialization.XmlArray("DiscoveryResolution")]
        [System.Xml.Serialization.XmlArrayItem("Directory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<ResolutionDirectoryType> DiscoveryResolution
        {
            get
            {
                return _discoveryResolution;
            }
            private set
            {
                _discoveryResolution = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DiscoveryResolution collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DiscoveryResolutionSpecified
        {
            get
            {
                return (DiscoveryResolution.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("applicationBaseDirectory")]
        public string ApplicationBaseDirectory { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AssemblyResolutionSettingsTypeAssemblyResolutionTestDirectory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AssemblyResolutionSettingsTypeAssemblyResolutionTestDirectory
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("useLoadContext")]
        public bool UseLoadContext { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AssemblyResolutionSettingsTypeAssemblyResolutionRuntimeResolution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AssemblyResolutionSettingsTypeAssemblyResolutionRuntimeResolution
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType> _directory;
        [System.Xml.Serialization.XmlElement("Directory")]
        public System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType> Directory
        {
            get
            {
                return _directory;
            }
            private set
            {
                _directory = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Directory collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DirectorySpecified
        {
            get
            {
                return (Directory.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AssemblyResolutionSettingsTypeAssemblyResolutionRuntimeResolution" /> class.</para>
        /// </summary>
        public AssemblyResolutionSettingsTypeAssemblyResolutionRuntimeResolution()
        {
            _directory = new System.Collections.ObjectModel.Collection<RuntimeResolutionDirectoryType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RuntimeResolutionDirectoryType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RuntimeResolutionDirectoryType : ResolutionDirectoryType
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("useLoadContext")]
        public bool UseLoadContextValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the UseLoadContext property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool UseLoadContextValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? UseLoadContext
        {
            get
            {
                if (UseLoadContextValueSpecified)
                {
                    return UseLoadContextValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                UseLoadContextValue = value.GetValueOrDefault();
                UseLoadContextValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ResolutionDirectoryType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(RuntimeResolutionDirectoryType))]
    public partial class ResolutionDirectoryType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("includeSubDirectories")]
        public bool IncludeSubDirectories { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AssemblyResolutionSettingsTypeAssemblyResolutionDiscoveryResolution", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AssemblyResolutionSettingsTypeAssemblyResolutionDiscoveryResolution
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResolutionDirectoryType> _directory;
        [System.Xml.Serialization.XmlElement("Directory")]
        public System.Collections.ObjectModel.Collection<ResolutionDirectoryType> Directory
        {
            get
            {
                return _directory;
            }
            private set
            {
                _directory = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Directory collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DirectorySpecified
        {
            get
            {
                return (Directory.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AssemblyResolutionSettingsTypeAssemblyResolutionDiscoveryResolution" /> class.</para>
        /// </summary>
        public AssemblyResolutionSettingsTypeAssemblyResolutionDiscoveryResolution()
        {
            _directory = new System.Collections.ObjectModel.Collection<ResolutionDirectoryType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionTimeouts", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestSettingsTypeExecutionTimeouts
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _runTimeout = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("runTimeout")]
        public int RunTimeout
        {
            get
            {
                return _runTimeout;
            }
            set
            {
                _runTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _testTimeout = 1800000;
        [System.ComponentModel.DefaultValue(1800000)]
        [System.Xml.Serialization.XmlAttribute("testTimeout")]
        public int TestTimeout
        {
            get
            {
                return _testTimeout;
            }
            set
            {
                _testTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _agentNotRespondingTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("agentNotRespondingTimeout")]
        public int AgentNotRespondingTimeout
        {
            get
            {
                return _agentNotRespondingTimeout;
            }
            set
            {
                _agentNotRespondingTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _deploymentTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("deploymentTimeout")]
        public int DeploymentTimeout
        {
            get
            {
                return _deploymentTimeout;
            }
            set
            {
                _deploymentTimeout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _scriptTimeout = 300000;
        [System.ComponentModel.DefaultValue(300000)]
        [System.Xml.Serialization.XmlAttribute("scriptTimeout")]
        public int ScriptTimeout
        {
            get
            {
                return _scriptTimeout;
            }
            set
            {
                _scriptTimeout = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("SelectionCriteria")]
        public AgentRuleTypeSelectionCriteria SelectionCriteria { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector> _dataCollectors;
        [System.Xml.Serialization.XmlArray("DataCollectors")]
        [System.Xml.Serialization.XmlArrayItem("DataCollector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector> DataCollectors
        {
            get
            {
                return _dataCollectors;
            }
            private set
            {
                _dataCollectors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollectors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorsSpecified
        {
            get
            {
                return (DataCollectors.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleType" /> class.</para>
        /// </summary>
        public AgentRuleType()
        {
            _dataCollectors = new System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleTypeSelectionCriteria", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleTypeSelectionCriteria
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _agentProperty;
        [System.Xml.Serialization.XmlElement("AgentProperty")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> AgentProperty
        {
            get
            {
                return _agentProperty;
            }
            private set
            {
                _agentProperty = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AgentProperty collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentPropertySpecified
        {
            get
            {
                return (AgentProperty.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleTypeSelectionCriteria" /> class.</para>
        /// </summary>
        public AgentRuleTypeSelectionCriteria()
        {
            _agentProperty = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("selectAllAgents")]
        public bool SelectAllAgentsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SelectAllAgents property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SelectAllAgentsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SelectAllAgents
        {
            get
            {
                if (SelectAllAgentsValueSpecified)
                {
                    return SelectAllAgentsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SelectAllAgentsValue = value.GetValueOrDefault();
                SelectAllAgentsValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleTypeDataCollectors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleTypeDataCollectors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector> _dataCollector;
        [System.Xml.Serialization.XmlElement("DataCollector")]
        public System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector> DataCollector
        {
            get
            {
                return _dataCollector;
            }
            private set
            {
                _dataCollector = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollector collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorSpecified
        {
            get
            {
                return (DataCollector.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleTypeDataCollectors" /> class.</para>
        /// </summary>
        public AgentRuleTypeDataCollectors()
        {
            _dataCollector = new System.Collections.ObjectModel.Collection<AgentRuleTypeDataCollectorsDataCollector>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleTypeDataCollectorsDataCollector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleTypeDataCollectorsDataCollector
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Configuration")]
        public AgentRuleTypeDataCollectorsDataCollectorConfiguration Configuration { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("uri")]
        public string Uri { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("friendlyName")]
        public string FriendlyName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("assemblyQualifiedName")]
        public string AssemblyQualifiedName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleTypeDataCollectorsDataCollectorConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleTypeDataCollectorsDataCollectorConfiguration
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleTypeDataCollectorsDataCollectorConfiguration" /> class.</para>
        /// </summary>
        public AgentRuleTypeDataCollectorsDataCollectorConfiguration()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestSettingsTypeExecutionLocation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum TestSettingsTypeExecutionLocation
    {
        Local,
        Remote,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleCollectionType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleCollectionType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<AgentRuleType> _agentRules;
        [System.Xml.Serialization.XmlArray("AgentRules")]
        [System.Xml.Serialization.XmlArrayItem("AgentRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<AgentRuleType> AgentRules
        {
            get
            {
                return _agentRules;
            }
            private set
            {
                _agentRules = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AgentRules collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentRulesSpecified
        {
            get
            {
                return (AgentRules.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleCollectionType" /> class.</para>
        /// </summary>
        public AgentRuleCollectionType()
        {
            _agentRules = new System.Collections.ObjectModel.Collection<AgentRuleType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentRuleCollectionTypeAgentRules", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AgentRuleCollectionTypeAgentRules
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<AgentRuleType> _agentRule;
        [System.Xml.Serialization.XmlElement("AgentRule")]
        public System.Collections.ObjectModel.Collection<AgentRuleType> AgentRule
        {
            get
            {
                return _agentRule;
            }
            private set
            {
                _agentRule = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AgentRule collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentRuleSpecified
        {
            get
            {
                return (AgentRule.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AgentRuleCollectionTypeAgentRules" /> class.</para>
        /// </summary>
        public AgentRuleCollectionTypeAgentRules()
        {
            _agentRule = new System.Collections.ObjectModel.Collection<AgentRuleType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultType> _webRequestResult;
        [System.Xml.Serialization.XmlElement("WebRequestResult")]
        public System.Collections.ObjectModel.Collection<WebRequestResultType> WebRequestResult
        {
            get
            {
                return _webRequestResult;
            }
            private set
            {
                _webRequestResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebRequestResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebRequestResultSpecified
        {
            get
            {
                return (WebRequestResult.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultsType" /> class.</para>
        /// </summary>
        public WebRequestResultsType()
        {
            _webRequestResult = new System.Collections.ObjectModel.Collection<WebRequestResultType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Request")]
        public WebRequestResultTypeRequest Request { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Response")]
        public WebRequestResultTypeResponse Response { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry> _context;
        [System.Xml.Serialization.XmlArray("Context")]
        [System.Xml.Serialization.XmlArrayItem("Entry", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry> Context
        {
            get
            {
                return _context;
            }
            private set
            {
                _context = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Context collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ContextSpecified
        {
            get
            {
                return (Context.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultType" /> class.</para>
        /// </summary>
        public WebRequestResultType()
        {
            _context = new System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry>();
            _errors = new System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError>();
            _dependantResults = new System.Collections.ObjectModel.Collection<WebRequestResultType>();
            _validationRuleResults = new System.Collections.ObjectModel.Collection<RuleResultType>();
            _extractionRuleResults = new System.Collections.ObjectModel.Collection<RuleResultType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError> _errors;
        [System.Xml.Serialization.XmlArray("Errors")]
        [System.Xml.Serialization.XmlArrayItem("Error", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError> Errors
        {
            get
            {
                return _errors;
            }
            private set
            {
                _errors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Errors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ErrorsSpecified
        {
            get
            {
                return (Errors.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultType> _dependantResults;
        [System.Xml.Serialization.XmlArray("DependantResults")]
        [System.Xml.Serialization.XmlArrayItem("WebRequestResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebRequestResultType> DependantResults
        {
            get
            {
                return _dependantResults;
            }
            private set
            {
                _dependantResults = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DependantResults collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DependantResultsSpecified
        {
            get
            {
                return (DependantResults.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultType> _validationRuleResults;
        [System.Xml.Serialization.XmlArray("ValidationRuleResults")]
        [System.Xml.Serialization.XmlArrayItem("ValidationRuleResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<RuleResultType> ValidationRuleResults
        {
            get
            {
                return _validationRuleResults;
            }
            private set
            {
                _validationRuleResults = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ValidationRuleResults collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ValidationRuleResultsSpecified
        {
            get
            {
                return (ValidationRuleResults.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultType> _extractionRuleResults;
        [System.Xml.Serialization.XmlArray("ExtractionRuleResults")]
        [System.Xml.Serialization.XmlArrayItem("ExtractionRuleResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<RuleResultType> ExtractionRuleResults
        {
            get
            {
                return _extractionRuleResults;
            }
            private set
            {
                _extractionRuleResults = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ExtractionRuleResults collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExtractionRuleResultsSpecified
        {
            get
            {
                return (ExtractionRuleResults.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("redirectUrl")]
        public string RedirectUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("exceptionMessage")]
        public string ExceptionMessage { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("run")]
        public int RunValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Run property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RunValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Run
        {
            get
            {
                if (RunValueSpecified)
                {
                    return RunValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RunValue = value.GetValueOrDefault();
                RunValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("submitted")]
        public bool SubmittedValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Submitted property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SubmittedValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? Submitted
        {
            get
            {
                if (SubmittedValueSpecified)
                {
                    return SubmittedValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SubmittedValue = value.GetValueOrDefault();
                SubmittedValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("cached")]
        public bool CachedValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Cached property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CachedValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? Cached
        {
            get
            {
                if (CachedValueSpecified)
                {
                    return CachedValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                CachedValue = value.GetValueOrDefault();
                CachedValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("isRedirectFollow")]
        public bool IsRedirectFollowValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IsRedirectFollow property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IsRedirectFollowValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? IsRedirectFollow
        {
            get
            {
                if (IsRedirectFollowValueSpecified)
                {
                    return IsRedirectFollowValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IsRedirectFollowValue = value.GetValueOrDefault();
                IsRedirectFollowValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("requestBodyBytesHandle")]
        public int RequestBodyBytesHandleValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the RequestBodyBytesHandle property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RequestBodyBytesHandleValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? RequestBodyBytesHandle
        {
            get
            {
                if (RequestBodyBytesHandleValueSpecified)
                {
                    return RequestBodyBytesHandleValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RequestBodyBytesHandleValue = value.GetValueOrDefault();
                RequestBodyBytesHandleValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("responseBytesHandle")]
        public int ResponseBytesHandleValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ResponseBytesHandle property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ResponseBytesHandleValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? ResponseBytesHandle
        {
            get
            {
                if (ResponseBytesHandleValueSpecified)
                {
                    return ResponseBytesHandleValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ResponseBytesHandleValue = value.GetValueOrDefault();
                ResponseBytesHandleValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("resultsUrl")]
        public string ResultsUrl { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private int _httpStatus = 200;
        [System.ComponentModel.DefaultValue(200)]
        [System.Xml.Serialization.XmlAttribute("httpStatus")]
        public int HttpStatus
        {
            get
            {
                return _httpStatus;
            }
            set
            {
                _httpStatus = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _recordResult = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("recordResult")]
        public bool RecordResult
        {
            get
            {
                return _recordResult;
            }
            set
            {
                _recordResult = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("scenarioName")]
        public string ScenarioName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("testCaseName")]
        public string TestCaseName { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("failedValidationRuleCount")]
        public int FailedValidationRuleCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FailedValidationRuleCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool FailedValidationRuleCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? FailedValidationRuleCount
        {
            get
            {
                if (FailedValidationRuleCountValueSpecified)
                {
                    return FailedValidationRuleCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                FailedValidationRuleCountValue = value.GetValueOrDefault();
                FailedValidationRuleCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("successfulExtractionRuleCount")]
        public int SuccessfulExtractionRuleCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SuccessfulExtractionRuleCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SuccessfulExtractionRuleCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SuccessfulExtractionRuleCount
        {
            get
            {
                if (SuccessfulExtractionRuleCountValueSpecified)
                {
                    return SuccessfulExtractionRuleCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SuccessfulExtractionRuleCountValue = value.GetValueOrDefault();
                SuccessfulExtractionRuleCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("failedExtractionRuleCount")]
        public int FailedExtractionRuleCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FailedExtractionRuleCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool FailedExtractionRuleCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? FailedExtractionRuleCount
        {
            get
            {
                if (FailedExtractionRuleCountValueSpecified)
                {
                    return FailedExtractionRuleCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                FailedExtractionRuleCountValue = value.GetValueOrDefault();
                FailedExtractionRuleCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("requestPassedByCode")]
        public bool RequestPassedByCodeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the RequestPassedByCode property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RequestPassedByCodeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? RequestPassedByCode
        {
            get
            {
                if (RequestPassedByCodeValueSpecified)
                {
                    return RequestPassedByCodeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RequestPassedByCodeValue = value.GetValueOrDefault();
                RequestPassedByCodeValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeRequest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeRequest
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Headers")]
        public object Headers { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("command")]
        public string Command { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("contentType")]
        public string ContentType { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("encoding")]
        public string Encoding { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeResponse", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeResponse
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Headers")]
        public object Headers { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("contentType")]
        public string ContentType { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("statusLine")]
        public string StatusLine { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("pageTime")]
        public string PageTime { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("time")]
        public string Time { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("statusCodeString")]
        public string StatusCodeString { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("contentLength")]
        public string ContentLength { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeContext", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeContext
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry> _entry;
        [System.Xml.Serialization.XmlElement("Entry")]
        public System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry> Entry
        {
            get
            {
                return _entry;
            }
            private set
            {
                _entry = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Entry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool EntrySpecified
        {
            get
            {
                return (Entry.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultTypeContext" /> class.</para>
        /// </summary>
        public WebRequestResultTypeContext()
        {
            _entry = new System.Collections.ObjectModel.Collection<WebRequestResultTypeContextEntry>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeContextEntry", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeContextEntry
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeErrors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeErrors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError> _error;
        [System.Xml.Serialization.XmlElement("Error")]
        public System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError> Error
        {
            get
            {
                return _error;
            }
            private set
            {
                _error = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Error collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ErrorSpecified
        {
            get
            {
                return (Error.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultTypeErrors" /> class.</para>
        /// </summary>
        public WebRequestResultTypeErrors()
        {
            _error = new System.Collections.ObjectModel.Collection<WebRequestResultTypeErrorsError>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeErrorsError", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeErrorsError
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StackTrace")]
        public object StackTrace { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ExceptionText")]
        public object ExceptionText { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("type")]
        public WebTestErrorType TypeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Type property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TypeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public WebTestErrorType? Type
        {
            get
            {
                if (TypeValueSpecified)
                {
                    return TypeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TypeValue = value.GetValueOrDefault();
                TypeValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("subType")]
        public string SubType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("text")]
        public string Text { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("stackTrace")]
        public string StackTrace1 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("exceptionText")]
        public string ExceptionText1 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("time")]
        public string Time { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestErrorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum WebTestErrorType
    {
        TestError,
        Exception,
        HttpError,
        ValidationRuleError,
        ExtractionRuleError,
        ConditionalRuleError,
        Timeout,
        DataCollectionError,
        DataCollectionWarning,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeValidationRuleResults", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeValidationRuleResults
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultType> _validationRuleResult;
        [System.Xml.Serialization.XmlElement("ValidationRuleResult")]
        public System.Collections.ObjectModel.Collection<RuleResultType> ValidationRuleResult
        {
            get
            {
                return _validationRuleResult;
            }
            private set
            {
                _validationRuleResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ValidationRuleResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ValidationRuleResultSpecified
        {
            get
            {
                return (ValidationRuleResult.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultTypeValidationRuleResults" /> class.</para>
        /// </summary>
        public WebRequestResultTypeValidationRuleResults()
        {
            _validationRuleResult = new System.Collections.ObjectModel.Collection<RuleResultType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RuleResultType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RuleResultType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty> _ruleProperties;
        [System.Xml.Serialization.XmlArray("RuleProperties")]
        [System.Xml.Serialization.XmlArrayItem("RuleProperty", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty> RuleProperties
        {
            get
            {
                return _ruleProperties;
            }
            private set
            {
                _ruleProperties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuleProperties collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RulePropertiesSpecified
        {
            get
            {
                return (RuleProperties.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="RuleResultType" /> class.</para>
        /// </summary>
        public RuleResultType()
        {
            _ruleProperties = new System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("ruleType")]
        public string RuleType { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _success = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("success")]
        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("message")]
        public string Message { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RuleResultTypeRuleProperties", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RuleResultTypeRuleProperties
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty> _ruleProperty;
        [System.Xml.Serialization.XmlElement("RuleProperty")]
        public System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty> RuleProperty
        {
            get
            {
                return _ruleProperty;
            }
            private set
            {
                _ruleProperty = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuleProperty collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RulePropertySpecified
        {
            get
            {
                return (RuleProperty.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="RuleResultTypeRuleProperties" /> class.</para>
        /// </summary>
        public RuleResultTypeRuleProperties()
        {
            _ruleProperty = new System.Collections.ObjectModel.Collection<RuleResultTypeRulePropertiesRuleProperty>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RuleResultTypeRulePropertiesRuleProperty", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RuleResultTypeRulePropertiesRuleProperty
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebRequestResultTypeExtractionRuleResults", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebRequestResultTypeExtractionRuleResults
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<RuleResultType> _extractionRuleResult;
        [System.Xml.Serialization.XmlElement("ExtractionRuleResult")]
        public System.Collections.ObjectModel.Collection<RuleResultType> ExtractionRuleResult
        {
            get
            {
                return _extractionRuleResult;
            }
            private set
            {
                _extractionRuleResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ExtractionRuleResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExtractionRuleResultSpecified
        {
            get
            {
                return (ExtractionRuleResult.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebRequestResultTypeExtractionRuleResults" /> class.</para>
        /// </summary>
        public WebRequestResultTypeExtractionRuleResults()
        {
            _extractionRuleResult = new System.Collections.ObjectModel.Collection<RuleResultType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultDetailsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultDetailsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration> _webTestResultIterations;
        [System.Xml.Serialization.XmlArray("WebTestResultIterations")]
        [System.Xml.Serialization.XmlArrayItem("WebTestResultIteration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration> WebTestResultIterations
        {
            get
            {
                return _webTestResultIterations;
            }
            private set
            {
                _webTestResultIterations = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultIterations collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultIterationsSpecified
        {
            get
            {
                return (WebTestResultIterations.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultDetailsType" /> class.</para>
        /// </summary>
        public WebTestResultDetailsType()
        {
            _webTestResultIterations = new System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultDetailsTypeWebTestResultIterations", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultDetailsTypeWebTestResultIterations
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration> _webTestResultIteration;
        [System.Xml.Serialization.XmlElement("WebTestResultIteration")]
        public System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration> WebTestResultIteration
        {
            get
            {
                return _webTestResultIteration;
            }
            private set
            {
                _webTestResultIteration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultIteration collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultIterationSpecified
        {
            get
            {
                return (WebTestResultIteration.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultDetailsTypeWebTestResultIterations" /> class.</para>
        /// </summary>
        public WebTestResultDetailsTypeWebTestResultIterations()
        {
            _webTestResultIteration = new System.Collections.ObjectModel.Collection<WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultDetailsTypeWebTestResultIterationsWebTestResultIteration
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("WebTestResultGroup")]
        public WebTestResultGroupType WebTestResultGroup { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("iterationNumber")]
        public int IterationNumber { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultGroupType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultGroupType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultCommentType> _webTestResultComment;
        [System.Xml.Serialization.XmlElement("WebTestResultComment")]
        public System.Collections.ObjectModel.Collection<WebTestResultCommentType> WebTestResultComment
        {
            get
            {
                return _webTestResultComment;
            }
            private set
            {
                _webTestResultComment = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultComment collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultCommentSpecified
        {
            get
            {
                return (WebTestResultComment.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultGroupType" /> class.</para>
        /// </summary>
        public WebTestResultGroupType()
        {
            _webTestResultComment = new System.Collections.ObjectModel.Collection<WebTestResultCommentType>();
            _webTestResultTransaction = new System.Collections.ObjectModel.Collection<WebTestResultTransactionType>();
            _webTestResultPage = new System.Collections.ObjectModel.Collection<WebTestResultPageType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultTransactionType> _webTestResultTransaction;
        [System.Xml.Serialization.XmlElement("WebTestResultTransaction")]
        public System.Collections.ObjectModel.Collection<WebTestResultTransactionType> WebTestResultTransaction
        {
            get
            {
                return _webTestResultTransaction;
            }
            private set
            {
                _webTestResultTransaction = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultTransaction collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultTransactionSpecified
        {
            get
            {
                return (WebTestResultTransaction.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultPageType> _webTestResultPage;
        [System.Xml.Serialization.XmlElement("WebTestResultPage")]
        public System.Collections.ObjectModel.Collection<WebTestResultPageType> WebTestResultPage
        {
            get
            {
                return _webTestResultPage;
            }
            private set
            {
                _webTestResultPage = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTestResultPage collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestResultPageSpecified
        {
            get
            {
                return (WebTestResultPage.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultCommentType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultCommentType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("comment")]
        public string Comment { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultTransactionType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultTransactionType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("WebTestResultGroup")]
        public WebTestResultGroupType WebTestResultGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("isIncludedTest")]
        public bool IsIncludedTestValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IsIncludedTest property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IsIncludedTestValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? IsIncludedTest
        {
            get
            {
                if (IsIncludedTestValueSpecified)
                {
                    return IsIncludedTestValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IsIncludedTestValue = value.GetValueOrDefault();
                IsIncludedTestValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("responseTime")]
        public string ResponseTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultPageType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultPageType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("WebRequestResult")]
        public WebRequestResultType WebRequestResult { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType> _redirectedPages;
        [System.Xml.Serialization.XmlArray("RedirectedPages")]
        [System.Xml.Serialization.XmlArrayItem("RedirectedPage", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType> RedirectedPages
        {
            get
            {
                return _redirectedPages;
            }
            private set
            {
                _redirectedPages = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RedirectedPages collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RedirectedPagesSpecified
        {
            get
            {
                return (RedirectedPages.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultPageType" /> class.</para>
        /// </summary>
        public WebTestResultPageType()
        {
            _redirectedPages = new System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultPageTypeRedirectedPages", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultPageTypeRedirectedPages
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType> _redirectedPage;
        [System.Xml.Serialization.XmlElement("RedirectedPage")]
        public System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType> RedirectedPage
        {
            get
            {
                return _redirectedPage;
            }
            private set
            {
                _redirectedPage = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RedirectedPage collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RedirectedPageSpecified
        {
            get
            {
                return (RedirectedPage.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestResultPageTypeRedirectedPages" /> class.</para>
        /// </summary>
        public WebTestResultPageTypeRedirectedPages()
        {
            _redirectedPage = new System.Collections.ObjectModel.Collection<WebTestResultRedirectedPageType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestResultRedirectedPageType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestResultRedirectedPageType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("WebRequestResult")]
        public WebRequestResultType WebRequestResult { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeAnalyzerViewState", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeAnalyzerViewState
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("LoadTestRunDescriptor")]
        public LoadTestRunDescriptorType LoadTestRunDescriptor { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestRunDescriptorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestRunDescriptorType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GraphDescriptorType> _graphDescriptors;
        [System.Xml.Serialization.XmlArray("GraphDescriptors")]
        [System.Xml.Serialization.XmlArrayItem("GraphDescriptor", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<GraphDescriptorType> GraphDescriptors
        {
            get
            {
                return _graphDescriptors;
            }
            private set
            {
                _graphDescriptors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the GraphDescriptors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool GraphDescriptorsSpecified
        {
            get
            {
                return (GraphDescriptors.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestRunDescriptorType" /> class.</para>
        /// </summary>
        public LoadTestRunDescriptorType()
        {
            _graphDescriptors = new System.Collections.ObjectModel.Collection<GraphDescriptorType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isLegendPanelVisible = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isLegendPanelVisible")]
        public bool IsLegendPanelVisible
        {
            get
            {
                return _isLegendPanelVisible;
            }
            set
            {
                _isLegendPanelVisible = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isOverviewPanelVisible = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isOverviewPanelVisible")]
        public bool IsOverviewPanelVisible
        {
            get
            {
                return _isOverviewPanelVisible;
            }
            set
            {
                _isOverviewPanelVisible = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isCounterPanelVisible = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isCounterPanelVisible")]
        public bool IsCounterPanelVisible
        {
            get
            {
                return _isCounterPanelVisible;
            }
            set
            {
                _isCounterPanelVisible = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _scrollingGraph = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("scrollingGraph")]
        public bool ScrollingGraph
        {
            get
            {
                return _scrollingGraph;
            }
            set
            {
                _scrollingGraph = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _minMaxGraph = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("minMaxGraph")]
        public bool MinMaxGraph
        {
            get
            {
                return _minMaxGraph;
            }
            set
            {
                _minMaxGraph = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _showHorizontalGridOnGraph = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("showHorizontalGridOnGraph")]
        public bool ShowHorizontalGridOnGraph
        {
            get
            {
                return _showHorizontalGridOnGraph;
            }
            set
            {
                _showHorizontalGridOnGraph = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _showThresholdsOnGraph = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("showThresholdsOnGraph")]
        public bool ShowThresholdsOnGraph
        {
            get
            {
                return _showThresholdsOnGraph;
            }
            set
            {
                _showThresholdsOnGraph = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _showComparison = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("showComparison")]
        public bool ShowComparison
        {
            get
            {
                return _showComparison;
            }
            set
            {
                _showComparison = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _showZoom = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("showZoom")]
        public bool ShowZoom
        {
            get
            {
                return _showZoom;
            }
            set
            {
                _showZoom = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _lockZoom = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("lockZoom")]
        public bool LockZoom
        {
            get
            {
                return _lockZoom;
            }
            set
            {
                _lockZoom = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private LoadTestRunDescriptorViewType _activeConsoleView = VSTest.LoadTestRunDescriptorViewType.Graph;
        [System.ComponentModel.DefaultValue(VSTest.LoadTestRunDescriptorViewType.Graph)]
        [System.Xml.Serialization.XmlAttribute("activeConsoleView")]
        public LoadTestRunDescriptorViewType ActiveConsoleView
        {
            get
            {
                return _activeConsoleView;
            }
            set
            {
                _activeConsoleView = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("selectedGraphPanel1")]
        public string SelectedGraphPanel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("selectedGraphPanel2")]
        public string SelectedGraphPanel2 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("selectedGraphPanel3")]
        public string SelectedGraphPanel3 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("selectedGraphPanel4")]
        public string SelectedGraphPanel4 { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private PanelLayoutType _graphPanelLayout = VSTest.PanelLayoutType.FourGrid;
        [System.ComponentModel.DefaultValue(VSTest.PanelLayoutType.FourGrid)]
        [System.Xml.Serialization.XmlAttribute("graphPanelLayout")]
        public PanelLayoutType GraphPanelLayout
        {
            get
            {
                return _graphPanelLayout;
            }
            set
            {
                _graphPanelLayout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private PanelLayoutType _tablePanelLayout = VSTest.PanelLayoutType.TwoHorizontal;
        [System.ComponentModel.DefaultValue(VSTest.PanelLayoutType.TwoHorizontal)]
        [System.Xml.Serialization.XmlAttribute("tablePanelLayout")]
        public PanelLayoutType TablePanelLayout
        {
            get
            {
                return _tablePanelLayout;
            }
            set
            {
                _tablePanelLayout = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _selectedTablePanel1 = "Tests";
        [System.ComponentModel.DefaultValue("Tests")]
        [System.Xml.Serialization.XmlAttribute("selectedTablePanel1")]
        public string SelectedTablePanel1
        {
            get
            {
                return _selectedTablePanel1;
            }
            set
            {
                _selectedTablePanel1 = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _selectedTablePanel2 = "Errors";
        [System.ComponentModel.DefaultValue("Errors")]
        [System.Xml.Serialization.XmlAttribute("selectedTablePanel2")]
        public string SelectedTablePanel2
        {
            get
            {
                return _selectedTablePanel2;
            }
            set
            {
                _selectedTablePanel2 = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _selectedTablePanel3 = "Thresholds";
        [System.ComponentModel.DefaultValue("Thresholds")]
        [System.Xml.Serialization.XmlAttribute("selectedTablePanel3")]
        public string SelectedTablePanel3
        {
            get
            {
                return _selectedTablePanel3;
            }
            set
            {
                _selectedTablePanel3 = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _selectedTablePanel4 = "Transactions";
        [System.ComponentModel.DefaultValue("Transactions")]
        [System.Xml.Serialization.XmlAttribute("selectedTablePanel4")]
        public string SelectedTablePanel4
        {
            get
            {
                return _selectedTablePanel4;
            }
            set
            {
                _selectedTablePanel4 = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("controllerName")]
        public string ControllerName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isLocalRun = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isLocalRun")]
        public bool IsLocalRun
        {
            get
            {
                return _isLocalRun;
            }
            set
            {
                _isLocalRun = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testRunId")]
        public string TestRunId { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private int _repositoryRunId = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("repositoryRunId")]
        public int RepositoryRunId
        {
            get
            {
                return _repositoryRunId;
            }
            set
            {
                _repositoryRunId = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestRunDescriptorTypeGraphDescriptors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestRunDescriptorTypeGraphDescriptors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GraphDescriptorType> _graphDescriptor;
        [System.Xml.Serialization.XmlElement("GraphDescriptor")]
        public System.Collections.ObjectModel.Collection<GraphDescriptorType> GraphDescriptor
        {
            get
            {
                return _graphDescriptor;
            }
            private set
            {
                _graphDescriptor = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the GraphDescriptor collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool GraphDescriptorSpecified
        {
            get
            {
                return (GraphDescriptor.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestRunDescriptorTypeGraphDescriptors" /> class.</para>
        /// </summary>
        public LoadTestRunDescriptorTypeGraphDescriptors()
        {
            _graphDescriptor = new System.Collections.ObjectModel.Collection<GraphDescriptorType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestRunDescriptorViewType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum LoadTestRunDescriptorViewType
    {
        None,
        Graph,
        Summary,
        Table,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PanelLayoutType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum PanelLayoutType
    {
        One,
        TwoHorizontal,
        TwoVertical,
        ThreeLeft,
        ThreeRight,
        ThreeTop,
        ThreeBottom,
        ThreeHorizontal,
        ThreeVertical,
        FourHorizontal,
        FourVertical,
        FourGrid,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummary
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult> _performanceCounterResults;
        [System.Xml.Serialization.XmlArray("PerformanceCounterResults")]
        [System.Xml.Serialization.XmlArrayItem("PerformanceCounterResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult> PerformanceCounterResults
        {
            get
            {
                return _performanceCounterResults;
            }
            private set
            {
                _performanceCounterResults = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PerformanceCounterResults collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PerformanceCounterResultsSpecified
        {
            get
            {
                return (PerformanceCounterResults.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestResultTypeSummary" /> class.</para>
        /// </summary>
        public LoadTestResultTypeSummary()
        {
            _performanceCounterResults = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult>();
            _pageSummaries = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary>();
            _testSummaries = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary>();
            _transactionSummaries = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary> _pageSummaries;
        [System.Xml.Serialization.XmlArray("PageSummaries")]
        [System.Xml.Serialization.XmlArrayItem("PageSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary> PageSummaries
        {
            get
            {
                return _pageSummaries;
            }
            private set
            {
                _pageSummaries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PageSummaries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PageSummariesSpecified
        {
            get
            {
                return (PageSummaries.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary> _testSummaries;
        [System.Xml.Serialization.XmlArray("TestSummaries")]
        [System.Xml.Serialization.XmlArrayItem("TestSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary> TestSummaries
        {
            get
            {
                return _testSummaries;
            }
            private set
            {
                _testSummaries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestSummaries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestSummariesSpecified
        {
            get
            {
                return (TestSummaries.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary> _transactionSummaries;
        [System.Xml.Serialization.XmlArray("TransactionSummaries")]
        [System.Xml.Serialization.XmlArrayItem("TransactionSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary> TransactionSummaries
        {
            get
            {
                return _transactionSummaries;
            }
            private set
            {
                _transactionSummaries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TransactionSummaries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TransactionSummariesSpecified
        {
            get
            {
                return (TransactionSummaries.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryPerformanceCounterResults", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryPerformanceCounterResults
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult> _performanceCounterResult;
        [System.Xml.Serialization.XmlElement("PerformanceCounterResult")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult> PerformanceCounterResult
        {
            get
            {
                return _performanceCounterResult;
            }
            private set
            {
                _performanceCounterResult = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PerformanceCounterResult collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PerformanceCounterResultSpecified
        {
            get
            {
                return (PerformanceCounterResult.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestResultTypeSummaryPerformanceCounterResults" /> class.</para>
        /// </summary>
        public LoadTestResultTypeSummaryPerformanceCounterResults()
        {
            _performanceCounterResult = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryPerformanceCounterResultsPerformanceCounterResult
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("machineName")]
        public string MachineName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("categoryName")]
        public string CategoryName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("instanceName")]
        public string InstanceName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("counterName")]
        public string CounterName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public double Value { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isOverallResultCounter = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isOverallResultCounter")]
        public bool IsOverallResultCounter
        {
            get
            {
                return _isOverallResultCounter;
            }
            set
            {
                _isOverallResultCounter = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _higherIsBetter = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("higherIsBetter")]
        public bool HigherIsBetter
        {
            get
            {
                return _higherIsBetter;
            }
            set
            {
                _higherIsBetter = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryPageSummaries", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryPageSummaries
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary> _pageSummary;
        [System.Xml.Serialization.XmlElement("PageSummary")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary> PageSummary
        {
            get
            {
                return _pageSummary;
            }
            private set
            {
                _pageSummary = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the PageSummary collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PageSummarySpecified
        {
            get
            {
                return (PageSummary.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestResultTypeSummaryPageSummaries" /> class.</para>
        /// </summary>
        public LoadTestResultTypeSummaryPageSummaries()
        {
            _pageSummary = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryPageSummariesPageSummary>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryPageSummariesPageSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryPageSummariesPageSummary
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("scenarioName")]
        public string ScenarioName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testName")]
        public string TestName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("pageCount")]
        public int PageCount { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("responseTime")]
        public int ResponseTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryTestSummaries", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryTestSummaries
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary> _testSummary;
        [System.Xml.Serialization.XmlElement("TestSummary")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary> TestSummary
        {
            get
            {
                return _testSummary;
            }
            private set
            {
                _testSummary = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestSummary collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestSummarySpecified
        {
            get
            {
                return (TestSummary.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestResultTypeSummaryTestSummaries" /> class.</para>
        /// </summary>
        public LoadTestResultTypeSummaryTestSummaries()
        {
            _testSummary = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTestSummariesTestSummary>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryTestSummariesTestSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryTestSummariesTestSummary
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("scenarioName")]
        public string ScenarioName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testName")]
        public string TestName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("totalTests")]
        public int TotalTests { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testsFailed")]
        public int TestsFailed { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("averageDuration")]
        public int AverageDuration { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryTransactionSummaries", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryTransactionSummaries
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary> _transactionSummary;
        [System.Xml.Serialization.XmlElement("TransactionSummary")]
        public System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary> TransactionSummary
        {
            get
            {
                return _transactionSummary;
            }
            private set
            {
                _transactionSummary = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TransactionSummary collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TransactionSummarySpecified
        {
            get
            {
                return (TransactionSummary.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestResultTypeSummaryTransactionSummaries" /> class.</para>
        /// </summary>
        public LoadTestResultTypeSummaryTransactionSummaries()
        {
            _transactionSummary = new System.Collections.ObjectModel.Collection<LoadTestResultTypeSummaryTransactionSummariesTransactionSummary>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultTypeSummaryTransactionSummariesTransactionSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestResultTypeSummaryTransactionSummariesTransactionSummary
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("scenarioName")]
        public string ScenarioName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testName")]
        public string TestName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("transactionName")]
        public string TransactionName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("transactionCount")]
        public int TransactionCount { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("elapsedTime")]
        public string ElapsedTime { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("responseTime")]
        public string ResponseTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestRunStatusType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum LoadTestRunStatusType
    {
        Connecting,
        InitializingResultsCollection,
        NotStarted,
        Queued,
        Starting,
        Stopping,
        Stopped,
        WarmingUp,
        WritingResults,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestResultStoreType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum LoadTestResultStoreType
    {
        None,
        Database,
        XmlResultFile,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("LoadTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class LoadTestType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenarios> _scenarios;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Scenarios")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenarios> Scenarios
        {
            get
            {
                return _scenarios;
            }
            private set
            {
                _scenarios = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestType" /> class.</para>
        /// </summary>
        public LoadTestType()
        {
            _scenarios = new System.Collections.ObjectModel.Collection<LoadTestTypeScenarios>();
            _counterSets = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSets>();
            _runConfigurations = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurations>();
            _loadTestPlugins = new System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPlugins>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSets> _counterSets;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSets")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSets> CounterSets
        {
            get
            {
                return _counterSets;
            }
            private set
            {
                _counterSets = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurations> _runConfigurations;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("RunConfigurations")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurations> RunConfigurations
        {
            get
            {
                return _runConfigurations;
            }
            private set
            {
                _runConfigurations = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPlugins> _loadTestPlugins;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("LoadTestPlugins")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPlugins> LoadTestPlugins
        {
            get
            {
                return _loadTestPlugins;
            }
            private set
            {
                _loadTestPlugins = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Description")]
        public string Description { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Owner")]
        public string Owner { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("storage")]
        public string Storage { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("Priority")]
        public int PriorityValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Priority property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool PriorityValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Priority
        {
            get
            {
                if (PriorityValueSpecified)
                {
                    return PriorityValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PriorityValue = value.GetValueOrDefault();
                PriorityValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("Enabled")]
        public bool EnabledValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Enabled property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool EnabledValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? Enabled
        {
            get
            {
                if (EnabledValueSpecified)
                {
                    return EnabledValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                EnabledValue = value.GetValueOrDefault();
                EnabledValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CssProjectStructure")]
        public string CssProjectStructure { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CssIteration")]
        public string CssIteration { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("DeploymentItemsEditable")]
        public string DeploymentItemsEditable { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("WorkItemIds")]
        public string WorkItemIds { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("TraceLevel")]
        public string TraceLevel { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("CurrentRunConfig")]
        public string CurrentRunConfig { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenarios", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenarios
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenario> _scenario;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Scenario")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenario> Scenario
        {
            get
            {
                return _scenario;
            }
            private set
            {
                _scenario = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenarios" /> class.</para>
        /// </summary>
        public LoadTestTypeScenarios()
        {
            _scenario = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenario>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenario", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenario
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ThinkProfile")]
        public LoadTestTypeScenariosScenarioThinkProfile ThinkProfile { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("LoadProfile")]
        public LoadTestTypeScenariosScenarioLoadProfile LoadProfile { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile> _initializeTest;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("InitializeTest")]
        [System.Xml.Serialization.XmlArrayItem("TestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile> InitializeTest
        {
            get
            {
                return _initializeTest;
            }
            private set
            {
                _initializeTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenario" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenario()
        {
            _initializeTest = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile>();
            _terminateTest = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile>();
            _testMix = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile>();
            _browserMix = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile>();
            _networkMix = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile> _terminateTest;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("TerminateTest")]
        [System.Xml.Serialization.XmlArrayItem("TestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile> TerminateTest
        {
            get
            {
                return _terminateTest;
            }
            private set
            {
                _terminateTest = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile> _testMix;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("TestMix")]
        [System.Xml.Serialization.XmlArrayItem("TestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile> TestMix
        {
            get
            {
                return _testMix;
            }
            private set
            {
                _testMix = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile> _browserMix;
        [System.Xml.Serialization.XmlArray("BrowserMix")]
        [System.Xml.Serialization.XmlArrayItem("BrowserProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile> BrowserMix
        {
            get
            {
                return _browserMix;
            }
            private set
            {
                _browserMix = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the BrowserMix collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool BrowserMixSpecified
        {
            get
            {
                return (BrowserMix.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile> _networkMix;
        [System.Xml.Serialization.XmlArray("NetworkMix")]
        [System.Xml.Serialization.XmlArrayItem("NetworkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile> NetworkMix
        {
            get
            {
                return _networkMix;
            }
            private set
            {
                _networkMix = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the NetworkMix collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool NetworkMixSpecified
        {
            get
            {
                return (NetworkMix.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("AllowedAgents")]
        public string AllowedAgents { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("IPSwitching")]
        public bool IPSwitchingValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IPSwitching property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IPSwitchingValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? IPSwitching
        {
            get
            {
                if (IPSwitchingValueSpecified)
                {
                    return IPSwitchingValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IPSwitchingValue = value.GetValueOrDefault();
                IPSwitchingValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("DisableDuringWarmup")]
        public bool DisableDuringWarmupValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the DisableDuringWarmup property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool DisableDuringWarmupValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? DisableDuringWarmup
        {
            get
            {
                if (DisableDuringWarmupValueSpecified)
                {
                    return DisableDuringWarmupValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DisableDuringWarmupValue = value.GetValueOrDefault();
                DisableDuringWarmupValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("DelayStartTime")]
        public int DelayStartTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the DelayStartTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool DelayStartTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? DelayStartTime
        {
            get
            {
                if (DelayStartTimeValueSpecified)
                {
                    return DelayStartTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DelayStartTimeValue = value.GetValueOrDefault();
                DelayStartTimeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("DelayBetweenIterations")]
        public int DelayBetweenIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the DelayBetweenIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool DelayBetweenIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? DelayBetweenIterations
        {
            get
            {
                if (DelayBetweenIterationsValueSpecified)
                {
                    return DelayBetweenIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DelayBetweenIterationsValue = value.GetValueOrDefault();
                DelayBetweenIterationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxTestIterations")]
        public int MaxTestIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxTestIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxTestIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxTestIterations
        {
            get
            {
                if (MaxTestIterationsValueSpecified)
                {
                    return MaxTestIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxTestIterationsValue = value.GetValueOrDefault();
                MaxTestIterationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("PercentNewUsers")]
        public int PercentNewUsersValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the PercentNewUsers property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool PercentNewUsersValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? PercentNewUsers
        {
            get
            {
                if (PercentNewUsersValueSpecified)
                {
                    return PercentNewUsersValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PercentNewUsersValue = value.GetValueOrDefault();
                PercentNewUsersValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("TestMixType")]
        public TestMixType TestMixTypeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the TestMixType property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TestMixTypeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public TestMixType? TestMixType
        {
            get
            {
                if (TestMixTypeValueSpecified)
                {
                    return TestMixTypeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TestMixTypeValue = value.GetValueOrDefault();
                TestMixTypeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("ApplyDistributionToPacingDelay")]
        public bool ApplyDistributionToPacingDelayValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ApplyDistributionToPacingDelay property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ApplyDistributionToPacingDelayValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? ApplyDistributionToPacingDelay
        {
            get
            {
                if (ApplyDistributionToPacingDelayValueSpecified)
                {
                    return ApplyDistributionToPacingDelayValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ApplyDistributionToPacingDelayValue = value.GetValueOrDefault();
                ApplyDistributionToPacingDelayValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioThinkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioThinkProfile
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Pattern")]
        public string Pattern { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Value")]
        public float Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioLoadProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioLoadProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Pattern")]
        public string Pattern { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("InitialUsers")]
        public int InitialUsers { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxUsers")]
        public int MaxUsersValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxUsers property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxUsersValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxUsers
        {
            get
            {
                if (MaxUsersValueSpecified)
                {
                    return MaxUsersValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxUsersValue = value.GetValueOrDefault();
                MaxUsersValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("StepUsers")]
        public int StepUsersValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the StepUsers property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool StepUsersValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? StepUsers
        {
            get
            {
                if (StepUsersValueSpecified)
                {
                    return StepUsersValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                StepUsersValue = value.GetValueOrDefault();
                StepUsersValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("StepDuration")]
        public int StepDurationValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the StepDuration property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool StepDurationValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? StepDuration
        {
            get
            {
                if (StepDurationValueSpecified)
                {
                    return StepDurationValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                StepDurationValue = value.GetValueOrDefault();
                StepDurationValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("StepRampTime")]
        public int StepRampTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the StepRampTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool StepRampTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? StepRampTime
        {
            get
            {
                if (StepRampTimeValueSpecified)
                {
                    return StepRampTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                StepRampTimeValue = value.GetValueOrDefault();
                StepRampTimeValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CounterPath")]
        public string CounterPath { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("MachineName")]
        public string MachineName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CategoryName")]
        public string CategoryName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CounterName")]
        public string CounterName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("InstanceName")]
        public string InstanceName { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MinUserCount")]
        public int MinUserCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MinUserCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MinUserCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MinUserCount
        {
            get
            {
                if (MinUserCountValueSpecified)
                {
                    return MinUserCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MinUserCountValue = value.GetValueOrDefault();
                MinUserCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxUserCount")]
        public int MaxUserCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxUserCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxUserCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxUserCount
        {
            get
            {
                if (MaxUserCountValueSpecified)
                {
                    return MaxUserCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxUserCountValue = value.GetValueOrDefault();
                MaxUserCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxUserCountIncrease")]
        public int MaxUserCountIncreaseValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxUserCountIncrease property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxUserCountIncreaseValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxUserCountIncrease
        {
            get
            {
                if (MaxUserCountIncreaseValueSpecified)
                {
                    return MaxUserCountIncreaseValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxUserCountIncreaseValue = value.GetValueOrDefault();
                MaxUserCountIncreaseValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxUserCountDecrease")]
        public int MaxUserCountDecreaseValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxUserCountDecrease property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxUserCountDecreaseValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxUserCountDecrease
        {
            get
            {
                if (MaxUserCountDecreaseValueSpecified)
                {
                    return MaxUserCountDecreaseValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxUserCountDecreaseValue = value.GetValueOrDefault();
                MaxUserCountDecreaseValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MinTargetValue")]
        public double MinTargetValueValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MinTargetValue property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MinTargetValueValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public double? MinTargetValue
        {
            get
            {
                if (MinTargetValueValueSpecified)
                {
                    return MinTargetValueValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MinTargetValueValue = value.GetValueOrDefault();
                MinTargetValueValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxTargetValue")]
        public double MaxTargetValueValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxTargetValue property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxTargetValueValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public double? MaxTargetValue
        {
            get
            {
                if (MaxTargetValueValueSpecified)
                {
                    return MaxTargetValueValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxTargetValueValue = value.GetValueOrDefault();
                MaxTargetValueValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("HigherValuesBetter")]
        public bool HigherValuesBetterValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the HigherValuesBetter property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool HigherValuesBetterValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? HigherValuesBetter
        {
            get
            {
                if (HigherValuesBetterValueSpecified)
                {
                    return HigherValuesBetterValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HigherValuesBetterValue = value.GetValueOrDefault();
                HigherValuesBetterValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("StopAdjustingAtGoal")]
        public bool StopAdjustingAtGoalValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the StopAdjustingAtGoal property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool StopAdjustingAtGoalValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? StopAdjustingAtGoal
        {
            get
            {
                if (StopAdjustingAtGoalValueSpecified)
                {
                    return StopAdjustingAtGoalValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                StopAdjustingAtGoalValue = value.GetValueOrDefault();
                StopAdjustingAtGoalValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioInitializeTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioInitializeTest
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile> _testProfile;
        [System.Xml.Serialization.XmlElement("TestProfile")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile> TestProfile
        {
            get
            {
                return _testProfile;
            }
            private set
            {
                _testProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestProfileSpecified
        {
            get
            {
                return (TestProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioInitializeTest" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioInitializeTest()
        {
            _testProfile = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioInitializeTestTestProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioInitializeTestTestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioInitializeTestTestProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentage")]
        public float Percentage { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Type")]
        public string Type { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioTerminateTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioTerminateTest
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile> _testProfile;
        [System.Xml.Serialization.XmlElement("TestProfile")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile> TestProfile
        {
            get
            {
                return _testProfile;
            }
            private set
            {
                _testProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestProfileSpecified
        {
            get
            {
                return (TestProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioTerminateTest" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioTerminateTest()
        {
            _testProfile = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTerminateTestTestProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioTerminateTestTestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioTerminateTestTestProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentage")]
        public float Percentage { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Type")]
        public string Type { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioTestMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioTestMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile> _testProfile;
        [System.Xml.Serialization.XmlElement("TestProfile")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile> TestProfile
        {
            get
            {
                return _testProfile;
            }
            private set
            {
                _testProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestProfileSpecified
        {
            get
            {
                return (TestProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioTestMix" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioTestMix()
        {
            _testProfile = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioTestMixTestProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioTestMixTestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioTestMixTestProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentage")]
        public float Percentage { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Type")]
        public string Type { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioBrowserMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioBrowserMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile> _browserProfile;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("BrowserProfile")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile> BrowserProfile
        {
            get
            {
                return _browserProfile;
            }
            private set
            {
                _browserProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioBrowserMix" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioBrowserMix()
        {
            _browserProfile = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioBrowserMixBrowserProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioBrowserMixBrowserProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Browser")]
        public LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowser Browser { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentage")]
        public float Percentage { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowser", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowser
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader> _headers;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("Headers")]
        [System.Xml.Serialization.XmlArrayItem("Header", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader> Headers
        {
            get
            {
                return _headers;
            }
            private set
            {
                _headers = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowser" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowser()
        {
            _headers = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxConnections")]
        public int MaxConnectionsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxConnections property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxConnectionsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxConnections
        {
            get
            {
                if (MaxConnectionsValueSpecified)
                {
                    return MaxConnectionsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxConnectionsValue = value.GetValueOrDefault();
                MaxConnectionsValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeaders", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeaders
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader> _header;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Header")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader> Header
        {
            get
            {
                return _header;
            }
            private set
            {
                _header = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeaders" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeaders()
        {
            _header = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioBrowserMixBrowserProfileBrowserHeadersHeader
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioNetworkMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioNetworkMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile> _networkProfile;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("NetworkProfile")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile> NetworkProfile
        {
            get
            {
                return _networkProfile;
            }
            private set
            {
                _networkProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeScenariosScenarioNetworkMix" /> class.</para>
        /// </summary>
        public LoadTestTypeScenariosScenarioNetworkMix()
        {
            _networkProfile = new System.Collections.ObjectModel.Collection<LoadTestTypeScenariosScenarioNetworkMixNetworkProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeScenariosScenarioNetworkMixNetworkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeScenariosScenarioNetworkMixNetworkProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Network")]
        public NetworkType Network { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentage")]
        public float Percentage { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestMixType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum TestMixType
    {
        Sequential,
        PercentageOfTestsStarted,
        PercentageOfUsersRunning,
        UserPacing,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSets", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSets
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSet> _counterSet;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSet")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSet> CounterSet
        {
            get
            {
                return _counterSet;
            }
            private set
            {
                _counterSet = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSets" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSets()
        {
            _counterSet = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSet>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSet", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSet
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory> _counterCategories;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("CounterCategories")]
        [System.Xml.Serialization.XmlArrayItem("CounterCategory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory> CounterCategories
        {
            get
            {
                return _counterCategories;
            }
            private set
            {
                _counterCategories = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSet" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSet()
        {
            _counterCategories = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory>();
            _defaultCountersForAutomaticGraphs = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter> _defaultCountersForAutomaticGraphs;
        [System.Xml.Serialization.XmlArray("DefaultCountersForAutomaticGraphs")]
        [System.Xml.Serialization.XmlArrayItem("DefaultCounter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter> DefaultCountersForAutomaticGraphs
        {
            get
            {
                return _defaultCountersForAutomaticGraphs;
            }
            private set
            {
                _defaultCountersForAutomaticGraphs = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DefaultCountersForAutomaticGraphs collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DefaultCountersForAutomaticGraphsSpecified
        {
            get
            {
                return (DefaultCountersForAutomaticGraphs.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("CounterSetType")]
        public string CounterSetType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("LocId")]
        public string LocId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategories", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategories
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory> _counterCategory;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterCategory")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory> CounterCategory
        {
            get
            {
                return _counterCategory;
            }
            private set
            {
                _counterCategory = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategories" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategories()
        {
            _counterCategory = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter> _counters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("Counters")]
        [System.Xml.Serialization.XmlArrayItem("Counter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter> Counters
        {
            get
            {
                return _counters;
            }
            private set
            {
                _counters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategory()
        {
            _counters = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter>();
            _instances = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance> _instances;
        [System.Xml.Serialization.XmlArray("Instances")]
        [System.Xml.Serialization.XmlArrayItem("Instance", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance> Instances
        {
            get
            {
                return _instances;
            }
            private set
            {
                _instances = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Instances collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool InstancesSpecified
        {
            get
            {
                return (Instances.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCounters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCounters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter> _counter;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Counter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter> Counter
        {
            get
            {
                return _counter;
            }
            private set
            {
                _counter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCounters" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCounters()
        {
            _counter = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule> _thresholdRules;
        [System.Xml.Serialization.XmlArray("ThresholdRules")]
        [System.Xml.Serialization.XmlArrayItem("ThresholdRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule> ThresholdRules
        {
            get
            {
                return _thresholdRules;
            }
            private set
            {
                _thresholdRules = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ThresholdRules collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ThresholdRulesSpecified
        {
            get
            {
                return (ThresholdRules.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounter()
        {
            _thresholdRules = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("Range")]
        public int RangeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Range property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RangeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Range
        {
            get
            {
                if (RangeValueSpecified)
                {
                    return RangeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RangeValue = value.GetValueOrDefault();
                RangeValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("RangeGroup")]
        public string RangeGroup { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _higherIsBetter = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("HigherIsBetter")]
        public bool HigherIsBetter
        {
            get
            {
                return _higherIsBetter;
            }
            set
            {
                _higherIsBetter = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterT" +
        "hresholdRules", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRules
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule> _thresholdRule;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ThresholdRule")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule> ThresholdRule
        {
            get
            {
                return _thresholdRule;
            }
            private set
            {
                _thresholdRule = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRules" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRules()
        {
            _thresholdRule = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterT" +
        "hresholdRulesThresholdRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter> _ruleParameters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("RuleParameters")]
        [System.Xml.Serialization.XmlArrayItem("RuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter> RuleParameters
        {
            get
            {
                return _ruleParameters;
            }
            private set
            {
                _ruleParameters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRule()
        {
            _ruleParameters = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Classname")]
        public string Classname { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterT" +
        "hresholdRulesThresholdRuleRuleParameters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParameters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter> _ruleParameter;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("RuleParameter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter> RuleParameter
        {
            get
            {
                return _ruleParameter;
            }
            private set
            {
                _ruleParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParameters" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParameters()
        {
            _ruleParameter = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterT" +
        "hresholdRulesThresholdRuleRuleParametersRuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryCountersCounterThresholdRulesThresholdRuleRuleParametersRuleParameter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstances", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstances
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance> _instance;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Instance")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance> Instance
        {
            get
            {
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstances" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstances()
        {
            _instance = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstanc" +
        "e", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetCounterCategoriesCounterCategoryInstancesInstance
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphs", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphs
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter> _defaultCounter;
        [System.Xml.Serialization.XmlElement("DefaultCounter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter> DefaultCounter
        {
            get
            {
                return _defaultCounter;
            }
            private set
            {
                _defaultCounter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DefaultCounter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DefaultCounterSpecified
        {
            get
            {
                return (DefaultCounter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphs" /> class.</para>
        /// </summary>
        public LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphs()
        {
            _defaultCounter = new System.Collections.ObjectModel.Collection<LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeCounterSetsCounterSetDefaultCountersForAutomaticGraphsDefaultCounter
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CategoryName")]
        public string CategoryName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("CounterName")]
        public string CounterName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("InstanceName")]
        public string InstanceName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("GraphName")]
        public string GraphName { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("Range")]
        public int RangeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Range property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RangeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Range
        {
            get
            {
                if (RangeValueSpecified)
                {
                    return RangeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RangeValue = value.GetValueOrDefault();
                RangeValueSpecified = value.HasValue;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("RunType")]
        public string RunType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurations", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurations
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfiguration> _runConfiguration;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("RunConfiguration")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfiguration> RunConfiguration
        {
            get
            {
                return _runConfiguration;
            }
            private set
            {
                _runConfiguration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurations" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurations()
        {
            _runConfiguration = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfiguration>();
        }
    }
    /// <summary>
    /// <para>TODO: leave up to NC: this type is a duplicate of LoadTestRunCOnfigurationType. The differentces are results of WebTestSuiteSerializer (upper case for attributes and enums are strings vs ints)</para>
    /// </summary>
    [System.ComponentModel.Description("TODO: leave up to NC: this type is a duplicate of LoadTestRunCOnfigurationType. T" +
        "he differentces are results of WebTestSuiteSerializer (upper case for attributes" +
        " and enums are strings vs ints)")]
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfiguration
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSetMappings")]
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappings CounterSetMappings { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent> _applications;
        [System.Xml.Serialization.XmlArray("Applications")]
        [System.Xml.Serialization.XmlArrayItem("AutComponent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent> Applications
        {
            get
            {
                return _applications;
            }
            private set
            {
                _applications = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Applications collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ApplicationsSpecified
        {
            get
            {
                return (Applications.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfiguration" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfiguration()
        {
            _applications = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent>();
            _loadGeneratorLocations = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation>();
            _contextParameters = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation> _loadGeneratorLocations;
        [System.Xml.Serialization.XmlArray("LoadGeneratorLocations")]
        [System.Xml.Serialization.XmlArrayItem("GeoLocation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation> LoadGeneratorLocations
        {
            get
            {
                return _loadGeneratorLocations;
            }
            private set
            {
                _loadGeneratorLocations = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the LoadGeneratorLocations collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool LoadGeneratorLocationsSpecified
        {
            get
            {
                return (LoadGeneratorLocations.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter> _contextParameters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("ContextParameters")]
        [System.Xml.Serialization.XmlArrayItem("ContextParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter> ContextParameters
        {
            get
            {
                return _contextParameters;
            }
            private set
            {
                _contextParameters = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("ResultsStoreType")]
        public string ResultsStoreType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("TimingDetailsStorage")]
        public string TimingDetailsStorage { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("MaxErrorDetails")]
        public int MaxErrorDetails { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("MaxRequestUrlsReported")]
        public int MaxRequestUrlsReported { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxErrorsPerType")]
        public int MaxErrorsPerTypeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxErrorsPerType property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxErrorsPerTypeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxErrorsPerType
        {
            get
            {
                if (MaxErrorsPerTypeValueSpecified)
                {
                    return MaxErrorsPerTypeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxErrorsPerTypeValue = value.GetValueOrDefault();
                MaxErrorsPerTypeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("MaxThresholdViolations")]
        public int MaxThresholdViolationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the MaxThresholdViolations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool MaxThresholdViolationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? MaxThresholdViolations
        {
            get
            {
                if (MaxThresholdViolationsValueSpecified)
                {
                    return MaxThresholdViolationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                MaxThresholdViolationsValue = value.GetValueOrDefault();
                MaxThresholdViolationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("UseTestIterations")]
        public bool UseTestIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the UseTestIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool UseTestIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? UseTestIterations
        {
            get
            {
                if (UseTestIterationsValueSpecified)
                {
                    return UseTestIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                UseTestIterationsValue = value.GetValueOrDefault();
                UseTestIterationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("RunDuration")]
        public int RunDuration { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("WarmupTime")]
        public int WarmupTime { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("CoolDownTime")]
        public int CoolDownTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the CoolDownTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CoolDownTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? CoolDownTime
        {
            get
            {
                if (CoolDownTimeValueSpecified)
                {
                    return CoolDownTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                CoolDownTimeValue = value.GetValueOrDefault();
                CoolDownTimeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("TestIterations")]
        public int TestIterationsValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the TestIterations property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TestIterationsValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? TestIterations
        {
            get
            {
                if (TestIterationsValueSpecified)
                {
                    return TestIterationsValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TestIterationsValue = value.GetValueOrDefault();
                TestIterationsValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("WebTestConnectionModel")]
        public WebTestConnectionModel WebTestConnectionModel { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("WebTestConnectionPoolSize")]
        public int WebTestConnectionPoolSize { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("SampleRate")]
        public int SampleRate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("ValidationLevel")]
        public LoadTestValidationLevel ValidationLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("SqlTracingConnectString")]
        public string SqlTracingConnectString { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("SqlTracingConnectStringDisplayValue")]
        public string SqlTracingConnectStringDisplayValue { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("SqlTracingDirectory")]
        public string SqlTracingDirectory { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SqlTracingEnabled")]
        public bool SqlTracingEnabledValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingEnabled property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingEnabledValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SqlTracingEnabled
        {
            get
            {
                if (SqlTracingEnabledValueSpecified)
                {
                    return SqlTracingEnabledValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingEnabledValue = value.GetValueOrDefault();
                SqlTracingEnabledValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SqlTracingFileCount")]
        public int SqlTracingFileCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingFileCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingFileCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SqlTracingFileCount
        {
            get
            {
                if (SqlTracingFileCountValueSpecified)
                {
                    return SqlTracingFileCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingFileCountValue = value.GetValueOrDefault();
                SqlTracingFileCountValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SqlTracingRolloverEnabled")]
        public bool SqlTracingRolloverEnabledValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingRolloverEnabled property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingRolloverEnabledValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SqlTracingRolloverEnabled
        {
            get
            {
                if (SqlTracingRolloverEnabledValueSpecified)
                {
                    return SqlTracingRolloverEnabledValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingRolloverEnabledValue = value.GetValueOrDefault();
                SqlTracingRolloverEnabledValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SqlTracingMinimumDuration")]
        public int SqlTracingMinimumDurationValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SqlTracingMinimumDuration property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SqlTracingMinimumDurationValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SqlTracingMinimumDuration
        {
            get
            {
                if (SqlTracingMinimumDurationValueSpecified)
                {
                    return SqlTracingMinimumDurationValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SqlTracingMinimumDurationValue = value.GetValueOrDefault();
                SqlTracingMinimumDurationValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("RunUnitTestsInAppDomain")]
        public bool RunUnitTestsInAppDomainValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the RunUnitTestsInAppDomain property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RunUnitTestsInAppDomainValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? RunUnitTestsInAppDomain
        {
            get
            {
                if (RunUnitTestsInAppDomainValueSpecified)
                {
                    return RunUnitTestsInAppDomainValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RunUnitTestsInAppDomainValue = value.GetValueOrDefault();
                RunUnitTestsInAppDomainValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SaveTestLogsOnError")]
        public bool SaveTestLogsOnErrorValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SaveTestLogsOnError property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SaveTestLogsOnErrorValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? SaveTestLogsOnError
        {
            get
            {
                if (SaveTestLogsOnErrorValueSpecified)
                {
                    return SaveTestLogsOnErrorValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SaveTestLogsOnErrorValue = value.GetValueOrDefault();
                SaveTestLogsOnErrorValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("SaveTestLogsFrequency")]
        public int SaveTestLogsFrequencyValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the SaveTestLogsFrequency property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool SaveTestLogsFrequencyValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? SaveTestLogsFrequency
        {
            get
            {
                if (SaveTestLogsFrequencyValueSpecified)
                {
                    return SaveTestLogsFrequencyValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                SaveTestLogsFrequencyValue = value.GetValueOrDefault();
                SaveTestLogsFrequencyValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("CoreCount")]
        public int CoreCountValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the CoreCount property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CoreCountValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? CoreCount
        {
            get
            {
                if (CoreCountValueSpecified)
                {
                    return CoreCountValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                CoreCountValue = value.GetValueOrDefault();
                CoreCountValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useMultipleIPs = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("UseMultipleIPs")]
        public bool UseMultipleIPs
        {
            get
            {
                return _useMultipleIPs;
            }
            set
            {
                _useMultipleIPs = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private LoadTestAgentConfiguration _testAgentConfiguration = VSTest.LoadTestAgentConfiguration.Default;
        [System.ComponentModel.DefaultValue(VSTest.LoadTestAgentConfiguration.Default)]
        [System.Xml.Serialization.XmlAttribute("TestAgentConfiguration")]
        public LoadTestAgentConfiguration TestAgentConfiguration
        {
            get
            {
                return _testAgentConfiguration;
            }
            set
            {
                _testAgentConfiguration = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private AgentDiagnosticsTraceLevel _agentDiagnosticsLevel = VSTest.AgentDiagnosticsTraceLevel.Warning;
        [System.ComponentModel.DefaultValue(VSTest.AgentDiagnosticsTraceLevel.Warning)]
        [System.Xml.Serialization.XmlAttribute("AgentDiagnosticsLevel")]
        public AgentDiagnosticsTraceLevel AgentDiagnosticsLevel
        {
            get
            {
                return _agentDiagnosticsLevel;
            }
            set
            {
                _agentDiagnosticsLevel = value;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("ResourcesRetentionTimeInMinutes")]
        public int ResourcesRetentionTimeInMinutesValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ResourcesRetentionTimeInMinutes property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ResourcesRetentionTimeInMinutesValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? ResourcesRetentionTimeInMinutes
        {
            get
            {
                if (ResourcesRetentionTimeInMinutesValueSpecified)
                {
                    return ResourcesRetentionTimeInMinutesValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ResourcesRetentionTimeInMinutesValue = value.GetValueOrDefault();
                ResourcesRetentionTimeInMinutesValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappings", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappings
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping> _counterSetMapping;
        [System.Xml.Serialization.XmlElement("CounterSetMapping")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping> CounterSetMapping
        {
            get
            {
                return _counterSetMapping;
            }
            private set
            {
                _counterSetMapping = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CounterSetMapping collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CounterSetMappingSpecified
        {
            get
            {
                return (CounterSetMapping.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappings" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappings()
        {
            _counterSetMapping = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping>();
            _applicationsUnderTestSettings = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings> _applicationsUnderTestSettings;
        [System.Xml.Serialization.XmlElement("ApplicationsUnderTestSettings")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings> ApplicationsUnderTestSettings
        {
            get
            {
                return _applicationsUnderTestSettings;
            }
            private set
            {
                _applicationsUnderTestSettings = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ApplicationsUnderTestSettings collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ApplicationsUnderTestSettingsSpecified
        {
            get
            {
                return (ApplicationsUnderTestSettings.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference> _counterSetReferences;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("CounterSetReferences")]
        [System.Xml.Serialization.XmlArrayItem("CounterSetReference", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference> CounterSetReferences
        {
            get
            {
                return _counterSetReferences;
            }
            private set
            {
                _counterSetReferences = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMapping()
        {
            _counterSetReferences = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("ComputerName")]
        public string ComputerName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingC" +
        "ounterSetReferences", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferences
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference> _counterSetReference;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("CounterSetReference")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference> CounterSetReference
        {
            get
            {
                return _counterSetReference;
            }
            private set
            {
                _counterSetReference = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferences" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferences()
        {
            _counterSetReference = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingC" +
        "ounterSetReferencesCounterSetReference", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsCounterSetMappingCounterSetReferencesCounterSetReference
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("CounterSetName")]
        public string CounterSetName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderT" +
        "estSettings", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup> _applicationUnderTestGroup;
        [System.Xml.Serialization.XmlElement("ApplicationUnderTestGroup")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup> ApplicationUnderTestGroup
        {
            get
            {
                return _applicationUnderTestGroup;
            }
            private set
            {
                _applicationUnderTestGroup = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ApplicationUnderTestGroup collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ApplicationUnderTestGroupSpecified
        {
            get
            {
                return (ApplicationUnderTestGroup.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettings()
        {
            _applicationUnderTestGroup = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderT" +
        "estSettingsApplicationUnderTestGroup", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest> _applicationsUnderTest;
        [System.Xml.Serialization.XmlArray("ApplicationsUnderTest")]
        [System.Xml.Serialization.XmlArrayItem("ApplicationUnderTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest> ApplicationsUnderTest
        {
            get
            {
                return _applicationsUnderTest;
            }
            private set
            {
                _applicationsUnderTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ApplicationsUnderTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ApplicationsUnderTestSpecified
        {
            get
            {
                return (ApplicationsUnderTest.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroup()
        {
            _applicationsUnderTest = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Type")]
        public string Type { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderT" +
        "estSettingsApplicationUnderTestGroupApplicationsUnderTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTest
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest> _applicationUnderTest;
        [System.Xml.Serialization.XmlElement("ApplicationUnderTest")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest> ApplicationUnderTest
        {
            get
            {
                return _applicationUnderTest;
            }
            private set
            {
                _applicationUnderTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ApplicationUnderTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ApplicationUnderTestSpecified
        {
            get
            {
                return (ApplicationUnderTest.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTest" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTest()
        {
            _applicationUnderTest = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderT" +
        "estSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _properties;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("Properties")]
        [System.Xml.Serialization.XmlArrayItem("Property", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> Properties
        {
            get
            {
                return _properties;
            }
            private set
            {
                _properties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationCounterSetMappingsApplicationsUnderTestSettingsApplicationUnderTestGroupApplicationsUnderTestApplicationUnderTest()
        {
            _properties = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationApplications", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationApplications
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent> _autComponent;
        [System.Xml.Serialization.XmlElement("AutComponent")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent> AutComponent
        {
            get
            {
                return _autComponent;
            }
            private set
            {
                _autComponent = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AutComponent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AutComponentSpecified
        {
            get
            {
                return (AutComponent.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationApplications" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationApplications()
        {
            _autComponent = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter> _autCounters;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("AutCounters")]
        [System.Xml.Serialization.XmlArrayItem("AutCounter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter> AutCounters
        {
            get
            {
                return _autCounters;
            }
            private set
            {
                _autCounters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponent()
        {
            _autCounters = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Type")]
        public string Type { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Separator")]
        public string Separator { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Version")]
        public string Version { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCounters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCounters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter> _autCounter;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("AutCounter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter> AutCounter
        {
            get
            {
                return _autCounter;
            }
            private set
            {
                _autCounter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCounters" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCounters()
        {
            _autCounter = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersA" +
        "utCounter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationApplicationsAutComponentAutCountersAutCounter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocations", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocations
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation> _geoLocation;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("GeoLocation")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation> GeoLocation
        {
            get
            {
                return _geoLocation;
            }
            private set
            {
                _geoLocation = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocations" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocations()
        {
            _geoLocation = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationLoadGeneratorLocationsGeoLocation
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Location")]
        public string Location { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Percentange")]
        public int Percentange { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationContextParameters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationContextParameters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter> _contextParameter;
        [System.Xml.Serialization.XmlElement("ContextParameter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter> ContextParameter
        {
            get
            {
                return _contextParameter;
            }
            private set
            {
                _contextParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ContextParameter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ContextParameterSpecified
        {
            get
            {
                return (ContextParameter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeRunConfigurationsRunConfigurationContextParameters" /> class.</para>
        /// </summary>
        public LoadTestTypeRunConfigurationsRunConfigurationContextParameters()
        {
            _contextParameter = new System.Collections.ObjectModel.Collection<LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeRunConfigurationsRunConfigurationContextParametersContextParameter
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestConnectionModel", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum WebTestConnectionModel
    {
        ConnectionPerUser,
        ConnectionPool,
        ConnectionPerTestIteration,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestValidationLevel", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum LoadTestValidationLevel
    {
        Low,
        Medium,
        High,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestAgentConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum LoadTestAgentConfiguration
    {
        Default,
        [System.Xml.Serialization.XmlEnum("Trusted IP")]
        Trusted_IP,
        [System.Xml.Serialization.XmlEnum("Private Cloud")]
        Private_Cloud,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AgentDiagnosticsTraceLevel", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum AgentDiagnosticsTraceLevel
    {
        None,
        Error,
        Warning,
        Information,
        Verbose,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeLoadTestPlugins", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeLoadTestPlugins
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPlugin> _loadTestPlugin;
        [System.Xml.Serialization.XmlElement("LoadTestPlugin")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPlugin> LoadTestPlugin
        {
            get
            {
                return _loadTestPlugin;
            }
            private set
            {
                _loadTestPlugin = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the LoadTestPlugin collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool LoadTestPluginSpecified
        {
            get
            {
                return (LoadTestPlugin.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeLoadTestPlugins" /> class.</para>
        /// </summary>
        public LoadTestTypeLoadTestPlugins()
        {
            _loadTestPlugin = new System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPlugin>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeLoadTestPluginsLoadTestPlugin", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeLoadTestPluginsLoadTestPlugin
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter> _ruleParameters;
        [System.Xml.Serialization.XmlArray("RuleParameters")]
        [System.Xml.Serialization.XmlArrayItem("RuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter> RuleParameters
        {
            get
            {
                return _ruleParameters;
            }
            private set
            {
                _ruleParameters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuleParameters collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RuleParametersSpecified
        {
            get
            {
                return (RuleParameters.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeLoadTestPluginsLoadTestPlugin" /> class.</para>
        /// </summary>
        public LoadTestTypeLoadTestPluginsLoadTestPlugin()
        {
            _ruleParameters = new System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter>();
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Classname")]
        public string Classname { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Description")]
        public string Description { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string[] Text { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeLoadTestPluginsLoadTestPluginRuleParameters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeLoadTestPluginsLoadTestPluginRuleParameters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter> _ruleParameter;
        [System.Xml.Serialization.XmlElement("RuleParameter")]
        public System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter> RuleParameter
        {
            get
            {
                return _ruleParameter;
            }
            private set
            {
                _ruleParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RuleParameter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RuleParameterSpecified
        {
            get
            {
                return (RuleParameter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LoadTestTypeLoadTestPluginsLoadTestPluginRuleParameters" /> class.</para>
        /// </summary>
        public LoadTestTypeLoadTestPluginsLoadTestPluginRuleParameters()
        {
            _ruleParameter = new System.Collections.ObjectModel.Collection<LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LoadTestTypeLoadTestPluginsLoadTestPluginRuleParametersRuleParameter
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("OrderedTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("OrderedTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class OrderedTestType : BaseTestType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LinkType> _testLinks;
        [System.Xml.Serialization.XmlArray("TestLinks")]
        [System.Xml.Serialization.XmlArrayItem("TestLink", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LinkType> TestLinks
        {
            get
            {
                return _testLinks;
            }
            private set
            {
                _testLinks = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestLinks collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestLinksSpecified
        {
            get
            {
                return (TestLinks.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="OrderedTestType" /> class.</para>
        /// </summary>
        public OrderedTestType()
        {
            _testLinks = new System.Collections.ObjectModel.Collection<LinkType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _continueAfterFailure = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("continueAfterFailure")]
        public bool ContinueAfterFailure
        {
            get
            {
                return _continueAfterFailure;
            }
            set
            {
                _continueAfterFailure = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestLinksType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestLinksType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LinkType> _testLink;
        [System.Xml.Serialization.XmlElement("TestLink")]
        public System.Collections.ObjectModel.Collection<LinkType> TestLink
        {
            get
            {
                return _testLink;
            }
            private set
            {
                _testLink = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestLink collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestLinkSpecified
        {
            get
            {
                return (TestLink.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestLinksType" /> class.</para>
        /// </summary>
        public TestLinksType()
        {
            _testLink = new System.Collections.ObjectModel.Collection<LinkType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunOutputType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunOutputType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StdOut")]
        public object StdOut { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StdErr")]
        public object StdErr { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DebugTrace")]
        public object DebugTrace { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TraceInfo")]
        public object TraceInfo { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PlainTextManualTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("ManualTest", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class PlainTextManualTestType : BaseTestType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("BodyText")]
        public PlainTextManualTestTypeBodyText BodyText { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PlainTextManualTestTypeBodyText", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class PlainTextManualTestTypeBodyText
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="PlainTextManualTestTypeBodyText" /> class.</para>
        /// </summary>
        public PlainTextManualTestTypeBodyText()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlText()]
        public string[] Text { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("LoadProfile")]
        public ScenarioTypeLoadProfile LoadProfile { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ThinkProfile")]
        public ScenarioTypeThinkProfile ThinkProfile { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile> _testMix;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("TestMix")]
        [System.Xml.Serialization.XmlArrayItem("TestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile> TestMix
        {
            get
            {
                return _testMix;
            }
            private set
            {
                _testMix = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ScenarioType" /> class.</para>
        /// </summary>
        public ScenarioType()
        {
            _testMix = new System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile>();
            _browserMix = new System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile>();
            _networkMix = new System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile> _browserMix;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("BrowserMix")]
        [System.Xml.Serialization.XmlArrayItem("BrowserProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile> BrowserMix
        {
            get
            {
                return _browserMix;
            }
            private set
            {
                _browserMix = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile> _networkMix;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("NetworkMix")]
        [System.Xml.Serialization.XmlArrayItem("NetworkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile> NetworkMix
        {
            get
            {
                return _networkMix;
            }
            private set
            {
                _networkMix = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("testMixType")]
        public string TestMixType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private string _allowedAgents = "";
        [System.ComponentModel.DefaultValue("")]
        [System.Xml.Serialization.XmlAttribute("allowedAgents")]
        public string AllowedAgents
        {
            get
            {
                return _allowedAgents;
            }
            set
            {
                _allowedAgents = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _ipSwitching = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("ipSwitching")]
        public bool IpSwitching
        {
            get
            {
                return _ipSwitching;
            }
            set
            {
                _ipSwitching = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _disableDuringWarmup = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("disableDuringWarmup")]
        public bool DisableDuringWarmup
        {
            get
            {
                return _disableDuringWarmup;
            }
            set
            {
                _disableDuringWarmup = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _delayBetweenIterations = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("delayBetweenIterations")]
        public int DelayBetweenIterations
        {
            get
            {
                return _delayBetweenIterations;
            }
            set
            {
                _delayBetweenIterations = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _maxTestIterations = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("maxTestIterations")]
        public int MaxTestIterations
        {
            get
            {
                return _maxTestIterations;
            }
            set
            {
                _maxTestIterations = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _delayStartTime = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("delayStartTime")]
        public int DelayStartTime
        {
            get
            {
                return _delayStartTime;
            }
            set
            {
                _delayStartTime = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _percentNewUsers = 100;
        [System.ComponentModel.DefaultValue(100)]
        [System.Xml.Serialization.XmlAttribute("percentNewUsers")]
        public int PercentNewUsers
        {
            get
            {
                return _percentNewUsers;
            }
            set
            {
                _percentNewUsers = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeLoadProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeLoadProfile
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _pattern = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("pattern")]
        public int Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                _pattern = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("initialUsers")]
        public int InitialUsers { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeThinkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeThinkProfile
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _pattern = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("pattern")]
        public int Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                _pattern = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private double _value = 0D;
        [System.ComponentModel.DefaultValue(0D)]
        [System.Xml.Serialization.XmlAttribute("value")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeTestMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeTestMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile> _testProfile;
        [System.Xml.Serialization.XmlElement("TestProfile")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile> TestProfile
        {
            get
            {
                return _testProfile;
            }
            private set
            {
                _testProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestProfileSpecified
        {
            get
            {
                return (TestProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ScenarioTypeTestMix" /> class.</para>
        /// </summary>
        public ScenarioTypeTestMix()
        {
            _testProfile = new System.Collections.ObjectModel.Collection<ScenarioTypeTestMixTestProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeTestMixTestProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeTestMixTestProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Percentage")]
        public ScenarioTypeTestMixTestProfilePercentage Percentage { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("percentage")]
        public string Percentage1 { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("path")]
        public string Path { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeTestMixTestProfilePercentage", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeTestMixTestProfilePercentage
    {
        [System.Xml.Serialization.XmlIgnore()]
        private int _hi = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("hi")]
        public int Hi
        {
            get
            {
                return _hi;
            }
            set
            {
                _hi = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _lo = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("lo")]
        public int Lo
        {
            get
            {
                return _lo;
            }
            set
            {
                _lo = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _mid = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("mid")]
        public int Mid
        {
            get
            {
                return _mid;
            }
            set
            {
                _mid = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private int _flags = 0;
        [System.ComponentModel.DefaultValue(0)]
        [System.Xml.Serialization.XmlAttribute("flags")]
        public int Flags
        {
            get
            {
                return _flags;
            }
            set
            {
                _flags = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeBrowserMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeBrowserMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile> _browserProfile;
        [System.Xml.Serialization.XmlElement("BrowserProfile")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile> BrowserProfile
        {
            get
            {
                return _browserProfile;
            }
            private set
            {
                _browserProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the BrowserProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool BrowserProfileSpecified
        {
            get
            {
                return (BrowserProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ScenarioTypeBrowserMix" /> class.</para>
        /// </summary>
        public ScenarioTypeBrowserMix()
        {
            _browserProfile = new System.Collections.ObjectModel.Collection<ScenarioTypeBrowserMixBrowserProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeBrowserMixBrowserProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeBrowserMixBrowserProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Browser")]
        public BrowserType Browser { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("percentage")]
        public int PercentageValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Percentage property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool PercentageValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Percentage
        {
            get
            {
                if (PercentageValueSpecified)
                {
                    return PercentageValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PercentageValue = value.GetValueOrDefault();
                PercentageValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeNetworkMix", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeNetworkMix
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile> _networkProfile;
        [System.Xml.Serialization.XmlElement("NetworkProfile")]
        public System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile> NetworkProfile
        {
            get
            {
                return _networkProfile;
            }
            private set
            {
                _networkProfile = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the NetworkProfile collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool NetworkProfileSpecified
        {
            get
            {
                return (NetworkProfile.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ScenarioTypeNetworkMix" /> class.</para>
        /// </summary>
        public ScenarioTypeNetworkMix()
        {
            _networkProfile = new System.Collections.ObjectModel.Collection<ScenarioTypeNetworkMixNetworkProfile>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ScenarioTypeNetworkMixNetworkProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ScenarioTypeNetworkMixNetworkProfile
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Network")]
        public NetworkType Network { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("percentage")]
        public int PercentageValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Percentage property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool PercentageValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? Percentage
        {
            get
            {
                if (PercentageValueSpecified)
                {
                    return PercentageValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PercentageValue = value.GetValueOrDefault();
                PercentageValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestEntriesType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestEntriesType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestEntryType> _testEntry;
        [System.Xml.Serialization.XmlElement("TestEntry")]
        public System.Collections.ObjectModel.Collection<TestEntryType> TestEntry
        {
            get
            {
                return _testEntry;
            }
            private set
            {
                _testEntry = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestEntry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestEntrySpecified
        {
            get
            {
                return (TestEntry.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestEntriesType" /> class.</para>
        /// </summary>
        public TestEntriesType()
        {
            _testEntry = new System.Collections.ObjectModel.Collection<TestEntryType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestEntryType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestEntryType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TcmInformation")]
        public TcmInformationType TcmInformation { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestEntryType> _testEntries;
        [System.Xml.Serialization.XmlArray("TestEntries")]
        [System.Xml.Serialization.XmlArrayItem("TestEntry", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<TestEntryType> TestEntries
        {
            get
            {
                return _testEntries;
            }
            private set
            {
                _testEntries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestEntries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestEntriesSpecified
        {
            get
            {
                return (TestEntries.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestEntryType" /> class.</para>
        /// </summary>
        public TestEntryType()
        {
            _testEntries = new System.Collections.ObjectModel.Collection<TestEntryType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testId")]
        public string TestId { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("executionId")]
        public string ExecutionId { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private string _parentExecutionId = "00000000-0000-0000-0000-000000000000";
        [System.ComponentModel.DefaultValue("00000000-0000-0000-0000-000000000000")]
        [System.Xml.Serialization.XmlAttribute("parentExecutionId")]
        public string ParentExecutionId
        {
            get
            {
                return _parentExecutionId;
            }
            set
            {
                _parentExecutionId = value;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("testListId")]
        public string TestListId { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isTransparent = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("isTransparent")]
        public bool IsTransparent
        {
            get
            {
                return _isTransparent;
            }
            set
            {
                _isTransparent = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestListType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestListType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Description")]
        public object Description { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("RunConfiguration")]
        public LinkType RunConfiguration { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LinkType> _testLinks;
        [System.Xml.Serialization.XmlArray("TestLinks")]
        [System.Xml.Serialization.XmlArrayItem("TestLink", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<LinkType> TestLinks
        {
            get
            {
                return _testLinks;
            }
            private set
            {
                _testLinks = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestLinks collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestLinksSpecified
        {
            get
            {
                return (TestLinks.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestListType" /> class.</para>
        /// </summary>
        public TestListType()
        {
            _testLinks = new System.Collections.ObjectModel.Collection<LinkType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabled = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private string _parentListId = "00000000-0000-0000-0000-000000000000";
        [System.ComponentModel.DefaultValue("00000000-0000-0000-0000-000000000000")]
        [System.Xml.Serialization.XmlAttribute("parentListId")]
        public string ParentListId
        {
            get
            {
                return _parentListId;
            }
            set
            {
                _parentListId = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestResultDetailType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestResultDetail", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestResultDetailType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("TestDefinitions")]
        public TestDefinitionType TestDefinitions { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Result")]
        public ResultsType Result { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("runId")]
        public string RunId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestDefinitionType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestDefinitionType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<UnitTestType> _unitTest;
        [System.Xml.Serialization.XmlElement("UnitTest")]
        public System.Collections.ObjectModel.Collection<UnitTestType> UnitTest
        {
            get
            {
                return _unitTest;
            }
            private set
            {
                _unitTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UnitTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UnitTestSpecified
        {
            get
            {
                return (UnitTest.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestDefinitionType" /> class.</para>
        /// </summary>
        public TestDefinitionType()
        {
            _unitTest = new System.Collections.ObjectModel.Collection<UnitTestType>();
            _unitTestElement = new System.Collections.ObjectModel.Collection<UnitTestType>();
            _manualTest = new System.Collections.ObjectModel.Collection<PlainTextManualTestType>();
            _webTest = new System.Collections.ObjectModel.Collection<DeclarativeWebTestElementType>();
            _codedWebTest = new System.Collections.ObjectModel.Collection<CodedWebTestElementType>();
            _orderedTest = new System.Collections.ObjectModel.Collection<OrderedTestType>();
            _loadTest = new System.Collections.ObjectModel.Collection<LoadTestType>();
            _genericTest = new System.Collections.ObjectModel.Collection<GenericTestType>();
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<UnitTestType> _unitTestElement;
        /// <summary>
        /// <para>// Deprecated. Use UnitTest instead</para>
        /// </summary>
        [System.ComponentModel.Description("// Deprecated. Use UnitTest instead")]
        [System.Xml.Serialization.XmlElement("UnitTestElement")]
        public System.Collections.ObjectModel.Collection<UnitTestType> UnitTestElement
        {
            get
            {
                return _unitTestElement;
            }
            private set
            {
                _unitTestElement = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UnitTestElement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UnitTestElementSpecified
        {
            get
            {
                return (UnitTestElement.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<PlainTextManualTestType> _manualTest;
        [System.Xml.Serialization.XmlElement("ManualTest")]
        public System.Collections.ObjectModel.Collection<PlainTextManualTestType> ManualTest
        {
            get
            {
                return _manualTest;
            }
            private set
            {
                _manualTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ManualTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ManualTestSpecified
        {
            get
            {
                return (ManualTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DeclarativeWebTestElementType> _webTest;
        [System.Xml.Serialization.XmlElement("WebTest")]
        public System.Collections.ObjectModel.Collection<DeclarativeWebTestElementType> WebTest
        {
            get
            {
                return _webTest;
            }
            private set
            {
                _webTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the WebTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool WebTestSpecified
        {
            get
            {
                return (WebTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CodedWebTestElementType> _codedWebTest;
        [System.Xml.Serialization.XmlElement("CodedWebTest")]
        public System.Collections.ObjectModel.Collection<CodedWebTestElementType> CodedWebTest
        {
            get
            {
                return _codedWebTest;
            }
            private set
            {
                _codedWebTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CodedWebTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CodedWebTestSpecified
        {
            get
            {
                return (CodedWebTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<OrderedTestType> _orderedTest;
        [System.Xml.Serialization.XmlElement("OrderedTest")]
        public System.Collections.ObjectModel.Collection<OrderedTestType> OrderedTest
        {
            get
            {
                return _orderedTest;
            }
            private set
            {
                _orderedTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the OrderedTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool OrderedTestSpecified
        {
            get
            {
                return (OrderedTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LoadTestType> _loadTest;
        [System.Xml.Serialization.XmlElement("LoadTest")]
        public System.Collections.ObjectModel.Collection<LoadTestType> LoadTest
        {
            get
            {
                return _loadTest;
            }
            private set
            {
                _loadTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the LoadTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool LoadTestSpecified
        {
            get
            {
                return (LoadTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<GenericTestType> _genericTest;
        [System.Xml.Serialization.XmlElement("GenericTest")]
        public System.Collections.ObjectModel.Collection<GenericTestType> GenericTest
        {
            get
            {
                return _genericTest;
            }
            private set
            {
                _genericTest = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the GenericTest collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool GenericTestSpecified
        {
            get
            {
                return (GenericTest.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestType : BaseTestType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("TestMethod")]
        public UnitTestTypeTestMethod TestMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DataSource")]
        public UnitTestTypeDataSource DataSource { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("AspNet")]
        public UnitTestTypeAspNet AspNet { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _aspNetDevelopmentServers;
        [System.Xml.Serialization.XmlArray("AspNetDevelopmentServers")]
        [System.Xml.Serialization.XmlArrayItem("DevelopmentServer", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<object> AspNetDevelopmentServers
        {
            get
            {
                return _aspNetDevelopmentServers;
            }
            private set
            {
                _aspNetDevelopmentServers = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AspNetDevelopmentServers collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AspNetDevelopmentServersSpecified
        {
            get
            {
                return (AspNetDevelopmentServers.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="UnitTestType" /> class.</para>
        /// </summary>
        public UnitTestType()
        {
            _aspNetDevelopmentServers = new System.Collections.ObjectModel.Collection<object>();
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Extension")]
        public UnitTestTypeExtension Extension { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestTypeTestMethod", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestTypeTestMethod
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("codeBase")]
        public string CodeBase { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("className")]
        public string ClassName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isValid = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isValid")]
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("adapterTypeName")]
        public string AdapterTypeName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestTypeDataSource", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestTypeDataSource
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("settingName")]
        public string SettingName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("accessMethod")]
        public string AccessMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("connectionString")]
        public string ConnectionString { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("providerInvariantName")]
        public string ProviderInvariantName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("tableName")]
        public string TableName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestTypeAspNet", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestTypeAspNet
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DevelopmentServerType> _developmentServer;
        [System.Xml.Serialization.XmlElement("DevelopmentServer")]
        public System.Collections.ObjectModel.Collection<DevelopmentServerType> DevelopmentServer
        {
            get
            {
                return _developmentServer;
            }
            private set
            {
                _developmentServer = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DevelopmentServer collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DevelopmentServerSpecified
        {
            get
            {
                return (DevelopmentServer.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="UnitTestTypeAspNet" /> class.</para>
        /// </summary>
        public UnitTestTypeAspNet()
        {
            _developmentServer = new System.Collections.ObjectModel.Collection<DevelopmentServerType>();
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("webSiteUrl")]
        public string WebSiteUrl { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestTypeAspNetDevelopmentServers", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestTypeAspNetDevelopmentServers
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<object> _developmentServer;
        [System.Xml.Serialization.XmlElement("DevelopmentServer")]
        public System.Collections.ObjectModel.Collection<object> DevelopmentServer
        {
            get
            {
                return _developmentServer;
            }
            private set
            {
                _developmentServer = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DevelopmentServer collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DevelopmentServerSpecified
        {
            get
            {
                return (DevelopmentServer.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="UnitTestTypeAspNetDevelopmentServers" /> class.</para>
        /// </summary>
        public UnitTestTypeAspNetDevelopmentServers()
        {
            _developmentServer = new System.Collections.ObjectModel.Collection<object>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestTypeExtension", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class UnitTestTypeExtension
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Xml.XmlElement Any { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string[] Text { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestRun", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestRunType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunConfiguration> _testRunConfiguration;
        [System.Xml.Serialization.XmlElement("TestRunConfiguration")]
        public System.Collections.ObjectModel.Collection<TestRunConfiguration> TestRunConfiguration
        {
            get
            {
                return _testRunConfiguration;
            }
            private set
            {
                _testRunConfiguration = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestRunConfiguration collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestRunConfigurationSpecified
        {
            get
            {
                return (TestRunConfiguration.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunType" /> class.</para>
        /// </summary>
        public TestRunType()
        {
            _testRunConfiguration = new System.Collections.ObjectModel.Collection<TestRunConfiguration>();
            _testSettings = new System.Collections.ObjectModel.Collection<TestSettingsType>();
            _resultSummary = new System.Collections.ObjectModel.Collection<TestRunTypeResultSummary>();
            _times = new System.Collections.ObjectModel.Collection<TestRunTypeTimes>();
            _testDefinitions = new System.Collections.ObjectModel.Collection<TestDefinitionType>();
            _testLists = new System.Collections.ObjectModel.Collection<TestRunTypeTestLists>();
            _testEntries = new System.Collections.ObjectModel.Collection<TestEntriesType>();
            _results = new System.Collections.ObjectModel.Collection<ResultsType>();
            _userData = new System.Collections.ObjectModel.Collection<TestRunTypeUserData>();
            _build = new System.Collections.ObjectModel.Collection<TestRunTypeBuild>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestSettingsType> _testSettings;
        [System.Xml.Serialization.XmlElement("TestSettings")]
        public System.Collections.ObjectModel.Collection<TestSettingsType> TestSettings
        {
            get
            {
                return _testSettings;
            }
            private set
            {
                _testSettings = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestSettings collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestSettingsSpecified
        {
            get
            {
                return (TestSettings.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeResultSummary> _resultSummary;
        [System.Xml.Serialization.XmlElement("ResultSummary")]
        public System.Collections.ObjectModel.Collection<TestRunTypeResultSummary> ResultSummary
        {
            get
            {
                return _resultSummary;
            }
            private set
            {
                _resultSummary = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ResultSummary collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ResultSummarySpecified
        {
            get
            {
                return (ResultSummary.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeTimes> _times;
        [System.Xml.Serialization.XmlElement("Times")]
        public System.Collections.ObjectModel.Collection<TestRunTypeTimes> Times
        {
            get
            {
                return _times;
            }
            private set
            {
                _times = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Times collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TimesSpecified
        {
            get
            {
                return (Times.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestDefinitionType> _testDefinitions;
        [System.Xml.Serialization.XmlElement("TestDefinitions")]
        public System.Collections.ObjectModel.Collection<TestDefinitionType> TestDefinitions
        {
            get
            {
                return _testDefinitions;
            }
            private set
            {
                _testDefinitions = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestDefinitions collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestDefinitionsSpecified
        {
            get
            {
                return (TestDefinitions.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeTestLists> _testLists;
        [System.Xml.Serialization.XmlElement("TestLists")]
        public System.Collections.ObjectModel.Collection<TestRunTypeTestLists> TestLists
        {
            get
            {
                return _testLists;
            }
            private set
            {
                _testLists = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestLists collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestListsSpecified
        {
            get
            {
                return (TestLists.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestEntriesType> _testEntries;
        [System.Xml.Serialization.XmlElement("TestEntries")]
        public System.Collections.ObjectModel.Collection<TestEntriesType> TestEntries
        {
            get
            {
                return _testEntries;
            }
            private set
            {
                _testEntries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestEntries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestEntriesSpecified
        {
            get
            {
                return (TestEntries.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResultsType> _results;
        [System.Xml.Serialization.XmlElement("Results")]
        public System.Collections.ObjectModel.Collection<ResultsType> Results
        {
            get
            {
                return _results;
            }
            private set
            {
                _results = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Results collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ResultsSpecified
        {
            get
            {
                return (Results.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeUserData> _userData;
        [System.Xml.Serialization.XmlElement("UserData")]
        public System.Collections.ObjectModel.Collection<TestRunTypeUserData> UserData
        {
            get
            {
                return _userData;
            }
            private set
            {
                _userData = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the UserData collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool UserDataSpecified
        {
            get
            {
                return (UserData.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeBuild> _build;
        [System.Xml.Serialization.XmlElement("Build")]
        public System.Collections.ObjectModel.Collection<TestRunTypeBuild> Build
        {
            get
            {
                return _build;
            }
            private set
            {
                _build = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Build collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool BuildSpecified
        {
            get
            {
                return (Build.Count != 0);
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("runUser")]
        public string RunUser { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("tcmPassId")]
        public int TcmPassIdValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the TcmPassId property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TcmPassIdValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public int? TcmPassId
        {
            get
            {
                if (TcmPassIdValueSpecified)
                {
                    return TcmPassIdValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TcmPassIdValue = value.GetValueOrDefault();
                TcmPassIdValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeResultSummary", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeResultSummary
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CountersType> _counters;
        [System.Xml.Serialization.XmlElement("Counters")]
        public System.Collections.ObjectModel.Collection<CountersType> Counters
        {
            get
            {
                return _counters;
            }
            private set
            {
                _counters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Counters collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CountersSpecified
        {
            get
            {
                return (Counters.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunTypeResultSummary" /> class.</para>
        /// </summary>
        public TestRunTypeResultSummary()
        {
            _counters = new System.Collections.ObjectModel.Collection<CountersType>();
            _output = new System.Collections.ObjectModel.Collection<TestRunOutputType>();
            _runInfos = new System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfos>();
            _resultFiles = new System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile>();
            _fileUris = new System.Collections.ObjectModel.Collection<FileUriType>();
            _collectorDataEntries = new System.Collections.ObjectModel.Collection<CollectorType>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunOutputType> _output;
        [System.Xml.Serialization.XmlElement("Output")]
        public System.Collections.ObjectModel.Collection<TestRunOutputType> Output
        {
            get
            {
                return _output;
            }
            private set
            {
                _output = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Output collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool OutputSpecified
        {
            get
            {
                return (Output.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfos> _runInfos;
        [System.Xml.Serialization.XmlElement("RunInfos")]
        public System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfos> RunInfos
        {
            get
            {
                return _runInfos;
            }
            private set
            {
                _runInfos = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RunInfos collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RunInfosSpecified
        {
            get
            {
                return (RunInfos.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile> _resultFiles;
        [System.Xml.Serialization.XmlArray("ResultFiles")]
        [System.Xml.Serialization.XmlArrayItem("ResultFile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<ResultFilesTypeResultFile> ResultFiles
        {
            get
            {
                return _resultFiles;
            }
            private set
            {
                _resultFiles = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ResultFiles collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ResultFilesSpecified
        {
            get
            {
                return (ResultFiles.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<FileUriType> _fileUris;
        [System.Xml.Serialization.XmlArray("FileUris")]
        [System.Xml.Serialization.XmlArrayItem("FileUri", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<FileUriType> FileUris
        {
            get
            {
                return _fileUris;
            }
            private set
            {
                _fileUris = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the FileUris collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool FileUrisSpecified
        {
            get
            {
                return (FileUris.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<CollectorType> _collectorDataEntries;
        [System.Xml.Serialization.XmlArray("CollectorDataEntries")]
        [System.Xml.Serialization.XmlArrayItem("Collector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<CollectorType> CollectorDataEntries
        {
            get
            {
                return _collectorDataEntries;
            }
            private set
            {
                _collectorDataEntries = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the CollectorDataEntries collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool CollectorDataEntriesSpecified
        {
            get
            {
                return (CollectorDataEntries.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DataCollectorMessages")]
        public DataCollectorMessagesType DataCollectorMessages { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("outcome")]
        public string Outcome { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isPartialRun = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isPartialRun")]
        public bool IsPartialRun
        {
            get
            {
                return _isPartialRun;
            }
            set
            {
                _isPartialRun = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeResultSummaryRunInfos", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeResultSummaryRunInfos
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfosRunInfo> _runInfo;
        [System.Xml.Serialization.XmlElement("RunInfo")]
        public System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfosRunInfo> RunInfo
        {
            get
            {
                return _runInfo;
            }
            private set
            {
                _runInfo = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RunInfo collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RunInfoSpecified
        {
            get
            {
                return (RunInfo.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunTypeResultSummaryRunInfos" /> class.</para>
        /// </summary>
        public TestRunTypeResultSummaryRunInfos()
        {
            _runInfo = new System.Collections.ObjectModel.Collection<TestRunTypeResultSummaryRunInfosRunInfo>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeResultSummaryRunInfosRunInfo", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeResultSummaryRunInfosRunInfo
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Text")]
        public object Text { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Exception")]
        public object Exception { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("computerName")]
        public string ComputerName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("outcome")]
        public TestOutcome Outcome { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("timestamp")]
        public string Timestamp { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestOutcome", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum TestOutcome
    {
        Error,
        Failed,
        Timeout,
        Aborted,
        Inconclusive,
        PassedButRunAborted,
        NotRunnable,
        NotExecuted,
        Disconnected,
        Warning,
        Passed,
        Completed,
        InProgress,
        Pending,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeTimes", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeTimes
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("creation")]
        public string Creation { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("queuing")]
        public string Queuing { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("start")]
        public string Start { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("finish")]
        public string Finish { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeTestLists", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeTestLists
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestListType> _testList;
        [System.Xml.Serialization.XmlElement("TestList")]
        public System.Collections.ObjectModel.Collection<TestListType> TestList
        {
            get
            {
                return _testList;
            }
            private set
            {
                _testList = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestList collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestListSpecified
        {
            get
            {
                return (TestList.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestRunTypeTestLists" /> class.</para>
        /// </summary>
        public TestRunTypeTestLists()
        {
            _testList = new System.Collections.ObjectModel.Collection<TestListType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeUserData", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeUserData
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Xml.XmlElement Any { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestRunTypeBuild", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class TestRunTypeBuild
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("flavor")]
        public string Flavor { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("platform")]
        public string Platform { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitTestResultTypeEnum", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum UnitTestResultTypeEnum
    {
        NotDataDriven,
        DataDrivenTest,
        DataDrivenDataRow,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ViewType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum ViewType
    {
        None,
        Graph,
        Summary,
        Table,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebDataType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebDataType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Headers")]
        public WebDataTypeHeaders Headers { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("command")]
        public string Command { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("contentType")]
        public string ContentType { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("encodingName")]
        public string EncodingName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebDataTypeHeaders", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebDataTypeHeaders
    {
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestErrorTypeEnum", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum WebTestErrorTypeEnum
    {
        TestError,
        Exception,
        HttpError,
        ValidationRuleError,
        ExtractionRuleError,
        Timeout,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestItemsType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestItemsType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestType> _request;
        [System.Xml.Serialization.XmlElement("Request")]
        public System.Collections.ObjectModel.Collection<WebTestRequestType> Request
        {
            get
            {
                return _request;
            }
            private set
            {
                _request = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Request collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RequestSpecified
        {
            get
            {
                return (Request.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestItemsType" /> class.</para>
        /// </summary>
        public WebTestItemsType()
        {
            _request = new System.Collections.ObjectModel.Collection<WebTestRequestType>();
            _transactionTimer = new System.Collections.ObjectModel.Collection<WebTestItemsTypeTransactionTimer>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestItemsTypeTransactionTimer> _transactionTimer;
        [System.Xml.Serialization.XmlElement("TransactionTimer")]
        public System.Collections.ObjectModel.Collection<WebTestItemsTypeTransactionTimer> TransactionTimer
        {
            get
            {
                return _transactionTimer;
            }
            private set
            {
                _transactionTimer = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TransactionTimer collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TransactionTimerSpecified
        {
            get
            {
                return (TransactionTimer.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("StringHttpBody")]
        public WebTestRequestTypeStringHttpBody StringHttpBody { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestType> _dependentRequests;
        [System.Xml.Serialization.XmlArray("DependentRequests")]
        [System.Xml.Serialization.XmlArrayItem("Request", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebTestRequestType> DependentRequests
        {
            get
            {
                return _dependentRequests;
            }
            private set
            {
                _dependentRequests = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DependentRequests collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DependentRequestsSpecified
        {
            get
            {
                return (DependentRequests.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestRequestType" /> class.</para>
        /// </summary>
        public WebTestRequestType()
        {
            _dependentRequests = new System.Collections.ObjectModel.Collection<WebTestRequestType>();
            _headers = new System.Collections.ObjectModel.Collection<HeadersTypeHeader>();
            _extractionRules = new System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule>();
            _queryStringParameters = new System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<HeadersTypeHeader> _headers;
        [System.Xml.Serialization.XmlArray("Headers")]
        [System.Xml.Serialization.XmlArrayItem("Header", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<HeadersTypeHeader> Headers
        {
            get
            {
                return _headers;
            }
            private set
            {
                _headers = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Headers collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool HeadersSpecified
        {
            get
            {
                return (Headers.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule> _extractionRules;
        [System.Xml.Serialization.XmlArray("ExtractionRules")]
        [System.Xml.Serialization.XmlArrayItem("ExtractionRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule> ExtractionRules
        {
            get
            {
                return _extractionRules;
            }
            private set
            {
                _extractionRules = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ExtractionRules collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ExtractionRulesSpecified
        {
            get
            {
                return (ExtractionRules.Count != 0);
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter> _queryStringParameters;
        [System.Xml.Serialization.XmlArray("QueryStringParameters")]
        [System.Xml.Serialization.XmlArrayItem("QueryStringParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter> QueryStringParameters
        {
            get
            {
                return _queryStringParameters;
            }
            private set
            {
                _queryStringParameters = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the QueryStringParameters collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool QueryStringParametersSpecified
        {
            get
            {
                return (QueryStringParameters.Count != 0);
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("FormPostHttpBody")]
        public WebTestRequestTypeFormPostHttpBody FormPostHttpBody { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("Guid")]
        public string Guid { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("method")]
        public string Method { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("version")]
        public decimal VersionValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Version property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool VersionValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public decimal? Version
        {
            get
            {
                if (VersionValueSpecified)
                {
                    return VersionValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                VersionValue = value.GetValueOrDefault();
                VersionValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("url")]
        public string Url { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("thinkTime")]
        public byte ThinkTimeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the ThinkTime property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ThinkTimeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public byte? ThinkTime
        {
            get
            {
                if (ThinkTimeValueSpecified)
                {
                    return ThinkTimeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ThinkTimeValue = value.GetValueOrDefault();
                ThinkTimeValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("timeout")]
        public byte TimeoutValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Timeout property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TimeoutValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public byte? Timeout
        {
            get
            {
                if (TimeoutValueSpecified)
                {
                    return TimeoutValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TimeoutValue = value.GetValueOrDefault();
                TimeoutValueSpecified = value.HasValue;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _parseLinks = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("parseLinks")]
        public bool ParseLinks
        {
            get
            {
                return _parseLinks;
            }
            set
            {
                _parseLinks = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _followRedirects = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("followRedirects")]
        public bool FollowRedirects
        {
            get
            {
                return _followRedirects;
            }
            set
            {
                _followRedirects = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _cache = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("cache")]
        public bool Cache
        {
            get
            {
                return _cache;
            }
            set
            {
                _cache = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeStringHttpBody", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeStringHttpBody
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("contentType")]
        public string ContentType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeDependentRequests", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeDependentRequests
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestType> _request;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Request")]
        public System.Collections.ObjectModel.Collection<WebTestRequestType> Request
        {
            get
            {
                return _request;
            }
            private set
            {
                _request = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestRequestTypeDependentRequests" /> class.</para>
        /// </summary>
        public WebTestRequestTypeDependentRequests()
        {
            _request = new System.Collections.ObjectModel.Collection<WebTestRequestType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeExtractionRules", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeExtractionRules
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule> _extractionRule;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ExtractionRule")]
        public System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule> ExtractionRule
        {
            get
            {
                return _extractionRule;
            }
            private set
            {
                _extractionRule = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestRequestTypeExtractionRules" /> class.</para>
        /// </summary>
        public WebTestRequestTypeExtractionRules()
        {
            _extractionRule = new System.Collections.ObjectModel.Collection<WebTestRequestTypeExtractionRulesExtractionRule>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeExtractionRulesExtractionRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeExtractionRulesExtractionRule
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("className")]
        public string ClassName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("variableName")]
        public string VariableName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeQueryStringParameters", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeQueryStringParameters
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter> _queryStringParameter;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("QueryStringParameter")]
        public System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter> QueryStringParameter
        {
            get
            {
                return _queryStringParameter;
            }
            private set
            {
                _queryStringParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestRequestTypeQueryStringParameters" /> class.</para>
        /// </summary>
        public WebTestRequestTypeQueryStringParameters()
        {
            _queryStringParameter = new System.Collections.ObjectModel.Collection<WebTestRequestTypeQueryStringParametersQueryStringParameter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeQueryStringParametersQueryStringParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeQueryStringParametersQueryStringParameter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _useToGroupResults = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("useToGroupResults")]
        public bool UseToGroupResults
        {
            get
            {
                return _useToGroupResults;
            }
            set
            {
                _useToGroupResults = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeFormPostHttpBody", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeFormPostHttpBody
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<WebTestRequestTypeFormPostHttpBodyFormPostParameter> _formPostParameter;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("FormPostParameter")]
        public System.Collections.ObjectModel.Collection<WebTestRequestTypeFormPostHttpBodyFormPostParameter> FormPostParameter
        {
            get
            {
                return _formPostParameter;
            }
            private set
            {
                _formPostParameter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="WebTestRequestTypeFormPostHttpBody" /> class.</para>
        /// </summary>
        public WebTestRequestTypeFormPostHttpBody()
        {
            _formPostParameter = new System.Collections.ObjectModel.Collection<WebTestRequestTypeFormPostHttpBodyFormPostParameter>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("FileUploadParameter")]
        public WebTestRequestTypeFormPostHttpBodyFileUploadParameter FileUploadParameter { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeFormPostHttpBodyFormPostParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeFormPostHttpBodyFormPostParameter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public string Value { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestRequestTypeFormPostHttpBodyFileUploadParameter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestRequestTypeFormPostHttpBodyFileUploadParameter
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("fileName")]
        public string FileName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("contentType")]
        public string ContentType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("WebTestItemsTypeTransactionTimer", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class WebTestItemsTypeTransactionTimer
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Items")]
        public WebTestItemsType Items { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("Name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NetworkEmulationProfileType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("NetworkEmulationProfile", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class NetworkEmulationProfileType
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Emulation")]
        public NetworkEmulationProfileTypeEmulation Emulation { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("bandwidthInKbps")]
        public string BandwidthInKbps { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NetworkEmulationProfileTypeEmulation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NetworkEmulationProfileTypeEmulation
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="NetworkEmulationProfileTypeEmulation" /> class.</para>
        /// </summary>
        public NetworkEmulationProfileTypeEmulation()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DiscoveryCacheType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("DiscoveryCache", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class DiscoveryCacheType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController> _remoteAgents;
        [System.Xml.Serialization.XmlArray("RemoteAgents")]
        [System.Xml.Serialization.XmlArrayItem("Controller", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController> RemoteAgents
        {
            get
            {
                return _remoteAgents;
            }
            private set
            {
                _remoteAgents = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the RemoteAgents collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool RemoteAgentsSpecified
        {
            get
            {
                return (RemoteAgents.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiscoveryCacheType" /> class.</para>
        /// </summary>
        public DiscoveryCacheType()
        {
            _remoteAgents = new System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DiscoveryCacheTypeRemoteAgents", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DiscoveryCacheTypeRemoteAgents
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController> _controller;
        [System.Xml.Serialization.XmlElement("Controller")]
        public System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController> Controller
        {
            get
            {
                return _controller;
            }
            private set
            {
                _controller = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Controller collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ControllerSpecified
        {
            get
            {
                return (Controller.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiscoveryCacheTypeRemoteAgents" /> class.</para>
        /// </summary>
        public DiscoveryCacheTypeRemoteAgents()
        {
            _controller = new System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsController>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DiscoveryCacheTypeRemoteAgentsController", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DiscoveryCacheTypeRemoteAgentsController
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsControllerAgent> _agent;
        [System.Xml.Serialization.XmlElement("Agent")]
        public System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsControllerAgent> Agent
        {
            get
            {
                return _agent;
            }
            private set
            {
                _agent = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Agent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentSpecified
        {
            get
            {
                return (Agent.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiscoveryCacheTypeRemoteAgentsController" /> class.</para>
        /// </summary>
        public DiscoveryCacheTypeRemoteAgentsController()
        {
            _agent = new System.Collections.ObjectModel.Collection<DiscoveryCacheTypeRemoteAgentsControllerAgent>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DiscoveryCacheTypeRemoteAgentsControllerAgent", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DiscoveryCacheTypeRemoteAgentsControllerAgent
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DataCollectorInformation")]
        public DataCollectorInformationType DataCollectorInformation { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _agentProperties;
        [System.Xml.Serialization.XmlArray("AgentProperties")]
        [System.Xml.Serialization.XmlArrayItem("Property", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> AgentProperties
        {
            get
            {
                return _agentProperties;
            }
            private set
            {
                _agentProperties = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the AgentProperties collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AgentPropertiesSpecified
        {
            get
            {
                return (AgentProperties.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiscoveryCacheTypeRemoteAgentsControllerAgent" /> class.</para>
        /// </summary>
        public DiscoveryCacheTypeRemoteAgentsControllerAgent()
        {
            _agentProperties = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationType
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector> _dataCollectors;
        [System.Xml.Serialization.XmlArray("DataCollectors")]
        [System.Xml.Serialization.XmlArrayItem("DataCollector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector> DataCollectors
        {
            get
            {
                return _dataCollectors;
            }
            private set
            {
                _dataCollectors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollectors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorsSpecified
        {
            get
            {
                return (DataCollectors.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorInformationType" /> class.</para>
        /// </summary>
        public DataCollectorInformationType()
        {
            _dataCollectors = new System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector>();
            _configurationEditors = new System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor> _configurationEditors;
        [System.Xml.Serialization.XmlArray("ConfigurationEditors")]
        [System.Xml.Serialization.XmlArrayItem("ConfigurationEditor", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor> ConfigurationEditors
        {
            get
            {
                return _configurationEditors;
            }
            private set
            {
                _configurationEditors = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ConfigurationEditors collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ConfigurationEditorsSpecified
        {
            get
            {
                return (ConfigurationEditors.Count != 0);
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeDataCollectors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeDataCollectors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector> _dataCollector;
        [System.Xml.Serialization.XmlElement("DataCollector")]
        public System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector> DataCollector
        {
            get
            {
                return _dataCollector;
            }
            private set
            {
                _dataCollector = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollector collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorSpecified
        {
            get
            {
                return (DataCollector.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorInformationTypeDataCollectors" /> class.</para>
        /// </summary>
        public DataCollectorInformationTypeDataCollectors()
        {
            _dataCollector = new System.Collections.ObjectModel.Collection<DataCollectorInformationTypeDataCollectorsDataCollector>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeDataCollectorsDataCollector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeDataCollectorsDataCollector
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("FriendlyName")]
        public object FriendlyName { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Description")]
        public object Description { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DefaultConfiguration")]
        public DataCollectorInformationTypeDataCollectorsDataCollectorDefaultConfiguration DefaultConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("ConfigurationEditor")]
        public DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditor ConfigurationEditor { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("typeUri")]
        public string TypeUri { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("requiresOutOfProcessCollection")]
        public bool RequiresOutOfProcessCollectionValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the RequiresOutOfProcessCollection property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool RequiresOutOfProcessCollectionValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public bool? RequiresOutOfProcessCollection
        {
            get
            {
                if (RequiresOutOfProcessCollectionValueSpecified)
                {
                    return RequiresOutOfProcessCollectionValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                RequiresOutOfProcessCollectionValue = value.GetValueOrDefault();
                RequiresOutOfProcessCollectionValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("assemblyQualifiedName")]
        public string AssemblyQualifiedName { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isEnabledByDefault = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isEnabledByDefault")]
        public bool IsEnabledByDefault
        {
            get
            {
                return _isEnabledByDefault;
            }
            set
            {
                _isEnabledByDefault = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _enabledOnCollectionOnlyAgents = true;
        [System.ComponentModel.DefaultValue(true)]
        [System.Xml.Serialization.XmlAttribute("enabledOnCollectionOnlyAgents")]
        public bool EnabledOnCollectionOnlyAgents
        {
            get
            {
                return _enabledOnCollectionOnlyAgents;
            }
            set
            {
                _enabledOnCollectionOnlyAgents = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("supportedTestClients")]
        public string SupportedTestClients { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("supportedLocations")]
        public string SupportedLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("supportedAgentRoleTypes")]
        public string SupportedAgentRoleTypes { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _isEnabledByDefaultForTailoredApplications = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("isEnabledByDefaultForTailoredApplications")]
        public bool IsEnabledByDefaultForTailoredApplications
        {
            get
            {
                return _isEnabledByDefaultForTailoredApplications;
            }
            set
            {
                _isEnabledByDefaultForTailoredApplications = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _supportsTailoredApplications = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("supportsTailoredApplications")]
        public bool SupportsTailoredApplications
        {
            get
            {
                return _supportsTailoredApplications;
            }
            set
            {
                _supportsTailoredApplications = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeDataCollectorsDataCollectorDefaultConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeDataCollectorsDataCollectorDefaultConfiguration
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorInformationTypeDataCollectorsDataCollectorDefaultConfiguration" /> class.</para>
        /// </summary>
        public DataCollectorInformationTypeDataCollectorsDataCollectorDefaultConfiguration()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditor", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditor
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Configuration")]
        public DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditorConfiguration Configuration { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("typeUri")]
        public string TypeUri { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("helpUri")]
        public string HelpUri { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditorConfigu" +
        "ration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditorConfiguration
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditorConfiguration" /> class.</para>
        /// </summary>
        public DataCollectorInformationTypeDataCollectorsDataCollectorConfigurationEditorConfiguration()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeConfigurationEditors", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeConfigurationEditors
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor> _configurationEditor;
        [System.Xml.Serialization.XmlElement("ConfigurationEditor")]
        public System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor> ConfigurationEditor
        {
            get
            {
                return _configurationEditor;
            }
            private set
            {
                _configurationEditor = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the ConfigurationEditor collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ConfigurationEditorSpecified
        {
            get
            {
                return (ConfigurationEditor.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorInformationTypeConfigurationEditors" /> class.</para>
        /// </summary>
        public DataCollectorInformationTypeConfigurationEditors()
        {
            _configurationEditor = new System.Collections.ObjectModel.Collection<DataCollectorInformationTypeConfigurationEditorsConfigurationEditor>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorInformationTypeConfigurationEditorsConfigurationEditor", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorInformationTypeConfigurationEditorsConfigurationEditor
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("typeUri")]
        public string TypeUri { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("assemblyQualifiedName")]
        public string AssemblyQualifiedName { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DiscoveryCacheTypeRemoteAgentsControllerAgentAgentProperties", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DiscoveryCacheTypeRemoteAgentsControllerAgentAgentProperties
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<NameValuePropertyType> _property;
        [System.Xml.Serialization.XmlElement("Property")]
        public System.Collections.ObjectModel.Collection<NameValuePropertyType> Property
        {
            get
            {
                return _property;
            }
            private set
            {
                _property = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Property collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool PropertySpecified
        {
            get
            {
                return (Property.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiscoveryCacheTypeRemoteAgentsControllerAgentAgentProperties" /> class.</para>
        /// </summary>
        public DiscoveryCacheTypeRemoteAgentsControllerAgentAgentProperties()
        {
            _property = new System.Collections.ObjectModel.Collection<NameValuePropertyType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorConfigurationSection", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("DataCollectorConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class DataCollectorConfigurationSection
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<DataCollectorConfigurationSectionDataCollector> _dataCollector;
        [System.Xml.Serialization.XmlElement("DataCollector")]
        public System.Collections.ObjectModel.Collection<DataCollectorConfigurationSectionDataCollector> DataCollector
        {
            get
            {
                return _dataCollector;
            }
            private set
            {
                _dataCollector = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the DataCollector collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool DataCollectorSpecified
        {
            get
            {
                return (DataCollector.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorConfigurationSection" /> class.</para>
        /// </summary>
        public DataCollectorConfigurationSection()
        {
            _dataCollector = new System.Collections.ObjectModel.Collection<DataCollectorConfigurationSectionDataCollector>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorConfigurationSectionDataCollector", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorConfigurationSectionDataCollector
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("DefaultConfiguration")]
        public DataCollectorConfigurationSectionDataCollectorDefaultConfiguration DefaultConfiguration { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("typeUri")]
        public string TypeUri { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DataCollectorConfigurationSectionDataCollectorDefaultConfiguration", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class DataCollectorConfigurationSectionDataCollectorDefaultConfiguration
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        [System.Xml.Serialization.XmlAnyElement()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return _any;
            }
            private set
            {
                _any = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool AnySpecified
        {
            get
            {
                return (Any.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DataCollectorConfigurationSectionDataCollectorDefaultConfiguration" /> class.</para>
        /// </summary>
        public DataCollectorConfigurationSectionDataCollectorDefaultConfiguration()
        {
            _any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PeriodicDisconnectionType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class PeriodicDisconnectionType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ConnectionTime")]
        public SecType ConnectionTime { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("DisconnectionTime")]
        public SecType DisconnectionTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SecType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class SecType
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("unit")]
        public SecTypeUnit UnitValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Unit property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool UnitValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public SecTypeUnit? Unit
        {
            get
            {
                if (UnitValueSpecified)
                {
                    return UnitValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                UnitValue = value.GetValueOrDefault();
                UnitValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SecTypeUnit", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum SecTypeUnit
    {
        [System.Xml.Serialization.XmlEnum("sec")]
        Sec,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Empirical1Type", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class Empirical1Type
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Empirical2Type", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class Empirical2Type
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NormalReorderType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NormalReorderType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Deviation")]
        public double Deviation { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("MaxPacketLag")]
        public ushort MaxPacketLag { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("FixedLatencyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class FixedLatencyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Time")]
        public MsecType Time { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("MsecType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class MsecType
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("unit")]
        public MsecTypeUnit UnitValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Unit property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool UnitValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public MsecTypeUnit? Unit
        {
            get
            {
                if (UnitValueSpecified)
                {
                    return UnitValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                UnitValue = value.GetValueOrDefault();
                UnitValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("MsecTypeUnit", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum MsecTypeUnit
    {
        [System.Xml.Serialization.XmlEnum("msec")]
        Msec,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UniformLatencyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(LinearLatencyType))]
    public partial class UniformLatencyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Min")]
        public MsecType Min { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Max")]
        public MsecType Max { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NormalLatencyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NormalLatencyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Average")]
        public MsecType Average { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Deviation")]
        public MsecType Deviation { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LinearLatencyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class LinearLatencyType : UniformLatencyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Period")]
        public SecType Period { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BurstLatencyType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BurstLatencyType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Time")]
        public MsecType Time { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PeriodMin")]
        public SecType PeriodMin { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PeriodMax")]
        public SecType PeriodMax { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Probability")]
        public decimal Probability { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RandomErrorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RandomErrorType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ErrorUnit")]
        public ErrorUnitType ErrorUnit { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ErrorUnitType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum ErrorUnitType
    {
        [System.Xml.Serialization.XmlEnum("packet")]
        Packet,
        [System.Xml.Serialization.XmlEnum("bit")]
        Bit,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("NormalQueueType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class NormalQueueType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("QueueMode")]
        public UnitType QueueMode { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Size")]
        public string Size { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("DropType")]
        public DropType DropType { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("UnitType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum UnitType
    {
        [System.Xml.Serialization.XmlEnum("byte")]
        Byte,
        [System.Xml.Serialization.XmlEnum("kb")]
        Kb,
        [System.Xml.Serialization.XmlEnum("packet")]
        Packet,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("DropType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("DropType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum DropType
    {
        DropTail,
        DropHead,
        DropRandom,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RedQueueType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RedQueueType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("DropType")]
        public DropType DropType { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("QueueMode")]
        public UnitType QueueMode { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("MinPacket")]
        public string MinPacket { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("MaxPacket")]
        public string MaxPacket { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PacketSize")]
        public string PacketSize { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ConstantTrafficType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(ExponentialTrafficType))]
    [System.Xml.Serialization.XmlInclude(typeof(ParetoTrafficType))]
    public partial class ConstantTrafficType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public SpeedType Rate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PacketSize")]
        public SizeType PacketSize { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SpeedType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class SpeedType
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public double Value { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("unit")]
        public SpeedTypeUnit Unit { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SpeedTypeUnit", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum SpeedTypeUnit
    {
        [System.Xml.Serialization.XmlEnum("kbps")]
        Kbps,
        [System.Xml.Serialization.XmlEnum("mbps")]
        Mbps,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SizeType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class SizeType
    {
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private SizeTypeUnit _unit = VSTest.SizeTypeUnit.Byte;
        [System.ComponentModel.DefaultValue(VSTest.SizeTypeUnit.Byte)]
        [System.Xml.Serialization.XmlAttribute("unit")]
        public SizeTypeUnit Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("SizeTypeUnit", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum SizeTypeUnit
    {
        [System.Xml.Serialization.XmlEnum("byte")]
        Byte,
        [System.Xml.Serialization.XmlEnum("kb")]
        Kb,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ExponentialTrafficType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(ParetoTrafficType))]
    public partial class ExponentialTrafficType : ConstantTrafficType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("BurstTime")]
        public SecType BurstTime { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("IdleTime")]
        public SecType IdleTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("ParetoTrafficType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class ParetoTrafficType : ExponentialTrafficType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Shape")]
        public double Shape { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("PeriodicLossType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class PeriodicLossType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PerPackets")]
        public string PerPackets { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("RandomLossType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class RandomLossType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BurstLossType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BurstLossType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Rate")]
        public decimal Rate { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("MinPacket")]
        public string MinPacket { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("MaxPacket")]
        public string MaxPacket { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("AddressType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class AddressType
    {
        /// <summary>
        /// <para xml:lang="en">Pattern: ((([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))|(([0-9a-fA-F]{1,4}:){7}([0-9a-fA-F]{1,4})).</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RegularExpression("((([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.){3}([1-9]?[0-9]|1[0-9][0-9]|2[0" +
            "-4][0-9]|25[0-5]))|(([0-9a-fA-F]{1,4}:){7}([0-9a-fA-F]{1,4}))")]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("IpAddress")]
        public string IpAddress { get; set; }
        /// <summary>
        /// <para xml:lang="en">Pattern: ((([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))|(([0-9a-fA-F]{1,4}:){7}([0-9a-fA-F]{1,4})).</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RegularExpression("((([1-9]?[0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.){3}([1-9]?[0-9]|1[0-9][0-9]|2[0" +
            "-4][0-9]|25[0-5]))|(([0-9a-fA-F]{1,4}:){7}([0-9a-fA-F]{1,4}))")]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("IpMask")]
        public string IpMask { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PortBegin")]
        public ushort PortBegin { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("PortEnd")]
        public ushort PortEnd { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("StatisticalType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlInclude(typeof(StatisticalErrorType))]
    public partial class StatisticalType
    {
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Good")]
        public decimal Good { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("GoodToBad")]
        public decimal GoodToBad { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Bad")]
        public decimal Bad { get; set; }
        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 1.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0", "1", ConvertValueInInvariantCulture = true)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("BadToGood")]
        public decimal BadToGood { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("SwitchTime")]
        public SecType SwitchTime { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("StatisticalErrorType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class StatisticalErrorType : StatisticalType
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("ErrorUnit")]
        public ErrorUnitType ErrorUnit { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TestLists", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("TestLists", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestLists
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<TestListType> _testList;
        [System.Xml.Serialization.XmlElement("TestList")]
        public System.Collections.ObjectModel.Collection<TestListType> TestList
        {
            get
            {
                return _testList;
            }
            private set
            {
                _testList = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the TestList collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool TestListSpecified
        {
            get
            {
                return (TestList.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TestLists" /> class.</para>
        /// </summary>
        public TestLists()
        {
            _testList = new System.Collections.ObjectModel.Collection<TestListType>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Emulation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Emulation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Emulation
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("VirtualChannel")]
        public VirtualChannel VirtualChannel { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<Timestamp> _timestamp;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Timestamp")]
        public System.Collections.ObjectModel.Collection<Timestamp> Timestamp
        {
            get
            {
                return _timestamp;
            }
            private set
            {
                _timestamp = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="Emulation" /> class.</para>
        /// </summary>
        public Emulation()
        {
            _timestamp = new System.Collections.ObjectModel.Collection<Timestamp>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("VirtualChannel", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("VirtualChannel", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class VirtualChannel
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<Filter> _filterList;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlArray("FilterList")]
        [System.Xml.Serialization.XmlArrayItem("Filter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
        public System.Collections.ObjectModel.Collection<Filter> FilterList
        {
            get
            {
                return _filterList;
            }
            private set
            {
                _filterList = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="VirtualChannel" /> class.</para>
        /// </summary>
        public VirtualChannel()
        {
            _filterList = new System.Collections.ObjectModel.Collection<Filter>();
            _virtualLink = new System.Collections.ObjectModel.Collection<VirtualLink>();
        }
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<VirtualLink> _virtualLink;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("VirtualLink")]
        public System.Collections.ObjectModel.Collection<VirtualLink> VirtualLink
        {
            get
            {
                return _virtualLink;
            }
            private set
            {
                _virtualLink = value;
            }
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("DispatchType")]
        public VirtualChannelDispatchType DispatchTypeValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the DispatchType property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool DispatchTypeValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public VirtualChannelDispatchType? DispatchType
        {
            get
            {
                if (DispatchTypeValueSpecified)
                {
                    return DispatchTypeValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DispatchTypeValue = value.GetValueOrDefault();
                DispatchTypeValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("FilterList", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("FilterList", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class FilterList
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<Filter> _filter;
        [System.Xml.Serialization.XmlElement("Filter")]
        public System.Collections.ObjectModel.Collection<Filter> Filter
        {
            get
            {
                return _filter;
            }
            private set
            {
                _filter = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Filter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public bool FilterSpecified
        {
            get
            {
                return (Filter.Count != 0);
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="FilterList" /> class.</para>
        /// </summary>
        public FilterList()
        {
            _filter = new System.Collections.ObjectModel.Collection<Filter>();
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Filter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Filter", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Filter
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlElement("IpVersion")]
        public IpVersion IpVersionValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IpVersion property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool IpVersionValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public IpVersion? IpVersion
        {
            get
            {
                if (IpVersionValueSpecified)
                {
                    return IpVersionValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                IpVersionValue = value.GetValueOrDefault();
                IpVersionValueSpecified = value.HasValue;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlElement("Protocol")]
        public Protocol ProtocolValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Protocol property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ProtocolValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public Protocol? Protocol
        {
            get
            {
                if (ProtocolValueSpecified)
                {
                    return ProtocolValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ProtocolValue = value.GetValueOrDefault();
                ProtocolValueSpecified = value.HasValue;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Pattern: ([0-9a-fA-F]{1,2}-){7}([0-9a-fA-F]{1,2}).</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RegularExpression("([0-9a-fA-F]{1,2}-){7}([0-9a-fA-F]{1,2})")]
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("PhysicalAddress")]
        public string PhysicalAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Local")]
        public AddressType Local { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Remote")]
        public AddressType Remote { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        private bool _not = false;
        [System.ComponentModel.DefaultValue(false)]
        [System.Xml.Serialization.XmlAttribute("not")]
        public bool Not
        {
            get
            {
                return _not;
            }
            set
            {
                _not = value;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("IpVersion", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("IpVersion", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum IpVersion
    {
        IPv4,
        IPv6,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Protocol", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("Protocol", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public enum Protocol
    {
        ICMP,
        TCP,
        UDP,
        ECP,
        ICMPv6,
        HTTP,
        FTP,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("VirtualLink", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("VirtualLink", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class VirtualLink
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<LinkRule> _linkRule;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("LinkRule")]
        public System.Collections.ObjectModel.Collection<LinkRule> LinkRule
        {
            get
            {
                return _linkRule;
            }
            private set
            {
                _linkRule = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="VirtualLink" /> class.</para>
        /// </summary>
        public VirtualLink()
        {
            _linkRule = new System.Collections.ObjectModel.Collection<LinkRule>();
        }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlAttribute("instances")]
        public ushort InstancesValue { get; set; }
        /// <summary>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Instances property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool InstancesValueSpecified { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public ushort? Instances
        {
            get
            {
                if (InstancesValueSpecified)
                {
                    return InstancesValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                InstancesValue = value.GetValueOrDefault();
                InstancesValueSpecified = value.HasValue;
            }
        }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LinkRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("LinkRule", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class LinkRule
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Latency")]
        public Latency Latency { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Error")]
        public Error Error { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Loss")]
        public Loss Loss { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Bandwidth")]
        public Bandwidth Bandwidth { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("BackgroundTraffic")]
        public BackgroundTraffic BackgroundTraffic { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Reorder")]
        public Reorder Reorder { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Disconnection")]
        public Disconnection Disconnection { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("dir")]
        public LinkRuleDir Dir { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Latency", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Latency", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Latency
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Fixed")]
        public FixedLatencyType Fixed { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Uniform")]
        public UniformLatencyType Uniform { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Normal")]
        public NormalLatencyType Normal { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Linear")]
        public LinearLatencyType Linear { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Burst")]
        public BurstLatencyType Burst { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Error", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Error", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Error
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Random")]
        public RandomErrorType Random { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Statistical")]
        public StatisticalErrorType Statistical { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Loss", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Loss", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Loss
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Periodic")]
        public PeriodicLossType Periodic { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Random")]
        public RandomLossType Random { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Burst")]
        public BurstLossType Burst { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Statistical")]
        public StatisticalType Statistical { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Bandwidth", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Bandwidth", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Bandwidth
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("Speed")]
        public SpeedType Speed { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("QueueManagement")]
        public BandwidthQueueManagement QueueManagement { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BandwidthQueueManagement", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    public partial class BandwidthQueueManagement
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("RedQueue")]
        public RedQueueType RedQueue { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("NormalQueue")]
        public NormalQueueType NormalQueue { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("BackgroundTraffic", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("BackgroundTraffic", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class BackgroundTraffic
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Constant")]
        public ConstantTrafficType Constant { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Exponential")]
        public ExponentialTrafficType Exponential { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Pareto")]
        public ParetoTrafficType Pareto { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Reorder", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Reorder", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Reorder
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Normal")]
        public NormalReorderType Normal { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Empirical1")]
        public Empirical1Type Empirical1 { get; set; }
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Empirical2")]
        public Empirical2Type Empirical2 { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Disconnection", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Disconnection", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Disconnection
    {
        [System.Diagnostics.CodeAnalysis.AllowNull()]
        [System.Diagnostics.CodeAnalysis.MaybeNull()]
        [System.Xml.Serialization.XmlElement("Periodic")]
        public PeriodicDisconnectionType Periodic { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("LinkRuleDir", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum LinkRuleDir
    {
        [System.Xml.Serialization.XmlEnum("upstream")]
        Upstream,
        [System.Xml.Serialization.XmlEnum("downstream")]
        Downstream,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("VirtualChannelDispatchType", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum VirtualChannelDispatchType
    {
        [System.Xml.Serialization.XmlEnum("packet")]
        Packet,
        [System.Xml.Serialization.XmlEnum("connection")]
        Connection,
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("Timestamp", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlRoot("Timestamp", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class Timestamp
    {
        [System.Xml.Serialization.XmlIgnore()]
        private System.Collections.ObjectModel.Collection<VirtualChannel> _virtualChannel;
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlElement("VirtualChannel")]
        public System.Collections.ObjectModel.Collection<VirtualChannel> VirtualChannel
        {
            get
            {
                return _virtualChannel;
            }
            private set
            {
                _virtualChannel = value;
            }
        }
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="Timestamp" /> class.</para>
        /// </summary>
        public Timestamp()
        {
            _virtualChannel = new System.Collections.ObjectModel.Collection<VirtualChannel>();
        }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("value")]
        public uint Value { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        [System.Xml.Serialization.XmlAttribute("operation")]
        public TimestampOperation Operation { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("TimestampOperation", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010", AnonymousType = true)]
    public enum TimestampOperation
    {
        Add,
        Modify,
        Delete,
    }
}
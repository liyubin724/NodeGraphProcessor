using System;

namespace GraphProcessor
{
    /// <summary>
	/// Tell that this field is will generate an input port
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InputAttribute : Attribute
    {
        public string name;
        public bool allowMultiple = false;

        /// <summary>
        /// Mark the field as an input port
        /// </summary>
        /// <param name="name">display name</param>
        /// <param name="allowMultiple">is connecting multiple edges allowed</param>
        public InputAttribute(string name = null, bool allowMultiple = false)
        {
            this.name = name;
            this.allowMultiple = allowMultiple;
        }
    }

    /// <summary>
	/// Tell that this field is will generate an output port
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class OutputAttribute : Attribute
    {
        public string name;
        public bool allowMultiple = true;

        /// <summary>
        /// Mark the field as an output port
        /// </summary>
        /// <param name="name">display name</param>
        /// <param name="allowMultiple">is connecting multiple edges allowed</param>
        public OutputAttribute(string name = null, bool allowMultiple = true)
        {
            this.name = name;
            this.allowMultiple = allowMultiple;
        }
    }

    /// <summary>
    /// Creates a vertical port instead of the default horizontal one
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class VerticalAttribute : Attribute
    {
    }

    /// <summary>
    /// Allow you to modify the generated port view from a field. 
    /// Can be used to generate multiple ports from one field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CustomPortBehaviorAttribute : Attribute
    {
        public string fieldName;

        /// <summary>
        /// Allow you to modify the generated port view from a field. 
        /// Can be used to generate multiple ports from one field.
        /// You must add this attribute on a function of this signature
        /// <code>
        /// IEnumerable&lt;PortData&gt; MyCustomPortFunction(List&lt;SerializableEdge&gt; edges);
        /// </code>
        /// </summary>
        /// <param name="fieldName">local node field name</param>
        public CustomPortBehaviorAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }
    }
}

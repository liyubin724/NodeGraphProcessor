using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProcessor
{
    /// <summary>
    /// Set a custom drawer for a field. It can then be created using the FieldFactory
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [Obsolete("You can use the standard Unity CustomPropertyDrawer instead.")]
    public class FieldDrawerAttribute : Attribute
    {
        public Type fieldType;

        /// <summary>
        /// Register a custom view for a type in the FieldFactory class
        /// </summary>
        /// <param name="fieldType"></param>
        public FieldDrawerAttribute(Type fieldType)
        {
            this.fieldType = fieldType;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class VisibleIf : Attribute
    {
        public string fieldName;
        public object value;

        public VisibleIf(string fieldName, object value)
        {
            this.fieldName = fieldName;
            this.value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShowInInspector : Attribute
    {
        public bool showInNode;

        public ShowInInspector(bool showInNode = false)
        {
            this.showInNode = showInNode;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShowAsDrawer : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class SettingAttribute : Attribute
    {
        public string name;

        public SettingAttribute(string name = null)
        {
            this.name = name;
        }
    }
}

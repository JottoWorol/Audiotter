using System;
using UnityEngine;

namespace Audiotter.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class ShowIf : PropertyAttribute
    {
        public string ConditionalSourceField = "";
        public bool HideInInspector = false;

        public ShowIf(string conditionalSourceField)
        {
            ConditionalSourceField = conditionalSourceField;
            HideInInspector = false;
        }

        public ShowIf(string conditionalSourceField, bool hideInInspector)
        {
            ConditionalSourceField = conditionalSourceField;
            HideInInspector = hideInInspector;
        }
    }
}
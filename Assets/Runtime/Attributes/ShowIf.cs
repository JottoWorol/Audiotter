using System;
using UnityEngine;

namespace Audiotter.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Class | AttributeTargets.Struct
    )]
    public class ShowIf : PropertyAttribute
    {
        public string ConditionalSourceField = "";
        public bool HideInInspector;

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
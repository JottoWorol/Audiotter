using UnityEngine;

namespace Audiotter.Runtime.Attributes
{
    public class ButtonAttribute : PropertyAttribute
    {
        public ButtonAttribute(string methodName) => MethodName = methodName;

        public string MethodName { get; }
    }
}
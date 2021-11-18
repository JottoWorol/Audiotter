using UnityEngine;

namespace Assets.Runtime.Attributes
{
    public class ButtonAttribute : PropertyAttribute
    {
        public string MethodName { get; }
        public ButtonAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}
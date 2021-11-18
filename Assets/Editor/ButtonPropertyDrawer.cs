using Audiotter.Assets.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Audiotter.Assets.Editor
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            var methodName = (attribute as ButtonAttribute).MethodName;
            var target = property.serializedObject.targetObject;
            var type = target.GetType();
            var method = type.GetMethod(methodName);
            if (method == null)
            {
                GUI.Label(position, "Method could not be found. Is it public?");
                return;
            }

            if (method.GetParameters().Length > 0)
            {
                GUI.Label(position, "Method cannot have parameters.");
                return;
            }

            if (GUI.Button(position, method.Name)) method.Invoke(target, null);
        }
    }
}
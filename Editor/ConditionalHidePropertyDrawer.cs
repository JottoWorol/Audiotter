using Assets.Attributes;
using UnityEngine;
using EditorGUI = UnityEditor.EditorGUI;
using EditorGUIUtility = UnityEditor.EditorGUIUtility;
using GUI = UnityEngine.GUI;
using GUIContent = UnityEngine.GUIContent;
using PropertyDrawer = UnityEditor.PropertyDrawer;
using Rect = UnityEngine.Rect;
using SerializedProperty = UnityEditor.SerializedProperty;

namespace Assets.Editor
{
    [UnityEditor.CustomPropertyDrawer(typeof(ShowIf))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIf condHAtt = (ShowIf)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);
 
            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!condHAtt.HideInInspector || enabled)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
 
            GUI.enabled = wasEnabled;
        }
 
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIf condHAtt = (ShowIf)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);
 
            if (!condHAtt.HideInInspector || enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }
            else
            {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }
 
        private bool GetConditionalHideAttributeResult(ShowIf condHAtt, SerializedProperty property)
        {
            bool enabled = true;
            string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
            string conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField); //changes the path to the conditionalsource property path
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);
 
            if (sourcePropertyValue != null)
            {
                enabled = sourcePropertyValue.boolValue;
            }
            else
            {
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.ConditionalSourceField);
            }
 
            return enabled;
        }
    }
}
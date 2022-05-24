using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LocalizedText))]
public class LocalizedTextDrawer : PropertyDrawer
{
    private bool _dropdownEnabled;
    private float _height;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) =>
        _dropdownEnabled ? _height + 20 : 20;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        position.width -= 34;
        position.height = 18;
    }

    public LocalizedTextDrawer(float height, bool dropdownEnabled)
    {
        this._height = height;
        this._dropdownEnabled = dropdownEnabled;
    }
}
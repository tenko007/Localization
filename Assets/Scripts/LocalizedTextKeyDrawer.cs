using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LocalizedTextKey))]
public class LocalizedTextKeyDrawer : PropertyDrawer
{
    private bool _dropdownEnabled;
    private float _height;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) =>
        _dropdownEnabled ? _height + 25 : 20;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty key = property.FindPropertyRelative("key");
        
        AddDropdownMenu(ref position, key);
        AddTextField(ref position, key);
        
        AddButton(ref position, "Search");
        AddButton(ref position, "Add");
        
        EditorGUI.EndProperty();
    }

    private void AddTextField(ref Rect position, SerializedProperty textInside)
    {
        position.width -= 15;
        textInside.stringValue = EditorGUI.TextField(position, textInside.stringValue);
    }
    
    private void AddDropdownMenu(ref Rect position, SerializedProperty textInside)
    {
        position.width -= 26;
        position.height = 18;
        
        Rect valueRect = new Rect(position);
        valueRect.width -= 10;

        Rect foldButtonRect = new Rect(position);
        foldButtonRect.width = 15;
        foldButtonRect.x -= 15;
        
        _dropdownEnabled = EditorGUI.Foldout(foldButtonRect, _dropdownEnabled, "");//, GUIStyle.none);
        if (_dropdownEnabled)
        {
            var value = Localization.Instance.GetText(textInside.stringValue);
            GUIStyle style = GUI.skin.box;
            _height = style.CalcHeight(new GUIContent(value), valueRect.width);

            valueRect.height = _height;
            valueRect.width = 80;
            valueRect.y += 21;
            EditorGUI.LabelField(valueRect, Localization.Instance.CurrentLanguage, EditorStyles.objectField);
            
            valueRect.x += valueRect.width + 10;
            valueRect.width = 240;
            EditorGUI.LabelField(valueRect, value, EditorStyles.linkLabel);
        }
    }

    private void AddButton(ref Rect position, string name)
    {
        position.x += position.width + 2;

        position.width = 18;
        position.height = 18;
        
        GUIStyle GUIStyle = new GUIStyle();
        Texture icon = (Texture)Resources.Load(name);
        GUIContent content = new GUIContent(icon);
        
        if (GUI.Button(position, content, GUIStyle))
            Debug.Log($"{name} button pressed");
    }
}
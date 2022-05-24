using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
    private Text _textField;
    public LocalizedTextKey key;

    private void OnEnable()
    {
        _textField = GetComponent<Text>();
        UpdateText();
        Localization.Instance.OnLanguageChanged += UpdateText;
    }

    private void OnDisable() => Localization.Instance.OnLanguageChanged -= UpdateText;

    private void UpdateText()
    {
        string value = Localization.Instance.GetText(key.key);
        _textField.text = value;
    }
}
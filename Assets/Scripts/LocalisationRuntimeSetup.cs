using UnityEngine;
using UnityEngine.UI;

public class LocalisationRuntimeSetup : MonoBehaviour
{
    [SerializeField] private InputField _inputField;

    private void OnEnable()
    {
        _inputField.text = Localization.Instance.CurrentLanguage;
        _inputField.onEndEdit.AddListener(UpdateLanguage);
    }

    private void OnDisable() => _inputField.onEndEdit.RemoveListener(UpdateLanguage);

    private void UpdateLanguage(string newLanguage)
    {
        Localization.Instance.SetLanguage(newLanguage);
    }
}
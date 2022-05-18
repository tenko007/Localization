using System;
using UnityEngine;

public class LocalisationMonoSetup : MonoBehaviour
{
    [SerializeField] private string currentLanguage = "English";

    private void Start()
    {
        Localization.Instance.SetLanguage(currentLanguage);
    }
    
}
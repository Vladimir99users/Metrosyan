using UnityEngine.Localization.Settings;
using UnityEngine;
using System.Collections;

public class LocalizationButton : MonoBehaviour
{
    private bool active = false;
    private int currentLanguage = 0;

    public void ChangeLocale()
    {
        if(active == true) return;

        currentLanguage ++;

        if(currentLanguage >= LocalizationSettings.AvailableLocales.Locales.Count) 
        {
            currentLanguage = 0;
        }
        
        StartCoroutine(SetLocale(currentLanguage));
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
}

using UnityEngine.Localization.Settings;
using UnityEngine;

public class LocalizationTextFile<T> : ScriptableObject  where T : ScriptableObject
{
    [SerializeField] private T _localizationRu;
    [SerializeField] private T _localizationEng;
    public T GetTextFile()
    {
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            return _localizationRu;
        } else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            return _localizationEng;
        }
        return _localizationRu;
    }
}

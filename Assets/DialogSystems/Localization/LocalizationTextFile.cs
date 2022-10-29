using UnityEngine.Localization.Settings;
using UnityEngine;

public class LocalizationTextFile<T> : ScriptableObject  where T : ScriptableObject
{
    [SerializeField] private T _localizationRu;
    [SerializeField] private T _localizationEng;
    public T GetText()
    {
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            return _localizationEng;
        } else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            return _localizationRu;
        }
        Debug.LogError("Нет такой локализации!");
        return _localizationEng;
    }
}

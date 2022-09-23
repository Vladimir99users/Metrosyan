using UnityEngine.Localization.Settings;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation List", menuName = "Conversation/Localization")]
public class LocalizationConversation : ScriptableObject
{
    [Header("Русский диалог")][SerializeField] private Conversation _RUConversation;
    [Header("Английский диалог")][SerializeField] private Conversation _ENGConversation;

    public Conversation GetConversation()
    {
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            return _RUConversation;
        } else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            return _ENGConversation;
        }
        return _RUConversation;
    }
}

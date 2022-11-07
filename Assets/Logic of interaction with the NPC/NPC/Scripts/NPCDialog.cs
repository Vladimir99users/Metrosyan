using UnityEngine;
using DialogSystem;
public class NPCDialog : MonoBehaviour, ICanTalk
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private GiveQuest _giveQuest => GetComponent<GiveQuest>();

    public virtual void StartTalk()
    {
        _dialog.Initialize();
        _dialog.StartDialog();
        _giveQuest.SendMessageIntheWorld();
    }
    public virtual void EndTalk()
    {
        ViewDialog.OnCloseConfigurationDialog?.Invoke();
    }
}

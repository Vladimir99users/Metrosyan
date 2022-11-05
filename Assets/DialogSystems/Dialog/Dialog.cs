using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DialogControl
{
    using Item;

    [CreateAssetMenu(fileName = "Dialog", menuName = "Conversation/Dialog")]
    public class Dialog : ScriptableObject, ICanTalk
    {
        [Header("Последовательность диалогов")]
        [SerializeField] private  List<LocalizationTextFile<Conversation>> _conversation ;
        private int indexConvarsation = 0;

        [Header("Настройки диалога")]
        [Space]
        public DialogueIsStarted OnDialogStarted;
        public DialogueIsEnd OnDialogEnd;

        public List<LocalizationTextFile<Conversation>> Conversation
        {
            get
            {
                if(_conversation is null) Debug.LogError("НЕТ ДИАЛОГА ДЕНИС БЛЯДЬ");
                return _conversation;
            }
            set
            {
                Conversation = _conversation;
            }
        }

        public void Initialize()
        {
            indexConvarsation = 0;
        }

        public void StartDialog()
        {
            throw new System.NotImplementedException();
        }
        private void StartСonversation(int index)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversation[index].GetText());        
        }

        
    }

    public class DialogueIsStarted : UnityEvent<Dialog> { }
    public class DialogueIsEnd : UnityEvent<Dialog> { }

}

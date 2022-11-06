using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DialogSystem
{
    using Item;

    [CreateAssetMenu(fileName = "Dialog", menuName = "Conversation/Dialog")]
    public class Dialog : ScriptableObject, ICanTalk
    {
        [Header("Последовательность диалогов")]
        [SerializeField] private  List<LocalizationTextFile<Conversation>> _conversation ;
        public int IDConversation {get;set;}

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
            IDConversation = 0;
        }

        public void StartDialog()
        {
            StartСonversation(IDConversation);
        }
        private void StartСonversation(int index)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversation[index].GetText());        
        }
    }

    public class DialogueIsStarted : UnityEvent<Dialog> { }
    public class DialogueIsEnd : UnityEvent<Dialog> { }

}

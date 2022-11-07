using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DialogSystem
{
    using Item;

    [CreateAssetMenu(fileName = "Dialog", menuName = "Conversation/Dialog/dialog")]
    public class Dialog : ScriptableObject
    {
        [Header("Последовательность диалогов")]
        [SerializeField] private  List<LocalizationTextFile<Conversation>> _conversation ;
        public int IDConversation {get;set;}
        public virtual void Initialize()
        {
            IDConversation = 0;
        }
        public virtual void StartDialog()
        {
            StartСonversation(IDConversation);
        }
        private void StartСonversation(int index)
        {
            ViewDialog.OnStartConfigurationDialog?.Invoke(_conversation[index].GetText());     
        }
        private void NextConversation()
        {
            IDConversation = IDConversation + 1;
        }
    }

}

using UnityEngine;
using UnityEngine.Events;

namespace RemakeQuest
{
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] private string _nameQuest;
        [SerializeField] private string _descriptionQuest;
        [SerializeField] private Reward _reward = new Reward();

        public string NameQuest => _nameQuest;
        public string DescriptionQuest => _descriptionQuest;
        public Reward Reward => _reward;

        internal  UnityEvent OnCompleteQuest ;
        public bool _isCompleted {get; protected set;}
        protected bool _isGive = false;
        
        public void ResetQuest()
        {
            _isGive = false;
        }

        public bool TryGive()
        {
            return !_isGive;
        }
        public virtual void InitializationQuest()
        {
            if(TryGive())
            {
                _isGive = true;
                Debug.Log("Quest Init = " + _nameQuest);
                _isCompleted = false;
                RemakeQuest.QuestViewer.OnAddQuestViwer?.Invoke(this);
                OnCompleteQuest.AddListener(TryDone);  
            } else 
            {
                return;
            }    
        }

        public virtual void CompleteQuest()
        {
            _isCompleted = true;
            OnCompleteQuest?.Invoke();
        }

        protected virtual void TryDone()
        {
            if(_isCompleted)
            {
                Debug.Log("Quest complete = " + _nameQuest);
                RemakeQuest.QuestViewer.OnRemoveQuestViwer?.Invoke();
                OnCompleteQuest.RemoveAllListeners();
            } 
        }


    }
}


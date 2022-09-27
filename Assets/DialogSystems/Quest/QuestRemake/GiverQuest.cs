using UnityEngine;


namespace RemakeQuest
{
    public class GiverQuest : MonoBehaviour
    {
        private RemakeQuest.Quest _currentQuest;

        public virtual void InitQuestToPlayer(RemakeQuest.Quest _quest)
        {
            _currentQuest = _quest;
            Debug.Log("Quest = " + _currentQuest.NameQuest);
            _quest.InitializationQuest(); 
        }
        public void CompleteQuestGiver()
        {
            if(_currentQuest is null) return;
            _currentQuest.CompleteQuest(); 
        }
    }
}


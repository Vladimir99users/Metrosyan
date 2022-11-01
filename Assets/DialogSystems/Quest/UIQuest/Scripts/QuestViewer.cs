
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;



namespace Quest.UI
{
    public class QuestViewer : MonoBehaviour
    {   
       
        [SerializeField] private RectTransform _parent;
        [SerializeField] private UIQuest _questUI;


        public static UnityAction<Quest> OnAddorUpdateQuestViewer;
        public static UnityAction<Quest> OnRemoveQuestViewer;

        // не верный словарь! нужно через UIQuestGoal

        private Dictionary<Quest,UIQuest> _questDictionary = new Dictionary<Quest, UIQuest>();

        private void OnEnable()
        {
            OnRemoveQuestViewer += RemoveQuest;
            OnAddorUpdateQuestViewer += AddQuest;
        }

        private void OnDisable()
        {
            OnRemoveQuestViewer -= RemoveQuest;
            OnAddorUpdateQuestViewer -= AddQuest;
        }

        private void AddQuest(Quest _quest)
        {
            if(_questDictionary.ContainsKey(_quest) == false)
            {
                var item = Instantiate(_questUI,_parent);
                item.Initialize(_quest.Info._nameQuest, _quest.Goals[_quest.ID],true);
                _questDictionary.Add(_quest,item);
            } else 
            {
                _questDictionary[_quest].Initialize(_quest.Info._nameQuest, _quest.Goals[_quest.ID],false);
            }
        }

        private void RemoveQuest(Quest _quest)
        {
            Destroy(_questDictionary[_quest].gameObject);
            
            _questDictionary.Remove(_quest);
            Debug.Log("I am Destroy quest, осталось квестов = " + _questDictionary.Count);
        }



    }
}


using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;


namespace Quest.UI
{
    public class QuestViewer : MonoBehaviour
    {   
        [SerializeField] private UIQuestGoal _visualQuestGoal;
        [SerializeField] private TextMeshProUGUI _nameQuest;
        [SerializeField] private RectTransform _parent;



        public static UnityAction<Quest> OnAddorUpdateQuestViewer;
        public static UnityAction<Quest> OnRemoveQuestViewer;

        // не верный словарь! нужно через UIQuestGoal

        private Dictionary<Quest,Quest.QuestGoal> _questDictionary = new Dictionary<Quest, Quest.QuestGoal>();

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
            if(_questDictionary.ContainsKey(_quest))
            {
                _questDictionary[_quest] = _quest.Goals[_quest.ID];
                UpdateInformationGoal(_quest.Goals[_quest.ID]);
            } else 
            {
                _questDictionary.Add(_quest,_quest.Goals[_quest.ID]);
                UpdateInformationQuest(_quest);
            }
        }
        private void RemoveQuest(Quest _quest)
        {
            _questDictionary.Remove(_quest);
        }

        private void UpdateInformationQuest(Quest _quest)
        {
            _nameQuest.text = _quest.Info._nameQuest;
            UpdateInformationGoal(_quest.Goals[_quest.ID]);
        }

        private void UpdateInformationGoal(Quest.QuestGoal _goal)
        {
            var goal = Instantiate (_visualQuestGoal,_parent);
            goal.Init(_goal._description.GetText().Description, _goal._sprite);
        }


    }
}

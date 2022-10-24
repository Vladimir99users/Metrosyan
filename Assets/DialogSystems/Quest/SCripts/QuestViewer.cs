using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Quest
{
    public class QuestViewer : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI _description;
        public static UnityAction<Quest> OnAddQuestViewer;
        public static UnityAction OnRemoveQuestViewer;

        private Dictionary<Quest,List<Quest.QuestGoal>> _questDictionary = new Dictionary<Quest, List<Quest.QuestGoal>>();

        private void OnEnable()
        {
            OnRemoveQuestViewer += RemoveQuest;
            OnAddQuestViewer += ViewQuest;
        }

        private void OnDisable()
        {
            OnRemoveQuestViewer -= RemoveQuest;
            OnAddQuestViewer -= ViewQuest;
        }

        private void ViewQuest(Quest _quest)
        {
            _description.text = _quest.Info._descriptionQuest;
            UpdateInformationQuest();
        }
        private void RemoveQuest()
        {
            _description.text = string.Empty;
            UpdateInformationQuest();
        }

        private void UpdateInformationQuest()
        {
            
        }


    }
}

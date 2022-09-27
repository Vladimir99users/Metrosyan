using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace RemakeQuest
{
    public class QuestViewer : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI _description;
        public static UnityAction<RemakeQuest.Quest> OnAddQuestViwer;
        public static UnityAction OnRemoveQuestViwer;

        private void OnEnable()
        {
            OnRemoveQuestViwer += RemoveQuest;
            OnAddQuestViwer += ViewQuest;
        }

        private void OnDisable()
        {
            OnRemoveQuestViwer -= RemoveQuest;
            OnAddQuestViwer -= ViewQuest;
        }

        private void ViewQuest(RemakeQuest.Quest _quest)
        {
            _description.text = _quest.DescriptionQuest;
        }
        private void RemoveQuest()
        {
            _description.text = string.Empty;
        }


    }
}

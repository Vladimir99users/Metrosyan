using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Quest
{
    public class QuestViewer : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI _description;
        public static UnityAction<global::Quest.Quest> OnAddQuestViwer;
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

        private void ViewQuest(global::Quest.Quest _quest)
        {
            _description.text = _quest.Info._descriptionQuest;
        }
        private void RemoveQuest()
        {
            _description.text = string.Empty;
        }


    }
}

using TMPro;
using UnityEngine;


namespace Quest.UI
{
    public class UIQuest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textNameQuest;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private UIQuestGoal _visualQuestGoal;



        public void Initialize(string name, Quest.QuestGoal goal, bool onCreateObject) 
        {
            if(onCreateObject == true)
            {
                CreatGoalObject(goal);
            }
            

            _textNameQuest.text = name;
            UIQuestGoal currentgoal = GetComponentInChildren<UIQuestGoal>();
            currentgoal.Init(goal._description.GetText().Description, goal._sprite);
        }

        private void CreatGoalObject(Quest.QuestGoal goal)
        {
            var goals = Instantiate (_visualQuestGoal,_parent);
            goals.Init(goal._description.GetText().Description, goal._sprite);
        }
    }
}

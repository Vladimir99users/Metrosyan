using UnityEngine;
namespace RemakeQuest
{
    public class QuestTalk : Quest.QuestGoal
    {
        public string Name;
        public override void Initialize()
        {
            base.Initialize();
            EventManadger.OnNPCTalk.AddListener(CompleteQuest);
        }

        public void CompleteQuest(string name)
        {
            if(Name == name)
            {
                Debug.Log("I talk with " + name);
                Evaluate();
            }
        }

        protected override void Evaluate()
        {
            EventManadger.OnNPCTalk.RemoveListener(CompleteQuest);
            _currentAmount++;
            base.Evaluate();
        }
    }
}
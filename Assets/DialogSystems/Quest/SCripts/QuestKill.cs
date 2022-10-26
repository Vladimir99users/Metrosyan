using UnityEngine;


namespace Quest.Goal
{
    public class QuestKill : Quest.QuestGoal
    {
        [SerializeField] private EnemyType _type;

        public override void Initialize()
        {
            base.Initialize();

            EventManadger.OnKillSendMessage.AddListener(CompleteQuest);
        }

        public void CompleteQuest(EnemyType type)
        {
            if(_type == type)
            {
                Debug.Log(string.Format("Плюс один дракон с типом {0}",type));
                Evaluate();
            }
        }

        protected override void Evaluate()
        {
           
            _currentAmount++;
            if(_currentAmount >= _requiredAmount)  EventManadger.OnKillSendMessage.RemoveListener(CompleteQuest);
            base.Evaluate();
        }
    }
}














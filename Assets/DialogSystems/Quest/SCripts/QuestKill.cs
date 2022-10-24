using UnityEngine;


namespace Quest.Goal
{
    public class QuestKill : Quest.QuestGoal
    {
        public EnemyType _type;

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("НУЖНА УБИТЬ ДРАКОНОВ С ТИПОМ " + _type.ToString() );
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
            base.Evaluate();
        }
    }
}














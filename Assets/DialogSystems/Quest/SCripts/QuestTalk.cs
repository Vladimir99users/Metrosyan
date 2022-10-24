using UnityEngine;

namespace  Quest.Goal
{
    public class QuestTalk : Quest.QuestGoal
    {
        public CreateNewNPC NPC;
        public override void Initialize()
        {
            base.Initialize();
            EventManadger.OnNPCTalk.AddListener(CompleteQuest);
        }

        public void CompleteQuest(CreateNewNPC npc)
        {
            if(NPC.Name == npc.Name)
            {
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
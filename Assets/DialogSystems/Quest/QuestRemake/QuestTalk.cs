using UnityEngine;
namespace RemakeQuest
{
    [CreateAssetMenu(fileName = "QuestTalk", menuName = "Quest/QuestTalk")]
    public class QuestTalk : Quest
    {
        protected override void TryDone()
        {
           base.TryDone();
        }
    }
}
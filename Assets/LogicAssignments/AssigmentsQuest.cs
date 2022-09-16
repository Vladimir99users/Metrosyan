using UnityEngine;
using UnityEngine.Events;

public class AssigmentsQuest : MonoBehaviour
{
    [SerializeField] private QuestDescription _quest;
    public UnityEvent<QuestDescription> Assignment;

    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Player>() != null)
        {    
            Quest.OnRemoveQuest(_quest);
        }
    }
}

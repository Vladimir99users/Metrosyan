using UnityEngine;
using UnityEngine.Events;

public class Assignments : MonoBehaviour
{
   public UnityEvent<Conversation> Assignment;
   [SerializeField] private Conversation _conversation;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {    
            Assignment?.Invoke(_conversation);   
              
            Destroy(gameObject);  

        }
    }
}

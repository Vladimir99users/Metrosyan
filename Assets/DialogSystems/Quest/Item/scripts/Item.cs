using UnityEngine;
using Quest.ItemConfiguration;

namespace Quest
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Configuration _configuration;
        public void Init()
        {
            Debug.Log("Создал объект в точке");
        }

        private void OnTriggerEnter(Collider Col)
        {
            if(Col.gameObject.TryGetComponent<Player>(out Player player) == false) 
            { 
                return;
            }
            EventManadger.SendDragItem(_configuration);
            DragItem();
        }

        private void DragItem()
        {
            Destroy(gameObject);
        }
    }
}

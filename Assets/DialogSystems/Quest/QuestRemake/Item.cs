using UnityEngine;
using UnityEngine.Events;
namespace RemakeQuest
{
    public class Item : MonoBehaviour
    {
        internal UnityEvent OnDragItem = new UnityEvent();

        public void Init()
        {
            OnDragItem.AddListener(DragItem);
        }
        private void OnDestroy()
        {
            OnDragItem.RemoveListener(DragItem);
        }

        private void OnTriggerEnter(Collider Col)
        {
            if(Col.gameObject.TryGetComponent<Player>(out Player player) == false) 
            { 
                return;
            }
             OnDragItem?.Invoke();
        }

        private void DragItem()
        {
            Destroy(gameObject);
        }
    }
}

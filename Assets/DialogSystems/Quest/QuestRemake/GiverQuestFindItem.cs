using UnityEngine;

namespace RemakeQuest
{
    public class GiverQuestFindItem : GiverQuest
    {
        [SerializeField] private QuestFindItem _findItem;
        [SerializeField] private Transform[] _dot;

        private void Start()
        {
            _findItem.ResetQuest();
        }

        public override void InitQuestToPlayer(RemakeQuest.Quest _quest)
        {
            if(_findItem.TryGive())
            {
                _findItem.InitializationQuest();
                InitItems();
            }
           
        }
        private void InitItems()
        {
            for(int i = 0; i < _dot.Length;i++)
            {
                Item item = Instantiate(_findItem.Item,_dot[i]);
                item.Init();
                item.OnDragItem.AddListener(PlayerDragItim);
            }
            
        }
        private void PlayerDragItim()
        {
            Debug.Log("Player find " + _findItem.Item.name);
            _findItem.IncreaseRequiredAmount();
        }
    }
}

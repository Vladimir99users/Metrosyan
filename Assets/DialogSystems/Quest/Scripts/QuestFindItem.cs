using UnityEngine;
using Quest.ItemConfiguration;

namespace Quest.Goal
{
    public class QuestFindItem : Quest.QuestGoal
    {
        [SerializeField] private Configuration _configuration;

        
        public override void Initialize() 
        {
            base.Initialize();
            _requiredAmount = _configuration.Points.Length;
            CreateItemIntheWorld();
            EventManadger.OnDragItem.AddListener(CompleteQuest);
        }

        private void CreateItemIntheWorld()
        {
            foreach (var point in _configuration.Points)
            {
                var item = Instantiate(_configuration.Item,point,Quaternion.identity);
                item.Init();
            }
            
        }

         public void CompleteQuest(Configuration item)
        {
            Debug.Log(_configuration.Item == item.Item);
            if(_configuration.Item == item.Item)
            {
                Evaluate();
            }
        }

        protected override void Evaluate()
        {
            _currentAmount++;

            if(_currentAmount >= _requiredAmount)
            {
                EventManadger.OnDragItem.RemoveListener(CompleteQuest);
            } 
            
            base.Evaluate();
        }
    }
}


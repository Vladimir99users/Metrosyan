using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RemakeQuest
{
    [CreateAssetMenu(fileName = "QuestFindItem", menuName = "Quest/QuestFindItem")]
    public class QuestFindItem : Quest
    {
        [SerializeField] private Item _item;
        [SerializeField] protected int _requiredAmount;
        [SerializeField] protected int _currentAmount;

        public Item Item => _item;
        public int RequiredAmount => _requiredAmount;
        public int CurrentAmount => _currentAmount;

        
        public override void InitializationQuest()
        {
            _currentAmount = 0;
            base.InitializationQuest();
        }

        public void IncreaseRequiredAmount()
        {
            _currentAmount++;
            Calculate();
        }
        private void Calculate()
        {
            if(_currentAmount >= _requiredAmount)
            {
                _isCompleted = true;
                TryDone();
            }
        }

        protected override void TryDone()
        {
            base.TryDone(); 
        }

    }
}

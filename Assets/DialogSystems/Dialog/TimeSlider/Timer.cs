using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.TimerSlider
{
    public class Timer : MonoBehaviour, ITimer
    {
        [Space] [Header("Найстрока таймера ответа")]
        [Tooltip("Время через которое, игрок перейдёт на следующий Node")]
        [SerializeField][Range(0,100)] private int _timeToThink = 5;
        [Tooltip("Если нужен таймер не раз в секунду")] 
        [SerializeField][Range(0f,2f)] private float _interval = 1;

        [Tooltip("Сколько секунд надо ждать (по умолчанию равна _interval)")] 
        [SerializeField] [Range(0f,2f)] private float _sumInterval = 1;

        [SerializeField] private Slider _timerSlider;



        public int TimerToThink { get => _timeToThink; }
        public float Interval { get => _interval; }
        public float SumInterval { get => _sumInterval;}

        private void OnEnable()
        {
            _timerSlider.maxValue = _timeToThink;
        }


        IEnumerator ITimer.CloseDialogPanel()
        {
            while(true)
            {
                if(_timerSlider.value == _timerSlider.minValue)
                {
                    yield return new WaitForSeconds(_interval);
                    StopAllCoroutines();
                }
                _timerSlider.value -= _sumInterval;
                yield return new WaitForSeconds(_interval);
            }  
        }

        IEnumerator ITimer.PausedToReply()
        {
            while(true)
            {
                if(_timerSlider.value == _timerSlider.minValue)
                {
                    yield return null;
                }
                _timerSlider.value -= _sumInterval;
                yield return new WaitForSeconds(_interval);
            }
        }

        void ITimer.ResetTimeSlider()
        {
             _timerSlider.value = _timerSlider.maxValue;
        }
    }
}

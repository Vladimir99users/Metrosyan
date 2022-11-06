using System.Collections;
namespace DialogSystem.TimerSlider
{
    interface ITimer
    {
        int TimerToThink{get;}
        float Interval{get;}
        float SumInterval {get;}

        IEnumerator CloseDialogPanel();
        IEnumerator PausedToReply();
        void ResetTimeSlider();
    }
}


using UnityEngine.Events;
using Quest.ItemConfiguration;
public class EventManadger
{
    public static UnityEvent<CreateNewNPC> OnNPCTalk = new UnityEvent<CreateNewNPC>();
    public static UnityEvent<EnemyType> OnKillSendMessage = new UnityEvent<EnemyType>();
    public static UnityEvent OnComletedMessegaQuest = new UnityEvent();

    public static UnityEvent<Configuration> OnDragItem = new UnityEvent<Configuration>();
    public static void SendWithNPC(CreateNewNPC nameNPC)
    {
        OnNPCTalk?.Invoke(nameNPC);
    }

    public static void SendMessageKillEnemy(EnemyType type)
    {
        OnKillSendMessage?.Invoke(type);
    }
    public static void SendComletedMessageQuest()
    {
        OnComletedMessegaQuest?.Invoke();
    }

    public static void SendDragItem(Configuration item)
    {
        OnDragItem?.Invoke(item);
    }

}







/*
private static readonly List<Action<T>> _listeners = new List<Action<T>>();

   private static T _currentInfoState;


   public static void AddListener(Action<T> listener, bool instantNotify)
   {
        _listeners.Add(listener);

        if(instantNotify == true && _currentInfoState != null)
        {
            listener?.Invoke(_currentInfoState);
        }
   }

   public static void RaiseRegistrationInfo(T state)
   {
        _currentInfoState = state;
        foreach (var listener in _listeners)
        {
            listener?.Invoke(state);
        }
   }

   public static void RemoveListener(Action<T> listener)
   {
        if(_listeners.Contains(listener))
        {
            _listeners.Remove(listener);
        }
   }


*/
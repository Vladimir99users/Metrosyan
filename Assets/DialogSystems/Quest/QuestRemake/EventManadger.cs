using System;
using System.Collections.Generic;
using UnityEngine.Events;
public class EventManadger
{
   public static UnityEvent<string> OnNPCTalk = new UnityEvent<string>();
    public static void SendWithNPC(string nameNPC)
    {
        OnNPCTalk?.Invoke(nameNPC);
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
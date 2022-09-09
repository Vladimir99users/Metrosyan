using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimatorCreature : MonoBehaviour
{
    private CreatureHealth _health => GetComponent<CreatureHealth>();
    private Animator _animator => GetComponent<Animator>();

    public static Action<StateCreature> _onStateCreature;

    private void OnEnable()
    {
        _onStateCreature += AnimatorState;
    }
    private void OnDisable()
    {
        _onStateCreature -= AnimatorState;
    }
    private void AnimatorState(StateCreature state)
    {
        switch (state)
        {
            case StateCreature.Walking:
                _animator.SetTrigger("Move");
                break;
            case StateCreature.Idle:
                _animator.SetTrigger("Idle");
                break;
            case StateCreature.Attacked:
                _animator.SetTrigger("Attacked");
                break;
             case StateCreature.Damage:
                _animator.Play("Witch_Damage");
                break;
             case StateCreature.Die:
                  _animator.SetBool("IsDie",true);
                  GetComponent<Player>().DisableAllAction();
                  break; 
            default: Debug.LogError("None trigger");
            break;
        }
    }
}

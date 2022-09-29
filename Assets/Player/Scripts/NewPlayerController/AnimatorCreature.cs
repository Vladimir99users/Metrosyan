using UnityEngine;
using System;

public class AnimatorCreature : MonoBehaviour
{
    private CreatureHealth _health => GetComponent<CreatureHealth>();
    private Animator _animator => GetComponent<Animator>();

    public static Action<StateCreature> _onStateCreature;
    public static Action<float> SpeedChanged;


    private void OnSpeedChanged(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

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
                _animator.ResetTrigger("Idle");
                break;
            case StateCreature.Idle:
                _animator.SetTrigger("Idle");
                _animator.ResetTrigger("Move");
                break;
            case StateCreature.Attacked:
                _animator.SetTrigger("Attacked");
                break;
             case StateCreature.Damage:
                _animator.Play("Witch_Damage");
                break;
             case StateCreature.Die:
                  _animator.SetBool("IsDie",true);
                  break;
            case StateCreature.Alive:
                _animator.SetBool("IsDie", false);
                break;
            default: Debug.LogError("None trigger");
            break;
        }
    }
}

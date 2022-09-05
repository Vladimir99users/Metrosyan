using System;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class Player : MonoBehaviour
{
    protected  CharacterController Controller => GetComponent<CharacterController>();  // s   
    protected Animator _animator => GetComponent<Animator>();
    
    [Header("Настройка игрока")]
    [SerializeField] [Range(0,30)]protected float SpeedPlayer = 10;
    [SerializeField] [Range(0,10)] protected float PlayerHeight = 3;
    [SerializeField] protected float GroundDistance = 0.8f;
    [SerializeField] protected float _gravity = -9.81f * 2f;

    [Space]
    [Header("Основные части игрока")]
    [SerializeField] protected  Transform _playerBody; //
    [SerializeField] protected  Transform Groundcheck;
    [SerializeField] protected  LayerMask GroundMask;
    [SerializeField] protected  Transform _pointCreatMagic ; 
    [SerializeField] protected Camera _camera;

    //=========== Дополнительные переменные===============
    [HideInInspector] protected Vector3 Velocity ; // ускорение для прыжка и гравитации
    [HideInInspector] protected bool IsGrounded ; // провека на землю

    [HideInInspector] protected float ZeroPointerVelocity = -2f; // нужно для того, что бы задать игроку минимум, за который он не сможет упасть
   // public abstract void CreatMagic(Magic _magic, Vector3 point);
    public abstract void MovePlayer(Vector2 move);
    public abstract void Fire(InputAction.CallbackContext context);
    public abstract void VisibilityMenu(InputAction.CallbackContext context);
    public abstract void VisibilityRadialMenu(InputAction.CallbackContext context);

}


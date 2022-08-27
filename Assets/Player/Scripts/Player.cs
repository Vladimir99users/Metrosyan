using UnityEngine;

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

    //=========== Дополнительные переменные===============
    [HideInInspector] protected Vector3 Velocity ; // ускорение для прыжка и гравитации
    [HideInInspector] protected bool IsGrounded ; // провека на землю
    [HideInInspector] protected float ZeroPointerVelocity = -2f; // нужно для того, что бы задать игроку минимум, за который он не сможет упасть
   // public abstract void CreatMagic(Magic _magic, Vector3 point);
    protected abstract void MovePlayer();

}


    /*
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-10,10);

        //transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //transform.Rotate(Vector3.up * mouseX);
        Vector3 newVecotrLook = new Vector3(mouseX,mouseY,0);
       
        transform.Rotate(Vector3.up,mouseY *50f* Time.deltaTime);
    */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PlayerControllerSpace
{
    sealed class Player_ThirdCamera : Player
    {
  
        private readonly float MOVE_ZERO = 0f;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Menu _menu;

        private  Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        private void Update()
        {
            OnMouseDragPosition();
            GravityPlayer();
        }

        public override void MovePlayer(Vector2 move)
        {   
           var newMove = transform.right * move.x + transform.forward * move.y;
           if(newMove.x != MOVE_ZERO || newMove.z != MOVE_ZERO) _animator.Play("Witch_Walk");
           else _animator.Play("Witch_Wait");
            Controller.Move(newMove * SpeedPlayer * Time.deltaTime);
        }

        public override void Fire(InputAction.CallbackContext context)
        {
            var MagicBullet = Instantiate(_bullet,_pointCreatMagic.position,Quaternion.identity);
            var point = OnMouseDragPosition();
            point.y = _pointCreatMagic.position.y;
            MagicBullet.gameObject.GetComponent<Rigidbody>().velocity = (point - _pointCreatMagic.position).normalized * 30f;
            Destroy(MagicBullet.gameObject,3f);
        }

        public override void VisibilityMenu(InputAction.CallbackContext context)
        {
            Debug.Log("Close Craft Menu");
            _menu.Close();
        }
        public override void VisibilityRadialMenu(InputAction.CallbackContext context)
        {
            Debug.Log("Open Radial Menu");
            
        }
        private  void GravityPlayer()
        {   
             if(IsGrounded && Velocity.y < 0)
             {
                 Velocity.y = ZeroPointerVelocity;

             } 
             // гравитация delta y = 1/2 * g * t^2;
             Velocity.y += _gravity * Time.deltaTime;  
             Controller.Move(Velocity * Time.deltaTime);  
        }

        private Vector3 OnMouseDragPosition()
        {
            Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
            if(groundPlane.Raycast(cameraRay,out float rayLenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
                Debug.DrawLine(cameraRay.origin,pointToLook,Color.black);
                LookPlayer(pointToLook);
                return pointToLook;
            }
            return new Vector3();
        }

        private void LookPlayer(Vector3 look)
        {
            _playerBody.LookAt(new Vector3(look.x,transform.position.y,look.z));
        }


    }
}


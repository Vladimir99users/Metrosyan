using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllerSpace
{
    sealed class Player_ThirdCamera : Player
    {
  

        private void Update()
        {
            LookMouse();
            GravityPlayer();
        }
        private void FixedUpdate()
        {
             MovePlayer();
        }

        private void LookMouse()
        {
                //получение позиции мышки для просчёта вектора поворота
            float mouseX = Input.GetAxis("Mouse X") * 300f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * 300f * Time.deltaTime;

            _playerBody.transform.Rotate(Vector3.up * mouseX);
        }

        protected override void MovePlayer()
        {
            _animator.Play("Witch_Walk");
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var move = transform.right * x + transform.forward * z;
            Controller.Move(move * SpeedPlayer * Time.deltaTime);
        }


       /* public override void CreatMagic(Vector3 point)
        {
            var MagicBullet = Instantiate(_magic,_pointCreatMagic.position,Quaternion.identity);
            point.y = _pointCreatMagic.position.y;
            MagicBullet.gameObject.GetComponent<Rigidbody>().velocity = (point - _pointCreatMagic.position).normalized * 30f;
            Destroy(MagicBullet.gameObject,3f);
        }*/
        private  void GravityPlayer()
        {   
             // без этого условия позиция игрока будет уходить в минус всегда
             // поэтому если нужно упасть с высоты, он сразу окажется на большей позиции чем должен был быть.
             // к примеру, он находится на позиции y = 0, а velocity уменьшается всегда,
             // то при падении игрок резко перескочит на позиции velocity     
             if(IsGrounded && Velocity.y < 0)
             {
                 Velocity.y = ZeroPointerVelocity;

             } 
             // гравитация delta y = 1/2 * g * t^2;
             Velocity.y += _gravity * Time.deltaTime;  
             Controller.Move(Velocity * Time.deltaTime);  
        }

    }
}


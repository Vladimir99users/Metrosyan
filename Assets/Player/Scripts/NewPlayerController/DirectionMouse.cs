using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMouse : MonoBehaviour
{
    private  Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    public Vector3 GetDirectionMouseRotation(Vector3 mouse)
    {
        Ray cameraRay = _mainCamera.ScreenPointToRay(mouse);
        if(groundPlane.Raycast(cameraRay,out float rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            return new Vector3(pointToLook.x,transform.position.y,pointToLook.z);
          
        }
        return new Vector3();
    }
}

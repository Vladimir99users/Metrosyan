using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMouse : MonoBehaviour
{
    private  Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
    public Vector3 DirectionMouseRotation(Vector3 mouse)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(mouse);
        if(groundPlane.Raycast(cameraRay,out float rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin,pointToLook,Color.red);
            return new Vector3(pointToLook.x,transform.position.y,pointToLook.z);
          
        }
        //Debug.LogError("Directions Mouse NONe");
        return new Vector3();
    }
}

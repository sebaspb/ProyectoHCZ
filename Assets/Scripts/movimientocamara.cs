using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientocamara : MonoBehaviour {

    //We create 2 variables that will control the position of the mouse in the x and the y axis.
    float mouseX;
    float mouseY;
    //We create a bool that control the inverted mouse option, in case the movement is inverted.
    public bool invertirmouse = false;
	
	void Update () {
        //We create a new gameobject called camera with the gameobject with the MainCamera Tag
        GameObject camera = GameObject.FindWithTag("MainCamera");
        //We create a new gameobject called hero with the gameobject with the Hero Tag
        GameObject Hero = GameObject.FindGameObjectWithTag("Hero");

        //We assign the variables that will control the mouse movement with their different characteristics.
        //To the mouseX variable we add the mouse movement on the X axis
        mouseX += Input.GetAxis("Mouse X");
        //To the mouseX variable we add the mouse movement on the Y axis
        mouseY += Input.GetAxis("Mouse Y");
        //We limit the movement into the Y axis so the camera only can moves between that range.
        mouseY = Mathf.Clamp(mouseY, -45.0f, 45.0f);

        //The current status of the invert bool is confirmed and motion is assigned to the camera as required
        if (invertirmouse)
        {
            //The camera angle is modified with the values of the mouse.
            camera.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        }

        if (!invertirmouse)
        {
            //The camera angle is modified with the values of the mouse, but the Y axis works inverted.
            camera.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
        }

        /*The movement of the hero is assigned exactly with the same movement of the camera, however it is limited to the Y axis.
          This is done in order to prevent the hero from moving vertically when the camera is moved in that direction.*/
          Hero.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}

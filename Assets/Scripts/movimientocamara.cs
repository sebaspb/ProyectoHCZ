using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientocamara : MonoBehaviour {

    float mouseX;
    float mouseY;
    public bool invertirmouse = false;

   
   

    void Start () {
       
    }
	
	void Update () {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        GameObject Hero = GameObject.FindGameObjectWithTag("Hero");
        //Se asignan las variables que controlaran el movimiento del mouse con sus diferentes características.
        mouseX += Input.GetAxis("Mouse X");//A la variable mouseX se le suma el moviento de mouse en el eje X
        mouseY += Input.GetAxis("Mouse Y");//A la variable mouseY se le suma el movimiento de mouse en el eje Y
        mouseY = Mathf.Clamp(mouseY, -45.0f, 45.0f);//Ésto hace que Mouse Y tenga un valor máximo en el que puede moverse y un valor mínimo


        //Se confirma el estado actual del bool invertirmouse y se asigna el movimiento a la cámara según sea necesario
        if (invertirmouse)
        {

            camera.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);//Éste consulta individualmente


        }

        if (!invertirmouse)
        {

            camera.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);//Éste consulta individualmente

        }

        //Se asigna el movimiento del héroe exactamente con el mismo movimiento de la cámara, sin embargo se limita al eje Y.
        //Ésto se hace con el fin de evitar que el heroe se desplaze verticalmente cuando se mueve la cámara en ésta dirección.
        Hero.transform.eulerAngles = new Vector3(0, mouseX, 0);


    }
}

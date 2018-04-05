using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Player
{
	
	//GameObject go = Instantiate(HI) as GameObject;
	//go.AddComponent<Movimie>();

	public class NewHero
	{
		public static void CreatePlayer()
		{

			GameObject Player = GameObject.CreatePrimitive(PrimitiveType.Cube);
			Player.transform.position = new Vector3(9,0.5f,5);
			Player.tag = "Player";
			Player.name = "Player";
			
		}
	} 


	public class Main
	{
		public static void CameraParented()
		{
			
			GameObject Player = GameObject.CreatePrimitive(PrimitiveType.Cube);
			Player.tag = "Player";
			Player.name = "Player";

			GameObject Camera = GameObject.FindWithTag("MainCamera");
			Camera.transform.SetParent(Player.transform,false);		
        
		}

	}

	public class Movement
	{
		
		public static void MovementPlayer(float mouseX, float mouseY)
		{

			float speed = Random.Range(1,100); 
			bool invertirmouse = false;
			GameObject Player = GameObject.CreatePrimitive(PrimitiveType.Cube);
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			mouseX += Input.GetAxis("Mouse X");//A la variable mouseX se le suma el moviento de mouse en el eje X
        	mouseY += Input.GetAxis("Mouse Y");//A la variable mouseY se le suma el movimiento de mouse en el eje Y
        	mouseY = Mathf.Clamp(mouseY, -45.0f, 45.0f);//Ésto hace que Mouse Y tenga un valor máximo en el que puede moverse y un valor mínimo

			 if (Input.GetKey("w"))
        	{
           
           		Player.transform.position += Player.transform.forward * speed;

        	}

      		if (Input.GetKey("s"))
        	{
           
           		Player.transform.position -= Player.transform.forward * speed;

       		 }

        	if (Input.GetKey("a"))
        	{
            
            	Player.transform.position -= Player.transform.right * speed;

        	}

        	if (Input.GetKey("d"))
        	{
    
           	 Player.transform.position += Player.transform.right * speed;

        	}

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
        	Player.transform.eulerAngles = new Vector3(0, mouseX, 0);

		}

	}	

	
	private void Start () 
	{

		
		
	}
	
	
	private void Update () 
	{
		
	}
}

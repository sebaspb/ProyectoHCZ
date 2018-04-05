using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies 
{

	int trigger;
  
	public Zombies()
	{
        //Se crea una primitiva de tipo cubo en una posición aleatoria y se le asigna el nombre Zombie.
        GameObject Zombies = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Zombies.transform.position = new Vector3(Random.Range(100,450),0.5f, Random.Range(100,450));
        Zombies.name = "Zombie ";
       
        //Se asignan 3 valores posibles al desencadenante
        trigger = Random.Range(0,3);
        
        

		switch(trigger)
		{
            //En el caso uno, se le asigna el color cian al zombie y se muestra el mensaje correspondiente.
			case 0:
			Zombies.GetComponent<Renderer>().material.SetColor("_Color",Color.cyan);
                Debug.Log("Soy un zombie color Cian");

                break;
			case 1:
                //En el caso uno, se le asigna el color magenta al zombie y se muestra el mensaje correspondiente.

                Zombies.GetComponent<Renderer>().material.SetColor("_Color",Color.magenta);
                Debug.Log("Soy un zombie color Magenta");
                break;
			case 2:
                //En el caso uno, se le asigna el color verde al zombie y se muestra el mensaje correspondiente.

                Zombies.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
                Debug.Log("Soy un zombie color Verde");
                break;	

		}
		
	}
	void Start()
	{

		
		
				
	}
	
}

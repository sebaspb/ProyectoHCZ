using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Citizen
{


	public int edad;

	public Citizen(string n)
	{
        //se crea una primitiva de tipo capsula en un lugar aleatorio, y se asigna un valor aleatorio entre 15 y 100 a la edad 
        GameObject Citizen = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Citizen.transform.position = new Vector3(Random.Range(100, 450), 0.9f, Random.Range(100, 450));
        edad = Random.Range(15, 100);
		
	}
      
        //Se crea un string que almacenará los diferentes nombres posibles para los ciudadanos.
		public enum NameCitizen 
		{
			
			Jesús, 
			Sebastian,
			Alejandro, 
			Vicky , 
			Sophia, 
			Jorge, 
			Alberto,
			Ricardo, 
			Miguel,
			Sandra, 
			Andrea, 
			Sansa, 
			Arya, 
			Jaime, 
			Ana, 
			Victoria, 
			Esteban, 
			Augusto, 
			Ned, 
			David

        }

		public NameCitizen No;
        //Se crea un  para; que se ejecutará un número aleatorio de veces no mayor a la cantidad de datos ingresada en 
        //la lista de nombres.
		public void Assigner()
		{
			for(int i = 0; i < 21; i++)
			{
            //Se le asigna un nombre aleatorio al ciudadano
            NameCitizen No = (NameCitizen)Random.Range(0,21);
			
			}

        //Se muestra el mensaje en consola que muestra el nombre y la edad del ciudadano creado
        	
			
	}

	private void Start () 
	{
        



    }
	
	
	private void Update () 
	{
		
	}
	
}

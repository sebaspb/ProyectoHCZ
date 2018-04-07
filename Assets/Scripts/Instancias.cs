using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancias : MonoBehaviour 
{
   /*First a bool is created to check if the hero has already been assigned; this is to ensure that
   that only one hero be assigned.*/
    bool heroeasignado = false;

    /*We create a variable that will increase progressively, this is used to have an internal control of the total 
     *number of entities that are generated, in order to control and report in the event that more than 20 are generated.*/
    float totalentidades = 0;

    /*Start is called only once at the start*/
    private void Start () 
	{
      
        /*The bool heroeasginado is checked; if it's false we proceed to create the hero*/
        if (!heroeasignado) { 

            //We create a new primitive of the cube type.       
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //We assign a random position that goes from coords 100 to 450 in the x and z axis.
            //and a fixed position of 0.5 in the y axis, this is done so that the cube appears at ground level.
            Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));

            //We assign the name Heroe to the object name so it can be differenciable in the Hierarchy panel.
            Objeto.name = "Heroe";
            //We assign the tag Heroe to the object so it can be easily accesed later.
            Objeto.tag = "Hero";

            //We add de script Hero to the object, that script controls the collision messages.
            Objeto.AddComponent<Hero>();
            //We add de script movimiento to the object, that script controls the movement of the hero.
            Objeto.AddComponent<movimiento>();
            Objeto.AddComponent<movimientocamara>();
            Objeto.AddComponent<Rigidbody>();
            Objeto.GetComponent<Rigidbody>().isKinematic=true;
            Objeto.AddComponent<Hero>();


            GameObject Camera = GameObject.FindWithTag("MainCamera");
            Camera.transform.SetParent(Objeto.transform, false);
            Camera.transform.position = Objeto.transform.position;


            
            heroeasignado = true;
            totalentidades += 1;


        }

        int cantidad = Random.Range(10, 20);
        for (int a = 0; a < cantidad;) {

            int desencadenante = Random.Range(0, 2);
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
           Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));

            switch (desencadenante)
            {
            case 0:
            Objeto.name = "Ciudadano";
                    Objeto.tag = "Ciudadano";
                    Objeto.AddComponent<Rigidbody>();

                    Objeto.AddComponent<Citizen>();
            totalentidades += 1;
                    break;

            case 1:
            Objeto.name = "Zombie";
                    Objeto.tag = "Zombie";
                    Objeto.AddComponent<Rigidbody>();

                    Objeto.AddComponent<Zombies>();
            totalentidades += 1;

                    break;
            }
            a += 1;
        }

        if (totalentidades > 20)
        {

            print("<color=yellow>CUIDADO HAY MUCHAS ENTIDADES, EL TOTAL ES DE: " + totalentidades +"</color>");


        }

    }






}

    

   


  

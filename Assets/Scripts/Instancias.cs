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
            //We add the script Hero to the object, that script controls the collision messages.
            Objeto.AddComponent<Hero>();
            //We add the script movimiento to the object, that script controls the movement of the hero.
            Objeto.AddComponent<movimiento>();
            //We add the script movimientocamara to the object, that script controls the movement of the camera.
            Objeto.AddComponent<movimientocamara>();
            //We add a rigid body to the object so it can collide with other entities.
            Objeto.AddComponent<Rigidbody>();
            //We change the kinematic mode to true to fix a bug that made the hero tilt on the ground.
            Objeto.GetComponent<Rigidbody>().isKinematic=true;
            //We add the script hero to the object, so the collision messages can work as intended.
            Objeto.AddComponent<Hero>();

            //We create a new gameobject with the name camera and its equal to the object with the tag MainCamera.
            GameObject Camera = GameObject.FindWithTag("MainCamera");
            //We make the camera as a child of the hero object.
            Camera.transform.SetParent(Objeto.transform, false);
            //We transform the positiont to be the same as the hero object so both will be in the same position.
            Camera.transform.position = Objeto.transform.position;
            //We change the heroeasignado bool to true, so the hero won't be created again.
            heroeasignado = true;
            //The totalentidades values is increased by one.
            totalentidades += 1;
        }

        //We create a new int called cantidad that is a random number between 10 and 19, because the max number of the range
        //is exlusive.,
        int cantidad = Random.Range(10,20);
        //We create a for that goes from 0 to the value of the previous variable.
        for (int a = 0; a < cantidad;)
        {
            //We create a new gameobject with a primitive of the cube type.
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //We assign a random position that goes from coords 100 to 450 in the x and z axis.
            //and a fixed position of 0.5 in the y axis, this is done so that the cube appears at ground level.
            Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));

            //We create a new variable that can be 0 or 1 and a switch is created to work with those 2 values.
            int desencadenante = Random.Range(0, 2);
            switch (desencadenante)
            {
                //in the first case.
                case 0:
                    //We assign the name ciudadano to that object so it can be easily differenciable in the hierarchy panel
                    Objeto.name = "Ciudadano";
                    //We assign the tag ciudadano to that object so it can be easily accesed later.
                    Objeto.tag = "Ciudadano";
                    //We assign a rigidbody to that object so it can collide with the other entities.
                    Objeto.AddComponent<Rigidbody>();
                    //We assign the citizen script to that object so it behaviour as a citizen.
                    Objeto.AddComponent<Citizen>();
                    //We increase the number of total entities in one.
                    totalentidades += 1;
                break;

                case 1:
                    //We assign the name zombie to that object so it can be easily differenciable in the hierarchy panel
                    Objeto.name = "Zombie";
                    //We assign the tag zombie to that object so it can be easily accesed later.
                    Objeto.tag = "Zombie";
                    //We assign a rigidbody to that object so it can collide with the other entities.
                    Objeto.AddComponent<Rigidbody>();
                    //We assign the zombiez script to that object so it behaviour as a zombie.
                    Objeto.AddComponent<Zombies>();
                    //We increase the number of total entities in one.
                    totalentidades += 1;

                break;
            }
            //the a variable is increased by one and the for is repeted until the condition is meeted.
        a += 1;
        }

        //If the total of entities is bigger than 20 we will show a message in the console that informs that problem.
        //That message will appear with a yellow color so it's easily noticeable.
        if (totalentidades > 20)
        {
            print("<color=yellow>CUIDADO HAY MUCHAS ENTIDADES, EL TOTAL ES DE: " + totalentidades +"</color>");
        }
    }
}

    

   


  

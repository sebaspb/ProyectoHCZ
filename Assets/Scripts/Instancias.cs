using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Allied;
using UnityEngine.UI;
public class Instancias : MonoBehaviour 
{
    /*First a bool is created to check if the hero has already been assigned; this is to ensure that
    that only one hero be assigned.*/
    bool heroeasignado = false;

    //A real variable called Instantiated is created
    float Instanciado;

    //A public constant is created that is equal to 25
    public const float MAX = 25;

    /*We create a variable that will increase progressively, this is used to have an internal control of the total 
     *number of entities that are generated, in order to control and report in the event that more than 20 are generated.*/
    float totalentidades = 0;

    //A public Transform is created to occupy the space of the interface to display the number of zombies
    public Transform TextoZombies;

    //Se crea un componente texto para que se pueda colocar lo que hay en totalZombies
    public Text TextoZombie;

    //A public Transform is created to occupy the space of the interface to display the number of Citizen
    public Transform TextoCitizen;

    //Se crea un componente texto para que se pueda colocar lo que hay en totalZombies

    public Text TextoCitizens;

    //A list called Objects is created to save what is inside the foreach.

    public static List<GameObject> Objects = new List<GameObject>();

    /*Start is called only once at the start*/
    private void Start () 
	{
        //It is said that instanciado is equal to the random variable of the constructor new CubesN with the variable Num and its maximum will be the constant Max
        Instanciado = Random.Range(new CubesN().Num, MAX);
        //The bool heroeasginado is checked; if it's false we proceed to create the hero
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

            Objects.Add(Objeto);
        }

        //We create a new int called cantidad that is a random number between 10 and 19, because the max number of the range
        //is exlusive.,
        
       
        //We create a for that goes from 0 to the value of the previous variable.

        for (int a = 0; a < Instanciado;)
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
                    //All GameObjects called Objeto are added and saved in Objects
                    Objects.Add(Objeto);
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
                    //All GameObjects called Objeto are added and saved in Objects
                    Objects.Add(Objeto);
                break;
            }
                //the a variable is increased by one and the for is repeted until the condition is meeted.
                a += 1;
                 
        }
            //An integer variable called totalZombies is created that is equal to 0 that will store the total of zombies
            int totalZombies = 0;
            //An integer variable called totalCiudadanos is created that is equal to 0 that will store the total of Citizen
            int totalCiudadanos = 0;
            //A foreach is created that takes all GameObjects named ObjectsNum and puts them in the Objects list. 
            foreach(GameObject ObjectsNum in Objects)
            {
                //If the name of what is in ObjectsNum is equal to "Zombie" then...
                if(ObjectsNum.name == "Zombie")
                {
                    //To the value of totalZombies is added 1
                    totalZombies += 1;
                   

                }
                    
                if(ObjectsNum.name == "Ciudadano")
                {
                    //To the value of totalCiudadanos is added 1    
                    totalCiudadanos += 1;
                  

                }

            } 
            //Message displayed on the console to show the total number of zombies
            Debug.Log("El total de Zombies es " + totalZombies);
            //Message displayed on the console to show the total number of Citizens
            Debug.Log("El total de ciudadanos es " + totalCiudadanos);
            //The TextZombies transform with the Text component is equal to the totalZombies value and that becomes the String
            TextoZombies.GetComponent<Text>().text = totalZombies.ToString();
            //The TextZombies transform with the Text component is equal to the totalZombies value and that becomes the String
            TextoCitizen.GetComponent<Text>().text = totalCiudadanos.ToString();
        
            //El canvas de los mensajes de zombies y ciudadanos se hace llamando la lista creada en instancias en un foreach 
    }
    
}


public class CubesN
{
    //Variable that is used for read-only integer call only Num 
    public readonly int Num;

    //Builder
    public CubesN()
    {
        //It says here that Num equals a random range between 5 and 15
        Num = Random.Range(5,15);

    }

} 



    

   


  

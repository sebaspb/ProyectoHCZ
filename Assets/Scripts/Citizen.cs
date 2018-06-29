using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;


//This makes what is put in the script into a library.
namespace NPC
{
    //This makes what is put in the script into a library.
    namespace Allied
    {    
        public class Citizen : classNPC
        {
            //we create a new structure that will store the citizen information (age and name).

            public struct CitizenInformation
            {
                public int age;
                public CitizenName name;

            }

            //We create a new structure with the previous data called cInformation.
            public CitizenInformation cInformation;


            //We create a new enumerator that will store all the possible names for the citizen.
            public enum CitizenName
            {
      	        Jesús,
                Sebastian,
                Alejandro,
                Vicky,
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

            //This is done so that this class inherits from the method in the NPC class
            override public void Herent()
            {
                //This says the rotation speed ranges from 1 to 10.
                Rot = Random.Range(1, 10);
                //It says here to start what is in the Move method.
                Move();
                //The age of the civilians is added at random between 15 and 100 years of age.
                init.age = Random.Range(15, 100);
               

            }

            //This is done so that this class inherits from the method in the classNPC
            override public void test()
            {
                //It says here that for every GameObject called ObjectsTest that is in the Objects list in Instancias...
                foreach(GameObject ObjectsTest in Instancias.Objects)
                {
                    //If the object is with the Zombie tag    
                    if(ObjectsTest.CompareTag("Zombie"))
                    {
                        //Here you check the distance between the object in the list and the Zombie; if it is smaller at a distance(5) then...
                        if(Vector3.Distance( ObjectsTest.transform.position ,transform.position) < distancia)
                        {
                            //This causes the citizen to run from the Zombie in the opposite direction.
                            transform.position = Vector3.MoveTowards(transform.position, ObjectsTest.transform.position, -Speed);
                            //This is where the corutine that activates the states in classNPC
                            StopCoroutine(Movement());
                        }
                    }
                }       
            }

            //Here you create an object in Zombies(Citizen c)    
            public static implicit operator Zombies(Citizen c)
            {
                //Zombies z is the same as Citizen c to which the Zombies component is added.
                Zombies z = c.gameObject.AddComponent<Zombies>();
                //The name of object c equals Zombie.
                c.name = "Zombie";
                //We assign the tag zombie to that object so it can be easily accesed later.
                c.tag = "Zombie";
                //The object c(citizen) is destroyed
                Destroy(c);
                //returns Z for the citizen to become a complete zombie
                return z;
            }
           

            //Start is called only once.
            void  Start()
            {
                //In the age information of the structure we create a random number between 15 and 100;
                base.Herent();
                //We create a new int that is equal to the number of elements in the names enumerator.
                int nombres = CitizenName.GetNames(typeof(CitizenName)).Length;
                //In the name information of the structure we store a random name of the list between 0 and the previous number position.
                cInformation.name = (CitizenName)Random.Range(0, nombres);
                //Here it is said that the age in Citizen is equal to the age in the classNPC
                cInformation.age = init.age;
            }
        }
    }
}





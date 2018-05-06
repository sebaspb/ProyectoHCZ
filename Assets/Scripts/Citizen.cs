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

            override public void Herent()
            {

                Rot = Random.Range(1, 10);
                Move();
                init.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
               

            }

            override public void test()
            {

                foreach(GameObject ObjectsTest in Instancias.Objects)
                {

                    if(ObjectsTest.CompareTag("Zombie"))
                    {

                        if(Vector3.Distance( ObjectsTest.transform.position ,transform.position) < distancia)
                        {

                            transform.position = Vector3.MoveTowards(transform.position, ObjectsTest.transform.position, -Speed);
                            StopCoroutine(Movement());
                   
                        }

                    }

                }       

            }

            public static implicit operator Zombies(Citizen c)
            {

                Zombies z = c.gameObject.AddComponent<Zombies>();
                Destroy(c);
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
                cInformation.age = init.age;
            }


           
        }
    }
}





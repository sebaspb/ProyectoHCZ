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
                //public int mov;
                //public int rot;
                //public CComportamiento comportamiento;
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

 /*    public enum CComportamiento
    {
        idle,
        moving,
        rotating,
        pursuing,

    }

    int comportamiento = CComportamiento.GetNames(typeof(CComportamiento)).Length;
 */
     

   
            
           /*  void Update()
            {

                float speedRot = Random.Range(0.1f,1);
                //We check if the CComportamiento value is = to 1; in that case the citizen will move.
                //The assignation to that variable is in the coroutine.
                if(cInformation.comportamiento == (CComportamiento)1)
                {
                    //We start a switch with the mov vale that is assigned in the coroutine.
                    switch(cInformation.mov)
                    {
                        //In the first case the citizen will move forward.
                        case 0:
                            transform.Translate(Vector3.forward * Time.deltaTime);
                        break;

                        //In the second case the citizen will move backwards.
                        case 1:
                            transform.Translate(Vector3.back * Time.deltaTime);
                        break;

                         //In the third case the citizen will move to the right.
                        case 2:
                            transform.Translate(Vector3.right * Time.deltaTime);
                        break;

                        //In the third case the citizen will move to the left.
                        case 3:
                            transform.Translate(Vector3.right * Time.deltaTime);
                        break;

                    }
                    

                } 

                //We check if the Zcomportamiento value is = to 2; in that case the citizen will move.   
                else if(cInformation.comportamiento == (CComportamiento)2)
                {
                    switch(cInformation.rot)
                    {

                         //In the first case the broken citizen on the right
                        case 0:
                            transform.Rotate(Vector3.up * speedRot);
                        break;
                        //In the second case the broken citizen on the right
                        case 1:
                            transform.Rotate(-Vector3.up * speedRot);
                        break;   

                    } 

                } */

        

             //We create a coroutine that is called estado
           /*  IEnumerator Estado(float time)
            {   
                yield return new WaitForSeconds(time);
                //We assign the comportamiento value of the structure to be between 0 and the comportamiento max value.
                cInformation.comportamiento = (CComportamiento)Random.Range(0, comportamiento);
                //We assign the mov value of the structure to be between 0 and the 4, because we are using 4 different moves options.
                cInformation.mov = Random.Range(0,4);
                //We assign the rot value of the structure to be between 0 and the 2, because we are using 2 different moves options.
                cInformation.rot = Random.Range(0,2);
                //We repeat the coroutine each 3 seconds.
                StartCoroutine(Estado(3));
            } */
        
 //Citizen hereda de NPC



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This makes what is put in the script into a library.
namespace NPC
{
    //This makes what is put in the script into a library.
    namespace Ally
    {    
        public class Citizen : MonoBehaviour
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

   
            //Start is called only once.
             void  Start()
            {
                //In the age information of the structure we create a random number between 15 and 100;
                cInformation.age = Random.Range(15, 100);
                //We create a new int that is equal to the number of elements in the names enumerator.
                int nombres = CitizenName.GetNames(typeof(CitizenName)).Length;
                //In the name information of the structure we store a random name of the list between 0 and the previous number position.
                cInformation.name = (CitizenName)Random.Range(0, nombres);
            }
        }
    }
 }



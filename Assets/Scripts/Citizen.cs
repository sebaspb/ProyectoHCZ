using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{

    public CitizenInformation cInformation;

    public struct CitizenInformation
    {
        public int age;
        public CitizenName name;
    }

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

   

    void  Start()
    {
        int nombres = CitizenName.GetNames(typeof(CitizenName)).Length;
        cInformation.age = Random.Range(15, 100);
        cInformation.name = (CitizenName)Random.Range(0, nombres);
    }

   
    }



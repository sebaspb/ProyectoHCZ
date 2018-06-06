using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Allied;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    //A static float variable is created. 
    public static float randomV;

    //First we create 2 variables that are created from the structs of the zombies and citizen scripts.
    public Citizen.CitizenInformation cinfo;
    public Zombies.ZombieInformation zinfo;


    void Start()
    {
        //Variable that invokes what assigns the value of the readonly that is in motion

        randomV = Random.Range(0.1f, 1);
        gameObject.AddComponent<movimiento>();


    }

   
    //In case of collision/* 
    void OnCollisionEnter(Collision obj)
    {
        //if the object it collides with has the tag Ciudadano
        if (obj.gameObject.GetComponent<Citizen>())
        {
            //We change the variable cinfo to be equal as the information stored in the structure of that citizen.
            cinfo = obj.gameObject.GetComponent<Citizen>().cInformation;

            //Then, we show a message that shows the name, and the age of that Citizen.
            Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "Hola soy " + cinfo.name + " y tengo " + cinfo.age + " años";
            StartCoroutine(limpiarmensaje(3));
        }
        //if the object it collides with has the component Zombies.
        if (obj.gameObject.GetComponent<Zombies>())
        {
            //It says here that the transform that is in instances deletes the previous message.    
            Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "";
             //It says here that the transform that is in instances places the text Game Over. 
            Instancias.TransformMsgGOStatic.GetComponent<Text>().text = "Game over";
            //If the time scale equals 1.0f
            if (Time.timeScale == 1.0f)
            {
                //The time scale equals 0.0f
                Time.timeScale = 0.0f;

            }


        }



    }


    //Coroutine to clean message that creates a variable called time.
    IEnumerator limpiarmensaje(float time)
    {
        //This means that every time the citizen's message appears, it waits for time.
        yield return new WaitForSeconds(time);
        //This erases the message of the citizens.
        Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "";

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Allied;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
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
            //Then, we show a message that shows the name, and the age of that zombie.


            Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "Hola soy " + cinfo.name + " y tengo " + cinfo.age + " años";
            StartCoroutine(limpiarmensaje(3));
        }
        //if the object it collides with has the tag Zombie
        if (obj.gameObject.GetComponent<Zombies>())
        {


            Debug.Log("gameover");
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;

            }


        }



    }



    IEnumerator limpiarmensaje(float time)
    {
        yield return new WaitForSeconds(time);
        Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "";

    }
}
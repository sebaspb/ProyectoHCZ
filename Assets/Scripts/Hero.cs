using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero :MonoBehaviour
{

    //First we create 2 variables that are created from the structs of the zombies and citizen scripts.
    public Citizen.CitizenInformation cinfo;
    public Zombies.ZombieInformation zinfo;


    //In case of collision
    void OnCollisionEnter(Collision obj)
    {

        //if the object it collides with has the tag Ciudadano
        if (obj.gameObject.tag=="Ciudadano")
        {
            //We change the variable cinfo to be equal as the information stored in the structure of that citizen.
            cinfo = obj.gameObject.GetComponent<Citizen>().cInformation;
            //Then, we show a message that shows the name, and the age of that zombie.
            Debug.Log("Hola soy " + cinfo.name + " y tengo " + cinfo.age + " años");
        }

        //if the object it collides with has the tag Zombie
        if (obj.gameObject.tag == "Zombie")
        {
            //We change the variable zinfo to be equal as the information stored in the structure of that zombie.
            zinfo = obj.gameObject.GetComponent<Zombies>().zInformation;
            /*Then, we show a message that shows the part of body that zombie wants to eat
             * The body part is stored in a enum in the zombies class*/
            Debug.Log("Waaaarrrr quiero comer " + zinfo.gusto);
        }

    }


}


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

    //Real variable of the damage a normal zombie does.
    public float DamageCaused = 20;

    //Real variable of the damage a RedZombie does.
    public float RedDamageCaused = 100;

    //Here a real variable is created for the value to be added to the player's life.
    public float Repair = 300;

    //Here you create an object called Keys.
    GameObject Keys;

    void Start()
    {
        //Variable that invokes what assigns the value of the readonly that is in motion
        randomV = Random.Range(0.1f, 1);
        gameObject.AddComponent<movimiento>();
        //An object called a Gun is created that is the same as the object with the Tag Gun.
        GameObject Gun = GameObject.FindWithTag("Gun");
        //Here it is said that the transform of the object Gun is equal to the transform of the Hero. 
        Gun.transform.parent = transform;
        //Here it is said that Gun's local position is equal to 0 on the X axis, 0 on the Y axis and 0.4 on the Z axis.
        Gun.transform.localPosition =  new Vector3(0,0,0.2f);  
        //Here it is said that the local scale of Gun is equal to 0.5 on all axes.
        Gun.transform.localScale = new Vector3(.5f,.5f,.5f);
        //Here it is said that the rotation is 90 on the X axis with an absolute value of 90, 0 on the Y axis and 0 on the Z axis in the local space.
        Gun.transform.Rotate(new Vector3(90,0,0), Space.Self);
      
    }

    void Update()
    {
        //We check that there are not zombies or red zombies from the instace script so the player can win the game if the condition is meeted.
        if (Instancias.totalZombiesRStatic == 0 && Instancias.totalZombiesStatic == 0)
        {
            //The text that displays the win message is modified.
            Instancias.TransformMsgWinStatic.GetComponent<Text>().text = "Congratulations, You won the game.";
            //If the time scale equals 1.0f
            if (Time.timeScale == 1.0f)
            {
                //The time scale equals 0.0f
                Time.timeScale = 0.0f;

            }
        }

    }

    //In case of collision
    void OnCollisionEnter(Collision obj)
    {
        //if the object it collides with has the tag Ciudadano
        if (obj.gameObject.GetComponent<Citizen>())
        {
            //We change the variable cinfo to be equal as the information stored in the structure of that citizen.
            cinfo = obj.gameObject.GetComponent<Citizen>().cInformation;

            //Then, we show a message that shows the name, and the age of that Citizen.
            Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "Hola soy " + cinfo.name + " y tengo " + cinfo.age + " años";
            StartCoroutine(ClearMessage(3));
        }
        //if the object it collides with has the component Zombies.
        if (obj.gameObject.GetComponent<Zombies>())
        {
            //It says here that the transform that is in instances deletes the previous message.    
            Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "";


            //If the hero collides with an object with the Zombie component, the DamageCaused is subtracted from the hero's life.
            Instancias.PlayerHealthStatic -= DamageCaused;
            //The life of the hero is equal to the value of the life bar.
            Instancias.LifeBarStatic.value = Instancias.PlayerHealthStatic;

            //If the hero's life equals 0 then
            if (Instancias.PlayerHealthStatic == 0)
            {
                //The life counter is subtracted by 1.
                Instancias.CounterLifesStatic -= 1;
                //The hero's life equals 500.
                Instancias.PlayerHealthStatic = 500;
            }

            //If the life counter is equal to 0 then
            if (Instancias.CounterLifesStatic == 0)
            {
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

   

        //If the hero hits the object with the name RedZombie then
        if (obj.gameObject.name == ("RedZombie"))
        {

            //It says here that the transform that is in instances deletes the previous message.    
            Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "";

            //The life of the hero is subtracted from the RedDamageCaused.
            Instancias.PlayerHealthStatic -= RedDamageCaused;
            //The life of the hero is equal to the value of the life bar.
            Instancias.LifeBarStatic.value = Instancias.PlayerHealthStatic;

            //If the hero's life equals 0
            if (Instancias.PlayerHealthStatic == 0)
            {
                //The life counter is subtracted by 1.
                Instancias.CounterLifesStatic -= 1;
                //The hero's life equals 500.
                Instancias.PlayerHealthStatic = 500;
            }
            //If the life counter is equal to 0 then
            if (Instancias.CounterLifesStatic == 0)
            {
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
    }    

    //It says here that if it goes through the object then
    void OnTriggerEnter(Collider obj)
    { 
        //If the object enters the object trigger with the Tag Keys then 
        if(obj.gameObject.CompareTag("Keys"))
        {
            //If the player's life is different from the maximum value of the player's life bar then
            if(Instancias.PlayerHealthStatic != Instancias.LifeBarStatic.maxValue)
            {
                
                //It is said here that the player's life is joined by Repair.
                Instancias.PlayerHealthStatic += Repair;
                //It is said here that if the player's life is greater than 500 after repair then
                if(Instancias.PlayerHealthStatic > 500)
                {
                    //The value of the player's life is equal to 500.
                    Instancias.PlayerHealthStatic = 500;

                }
                //The value of the life bar is equal to the life of the player.
                Instancias.LifeBarStatic.value = Instancias.PlayerHealthStatic;
            }
        }  
    }


    //Coroutine to clean message that creates a variable called time.
    IEnumerator ClearMessage(float time)
    {
        //This means that every time the citizen's message appears, it waits for time.
        yield return new WaitForSeconds(time);
        //This erases the message of the citizens.
        Instancias.TransformMsgCitizenStatic.GetComponent<Text>().text = "";
    }
}
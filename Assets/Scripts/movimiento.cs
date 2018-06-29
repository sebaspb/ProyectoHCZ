using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour 
{

    //A read-only variable called speed is created
    readonly float speed;

    //Builder
    public movimiento()
    {
        //Here it is said that speed is equal to the randomV variable of the Hero script
        speed = Hero.randomV;
    }


	
    //Update is called each frame.
	void Update ()
    {
        if (Time.timeScale != 0)
        { 
            //We create a new gameobject called hero that's equal to the gameobject with the hero tag.
            GameObject Hero = GameObject.FindGameObjectWithTag("Hero");

            //If we press the "w" key, the hero will transform it's position forward at the speed value.
            if (Input.GetKey("w"))
            {
                
                Hero.transform.position += Hero.transform.forward * speed;

            }

            //If we press the "s" key, the hero will transform it's position backwards at the speed value.
            if (Input.GetKey("s"))
            {

                Hero.transform.position -= Hero.transform.forward * speed;

            }

            //If we press the "a" key, the hero will transform it's position to the right at the speed value.
            if (Input.GetKey("a"))
            {
                
                Hero.transform.position -= Hero.transform.right * speed;

            }

            //If we press the "d" key, the hero will transform it's position to the left at the speed value.
            if (Input.GetKey("d"))
            {

                Hero.transform.position += Hero.transform.right * speed;

            }
        }
    }
}

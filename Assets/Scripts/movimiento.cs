using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {

    //We create a variable to store the speed of the hero.
    public float speed;

    /*Start is called only once at the start*/
    void Start ()
    {
        //At the start we assign the speed with a random range between 0.1 and 1
        speed = Random.Range(0.1f, 1);
    }
	
    //Update is called each frame.
	void Update ()
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

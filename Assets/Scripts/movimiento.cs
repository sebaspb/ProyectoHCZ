using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {
    public float speed;
    public Citizen.CitizenInformation cinfo;
    public Zombies.ZombieInformation zinfo;

    // Use this for initialization
    void Start () {
		speed = Random.Range(0.1f, 0.5f);

        

    }
	
	// Update is called once per frame
	void Update () {
        GameObject Hero = GameObject.FindGameObjectWithTag("Hero");

        if (Input.GetKey("w"))
        {

            Hero.transform.position += Hero.transform.forward * speed;

        }

        if (Input.GetKey("s"))
        {

            Hero.transform.position -= Hero.transform.forward * speed;

        }

        if (Input.GetKey("a"))
        {

            Hero.transform.position -= Hero.transform.right * speed;

        }

        if (Input.GetKey("d"))
        {

            Hero.transform.position += Hero.transform.right * speed;

        }

    }


    void OnCollisionEnter(Collision obj)
    {


           if (obj.gameObject.GetComponent<Citizen>())
           {

            cinfo = obj.gameObject.GetComponent<Citizen>().cInformation;

                Debug.Log("Hola soy " + cinfo.name + " y tengo " + cinfo.age + " años");

         }


        if (obj.gameObject.GetComponent<Zombies>())
        {

            zinfo = obj.gameObject.GetComponent<Zombies>().zInformation;

            Debug.Log("Waaaarrrr quiero comer " + zinfo.gusto);

        }

    }

}

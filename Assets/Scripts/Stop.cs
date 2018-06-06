using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;

public class Stop : MonoBehaviour 
{


	private void Start () 
	{
		
	}
	
	
	private void Update () 
	{
		
	}

	void OnCollisionEnter(Collision obj)
    {
		gameObject.GetComponent<Hero>();
		 if (obj.gameObject.GetComponent<Zombies>())
        {  
			if(Time.timeScale == 1)
			{

				Time.timeScale = 0;

			}
		}
	}
}

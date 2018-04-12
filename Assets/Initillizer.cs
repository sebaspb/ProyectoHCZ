using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initillizer : MonoBehaviour 
{

	public static int randomMin;
	private void Awake () 
	{
		
		randomMin = Random.Range(5,15);
		gameObject.AddComponent<Test>();
	}
}

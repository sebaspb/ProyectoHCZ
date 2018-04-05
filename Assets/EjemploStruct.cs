using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploStruct : MonoBehaviour 
{

	public struct myStruct
	{

		public int a;
		
	}

	private void Start () 
	{
		
		myStruct mStruct = new myStruct();
		mStruct.a = 1;
		Debug.Log(mStruct.a);
	}
	
	
	private void Update () 
	{
		
	}
}

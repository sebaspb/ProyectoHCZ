using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero :MonoBehaviour
{



    //public GameObject Jugador;

    public Hero()

    {
        //Se crea una primitiva de tipo cubo en una posición estipulada
        //GameObject Jugador = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Jugador.transform.position = new Vector3(9, 0.5f, 5);
        //Jugador.AddComponent<movimiento>();
        //Jugador.AddComponent<movimientocamara>();
        //Jugador.AddComponent<Rigidbody>();
                

        //se le asigna un tag y nombre "Hero"
        //Jugador.tag = "Hero";
        //Jugador.name = "Hero";

        //Se busca el objeto con el tag "MainCamera" y se emparenta al objeto creado anteriormente.
        //Al mismo tiempo se asigna la posicíón de la cámara a la misma del heroe, ésto garantiza que la cámara estará centrada respecto
        //al héroe
        //GameObject Camera = GameObject.FindWithTag("MainCamera");
        //Camera.transform.SetParent(Jugador.transform, false);
       // Camera.transform.position = new Vector3(9, 0.5f, 5);





    }

    void Start()
    {
 
        


    }

    void Update()
    {
        


    }

  

}


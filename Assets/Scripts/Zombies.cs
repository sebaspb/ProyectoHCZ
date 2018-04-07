using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{

    public struct ZombieInformation
    {

        public Color color;
        public ZComportamiento comportamiento;
        public Vector3 vel;
        public ZGusto gusto;
    }
    
    public enum ZGusto
    {
        cerebro,
        ojos,
        corazón,
        intestinos,
        hígado,
    }

    public enum ZComportamiento
    {
        idle,
        moving,
    }
    int comportamiento = ZComportamiento.GetNames(typeof(ZComportamiento)).Length;

    public ZombieInformation zInformation;
   
    void Start() {
        int gustos = ZGusto.GetNames(typeof(ZGusto)).Length;
        zInformation.gusto = (ZGusto)Random.Range(0, gustos);

        zInformation.vel.x = 5f;
        int casoZ = Random.Range(0,3);
        



        switch (casoZ)
        {

            case 0:
                GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                break;

            case 1:
                GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                break;

            case 2:
                GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;

        }

    

        StartCoroutine(Estado(0));

        


    }

    private void Update()
    {
        if (zInformation.comportamiento == (ZComportamiento)1)
        {
            transform.Translate(zInformation.vel * Time.deltaTime);

        }
    }

  
    IEnumerator Estado(float time)
    {
        yield return new WaitForSeconds(time);
       zInformation.comportamiento = (ZComportamiento)Random.Range(0, comportamiento);
           
        StartCoroutine(Estado(5));
    }


}
//    public struct PosicionZombie
//    {
//        public Vector3 pos;
//        public string nombre;
//        public Color color;
//        public string tag;
//    }

//    public enum Cuerpo
//    {

//        cerebro,
//        ojos,
//        corazón,
//        intestinos,
//        hígado,

//    }

//    PosicionZombie posicionzombie;
    

//    public Zombies(){

        
//        posicionzombie.pos = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));
//        posicionzombie.nombre = "Zombie";
//        posicionzombie.tag = "Zombie";

//        int Desencadenante = Random.Range(0, 3);

//        switch (Desencadenante)
//        {
//            case 0:
//                posicionzombie.color = Color.green;
//                break;

//            case 1:
//                posicionzombie.color = Color.cyan;
//                break;

//            case 2:

//                posicionzombie.color = Color.magenta;
//                break;

//        }
      

//        GameObject Zombies = GameObject.CreatePrimitive(PrimitiveType.Cube);
//        Zombies.transform.position = posicionzombie.pos;
//        Zombies.name = posicionzombie.nombre;
//        Zombies.tag = posicionzombie.tag;
//        //Zombies.AddComponent<Rigidbody>();
//        Zombies.GetComponent<Renderer>().material.SetColor("_Color", posicionzombie.color);


//    }

//    void Start()
//    {
//    }

//}
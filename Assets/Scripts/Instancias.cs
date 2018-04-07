using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancias : MonoBehaviour 
{
    bool heroeasignado = false;
    float totalentidades = 0;

    private void Start () 
	{
      

        if (!heroeasignado) { 
        for (int i = 0; i < 1;)
        {
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));
            Objeto.name = "Heroe";
                Objeto.tag = "Hero";
            Objeto.AddComponent<Hero>();
                Objeto.AddComponent<movimiento>();
                Objeto.AddComponent<movimientocamara>();
                Objeto.AddComponent<Rigidbody>();

            GameObject Camera = GameObject.FindWithTag("MainCamera");
            Camera.transform.SetParent(Objeto.transform, false);
            Camera.transform.position = Objeto.transform.position;


            i += 1;
            heroeasignado = true;
            totalentidades += 1;
            }
        }

        int cantidad = Random.Range(10, 20);
        for (int a = 0; a < cantidad;) {

            int desencadenante = Random.Range(0, 2);
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
           Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));

            switch (desencadenante)
            {
            case 0:
            Objeto.name = "Ciudadano";
                    Objeto.tag = "Ciudadano";
                    Objeto.AddComponent<Rigidbody>();

                    Objeto.AddComponent<Citizen>();
            totalentidades += 1;
                    break;

            case 1:
            Objeto.name = "Zombie";
                    Objeto.AddComponent<Rigidbody>();

                    Objeto.AddComponent<Zombies>();
            totalentidades += 1;

                    break;
            }
            a += 1;
        }

        if (totalentidades > 20)
        {

            print("<color=yellow>CUIDADO HAY MUCHAS ENTIDADES, EL TOTAL ES DE: " + totalentidades +"</color>");


        }

    }






}

        //GameObject Citizen = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //Citizen.transform.position = new Vector3(Random.Range(100, 450), 0.9f, Random.Range(100, 450));
        //Citizen.AddComponent<Zombies>();

        //for (int i = 0; i < Random.Range(5, 9);)
        //{

        //    new Zombies();
        //    i += 1;
        //}
        //new Hero();
    

   


  

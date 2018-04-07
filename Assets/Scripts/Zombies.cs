using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{

    public struct ZombieInformation
    {

        public Color color;
        public ZComportamiento comportamiento;
        public int mov;

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


        int casoZ = Random.Range(0, 3);




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

            switch (zInformation.mov) {
                case 0:
            transform.Translate(Vector3.forward * Time.deltaTime);
                    break;
                case 1:
                    transform.Translate(Vector3.back * Time.deltaTime);
                    break;
                case 2:
                    transform.Translate(Vector3.right * Time.deltaTime);
                    break;
                case 3:
                    transform.Translate(Vector3.right * Time.deltaTime);
                    break;
            }
    }
    }


    IEnumerator Estado(float time)
    {
        yield return new WaitForSeconds(time);
        zInformation.comportamiento = (ZComportamiento)Random.Range(0, comportamiento);
        zInformation.mov = Random.Range(0,4);
        StartCoroutine(Estado(5));
    }

   


    


}

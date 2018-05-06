using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Allied;
using NPC.Enemy;

public class classNPC : MonoBehaviour 
{
	public Date init;
    protected float Speed;
    protected float Rot;
    protected int cases;

    public Transform Objetivo;

    Vector3 direction;

    public float distancia = 5;
 

    virtual public void Herent()
    {

        Rot = Random.Range(1, 10);
        Move();
        init.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
      
    }

    virtual public void test()
    {

        foreach(GameObject ObjectsTest in Instancias.Objects)
        {

            if(ObjectsTest.GetComponent<Citizen>() || ObjectsTest.GetComponent<Hero>())
            {
                
                if( Vector3.Distance(ObjectsTest.transform.position ,transform.position) < distancia)
                {
                    
                    init.keep = state.pursuing;
                    transform.position = Vector3.MoveTowards(transform.position, ObjectsTest.transform.position, Speed);
                    StopCoroutine(Movement());
                                       

                }

            }

        }

    }

    void Update()
    {   
        test();
           
        switch (cases)//the switch is used for different positions where the zombie is directed.
        {
            case 1:
               transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                break;
            case 2:
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
                break;
            case 3:
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
                break;
            case 4:
                transform.Translate(-Vector3.right * Time.deltaTime * Speed);
                break;
            case 5:
                transform.Rotate(Vector3.up * Rot);
                break;
            case 6:
                transform.Rotate(-Vector3.up * Rot);
                break;
            case 7:
                transform.position += new Vector3(0, 0, 0);
                break;
           
        }

       
       
    }
    public void Move()//a function is created for the movement.
    {
        if (init.keep == state.idle)//if the state is at idle.
        {
            cases = 7;//stays in place since it's case 5.
            StartCoroutine(Movement());//it's called coroutine.
        }
        else if (init.keep == state.move)//if not, if the state this move.
        {
            if (init.age > 15 && init.age < 30)
            {
                Speed = 1;
            }
            else if (init.age > 31 && init.age < 46)
            {
                Speed = 0.8f;
            }
            else if (init.age > 47 && init.age < 62)
            {
                Speed = 0.6f;
            }
            else if (init.age > 63 && init.age < 78)
            {
                Speed = 0.4f;
            }
            else if (init.age > 79 && init.age < 94)
            {
                Speed = 0.2f;
            }
            else if (init.age > 95 && init.age < 100)
            {
                Speed = 0.1f;
            }
            cases = Random.Range(1,4);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine.
        }
        else if (init.keep == state.rotation)//if not, if the state this rotation.
        {
            cases = Random.Range(5, 6);//calls the switch to move in different positions.
            StartCoroutine(Movement());//it's called coroutine
        }
    }
    public IEnumerator Movement()//se hace una coroutine para el estado del mivimeinto.
    {
        yield return new WaitForSeconds(3);//takes 3 seconds to work.
        init.keep = (state)Random.Range(0, 3);//is called one of the two states.
        Move();//is called the Move function.
        yield return new WaitForSeconds(3);//takes 3 seconds to work.
    }
}
public enum state//a list is made of the zombie state.
{
    idle, move, rotation, pursuing,
}
public struct Date//the structure is made to be able to call the food, the state and the color to the Zombie class.
{
    public state keep;//becomes a standard enum variable for the state.
    public int age;//an int variable is made for age.

}


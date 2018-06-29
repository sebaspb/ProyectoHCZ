using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Allied;
using NPC.Enemy;
using UnityEngine.UI;
public class classNPC : MonoBehaviour 
{
    //A Date is created to put information on the age and status of Zombies and citizens.
	public Date init;

    //A protected float is created to control the speed of Zombies and Citizens.
    protected float Speed;

    //A protected float is created to control the rotation speed of the Zombies and Citizens.
    protected float Rot;

    //A protected int is created to control the cases.
    protected int cases;

    //A public Transform is created for the purpose of the Zombies
    public Transform Objetivo;

    //This is called the Zombie information.
    public Zombies.ZombieInformation zinfo;

    //Here a Vector3(x,y,z) is created.
    Vector3 direction;

    //Here you create a public float with a value of 5.
    public float distancia = 5;
    
    //Here you create a method that you can call up from other classes that inherit from classNPC.      
    virtual public void Herent()
    {
        //This says the rotation speed ranges from 1 to 10.
        Rot = Random.Range(1, 10);
        //It says here to start what is in the Move method.
        Move();
        //The age of the civilians is added at random between 15 and 100 years of age.
        init.age = Random.Range(15, 100);
    }

    //Here you create a method that you can call up from other classes that inherit from classNPC.  
    virtual public void test()
    {
        //It says here that for each GameObject with the name ObjectsTest in the list of Instances called Objects.
        foreach (GameObject ObjectsTest in Instancias.Objects)
        {

            //It says here that if the object with the Citizen component or the object with the Hero component
            if (ObjectsTest.GetComponent<Citizen>() || ObjectsTest.GetComponent<Hero>())
            {
                //Here the distance between the object in the list and the zombie is checked; if it is smaller at a distance(5) then....
                if (Vector3.Distance(ObjectsTest.transform.position, transform.position) < distancia)
                {
                    //The state of both the Zombies and the citizens to be equal to pursuing
                    init.keep = state.pursuing;
                    //This tells you where the Zombie should go and how fast.
                    transform.position = Vector3.MoveTowards(transform.position, ObjectsTest.transform.position, Speed);
                    //This is where the corutine that activates the states in classNPC.
                    StopCoroutine(Movement());
                }
            }
        }
    }

    void Update()
    {
        //If timeScale it's diferent of 0.
        if (Time.timeScale != 0)
        { 
            test();
            //The switch is used for different positions where the Zombie and Citizen are moving to.
            switch (cases)
            {
                case 1:
                    transform.Translate(Vector3.forward * Time.deltaTime *  Speed);
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
                    transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
                    break;
            }
            
            //It says here that for each GameObject named ObjectsTest in the Objects list of Instances then...    
            foreach (GameObject ObjectsTest in Instancias.Objects)
            {
                //If the object in the list is named Zombie
                if (ObjectsTest.tag == "Zombie")
                {                  
                    //If the object is in a place less than the distance from the object with the Hero tag then...
                    if (Vector3.Distance(ObjectsTest.transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position) < distancia)
                    {
                        //It says here that zinfo is the same as the object with the Zombies component.
                        zinfo = ObjectsTest.gameObject.GetComponent<Zombies>().zInformation;
                        //It says here that the message appears on the interface.
                        Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "Waaaarrrr quiero comer " + zinfo.gusto;
                        //This is where the coroutine starts in 3 seconds.
                        StartCoroutine(cleanmessage(3));
                        //This is where you go into the pursuing state.
                        init.keep = state.pursuing;
                    }
                }
                //If the object in the list is named ZombieRed
                if(ObjectsTest.tag == "ZombieRed")
                {
                     //If the object is in a place less than the distance from the object with the Hero tag then...
                    if (Vector3.Distance(ObjectsTest.transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position) < distancia)
                    {
                        //It says here that zinfo is the same as the object with the Zombies component.
                        zinfo = ObjectsTest.gameObject.GetComponent<Zombies>().zInformation;
                        //It says here that the message appears on the interface.
                        Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "Waaaarrrr quiero comer " + zinfo.gusto;
                        //This is where the corutina starts in 3 seconds.
                        StartCoroutine(cleanmessage(3));
                        //This is where you go into the pursuing state.
                        init.keep = state.pursuing;
                    }
                }
            }
        }
    }

    //A function is created for the movement.
    public void Move()
    {
        //If the state is at idle.
        if (init.keep == state.idle)
        {
            //Stays in place since it's case 5.
            cases = 7;
            //It's called coroutine.
            StartCoroutine(Movement());
        }

        else if (init.keep == state.move)
        //If not, if the state this move.
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
            //Calls the switch to move in different positions.
            cases = Random.Range(1,4);
            //It's called coroutine.
            StartCoroutine(Movement());
            
        }
        //If not, if the state this rotation.
        else if (init.keep == state.rotation)
        {
            //Calls the switch to move in different positions.
            cases = Random.Range(5, 6);
            //It's called coroutine
            StartCoroutine(Movement());
        }
    }
    //se hace una coroutine para el estado del movimiento.
    public IEnumerator Movement()
    {
        //Takes 3 seconds to work.
        yield return new WaitForSeconds(3);
        //Is called one of the three states.
        init.keep = (state)Random.Range(0, 3);
        //Is called the Move function.
        Move();
    }

    //Corutine to clean up zombie messages with a variable called time.
    IEnumerator cleanmessage(float time)
    {
        //This causes each Zombie's message to be deleted from time to time.
        yield return new WaitForSeconds(time);
        //This is where the Zombies' message is cleaned up.
        Instancias.TransformMsgZombiesStatic.GetComponent<Text>().text = "";
    }
}

//A list is made of the zombie state.
public enum state
{
    idle, move, rotation, pursuing,
}

//The structure is made to be able to call the food, the state and the color to the Zombie class.
public struct Date
{
    //Becomes a standard enum variable for the state.
    public state keep;

    //an int variable is made for age.
    public int age;
}








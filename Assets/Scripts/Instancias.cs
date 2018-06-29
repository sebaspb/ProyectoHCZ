
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Allied;
using UnityEngine.UI;
public class Instancias : MonoBehaviour
{
    /*First a bool is created to check if the hero has already been assigned; this is to ensure that
    that only one hero be assigned.*/
    bool heroeasignado = false;

    //A real variable called Instantiated is created
    float Instanciado;

    //A public constant is created that is equal to 25
    public const float MAX = 25;

    /*We create a variable that will increase progressively, this is used to have an internal control of the total 
     *number of entities that are generated, in order to control and report in the event that more than 20 are generated.*/
    float totalentidades = 0;

    //A public Transform is created to save the number of zombies(totalZombies) in the scene, we also create a static version to access it from other scripts.
    public Transform TransformTextZombies;
    public static Transform TransformTextZombiesStatic;


    //A text component is created so that you can place what is in totalZombies, we also create a static version to access it from other scripts.
    public Text TextZombie;
    public static Text TextZombieStatic;

    //A public Transform is created to save the number of zombies(totalZombies) in the scene we also create a static version to access it from other scripts.
    public Transform TransformTextZombiesRed;
    public static Transform TransformTextZombiesRedStatic;

    //A text component is created so that you can place what is in totalZombies we also create a static version to access it from other scripts.
    public Text TextZombieRed;
    public static Text TextZombieRedStatic;

    //A public Transform is created to save the number of Citizen(totalCitizen) in the scene we also create a static version to access it from other scripts.
    public Transform TransformTextCitizen;
    public static Transform TransformTextCitizenStatic;

    //A text component is created so that you can place what is in total(totalCitizen)we also create a static version to access it from other scripts.
    public Text TextCitizens;
    public static Text TextCitizensStatic;

    //A public Transform is created to occupy the space of the interface to display the message of the citizen,  we also create a static version to access it from other scripts.
    public Transform TransformMsgCitizen;
    public static Transform TransformMsgCitizenStatic;

    //A public Transform is created to display the citizens' message in the interface,
    public Text MsgCitizens;

    //A public static Transform is created so that the Zombies' messages change if it is a different Zombie, we also create a static version to access it from other scripts.
    public Transform TransformMsgZombies;
    public static Transform TransformMsgZombiesStatic;

    //A public Text is created to show what is saved in ZGusto.
    public Text MsgZombies;

    //A public Transform is created to display the GameOver message in the interface,  we also create a static version to access it from other scripts.
    public Transform TransformMSgGO;
    public static Transform TransformMsgGOStatic;

    //A public Text is created to display the GameOver message.
    public Text MSgGO;

    //A public Transform is created to display the win message in the interface,  we also create a static version to access it from other scripts.
    public Transform TransformMSgWin;
    public static Transform TransformMsgWinStatic;

    //A public Text is created to display the win message.
    public Text MSgWin;

    //public Transform to show the weapon state
    public Transform TransformWeaponStatus;

    //public Text to show the weapon state
    public Text WeaponStatus;

    //public Transform to show the reloading weapon message
    public Transform TransformMsgReload;

    //public Text para to show the reloading weapon message
    public Text MsgReload;

    //A list called Objects is created to save what is inside the foreach.
    public static List<GameObject> Objects = new List<GameObject>();

    [Tooltip("Life Bar Slider")]

    //public slider for the life bar and his static version
    public Slider LifeBar;
    public static Slider LifeBarStatic;

    [Header("<HEALTH OPTIONS AND LIFE BAR>")]
    [Tooltip("Player health, default 500")]

    //Variable for the player health and his sstatic version
    public float PlayerHealth = 500f;
    public static float PlayerHealthStatic;


    //Static transform that shows the player's lifes and his static version
    public Transform TransformLifes;
    public static Transform TransformLifesStatic;

    //Static variable that depends on the lifes amount to update; and his static version.

    float CounterLifes = 3;
    public static float CounterLifesStatic;


    [Space(10)]
    [Header("Gun")]
    [Tooltip("The prefab to be assigned as a bullet")]

    //public GameObject that stores the bullet
    public GameObject Bullet;

    [Tooltip("The object to be used as a bullet emitter")]

    //public GameObject, the bullet emitter for the buller
    public GameObject BulletEmitter;

    [Tooltip("The damage this bullet does to enemies")]

    //Variable to stare the bullet damage and his static version
    public float BulletDamage;
    public static float BulletDamageStatic;

    //Variable that stores the bullet force
    public float BulletForce = 9000f;

    //Time that's used to check if the weapon need to reload. 
    public float Timer;

    //Gameobject used to modify the wrench internally.
    GameObject keys;

    //Variables to store the HP of the zombies and their static version
    public float ZombiesLife;
    public static float ZombiesStaticLife;
    public float ZombiesLifeRed;
    public static float ZombiesStaticLifeRed;
   

    [Tooltip("Value that's gonna be used for the shot cadency")]
    public float FireDelta = 0.05f;

    //The following two variables are private and will be used to internally calculate the player's next minigun shot.
    private float Cadence = 0.5F;
    private float MyTime = 0.0F;

    //Variables to store the amount of each entitite and their static version
    int totalZombies = 0;
    public static int totalZombiesStatic = 0;
    int totalZombiesR = 0;
    public static int totalZombiesRStatic = 0;
    int totalCitizen = 0;
    public static int totalCitizenStatic = 0;

    //A bool used to show the correct message for the gun state.
    bool inactive = false;

    /*Start is called only once at the start*/

    public class EntitiesNumber
    {
        //Variable that is used for read-only integer call only Num 
        public readonly int Num;

        //Builder
        public EntitiesNumber()
        {
            //It says here that Num equals a random range between 5 and 15
            Num = Random.Range(5, 15);
        }
    }

    private void Start()
    {
        //All the static variables are assigned to be equal as his matching public version.
        TransformLifesStatic = TransformLifes;
        TransformMsgGOStatic = TransformMSgGO;
        TransformMsgCitizenStatic = TransformMsgCitizen;
        TransformMsgZombiesStatic = TransformMsgZombies;
        TransformMsgWinStatic = TransformMSgWin;

        TextZombieStatic = TextZombie;
        TransformTextZombiesStatic = TransformTextZombies;
        TextZombieRedStatic = TextZombieRed;
        TransformTextZombiesRedStatic = TransformTextZombiesRed;
        TextCitizensStatic = TextCitizens;
        TransformTextCitizenStatic = TransformTextCitizen;
        
        CounterLifesStatic = CounterLifes;


        //  The corresponding values assigned in the inspector will be assigned to the life bar.
        LifeBar.maxValue = PlayerHealth;
        LifeBar.value = PlayerHealth;
        LifeBarStatic = LifeBar;
        //The static variables are initialized with the value assigned in the inspector.
        PlayerHealthStatic = PlayerHealth;
        BulletDamageStatic = BulletDamage;
        ZombiesStaticLife = 500;
        ZombiesStaticLifeRed = 1000;
        //Variable that assigns the damage the bullet does.
        BulletDamage = 100;



      //Used to move the wrench randomly on the map
        keys = GameObject.FindWithTag("Keys");
        keys.transform.position = new Vector3(Random.Range(100, 450), 1.5f, Random.Range(100, 450));
           

        
        //The bool heroeasignado is checked; if it's false we proceed to create the hero.
        if (!heroeasignado)
        {
            //We create a new primitive of the cube type.       
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //We assign a random position that goes from coords 100 to 450 in the x and z axis.
            //and a fixed position of 0.5 in the y axis, this is done so that the cube appears at ground level.
            Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));
            //We assign the name Heroe to the object name so it can be differenciable in the Hierarchy panel.
            Objeto.name = "Heroe";
            //We assign the tag Heroe to the object so it can be easily accesed later.
            Objeto.tag = "Hero";
            //We add the script Hero to the object, that script controls the collision messages.
            Objeto.AddComponent<Hero>();
            //We add the script movimientocamara to the object, that script controls the movement of the camera.
            Objeto.AddComponent<movimientocamara>();
            //We add a rigid body to the object so it can collide with other entities.
            Objeto.AddComponent<Rigidbody>();
            //We change the kinematic mode to true to fix a bug that made the hero tilt on the ground.
            Objeto.GetComponent<Rigidbody>().isKinematic = true;
            //We create a new gameobject with the name camera and its equal to the object with the tag MainCamera.
            GameObject Camera = GameObject.FindWithTag("MainCamera");
            //We make the camera as a child of the hero object.
            Camera.transform.SetParent(Objeto.transform, false);
            //We transform the positiont to be the same as the hero object so both will be in the same position in x axis, but -1.05 in Y axis and 1.92 in z axis.
            Camera.transform.position = Objeto.transform.position - new Vector3(0, -1.05f, 1.92f);
            //Éste objeto va a tener el color negro.                                        
            Objeto.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            //We change the heroeasignado bool to true, so the hero won't be created again.
            heroeasignado = true;
            //The totalentidades values is increased by one.
            totalentidades += 1;
            //Add the object Objeto so that it remains in the Objects list.
            Objects.Add(Objeto);
        }


        //It is said that instanciado is equal to the random variable of the constructor new EntitiesNumber with the variable Num and its maximum will be the constant Max
        Instanciado = Random.Range(new EntitiesNumber().Num, MAX);

        //We create a for that goes from 0 to the value of the previous variable.

        for (int a = 0; a < Instanciado;)
        {
            //We create a new gameobject with a primitive of the cube type.
            GameObject Objeto = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //We assign a random position that goes from coords 100 to 450 in the x and z axis.
            //and a fixed position of 0.5 in the y axis, this is done so that the cube appears at ground level.
            Objeto.transform.position = new Vector3(Random.Range(100, 450), 0.5f, Random.Range(100, 450));

            //We create a new variable that can be 0 or 1 and a switch is created to work with those 2 values.
            int desencadenante = Random.Range(0, 3);
            switch (desencadenante)
            {
                //in the first case.
                case 0:
                    //We assign the name ciudadano to that object so it can be easily differenciable in the hierarchy panel
                    Objeto.name = "Ciudadano";
                    //We assign the tag ciudadano to that object so it can be easily accesed later.
                    Objeto.tag = "Ciudadano";
                    //We assign a rigidbody to that object so it can collide with the other entities.
                    Objeto.AddComponent<Rigidbody>();
                    //We assign the citizen script to that object so it behaviour as a citizen.
                    Objeto.AddComponent<Citizen>();
                    //We increase the number of total entities in one.
                    totalentidades += 1;
                    //All GameObjects called Objeto are added and saved in Objects
                    Objects.Add(Objeto);
                    //We freeze all the constraints to avoid weird behaviours
                    Objeto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                    RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                    break;

                case 1:
                    //We assign the name zombie to that object so it can be easily differenciable in the hierarchy panel
                    Objeto.name = "Zombie";
                    //We assign the tag zombie to that object so it can be easily accesed later.
                    Objeto.tag = "Zombie";
                    //We assign a rigidbody to that object so it can collide with the other entities.
                    Objeto.AddComponent<Rigidbody>();
                    //We assign the zombiez script to that object so it behaviour as a zombie.
                    Objeto.AddComponent<Zombies>();
                    //We modify the mazz of the zombie to avoid weird behaviour
                    //Objeto.GetComponent<Rigidbody>().mass = 100f;

                  
                    //We increase the number of total entities in one.
                    totalentidades += 1;
                    //All GameObjects called Objeto are added and saved in Objects

                    Objects.Add(Objeto);
                    //We freeze all the constraints to avoid weird behaviours
                    Objeto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                    RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                    break;

                case 2:
                    //We assign the name zombie to that object so it can be easily differenciable in the hierarchy panel
                    Objeto.name = "ZombieRed";
                    //We assign the tag zombie to that object so it can be easily accesed later.
                    Objeto.tag = "ZombieRed";
                    //We assign a rigidbody to that object so it can collide with the other entities.
                    Objeto.AddComponent<Rigidbody>();

                    //We assign the zombiez script to that object so it behaviour as a zombie.
                    Objeto.AddComponent<Zombies>();
                    //Some zombies are created with the red color since this case
                    Objeto.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    //We modify the mazz of the zombie to avoid weird behaviour
                    //Objeto.GetComponent<Rigidbody>().mass = 100f;
                 

                    //We increase the number of total entities in one.
                    totalentidades += 1;
                    //All GameObjects called Objeto are added and saved in Objects
                    Objects.Add(Objeto);
                    //We freeze all the constraints to avoid weird behaviours
                    Objeto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                         RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                    break;
            }
            //the a variable is increased by one and the for is repeted until the condition is meeted.
            a += 1;
        }


        //A foreach is created that takes all GameObjects named ObjectsNum and puts them in the Objects list. 
        foreach (GameObject ObjectsNum in Objects)
        {
            //If the name of what is in ObjectsNum is equal to "Zombie" then...
            if (ObjectsNum.name == "Zombie")
            {
                //To the value of totalZombies is added 1
                totalZombies += 1;
            }

            if (ObjectsNum.name == "Ciudadano")
            {
                //To the value of totalCitizen is added 1    
                totalCitizen += 1;
            }
            if (ObjectsNum.name == "ZombieRed")
            {
                //To the value of totalZombiesR is added 1
                totalZombiesR += 1;
            }
        }
        //Message displayed on the console to show the total number of zombies
        Debug.Log("El total de Zombies es " + totalZombies);
        //Message displayed on the console to show the total number of Citizens
        Debug.Log("El total de ciudadanos es " + totalCitizen);
        //The TextZombies transform with the Text component is equal to the totalZombies value and that becomes the String
        TransformTextZombies.GetComponent<Text>().text = "Total Zombies: " + totalZombies.ToString();
        //The TextZombies transform with the Text component is equal to the totalZombies value and that becomes the String
        TransformTextZombiesRed.GetComponent<Text>().text = "Total Zombies Red: " + totalZombiesR.ToString();
        //The TextZombies transform with the Text component is equal to the totalZombies value and that becomes the String
        TransformTextCitizen.GetComponent<Text>().text = "Total Citizen: " + totalCitizen.ToString();
        //The Text transform with the Text component is equal to the totalZombies value and that becomes the String
        TransformWeaponStatus.GetComponent<Text>().text = "Active".ToString();
        //The canvas of zombies and citizens messages is made by calling the list created in instances in a foreach

        //The static versions of the amount of each entitie is matched to his public version of the variable
        totalZombiesRStatic = totalZombiesR;
        totalZombiesStatic = totalZombies;
        totalCitizenStatic = totalCitizen;
    }

    void Update()
    {
        //These texts need to be updated constantly to keep the count of those entitites, and his updated with the static versions of the variables to keep tracked
        //changes in other scripts.
        TransformTextZombiesRed.GetComponent<Text>().text = "Total Zombies Red: " + totalZombiesRStatic.ToString();
        TransformTextZombies.GetComponent<Text>().text = "Total Zombies: " + totalZombiesStatic.ToString();
        TransformTextCitizen.GetComponent<Text>().text = "Total Citizen: " + totalCitizenStatic.ToString();


        //If the time scale is different than 0
        if (Time.timeScale != 0)
        {
            //TransformMsgCitizen = TransformMsgCitizenStatic
            TransformMsgCitizen = TransformMsgCitizenStatic;
        }
        //The message lives and the life counter is displayed.
        TransformLifes.GetComponent<Text>().text = "Lifes: " + CounterLifesStatic.ToString();

        //Here is the key rotation and the speed according to the Time.deltaTime.
        keys.transform.Rotate(new Vector3(0f, 45f, 0f) * Time.deltaTime);

        MyTime += Time.deltaTime;

        //We check that if the fire1 button is released, and the status of the weapon is active, the message must go back to active.
        if (Input.GetButtonUp("Fire1"))

            if (inactive == false)
            {
                {
                    TransformWeaponStatus.GetComponent<Text>().text = "Active".ToString();
                }
            }

        //If Fire1 is left pressed (right click).       
        if (Input.GetButton("Fire1") && MyTime > Cadence)
        {

            //One is added to the timer
            Timer += 1;
            //If Timer is less than or equal to 50 then
            if (Timer <= 50)
            {
                //The Cadence time is calculated, which depends exclusively on the FireDelta value that is assigned within the inspector.
                Cadence = MyTime + FireDelta;

                //An object is created that will trigger the bullets.
                GameObject BulletController;

                //BulletConstroller will instantiate the bullets in the position and rotation of the BulletEmitter transform for all objects called Bullet.
                BulletController = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;

                //Added a Rigidbody to BulletController    
                Rigidbody rb = BulletController.GetComponent<Rigidbody>();

                //A force relative to the position of the BulletController is added.
                rb.AddRelativeForce(transform.forward * BulletForce);

                //Destroy BulletController in 2 seconds.
                Destroy(BulletController, 2f);
                //This shows the message that the gun is firing.
                TransformWeaponStatus.GetComponent<Text>().text = "Firing".ToString();

                //The variable cadence and my time are reset and the next internal calculation is expected.
                Cadence = Cadence - MyTime;
                MyTime = 0.0f;

            }


        }

        //If you hold down Fire2(Left click) and Timer is greater than or equal to 51. 
        else if (Input.GetButton("Fire2") && Timer >= 51)
        {
            //Timer is subtracted from Timer.
            Timer -= Timer;

            //If Timer is less than or equal to 50.
            if (Timer <= 50)
            {
                //The message that the weapon is active is displayed here.    
                TransformWeaponStatus.GetComponent<Text>().text = "Active".ToString();
                //Here the reload message is deleted.
                TransformMsgReload.GetComponent<Text>().text = "".ToString();
                inactive = false;
            }

        }



        //If Timer is over 50.
        if (Timer > 50)
        {

            //The message that the gun is inactive is displayed here.   
            TransformWeaponStatus.GetComponent<Text>().text = "Inactive".ToString();
            //Here is the message to reload the gun.
            TransformMsgReload.GetComponent<Text>().text = "Reload weapon using right click".ToString();
            inactive = true;
        }
    }
}
                                                                                                                                                  
               
         
    






    

   


  

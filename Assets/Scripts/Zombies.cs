using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Allied;
using UnityEngine.UI;

//This makes what is put in the script into a library.
namespace NPC
{
    //This makes what is put in the script into a library.
    namespace Enemy
    {

        
        //It says here that the Zombies class inherits from the classNPC.
        public class Zombies : classNPC
        {


            public void Colors()
            {
                //We create a new int variable that's equal to the number of elements in the zGusto enum.
                int gustos = ZGusto.GetNames(typeof(ZGusto)).Length;

                //we assing the gusto variable to the structure to a random number between 0 and the previous variable.
                zInformation.gusto = (ZGusto)Random.Range(0, gustos);

                //We create a new int that is randomly assigned between 0 and 3 to control the following switch.
                int casoZ = Random.Range(0, 3);

                //We create a new switch that'll control the color of the zombies with the previous variable.
                if (gameObject.name == "Zombie")
                {
                    switch (casoZ)
                    {

                        //in the first case, we'll get the material and we'll assign the cyan color to it.
                        case 0:
                            GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                            break;

                        //in the second case, we'll get the material and we'll assign the magenta color to it.
                        case 1:
                            GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                            break;

                        //in the third case, we'll get the material and we'll assign the green color to it.
                        case 2:
                            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                            break;
                    }
                }

                //we check the name of the zombie and assign his corresponding HP
                if (gameObject.name == "Zombie")
                {
                    zInformation.Health = Instancias.ZombiesStaticLife;
                }

                if (gameObject.name == "ZombieRed")
                {

                    zInformation.Health = Instancias.ZombiesStaticLifeRed;
                }
            }

            //We create a new structure that will store the information for the zombie
            //the color, the movement behaviour, the movement direction, and the part of body that wants to eat.
            public struct ZombieInformation
            {
      

                public ZGusto gusto;
                public zColor ZoColor;
                public float Health;
             
          

            }

       

            //We create a enumerator that stores the parts of body that the zombies can eat.
            public enum ZGusto
            {
                cerebro,
                ojos,
                corazón,
                intestinos,
                hígado,
            }


            //We create a new structure from the previous data, this structure is called Zinformation.
            public ZombieInformation zInformation;

            //This is done so that this class inherits from the method in the classNPC
            override public void Herent()
            {
                //This says the rotation speed ranges from 1 to 10.
                Rot = Random.Range(1, 10);
                //It says here to start what is in the Move method.
                Move();
                //The age of the civilians is added at random between 15 and 100 years of age.
                init.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
            }

            //A numberer is created to put the colors that the Zombie has on it
            public enum zColor
            {

                green,
                cyan,
                magenta,
                red,

            }
 


            //Start is called only once at the star.
            void Start()
            {
                //This is to obtain the components of the NPC class. 
                base.Herent();
                //Here an int is created that is the same as the zColor names.                 
                int ZoColor = zColor.GetNames(typeof(zColor)).Length;
                //This gets the renderer component of the object.
                this.gameObject.GetComponent<Renderer>();
                //The Colors method is activated.
                Colors();
            }

            

            //This checks the collision of the other object.
            void OnCollisionEnter(Collision other)
            {
                //It says here that if other collides with the citizen object then...
                if (other.gameObject.GetComponent<Citizen>())
                {
                    //Citizen c is the same as the other object with the citizen component    
                    Citizen c = other.gameObject.GetComponent<Citizen>();
                    //Zombies z equals object c.
                    Zombies z = c;

                 //After the zombiefication the amount of zombies is increased by 1 and the citizen amount is reduced by one
                    Instancias.totalZombiesStatic += 1;
                    Instancias.totalCitizenStatic -= 1;

                }

                //We check if the collision is with the bullet

                if (other.gameObject.name == ("Bullet(Clone)"))
                {
                    //the health of the zombie is reduced by the bullet damage
                    zInformation.Health -= Instancias.BulletDamageStatic;
                    //Debug.Log(zInformation.Health);
                   
                    //If the zombie's health is 0 or less the destroyed function is called.
                    if (zInformation.Health <= 0)
                    {

                        destroyed();
                        
                    }

                }
            }

            void destroyed()
            {
                //we check the name of the zombie to modify the corresponding entitie amount
                if (gameObject.name == "ZombieRed")
                {
                    //the gameobject is destroyed
                    Destroy(gameObject) ;

                    //the reference for the main list that stores the entitites is deleted, so some errors of accesing a object that doesn't exist anymore are avoided.
                    Instancias.Objects.Remove(gameObject);

                    //the amount of zombies is reduced by 1
                   Instancias.totalZombiesRStatic -= 1;

                 


                }

                if (gameObject.name == "Zombie")
                {

                    Destroy(gameObject);

                    Instancias.Objects.Remove(gameObject);
                    Instancias.totalZombiesStatic -= 1;

               

                }
            }

           
        }
    }
}         

         
 
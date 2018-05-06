using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Allied;

//This makes what is put in the script into a library.
namespace NPC
{
    //This makes what is put in the script into a library.
    namespace Enemy
    {
        //Al zombie se le debe dar una edad y cuando un zombie convierta a un ciudadano en zombie éste debe mantener la edad del ciudadano que se convirtió.
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

            //We create a new structure that will store the information for the zombie
            //the color, the movement behaviour, the movement direction, and the part of body that wants to eat.
            public struct ZombieInformation
            {
                //public Color color;
             
                public ZGusto gusto;
                public zColor ZoColor;
       
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

            override public void Herent()
            {

                Rot = Random.Range(1, 10);
                Move();
               // init.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
               
                
            }

         
            public enum zColor
            {

                green,
                cyan,
                magenta,

            }

           

            //Start is called only once at the star.
            void Start() 
            {

               base.Herent();
               int ZoColor = zColor.GetNames(typeof(zColor)).Length;
               this.gameObject.GetComponent<Renderer>();
               Colors();
            
            }
         
           
            void OnCollisionEnter(Collision other)
            {
                if(other.gameObject.GetComponent<Citizen>())
                {

                    Citizen c = other.gameObject.GetComponent<Citizen>();
                    Zombies z = c;

                }
                
            }                       
        }
        
    }

    
}         

         
 
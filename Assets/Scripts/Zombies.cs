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

            //public float DistanciaMinima = 5;
            //We create a new structure that will store the information for the zombie
            //the color, the movement behaviour, the movement direction, and the part of body that wants to eat.
            public struct ZombieInformation
            {
                //public Color color;
                /*public ZComportamiento comportamiento;
                public int mov;
                public int rot;
                public int pur;
                */ 
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

            //we create a enumerator that stores the different states that the zombie can take.
         /*    public enum ZComportamiento
            {
             
                idle,
                moving,
                rotating,
                pursuing,
        
            } */

            //We create a new int variable that's equal to the number of elements in the ZComportamiento enum.
            //int comportamiento = ZComportamiento.GetNames(typeof(ZComportamiento)).Length;
  
            //We create a new structure from the previous data, this structure is called Zinformation.
            public ZombieInformation zInformation;

            override public void Herent()
            {

                Rot = Random.Range(1, 10);
                Move();
                init.age = Random.Range(15, 100);//the age of the civilians is added at random between 15 and 100 years of age.
               
                
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

            //Update is called each frame
           /*  private void Update()
            {
                float Distancia = Vector3.Distance(Objetivo.position, transform.position);
                float speedRot = Random.Range(0.1f,1);
                //We check if the Zcomportamiento value is = to 1; in that case the zombie will move.
                //The assignation to that variable is in the coroutine.
                if (zInformation.comportamiento == (ZComportamiento)1)
                {
                    //We start a switch with the mov vale that is assigned in the coroutine.
                    switch (zInformation.mov) 
                    {
                        //In the first case the zombie will move forward.
                        case 0:
                            transform.Translate(Vector3.forward * Time.deltaTime);
                        break;

                        //In the second case the zombie will move backwards.
                        case 1:
                            transform.Translate(Vector3.back * Time.deltaTime);
                        break;

                         //In the third case the zombie will move to the right.
                        case 2:
                            transform.Translate(Vector3.right * Time.deltaTime);
                        break;

                        //In the third case the zombie will move to the left.
                        case 3:
                            transform.Translate(Vector3.right * Time.deltaTime);
                         break;
             
                    }   
                    
                }

                //We check if the Zcomportamiento value is = to 2; in that case the zombie will move.    
                else if(zInformation.comportamiento ==(ZComportamiento)2)
                {
                    //The assignation to that variable is in the coroutine.
                    switch(zInformation.rot)
                    {
                         //In the first case the broken zombie on the right
                        case 0:
                            transform.Rotate(Vector3.up * speedRot);
                        break;
                         //In the second case the broken zombie on the right
                        case 1:
                            transform.Rotate(-Vector3.up * speedRot);
                        break;    
               
                    }

                }

                
                
                    if (Distancia <= DistanciaMinima)
                    {
                        Vector3 PosicionTarget = new Vector3(Objetivo.position.x, this.transform.position.y, Objetivo.position.z);
                        transform.LookAt(PosicionTarget);
                    }
 */
                

              
                
         
            


            //We create a coroutine that is called estado 
           /*  IEnumerator Estado(float time)
            {   
                yield return new WaitForSeconds(time);
                //We assign the comportamiento value of the structure to be between 0 and the comportamiento max value.
                zInformation.comportamiento = (ZComportamiento)Random.Range(0, comportamiento);
                //We assign the mov value of the structure to be between 0 and the 4, because we are using 4 different moves options.
                zInformation.mov = Random.Range(0,4);
                //We assign the rot value of the structure to be between 0 and the 2, because we are using 2 different moves options.
                zInformation.rot = Random.Range(0,2);
                //We repeat the coroutine each 3 seconds.
                StartCoroutine(Estado(3));
            }  */
            


//Zombie hereda de NPC
 
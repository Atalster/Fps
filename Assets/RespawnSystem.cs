using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RespawnSystem : MonoBehaviour
{
    public GameObject enemys;
    public GameObject enemy;
    public float nasru;
    public float stagetime1;
    public float stagetime2;
    public float stagetime3;
    public float stagetime4;
    public bool stageTime1;
    public bool stageTime2;
    public bool stageTime3;
    public bool stageTime4;
    public Text stages;
    public string STAGE1 = "STAGE 1";
    public string STAGE2 = "STAGE 2";
    public string STAGE3 = "STAGE 3";
    public string STAGE4 = "STAGE 4";
    public Animator Textanimator;
     private string currentState;
     public GameObject Player;
     public bool Isdone;
     public bool isdone;
public bool IIsdone;
public bool iisdone;
    // Start is called before the first frame update
    public void Start()
    {
        nasru = 10f;
        
    }

    void ChangeAnimationState(string newState)
    {       
        //stops the same animation from interrupting itself
        if (currentState == newState) return;

        //Play new animation
         Textanimator.Play(newState);

        //Reassign the current state
        currentState = newState;

    }
    // Update is called once per frame
    public void Update()
    {
         nasru -= Time.deltaTime;
          stagetime1 -= Time.deltaTime;
          stagetime2 -= Time.deltaTime;
          stagetime3 -= Time.deltaTime;
          stagetime4 -= Time.deltaTime;

         if(nasru <= 0)
         {
              //If stage is not 1, spanws red enemys
               if (stageTime1 == false && stageTime4 == false && stageTime3 == false && stageTime2 == false){
              GameObject go = GameObject.Instantiate(enemys);
         go.transform.position = transform.position;
         nasru = 5f;
               }
               //if stage is 1, spawns green/purple enemys
               if (stageTime1 == true)
               {
                     GameObject go = GameObject.Instantiate(enemy);
         go.transform.position = transform.position;
         nasru = 3.5f;  
               }

    if (stageTime2 == true)
               {
                     GameObject go = GameObject.Instantiate(enemys);
         go.transform.position = transform.position;
         nasru = 2.5f;  
               }


               if (stageTime3 == true)
               {
                     GameObject go = GameObject.Instantiate(enemy);
         go.transform.position = transform.position;
         nasru = 1.5f;  
               }

               if (stageTime4 == true)
               {
                     GameObject go = GameObject.Instantiate(enemys);
         go.transform.position = transform.position;
         nasru = 1f;  
               }




               //changes time for spawning on higher stages
               if (Isdone == false)
               {
           if (stagetime1 <= 0)
         {
              nasru = 3.5f;
             
               stageTime1 = true;
               stages.text = STAGE1;
               ChangeAnimationState("Stageanim");
               Invoke("Stopstageanim", 2f);
               Isdone = true;
         
         }
               }

            if (isdone == false)
            {   

         //changes time for spawning on higher stages
                if (stagetime2 <= 0)
         {
              nasru = 2.5f;
               nasru -= Time.deltaTime;
          stageTime1 = false;  
          stageTime2 = true;
          stages.text = STAGE2;
          ChangeAnimationState("Stageanim");
          Invoke("Stopstageanim", 2f);
          isdone = true;
         }
            }

          if (IIsdone == false)
          {
               if (stagetime3 <= 0)
               {
                   nasru = 1.5f;
               nasru -= Time.deltaTime;
          stageTime1 = false;  
          stageTime2 = false;
          stageTime3 = true;
          stages.text = STAGE3;
          ChangeAnimationState("Stageanim");
          Invoke("Stopstageanim", 2f);  
          IIsdone = true;
               }




          }

               if (iisdone == false)
               {
                    if (stagetime4 <= 0)
                    {
                      nasru = 1f;
               nasru -= Time.deltaTime;
          stageTime1 = false;  
          stageTime2 = false;
          stageTime3 = false;
          stageTime4 = true;
          stages.text = STAGE4;
          ChangeAnimationState("Stageanim");
          Invoke("Stopstageanim", 2f);
          iisdone = true;  
                    }

               }


         }

      
          if (Player.activeSelf == false)
          {
               nasru = 10000f;
               stagetime1 = 10000f;
               stagetime2 = 10000f;
               stagetime3 = 10000f;
               stagetime4 = 10000f;
               return;
          }
     

    
           
   
    }
    


     void Stopstageanim()
         {
              ChangeAnimationState("New State");
            stages.text = " ";  
         }
  

    
        
     
    }
    




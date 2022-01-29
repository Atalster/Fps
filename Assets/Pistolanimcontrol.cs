using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistolanimcontrol : MonoBehaviour
{
    private string currentState;
    public Animator animator;
    private bool IsSprinting;
    private bool IsWalking;
    private bool Is_aiming;
    private bool Is_shooting;
    private bool Is_inspecting;
    private bool Is_reloading;
    private double stopinspecttime = 3.30;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

     void ChangeAnimationState(string newState)
    {       
        //stops the same animation from interrupting itself
        if (currentState == newState) return;

        //Play new animation
         animator.Play(newState);

        //Reassign the current state
        currentState = newState;

    }

    // Update is called once per frame
    void Update()
    {
      
            


                //Walking animations
             if (Input.GetKeyDown(KeyCode.W)&& Is_aiming == false && Is_inspecting == false && Is_reloading == false){
                 
                ChangeAnimationState("PistolWalking");
                
                
                IsWalking = true;
          }

        if (Input.GetKeyUp(KeyCode.W)&& Is_aiming == false && Is_inspecting == false && Is_reloading == false){
            ChangeAnimationState("New State");
            
            IsWalking = false;
        }






                //Sprinting animations
                
               if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)&& Is_aiming == false && Is_inspecting == false && Is_reloading == false))
            {
               ChangeAnimationState("PistolSprinting");
              
               
                 Invoke("Sprintingweapon", 0.25f);
                 
                 IsSprinting = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp(KeyCode.W)&& Is_aiming == false && Is_inspecting == false && Is_reloading == false))
            {
                ChangeAnimationState("PistolEndSprinting");
               
               
               IsSprinting = false;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)&& Is_aiming == false && Is_inspecting == false && Is_reloading == false))
            {
                   
                ChangeAnimationState("PistolEndSprinting");
                Invoke("SprintingtoWalking", 0.15f);

                 IsSprinting = false;
                 IsWalking = true;
                 
           
                

            }
               
        //ADS animations
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeAnimationState("PistolADS");
            Is_aiming = true;
       
        }
        if (Is_aiming)
        {
            if(Input.GetButtonUp("Fire2"))
            {
                ChangeAnimationState("PistolUn-ADS");
                Is_aiming = false;
              
            }

        }
   //Inspect animations
              if (Input.GetKeyDown(KeyCode.G))
              {
                ChangeAnimationState("PistolInspect");
                Is_inspecting = true;
        Invoke("StopInspecting", 3.30f);
              } 

              ///ReloadingAnimations
                if (Input.GetKeyDown(KeyCode.R))
              {
                  ChangeAnimationState("PistolReloadBIM");
               Is_reloading = true;
               Invoke("StopReloading", 2.22f);
              }

             
 }

            void SprintingtoWalking()
            {
                ChangeAnimationState("PistolWalking");
            }

  void Sprintingweapon(){

               ChangeAnimationState("PistolSprinting 0");
            }
            void StopInspecting()
            {
                    Is_inspecting = false;
            }
            void StopReloading()
            {
                Is_reloading = false;
            }
}

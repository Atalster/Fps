using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AnimControl : MonoBehaviour
{
    // Simple Variables to identify our animator and delay between certain animations
   public GameObject theNPC;
   public float delay = .90f;
   public Animator animator;
    public Animator animator1;
   public Animator animator2;
   private bool IsStartwalking = false;
   private bool isInspecting = false;
   public GameObject scopeOverlay;
   private bool isScoped = false;
   public float aimrate = 1f;
   public float adsrate = 0.1f;
   public GameObject weaponCam;
   public Camera mainCamera;
   public float scopeFOV = 15f;

   private float nextTimeToAim = 0f;
   public GameObject Player;

   
    private string currentState;
    const string RECOIL_50CAL = "Recoil";
    public Gun gun;
    public AnimationClip Recoil;
    public bool is_Scoping;
    public GameObject mainCam;
    public GameObject ADS;
    public GameObject Crosshair;
    private bool isADS = false;
    int animLayer = 0;
    private bool Isreloading;
public GameObject weaponHolder;
const string RECOILONAIM_ADS = "RecoilOnAim2";
public AudioSource reload;

public AudioSource walking;
public AudioSource startendwalking;
public AudioSource sprinting;
public AudioSource startendsprinting;
public AudioSource Scopein;
public AudioSource Scopeout;
public AudioSource Inspect50cal;
public GameObject WeaponHolder2;
public GameObject Sniper;
private bool IsWalking;
private bool IsSprinting;



    // Start is called before the first frame update
    void Start()
    {
            animator = GetComponent<Animator>();
            animator1 = ADS.GetComponent<Animator>();
            animator2 = Crosshair.GetComponent<Animator>();
        
        
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

    void ChangeAnimationStateADS(string newState)
    {
       
        //stops the same animation from interrupting itself
        if (currentState == newState) return;

        //Play new animation
         
         animator1.Play(newState);

        //Reassign the current state
        currentState = newState;
         }
         



         

            void FixedUpdate()
            {
                    //Disables animations while gun isn't selected
                if (weaponHolder.activeInHierarchy == false)

        {
            return;
        }
        else
        {
            
        }

                //Reload animations 50cal

                //Turns off ADS and plays animation if out of ammo
                if (is_Scoping == true && gun.is_reloading == true)
            {
                is_Scoping = false;
                isScoped = false;
                Scopeout.Play();
               return;
            }
           

            
           
                    //Standard Reload animation 50cal
                    if (gun.is_reloading)
                    {
                       
                        ChangeAnimationState("Reload50Cal");
                       animator.SetBool("Isreloading", true);
                       return;
                                 
                          }
                   
                


                //Recoil animations
                if (gun.is_Shooting == true)
                {
                    
                    ChangeAnimationState("Recoil");
                    
                }
                else
                {
                    ChangeAnimationState("Idle");
                    
                }
                //Recoil while aiming
                if (is_Scoping == true && gun.is_Shooting == true)
                {
                    ChangeAnimationStateADS(RECOILONAIM_ADS);
                    StartCoroutine(ADSS());
                    isADS = true;
             }
             else
             {
                 isADS = false;
             }
                 
             
                if (isADS == true)
                {
                    StartCoroutine(ADSS());
                }
                    else
                    {
                        noADSS();
                    }
                
                
            }
  
   

          IEnumerator ADSS()
          {
              
                yield return new WaitForSeconds(1f);
              ADS.GetComponent<Animator>().Rebind();
          }

          void noADSS()
          {
                ADS.GetComponent<Animator>().enabled = true;         
         }
        
        
   void Update()
    {
        if (weaponHolder.activeInHierarchy == false)

        {
            return;
        }
  else
        {
            
        }
        
             if (is_Scoping | isScoped | isInspecting | IsWalking | IsSprinting | gun.is_Shooting)
           {
                WeaponHolder2.GetComponent<EnableGuns>().enabled = false;
                Sniper.GetComponent<EnableGuns>().enabled = false;
           }

           else
           {
                WeaponHolder2.GetComponent<EnableGuns>().enabled = true;
                Sniper.GetComponent<EnableGuns>().enabled = true;
           }


           if (gun.is_reloading)
           {
                WeaponHolder2.GetComponent<EnableGuns>().enabled = false;
                Sniper.GetComponent<EnableGuns>().enabled = false;
           }

           else
           {
                WeaponHolder2.GetComponent<EnableGuns>().enabled = true;
                Sniper.GetComponent<EnableGuns>().enabled = true;
           }

            if (gun.is_reloading)

{
    return;
}          

            //Scope Animations
            if (Input.GetButtonDown("Fire2") )
            {
                
                animator.SetBool("IsScoped", true);
                theNPC.GetComponent<Animator>().Play("Scope");
                isScoped = true;
                Scopein.Play();
            }

        
                 //Makes sure when reloading after ADS-ing Scopeout sound effect does not play again
            if (is_Scoping == false && gun.is_reloading == true && isScoped == false)
            {
                return;
            }
            
            if (Input.GetButtonUp("Fire2"))
            {
                animator.SetBool("IsScoped", false);
               isScoped = false; 
               Scopeout.Play();
    
            }
                
               


                //Inspect animations

                if (Input.GetButtonDown("g"))
                {
                    Inspect50cal.Play();
                    theNPC.GetComponent<Animator>().Play("WeaponInspect50Cal");
                         isInspecting = true;
                }


                    //Walking animations
             if (Input.GetKeyDown(KeyCode.W)){
                 
                theNPC.GetComponent<Animator>().Play("StartWalkingweapon");
                startendwalking.Play();
                Invoke("Walkingweapon", 0.25f);
                IsWalking = true;
          }

        if (Input.GetKeyUp(KeyCode.W)){
            theNPC.GetComponent<Animator>().Play("EndWalkingweapon");
            walking.Stop();
            startendwalking.Play();
            IsWalking = false;
        }

         
        
      
    
           
                //Sprinting animations
                
               if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
            {
                theNPC.GetComponent<Animator>().Play("StartSprintingweapon");
               walking.Stop();
                startendsprinting.Play();
                 Invoke("Sprintingweapon", 0.25f);
                 animator.SetBool("Is Startsprinting", true);
                 IsSprinting = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp(KeyCode.W)))
            {
                theNPC.GetComponent<Animator>().Play("EndSprintingweapon");
                sprinting.Stop();
               startendsprinting.Play();
               IsSprinting = false;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
            {
                 theNPC.GetComponent<Animator>().Play("StartWalkingweapon");
                 sprinting.Stop();
                 IsSprinting = false;
                 IsWalking = true;
                 
                 startendwalking.Play();
                Invoke("Walkingweapon", 0.25f);

            }

             if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp(KeyCode.W)))
            {
                 theNPC.GetComponent<Animator>().Play("EndWalkingweapon"); 
                 walking.Stop();
                 startendwalking.Play();  
                 IsSprinting = false;             
            }

               
            }
            void EndInspect(){
                theNPC.GetComponent<Animator>().StopPlayback();
              
            }
            
            void Walkingweapon(){
                theNPC.GetComponent<Animator>().Play("Walkingweapon");
                walking.Play();
            }

            void Sprintingweapon(){
                theNPC.GetComponent<Animator>().Play("Sprintingweapon");
                sprinting.Play();
            }

            IEnumerator OnScoped()
            {
                
                yield return new WaitForSeconds(.15f);
                Crosshair.SetActive(false);
                scopeOverlay.SetActive(true);
                weaponCam.SetActive(false);
                mainCamera.fieldOfView = 15f;
                GetComponent<Animator>().Rebind();
                is_Scoping = true;
            }

            IEnumerator OnUnscoped()
            {
                yield return new WaitForSeconds(.15f);
                Crosshair.SetActive(true);
                scopeOverlay.SetActive(false);
                weaponCam.SetActive(true);
                mainCamera.fieldOfView = 63.4f;
                 GetComponent<Animator>().enabled = true;
                 is_Scoping = false;
                 
            }
           
             // ADS Image Animations
           void LateUpdate()
           {

               if (weaponHolder.activeInHierarchy == false)
               {
                   return;
               }
                 else
        {
            
        }

             if (isScoped)
                {

                    
               StartCoroutine(OnScoped());
                }
                else
                {

                  
                   StartCoroutine(OnUnscoped());
                }
           }


          
        }
   
   
   
   

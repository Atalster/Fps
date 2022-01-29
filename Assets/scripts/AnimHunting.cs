using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHunting : MonoBehaviour
{
   // Start is called before the first frame update


   public Animator animator;
   private string currentState;
   private bool Inspecting;
   private bool Scoped = false;
   public GameObject theNPC;
   public AudioSource Alpharogueinspect;
   public AudioSource BullettingAlphaRogue;
   private bool isScoped;
   public Gunhuntingrifle gunhuntingrifle;
    void Start()
    {
           
           
    }

    void Update()
    {
        if (gunhuntingrifle.is_Reloading)
        {
            return;
        }
      
        
          if (Input.GetKeyDown(KeyCode.G))
                {
                        Alpharogueinspect.Play();
                    animator.SetBool("Inspecting", true);
                    
                    Invoke ("BulletTing", 1.6f);
                    Invoke ("InspectStop", 4.3f);
                }

           


                //Scope Animations
            if (Input.GetButtonDown("Fire2") )
            {
                
                animator.SetBool("isScoped", true);
                theNPC.GetComponent<Animator>().Play("Huntingriflescope");
                isScoped = true;
            }

              if (Input.GetButtonUp("Fire2"))
            {
                theNPC.GetComponent<Animator>().Play("HuntingrifleUn-Scope");
                animator.SetBool("isScoped", false);
               isScoped = false; 
               
    
            }
 }

 public void BulletTing()
 {
        BullettingAlphaRogue.Play();
 }
        public void InspectStop(){

            animator.SetBool("Inspecting", false);
           
        }

}

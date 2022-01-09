using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl_Test2 : MonoBehaviour
{




   public Animator animator;
    private string currentState;
    const string RECOIL_50CAL = "Recoil";
    public Gun gun;
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

            void FixedUpdate()
            {
                if (gun.is_Shooting == true)
                {
                    
                    ChangeAnimationState("Recoil");
                }
                else
                {
                    ChangeAnimationState("New State");
                }
            }


    
}



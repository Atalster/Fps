using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
   public GameObject AmmoLeft;
   public Gun gun;
   public static int theAmmo;
    bool isDone = false;

   void Start()
   {
       theAmmo = 3;
       AmmoLeft.GetComponent<Text>().text = theAmmo + "/3";  
       
   }

    // Update is called once per frame
    void Update()
    {
        if (!isDone){


                if (gun.is_reloading)
                {
                   StartCoroutine(ReloadAmmo()); 
                   isDone = true;
                }
        
        if (gun.is_Shooting)
        {
            
            AmmoSubtract();  
            isDone = true;
            Invoke ("Stall", 1.1f);
             }
             
        }
 
    }

    void Stall()
    {
        isDone = false;
    }
    IEnumerator ReloadAmmo()
    {
        yield return new WaitForSeconds (5f);
        theAmmo = 3;
        AmmoLeft.GetComponent<Text>().text = theAmmo + "/3";
         isDone = false;
    }

    void AmmoSubtract()
    {
         

        

                   theAmmo -= 1;
                    AmmoLeft.GetComponent<Text>().text = theAmmo + "/3";
                    
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPistol : MonoBehaviour
{
    public float damage = 10f;
        public float range = 100f;
        public Camera fpsCam;
       

        
        public float fireRate = 1f;
        public bool Is_reloading = false;

        private float nextTimeToFire = 0f;
        public  bool Is_shooting;
        
        public int maxAmmo = 3;
       public int currentAmmo;
        public float reloadTime = 1f;
        private string currentState;
        private bool Is_aiming;
       public bool OOB;
        public int score;
        
        
        public GameObject Scoremanager;
public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
            animator = GetComponent<Animator>();
    }
    
    void OnEnable()
    {
        Is_reloading = false;
        
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
           {
        if (Is_reloading || OOB)
        return;

          if (currentAmmo <= 0)
        {
            OOB = true;
            ChangeAnimationState("PistolOOB");
            StartCoroutine(Reload());
            
            return;
            
        }

        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
                Is_shooting = true;
                Invoke ("Noshoot", 0.50f);
        }
    }

            

           if (Is_shooting && GetComponent<Pistolanimcontrol>().Is_aiming)
         
        {
            ChangeAnimationState("PistolRecoilADS");
        }
      
        
        else if (Is_shooting)
        {
            ChangeAnimationState("PistolRecoil");
        }
         else
        {
            ChangeAnimationState("New State");
        }
    
    IEnumerator Reload()
       {
           
         yield return new WaitForSeconds(0.9f);
           
           Is_reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
            
           currentAmmo = maxAmmo;
            Is_reloading = false;
            OOB = false;
       }

       IEnumerator Reload1()
       {
         
           Is_reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
    
           currentAmmo = maxAmmo;
            Is_reloading = false;
       }

        if (Input.GetKey(KeyCode.R) && currentAmmo > 0 && currentAmmo < maxAmmo )
       {
           StartCoroutine(Reload1());
           return;
       }

   

}

     void Noshoot()
     {
                Is_shooting = false;
              
     }
       
    public void Shoot() 
    {
       
     
       
        
        

        currentAmmo--;
       
           
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))
        {
            
           Debug.Log(hit.transform.name); 
          Target target =  hit.transform.GetComponent<Target>();
        
          if (target != null)
          {
              target.TakeDamage(damage);
          }

     
         
        }
       
    }
}

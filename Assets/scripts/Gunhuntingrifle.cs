using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunhuntingrifle : MonoBehaviour
{
    public bool is_shooting;
    public Camera fpsCam;
     public int maxAmmo = 3;
        private int currentAmmo;
        public float reloadTime = 1f;
        public float damage = 10f;
        public float range = 100f;
        private float nextTimeToFire = 0f;
         public float fireRate = 1f;
        public bool is_Reloading = false;
        public Animator animator;
        private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        animator = GetComponent<Animator>();
       
    }

     void OnEnable()
    {
        is_Reloading = false;
        
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
        if (is_Reloading)
        return;

          if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            
            return;
            
        }

        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
                is_shooting = true;
                Invoke ("Noshoot", 0.2f);
        }
       
   
       

       IEnumerator Reload()
       {
           
         yield return new WaitForSeconds(1f);
           
           is_Reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
            
           currentAmmo = maxAmmo;
            is_Reloading = false;
       }

       IEnumerator Reload1()
       {
         
           is_Reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
    
           currentAmmo = maxAmmo;
            is_Reloading = false;
       }

       if (Input.GetKey(KeyCode.R) && currentAmmo > 0 && currentAmmo < 3 )
       {
           StartCoroutine(Reload1());
           return;
       }

        if (is_shooting)
        {
            ChangeAnimationState("Huntingriflerecoil");
        }
        else
        {
            ChangeAnimationState("Huntingrifelidle");
        }

    }


      void Noshoot()
     {
                is_shooting = false;
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

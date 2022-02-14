using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunhuntingrifle : MonoBehaviour
{
    public bool is_shooting;
    public Camera fpsCam;
     public int maxAmmo = 3;
        public int currentAmmo;
        public float reloadTime = 1f;
        public float damage = 10f;
        public float range = 100f;
        private float nextTimeToFire = 0f;
         public float fireRate = 1f;
        public bool is_Reloading = false;
        public Animator animator;
        private string currentState;
        public AudioSource gunshot;
        public AudioSource reload;
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

        if (Input.GetButton("Fire1"))
        {
            
            Shoot();
                is_shooting = true;
                Invoke ("Noshoot", 0.1f);
        }
       
   
       

       IEnumerator Reload()
       {
            
         yield return new WaitForSeconds(0.5f);
reload.Play();
          yield return new WaitForSeconds(0.1f);
           is_Reloading = true;
           Debug.Log("Reloading...");
           ChangeAnimationState("HuntingRifleReload");
           yield return new WaitForSeconds(reloadTime);
            
           currentAmmo = maxAmmo;
            is_Reloading = false;
            ChangeAnimationState("Huntingrifelidle");
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
       
        
      gunshot.Play();
        Invoke("stopgunshot", 0.5f);

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
    void stopgunshot()
    {
        gunshot.Stop();
    }
}

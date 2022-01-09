
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
        public float damage = 10f;
        public float range = 100f;
        public Camera fpsCam;
        public ParticleSystem muzzleFlash;
        public AnimControl animcontrol;
       

        public AudioSource GunShot; 
        public GameObject Weaponholder; 
       
        public GameObject impactEffect;
        public float fireRate = 1f;
        public bool is_reloading = false;

        private float nextTimeToFire = 0f;
        public  bool is_Shooting;
        public GameObject Crosshair;
        public int maxAmmo = 3;
        private int currentAmmo;
        public float reloadTime = 1f;
        Quaternion shotAngle = Quaternion.identity;
        
public AudioSource reload;



        
        public Animator animator;
    private string currentState;
    // Start is called before the first frame update
    const string RELOAD50CAL = "Reload50Cal";
    
    void Start()
    {
        currentAmmo = maxAmmo;
            animator = GetComponent<Animator>();

           

    }

    void OnEnable()
    {
        is_reloading = false;
        
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
                 
            }
    // Update is called once per frame
        void Update()   
    {
        if (is_reloading)
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
                is_Shooting = true;
                Invoke ("Noshoot", 1f);
        }
       
   
       

       IEnumerator Reload()
       {
           reload.Play();
         yield return new WaitForSeconds(1f);
           
           is_reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
            
           currentAmmo = maxAmmo;
            is_reloading = false;
       }

       IEnumerator Reload1()
       {
         reload.Play();
           is_reloading = true;
           Debug.Log("Reloading...");
           yield return new WaitForSeconds(reloadTime);
    
           currentAmmo = maxAmmo;
            is_reloading = false;
       }

       if (Input.GetKey(KeyCode.R) && currentAmmo > 0 && currentAmmo < 3 )
       {
           StartCoroutine(Reload1());
           return;
       }
        
     }

     void Noshoot()
     {
                is_Shooting = false;
     }
       
    public void Shoot() 
    {
       
        
        animcontrol.is_Scoping = false;
        
        GunShot.Play();
        muzzleFlash.Play();

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


using UnityEngine;

public class Target : MonoBehaviour
{
   public float health = 50f;
   public float dieDelay = 0f;

   public void TakeDamage (float amount)
   {
       health -= amount; 
       if (health <= 0f)
       {
           Invoke("Die", 0.4f);
          
       }
   }
    void Die ()
    {

        Destroy(gameObject);
    }
}

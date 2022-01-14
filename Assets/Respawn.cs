using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject _player;
    public float health = 50f;
    public Camera deadcamera;
  

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.O))
          {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
          }
        
    }

    public void TakeDamage (float amount)
   {
       health -= amount; 
       if (health <= 0f)
       {
             Destroy(gameObject);
             deadcamera.enabled = true;
             deadcamera.GetComponent<AudioListener>().enabled = true;
       }
       
   }
}

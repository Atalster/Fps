using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject Items;
    public float health = 50f;
    public Camera deadcamera;
    private bool isDed = false;
    public GameObject DED;
  void Start()
  {
      deadcamera.enabled = false;
  }
    // Update is called once per frame
    void Update()
    {
      

          if (deadcamera.enabled == true && isDed == true)
          {
              if (Input.GetKeyDown(KeyCode.R))
              {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
              }
          }
        
    }

    public void TakeDamage (float amount)
   {
       health -= amount; 
       if (health <= 0f)
       {
             Items.SetActive(false);
             DED.SetActive(true);
             isDed = true;
             deadcamera.enabled = true;
             deadcamera.GetComponent<AudioListener>().enabled = true;
       }
       
   }
}

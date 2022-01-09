using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject _player;
  

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.O))
          {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
          }
        
    }
}

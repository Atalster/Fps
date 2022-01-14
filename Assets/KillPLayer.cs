using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPLayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    public Camera deadcamera;
    public float damage = 10f;
    public Respawn respawn;

    


    void Start()
    {
        deadcamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadcamera.enabled == false)
        {
            deadcamera.GetComponent<AudioListener>().enabled = false;
        }

             if (deadcamera.enabled == true)
        {
            deadcamera.GetComponent<AudioListener>().enabled = true;
        }
            

    }

    

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject == _player)
            {
                 if (respawn != null)
          {
              respawn.TakeDamage(damage);
          }
                
            }
    }



}

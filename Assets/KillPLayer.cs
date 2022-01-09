using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPLayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    public Camera deadcamera;

    


    void Start()
    {
        deadcamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject == _player)
            {
                Destroy(collision.gameObject);
                 deadcamera.enabled = true;
            }
    }
}

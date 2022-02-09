using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePlayerDistance : MonoBehaviour
{
    [SerializeField]
   private Transform _player;
   public float Speed = 4f;
   public Camera deadCamera;
    private void Update()
    {

          if (deadCamera.enabled == true)
        {
            return;
        }
       
        Vector3 direction = _player.position - transform.position;
      
        direction.Normalize();
        Debug.Log(transform.position.magnitude);
        Debug.DrawRay(transform.position, direction, Color.blue);
        transform.Translate(direction * Time.deltaTime * Speed);
        
       
    
    }
}

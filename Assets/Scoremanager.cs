using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{

   public int Score;
   public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

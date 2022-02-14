using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyspeedUI : MonoBehaviour
{

    public Text enemyspeed;
    public string Speed = "m/s";
    public CalculatePlayerDistance calculatePlayerDistance;
    // Start is called before the first frame update
    void Start()
    { 
        enemyspeed.text = "ENEMY SPEED: " + calculatePlayerDistance.Speed + " " + Speed;
    }

    // Update is called once per frame
    void Update()
    {
        enemyspeed.text = "ENEMY SPEED: " + calculatePlayerDistance.Speed + " " + Speed;
    }
}

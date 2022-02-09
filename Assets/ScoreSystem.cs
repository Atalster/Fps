using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float PlayerAlivetime;
    public GameObject _player;
    public int score;
    private bool Isdone;



    // Start is called before the first frame update
    void Start()
    {
        PlayerAlivetime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAlivetime += Time.deltaTime;

        if (Isdone == false) {

  if (_player.activeSelf == false && PlayerAlivetime > 1f && PlayerAlivetime <= 10f)
       {
           score = 10;
           Isdone = true;
       }


       if (_player.activeSelf == false && PlayerAlivetime > 10f && PlayerAlivetime <= 25f)
       {
           score = 1045;
           Isdone = true;
       }

        if (_player.activeSelf == false && PlayerAlivetime > 25f && PlayerAlivetime <= 45f)
       {
           score = 1950;
           Isdone = true;
       }


           if (_player.activeSelf == false && PlayerAlivetime > 45f && PlayerAlivetime <= 61f)
       {
           score = 2875;
           Isdone = true;
       }

           if (_player.activeSelf == false && PlayerAlivetime > 61f && PlayerAlivetime <= 95f)
       {
           score = 3490;
           Isdone = true;
       }

              if (_player.activeSelf == false && PlayerAlivetime > 95f && PlayerAlivetime <= 145f)
       {
           score = 4699;
           Isdone = true;
       }

                  if (_player.activeSelf == false && PlayerAlivetime > 145f && PlayerAlivetime <= 165f)
       {
           score = 5999;
           Isdone = true;
       }

              if (_player.activeSelf == false && PlayerAlivetime > 165)
       {
           score = 10000;
           Isdone = true;
       }




        }
    }
}

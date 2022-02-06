using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Scoremanager;
    private bool Isdone;
       public GameObject enemys;
       
    // Start is called before the first frame update
    void Start()
    {
        enemys = GameObject.FindWithTag("enemys");
    }

    // Update is called once per frame
    void Update()
    {
        if (Isdone == false){
        if (Scoremanager.GetComponent<Scoremanager>().Enemy.transform.childCount == 0)
        {
            Scoremanager.GetComponent<Scoremanager>().Score += 650;
           Debug.Log(Scoremanager.GetComponent<Scoremanager>().Score);
           Isdone = true;
           
           if (Scoremanager.GetComponent<Scoremanager>().Enemy.transform.childCount >= 1)
           {
               Isdone = false;
           }
        }


        }
     
    }
}

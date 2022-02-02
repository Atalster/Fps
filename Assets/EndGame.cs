using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Scoremanager;
    private bool Isdone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Isdone == false) 
        {
        if (Scoremanager.GetComponent<Scoremanager>().Enemy == null)
        {
           Scoremanager.GetComponent<Scoremanager>().Score += 650;
           Debug.Log(Scoremanager.GetComponent<Scoremanager>().Score);
                       Isdone = true;
        }

        }
    }
}

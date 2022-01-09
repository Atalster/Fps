using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGuns : MonoBehaviour
{

    public GameObject Huntingrifle;
    public GameObject Sniper;
    public Animator Sniperanimator;
    public Animator Huntingrifleanimator;

    // Start is called before the first frame update
    void Start()
    {
        Sniper.SetActive(true);
        Huntingrifle.SetActive(false);
       Sniperanimator.GetComponent<Animator>().enabled = true;
       Huntingrifleanimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Huntingrifle.SetActive(true);
            Sniper.SetActive(false);
            Sniperanimator.GetComponent<Animator>().enabled = false;
            Huntingrifleanimator.enabled = true;
        }
 if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Huntingrifle.SetActive(false);
            Sniper.SetActive(true);
            Sniperanimator.GetComponent<Animator>().enabled = true;
            Huntingrifleanimator.enabled = false;
        }
    }



    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGuns : MonoBehaviour
{

    public GameObject Huntingrifle;
    public GameObject Sniper;
    public Animator Sniperanimator;
    public Animator Huntingrifleanimator;
    public GameObject AmmoCounter50Cal;
public Animator Pistolanimator;
public GameObject Pistol;
    // Start is called before the first frame update
    void Start()
    {
        Sniper.SetActive(true);
        Huntingrifle.SetActive(false);
       Sniperanimator.GetComponent<Animator>().enabled = true;
       Huntingrifleanimator.enabled = false;
       Pistol.SetActive(false);
       Pistolanimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           
            Sniper.SetActive(false);
            Sniperanimator.GetComponent<Animator>().enabled = false;
            
            AmmoCounter50Cal.SetActive(false);
            Pistol.SetActive(false);
       Pistolanimator.enabled = false;
        Huntingrifle.SetActive(true);
             Huntingrifleanimator.enabled = true;
        }
 if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Huntingrifle.SetActive(false);
            Sniper.SetActive(true);
            Sniperanimator.GetComponent<Animator>().enabled = true;
            Huntingrifleanimator.enabled = false;
          Pistol.SetActive(false);
             Pistolanimator.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sniper.SetActive(false);
            Sniperanimator.enabled = false;
            Huntingrifle.SetActive(false);
            Huntingrifleanimator.enabled = false;
            Pistolanimator.enabled = true;
            Pistol.SetActive(true);
             AmmoCounter50Cal.SetActive(false);
        }
    }



    
}

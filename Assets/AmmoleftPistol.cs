using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoleftPistol : MonoBehaviour
{
    public Text AmmoLeftPistol;
    public GunPistol Gunpistol;
 

    // Start is called before the first frame update
    void Start()
    {
        AmmoLeftPistol = GetComponent<Text>();
        AmmoLeftPistol.text = Gunpistol.currentAmmo + "/" + Gunpistol.maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        AmmoLeftPistol.text = Gunpistol.currentAmmo + "/" + Gunpistol.maxAmmo;
    }
}

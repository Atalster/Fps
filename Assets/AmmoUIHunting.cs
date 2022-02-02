using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIHunting : MonoBehaviour
{

    public Text AmmoLeftHunting;
    public Gunhuntingrifle gunhuntingrifle;
    // Start is called before the first frame update
    void Start()
    {
       AmmoLeftHunting = GetComponent<Text>();
       AmmoLeftHunting.text =  gunhuntingrifle.currentAmmo + "/" + gunhuntingrifle.maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoLeftHunting.text =  gunhuntingrifle.currentAmmo + "/" + gunhuntingrifle.maxAmmo;
    }
}

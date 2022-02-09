using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ENDgameUI : MonoBehaviour
{

        public Text Score;
        public ScoreSystem scoreSystem;
        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "YOUR SCORE: " + scoreSystem.score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinalScore : MonoBehaviour
{
	private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "" + EndScore.finalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

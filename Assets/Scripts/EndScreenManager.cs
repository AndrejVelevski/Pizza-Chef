using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winScreenCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //Check if the player has won the level or not
        if(true){
            winScreenCanvas.SetActive(true);
        }else{
            gameOverCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

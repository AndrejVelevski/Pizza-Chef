using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScore : MonoBehaviour
{
	public static int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = 0;
		DontDestroyOnLoad(gameObject);
    }

}

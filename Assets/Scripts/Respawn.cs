using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject[] respawnObjects;
    Vector3[] objectPositions;

    // Start is called before the first frame update
    void Start()
    {
        objectPositions = new Vector3[respawnObjects.Length];
        for (int i = 0; i < respawnObjects.Length; i++)
        {
            objectPositions[i] = respawnObjects[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawn(bool []removedObjects) {

        for (int i = 0; i < removedObjects.Length; i++)
        {
            if (removedObjects[i])
            {
                //Debug.Log("I: " + i);
                //Debug.Log("respawnsize: " + respawnIng.Length + " ss " + takenIng.Length);
                respawnObjects[i].transform.position = objectPositions[i];
                respawnObjects[i].SetActive(true);
            }
        }
    }
}

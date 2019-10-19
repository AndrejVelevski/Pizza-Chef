using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moov : MonoBehaviour
{
    private bool canMove = false;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (canMove)
        {
            rb.velocity = new Vector3(0, 1, 0);
        }
    }
    public void moovv()
    {
        canMove = true;

    }
}

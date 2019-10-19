﻿using UnityEngine;
using UnityEngine.EventSystems;

public class HoldItem : MonoBehaviour
{
    GameObject item;

    public void Update()
    {
        if (item != null)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Vector3.Distance(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward)))
            {
                rb.MovePosition(hit.point);
            }
            else
            {
                rb.MovePosition(Camera.main.transform.position + Camera.main.transform.forward);
            }

            if (Input.GetButtonDown("Cancel"))
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 5))
                {
                    rb.MovePosition(hit.point+Vector3.up*0.05f);
                }
                
                item = null;
            }
        }
    }

    public void Hold(GameObject item)
    {
        if (this.item == null)
        {
            this.item = item;
        }
    }
}

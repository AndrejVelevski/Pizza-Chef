using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 forwards = transform.forward * vertical;
        Vector3 sideways = transform.right * horizontal;
        Vector3 direction = (forwards + sideways).normalized;

        Vector3 velocity = Camera.main.transform.TransformDirection(direction * moveSpeed * Time.deltaTime);
        velocity.y = 0;

        controller.Move(velocity);

        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
    }
}

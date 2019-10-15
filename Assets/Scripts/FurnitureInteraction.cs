using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureInteraction : MonoBehaviour
{
    Vector3 minPosition;
    Vector3 maxPosition;
    Vector3 minRotation;
    Vector3 maxRotation;
    Vector3 minScale;
    Vector3 maxScale;
    bool toggle = false;
    bool opened = false;
    float steps = 0;
    float maxSteps = 1;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    AudioSource source;
    public AudioClip openSound;
    public AudioClip closeSound;

    void Start()
    {
        minPosition = transform.position;
        maxPosition = transform.position + position;
        minRotation = transform.rotation.eulerAngles;
        maxRotation = transform.rotation.eulerAngles + rotation;
        minScale = transform.localScale;
        maxScale = transform.localScale + scale;

        source = GetComponent<AudioSource>();
        if (source != null)
        {
            source.clip = closeSound;
        }
    }

    void Update()
    {
        if (toggle)
        {
            if (!opened)
            {
                steps+=Time.deltaTime;
                transform.position = Vector3.Lerp(minPosition,maxPosition,steps/maxSteps);
                transform.eulerAngles = Vector3.Lerp(minRotation,maxRotation,steps/maxSteps);
                transform.localScale = Vector3.Lerp(minScale,maxScale,steps/maxSteps);
                if (steps > maxSteps)
                {
                    steps = maxSteps;
                    transform.position = maxPosition;
                    transform.eulerAngles = maxRotation;
                    transform.localScale = maxScale;
                    Toggle();
                }
            }
            else
            {
                steps-=Time.deltaTime;
                transform.position = Vector3.Lerp(minPosition,maxPosition,steps/maxSteps);
                transform.eulerAngles = Vector3.Lerp(minRotation,maxRotation,steps/maxSteps);
                transform.localScale = Vector3.Lerp(minScale,maxScale,steps/maxSteps);
                if (steps < 0)
                {
                    steps = 0;
                    transform.position = minPosition;
                    transform.eulerAngles = minRotation;
                    transform.localScale = minScale;
                    Toggle();
                }
            }
        }
    }

    void Toggle()
    {
        toggle = false;
        opened = !opened;
    }

    public void Toggle(float maxSteps)
    {
        if (!toggle)
        {
            this.maxSteps = maxSteps;
            toggle = !toggle;
            if (source != null)
            {
                if (source.clip == openSound)
                {
                    source.clip = closeSound;
                }
                else
                {
                    source.clip = openSound;
                }
                source.Play();
            }
        }
    }
}

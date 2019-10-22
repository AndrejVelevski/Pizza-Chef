using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LiftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public float maxHoverTime = 1.5f;
    private float hoverTime;
    private bool isHovered;

    private bool activated;
    private bool movingUp;
    public GameObject movingPlatform;
    public Material material;
    private Renderer rend;

    public float platformMovingSpeed = 10f;

    private Transform platformPosition;
    private Vector3 platformStartingPosition;

    public Vector3 platformFinalPosition;

    Rigidbody rb;

    void Start()
    {
        rend = GetComponent<Renderer>();
        isHovered = false;
        hoverTime = maxHoverTime;
        activated = false;
        movingUp = true;

        platformPosition = movingPlatform.GetComponent<Transform>();
        platformStartingPosition = movingPlatform.GetComponent<Transform>().position;

        rb = movingPlatform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        timerFunction();

        if (activated)
        {
            movePlatform();
        }
    }

    private void timerFunction()
    {
        if (isHovered)
        {
            hoverTime -= Time.deltaTime;
        }

        if (hoverTime <= 0.0f)
        {
            onClick();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverExit();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick();
    }

    public void OnHoverEnter()
    {
        isHovered = true;
    }

    public void OnHoverExit()
    {
        isHovered = false;
        hoverTime = maxHoverTime;

    }

    private void onClick()
    {
        rend.material.color = Color.red;
        
        activated = true;
    }

    private void movePlatform()
    {
        if(movingUp){
            rb.velocity = new Vector3(0, platformMovingSpeed, 0);
        }
        else{
            rb.velocity = new Vector3(0, -platformMovingSpeed, 0);
        }    
        
        if(platformPosition.position.y >= platformFinalPosition.y){
            movingUp = false;
        }
        else if(platformPosition.position.y <= platformStartingPosition.y){
            movingUp = true;
            activated = false;
            rend.material.color = Color.white;
        }
    }

    



}


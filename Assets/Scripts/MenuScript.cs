using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class MenuScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private Text text;
    public float maxHoverTime = 1.5f;
    private float hoverTime;
    private bool isHovered;
    public GameObject instructionCanvas;
    private GameObject menuCanvas;

    void Start()
    {
        text = GetComponent<Text>();
        isHovered = false;
        hoverTime = maxHoverTime;
        menuCanvas = GameObject.FindWithTag("MenuCanvas");
    }

    void Update()
    {
        timerFunction();
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
        text.color = new Color32(0xE9, 0xF5, 0x9C, 0xFF);
        //Debug.Log("Hover On!");
        isHovered = true;
    }

    public void OnHoverExit()
    {
        text.color = new Color32(0x7E, 0xC2, 0xF1, 0xFF);
        isHovered = false;
        hoverTime = maxHoverTime;

    }

    private void onClick()
    {
        text.color = Color.red;

        switch (gameObject.name)
        {
            case "StartText":
                //Debug.Log("Start");
                SceneManager.LoadScene(1);
                break;

            case "InstructionsText":
                //Debug.Log("Instructuion");
                menuCanvas.SetActive(false);
                instructionCanvas.SetActive(true);

                break;
            case "ExitText":
                //Debug.Log("Exit");
                Application.Quit();
                break;
        }
    }

}


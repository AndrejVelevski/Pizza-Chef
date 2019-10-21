using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    bool cheeseOn,tomatoOn,mushroomsOn,meatOn;
    int ingredients = 0;
    public Material madePizzaMaterial;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cheese")
        {
            Debug.Log("Cheese on PIZZA!");
            cheeseOn = true;
            ingredients++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Tomato")
        {
            Debug.Log("Tomato on PIZZA!");
            tomatoOn = true;
            ingredients++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Mushroom")
        {
            Debug.Log("Mushroom on PIZZA!");
            mushroomsOn = true;
            ingredients++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Meat")
        {
            Debug.Log("Meat on PIZZA!");
            meatOn = true;
            ingredients++;
            Destroy(collision.gameObject);
        }

        //tmp code
        if(ingredients >= 4 && cheeseOn && tomatoOn && mushroomsOn && meatOn)
        {
            GetComponent<MeshRenderer>().material = madePizzaMaterial;
        }
        
    }
}

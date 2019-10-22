using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    int ingredients = 0;
    public Material madePizzaMaterial;
    float bakeTime;
    bool isDone = false;
    bool isBaking = false;

    System.Random random = new System.Random();

    void Start()
    {
        bakeTime = random.Next(10,21);
    }

    private void Update()
    {
        if (!isDone && isBaking)
        {
            bakeTime -= Time.deltaTime;
            if (bakeTime < 0)
            {
                isDone = true;
                GetComponent<MeshRenderer>().material = madePizzaMaterial;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDone)
        {
            switch (collision.gameObject.tag)
            {
                case "Apple": ingredients += (int)Food.Apple; Destroy(collision.gameObject); break;
                case "Avocado": ingredients += (int)Food.Avocado; Destroy(collision.gameObject); break;
                case "Banana": ingredients += (int)Food.Banana; Destroy(collision.gameObject); break;
                case "Broccoli": ingredients += (int)Food.Broccoli; Destroy(collision.gameObject); break;
                case "Carrot": ingredients += (int)Food.Carrot; Destroy(collision.gameObject); break;
                case "Cheese": ingredients += (int)Food.Cheese; Destroy(collision.gameObject); break;
                case "Cucumber": ingredients += (int)Food.Cucumber; Destroy(collision.gameObject); break;
                case "Leek": ingredients += (int)Food.Leek; Destroy(collision.gameObject); break;
                case "Lemon": ingredients += (int)Food.Lemon; Destroy(collision.gameObject); break;
                case "Meat": ingredients += (int)Food.Meat; Destroy(collision.gameObject); break;
                case "Mozzarella": ingredients += (int)Food.Mozzarella; Destroy(collision.gameObject); break;
                case "Mushroom": ingredients += (int)Food.Mushroom; Destroy(collision.gameObject); break;
                case "Onion": ingredients += (int)Food.Onion; Destroy(collision.gameObject); break;
                case "Pear": ingredients += (int)Food.Pear; Destroy(collision.gameObject); break;
                case "Pepperoni": ingredients += (int)Food.Pepperoni; Destroy(collision.gameObject); break;
                case "Tomato": ingredients += (int)Food.Tomato; Destroy(collision.gameObject); break;
            }
        }

        if (collision.gameObject.tag == "FurnaceBaker")
        {
            isBaking = true;
        }
        else if (collision.gameObject.tag == "PizzaChecker")
        {
            PizzaRequester pizzaRequester = collision.gameObject.GetComponent<PizzaRequester>();
            int requestedIngredients = pizzaRequester.getPizzaIngredients();
            int total = 0;

            string reqIng = Convert.ToString(requestedIngredients, 2);
            for (int i = 0; i < reqIng.Length; ++i)
            {
                if (reqIng[i] == '1')
                    ++total;
            }

            string result = Convert.ToString(ingredients ^ requestedIngredients, 2);

            int incorrect = 0;

            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i] == '1')
                    ++incorrect;
            }

            pizzaRequester.addScore((total - 2*incorrect) * 10 + (isDone?50:-50));

            pizzaRequester.generateNewOrder();

            Destroy(gameObject);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "FurnaceBaker")
        {
            isBaking = false;
        }
    }
}

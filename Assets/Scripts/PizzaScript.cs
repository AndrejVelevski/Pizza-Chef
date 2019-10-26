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

    bool[] takenIng;

    void Start()
    {
        bakeTime = random.Next(10,21);
        takenIng = new bool[16];    
    }

    private void Update()
    {
        //if (respawnIng.Length <= 0) initRespawn();

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
                case "Apple": ingredients += (int)Food.Apple; collision.gameObject.SetActive(false); takenIng[0] = true; break;
                case "Avocado": ingredients += (int)Food.Avocado; collision.gameObject.SetActive(false); takenIng[1] = true; break;
                case "Banana": ingredients += (int)Food.Banana; collision.gameObject.SetActive(false); takenIng[2] = true; break;
                case "Broccoli": ingredients += (int)Food.Broccoli; collision.gameObject.SetActive(false); takenIng[3] = true; break;
                case "Carrot": ingredients += (int)Food.Carrot; collision.gameObject.SetActive(false); takenIng[4] = true; break;
                case "Cheese": ingredients += (int)Food.Cheese; collision.gameObject.SetActive(false); takenIng[5] = true; break;
                case "Cucumber": ingredients += (int)Food.Cucumber; collision.gameObject.SetActive(false); takenIng[6] = true; break;
                case "Leek": ingredients += (int)Food.Leek; collision.gameObject.SetActive(false); takenIng[7] = true; break;
                case "Lemon": ingredients += (int)Food.Lemon; collision.gameObject.SetActive(false); takenIng[8] = true; break;
                case "Meat": ingredients += (int)Food.Meat; collision.gameObject.SetActive(false); takenIng[9] = true; break;
                case "Mozzarella": ingredients += (int)Food.Mozzarella; collision.gameObject.SetActive(false); takenIng[10] = true; break;
                case "Mushroom": ingredients += (int)Food.Mushroom; collision.gameObject.SetActive(false); takenIng[11] = true; break;
                case "Onion": ingredients += (int)Food.Onion; collision.gameObject.SetActive(false); takenIng[12] = true; break;
                case "Pear": ingredients += (int)Food.Pear; collision.gameObject.SetActive(false); takenIng[13] = true; break;
                case "Pepperoni": ingredients += (int)Food.Pepperoni; collision.gameObject.SetActive(false); takenIng[14] = true; break;
                case "Tomato": ingredients += (int)Food.Tomato; collision.gameObject.SetActive(false); takenIng[15] = true; break;
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

            gameObject.GetComponent<Respawn>().respawn(takenIng);

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

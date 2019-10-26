using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum Food
{
    Apple = 1 << 0,
    Avocado = 1 << 1,
    Banana = 1 << 2,
    Broccoli = 1 << 3,
    Carrot = 1 << 4,
    Cheese = 1 << 5,
    Cucumber = 1 << 6,
    Leek = 1 << 7,
    Lemon = 1 << 8,
    Meat = 1 << 9,
    Mozzarella = 1 << 10,
    Mushroom = 1 << 11,
    Onion = 1 << 12,
    Pear = 1 << 13,
    Pepperoni = 1 << 14,
    Tomato = 1 << 15
}

public class PizzaRequester : MonoBehaviour
{
    bool waitingForPizza;
    int currentIngredients;
    System.Random random = new System.Random();

    Array arr;
    int max;

    StringBuilder sb;

    public TextMeshPro ingredientsText;
    public TextMeshPro scoreText;
    public TextMeshPro timeText;

    int score = 0;

    public float time = 30;

    void Start()
    {
        waitingForPizza = false;
        arr = Enum.GetValues(typeof(Food));
        max = (int)arr.GetValue(arr.Length - 1);
        sb = new StringBuilder();
        scoreText.text = 0.ToString();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = ((int)time).ToString();
        }

        if (time <= 0)
            SceneManager.LoadScene("EndScreen");

        if (!waitingForPizza)
        {
            waitingForPizza = true;

            currentIngredients = 0;
            while (currentIngredients == 0)
                currentIngredients = random.Next(2 * max);

            sb.Clear();

            for (int i=0; i < arr.Length; ++i)
            {
                int j = (int)arr.GetValue(i);

                int mask = j | currentIngredients;
                if ((mask & currentIngredients) == mask)
                {
                    sb.Append((Food)j);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 1);

            ingredientsText.text = sb.ToString();
        }
    }

    public int getPizzaIngredients()
    {
        return currentIngredients;
    }

    public int getTotalIngredients()
    {
        return arr.Length;
    }

    public void addScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();

    }

    public void generateNewOrder()
    {
        waitingForPizza = false;
    }
}

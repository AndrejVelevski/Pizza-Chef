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
	
	private AudioSource audioSource;
    public AudioClip addToPizzaSound;
    public AudioClip sellPizzaSound;
    public AudioClip bakingDoneSound;

    System.Random random = new System.Random();

    bool[] takenIng;

    void Start()
    {
        bakeTime = random.Next(10,21);
        takenIng = new bool[16];   
		audioSource = GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(bakingDoneSound);
                GetComponent<MeshRenderer>().material = madePizzaMaterial;
            }
        }
        
    }
	
	void ingredientOnCollision(Collision collision){
		collision.gameObject.SetActive(false);
		audioSource.PlayOneShot(addToPizzaSound);
        GameObject player = GameObject.Find("Player");
        player.GetComponent<HoldItem>().RemoveItem();
}
	

    void OnCollisionEnter(Collision collision)
    {
        if (!isDone)
        {
            switch (collision.gameObject.tag)
            {
                case "Apple": ingredients += (int)Food.Apple; ingredientOnCollision(collision); takenIng[0] = true; break;
                case "Avocado": ingredients += (int)Food.Avocado; ingredientOnCollision(collision); takenIng[1] = true; break;
                case "Banana": ingredients += (int)Food.Banana; ingredientOnCollision(collision); takenIng[2] = true; break;
                case "Broccoli": ingredients += (int)Food.Broccoli; ingredientOnCollision(collision); takenIng[3] = true; break;
                case "Carrot": ingredients += (int)Food.Carrot; ingredientOnCollision(collision); takenIng[4] = true; break;
                case "Cheese": ingredients += (int)Food.Cheese; ingredientOnCollision(collision); takenIng[5] = true; break;
                case "Cucumber": ingredients += (int)Food.Cucumber; ingredientOnCollision(collision); takenIng[6] = true; break;
                case "Leek": ingredients += (int)Food.Leek; ingredientOnCollision(collision); takenIng[7] = true; break;
                case "Lemon": ingredients += (int)Food.Lemon; ingredientOnCollision(collision); takenIng[8] = true; break;
                case "Meat": ingredients += (int)Food.Meat; ingredientOnCollision(collision); takenIng[9] = true; break;
                case "Mozzarella": ingredients += (int)Food.Mozzarella; ingredientOnCollision(collision); takenIng[10] = true; break;
                case "Mushroom": ingredients += (int)Food.Mushroom; ingredientOnCollision(collision); takenIng[11] = true; break;
                case "Onion": ingredients += (int)Food.Onion; ingredientOnCollision(collision); takenIng[12] = true; break;
                case "Pear": ingredients += (int)Food.Pear; ingredientOnCollision(collision); takenIng[13] = true; break;
                case "Pepperoni": ingredients += (int)Food.Pepperoni; ingredientOnCollision(collision); takenIng[14] = true; break;
                case "Tomato": ingredients += (int)Food.Tomato; ingredientOnCollision(collision); takenIng[15] = true; break;
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
            audioSource.PlayOneShot(sellPizzaSound);

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

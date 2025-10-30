using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IngredientManager : MonoBehaviour
{

    public List<string> Recipe;
    public List<GameObject> SushiIngredients = new List<GameObject>();

    public int requiredCooked;

    int index;

    public GameObject SushiButton;

    public int cookingValue;

    public bool IsReadyToSend = false;

    public Slider Cooking;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       index = 0;
       cookingValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cookingValue == requiredCooked)
        {
            Debug.Log("doneCooking!");
            IsReadyToSend = true;
        }


    }

    public void CreateRecipe(string Name)
    {
        if (Name == "SushiPlatter")
        {
            requiredCooked = 13;
            SushiButton.SetActive(false);
            spawnSushiIngredients();

            
        }
    }

    public void spawnSushiIngredients()
    {
        Instantiate(SushiIngredients[index]);

    }

    public void IndexIncrease(int num)
    {

        index = num;

        Debug.Log(index);
    }
    public void AmtIncrease(int num)
    {
        cookingValue += num;

    }
}

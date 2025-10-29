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

    public int requiredCuts;

    int index;

    public GameObject SushiButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRecipe(string Name)
    {
        if (Name == "SushiPlatter")
        {
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
}

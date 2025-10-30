using Unity.VisualScripting;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public GameObject IngredientManagerObj;
    public bool ReadyToSend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IngredientManagerObj = GameObject.FindGameObjectWithTag("IngManager");
    }

    // Update is called once per frame
    void Update()
    {

        ReadyToSend = IngredientManagerObj.GetComponent<IngredientManager>().IsReadyToSend;

        if (ReadyToSend == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

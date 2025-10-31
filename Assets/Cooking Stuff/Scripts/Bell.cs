using Unity.VisualScripting;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public GameObject IngredientManagerObj;
    public bool ReadyToSend;
    public GameObject WinScreen;

    public GameObject Timer;
    public int rate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IngredientManagerObj = GameObject.FindGameObjectWithTag("IngManager");
        Timer = GameObject.FindGameObjectWithTag("Timer");
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

        if (ReadyToSend == true && Input.GetKeyDown(KeyCode.Space))
        {
            WinScreen.SetActive(true);
            Timer.GetComponent<timer>().rate = 0;
        }
    }
}

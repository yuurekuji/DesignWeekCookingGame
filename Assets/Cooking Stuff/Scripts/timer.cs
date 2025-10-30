using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public float time;
    public bool timerIsOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsOn == true){
            time += Time.deltaTime;
        }
        
        if (time > 60)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void startTimer()
    {
        timerIsOn = true;
        
    }
}

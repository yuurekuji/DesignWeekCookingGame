using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float maxTime;
    public float time;
    public bool timerIsOn = false;

    public Color filling;
    public Slider Timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsOn == true){
            time += Time.deltaTime;
            Timer.value -= Time.deltaTime;

        }
        
        if (time > maxTime)
        {
            SceneManager.LoadScene(0);
        }

        if(Timer.value <= 31)
        {
            filling = Color.yellow;
        }

        else if (Timer.value <= 13)
        {
            filling = Color.red;
        }
    }

    public void startTimer()
    {
        timerIsOn = true;
        
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float maxTime;
    public float time;
    public bool timerIsOn = false;

    public GameObject Filling;
    Color imageFill;
    public Slider Timer;
    public bool green = true;
    public bool yellow = false;
    public bool red = false;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int rate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageFill = Filling.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsOn == true){
            time += Time.deltaTime * rate;
            Timer.value -= Time.deltaTime * rate;

        }
        
        if (time >= maxTime)
        {
            star3.SetActive(false);
            SceneManager.LoadScene(3);
        }
         
        if(Timer.value <= 31 && Timer.value >=30)
        {
            yellow = true;
            green = false;
        }

        else if (Timer.value <= 13 && Timer.value >=12)
        {
            red = true;
            yellow = false;
        }

        if(yellow == true)
        {
            Filling.GetComponent<Image>().color = Color.yellow;
            star1.SetActive(false);
        }
        else if(red == true)
        {
            Filling.GetComponent<Image>().color = Color.red;
            star2.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void startTimer()
    {
        timerIsOn = true;
        rate = 1;
    }

    
}

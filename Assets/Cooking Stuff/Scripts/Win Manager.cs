using UnityEngine;
using TMPro;
public class WinManager : MonoBehaviour
{
    public TMP_Text text;
    public GameObject Timer;
    public float time;

    public GameObject Slider;
    public float sliderval;

    public GameObject Star1;
    public GameObject Star2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = GameObject.FindGameObjectWithTag("Timer");

    }

    // Update is called once per frame
    void Update()
    {
        time = Timer.GetComponent<timer>().time;

        text.text = time.ToString("F2");

        sliderval = Timer.GetComponent<timer>().Timer.value;

        if (sliderval <= 31 && sliderval >= 30)
        {
            Star1.SetActive(false);
        }

        else if (sliderval <= 13 && sliderval >= 12)
        {
            Star1.SetActive(false) ;
            Star2.SetActive(false);
        }

    }
}

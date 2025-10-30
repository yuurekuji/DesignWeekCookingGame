using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBar : MonoBehaviour
{
    public Slider slider;

    [Header("Slider Properties")]
    public float minValue;
    public float maxValue;
    public float initValue;

    [Header("Growing Speed")]
    public float DecreaseSpeed;
    public float IncreaseRate;
    
    [Header("Input button")]
    public string InteractionKey;
    //public GameObject warningPanel;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxValue;
        slider.minValue = minValue;
        slider.value = initValue;
    }

    // Update is called once per frame
    void Update()
    {
        //if (slider.value >= 1)
        //{
        //    if (Input.GetButtonDown(InteractionKey))
        //    {
        //        warningPanel.SetActive(true);
        //    }
        //}
        //else
        //{
        //    warningPanel.SetActive(false);
        //}

            SliderValue();
    }

    void SliderValue()
    {
        slider.value -= DecreaseSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown(InteractionKey))
        {
            slider.value += IncreaseRate;
        }
    }

    

}

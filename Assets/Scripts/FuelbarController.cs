using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelbarController : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text textValue;
    [SerializeField] Slider slider;
   

    
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = slider.maxValue;
        textValue.text = slider.value.ToString();
    }

    public void ChangeFuelValue(float value)
    {
        slider.value = value;
        textValue.text = slider.value.ToString();
    }
}

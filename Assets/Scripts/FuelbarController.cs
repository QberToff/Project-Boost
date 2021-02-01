using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelbarController : MonoBehaviour
{
    
    [SerializeField] Slider slider;
   

    
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = slider.maxValue;
        
    }

    public void ChangeFuelValue(float value)
    {
        slider.value = value;
        
    }
}

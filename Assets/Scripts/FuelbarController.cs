using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelbarController : MonoBehaviour
{
    [SerializeField] float startFuel;
    [SerializeField] Rocket rocket;
    [SerializeField] Image fuelbar;
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    //float testValue = 0.5f;

    private void Start()
    {
        startFuel = rocket.GetStartFuel();
        slider.maxValue = startFuel;
    }
    public void Update()
    {

        slider.value = rocket.GetFuel();
        fuelbar.fillAmount = rocket.GetFuel() / startFuel;
        text.text = rocket.GetFuel().ToString();


    }

}

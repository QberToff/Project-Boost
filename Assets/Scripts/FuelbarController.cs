using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelbarController : MonoBehaviour
{
    [SerializeField] float startFuel;
    [SerializeField] float fuel;
    [SerializeField] Image fuelbar;
    //float testValue = 0.5f;

    
    public void FuelCountAndDisplay(float thrusting)
    {
        fuel -= thrusting;
        fuelbar.fillAmount =  fuel/startFuel;
    }


    public float GetFuel()
    {
        return fuel;
    }

}

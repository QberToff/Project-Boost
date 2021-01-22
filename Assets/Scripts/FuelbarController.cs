using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelbarController : MonoBehaviour
{
    [SerializeField] float startFuel;
    [SerializeField] Rocket rocket;
    [SerializeField] Image fuelbar;
    //float testValue = 0.5f;

    private void Start()
    {
        startFuel = rocket.GetStartFuel();
    }
    public void Update()
    {
        
        fuelbar.fillAmount = rocket.GetFuel() / startFuel;
    }


   

}

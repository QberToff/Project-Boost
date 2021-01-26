using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDelear : MonoBehaviour
{
    [SerializeField] float addFuel = 50f;






    public float AddingFuel()
    {
        return addFuel;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}

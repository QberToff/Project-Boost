using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image[] rockets;

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < rockets.Length; i++)
        {
            if (i < GetComponent<Rocket>().GetHealth())
            {
                rockets[i].enabled = true;
            }
            else
            {
                rockets[i].enabled = false;
            }
        }
    }
}

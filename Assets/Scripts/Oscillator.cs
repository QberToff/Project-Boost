using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementPosition;
    [SerializeField] float period = 2f;

    [Range(0,1)] [SerializeField] float movementFactor;

    Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            Debug.LogError("Period can't be null");
        }
       
    float cycles = Time.time / period; //grows from 0 

    const float tau = Mathf.PI * 2;

    float rawSinWave = Mathf.Sin(tau * cycles); //tau * cycles means exact posotion in unit circle each frame


    movementFactor = rawSinWave / 2f + 0.5f; // by this we make our rawSinWave in range of 0 to 1
    //Debug.Log(movementFactor);

    Vector3 offset = movementFactor * movementPosition;
    transform.position = startingPosition + offset;
        

        
    }
}

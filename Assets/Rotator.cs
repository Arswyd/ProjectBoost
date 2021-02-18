using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // Only one component can be added

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 2f);
    [SerializeField] float period = 2f;

    float movementFactor;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // protect against period is zero
  
        float cycles = Time.time / period; // Game time / period -> grows continually from 0

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f;

        Vector3 offset = movementVector * movementFactor * Time.deltaTime;

        transform.Rotate(offset);

    }
}

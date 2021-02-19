using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // Only one component can be added

public class Spinner : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 2f);
    [SerializeField] float movementFactor = 10f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movementFactor * Time.deltaTime;

        transform.Rotate(offset);
    }
}

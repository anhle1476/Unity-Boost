using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    /// <summary>
    /// Radiant of the full circle (2 PI)
    /// </summary>
    private const float TAU = Mathf.PI * 2;

    /// <summary>
    /// The base movement vector
    /// </summary>
    [SerializeField] Vector3 movementVector = Vector3.right;
    /// <summary>
    /// The movement period (in seconds) to complete a full cycle
    /// </summary>
    [SerializeField] float period = 3;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (period <= Mathf.Epsilon || movementVector == Vector3.zero)
        {
            return;
        }

        float cycles = Time.time / period;

        // the sin values are ranged from -1 to 1
        float rawSinValue = Mathf.Sin(cycles * TAU);
        // ranged from 0 to 1, represent the position in the travelling cycle
        float movementFactor = (rawSinValue + 1) / 2;

        transform.position = startingPosition + (movementFactor * movementVector);
    }
}

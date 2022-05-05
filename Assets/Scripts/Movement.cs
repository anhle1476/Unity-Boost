using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float boostSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        ProcessBoost();
        ProcessRotation();
    }

    private void ProcessBoost()
    {
        // apply the boost force if the keys are pressed
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Time.deltaTime * boostSpeed * Vector3.up);
        }
    }

    private void ProcessRotation()
    {
        // Press left arror -> rotate left -> inverse the rotate Z
        float rotateForce = -Input.GetAxisRaw("Horizontal") * rotateSpeed;
        transform.Rotate(Time.deltaTime * rotateForce * Vector3.forward);
    }
}

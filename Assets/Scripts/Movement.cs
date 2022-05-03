using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float xSpeed = 1f;
    [SerializeField] float boostDecreaseSpeed = 0.1f;
    [SerializeField] float maxSpeed = 10;

    private Vector3 boostForce = Vector3.zero;
    private Vector3 maxBoostSpeed;

    // Start is called before the first frame update
    void Start()
    {
        maxBoostSpeed = Vector3.up * maxSpeed;
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
        if (Input.GetKey(KeyCode.Space))
        {
            boostForce += Time.deltaTime * ySpeed * Vector3.up;
            // limit by max speed
            boostForce = Vector3.Min(boostForce, maxBoostSpeed);
            // counter the gravity as we are boost
            boostForce += Physics.gravity.x * Time.deltaTime * Vector3.up;
        }

        boostForce = Vector3.Lerp(boostForce, Vector3.zero, boostDecreaseSpeed * Time.deltaTime * 60);
        if (boostForce != Vector3.zero)
        {
            transform.Translate(Time.deltaTime * 10 * (transform.up + boostForce));
        }
    }

    private void ProcessRotation()
    {
        // Press left arror -> rotate left -> inverse the rotate Z
        float rotateForce = Input.GetAxisRaw("Horizontal") * xSpeed;
        transform.Rotate(Time.deltaTime * 60 * new Vector3(0, 0, -rotateForce));
    }
}

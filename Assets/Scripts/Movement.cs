using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float boostSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            // play audio on when its boosted
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // stop the audio when it's stop
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void ProcessRotation()
    {
        // Press left arror -> rotate left -> inverse the rotate Z
        float rotateForce = -Input.GetAxisRaw("Horizontal") * rotateSpeed;

        // freezing the rb physic rotation so we can manually rotate ourself
        if (rotateForce != 0)
        {
            rb.freezeRotation = true;
            transform.Rotate(Time.deltaTime * rotateForce * Vector3.forward);
            rb.freezeRotation = false;
        }
    }
}

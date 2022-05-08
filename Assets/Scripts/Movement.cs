using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Movement : MonoBehaviour
{
    [SerializeField] float boostSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip engineSound = null;
    [SerializeField] ParticleSystem mainEngineParticle = null;
    [SerializeField] ParticleSystem leftEngineParticle = null;
    [SerializeField] ParticleSystem rightEngineParticle = null;

    private Rigidbody rb;
    private AudioSource audioSource;
    private RigidbodyConstraints initialConstraints;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialConstraints = rb.constraints;
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
                audioSource.PlayOneShot(engineSound);
            }

            mainEngineParticle.PlayIfNotPlaying();
        }
        else
        {
            // stop the audio when it's stop
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            mainEngineParticle.StopIfPlaying();
        }
    }

    private void ProcessRotation()
    {
        // inverse the input rotation as it's the opposite of the Z rotate degree
        float rotateForce = -Input.GetAxisRaw("Horizontal") * rotateSpeed;

        if (rotateForce != 0)
        {
            // freezing the rb physic rotation so we can manually rotate ourself
            rb.freezeRotation = true;
            transform.Rotate(Time.deltaTime * rotateForce * Vector3.forward);
            // un-freeze and restore the physic body constraints
            rb.freezeRotation = false;
            rb.constraints = initialConstraints;
        }

        ProcessSideEngineParticles(rotateForce);
    }


    private void ProcessSideEngineParticles(float rotateForce)
    {
        if (rotateForce != 0)
        {
            if (rotateForce < 0)
            {
                leftEngineParticle.PlayIfNotPlaying();
            }
            else
            {
                rightEngineParticle.PlayIfNotPlaying();
            }
        }
        else
        {
            leftEngineParticle.StopIfPlaying();
            rightEngineParticle.StopIfPlaying();
        }
    }
}

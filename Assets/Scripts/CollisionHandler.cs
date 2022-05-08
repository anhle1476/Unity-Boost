using Assets.Scripts.Constants;
using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(AudioSource))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] AudioClip crashSound = null;
    [SerializeField] AudioClip successSound = null;
    [SerializeField] ParticleSystem crashParticle = null;
    [SerializeField] ParticleSystem successParticle = null;

    private Movement movement;
    private AudioSource audioSource;

    private Status status;

    private void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
        status = Status.Playing;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // enable=false only prevent Start, Awate, Update, FixedUpdate and OnGUI from executing
        if (status != Status.Playing || !enabled)
        {
            return;
        }

        switch (collision.collider.tag)
        {
            case nameof(Tags.Finish):
                StartSuccessSequence();
                break;
            case nameof(Tags.Friendly):
                Debug.Log("Start");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        status = Status.Success;
        movement.enabled = false;

        successParticle.PlayIfNotPlaying();
        audioSource.PlayOneShot(successSound);

        Invoke(nameof(LoadNextLevel), sceneLoadDelay);
    }

    private void StartCrashSequence()
    {
        status = Status.Dead;
        movement.enabled = false;

        crashParticle.PlayIfNotPlaying();
        audioSource.PlayOneShot(crashSound);

        Invoke(nameof(ReloadCurrentScence), sceneLoadDelay);
    }

    private void LoadNextLevel()
    {
        SceneHelper.LoadNextScene();
    }

    private void ReloadCurrentScence()
    {
        SceneHelper.ReloadCurrentScene();
    }
}

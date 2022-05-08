using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKeys : MonoBehaviour
{
    private CollisionHandler collisionHandler;

    // Start is called before the first frame update
    void Start()
    {
        collisionHandler = GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // toggle collision handler
        if (Input.GetKey(KeyCode.L))
        {
            collisionHandler.enabled = !collisionHandler.enabled;
        }

        // to next scene
        if (Input.GetKey(KeyCode.N))
        {
            SceneHelper.LoadNextScene();
        }

        // restart current scene
        if (Input.GetKey(KeyCode.C))
        {
            SceneHelper.ReloadCurrentScene();
        }
    }
}

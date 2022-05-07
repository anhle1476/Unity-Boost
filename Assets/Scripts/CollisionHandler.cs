using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case nameof(Tags.Finish):
                Debug.Log("Win");
                break;
            case nameof(Tags.Friendly):
                Debug.Log("Start");
                break;
            case nameof(Tags.Fuel):
                Debug.Log("Fuel");
                break;
            default:
                Debug.Log("Boom");
                break;
        }
    }
}

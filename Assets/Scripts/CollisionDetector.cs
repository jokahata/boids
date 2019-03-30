using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    public bool IsColliding
    {
        get; 
        private set;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision enter");
        IsColliding = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsColliding = false;
        Debug.Log("Collision exit");
    }
}

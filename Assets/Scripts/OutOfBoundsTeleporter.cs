using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTeleporter : MonoBehaviour
{

    [SerializeField]
    private GameObject oppositeTeleporter;

    private bool oppositeTeleporterIsOnRightSide;

    void Start()
    {
        oppositeTeleporterIsOnRightSide = oppositeTeleporter.transform.position.x > transform.position.x;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        float newX = oppositeTeleporter.transform.position.x;
        if (oppositeTeleporterIsOnRightSide)
        {
            newX -= 2f;
        }
        else
        {
            newX += 2f;
        }

        collider.attachedRigidbody.position = new Vector3(newX, collider.transform.position.y, collider.transform.position.z);
    }
}

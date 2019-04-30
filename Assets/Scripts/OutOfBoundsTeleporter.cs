using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTeleporter : MonoBehaviour
{

    [SerializeField]
    private GameObject oppositeTeleporter;

    private bool onLeftOrTop;
    private bool isVertical;

    void Start()
    {
        float horizontalDifference = Mathf.Abs(oppositeTeleporter.transform.position.x - transform.position.x);
        float verticalDifference = Mathf.Abs(oppositeTeleporter.transform.position.y - transform.position.y);
        isVertical = verticalDifference > horizontalDifference;

        if (isVertical)
        {
            onLeftOrTop = oppositeTeleporter.transform.position.y > transform.position.y;
        }
        else
        {
            onLeftOrTop = oppositeTeleporter.transform.position.x > transform.position.x;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isVertical)
        {
            float newY = oppositeTeleporter.transform.position.y;
            if (onLeftOrTop)
            {
                newY -= 2f;
            }
            else
            {
                newY += 2f;
            }

            collider.attachedRigidbody.position = new Vector3(collider.transform.position.x, newY, collider.transform.position.z);
        }
        else
        {
            float newX = oppositeTeleporter.transform.position.x;
            if (onLeftOrTop)
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
}

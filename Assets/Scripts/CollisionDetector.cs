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

    public float Direction
    {
        get;
        private set;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IsColliding = true;
        updateDirection(other.transform);
    }

    private void updateDirection(Transform target)
    {
		Vector3 heading = target.position - transform.position;
		Direction = AngleDir(transform.up, heading, transform.right);
    }

    private void drawInBetween(Transform transform, Transform target)
    {
        Vector3 VectorResult;
        float DotResult = Vector2.Dot(transform.up, target.up);
        if (DotResult > 0)
        {
            VectorResult = transform.up + target.up;
        }
        else
        {
            VectorResult = transform.up - target.up;
        }
        Debug.DrawRay(transform.position, VectorResult * 100, Color.green);

    }

    void onTriggerStay2D(Collider2D other)
    {
        IsColliding = true;
        drawInBetween(transform, other.transform);
        updateDirection(other.transform);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsColliding = false;
        drawInBetween(transform, other.transform);
        Direction = 0;
    }

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}
	
}

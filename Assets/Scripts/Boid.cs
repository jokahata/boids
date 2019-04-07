using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public Vector2 Position
    {
        get { return rigidbody2d.transform.position; }
    }

    [SerializeField]
    private float repulsionDistance = 3f;

    private float translationScale = .01f;

    private float speed = 0.05f;

    private Rigidbody2D rigidbody2d;
    private CollisionDetector collisionDetector;

    private BoidController boidController;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponentInChildren<CollisionDetector>();
        // TODO: Fix this
        boidController = GameObject.Find("Boids").GetComponent<BoidController>();
        if (boidController == null)
        {
            Debug.LogError("boidController missing");
        }
    }

    void Update()
    {
        Vector2 currentPosition = rigidbody2d.transform.position;
        Vector2 targetDirection = (getVectorTowardBoidMassCenter() + getRepulsionFromNeighbors()) - currentPosition;
        targetDirection.Normalize();

        Debug.DrawRay(transform.position, getVectorTowardBoidMassCenter().normalized, Color.red);
        Debug.DrawRay(transform.position, getRepulsionFromNeighbors().normalized, Color.blue);
        Debug.DrawRay(transform.position, targetDirection, Color.green);

        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        float currentAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;        

        float directionTest = Mathf.Sin(currentAngle - targetAngle);

        Vector3 axis = Vector3.forward;
        if (directionTest < 0)
        {
            axis = -axis;
        }

        Quaternion q = Quaternion.AngleAxis(targetAngle, axis);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2f);

        Vector2 direction = transform.up;
        Vector2 newPosition = rigidbody2d.position + direction * 0.1f;
        rigidbody2d.MovePosition(newPosition);
    }

    private Vector2 getVectorTowardBoidMassCenter()
    {
        if (boidController == null)
        {
            return new Vector2();
        }

        Vector2 boidsCenter = boidController.BoidsCenter;
        Vector2 stepTowardsCenter = (boidsCenter - rigidbody2d.position) * translationScale;
        return stepTowardsCenter;
    }

    private Vector2 getRepulsionFromNeighbors()
    {
        Vector2 repulsionVector = new Vector2();
        if (boidController == null)
        {
            return repulsionVector; 
        }

        Vector2 position = rigidbody2d.transform.position;
        foreach (Boid boid in boidController.Boids)
        {
            if (boid != this)
            {
                Vector2 positionDifference = position - boid.Position;
                float distance = Vector3.Magnitude(positionDifference);
                if (distance < repulsionDistance)
                {
                    repulsionVector += new Vector2(positionDifference.x, positionDifference.y);
                }
            } 
        }

        return repulsionVector * translationScale;
    }
}

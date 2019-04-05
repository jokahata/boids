using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float repulsionDistance = 3f;

    private float translationScale = .01f;

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
        // TODO: Rotate the body
        Vector2 newPosition = rigidbody2d.position + getVectorTowardBoidMassCenter() + getRepulsionFromNeighbors();
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

        Transform transform = rigidbody2d.transform;
        foreach (Transform boid in boidController.Boids)
        {
            if (boid != transform)
            {
                Vector3 positionDifference = transform.position - boid.position;
                positionDifference.z = 0;
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

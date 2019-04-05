using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float boidMassCenterScale = .01f;

    private Rigidbody2D rigidbody2d;
    private CollisionDetector collisionDetector;


    private BoidController boidController;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponentInChildren<CollisionDetector>();
        // TODO: Fix this
        boidController = GameObject.Find("Boids").GetComponent<BoidController>();
    }

    void Update()
    {
        // TODO: Rotate the body
        Vector2 newPosition = rigidbody2d.position + getVectorTowardBoidMassCenter();
        rigidbody2d.MovePosition(newPosition);
    }

    private Vector2 getVectorTowardBoidMassCenter()
    {
        if (boidController == null)
        {
            Debug.LogError("boidController missing");
            return new Vector2();
        }

        Vector2 boidsCenter = boidController.BoidsCenter;
        Vector2 stepTowardsCenter = (boidsCenter - rigidbody2d.position) * boidMassCenterScale;
        return stepTowardsCenter;
    }
}

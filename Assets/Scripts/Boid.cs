using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    private Rigidbody2D rigidbody2d;
    private CollisionDetector collisionDetector;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponentInChildren<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the body
        if (collisionDetector.IsColliding)
        {
            int rotation = -1;
            if (collisionDetector.Direction < 0)
            {
                rotation = 1;
            }
            rigidbody2d.MoveRotation(rigidbody2d.rotation + rotation);
        }

        // Move forward in direction currently facing
        rigidbody2d.MovePosition(rigidbody2d.transform.position + (transform.up * Time.deltaTime * speed));
    }
}

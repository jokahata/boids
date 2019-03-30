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
        Debug.Log("Test");
        rigidbody2d = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponentInChildren<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the body
        Debug.Log("Debug says: " + collisionDetector.IsColliding);
        if (collisionDetector.IsColliding)
        {
            rigidbody2d.MoveRotation(rigidbody2d.rotation + 1);
        }

        // Move forward in direction currently facing
        rigidbody2d.MovePosition(rigidbody2d.transform.position + (transform.up * Time.deltaTime * speed));
    }
}

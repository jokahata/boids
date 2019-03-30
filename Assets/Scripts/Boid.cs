using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the body
        rigidbody2d.MoveRotation(rigidbody2d.rotation + 1);

        // Move forward in direction currently facing
        rigidbody2d.MovePosition(rigidbody2d.transform.position + (transform.up * Time.deltaTime * speed));
    }
}

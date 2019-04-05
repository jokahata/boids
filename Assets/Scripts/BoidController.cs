using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{

    public Vector2 BoidsCenter
    {
        get;
        private set;
    }

    public List<Transform> Boids
    {
        get;
        private set;
    }

    private int numBoids;

    // Start is called before the first frame update
    void Start()
    {
        numBoids = 0;
        Boids = new List<Transform>();
        // TODO: Probably not a good idea to assume that all children are boids
        foreach (Transform child in transform)
        {
            Boids.Add(child);
            numBoids += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = new Vector2();
        foreach (Transform boid in Boids)
        {
            position += new Vector2(boid.position.x, boid.position.y);
        }
        BoidsCenter = position / numBoids;
    }
}

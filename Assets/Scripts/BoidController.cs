using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    [SerializeField]
    private GameObject boidsPrefab;

    public Vector2 BoidsCenter
    {
        get;
        private set;
    }

    public List<Boid> Boids
    {
        get;
        private set;
    }

    private int numBoids;

    // Start is called before the first frame update
    void Start()
    {
        updateBoidList();
    }
    
    private void updateBoidList()
    {
        numBoids = 0;
        Boids = new List<Boid>();
        // TODO: Probably not a good idea to assume that all children are boids
        foreach (Transform child in transform)
        {
            Boids.Add(child.GetComponent<Boid>());
            numBoids += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateBoidsCenter();
        spawnOnClick();
    }

    private void updateBoidsCenter()
    {
        Vector2 position = new Vector2();
        foreach (Boid boid in Boids)
        {
            position += new Vector2(boid.Position.x, boid.Position.y);
        }
        BoidsCenter = position / numBoids;
    }

    private void spawnOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(boidsPrefab, transform);
            updateBoidList();
        }
    }
}

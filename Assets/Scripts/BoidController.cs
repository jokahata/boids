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
        numBoids = 0;
        updateBoidList();
    }
    
    private void updateBoidList()
    {
        Boids = new List<Boid>();
        // TODO: Probably not a good idea to assume that all children are boids
        foreach (Transform child in transform)
        {
            addToBoidList(child.GetComponent<Boid>());
        }
    }

    private void addToBoidList(Boid boid)
    {
        if (boid == null) return;
        Boids.Add(boid);
        numBoids += 1;
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
            createNewBoid(getMousePositionInLocal());
        }
    }

    private Vector2 getMousePositionInLocal()
    {
        Vector3 worldPoint = getMousePositionInWorld();
        Vector3 localPosition = transform.InverseTransformVector(worldPoint);
        localPosition.z = -5;
        return localPosition;
    }

    private Vector3 getMousePositionInWorld()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void createNewBoid(Vector3 localPosition)
    {
        GameObject newBoid = Instantiate(boidsPrefab, transform);
        newBoid.transform.position = localPosition;
        addToBoidList(newBoid.GetComponent<Boid>());
    }
}

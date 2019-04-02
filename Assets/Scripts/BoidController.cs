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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numBoids = 0;
        Vector2 position = new Vector2();
        foreach (Transform child in transform)
        {
            numBoids += 1;
            position += new Vector2(child.position.x, child.position.y);
        }
        BoidsCenter = position / numBoids;
    }
}

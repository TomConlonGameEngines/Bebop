using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class SteeringBehaviour:MonoBehaviour
{
    public float weight = 1.0f;
    public Vector3 force;

    [HideInInspector]
    public BoidTesting boid;

    public void Awake()
    {
        boid = GetComponent<BoidTesting>();
    }

    public abstract Vector3 Calculate();
}

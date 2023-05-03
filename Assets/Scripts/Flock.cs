using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flock : MonoBehaviour
{
    [SerializeField]
    private GameObject boid;

    [SerializeField]
    private int boidCount;

    [Header("Parameters")]
    public float Perception;
    public float CollisionPerception;
    public float RotateSpeed;
    public float Maxforce;
    public float Maxforce2;
    public float Maxspeed;


    [Header("Multipliers")]
    [Range(0,5)]
    public float AlignSlider;
    [Range(0, 5)]
    public float CohisionSlider;
    [Range(0, 5)]
    public float SeperationSlider;

    public Vector3 Orientation;
    public Quaternion Rotationfix;

    public List<Boid> Boids;

    void Start()
    {
        for (int i=0;i< boidCount;i++) 
        {
            Boids.Add(Instantiate(boid, transform).GetComponent<Boid>());
        }
    }

    
}

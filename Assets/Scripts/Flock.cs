using System.Collections.Generic;
using UnityEngine;
using System;

public class Flock : MonoBehaviour
{
    //To make it easyer to tweak the behaviour fo each boid those parameters are public a d red by each boid every frame.
    [Header("Boid Parameters")]
    public float Perception;
    public float CollisionPerception;
    public float RotateSpeed;
    public float Maxforce;
    public float Maxspeed;

    [Header("Boid Start Parameters")]
    public float VelovityMin;
    public float VelovityMax;
    public float ScaleMin;
    public float ScaleMax;



    [Header("Multipliers")]
    [Range(0, 5)]
    public float AlignSlider;
    [Range(0, 5)]
    public float CohisionSlider;
    [Range(0, 5)]
    public float SeperationSlider;

    [Header("Modifiers")]
    public Quaternion Rotationfix;

    //Boids list is red by each boid every frame to get avrage angle, location and space.
    public List<Boid> Boids;

    [SerializeField]
    private GameObject boid;

    [SerializeField]
    private int boidCount;

    

    void Start()
    {
        for (int i=0;i< boidCount;i++) 
        {
            Boids.Add(Instantiate(boid, transform).GetComponent<Boid>());
        }
    }

    
}

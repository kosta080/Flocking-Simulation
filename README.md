# Flocking-Simulation
Craig Reynolds Boids algorithm implimented in unity

Unity Flocking Simulation Script

The Flocking Simulation script in Unity is an implementation of Craig Reynolds' Boids algorithm. This algorithm simulates coordinated animal motion, such as bird flocks and fish schools, by defining a set of principles that govern the behavior of each individual in the group.
https://www.red3d.com/cwr/boids/

While collaborating with Roman Koretsky, we discussed crowd behavior simulation and he shared a helpful YouTube video with me on how to implement the Boid behavior  https://www.youtube.com/watch?v=mhjuuHl6qHM 
This inspired me to try implementing it in Unity.

The implementation consists of two classes: Flock and Boid. The Flock class is responsible for generating the boids and contains public values that allow you to adjust the simulation parameters. The Boid class controls the behavior of each individual boid, using helper classes such as Steering and Vector Calculation.

It's important to note that boidCount and Ignorence both have significant impact on the performance of the simulation. If you increase boidCount and experience a drop in FPS, you should also increase Ignorence. This causes each boid to skip computation of neighboring boids, resulting in shorter for loops and a smoother game performance. Low values of Ignorence don't have a big impact on the overall appearance of the simulation, but values above 5 will start to make the boids ignore each other.

If you've made it this far, your force is strong ! 
I've also attempted to optimize the computation by combining them in a single loop, but this resulted in unexpected behavior.

If you have any suggestions for improving this implementation, please feel free to share them.

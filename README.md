# Flocking-Simulation
Craig Reynolds Boids algorithm implimented in unity

During my work with Roman Koretsky we talked about croud behaviour simulation and he showed me this YT video 
which is showing how to impliment the Boid behaviour in JS 
https://www.youtube.com/watch?v=mhjuuHl6qHM

the boid simulation model is a set of principals that were created by Craig Reynolds in 1986 to simulate coordinated animal motion such as bird flocks and fish schools.
https://www.red3d.com/cwr/boids/

Since i came across this article wanted to try this in Unity.
Here is my implementation of the Boids model

the Flock class is responcible for generation the boids and cantains public valiues to let you tweak the parameters
the Boid class is controlling the individial boid and using the helper classes (Stearing, VectCalc)

boidCount and Ignorence bothe have segnificant impact on the performence
if you increase boidCount and get FPS drop you should also increase Ignorence which makes each boid skip neghbor boids in the computation whoch makes the for loops shorter and the game run smoother
low values of Ignorence dont have big impact on the overall appearence of the simulation but above 5 you start to notice that boids are ignoring each other


Feel free to comment if you see how this can be improved.

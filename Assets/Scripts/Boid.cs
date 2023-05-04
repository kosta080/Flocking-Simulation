using UnityEngine;

public class Boid: MonoBehaviour
{
	public Vector2 position;
	public Vector2 velovity;

	public float perception;
	public float collisionPerception;
	public float maxforce;
	public float maxspeed;
	public int ignorence;

	private Vector3 prevPos = Vector3.zero;
	private Vector2 acceleration;
	private float individualScale;
	private Flock flock;


	private void Start()
	{
		flock = FindObjectOfType<Flock>();

		position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
		velovity = Random.insideUnitCircle.normalized;
		velovity *= Random.Range(flock.VelovityMin, flock.VelovityMax);
		acceleration = Vector2.zero;
		individualScale = Random.Range(flock.ScaleMin, flock.ScaleMax);
		
		transform.localScale = new Vector3(individualScale, individualScale, individualScale);
	}
	
	private void Update()
	{
		takeParamsFromFlockClass();

		//Calculating adding up forces
		acceleration =	(Stearing.Separation(this, flock.Boids) * flock.SeperationSlider) + 
						(Stearing.Align(this, flock.Boids) * flock.AlignSlider) + 
						(Stearing.Cohesion(this, flock.Boids) * flock.CohisionSlider);

		//Adding velovity and forces
		position += velovity * Time.deltaTime;
		velovity += acceleration;

		//Each boit that go uot of the creen reappear on the other side
		position = VectCalc.loopScreen(position);

		transform.position = VectCalc.vec2to3(position);

		updateBoidRotation();
		
	}

	private void takeParamsFromFlockClass()
	{
		perception = flock.Perception * individualScale;
		maxforce = flock.Maxforce * individualScale;
		maxspeed = flock.Maxspeed * individualScale;
		collisionPerception = flock.CollisionPerception;
		ignorence = flock.Ignorence > 1 ? flock.Ignorence : 1;
	}

	private void updateBoidRotation()
	{
		Vector3 lookVector = (prevPos - transform.position).normalized;
		if (lookVector == Vector3.zero)
			return;

		Quaternion rotation = Quaternion.LookRotation(lookVector, Vector3.forward);
		rotation = rotation * flock.Rotationfix;
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 9);

		prevPos = transform.position;
	}

}

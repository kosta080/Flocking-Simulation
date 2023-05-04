using UnityEngine;

public class Boid: MonoBehaviour
{
	public Vector2 position;
	public Vector2 velovity;
	public Vector2 acceleration;
	public float perception;
	public float collisionPerception;
	public float maxforce;
	public float maxspeed;

	private float personality;

	private Flock flock;

	private void Awake()
	{
		position = new Vector2(Random.Range(0, Screen.width), Random.Range(0,Screen.height));

		velovity = Random.insideUnitCircle.normalized;
		velovity *= Random.Range(2.5f, 6.5f);
		acceleration = Vector2.zero;
		personality = Random.Range(0.8f, 1.2f);
	}
	private void Start()
	{
		flock = FindObjectOfType<Flock>();
	}
	Vector3 prevPos = Vector3.zero;
	
	private void Update()
	{
		//taking parameters from the flock
		perception = flock.Perception* personality;
		maxforce = flock.Maxforce* personality;
		maxspeed = flock.Maxspeed* personality;
		collisionPerception = flock.CollisionPerception;

		acceleration = (Separation() * flock.SeperationSlider) + 
						(Align() * flock.AlignSlider) + 
						(Cohesion() * flock.CohisionSlider);
		
		position += velovity * Time.deltaTime*50;
		velovity += acceleration;
		position = loopScreen(position);
		transform.position = m3(position);

		Vector3 lookVector = (prevPos - transform.position).normalized;
		if (lookVector == Vector3.zero)
			return;
		
		Quaternion rotation = Quaternion.LookRotation(lookVector, Vector3.forward);
		rotation = rotation * flock.Rotationfix;
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*9);

		prevPos = transform.position;
	}
	private Vector2 loopScreen(Vector2 pos)
	{
		if (pos.x > Screen.width)pos.x = 0;
		if (pos.x < 0)pos.x = Screen.width;
		if (pos.y > Screen.height)pos.y = 0;
		if (pos.y < 0)pos.y = Screen.height;
		return pos;
	}

	private Vector2 Align()
	{
		Vector2 avgVelovity = Vector2.zero;
		int count = 0;
		foreach (Boid other in flock.Boids)
		{
			if (other == this)
				continue;
			float dist = Vector2.Distance(position, other.position);
			if (dist > perception)
				continue;

			avgVelovity += other.velovity;
			count++;
		}
		if (count > 0)
		{
			avgVelovity /= count;

			//set magnetude
			avgVelovity.Normalize();
			avgVelovity *= maxspeed;

			Vector2 force = avgVelovity - velovity;
			force = clampV2(force, maxforce * -1, maxforce);
			return force;
		}
		return Vector2.zero;
	}

	private Vector2 Cohesion()
	{
		Vector2 avgPosition = Vector2.zero;
		int count = 0;
		foreach (Boid other in flock.Boids)
		{
			if (other == this)
				continue;
			float dist = Vector2.Distance(position, other.position);
			if (dist > perception)
				continue;

			avgPosition += other.position;
			count++;
		}
		if (count > 0)
		{
			avgPosition /= count;

			avgPosition -= m2(transform.position);
			//set magnetude
			avgPosition.Normalize();
			avgPosition *= maxspeed;

			Vector2 force = avgPosition - velovity;
			force = clampV2(force, maxforce * -1, maxforce);
			return force;
		}
		return Vector2.zero;
	}
	
	private Vector2 Separation()
	{
		Vector2 avgSpace = Vector2.zero;
		int count = 0;
		foreach (Boid other in flock.Boids)
		{
			if (other == this)
				continue;
			float dist = Vector2.Distance(position, other.position);
			if (dist > collisionPerception)
				continue;

			Vector2 diff = m2(transform.position) - other.position;
			avgSpace += diff / dist;
			count++;
		}
		if (count > 0)
		{
			//avg
			avgSpace /= count;

			//avgPosition -= m2(transform.position);
			//set magnetude
			avgSpace.Normalize();
			avgSpace *= maxspeed;
			//subtract velovity
			Vector2 force = avgSpace - velovity;
			//limit to max force
			force = clampV2(force, maxforce * -1, maxforce);
			return force;
		}
		return Vector2.zero;
	}
	private Vector2 clampV2(Vector2 vect,float min,float max)
	{
		vect.x = Mathf.Clamp(vect.x, min, max);
		vect.y = Mathf.Clamp(vect.y, min, max);
		return vect;
	}
	private Vector2 m2(Vector3 v3)
	{
		return new Vector2(v3.x, v3.y);
	}
	private Vector3 m3(Vector2 v2)
	{
		return new Vector3(v2.x, v2.y, 0.0f);
	}
}

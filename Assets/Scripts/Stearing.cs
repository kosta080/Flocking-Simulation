using System.Collections.Generic;
using UnityEngine;

public class Stearing 
{
    public static Vector2 Align(Boid thisBoid, List<Boid> otherBoids)
    {
		
		Vector2 avgVelovity = Vector2.zero;
		int count = 0;
		for (int i = 0; i < otherBoids.Count; i += thisBoid.ignorence)
		{
			if (otherBoids[i] == thisBoid)
				continue;
			float dist = Vector2.Distance(thisBoid.position, otherBoids[i].position);
			if (dist > thisBoid.perception)
				continue;

			avgVelovity += otherBoids[i].velovity;
			count++;
		}
		if (count > 0)
		{
			avgVelovity /= count;

			//set magnetude
			avgVelovity.Normalize();
			avgVelovity *= thisBoid.maxspeed;

			Vector2 force = avgVelovity - thisBoid.velovity;
			force = VectCalc.clampV2(force, thisBoid.maxforce * -1, thisBoid.maxforce);
			return force;
		}

		return Vector2.zero;
	}
	public static Vector2 Cohesion(Boid thisBoid, List<Boid> otherBoids)
	{
		
		Vector2 avgPosition = Vector2.zero;
		int count = 0;
		for (int i = 0; i < otherBoids.Count; i += thisBoid.ignorence)
		{
			if (otherBoids[i] == thisBoid)
				continue;
			float dist = Vector2.Distance(thisBoid.position, otherBoids[i].position);
			if (dist > thisBoid.perception)
				continue;

			avgPosition += otherBoids[i].position;
			count++;
		}
		if (count > 0)
		{
			avgPosition /= count;

			avgPosition -= VectCalc.vec3to2(thisBoid.position);
			//set magnetude
			avgPosition.Normalize();
			avgPosition *= thisBoid.maxspeed;

			Vector2 force = avgPosition - thisBoid.velovity;
			force = VectCalc.clampV2(force, thisBoid.maxforce * -1, thisBoid.maxforce);
			return force;
		}
		return Vector2.zero;
	}
	public static Vector2 Separation(Boid thisBoid, List<Boid> otherBoids)
	{
		
		Vector2 avgSpace = Vector2.zero;
		int count = 0;
		//(Boid other in otherBoids)
		for (int i=0; i < otherBoids.Count;i+= thisBoid.ignorence)
		{
			if (otherBoids[i] == thisBoid)
				continue;
			float dist = Vector2.Distance(thisBoid.position, otherBoids[i].position);

			if (dist > thisBoid.collisionPerception)
				continue;

			Vector2 diff = VectCalc.vec3to2(thisBoid.position) - otherBoids[i].position;
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
			avgSpace *= thisBoid.maxspeed;
			//subtract velovity
			Vector2 force = avgSpace - thisBoid.velovity;
			//limit to max force
			force = VectCalc.clampV2(force, thisBoid.maxforce * -1, thisBoid.maxforce);
			return force;
		}
		return Vector2.zero;
	}


}

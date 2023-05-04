using UnityEngine;

public class VectCalc
{
	public static Vector2 clampV2(Vector2 vect, float min, float max)
	{
		vect.x = Mathf.Clamp(vect.x, min, max);
		vect.y = Mathf.Clamp(vect.y, min, max);
		return vect;
	}
	public static Vector2 vec3to2(Vector3 v3)
	{
		return new Vector2(v3.x, v3.y);
	}
	public static Vector3 vec2to3(Vector2 v2)
	{
		return new Vector3(v2.x, v2.y, 0.0f);
	}

	public static Vector2 loopScreen(Vector2 pos)
	{
		if (pos.x > Screen.width) pos.x = 0;
		if (pos.x < 0) pos.x = Screen.width;
		if (pos.y > Screen.height) pos.y = 0;
		if (pos.y < 0) pos.y = Screen.height;
		return pos;
	}
}

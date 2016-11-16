using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {

	public float maxSpeed; 
	public float maxAcceleration; 
	public float maxRotation; 
	public float maxAngularAccel; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float RotationDirection (float rotation)
	{
		rotation %= 360.0f; 
		if (Mathf.Abs (rotation) > 180.0f) 
		{
			if (rotation < 0.0f)
				rotation += 360.0f;
			else
				rotation -= 180.0f;
		}

		return rotation; 
	}
}

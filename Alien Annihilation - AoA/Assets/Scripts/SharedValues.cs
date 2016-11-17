using UnityEngine;
using System.Collections;

public class SharedValues : MonoBehaviour {

	float gravity = 9.80f;
	float maxSpeed = 3.0f;

	public float GetGravityValue()
	{
		float grav = gravity;
		return grav;
	}

	public float GetMaxSpeedValue()
	{
		float speed = maxSpeed;
		return speed;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{

	private Animation anim ; 

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKey (KeyCode.Space))
		{
			anim.Play ("soldierFiring");
		}

	}

}

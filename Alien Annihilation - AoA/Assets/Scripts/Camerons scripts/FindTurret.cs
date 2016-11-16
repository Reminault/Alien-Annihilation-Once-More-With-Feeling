using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FindTurret : NodeCs
{

	public GameObject [] allTurrets;
	public float turretDistance;
	public GameObject closestTurret; 
	public float closestDistance;
	public bool hasPath;
	// Use this for initialization
	void Start () {

		closestDistance = Mathf.Infinity;
		hasPath = false; 

	}

	// Update is called once per frame
	void Update ()
	{
		currentBehaviour ();
	}

	public override void currentBehaviour()
	{
		
		allTurrets = GameObject.FindGameObjectsWithTag ("Turret");

		//closestDistance = Mathf.Infinity;
		if (hasPath == false) 
		{

			hasPath = true;
			
			foreach (GameObject turret in allTurrets) {
				Debug.Log ("yes" + allTurrets);
				//draws distance from all turrets and all enemies
				//Vector3 direction = transform.position - turret.transform.position;
				turretDistance = Vector3.Distance (transform.position, turret.transform.position); 


		 	 

				if (turretDistance < closestDistance) 
				{
					closestDistance = turretDistance;
					GetComponent<Unit> ().requestPath (turret.transform);

					if (allTurrets[allTurrets.Length -1])
					{
						hasPath = false;
						Debug.Log (hasPath);
					}
				}

		
			}

		}
//		Debug.Log (closestDistance);



		}
	

}

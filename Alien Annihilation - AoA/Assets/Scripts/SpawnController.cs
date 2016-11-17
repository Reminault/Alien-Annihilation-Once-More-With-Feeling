using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	int wave;
	int waveSize;
	int enemyWaveSize;
	int baseWaveSize = 1;
	Vector3 spawnLocation1, spawnLocation2, spawnLocation3, spawnLocation4, spawnLocation5, spawnLocation6, spawnLocation7, spawnLocation8, spawnLocation9;
	string enemyType;
	public GameObject alienPrefab;
	GameObject Alien;

	int RndChck1, RndChck2;
	Vector3 hivePosition1, hivePosition2, hivePosition3;

	Vector3 spawnPoint;
	//Vector3[] hiveLocations = new Vector3[3];
	Vector3[] spawnLocations = new Vector3[9];
	//List <String> listedEnemyTypes = new List<String>();
	bool spawnWave = false;



	// Use this for initialization
	void Start () 
	{
		spawnLocation1 = GameObject.Find ("SpawnLocation1").GetComponent<Transform>().transform.position;
		spawnLocation2 = GameObject.Find ("SpawnLocation2").GetComponent<Transform>().transform.position; 
		spawnLocation3 = GameObject.Find ("SpawnLocation3").GetComponent<Transform>().transform.position;
		spawnLocation4 = GameObject.Find ("SpawnLocation4").GetComponent<Transform>().transform.position;
		spawnLocation5 = GameObject.Find ("SpawnLocation5").GetComponent<Transform>().transform.position;
		spawnLocation6 = GameObject.Find ("SpawnLocation6").GetComponent<Transform>().transform.position;
		spawnLocation7 = GameObject.Find ("SpawnLocation7").GetComponent<Transform>().transform.position;
		spawnLocation8 = GameObject.Find ("SpawnLocation8").GetComponent<Transform>().transform.position;
		spawnLocation9 = GameObject.Find ("SpawnLocation9").GetComponent<Transform>().transform.position;

		spawnLocations [0] = spawnLocation1;
		spawnLocations [1] = spawnLocation2;
		spawnLocations [2] = spawnLocation3;
		spawnLocations [3] = spawnLocation4;
		spawnLocations [4] = spawnLocation5;
		spawnLocations [5] = spawnLocation6;
		spawnLocations [6] = spawnLocation7;
		spawnLocations [7] = spawnLocation8;
		spawnLocations [8] = spawnLocation9;
	
	}

	public int GenerateWaveSize()
	{
		wave = GameObject.Find("GameManager").GetComponent<GameManager>().GetWaveNumber();
		//enemyWaveSize = wave * baseWaveSize;
		enemyWaveSize = baseWaveSize + wave;
		Debug.Log ("Enemy Wave Size:" + enemyWaveSize);
		return enemyWaveSize;
	}

	void Spawn(Vector3 location)
	{
		Alien = (GameObject)Instantiate(alienPrefab, location, Quaternion.identity);
		Debug.Log ("Alien Spawn");
	}

	// Update is called once per frame
	void Update () 
	{
		spawnWave = GameObject.Find("GameManager").GetComponent<GameManager>().GetWaveState();
		Debug.Log ("Spawner State " + spawnWave);


		if (spawnWave == true) 
		{
			waveSize = GenerateWaveSize ();

			for (int k = 0; k <= waveSize; k++) 
			{
				RndChck1 = (int)Random.Range (0.0f, 3.0f);
			
				if (RndChck1 == 1) 
				{
					Debug.Log ("Hive: " + RndChck1 + "Active");
					RndChck2 = (int)Random.Range (0.0f, 2.0f);
					spawnPoint = spawnLocations [RndChck2];
					Spawn (spawnPoint);
					Debug.Log ("Spawned @ Location " + RndChck2);
				} 
				else if (RndChck1 == 2) 
				{
					Debug.Log ("Hive: " + RndChck1 + "Active");
					RndChck2 = (int)Random.Range (3.0f, 5.0f);
					spawnPoint = spawnLocations [RndChck2];
					Spawn (spawnPoint);
					Debug.Log ("Spawned @ Location " + RndChck2);
				} 
				else if (RndChck1 == 3) {
					Debug.Log ("Hive: " + RndChck1 + "Active");
					RndChck2 = (int)Random.Range (6.0f, 8.0f);
					spawnPoint = spawnLocations [RndChck2];
					Spawn (spawnPoint);
					Debug.Log ("Spawned @ Location " + RndChck2);
				}

				Debug.Log ("Complete Run");
			}
			spawnWave = !spawnWave;
			GameObject.Find("GameManager").GetComponent<GameManager>().SetWaveState(spawnWave);
			Debug.Log ("Spawning Completed");
		}

	}
}

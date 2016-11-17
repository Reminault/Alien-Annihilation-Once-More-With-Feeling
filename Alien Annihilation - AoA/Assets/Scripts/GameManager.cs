using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int waveNumber= 0;
	int playerScore = 0;
	int scoreAwarded;
	int activeEnemies = 0;
	GameObject Player;
	bool beginWave = false;
	float timeToWaveStart;
	float currentTime;


	// Use this for initialization
	void Start () {
	
	}

	public int GetWaveNumber()
	{
		return waveNumber;
	}

	public bool GetWaveState()
	{
		return beginWave;
	}

	public bool SetWaveState(bool newState)
	{
		beginWave = newState;
		return beginWave;
	}



	// Update is called once per frame
	void Update () 
	{
		if (activeEnemies == 0) 
		{
			currentTime = Time.timeSinceLevelLoad;
			timeToWaveStart = currentTime + 20.0f;
			if (currentTime == timeToWaveStart) 
			{
				beginWave = true;
				GameObject.Find("GameManager").GetComponent<SpawnController>();
				//activeEnemies = SpawnController ().GenerateWaveSize ();
				activeEnemies = GameObject.Find("GameManager").GetComponent<SpawnController>().GenerateWaveSize();
				Debug.Log("Active Enemies:" + activeEnemies);
				waveNumber++;
				Debug.Log("Current Wave:" + waveNumber);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public int currentEnemyHealth;
	public int totalEnemyHealth;

	public int enemyDamage;
	public int enemyDefense;
	public Vector3 enemySpeed;

	float maxEnemySpeed;

	public int getEnemyDamage()
	{
		return enemyDamage;
	}
	public void getAndTakeDamage(int dmg)
	{
		currentEnemyHealth -= dmg;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

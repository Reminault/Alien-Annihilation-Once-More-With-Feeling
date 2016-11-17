using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPooling : MonoBehaviour {

	public GameObject bulletPrefab;
	GameObject Bullet;
	GameObject[] Bullets = new GameObject[15];
	Vector3 bulletLocation;
	int selectedBullet;


	// Use this for initialization
	void Start () 
	{	
		bulletLocation = GameObject.Find("BulletSpawn").GetComponent<Transform>.position();

		for (int i = 0; i <= Bullets.Length; i++) 
		{
			GameObject Bullet = (GameObject)Instantiate(bulletPrefab, bulletLocation, Quaternion.identity);
			Bullets [i] = Bullet;
		}

		selectedBullet = 0;
	}

	public GameObject AccessBullet()
	{

		return 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

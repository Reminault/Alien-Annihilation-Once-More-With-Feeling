using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour {


    public int currentPlayerHealth;
    public int maxPlayerHealth;
	public Image healthBar;

    public int playerDamage;
    public int playerDefense;
    public Vector3 playerSpeed;
	float playerMaxSpeed;

    bool turnOnSpawner = false;
    Rigidbody playerRB;

    public int getPlayerDamage()
    {
        return playerDamage;
    }
    public void getAndTakeDamage(int dmg)
    {
        currentPlayerHealth -= dmg;
    }

    public int getCurrentPlayerHealthAndDefense()
    {
        int playerHD = currentPlayerHealth + playerDefense;
        return playerHD;
    }

	void Attack()
	{
		
	}

	void Die()
	{
		//Application.LoadLevel(Application.loadedLevel);
	}

	// Update is called once per frame
	void Update () 
    {
		healthBar.fillAmount = (float)currentPlayerHealth / maxPlayerHealth;

		if (currentPlayerHealth <= 0)
		{
			Die();
		}

        //playerSpeed = new Vector3(0, 0, 0);

		if (Input.GetAxis("Vertical") > 0)
        {
            //positive
            playerSpeed.z = 5;
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
			//this.gameObject.transform.rotation.y = 90;
        }
		if (Input.GetAxis("Vertical") < 0)
        {
            //negative
            playerSpeed.z = -5;
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
			//this.gameObject.transform.rotation.y = 180;

        }
		if (Input.GetAxis("Horizontal") < 0)
        {
            //negative
            playerSpeed.x = -5;
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
			//this.gameObject.transform.rotation.y = 270;

        }
		if (Input.GetAxis("Horizontal") > 0)
        {
            //positive
            playerSpeed.x = 5;
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
			//this.gameObject.transform.rotation.y = 0;

        }
		//this.gameObject.transform.position += playerSpeed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Return)) 
		{
			turnOnSpawner = !turnOnSpawner;
			GameObject.Find("GameManager").GetComponent<GameManager>().SetWaveState(turnOnSpawner);
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Attack ();
		}
			
	}
}

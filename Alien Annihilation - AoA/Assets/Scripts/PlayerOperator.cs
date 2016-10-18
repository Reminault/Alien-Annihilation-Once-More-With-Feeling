using UnityEngine;
using System.Collections;

public class PlayerOperator : MonoBehaviour {


    public int currentPlayerHealth;
    public int maxPlayerHealth;

    public int playerDamage;
    public int playerDefense;
    public Vector3 playerSpeed;
	float playerMaxSpeed = 3;

    bool isGrounded;
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
	
    //private Vector3 movement()
    //{
    //    Vector3 moveDirection;
    //    int x = 0;
    //    int y = 0;
    //    int z = 0;
    //    moveDirection = new Vector3 (x,y,z);

    //    return moveDirection;
    //}

	// Update is called once per frame
	void Update () 
    {
        //playerSpeed = new Vector3(0, 0, 0);

		while (Input.GetAxis("Vertical") > 0)
        {
            //positive
            playerSpeed.z = 1;
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
        }
		if (Input.GetAxis("Vertical") < 0)
        {
            //negative
            playerSpeed.z += -1;
            //this.gameObject.transform.position += playerSpeed * Time.deltaTime;

        }
		if (Input.GetAxis("Horizontal") < 0)
        {
            //negative
            playerSpeed.x += -1;
            //this.gameObject.transform.position += playerSpeed * Time.deltaTime;

        }
		if (Input.GetAxis("Horizontal") > 0)
        {
            //positive
            playerSpeed.x += 1;
            //this.gameObject.transform.position += playerSpeed * Time.deltaTime;

        }
		//this.gameObject.transform.position += playerSpeed * Time.deltaTime;

	    
	}
}

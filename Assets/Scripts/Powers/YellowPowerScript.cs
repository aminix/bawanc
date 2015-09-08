using UnityEngine;
using System.Collections;

public class YellowPowerScript : MonoBehaviour {

	public GameObject 	YellowPowerBall;


	private wowc		WowC;
	private GameObject 	yellowPowerBall;
	private bool 		canShoot;


	// Use this for initialization
	void Start () 
	{
		WowC = gameObject.GetComponent<wowc>();
	}

	void OnEnable()
	{
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			if(canShoot)
				ShootPower();
		}
	}

	void ShootPower()
	{

		if(yellowPowerBall == null)
		{
			yellowPowerBall = Instantiate(YellowPowerBall,transform.position,
			                                Quaternion.identity) as GameObject;
		}
		//IF existing bring it back to its former position;
		else
		{
			yellowPowerBall.SetActive(true);
			yellowPowerBall.transform.position = transform.position;
		}

		if(WowC.facingRight)
		{
			yellowPowerBall.GetComponent<Rigidbody>().velocity = new Vector3(15,0,0);
			yellowPowerBall.transform.LookAt(Vector3.right);
		}
		// Else give velocity to go to LEFT
		else 
		{
			yellowPowerBall.GetComponent<Rigidbody>().velocity = new Vector3(-15,0,0);
			yellowPowerBall.transform.LookAt(Vector3.left);
		}
		
		canShoot = false;
		this.enabled = false;
	}


}

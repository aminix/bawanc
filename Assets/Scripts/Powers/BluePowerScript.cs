using UnityEngine;
using System.Collections;

public class BluePowerScript : MonoBehaviour {
	


	

	private wowc 		WowC; // the character
	public float 		DashTime = 3f; //how long will the speed last
	public float 		Duration;  // the time left in the speed duration
	public float		AddedSpeed = 15f; //the new max speed after the orb activation
	public bool 		StartDuration; //the boolean trigger for the start and pause of the speed duration
	public bool 		EnableSpeedUp; //the trigger to implement the speed
	void Awake () 
	{
		WowC = gameObject.GetComponent<wowc>();
		
	}



	void Update () 
	{
        Debug.Log("MoveForce " + WowC.moveForce);
        Debug.Log("MaxSpeed " + WowC.maxSpeed);

		if (StartDuration) {    //if the StartDuration trigger is on the Duration Time will increment
			Duration += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.F)) { // the key will trigger the on/off of the dash 
			StartDuration = !StartDuration;
			EnableSpeedUp = !EnableSpeedUp;
		}

		if (Duration <= DashTime && EnableSpeedUp) { //if the enableSpeedUp is on, and the the Duration has still seconds left the SpeedUp will occur
			SpeedUp ();
		}else{  
			WowC.moveForce = 365f;
			WowC.maxSpeed = 5f;
		}

		if (Duration >= DashTime) { //if the Duration reached the DashTime limit, the Orb effect will be disabled.
            StartDuration = false;
            EnableSpeedUp = false;
			Duration = 0f;
			WowC.moveForce = 365f;
			WowC.maxSpeed = 5f;
			this.enabled = false;
		}	
	}

	void SpeedUp(){ // where the speeding up part takes place.
		WowC.moveForce = 365f * 2;
		WowC.maxSpeed = 5 + AddedSpeed;
	}

}

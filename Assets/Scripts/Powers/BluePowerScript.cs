using UnityEngine;
using System.Collections;

public class BluePowerScript : MonoBehaviour {
	


	

	private wowc 		WowC; // the character
	public float 		DashTime = 3f; //how long will the speed last
	public float 		Duration;  // the time left in the speed duration
	public float		AddedSpeed = 15f; //the new max speed after the orb activation
	public bool 		StartDuration; //the boolean trigger for the start and pause of the speed duration
	public bool 		EnableSpeedUp; //the trigger to implement the speed

    private GameObject rightHandSpeeder;
    private GameObject leftHandSpeeder;
    private GameObject rightFootSpeeder;
    private GameObject leftFootSpeeder;
    void Awake () 
	{
		WowC = gameObject.GetComponent<wowc>();
        SpeedEffect();
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
            rightHandSpeeder.SetActive(EnableSpeedUp);
            leftHandSpeeder.SetActive(EnableSpeedUp);
            rightFootSpeeder.SetActive(EnableSpeedUp);
            leftFootSpeeder.SetActive(EnableSpeedUp);
        }
        else{
            rightHandSpeeder.SetActive(EnableSpeedUp);
            leftHandSpeeder.SetActive(EnableSpeedUp);
            rightFootSpeeder.SetActive(EnableSpeedUp);
            leftFootSpeeder.SetActive(EnableSpeedUp);
            WowC.moveForce = 365f;
			WowC.maxSpeed = 5f;
		}

		if (Duration >= DashTime) { //if the Duration reached the DashTime limit, the Orb effect will be disabled.
            StartDuration = false;
            EnableSpeedUp = false;
            rightHandSpeeder.SetActive(EnableSpeedUp);
            leftHandSpeeder.SetActive(EnableSpeedUp);
            rightFootSpeeder.SetActive(EnableSpeedUp);
            leftFootSpeeder.SetActive(EnableSpeedUp);
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

    void SpeedEffect()
    {
        var Ahiraavan = transform.FindChild("Ahiraavan").transform;
        var rig = Ahiraavan.FindChild("rig").transform;
        var rigRoot = rig.FindChild("rig|root").transform;
    
        var rShoulder = rigRoot.FindChild("rig|MCH-upper_arm.fk.R.socket2").transform;
        var rUpperarm = rShoulder.FindChild("rig|upper_arm.fk.R").transform;
        var rUpperarm1 = rUpperarm.FindChild("rig|MCH-upper_arm_antistr.fk.R").transform;
        var rForearm = rUpperarm1.FindChild("rig|forearm.fk.R").transform;
        var rForearm1 = rForearm.FindChild("rig|MCH-forearm_antistr.fk.R").transform;
        rightHandSpeeder = rForearm1.FindChild("Blue Power").gameObject as GameObject;
     
        var lShoulder = rigRoot.FindChild("rig|MCH-upper_arm.fk.L.socket2").transform;
        var lUpperarm = lShoulder.FindChild("rig|upper_arm.fk.L").transform;
        var lUpperarm1 = lUpperarm.FindChild("rig|MCH-upper_arm_antistr.fk.L").transform;
        var lForearm = lUpperarm1.FindChild("rig|forearm.fk.L").transform;
        var lForearm1 = lForearm.FindChild("rig|MCH-forearm_antistr.fk.L").transform;
        leftHandSpeeder = lForearm1.FindChild("Blue Power").gameObject as GameObject;

        var rHips = rigRoot.FindChild("rig|MCH-thigh.fk.R.socket2").transform;
        var rThigh = rHips.FindChild("rig|thigh.fk.R").transform;
        var rThigh1 = rThigh.FindChild("rig|MCH-thigh_antistr.fk.R").transform;
        var rShin = rThigh1.FindChild("rig|shin.fk.R").transform;
        var rShin1 = rShin.FindChild("rig|MCH-shin_antistr.fk.R").transform;
        rightFootSpeeder = rShin1.FindChild("Blue Power").gameObject as GameObject;

        var lHips = rigRoot.FindChild("rig|MCH-thigh.fk.L.socket2").transform;
        var lThigh =lHips.FindChild("rig|thigh.fk.L").transform;
        var lThigh1 = lThigh.FindChild("rig|MCH-thigh_antistr.fk.L").transform;
        var lShin = lThigh1.FindChild("rig|shin.fk.L").transform;
        var lShin1 = lShin.FindChild("rig|MCH-shin_antistr.fk.L").transform;
        leftFootSpeeder = lShin1.FindChild("Blue Power").gameObject as GameObject;


    }
}

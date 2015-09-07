using UnityEngine;
using System.Collections;

public class RedPowerScript : MonoBehaviour {

	//ATTACHED TO THE PLAYER SCRIPT



	//PUBLIC STATIC


	//PUBLIC


	//Effect
	public GameObject FireBall;

	//PRIVATE


	//Outside Components
	private wowc 		WowC;

	private GameObject 	rightHandPower;
	private GameObject 	leftHandPower;
	private GameObject 	rightHandFireBall;
	private GameObject 	leftHandFireBall;

	//FireBalls
	private GameObject 	fireBall1,fireBall2;



	// Use this for initialization
	void Awake () 
	{
		WowC = gameObject.GetComponent<wowc>();
		FindArms();

	}

	void OnEnable()
	{
		rightHandPower.SetActive(true);
		leftHandPower.SetActive(true);


	}


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.V))
		{
			FireShotsOneAtATime();


		}
	}

	void FireShotsOneAtATime ()
	{
		//If Right Hand Power (effect) is on. First Shot
		if(rightHandPower.activeSelf)
		{
			//Deactivate it
			rightHandPower.SetActive(false);
			//create a new fireball if not existing already
			if(rightHandFireBall == null)
			{
				rightHandFireBall = Instantiate(FireBall,rightHandPower.transform.position,
				                                Quaternion.Euler(110,0,0)) as GameObject;
			}
			//IF existing bring it back to its former position;
			else
			{
				rightHandFireBall.SetActive(true);
				rightHandFireBall.transform.position = rightHandPower.transform.position;
			}
			//If facing right give velocity to go to RIGHT
			if(WowC.facingRight)
			{
				rightHandFireBall.GetComponent<Rigidbody>().velocity = new Vector3(10,0,0);
				rightHandFireBall.transform.LookAt(Vector3.right);
			}
			// Else give velocity to go to LEFT
			else 
			{
				
				rightHandFireBall.GetComponent<Rigidbody>().velocity = new Vector3(-12,0,0);
				rightHandFireBall.transform.LookAt(Vector3.left);
			}

			//Returning so we dont shoot both Fire SHOTS at ONCE
			return;
		}
		else if(leftHandPower.activeSelf)
		{
			//Deactivate it
			leftHandPower.SetActive(false);
			//create a new fireball if not existing already
			if(leftHandFireBall == null)
			{
				leftHandFireBall = Instantiate(FireBall,leftHandPower.transform.position,
				                               Quaternion.Euler(110,0,0)) as GameObject;
			}
			//IF existing bring it back to its former position;
			else
			{
				leftHandFireBall.SetActive(true);
				leftHandFireBall.transform.position = leftHandPower.transform.position;
			}
			//If facing right give velocity to go to RIGHT
			if(WowC.facingRight)
			{
				leftHandFireBall.GetComponent<Rigidbody>().velocity = new Vector3(10,0,0);
				leftHandFireBall.transform.LookAt(Vector3.right);
			}
			// Else give velocity to go to LEFT
			else 
			{
				
				leftHandFireBall.GetComponent<Rigidbody>().velocity = new Vector3(-12,0,0);
				leftHandFireBall.transform.LookAt(Vector3.left);
			}
			
			//ONCE BOTH POWERS USED. TURN THIS SCRIPT OFF
			this.enabled = false;
			
			
		}

	}
	
	//Finding Arms - Bones to attach fire effect
	//This will change once we have the real model as we will need to find those bones.
	//This is Blender Skeleton, we will be using C4D skeleton
	void FindArms()
	{
		var Ahiraavan = transform.FindChild("Ahiraavan").transform;
		var rig = Ahiraavan.FindChild("rig").transform;
		var rigRoot = rig.FindChild("rig|root").transform;
		//RIGHT
		var rShoulder 	= rigRoot.FindChild("rig|MCH-upper_arm.fk.R.socket2").transform;
		var rUpperarm 	= rShoulder.FindChild("rig|upper_arm.fk.R").transform;
		var rUpperarm1 	= rUpperarm.FindChild("rig|MCH-upper_arm_antistr.fk.R").transform;
		var rForearm 	= rUpperarm1.FindChild("rig|forearm.fk.R").transform;
		var rForearm1 	= rForearm.FindChild("rig|MCH-forearm_antistr.fk.R").transform;
		rightHandPower 	= rForearm1.FindChild("Red Power").gameObject as GameObject;
	//	rightHandPower.SetActive(true);

		//Left
		//RIGHT
		var lShoulder 	= rigRoot.FindChild("rig|MCH-upper_arm.fk.L.socket2").transform;
		var lUpperarm 	= lShoulder.FindChild("rig|upper_arm.fk.L").transform;
		var lUpperarm1 	= lUpperarm.FindChild("rig|MCH-upper_arm_antistr.fk.L").transform;
		var lForearm 	= lUpperarm1.FindChild("rig|forearm.fk.L").transform;
		var lForearm1 	= lForearm.FindChild("rig|MCH-forearm_antistr.fk.L").transform;
		leftHandPower 	= lForearm1.FindChild("Red Power").gameObject as GameObject;
	//	leftHandPower.SetActive(true);
		
	}


}

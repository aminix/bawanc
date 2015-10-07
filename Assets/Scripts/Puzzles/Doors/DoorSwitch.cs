using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {

	//public static


	//public
	public bool AutomaticOpeningDoor;
	public bool KeyNeededToOpenDoor;
	public bool IsItHackable;
	public bool GateOpen;

	//private
	private Animator anim;
	private float timer;



	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(GateOpen)
		{
			timer += Time.deltaTime;
		}
		if(timer > 2)
		{
			GateOpen = false;
			timer = 0;
		}
	}

	void OnCollisionEnter(Collision coll)
	{

		if(coll.gameObject.tag == "Player" && !GateOpen)
		{
			if(KeyNeededToOpenDoor)
			{
				Debug.Log("Please bring desired key");
			}
			else
			{
				if(AutomaticOpeningDoor)
				{
					Vector3 df = (transform.position - coll.gameObject.transform.position);
					df = (new Vector3(df.x,0,df.z).normalized);

					if(df.x > 0)
					{
						anim.SetTrigger("Open Sesame Right");
					}
					else
					{
						anim.SetTrigger("Open Sesame Left");
					}

					GateOpen = true;
				}

			}

		}



		Debug.Log(coll.gameObject +" Collided");
	}

	void OnTriggerEnter(Collider coll)
	{

		Debug.Log(coll.gameObject+ " Triggered");
	}


}

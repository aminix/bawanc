using UnityEngine;
using System.Collections;

public class PinkPowerScript : MonoBehaviour {

	public GameObject jumpEffectPrefab;
	GameObject jumpEffect;
	public float jumpForceAdded = 1.5f;
	float jumpEffectTime = 2;
//	private Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("z")) {
			bool grounded = Physics.Linecast (transform.position, gameObject.GetComponent<wowc> ().groundCheck.position);

			if (grounded) {
				//anim.SetTrigger("Big_Jump");
				jumpEffect = Instantiate(jumpEffectPrefab);
				//is -0.8 because the capsule's Y position is not exactly the ground, also groundCheck object is too below to be used as reference as well
				jumpEffect.transform.position = new Vector3(transform.position.x, transform.position.y -0.8f, transform.position.z);
				gameObject.GetComponent<wowc> ().Jump(gameObject.GetComponent<wowc> ().jumpForce * jumpForceAdded);
				Destroy(jumpEffect, jumpEffectTime);
			}

		}
	
	}
}

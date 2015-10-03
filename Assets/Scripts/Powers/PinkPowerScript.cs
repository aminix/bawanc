using UnityEngine;
using System.Collections;

public class PinkPowerScript : MonoBehaviour {

	public GameObject jumpEffectPrefab;
	GameObject jumpEffect;
	float jumpEffectTime = 2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			bool grounded = Physics.Linecast (transform.position, gameObject.GetComponent<wowc> ().groundCheck.position);
			Debug.Log (grounded);
			if (!grounded) {
				jumpEffect = Instantiate(jumpEffectPrefab);
				gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0f,0f); //reset velocity so second jump can happen when falling too

				//is -0.8 because the capsule's Y position is not exactly the ground, also groundCheck object is too below to be used as reference as well
				jumpEffect.transform.position = new Vector3(transform.position.x, transform.position.y -0.8f, transform.position.z);
				gameObject.GetComponent<wowc> ().Jump(gameObject.GetComponent<wowc> ().jumpForce);
				Destroy(jumpEffect, jumpEffectTime);
				this.enabled = false;
			}

		}
	
	}
}

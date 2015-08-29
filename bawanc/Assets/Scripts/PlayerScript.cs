using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		float x = Input.GetAxis ("Horizontal") * 1000 * Time.deltaTime;
		float y = Input.GetAxis ("Vertical") * 1000 * Time.deltaTime;
		Debug.Log (x);
		Vector3 f = new Vector3 (x, y, 0);
		rb.AddForce (f);
	}
}

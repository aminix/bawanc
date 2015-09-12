using UnityEngine;
using System.Collections;

public class PurplePowerScript : MonoBehaviour {
	public GameObject portalPrefab;
	GameObject myPortal;
	// Use this for initialization
	void Start () {
		myPortal = Instantiate (portalPrefab);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			//portal.SetActive (true);
			myPortal.transform.position = transform.position;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			//portal.SetActive (true);
			transform.position = myPortal.transform.position;
		}
	}
}

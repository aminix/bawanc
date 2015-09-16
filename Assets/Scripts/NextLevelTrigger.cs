using UnityEngine;
using System.Collections;

/*
 * This class should go attached to an invisible object
 * at the end of each level and triggers the next one
 * 
 */
public class NextLevelTrigger : MonoBehaviour {
	public int nextSceneNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Next level is " + nextSceneNumber);
		if (other.tag == "Player") {
			Object.DontDestroyOnLoad (GameController.Instance);
			Application.LoadLevel (nextSceneNumber);
		}

	}
}

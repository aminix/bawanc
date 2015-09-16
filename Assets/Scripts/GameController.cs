using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public Vector3 respawnPoint; //point where character will respawn when he dies, other scripts will change it
	private GameObject character;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		respawnPoint = new Vector3 (1, 0, 0); //first point
		character = GameObject.FindWithTag ("Player");
		character.transform.position = respawnPoint;
	
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	//Call when character dies, should be called from the object that killed the character
	public void respawnCharacter() 
	{
		Debug.Log ("Character died :(");
		character.transform.position = respawnPoint;
	}
	
	//Call when player finishes the game
	public void GameOver() 
	{
		Debug.Log ("Player finished game");
		//call scene with credits?
	}


}

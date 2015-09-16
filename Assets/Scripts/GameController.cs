﻿using UnityEngine;
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

	//Call when player clicks Start Game from menu
	public void GameStart() 
	{
		Debug.Log ("Start game");
		//this implementation depends on the menu, should hide the menu
		// if the menu is in the scene, or load scene 0 if menu is in different scene
	}

	//Call when player finishes the game or quit
	public void GameOver() 
	{
		Debug.Log ("Player finished game");
		respawnPoint = new Vector3 (1, 0, 0); //first point
		character.transform.position = respawnPoint;
		//this method should probably have to change, show the start menu?
	}


}

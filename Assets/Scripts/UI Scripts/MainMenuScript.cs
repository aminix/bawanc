using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

     public void QuitGame()
    {
        Application.Quit(); // Will work once build and tested.. i think
    }

    public void StartGame()
    {
        Application.LoadLevel("Level 1"); 
    }
}

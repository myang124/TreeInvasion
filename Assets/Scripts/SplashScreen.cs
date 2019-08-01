/**
 * Splash Screen script to load from splash screen to main menu. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

	//Runs the game
	void Start ()
    {
        StartCoroutine("MainMenu");
	}
	
	//Method not used
	void Update () {
		
	}

    //Loads main menu level after 5 seconds.
    public IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(1);
    }
}

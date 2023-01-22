using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Awake()
	{
		Time.timeScale = 1;
	}

	public void PlayGame (){

	SceneManager.LoadScene(1);
    }

    public void HowToPlay (){

	SceneManager.LoadScene(2);
    }

    public void Menu (){

	SceneManager.LoadScene(0);
    }

    public void QuitGame (){
	    Debug.Log("QUIT");  
	Application.Quit();
    }

}

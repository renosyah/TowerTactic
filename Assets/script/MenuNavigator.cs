using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuNavigator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
   
       SceneManager.LoadScene("MainMenu");

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void Option()
    {
        SceneManager.LoadScene("OptionScene");
    }
   

    public void Exit()
    {
        Application.Quit();
    }
}

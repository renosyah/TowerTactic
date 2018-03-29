using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuNavigator : MonoBehaviour {

    public bool ThisIsOptionsMenu;
    public GameObject gameObject;
    public bool ThisIsMainMenu;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ThisIsOptionsMenu && gameObject != null)
        {
            gameObject.GetComponent<OptionSetting>().SaveNow();
            MainMenu();

        }else if (Input.GetKeyDown(KeyCode.Escape) && ThisIsMainMenu){
            Application.Quit();
        }

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

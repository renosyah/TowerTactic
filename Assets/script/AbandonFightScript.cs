using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonFightScript : MonoBehaviour {

	public GameObject GameObjectToReveal;
	void Start () {
		
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowAbandonDialog();
        }
            
    }

    public void ShowAbandonDialog()
    {
        GameObjectToReveal.SetActive(true);
    }

    public void DismissAbandonDialog()
    {
        GameObjectToReveal.SetActive(false);
    }
}

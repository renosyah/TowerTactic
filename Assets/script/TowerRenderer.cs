using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRenderer : MonoBehaviour {
    public Sprite tower1, tower2, tower3;
    public string side;
    SpriteRenderer imagerender;
   
    // Use this for initialization
    void Start () {
        imagerender = GetComponent<SpriteRenderer>();
       
        ChangeImageTower(Random.Range(1,6));
    }

    void ChangeImageTower(int i)
    {
        if (i == 1)
        {
            imagerender.sprite = tower1;

        }else if (i == 2)
        {
            imagerender.sprite = tower2;
        }
        else if (i == 3)
        {
            imagerender.sprite = tower3;
        }else if (i == 4)
        {
            imagerender.sprite = tower3;

        }
        else if (i == 5)
        {
            imagerender.sprite = tower2;
        }
        else if (i == 6)
        {
            imagerender.sprite = tower1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}

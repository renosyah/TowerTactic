using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRenderer : MonoBehaviour {
    public Sprite sky1, sky2, sky3, sky4;
    SpriteRenderer imagerender;
    // Use this for initialization
    void Start () {
        imagerender = GetComponent<SpriteRenderer>();

        ChangeImageTower(Random.Range(1, 5));
    }
    void ChangeImageTower(int i)
    {
        if (i == 1)
        {
            imagerender.sprite = sky1;

        }
        else if (i == 2)
        {
            imagerender.sprite = sky2;
        }
        else if (i == 3)
        {
            imagerender.sprite = sky3;
        }
        else if (i == 4)
        {
            imagerender.sprite = sky4;

        }
        else if (i == 5)
        {
            imagerender.sprite = sky4;

        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
    Rigidbody2D rd;
    public int SwordHP;

	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody2D>();
        SwordHP = SwordHP + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            SwordHP--;
            if (SwordHP <= 0)
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
